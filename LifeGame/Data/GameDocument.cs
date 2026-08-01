using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LifeGame
{
    /// <summary>
    /// 所有 Markdown 文档类型（Note, Literature, Diary）的基类。
    /// 一个 .md 文件（含 YAML front matter）对应一个 GameDocument 实例。
    /// 
    /// 使用方式：
    ///   启动时：LoadMetadataOnly(filePath) → 只有 YAML 元数据，Lines 为空
    ///   打开编辑时：EnsureBodyLoaded(filePath) → 懒加载 body
    /// </summary>
    public abstract class GameDocument
    {
        public string GUID;
        public virtual string Topic { get; set; }
        public List<RNoteColor> Colors = new List<RNoteColor>();
        public List<DDLEntry> DDLs = new List<DDLEntry>();
        public List<OutlineLine> Lines = new List<OutlineLine>();

        public abstract string DocumentType { get; }

        // ========== 静态工厂 ==========

        /// <summary>从 .md 文件完整加载（YAML + body）</summary>
        public static GameDocument Load(string filePath)
        {
            if (!File.Exists(filePath)) return null;
            string raw = File.ReadAllText(filePath, Encoding.UTF8);
            var (yaml, body) = SplitFrontMatter(raw);

            var doc = CreateByType(ExtractTypeFromYaml(yaml));
            var dict = ParseSimpleYaml(yaml);
            doc.ParseYaml(dict);
            doc.ParseBody(body);
            return doc;
        }

        /// <summary>只加载 YAML 元数据，不解析 body（启动时使用，省内存）</summary>
        public static GameDocument LoadMetadataOnly(string filePath)
        {
            if (!File.Exists(filePath)) return null;
            string raw = File.ReadAllText(filePath, Encoding.UTF8);
            var (yaml, _) = SplitFrontMatter(raw);

            var doc = CreateByType(ExtractTypeFromYaml(yaml));
            var dict = ParseSimpleYaml(yaml);
            doc.ParseYaml(dict);
            // 不调用 ParseBody，Lines 保持空列表
            return doc;
        }

        /// <summary>获取或加载 body 的 OutlineLine 列表（未加载时从文件读取）</summary>
        public void EnsureBodyLoaded(string filePath)
        {
            if (Lines.Count > 0) return;
            string raw = File.ReadAllText(filePath, Encoding.UTF8);
            var (_, body) = SplitFrontMatter(raw);
            ParseBody(body);
        }

        private static GameDocument CreateByType(string type)
        {
            if (type == "Literature") return new LiteratureDocument();
            if (type == "LiteratureReview") return new LiteratureReviewDocument();
            if (type == "Diary") return new DiaryDocument();
            return new NoteDocument();
        }

        // ========== 实例方法（子类必须/可选实现） ==========

        /// <summary>保存文档。若 title/date 变化会删旧文件，返回新路径</summary>
        public abstract string Save(string oldFilePath);

        /// <summary>从解析好的 YAML 字典填充自身字段</summary>
        public abstract void ParseYaml(Dictionary<string, object> dict);

        /// <summary>构建 YAML front matter 字符串</summary>
        protected abstract string BuildYaml();

        /// <summary>解析 Markdown body。body[0] 是标题行，跳过、剩余行 Level 减一</summary>
        protected virtual void ParseBody(string body)
        {
            Lines = MarkdownNoteConverter.ParseOutlineBody(body);
            if (Lines.Count > 0 && Lines[0].Level == 0)
            {
                Lines.RemoveAt(0);
                foreach (var l in Lines) l.Level--;
            }
            // 动态从 Lines 中提取 DDL 条目（含父节点）
            DDLs = new List<DDLEntry>();
            var seenTexts = new HashSet<string>();
            for (int i = 0; i < Lines.Count; i++)
            {
                if (Lines[i].MetaType != NodeMetaType.Deadline) continue;
                string text = Lines[i].Text.Trim();
                if (!seenTexts.Add(text)) continue;

                // 向上查找最近的低层级节点作为父节点
                string parent = "";
                for (int j = i - 1; j >= 0; j--)
                {
                    if (Lines[j].Level < Lines[i].Level)
                    {
                        parent = Lines[j].Text;
                        break;
                    }
                }
                DDLs.Add(new DDLEntry { Text = text, Parent = parent });
            }
        }

        /// <summary>构建 Markdown body（标题行 + 缩进内容行）</summary>
        protected virtual string BuildBody(string titleText)
        {
            var bodyLines = new List<OutlineLine>();
            var titleLine = new OutlineLine { Text = titleText ?? "", Level = 0 };
            if (string.IsNullOrEmpty(titleLine.GUID)) titleLine.GUID = Guid.NewGuid().ToString();
            bodyLines.Add(titleLine);

            // 计算基准层级：树中内容行可能因 __ROOT__ 追加而比实际多一级
            // 归一化使第一级内容在文件中为 Level 1（标题 Level 0）
            int minLevel = Lines.Count > 0 ? Lines.Min(l => l.Level) : 0;
            int offset = 1 - minLevel; // 使最小层级变为 1

            foreach (var l in Lines)
            {
                // 克隆避免修改原始 Line 的 Level（原始对象可能被多处引用）
                var clone = new OutlineLine
                {
                    Text = l.Text, Level = l.Level + offset, GUID = l.GUID,
                    ParentGUID = l.ParentGUID, Ordering = l.Ordering,
                    IsMetaNode = l.IsMetaNode, IsMetaSectionHeader = l.IsMetaSectionHeader,
                    MetaType = l.MetaType, MetaValue = l.MetaValue,
                    Expanded = l.Expanded, AllowAddChild = l.AllowAddChild,
                    EditFormatHint = l.EditFormatHint,
                };
                bodyLines.Add(clone);
            }
            return MarkdownNoteConverter.BuildOutlineBody(bodyLines);
        }

        /// <summary>原子写入 .md 文件</summary>
        protected static void WriteFile(string path, string yaml, string body)
        {
            string content = "---\n" + yaml + "---\n\n" + body;
            DataFileHelper.AtomicWriteText(path, content);
            try
            {
                string logPath = "data\\logs\\save_debug.log";
                string dir = System.IO.Path.GetDirectoryName(logPath);
                if (!string.IsNullOrEmpty(dir)) System.IO.Directory.CreateDirectory(dir);
                System.IO.File.AppendAllText(logPath,
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [WriteFile] path={System.IO.Path.GetFileName(path)}, yamlLen={yaml.Length}, bodyLen={body.Length}, totalLen={content.Length}{Environment.NewLine}",
                    System.Text.Encoding.UTF8);
            }
            catch { }
        }

        // ========== YAML 解析引擎 ==========

        public static Dictionary<string, object> ParseSimpleYaml(string yaml)
        {
            var result = new Dictionary<string, object>();
            if (string.IsNullOrWhiteSpace(yaml)) return result;

            var lines = yaml.Split('\n');
            string currentKey = null;
            var currentList = new List<object>();
            var currentDict = new Dictionary<string, string>();
            string currentDictKey = null;

            for (int i = 0; i < lines.Length; i++)
            {
                string trimmed = lines[i].TrimEnd('\r');
                if (string.IsNullOrWhiteSpace(trimmed))
                {
                    FlushCurrent(result, ref currentKey, ref currentList, ref currentDict, ref currentDictKey);
                    continue;
                }

                string stripped = trimmed.TrimStart();
                if (stripped.StartsWith("- ") || stripped == "-")
                {
                    if (currentDictKey != null && currentDict.Count > 0)
                    {
                        currentList.Add(new Dictionary<string, string>(currentDict));
                        currentDict.Clear();
                        currentDictKey = null;
                    }

                    string item = stripped.Substring(2).Trim();
                    int colonIdx = FindFirstColon(item);
                    if (colonIdx >= 0)
                    {
                        string k = item.Substring(0, colonIdx).Trim();
                        string v = UnquoteYaml(item.Substring(colonIdx + 1).Trim());
                        currentDict[k] = v;
                        currentDictKey = k;
                    }
                    else
                    {
                        currentList.Add(UnquoteYaml(item));
                    }
                    continue;
                }

                if (currentDictKey != null)
                {
                    bool isIndented = trimmed.Length > stripped.Length;
                    if (!isIndented)
                    {
                        FlushCurrent(result, ref currentKey, ref currentList, ref currentDict, ref currentDictKey);
                    }
                    else
                    {
                        int cIdx = FindFirstColon(stripped);
                        if (cIdx >= 0)
                        {
                            string k = stripped.Substring(0, cIdx).Trim();
                            string v = UnquoteYaml(stripped.Substring(cIdx + 1).Trim());
                            currentDict[k] = v;
                            currentDictKey = k;
                            continue;
                        }
                        else
                        {
                            FlushCurrent(result, ref currentKey, ref currentList, ref currentDict, ref currentDictKey);
                        }
                    }
                }

                int colIdx = FindFirstColon(trimmed);
                if (colIdx >= 0)
                {
                    string k = trimmed.Substring(0, colIdx).Trim();
                    string v = trimmed.Substring(colIdx + 1).Trim();
                    if (string.IsNullOrEmpty(v))
                    {
                        currentKey = k;
                        currentList.Clear();
                        currentDict.Clear();
                        currentDictKey = null;
                    }
                    else
                    {
                        result[k] = UnquoteYaml(v);
                    }
                }
            }
            FlushCurrent(result, ref currentKey, ref currentList, ref currentDict, ref currentDictKey);
            return result;
        }

        private static void FlushCurrent(Dictionary<string, object> result,
            ref string currentKey, ref List<object> currentList,
            ref Dictionary<string, string> currentDict, ref string currentDictKey)
        {
            if (currentDictKey != null && currentDict.Count > 0)
            {
                currentList.Add(new Dictionary<string, string>(currentDict));
                currentDict.Clear();
                currentDictKey = null;
            }
            if (!string.IsNullOrEmpty(currentKey) && currentList.Count > 0)
            {
                if (currentList[0] is Dictionary<string, string>)
                    result[currentKey] = currentList.Cast<Dictionary<string, string>>().ToList();
                else
                    result[currentKey] = currentList.Cast<string>().ToList();
                currentKey = null;
                currentList = new List<object>();
            }
            else if (!string.IsNullOrEmpty(currentKey))
            {
                currentKey = null;
                currentList.Clear();
            }
        }

        private static int FindFirstColon(string line)
        {
            bool inQuote = false;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '"') inQuote = !inQuote;
                if (line[i] == ':' && !inQuote) return i;
            }
            return -1;
        }

        private static string UnquoteYaml(string v)
        {
            if (string.IsNullOrEmpty(v)) return "";
            v = v.Trim();
            if (v.StartsWith("\"") && v.EndsWith("\"")) return v.Substring(1, v.Length - 2);
            if (v.StartsWith("'") && v.EndsWith("'")) return v.Substring(1, v.Length - 2);
            return v;
        }

        // ========== YAML 字典访问器（子类 ParseYaml 使用） ==========

        protected static string Y(Dictionary<string, object> d, string key, string def = null)
        {
            if (d.TryGetValue(key, out var v)) return v?.ToString() ?? def;
            return def;
        }

        protected static int YInt(Dictionary<string, object> d, string key, int def = 0)
        {
            if (d.TryGetValue(key, out var v)) return int.TryParse(v?.ToString(), out int n) ? n : def;
            return def;
        }

        protected static bool YBool(Dictionary<string, object> d, string key, bool def = false)
        {
            if (d.TryGetValue(key, out var v)) return v?.ToString()?.ToLower() == "true";
            return def;
        }

        protected static DateTime YDate(Dictionary<string, object> d, string key, DateTime def)
        {
            if (d.TryGetValue(key, out var v)) return DateTime.TryParse(v?.ToString(), out DateTime dt) ? dt : def;
            return def;
        }

        protected static List<Dictionary<string, string>> YList(Dictionary<string, object> d, string key)
            => (d.TryGetValue(key, out var v) ? v as List<Dictionary<string, string>> : null)
               ?? new List<Dictionary<string, string>>();

        // ========== Colors 序列化/反序列化（三个子类共用） ==========

        protected static List<RNoteColor> ParseColors(Dictionary<string, object> d)
        {
            var result = new List<RNoteColor>();
            foreach (var item in YList(d, "colors"))
            {
                result.Add(new RNoteColor
                {
                    Keyword = item.TryGetValue("keyword", out var kw) ? kw : "",
                    Color = item.TryGetValue("color", out var cl) ? cl : "",
                });
            }
            return result;
        }

        protected static void AppendColorsYaml(StringBuilder sb, List<RNoteColor> colors)
        {
            if (colors == null || colors.Count == 0) return;
            sb.AppendLine("colors:");
            foreach (var c in colors)
            {
                sb.AppendLine($"  - keyword: \"{Esc(c.Keyword ?? "")}\"");
                sb.AppendLine($"    color: \"{Esc(c.Color ?? "")}\"");
            }
        }

        // ========== Tasks 序列化/反序列化（NoteDocument 用） ==========

        protected static List<NoteTask> ParseTasks(Dictionary<string, object> d)
        {
            var result = new List<NoteTask>();
            foreach (var item in YList(d, "tasks"))
            {
                result.Add(new NoteTask
                {
                    Text = item.TryGetValue("text", out var t) ? t : "",
                    MetaType = item.TryGetValue("meta_type", out var mt) ? mt : "",
                });
            }
            return result;
        }

        protected static void AppendTasksYaml(StringBuilder sb, List<NoteTask> tasks)
        {
            if (tasks == null || tasks.Count == 0) return;
            sb.AppendLine("tasks:");
            foreach (var t in tasks)
            {
                sb.AppendLine($"  - text: \"{Esc(t.Text)}\"");
                sb.AppendLine($"    meta_type: {t.MetaType}");
            }
        }

        // ========== DDLs 序列化/反序列化（基类共用） ==========

        protected static List<DDLEntry> ParseDDLs(Dictionary<string, object> d)
        {
            var result = new List<DDLEntry>();
            if (d.TryGetValue("ddls", out var v))
            {
                // 新格式：List<Dictionary<string,string>> 含 text + parent
                if (v is List<Dictionary<string, string>> dictList)
                {
                    foreach (var item in dictList)
                    {
                        result.Add(new DDLEntry
                        {
                            Text = item.TryGetValue("text", out var t) ? t : "",
                            Parent = item.TryGetValue("parent", out var p) ? p : "",
                        });
                    }
                }
                // 旧格式兼容：List<string> 纯文本
                else if (v is List<string> strList)
                {
                    foreach (var s in strList)
                        result.Add(new DDLEntry { Text = s, Parent = "" });
                }
            }
            return result;
        }

        protected static void AppendDDLYaml(StringBuilder sb, List<DDLEntry> ddls)
        {
            if (ddls == null || ddls.Count == 0) return;
            sb.AppendLine("ddls:");
            foreach (var ddl in ddls)
            {
                sb.AppendLine($"  - text: \"{Esc(ddl.Text)}\"");
                if (!string.IsNullOrEmpty(ddl.Parent))
                    sb.AppendLine($"    parent: \"{Esc(ddl.Parent)}\"");
            }
        }

        // ========== Schedules 序列化/反序列化（Diary 专属） ==========

        protected static List<ScheduleEntry> ParseSchedules(Dictionary<string, object> d)
        {
            var result = new List<ScheduleEntry>();
            foreach (var item in YList(d, "schedules"))
            {
                var entry = new ScheduleEntry
                {
                    Name     = item.TryGetValue("name", out var n) ? n : "",
                    Start    = item.TryGetValue("start", out var s) ? s : "",
                    End      = item.TryGetValue("end", out var e) ? e : "",
                    Color    = item.TryGetValue("color", out var c) ? c : "",
                    Location = item.TryGetValue("location", out var l) ? l : "",
                    WithWho  = item.TryGetValue("with_who", out var w) ? w : "",
                };
                result.Add(entry);
            }
            return result;
        }

        protected static void AppendSchedulesYaml(StringBuilder sb, List<ScheduleEntry> schedules)
        {
            if (schedules == null || schedules.Count == 0) return;
            sb.AppendLine("schedules:");
            foreach (var s in schedules)
            {
                sb.AppendLine($"  - name: \"{Esc(s.Name)}\"");
                sb.AppendLine($"    start: \"{s.Start}\"");
                sb.AppendLine($"    end: \"{s.End}\"");
                if (!string.IsNullOrEmpty(s.Color))    sb.AppendLine($"    color: \"{Esc(s.Color)}\"");
                if (!string.IsNullOrEmpty(s.Location)) sb.AppendLine($"    location: \"{Esc(s.Location)}\"");
                if (!string.IsNullOrEmpty(s.WithWho))  sb.AppendLine($"    with_who: \"{Esc(s.WithWho)}\"");
            }
        }

        // ========== YAML 字符串转义 ==========

        protected static string Esc(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            if (s.Contains("\\") || s.Contains("\"") || s.Contains("\n"))
                return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
            return s;
        }

        // ========== Front Matter 拆分 ==========

        public static (string yaml, string body) SplitFrontMatter(string raw)
        {
            if (string.IsNullOrEmpty(raw)) return ("", "");
            raw = raw.Replace("\r\n", "\n").Replace("\r", "\n");
            if (!raw.StartsWith("---\n")) return ("", raw);
            int endIdx = raw.IndexOf("\n---\n", 4);
            if (endIdx < 0) return (raw.Substring(4), "");
            string yaml = raw.Substring(4, endIdx - 4);
            string body = raw.Substring(endIdx + 5).TrimStart('\n');
            return (yaml, body);
        }

        private static string ExtractTypeFromYaml(string yaml)
        {
            foreach (var line in yaml.Split('\n'))
            {
                string t = line.TrimEnd('\r').Trim();
                if (t.StartsWith("type:"))
                    return t.Substring(5).Trim().Trim('"');
            }
            return "Note";
        }
    }

    // ================================================================
    //  NoteDocument
    // ================================================================

    public class NoteDocument : GameDocument
    {
        public DateTime Created = DateTime.Today;
        public DateTime Modified = DateTime.Today;
        public List<NoteTask> Tasks = new List<NoteTask>();

        public override string DocumentType => "Note";

        public override void ParseYaml(Dictionary<string, object> dict)
        {
            GUID     = Y(dict, "guid", GUID);
            Topic    = Y(dict, "topic", Topic);
            Created  = YDate(dict, "created", DateTime.Today);
            Modified = YDate(dict, "modified", DateTime.Today);
            Colors   = ParseColors(dict);
            Tasks    = ParseTasks(dict);
            DDLs     = ParseDDLs(dict);
        }

        protected override string BuildYaml()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"guid: \"{GUID}\"");
            sb.AppendLine($"topic: \"{Esc(Topic ?? "")}\"");
            sb.AppendLine($"type: Note");
            sb.AppendLine($"created: \"{Created:o}\"");
            sb.AppendLine($"modified: \"{Modified:o}\"");
            AppendColorsYaml(sb, Colors);
            AppendDDLYaml(sb, DDLs);
            AppendTasksYaml(sb, Tasks);
            return sb.ToString();
        }

        public override string Save(string oldFilePath)
        {
            string newPath = MarkdownNoteConverter.MakeNotePath(Created, Topic);
            if (!string.IsNullOrEmpty(oldFilePath) &&
                !string.Equals(oldFilePath, newPath, StringComparison.OrdinalIgnoreCase) &&
                File.Exists(oldFilePath))
            {
                DataFileHelper.SafeDelete(oldFilePath);
            }
            WriteFile(newPath, BuildYaml(), BuildBody(Topic));
            try
            {
                string logPath = "data\\logs\\save_debug.log";
                System.IO.File.AppendAllText(logPath,
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [NoteDocument.Save] GUID={GUID}, oldPath={System.IO.Path.GetFileName(oldFilePath ?? "null")}, newPath={System.IO.Path.GetFileName(newPath)}, FileExists={File.Exists(newPath)}{Environment.NewLine}",
                    Encoding.UTF8);
            }
            catch { }
            return newPath;
        }
    }

    // ================================================================
    //  LiteratureDocument
    // ================================================================

    public class LiteratureDocument : GameDocument
    {
        // 核心字段
        public DateTime Created = DateTime.Today;
        public DateTime Modified = DateTime.Today;

        // 别名（兼容现有代码通过 Title / DateAdded 访问）
        public string   Title          { get => Topic;    set => Topic = value; }
        public DateTime DateAdded      { get => Created;  set => Created = value; }
        public DateTime DateModified   { get => Modified; set => Modified = value; }

        // 文献元数据（非 BibTeX，存于 YAML）
        public string Author, Journal, Year, Volume, Pages, Doi;
        public string Publisher, Booktitle, School;
        public int PublishYear;
        public bool Star;
        public string JournalOrConferenceName;

        // 关系
        public List<RLiteratureAuthor> Authors = new List<RLiteratureAuthor>();
        public List<RLiteratureTag>   Tags   = new List<RLiteratureTag>();

        public override string DocumentType => "Literature";

        public override void ParseYaml(Dictionary<string, object> dict)
        {
            GUID     = Y(dict, "guid", GUID);
            Topic    = Y(dict, "topic", null) ?? Y(dict, "title", Topic);
            Created  = YDate(dict, "created", DateTime.Today);
            Modified = YDate(dict, "modified", DateTime.Today);

            Author    = Y(dict, "author");
            Journal   = Y(dict, "journal");
            Year      = Y(dict, "year");
            Volume    = Y(dict, "volume");
            Pages     = Y(dict, "pages");
            Doi       = Y(dict, "doi");
            Publisher = Y(dict, "publisher");
            Booktitle = Y(dict, "booktitle");
            School    = Y(dict, "school");
            PublishYear = YInt(dict, "publish_year");
            Star      = YBool(dict, "star");
            JournalOrConferenceName = Y(dict, "journal_or_conference");
            if (string.IsNullOrEmpty(JournalOrConferenceName))
                JournalOrConferenceName = Journal ?? Booktitle ?? "";

            Colors  = ParseColors(dict);
            Authors = ParseAuthors(dict);
            Tags    = ParseTags(dict);
        }

        protected override string BuildYaml()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"guid: \"{GUID}\"");
            sb.AppendLine($"topic: \"{Esc(Topic ?? "")}\"");
            sb.AppendLine($"type: Literature");
            sb.AppendLine($"created: \"{Created:o}\"");
            sb.AppendLine($"modified: \"{Modified:o}\"");
            if (!string.IsNullOrEmpty(Author))    sb.AppendLine($"author: \"{Esc(Author)}\"");
            if (!string.IsNullOrEmpty(Journal))   sb.AppendLine($"journal: \"{Esc(Journal)}\"");
            if (!string.IsNullOrEmpty(Year))      sb.AppendLine($"year: \"{Esc(Year)}\"");
            if (!string.IsNullOrEmpty(Volume))    sb.AppendLine($"volume: \"{Esc(Volume)}\"");
            if (!string.IsNullOrEmpty(Pages))     sb.AppendLine($"pages: \"{Esc(Pages)}\"");
            if (!string.IsNullOrEmpty(Doi))       sb.AppendLine($"doi: \"{Esc(Doi)}\"");
            if (PublishYear > 0)                  sb.AppendLine($"publish_year: {PublishYear}");
            if (Star)                             sb.AppendLine("star: true");

            AppendColorsYaml(sb, Colors);

            if (Authors != null && Authors.Count > 0)
            {
                sb.AppendLine("authors:");
                foreach (var a in Authors)
                {
                    sb.AppendLine($"  - author: \"{Esc(a.Author ?? "")}\"");
                    sb.AppendLine($"    ordering: {a.Ordering}");
                }
            }
            if (Tags != null && Tags.Count > 0)
            {
                sb.AppendLine("tags:");
                foreach (var t in Tags)
                    sb.AppendLine($"  - tag: \"{Esc(t.Tag ?? "")}\"");
            }
            return sb.ToString();
        }

        public override string Save(string oldFilePath)
        {
            string newPath = MarkdownNoteConverter.MakeLiteraturePath(Topic);
            if (!string.IsNullOrEmpty(oldFilePath) &&
                !string.Equals(oldFilePath, newPath, StringComparison.OrdinalIgnoreCase) &&
                File.Exists(oldFilePath))
            {
                DataFileHelper.SafeDelete(oldFilePath);
            }
            WriteFile(newPath, BuildYaml(), BuildBody(Topic));
            return newPath;
        }

        private static List<RLiteratureAuthor> ParseAuthors(Dictionary<string, object> d)
        {
            var result = new List<RLiteratureAuthor>();
            foreach (var item in YList(d, "authors"))
            {
                result.Add(new RLiteratureAuthor
                {
                    Author   = item.TryGetValue("author", out var a) ? a : "",
                    Ordering = item.TryGetValue("ordering", out var o) && int.TryParse(o, out int n) ? n : result.Count,
                });
            }
            return result;
        }

        private static List<RLiteratureTag> ParseTags(Dictionary<string, object> d)
        {
            var result = new List<RLiteratureTag>();
            foreach (var item in YList(d, "tags"))
                result.Add(new RLiteratureTag { Tag = item.TryGetValue("tag", out var t) ? t : "" });
            return result;
        }
    }

    // ================================================================
    //  DiaryDocument
    // ================================================================

    public class DiaryDocument : GameDocument
    {
        public override string Topic { get => "Diary"; set { } }
        public DateTime Date;
        public List<NoteTask> Tasks = new List<NoteTask>();
        public List<ScheduleEntry> Schedules = new List<ScheduleEntry>();

        public override string DocumentType => "Diary";

        public override void ParseYaml(Dictionary<string, object> dict)
        {
            GUID   = Y(dict, "guid", GUID);
            Date   = YDate(dict, "date", DateTime.Today);
            Colors = ParseColors(dict);
            Tasks  = ParseTasks(dict);
            DDLs   = ParseDDLs(dict);
            Schedules = ParseSchedules(dict);
        }

        protected override string BuildYaml()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"guid: \"{GUID}\"");
            sb.AppendLine($"topic: \"Diary\"");
            sb.AppendLine($"date: \"{Date:yyyy-MM-dd}\"");
            sb.AppendLine($"type: Diary");
            AppendColorsYaml(sb, Colors);
            AppendDDLYaml(sb, DDLs);
            AppendTasksYaml(sb, Tasks);
            return sb.ToString();
        }

        public override string Save(string oldFilePath)
        {
            string newPath = MarkdownNoteConverter.MakeDiaryPath(Date);
            if (!string.IsNullOrEmpty(oldFilePath) &&
                !string.Equals(oldFilePath, newPath, StringComparison.OrdinalIgnoreCase) &&
                File.Exists(oldFilePath))
            {
                DataFileHelper.SafeDelete(oldFilePath);
            }
            WriteFile(newPath, BuildYaml(), BuildBody(Topic));
            return newPath;
        }
    }

    // ================================================================
    //  LiteratureReviewDocument
    // ================================================================

    public class LiteratureReviewDocument : GameDocument
    {
        public DateTime Created = DateTime.Today;
        public DateTime Modified = DateTime.Today;

        public override string DocumentType => "LiteratureReview";

        public override void ParseYaml(Dictionary<string, object> dict)
        {
            GUID     = Y(dict, "guid", GUID);
            Topic    = Y(dict, "topic", Topic);
            Created  = YDate(dict, "created", DateTime.Today);
            Modified = YDate(dict, "modified", DateTime.Today);
            Colors   = ParseColors(dict);
        }

        protected override string BuildYaml()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"guid: \"{GUID}\"");
            sb.AppendLine($"topic: \"{Esc(Topic ?? "")}\"");
            sb.AppendLine($"type: LiteratureReview");
            sb.AppendLine($"created: \"{Created:o}\"");
            sb.AppendLine($"modified: \"{Modified:o}\"");
            AppendColorsYaml(sb, Colors);
            return sb.ToString();
        }

        public override string Save(string oldFilePath)
        {
            string newPath = MarkdownNoteConverter.MakeLiteratureReviewPath(Created, Topic);
            if (!string.IsNullOrEmpty(oldFilePath) &&
                !string.Equals(oldFilePath, newPath, StringComparison.OrdinalIgnoreCase) &&
                File.Exists(oldFilePath))
            {
                DataFileHelper.SafeDelete(oldFilePath);
            }
            WriteFile(newPath, BuildYaml(), BuildBody(Topic));
            return newPath;
        }
    }

    // ================================================================
    //  辅助类
    // ================================================================

    public class NoteTask
    {
        public string Text;        // $TASK$>xxx 或 $SCHL$>xxx 的完整文本
        public string MetaType;    // "Task", "Schedule", "Deadline", "Progress"
    }

    public class DDLEntry
    {
        public string Text;        // $DDLI$> YYYY.MM.DD desc
        public string Parent;      // 父节点标题
    }

    public class ScheduleEntry
    {
        public string Name;       // e.g. "Meeting"
        public string Start;      // e.g. "09:00"
        public string End;        // e.g. "10:00"
        public string Color;      // e.g. "Blue"
        public string Location;   // e.g. "Office"
        public string WithWho;    // e.g. "John"
    }
}
