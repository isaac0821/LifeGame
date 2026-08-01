using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace LifeGame
{
    public static class TreeBuilderService
    {
        #region ScannedTaskNode

        public class ScannedTaskNode
        {
            public string NoteGUID;
            public string NoteTopic;
            public DateTime NoteTagTime;
            public OutlineLine Line;
            public string ParentText;
            public bool IsExpired;
        }

        #endregion

        #region Static Parse Helpers

        public static string ParseTaskName(string taskText)
        {
            if (string.IsNullOrEmpty(taskText)) return "";
            string t = taskText.StartsWith("$TASK$>") ? taskText.Substring(7) : taskText;
            int at = t.LastIndexOf('@');
            if (at < 0) return t;
            return t.Substring(0, at);
        }

        public static DateTime ParseTaskStart(string taskText)
        {
            if (string.IsNullOrEmpty(taskText)) return DateTime.MinValue;
            string t = taskText.StartsWith("$TASK$>") ? taskText.Substring(7) : taskText;
            t = StripWeeklySuffix(t);
            int at = t.LastIndexOf('@');
            if (at < 0) return DateTime.MinValue;
            string range = t.Substring(at + 1);
            int sep = range.IndexOf('-');
            if (sep >= 0) return TryParseDate(range.Substring(0, sep));
            return TryParseDate(range);
        }

        public static DateTime ParseTaskEnd(string taskText)
        {
            if (string.IsNullOrEmpty(taskText)) return DateTime.MinValue;
            string t = taskText.StartsWith("$TASK$>") ? taskText.Substring(7) : taskText;
            t = StripWeeklySuffix(t);
            int at = t.LastIndexOf('@');
            if (at < 0) return DateTime.MinValue;
            string range = t.Substring(at + 1);
            int sep = range.IndexOf('-');
            if (sep >= 0) return TryParseDate(range.Substring(sep + 1));
            return TryParseDate(range);
        }

        public static DateTime ParseSchlDate(string schlText)
        {
            if (string.IsNullOrEmpty(schlText)) return DateTime.MinValue;
            string t = schlText.StartsWith("$SCHL$>") ? schlText.Substring(7) : schlText;
            var parts = t.Split('@');
            if (parts.Length >= 2)
            {
                var lastDate = TryParseDate(parts[parts.Length - 1]);
                if (lastDate != DateTime.MinValue) return lastDate;
            }
            if (parts.Length >= 2)
            {
                var dt = TryParseDate(parts[1]);
                if (dt != DateTime.MinValue) return dt;
            }
            return DateTime.MinValue;
        }

        public static DateTime ParseDdlDate(string text)
        {
            if (string.IsNullOrEmpty(text)) return DateTime.MinValue;
            string t = text.StartsWith("$DDLI$>", StringComparison.OrdinalIgnoreCase) ? text.Substring(7)
                : text.StartsWith("date:", StringComparison.OrdinalIgnoreCase) ? text.Substring(5) : text;
            int atIdx = t.IndexOf('@');
            if (atIdx < 0) return DateTime.MinValue;
            var match = Regex.Match(t.Substring(0, atIdx), @"^(\d{4}\.\d{1,2}\.\d{1,2})$");
            if (match.Success) return TryParseDate(match.Groups[1].Value);
            return DateTime.MinValue;
        }

        public static string ParseDdlName(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            string t = text.StartsWith("$DDLI$>", StringComparison.OrdinalIgnoreCase) ? text.Substring(7)
                : text.StartsWith("date:", StringComparison.OrdinalIgnoreCase) ? text.Substring(5) : text;
            int atIdx = t.IndexOf('@');
            if (atIdx < 0) return "";
            return t.Substring(atIdx + 1);
        }

        public static DateTime TryParseDate(string s)
        {
            if (string.IsNullOrEmpty(s)) return DateTime.MinValue;
            s = s.Trim().Replace('.', '/');
            string[] fmts = { "yyyy/MM/dd", "yyyy-MM-dd", "MM/dd/yyyy" };
            if (DateTime.TryParseExact(s, fmts, System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime dt)) return dt;
            if (DateTime.TryParse(s, out dt)) return dt;
            return DateTime.MinValue;
        }

        public static string StripWeeklySuffix(string taskText)
        {
            if (string.IsNullOrEmpty(taskText)) return taskText;
            var match = Regex.Match(taskText, @"@\{[^}]+\}\s*$");
            if (!match.Success) return taskText;
            return taskText.Substring(0, match.Index).TrimEnd();
        }

        public static DateTime GetTaskEndDate(OutlineLine line)
        {
            if (line.MetaType == NodeMetaType.Task) return ParseTaskEnd(line.Text);
            if (line.MetaType == NodeMetaType.Schedule) return ParseSchlDate(line.Text);
            return DateTime.MinValue;
        }

        #endregion

        #region ScanAllNotesForTasks

        public static List<ScannedTaskNode> ScanAllNotesForTasks()
        {
            var result = new List<ScannedTaskNode>();
            var sysNoteNames = new HashSet<string> {
                "SysNote: Menu",
                "SysNote: Note Archive", "SysNote: Task History",
                "SysNote: Calendar", "SysNote: Diary",
                "SysNote: Literature Review",
            };
            var today = DateTime.Today;

            foreach (var note in G.glb.lstNote)
            {
                if (sysNoteNames.Contains(note.Topic)) continue;

                // 内存缓存已在启动时从 YAML 加载，两者都为空时从磁盘恢复
                if (note.Tasks.Count == 0 && note.DDLs.Count == 0)
                    EnsureNoteTasksFromDisk(note);

                // 有 Tasks 但缺少 DDLs 时，单独从 body 恢复 DDLs
                if (note.DDLs.Count == 0 && note.Tasks.Count > 0)
                {
                    try
                    {
                        string fileName = MarkdownNoteConverter.MakeNoteFileName(note.Created, note.Topic);
                        string filePath = Path.Combine(DataFileHelper.NotesDir, fileName);
                        if (File.Exists(filePath))
                        {
                            string raw = File.ReadAllText(filePath, Encoding.UTF8);
                            var (_, body) = GameDocument.SplitFrontMatter(raw);
                            if (!string.IsNullOrEmpty(body))
                            {
                                foreach (var line in body.Split('\n'))
                                {
                                    string trimmed = line.Trim();
                                    if (trimmed.StartsWith("$DDLI$>"))
                                        note.DDLs.Add(new DDLEntry { Text = trimmed, Parent = "" });
                                }
                            }
                        }
                    }
                    catch { }
                }

                if (note.Tasks.Count == 0 && note.DDLs.Count == 0) continue;

                // 1. 从 DDLs 字段读取（新机制，含父节点信息）
                foreach (var ddl in note.DDLs)
                {
                    var line = new OutlineLine { Text = ddl.Text, MetaType = NodeMetaType.Deadline, GUID = Guid.NewGuid().ToString() };
                    result.Add(new ScannedTaskNode
                    {
                        NoteGUID = note.GUID,
                        NoteTopic = note.Topic,
                        NoteTagTime = note.Created,
                        Line = line,
                        ParentText = ddl.Parent ?? "",
                        IsExpired = false,
                    });
                }

                // 2. 从 Tasks 字段读取（Task / Schedule / Progress，以及向后兼容的 Deadline）
                foreach (var task in note.Tasks)
                {
                    NodeMetaType metaType;
                    if (task.MetaType == "Task") metaType = NodeMetaType.Task;
                    else if (task.MetaType == "Schedule") metaType = NodeMetaType.Schedule;
                    else if (task.MetaType == "Deadline")
                    {
                        // 若已有 DDLs 字段，跳过 Tasks 中的 Deadline 避免重复
                        if (note.DDLs.Count > 0) continue;
                        metaType = NodeMetaType.Deadline;
                    }
                    else if (task.MetaType == "Progress") metaType = NodeMetaType.Progress;
                    else continue;

                    var line = new OutlineLine { Text = task.Text, MetaType = metaType, GUID = Guid.NewGuid().ToString() };

                    bool expired = false;
                    if (metaType == NodeMetaType.Task)
                    {
                        var end = ParseTaskEnd(task.Text);
                        expired = end != DateTime.MinValue && end < today;
                    }
                    else if (metaType == NodeMetaType.Schedule)
                    {
                        var date = ParseSchlDate(task.Text);
                        expired = date != DateTime.MinValue && date < today;
                    }

                    result.Add(new ScannedTaskNode
                    {
                        NoteGUID = note.GUID,
                        NoteTopic = note.Topic,
                        NoteTagTime = note.Created,
                        Line = line,
                        ParentText = "",
                        IsExpired = expired,
                    });
                }
            }

            return result;
        }

        /// <summary>从磁盘加载 Note 的 Tasks/DDLs（当内存中为空时）</summary>
        private static void EnsureNoteTasksFromDisk(NoteDocument note)
        {
            try
            {
                string fileName = MarkdownNoteConverter.MakeNoteFileName(note.Created, note.Topic);
                string filePath = Path.Combine(DataFileHelper.NotesDir, fileName);
                if (!File.Exists(filePath)) return;

                // 清空旧的缓存数据，重新从磁盘加载
                note.Tasks.Clear();
                note.DDLs.Clear();

                string raw = File.ReadAllText(filePath, Encoding.UTF8);
                var (yaml, body) = GameDocument.SplitFrontMatter(raw);

                // 优先从 YAML 解析 tasks / ddls
                if (!string.IsNullOrEmpty(yaml))
                {
                    var dict = GameDocument.ParseSimpleYaml(yaml);
                    if (dict.TryGetValue("tasks", out var tasksObj) && tasksObj is System.Collections.IList taskList)
                    {
                        foreach (var item in taskList)
                        {
                            if (item is Dictionary<string, object> tdict &&
                                tdict.TryGetValue("text", out var txt) &&
                                tdict.TryGetValue("meta", out var meta))
                            {
                                note.Tasks.Add(new NoteTask { Text = txt?.ToString() ?? "", MetaType = meta?.ToString() ?? "Task" });
                            }
                        }
                    }
                    if (dict.TryGetValue("ddls", out var ddlsObj) && ddlsObj is System.Collections.IList ddlList)
                    {
                        foreach (var item in ddlList)
                        {
                            if (item is Dictionary<string, object> ddict &&
                                ddict.TryGetValue("text", out var txt))
                            {
                                string parent = ddict.TryGetValue("parent", out var p) ? p?.ToString() ?? "" : "";
                                note.DDLs.Add(new DDLEntry { Text = txt?.ToString() ?? "", Parent = parent });
                            }
                        }
                    }
                }

                // 从 body 扫描缺失的 $TASK$> / $SCHL$> / $PROG$> / $DDLI$>
                if (!string.IsNullOrEmpty(body))
                {
                    bool needTasks = note.Tasks.Count == 0;
                    bool needDDLs = note.DDLs.Count == 0;
                    if (needTasks || needDDLs)
                    {
                        foreach (var line in body.Split('\n'))
                        {
                            string trimmed = line.Trim();
                            if (string.IsNullOrEmpty(trimmed)) continue;
                            if (needTasks && trimmed.StartsWith("$TASK$>"))
                                note.Tasks.Add(new NoteTask { Text = trimmed, MetaType = "Task" });
                            else if (needTasks && trimmed.StartsWith("$SCHL$>"))
                                note.Tasks.Add(new NoteTask { Text = trimmed, MetaType = "Schedule" });
                            else if (needTasks && trimmed.StartsWith("$PROG$>"))
                                note.Tasks.Add(new NoteTask { Text = trimmed, MetaType = "Progress" });
                            else if (needDDLs && trimmed.StartsWith("$DDLI$>"))
                                note.DDLs.Add(new DDLEntry { Text = trimmed, Parent = "" });
                        }
                    }
                }
            }
            catch { }
        }

        #endregion

        #region Tree Building - TDL

        public static void BuildTDLIndexTree(OutlinePanel outlinePanel)
        {
            var treeLines = new List<OutlineLine>();
            int order = 0;
            var allScanned = ScanAllNotesForTasks();
            var scanned = allScanned
                .Where(sn => sn.Line.MetaType == NodeMetaType.Task && !sn.IsExpired)
                .ToList();

            // === To Do List 分区 (level 0) ===
            string tdlSectionGUID = "TDL_TASKS_SEC";
            treeLines.Add(new OutlineLine
            {
                Level = 0, ParentGUID = "", GUID = tdlSectionGUID,
                Text = "To Do List",
                Ordering = order++,
                Expanded = true,
            });

            var noteGroups = scanned
                .GroupBy(sn => sn.NoteGUID)
                .OrderBy(g => g.First().NoteTopic);

            foreach (var noteGroup in noteGroups)
            {
                var first = noteGroup.First();
                string noteSectionGUID = "TDL_NOTE_" + order;
                treeLines.Add(new OutlineLine
                {
                    Level = 1, ParentGUID = tdlSectionGUID, GUID = noteSectionGUID,
                    Text = "$NOTE$>" + first.NoteTopic,
                    Ordering = order++,
                    Expanded = true,
                    MetaType = NodeMetaType.NoteRef,
                    MetaValue = first.NoteGUID,
                });

                var parentGroups = noteGroup
                    .GroupBy(sn => string.IsNullOrEmpty(sn.ParentText) ? null : sn.ParentText)
                    .OrderBy(g => g.Key);

                foreach (var parentGroup in parentGroups)
                {
                    if (parentGroup.Key == null)
                    {
                        foreach (var sn in parentGroup)
                            AddLineWithSubtree(treeLines, sn.Line, noteSectionGUID, 2, ref order, sn.NoteGUID);
                        continue;
                    }

                    string parentGUID = "TDL_PARENT_" + order;
                    treeLines.Add(new OutlineLine
                    {
                        Level = 2, ParentGUID = noteSectionGUID, GUID = parentGUID,
                        Text = parentGroup.Key,
                        Ordering = order++,
                        Expanded = true,
                    });

                    foreach (var sn in parentGroup)
                    {
                        AddLineWithSubtree(treeLines, sn.Line, parentGUID, 3, ref order, sn.NoteGUID);
                    }
                }
            }

            // === Deadline 分区 (level 0，与 To Do List 平级) ===
            var ddls = allScanned
                .Where(sn => sn.Line.MetaType == NodeMetaType.Deadline)
                .ToList();

            if (ddls.Count > 0)
            {
                string deadlineSectionGUID = "TDL_DEADLINE_SEC";
                treeLines.Add(new OutlineLine
                {
                    Level = 0, ParentGUID = "", GUID = deadlineSectionGUID,
                    Text = "Deadline",
                    Ordering = order++,
                    Expanded = true,
                });

                var ddlNoteGroups = ddls
                    .GroupBy(sn => sn.NoteGUID)
                    .OrderBy(g => g.First().NoteTopic);

                foreach (var noteGroup in ddlNoteGroups)
                {
                    var first = noteGroup.First();
                    string ddlNoteGUID = "TDL_DDL_NOTE_" + order;
                    treeLines.Add(new OutlineLine
                    {
                        Level = 1, ParentGUID = deadlineSectionGUID, GUID = ddlNoteGUID,
                        Text = "$NOTE$>" + first.NoteTopic,
                        Ordering = order++,
                        Expanded = true,
                        MetaType = NodeMetaType.NoteRef,
                        MetaValue = first.NoteGUID,
                    });

                    foreach (var ddl in noteGroup.OrderBy(d => ParseDdlDate(d.Line.Text)))
                    {
                        string ddlName = ParseDdlName(ddl.Line.Text);
                        DateTime ddlDate = ParseDdlDate(ddl.Line.Text);
                        string dateStr = ddlDate != DateTime.MinValue ? ddlDate.ToString("yyyy.MM.dd") + " " : "";
                        treeLines.Add(new OutlineLine
                        {
                            Level = 2, ParentGUID = ddlNoteGUID,
                            GUID = "TDL_DDL_" + order,
                            Text = "$DDLI$>" + dateStr + ddlName,
                            Ordering = order++,
                            MetaType = NodeMetaType.Deadline,
                        });
                    }
                }
            }

            if (treeLines.Count == 1)
            {
                treeLines.Add(new OutlineLine { Level = 1, ParentGUID = tdlSectionGUID, GUID = "TDL_EMPTY",
                    Text = "(No active tasks)", Ordering = order++ });
            }

            outlinePanel.LoadLines(treeLines);
            outlinePanel.SetRootTitle("Calendar");
            outlinePanel.RefreshLayout();
        }

        #endregion

        #region Tree Building - Archive

        public static void BuildArchiveIndexTree(OutlinePanel outlinePanel)
        {
            var treeLines = new List<OutlineLine>();
            int order = 0;
            var today = DateTime.Today;
            var scanned = ScanAllNotesForTasks()
                .Where(sn => sn.IsExpired)
                .ToList();

            var yearGroups = scanned
                .GroupBy(sn =>
                {
                    var d = GetTaskEndDate(sn.Line);
                    return d == DateTime.MinValue ? 0 : d.Year;
                })
                .Where(g => g.Key > 0)
                .OrderByDescending(g => g.Key);

            foreach (var yearGroup in yearGroups)
            {
                string yearGUID = "ARC_YEAR_" + order;
                treeLines.Add(new OutlineLine
                {
                    Level = 0, ParentGUID = "", GUID = yearGUID,
                    Text = "\uD83D\uDCC5 " + yearGroup.Key.ToString(),
                    Ordering = order++, Expanded = true,
                });

                var monthGroups = yearGroup
                    .GroupBy(sn =>
                    {
                        var d = GetTaskEndDate(sn.Line);
                        return d.Month;
                    })
                    .OrderByDescending(g => g.Key);

                foreach (var monthGroup in monthGroups)
                {
                    string monthGUID = "ARC_MONTH_" + order;
                    treeLines.Add(new OutlineLine
                    {
                        Level = 1, ParentGUID = yearGUID, GUID = monthGUID,
                        Text = "\uD83D\uDCC6 " + monthGroup.Key.ToString("00") + "\u6708",
                        Ordering = order++, Expanded = true,
                    });

                    var noteGroups = monthGroup
                        .GroupBy(sn => sn.NoteGUID)
                        .OrderBy(g => g.First().NoteTopic);

                    foreach (var noteGroup in noteGroups)
                    {
                        var first = noteGroup.First();
                        string noteGUID = "ARC_NOTE_" + order;
                        treeLines.Add(new OutlineLine
                        {
                            Level = 2, ParentGUID = monthGUID, GUID = noteGUID,
                            Text = "$NOTE$>" + first.NoteTopic,
                            MetaType = NodeMetaType.NoteRef,
                            MetaValue = first.NoteGUID,
                            Ordering = order++,
                            Expanded = true,
                        });

                        foreach (var sn in noteGroup)
                        {
                            string lineGUID = "ARC_LINE_" + order;
                            treeLines.Add(new OutlineLine
                            {
                                Level = 3, ParentGUID = noteGUID, GUID = lineGUID,
                                Text = sn.Line.Text,
                                MetaType = sn.Line.MetaType,
                                MetaValue = sn.NoteGUID,
                                Ordering = order++,
                                Expanded = false,
                                LabelKeywords = sn.Line.LabelKeywords,
                                ProgressPercent = sn.Line.ProgressPercent,
                            });
                        }
                    }
                }
            }

            if (treeLines.Count == 0)
            {
                treeLines.Add(new OutlineLine { Level = 0, ParentGUID = "", GUID = "ARC_EMPTY",
                    Text = "(No archived tasks)", Ordering = 0 });
            }

            outlinePanel.LoadLines(treeLines);
            outlinePanel.SetRootTitle("Task History");
            outlinePanel.RefreshLayout();
        }

        #endregion

        #region Tree Building - Notes Index

        public static void LoadNotesIndexTree(OutlinePanel outlinePanel)
        {
            var treeLines = new List<OutlineLine>();
            int order = 0;

            var sysNoteNames = new HashSet<string> {
                "SysNote: Menu",
                "SysNote: Note Archive", "SysNote: Task History",
                "SysNote: Calendar", "SysNote: Diary"
            };
            var regularNotes = G.glb.lstNote
                .Where(o => !sysNoteNames.Contains(o.Topic))
                .OrderByDescending(o => o.Created)
                .ThenBy(o => o.Topic)
                .ToList();

            var years = regularNotes.GroupBy(o => o.Created.Year)
                .OrderByDescending(g => g.Key);

            foreach (var yearGroup in years)
            {
                string yearGUID = "NI_YEAR_" + yearGroup.Key;
                treeLines.Add(new OutlineLine
                {
                    Level = 0, ParentGUID = "", GUID = yearGUID,
                    Text = "\uD83D\uDCC5 " + yearGroup.Key.ToString(),
                    Ordering = order++, Expanded = false,
                });

                var months = yearGroup.GroupBy(o => o.Created.Month)
                    .OrderByDescending(g => g.Key);
                foreach (var monthGroup in months)
                {
                    string monthGUID = yearGUID + "_M" + monthGroup.Key;
                    treeLines.Add(new OutlineLine
                    {
                        Level = 1, ParentGUID = yearGUID, GUID = monthGUID,
                        Text = "\uD83D\uDCC6 " + monthGroup.Key.ToString("00") + "\u6708",
                        Ordering = order++, Expanded = false,
                    });

                    foreach (var n in monthGroup)
                    {
                        string noteGUID = "NI_NOTE_" + n.GUID;
                        treeLines.Add(new OutlineLine
                        {
                            Level = 2, ParentGUID = monthGUID, GUID = noteGUID,
                            Text = "$NOTE$>" + n.Created.ToString("yyyy.MM.dd") + "@" + n.Topic,
                            MetaType = NodeMetaType.NoteRef,
                            MetaValue = n.Topic,
                            Ordering = order++,
                        });
                    }
                }
            }

            if (treeLines.Count == 0)
            {
                treeLines.Add(new OutlineLine { Level = 0, ParentGUID = "", GUID = "NI_EMPTY",
                    Text = "(No notes yet)", Ordering = 0 });
            }

            outlinePanel.LoadLines(treeLines);
            outlinePanel.SetRootTitle("Notes");
            outlinePanel.RefreshLayout();
        }

        #endregion

        #region Menu Content

        public static void LoadMenuContent(OutlinePanel outlinePanel, List<OutlineLine> contentLines, List<RNoteColor> colors, string guid)
        {
            var allLines = new List<OutlineLine>();
            int order = 0;

            const string funcGUID = "MENU_FUNCTIONS";
            var funcNode = new OutlineLine
            {
                Text = "Functions",
                Level = 0, ParentGUID = "", GUID = funcGUID,
                IsMetaNode = true, IsMetaSectionHeader = true,
                AllowAddChild = false, Expanded = true,
                Ordering = order++,
            };
            allLines.Add(funcNode);

            AddMenuMetaLine(allLines, ref order, "MENU_CAL", "$FUNC$>SysNote: Calendar", "SysNote: Calendar", funcGUID);
            AddMenuMetaLine(allLines, ref order, "MENU_DIARY", "$FUNC$>SysNote: Diary", "SysNote: Diary", funcGUID);

            // ========== Indexes 分区 ==========
            const string idxGUID = "MENU_INDEXES";
            var idxNode = new OutlineLine
            {
                Text = "Indexes",
                Level = 0, ParentGUID = "", GUID = idxGUID,
                IsMetaNode = true, IsMetaSectionHeader = true,
                AllowAddChild = false, Expanded = true,
                Ordering = order++,
            };
            allLines.Add(idxNode);

            AddMenuMetaLine(allLines, ref order, "MENU_ARC", "$FUNC$>SysNote: Task History", "SysNote: Task History", idxGUID);
            AddMenuMetaLine(allLines, ref order, "MENU_NOTES", "$FUNC$>SysNote: Note Archive", "SysNote: Note Archive", idxGUID);
            AddMenuMetaLine(allLines, ref order, "MENU_LREV", "$FUNC$>SysNote: Literature Review", "SysNote: Literature Review", idxGUID);

            int contentOrder = order;
            if (contentLines != null && contentLines.Count > 0)
            {
                foreach (var line in contentLines)
                {
                    line.Ordering = contentOrder++;
                    allLines.Add(line);
                }
            }
            else
            {
                allLines.Add(new OutlineLine
                {
                    Level = 0, ParentGUID = "", GUID = "MENU_DEFAULT",
                    Text = "Welcome to LifeGame!", Ordering = contentOrder++,
                });
            }

            outlinePanel.LoadLines(allLines);
            outlinePanel.SetRootTitle("LifeGame Menu");
            outlinePanel.RefreshLayout();
        }

        public static void SaveMenuContent(OutlinePanel outlinePanel, string noteGUID, List<RNoteColor> noteColors)
        {
            // Menu content is already persisted to MenuFunc.md by frmLauncher.
        }

        #endregion

        #region Private Tree-Building Helpers

        private static void AddLineWithSubtree(List<OutlineLine> treeLines, OutlineLine line, string parentGUID,
            int level, ref int order, string sourceNoteGUID)
        {
            string lineGUID = "TDL_LINE_" + order;
            treeLines.Add(new OutlineLine
            {
                Level = level, ParentGUID = parentGUID, GUID = lineGUID,
                Text = line.Text,
                MetaType = line.MetaType,
                MetaValue = sourceNoteGUID,
                Ordering = order++,
                Expanded = line.Expanded,
                LabelKeywords = line.LabelKeywords,
                ProgressPercent = line.ProgressPercent,
            });

            var sourceNote = G.glb.lstNote.Find(n => n.GUID == sourceNoteGUID);
            if (sourceNote != null)
            {
                string filePath = MarkdownNoteConverter.MakeNotePath(sourceNote.Created, sourceNote.Topic);
                if (filePath != null)
                {
                    try { sourceNote.EnsureBodyLoaded(filePath); } catch { }
                    var allLines = sourceNote.Lines;
                    foreach (var child in allLines.Where(l => l.ParentGUID == line.GUID).OrderBy(l => l.Ordering))
                    {
                        if (child.IsMetaNode || child.IsMetaSectionHeader) continue;
                        AddLineWithSubtree(treeLines, child, lineGUID, level + 1, ref order, sourceNoteGUID);
                    }
                }
            }
        }

        private static void AddMenuMetaLine(List<OutlineLine> lines, ref int order, string guide,
            string displayText, string sysNoteTopic, string parentGUID)
        {
            lines.Add(new OutlineLine
            {
                Level = 1, ParentGUID = parentGUID, GUID = guide,
                Text = displayText,
                MetaType = NodeMetaType.FuncRef,
                MetaValue = sysNoteTopic,
                IsMetaNode = true,
                Ordering = order++,
            });
        }

        #endregion
    }
}
