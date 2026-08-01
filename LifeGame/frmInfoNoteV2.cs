﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace LifeGame
{
    public enum ESysNoteType
    {
        None,
        Menu,
        Calendar,
        Archive,
        Diary
    }

    public partial class frmInfoNoteV2 : frmNoteBase
    {
        #region 字段
        public string GUID = "";

        internal NoteDocument note = new NoteDocument();
        private LiteratureDocument literature = new LiteratureDocument();
        private DiaryDocument diary = new DiaryDocument();
        private LiteratureReviewDocument literatureReview = new LiteratureReviewDocument();

        internal ENoteType noteType = ENoteType.Note;
        internal ESysNoteType sysNoteType = ESysNoteType.None;
        internal bool isSysNote = false;
        internal bool isSysDiary = false; // SysNote: Diary 作为 DiaryDocument 临时容器
        internal bool isSearchResult = false; // 搜索结果的临时只读窗口
        internal List<OutlineLine> lstNoteLog = new List<OutlineLine>();
        internal List<RNoteColor> lstNoteColor = new List<RNoteColor>();
        private List<OutlineLine> _lines = new List<OutlineLine>(); // cached GameDocument.Lines
        private List<RLiteratureAuthor> lstLiteratureAuthor = new List<RLiteratureAuthor>();
        private List<RLiteratureTag> lstLiteratureTag = new List<RLiteratureTag>();
        private List<OutlineLine> lstTDLNoteLog = new List<OutlineLine>();
        private List<RNoteColor> lstTDLNoteColor = new List<RNoteColor>();
        private List<string> lstReferenceLinks = new List<string>();

        // === Diary Schedule 字段 ===
        private Panel scheduleContainer;
        private Panel scheduleToolbar;
        private DateTimePicker dtpDiaryDate;
        private PictureBox scheduleCanvas;

        // === Calendar / TDL 月视图字段 ===
        private Panel calendarPanel;
        private Panel calendarToolbar;
        private Label lblCalendarMonth;
        private Button btnCalPrev, btnCalNext, btnCalToday;
        private PictureBox[,] calDayCells; // [row, col], 6 rows × 7 cols
        private DateTime calSelectedMonth; // 当月第一天

        // SysNote fixed names
        private const string SysNoteTDLName = "SysNote: Calendar"; // Calendar/TDL merged
        private const string SysNoteDiaryName = "SysNote: Diary"; // not used as a NoteDocument
        private const string SysNoteNoteName = "SysNote: Note Archive";
        private const string SysNoteArchiveName = "SysNote: Task History";

        /// <summary>需要持久化的 SysNote 名集合（存 data/sysnotes/）</summary>
        private static readonly HashSet<string> PersistedSysNotes = new HashSet<string>
        {
            "SysNote: Calendar",
            "SysNote: Diary",
        };

        private static string BuildSysNoteYaml(string guid, string topic, DateTime created, DateTime modified,
            List<RNoteColor> colors, List<DDLEntry> ddls, List<NoteTask> tasks)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"guid: \"{guid}\"");
            sb.AppendLine($"topic: \"{Esc(topic)}\"");
            sb.AppendLine("type: Note");
            sb.AppendLine($"created: \"{created:o}\"");
            sb.AppendLine($"modified: \"{modified:o}\"");
            if (colors != null && colors.Count > 0)
            {
                sb.AppendLine("colors:");
                foreach (var c in colors)
                     sb.AppendLine($"  - keyword: \"{Esc(c.Keyword)}\"\n    color: \"{Esc(c.Color)}\"");
            }
            else { sb.AppendLine("colors: []"); }
            if (ddls != null && ddls.Count > 0)
            {
                sb.AppendLine("ddls:");
                foreach (var d in ddls)
                {
                    if (!string.IsNullOrEmpty(d.Parent))
                        sb.AppendLine($"  - text: \"{Esc(d.Text)}\"\n    parent: \"{Esc(d.Parent)}\"");
                    else
                        sb.AppendLine($"  - text: \"{Esc(d.Text)}\"");
                }
            }
            if (tasks != null && tasks.Count > 0)
            {
                sb.AppendLine("tasks:");
                foreach (var t in tasks)
                    sb.AppendLine($"  - text: \"{Esc(t.Text)}\"\n    meta: \"{Esc(t.MetaType)}\"");
            }
            return sb.ToString();
        }

        private static string Esc(string s) => (s ?? "").Replace("\\", "\\\\").Replace("\"", "\\\"");
        private string MetaNodeGUID => "META__" + GUID;

        public delegate void DrawLogHandler();
        public delegate void RefreshTabHandler();
        public event RefreshTabHandler RefreshTab;
        #endregion

        #region SysNote 类型检测与调度
        private void DetectSysNoteType()
        {
            if (note.Topic == SysNoteTDLName)        { sysNoteType = ESysNoteType.Calendar; isSysNote = true; }
            else if (note.Topic == SysNoteArchiveName)  { sysNoteType = ESysNoteType.Archive; isSysNote = true; }
            else if (note.Topic == SysNoteDiaryName)    { sysNoteType = ESysNoteType.Diary; isSysNote = true; }
            else if (note.Topic == SysNoteNoteName) { sysNoteType = ESysNoteType.None; isSysNote = true; }
            else { sysNoteType = ESysNoteType.None; isSysNote = false; }
        }

        #endregion

        private void OpenDiaryFromMenu(DateTime date) => OpenSysDiary(date);

        /// <summary>通过 SysNote: Diary 窗口打开指定日期的 DiaryDocument</summary>
        private void OpenSysDiary(DateTime date)
        {
            var sysDiaryNote = G.glb.lstNote.Find(o => o.Topic == SysNoteDiaryName);
            if (sysDiaryNote == null) return;

            if (M.NoteExists(sysDiaryNote.GUID))
            {
                var f = (frmInfoNoteV2)M.FindNoteForm(sysDiaryNote.GUID);
                f.SwitchDiaryDate(date);
                f.BringToFront();
            }
            else
            {
                var f = new frmInfoNoteV2(sysDiaryNote);
                f.SwitchDiaryDate(date);
                f.Show();
                M.notesOpened.Add(f);
            }
        }

        #region Task / Schedule 解析辅助

        /// <summary>从 $TASK$>Name@YYYY.MM.DD~YYYY.MM.DD 中提取任务名</summary>
        private static string ParseTaskName(string taskText)
        {
            if (string.IsNullOrEmpty(taskText)) return "";
            string t = taskText.StartsWith("$TASK$>") ? taskText.Substring(7) : taskText;
            int at = t.LastIndexOf('@');
            if (at < 0) return t;
            string before = t.Substring(0, at);
            // 可能是 "Name@start~end" 或 "Name@start~end@extra"，找到最后一个 @ 左边的内容
            // 再找到倒数第二个 @（如果有），取中间部分
            return before;
        }

        /// <summary>从 $TASK$>Name@YYYY.MM.DD 或 $TASK$>Name@YYYY.MM.DD-YYYY.MM.DD 中提取起始日期</summary>
        private static DateTime ParseTaskStart(string taskText)
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

        /// <summary>从 $TASK$>Name@YYYY.MM.DD 或 $TASK$>Name@YYYY.MM.DD-YYYY.MM.DD 中提取结束日期</summary>
        private static DateTime ParseTaskEnd(string taskText)
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

        /// <summary>从 $SCHL$>Name@HH:mm-HH:mm@Color@Location[@yyyy.mm.dd] 提取日期。优先末尾日期，否则 parts[1]</summary>
        private static DateTime ParseSchlDate(string schlText)
        {
            if (string.IsNullOrEmpty(schlText)) return DateTime.MinValue;
            string t = schlText.StartsWith("$SCHL$>") ? schlText.Substring(7) : schlText;
            var parts = t.Split('@');
            // 检查末尾是否为日期（yyyy.mm.dd），用于 TDL/Archive 中独立的 $SCHL$>
            if (parts.Length >= 2)
            {
                var lastDate = TryParseDate(parts[parts.Length - 1]);
                if (lastDate != DateTime.MinValue) return lastDate;
            }
            // 否则检查 parts[1]（可能是 HH:mm 时间，也可能是日期）
            if (parts.Length >= 2)
            {
                var dt = TryParseDate(parts[1]);
                if (dt != DateTime.MinValue) return dt;
            }
            return DateTime.MinValue;
        }

        /// <summary>判断指定节点是否是 $TASK$> 的子节点（即父节点是 $TASK$>）</summary>
        private bool IsChildOfTaskNode(OutlineLine line)
        {
            if (line == null || string.IsNullOrEmpty(line.ParentGUID)) return false;
            var parent = richTreeView.GetAllLines().Find(l => l.GUID == line.ParentGUID);
            return parent != null && parent.MetaType == NodeMetaType.Task;
        }

        private static DateTime TryParseDate(string s)
        {
            if (string.IsNullOrEmpty(s)) return DateTime.MinValue;
            s = s.Trim();
            // 将 . 替换为 /，因为 . 在自定义日期格式中是区域性的日期分隔符，
            // 在 zh-CN 会被解释为 / 导致 "2026.06.21" 匹配失败
            s = s.Replace('.', '/');
            string[] fmts = { "yyyy/MM/dd", "yyyy-MM-dd", "MM/dd/yyyy" };
            if (DateTime.TryParseExact(s, fmts, System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime dt))
                return dt;
            if (DateTime.TryParse(s, out dt)) return dt;
            return DateTime.MinValue;
        }

        /// <summary>从 $DDLI$>YYYY.MM.DD@显示内容 解析日期（必须有@）</summary>
        private static DateTime ParseDdlDate(string text)
        {
            if (string.IsNullOrEmpty(text)) return DateTime.MinValue;
            string t = StripDdlPrefix(text);
            int atIdx = t.IndexOf('@');
            if (atIdx < 0) return DateTime.MinValue;
            var match = System.Text.RegularExpressions.Regex.Match(t.Substring(0, atIdx), @"^(\d{4}\.\d{1,2}\.\d{1,2})$");
            if (match.Success) return TryParseDate(match.Groups[1].Value);
            return DateTime.MinValue;
        }

        /// <summary>从 $DDLI$>YYYY.MM.DD@显示内容 提取@后的显示名称（没有@则返回空）</summary>
        private static string ParseDdlName(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            string t = StripDdlPrefix(text);
            int atIdx = t.IndexOf('@');
            if (atIdx < 0) return "";
            return t.Substring(atIdx + 1);
        }

        private static string StripDdlPrefix(string text)
        {
            if (text.StartsWith("$DDLI$>", StringComparison.OrdinalIgnoreCase))
                return text.Substring(7);
            if (text.StartsWith("date:", StringComparison.OrdinalIgnoreCase))
                return text.Substring(5);
            return text;
        }

        #endregion

        #region SysNote: Calendar 面板
        private void InitCalendarPanel()
        {
            calSelectedMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            splitMain.Panel2.Controls.Clear();
            splitMain.Panel2Collapsed = false;
            splitMain.SplitterDistance = this.ClientSize.Width * 1 / 5; // 左右 1:4

            // 工具栏：◀ 月份 ▶ Today
            calendarToolbar = new Panel
            {
                Dock = DockStyle.Top,
                BackColor = Theme.Current.ToolbarBackground,
                Height = 36,
                Padding = new Padding(6, 4, 6, 4),
            };

            int btnW = 28, btnH = 26;
            btnCalPrev = new Button { Text = "\u25C0", FlatStyle = FlatStyle.Flat, Size = new Size(btnW, btnH), Left = 4, Top = 4 };
            StyleButton(btnCalPrev, Theme.Current.ButtonSecondaryBg, Theme.Current.TextSecondary);
            btnCalPrev.Click += (s, e) => { calSelectedMonth = calSelectedMonth.AddMonths(-1); DrawMonthView(); };
            calendarToolbar.Controls.Add(btnCalPrev);

            lblCalendarMonth = new Label
            {
                Text = calSelectedMonth.ToString("yyyy年M月"),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Left = btnCalPrev.Right, Top = 2, Width = 140, Height = 28,
                ForeColor = Theme.Current.TextPrimary,
            };
            calendarToolbar.Controls.Add(lblCalendarMonth);

            btnCalNext = new Button { Text = "\u25B6", FlatStyle = FlatStyle.Flat, Size = new Size(btnW, btnH), Left = lblCalendarMonth.Right, Top = 4 };
            StyleButton(btnCalNext, Theme.Current.ButtonSecondaryBg, Theme.Current.TextSecondary);
            btnCalNext.Click += (s, e) => { calSelectedMonth = calSelectedMonth.AddMonths(1); DrawMonthView(); };
            calendarToolbar.Controls.Add(btnCalNext);

            btnCalToday = new Button { Text = "Today", Font = new Font("Segoe UI", 8F),
                Left = btnCalNext.Right + 8, Top = 4, Width = 52, Height = btnH };
            StyleButton(btnCalToday, Theme.Current.ButtonSecondaryBg, Theme.Current.Accent);
            btnCalToday.FlatAppearance.BorderSize = 0;
            btnCalToday.Click += (s, e) => { calSelectedMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); DrawMonthView(); };
            calendarToolbar.Controls.Add(btnCalToday);

            // 月历网格：7列 × 7行（1表头 + 6行日期）
            calendarPanel = new Panel { Dock = DockStyle.Fill, BackColor = Theme.Current.ScheduleBg };
            var calTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill, ColumnCount = 7, RowCount = 7,
                BackColor = Theme.Current.ScheduleBg,
                Margin = new Padding(2),
            };
            for (int i = 0; i < 7; i++)
                calTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857F));
            calTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 24)); // header
            for (int i = 1; i < 7; i++)
                calTable.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6667F));

            string[] dayNames = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            for (int i = 0; i < 7; i++)
            {
                var lbl = new Label { Text = dayNames[i], TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 8F, FontStyle.Bold), Dock = DockStyle.Fill,
                    ForeColor = Theme.Current.TextSecondary };
                calTable.Controls.Add(lbl, i, 0);
            }

            calDayCells = new PictureBox[6, 7];
            for (int row = 0; row < 6; row++)
                for (int col = 0; col < 7; col++)
                {
                    var pb = new PictureBox
                    {
                        Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(1),
                        Cursor = Cursors.Hand, SizeMode = PictureBoxSizeMode.Normal,
                        Name = $"calCell_{row}_{col}",
                    };
                    pb.DoubleClick += CalCell_DoubleClick;
                    pb.Paint += CalCell_Paint;
                    calDayCells[row, col] = pb;
                    calTable.Controls.Add(pb, col, row + 1);
                }

            calendarPanel.Controls.Add(calTable);
            splitMain.Panel2.Controls.Add(calendarPanel);
            splitMain.Panel2.Controls.Add(calendarToolbar);

            // 加载左侧 TDL 索引树（扫描所有 Note 中的 $TASK$>，按 Note标题 → 父节点 → $TASK$> 结构）
            richTreeView.IsReadOnly = true;
            richTreeView.IconDisplayMode = true;
            BuildTDLIndexTree();
            BuildTDLContextMenu();
        }

        /// <summary>构建 TDL 索引树：Note标题 → 父节点文本 → $TASK$> 及其子树</summary>
        private void BuildTDLIndexTree() => TreeBuilderService.BuildTDLIndexTree(richTreeView.OutlinePanel);

        /// <summary>TDL 只读上下文菜单：仅"转到"到来源 Note</summary>
        private void BuildTDLContextMenu()
        {
            // context menu handled by RichTreeView // 使用 OnLineRightClicked 处理
        }

        /// <summary>打开 Note 或激活已打开的窗口</summary>
        private void OpenOrActivateNote(NoteDocument note)
        {
            if (M.NoteExists(note.GUID))
                M.FindNoteForm(note.GUID).BringToFront();
            else { var f = new frmInfoNoteV2(note); f.Show(); M.notesOpened.Add(f); }
        }

        private void CalCell_DoubleClick(object sender, EventArgs e)
        {
            var pb = sender as PictureBox;
            if (pb?.Tag is CalCellData cell && cell.Date != DateTime.MinValue)
                OpenDiaryFromMenu(cell.Date);
        }

        /// <summary>月历单元格绘制：日期数字 + bullet 列表</summary>
        private void CalCell_Paint(object sender, PaintEventArgs e)
        {
            var pb = sender as PictureBox;
            if (!(pb?.Tag is CalCellData cell)) return;
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int w = pb.Width, hh = pb.Height;
            DateTime day = cell.Date;

            // 背景
            bool isToday = day.Date == DateTime.Today;
            Color bgColor = isToday ? Color.FromArgb(230, 240, 255)
                : cell.IsOtherMonth ? Color.FromArgb(248, 248, 246) : Color.White;
            Color textColor = cell.IsOtherMonth ? Color.FromArgb(180, 180, 180)
                : isToday ? Theme.Current.Accent : Theme.Current.TextPrimary;

            using (var bgBrush = new SolidBrush(bgColor))
                g.FillRectangle(bgBrush, e.ClipRectangle);
            if (isToday)
                using (var pen = new Pen(Theme.Current.Accent, 2))
                    g.DrawRectangle(pen, 1, 1, w - 3, hh - 3);

            // 日期数字
            string dayStr = day.Day.ToString();
            using (var f = new Font("Segoe UI", 9F, isToday ? FontStyle.Bold : FontStyle.Regular))
                g.DrawString(dayStr, f, new SolidBrush(textColor), 4, 2);

            // bullet 列表
            if (cell.Bullets.Count == 0) return;
            float bulletY = 20;
            float maxH = hh - 4;
            float lineH = Math.Min(14, (maxH - bulletY) / Math.Max(cell.Bullets.Count, 1));
            if (lineH < 10) lineH = 10; // 最小行高

            using (var bulletFont = new Font("Segoe UI", 9F))
            {
                int maxBullets = Math.Min(cell.Bullets.Count, (int)((maxH - bulletY) / lineH));
                for (int i = 0; i < maxBullets; i++)
                {
                    var b = cell.Bullets[i];
                    string prefix = b.IsDdl ? "! " : b.IsTask ? "● " : "◆ ";
                    string display = prefix + b.Text;
                    if (g.MeasureString(display, bulletFont).Width > w - 8)
                        display = prefix + Truncate(b.Text, g, bulletFont, w - 20);
                    Color drawColor = cell.IsOtherMonth ? Color.FromArgb(180, 180, 180)
                        : b.IsDdl ? Color.Red : b.Color;
                    using (var brush = new SolidBrush(drawColor))
                        g.DrawString(display, bulletFont, brush, 4, bulletY);
                    bulletY += lineH;
                }
                if (cell.Bullets.Count > maxBullets)
                    g.DrawString($"+{cell.Bullets.Count - maxBullets} more", bulletFont,
                        Brushes.Gray, 4, bulletY);
            }
        }

        private static string Truncate(string s, int maxLen)
        {
            if (string.IsNullOrEmpty(s)) return "";
            if (s.Length <= maxLen) return s;
            return s.Substring(0, maxLen - 1) + "…";
        }

        private static string Truncate(string s, Graphics g, Font f, int maxWidth)
        {
            if (string.IsNullOrEmpty(s)) return "";
            for (int len = s.Length; len > 3; len--)
            {
                string t = s.Substring(0, len - 1) + "…";
                if (g.MeasureString(t, f).Width <= maxWidth) return t;
            }
            return s.Substring(0, Math.Min(3, s.Length)) + "…";
        }

        /// <summary>绘制整个月历</summary>
        private void DrawMonthView()
        {
            try
            {
                if (calendarPanel == null || calDayCells == null)
                {
                    System.Diagnostics.Debug.WriteLine("[Calendar] calendarPanel or calDayCells null, skip DrawMonthView");
                    return;
                }

                lblCalendarMonth.Text = calSelectedMonth.ToString("yyyy年M月");

                int firstDayOfWeek = ((int)calSelectedMonth.DayOfWeek + 6) % 7;
                int daysInMonth = DateTime.DaysInMonth(calSelectedMonth.Year, calSelectedMonth.Month);

                var taskEntries = CollectTasksFromTDL();
                System.Diagnostics.Debug.WriteLine($"[Calendar] DrawMonthView: {taskEntries.Count} entries collected");

                DateTime cellDate = calSelectedMonth.AddDays(-firstDayOfWeek);
                for (int row = 0; row < 6; row++)
                    for (int col = 0; col < 7; col++)
                    {
                        var pb = calDayCells[row, col];
                        if (pb == null) continue;

                        var bullets = taskEntries
                            .Where(te => cellDate >= te.Start && cellDate <= te.End
                                && (te.WeeklyDays == null || te.WeeklyDays.Length == 0
                                    || te.WeeklyDays.Contains(cellDate.ToString("ddd"), StringComparer.OrdinalIgnoreCase)))
                            .OrderBy(te => te.IsSchedule ? 1 : 0)
                            .ThenBy(te => te.Name)
                            .Select(te => new CalBullet { Text = Truncate(te.Name, 12), Color = te.Color, IsTask = !te.IsSchedule && !te.IsDdl, IsArchived = te.IsArchived, IsDdl = te.IsDdl })
                            .Take(8)
                            .ToList();

                        var cellData = new CalCellData { Date = cellDate, Bullets = bullets, IsOtherMonth = cellDate.Month != calSelectedMonth.Month };
                        pb.Tag = cellData;
                        pb.BackColor = cellDate.Month == calSelectedMonth.Month
                            ? (cellDate.Date == DateTime.Today ? Color.FromArgb(230, 240, 255) : Color.White)
                            : Color.FromArgb(248, 248, 246);
                        pb.Invalidate();

                        cellDate = cellDate.AddDays(1);
                    }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("[Calendar] DrawMonthView ERROR: " + ex.ToString());
            }
        }

        /// <summary>月历单元格数据结构（存于 PictureBox.Tag）</summary>
        private class CalCellData
        {
            public DateTime Date;
            public List<CalBullet> Bullets = new List<CalBullet>();
            public bool IsOtherMonth;
        }

        private class CalBullet
        {
            public string Text;
            public Color Color;
            public bool IsTask; // true = $TASK$> (●), false = $SCHL$> (◆)
            public bool IsArchived; // true = 已归档（灰色+划线）
            public bool IsDdl; // true = $DDLI$> 节点（红色 + !）
        }

        /// <summary>任务条目（用于月历聚合）</summary>
        private class TaskEntry
        {
            public string Name;
            public DateTime Start;
            public DateTime End;
            public bool IsSchedule; // true = 独立 $SCHL$>, false = $TASK$>
            public bool IsDdl; // true = $DDLI$> / Date: 节点
            public Color Color;
            public bool IsArchived;
            public string[] WeeklyDays; // 如 ["Mon","Wed"]，空=每天
        }

        /// <summary>扫描所有非 SysNote 的 Note，收集其中的 $TASK$> 和 $SCHL$> 节点</summary>
        private List<TreeBuilderService.ScannedTaskNode> ScanAllNotesForTasks()
            => TreeBuilderService.ScanAllNotesForTasks();

        /// <summary>获取 $TASK$> 或 $SCHL$> 的结束/发生日期（用于 Archive 按日期分组）</summary>
        private static DateTime GetTaskEndDate(OutlineLine line)
        {
            if (line.MetaType == NodeMetaType.Task)
                return ParseTaskEnd(line.Text);
            if (line.MetaType == NodeMetaType.Schedule)
                return ParseSchlDate(line.Text);
            return DateTime.MinValue;
        }

        /// <summary>从所有 Note 收集 $TASK$> 和独立 $SCHL$> 条目（用于月历）</summary>
        private List<TaskEntry> CollectTasksFromTDL()
        {
            var result = new List<TaskEntry>();
            var scanned = ScanAllNotesForTasks();

            foreach (var sn in scanned)
            {
                if (sn.Line.MetaType == NodeMetaType.Task)
                {
                    var start = ParseTaskStart(sn.Line.Text);
                    var end = ParseTaskEnd(sn.Line.Text);
                    if (start == DateTime.MinValue || end == DateTime.MinValue) continue;
                    result.Add(new TaskEntry
                    {
                        Name = ParseTaskName(sn.Line.Text), Start = start, End = end,
                        IsSchedule = false, Color = GetLineColor(sn.Line),
                        IsArchived = sn.IsExpired,
                        WeeklyDays = ParseWeeklyDays(sn.Line.Text),
                    });
                }
                else if (sn.Line.MetaType == NodeMetaType.Schedule)
                {
                    var date = ParseSchlDate(sn.Line.Text);
                    if (date == DateTime.MinValue) continue;
                    result.Add(new TaskEntry
                    {
                        Name = sn.Line.MetaValue ?? sn.Line.Text.Substring(7).Split('@')[0],
                        Start = date, End = date,
                        IsSchedule = true, Color = GetLineColor(sn.Line),
                        IsArchived = sn.IsExpired,
                    });
                }
                else if (sn.Line.MetaType == NodeMetaType.Deadline)
                {
                    var ddlDate = ParseDdlDate(sn.Line.Text);
                    if (ddlDate == DateTime.MinValue) continue;
                    result.Add(new TaskEntry
                    {
                        Name = ParseDdlName(sn.Line.Text),
                        Start = ddlDate, End = ddlDate,
                        IsDdl = true, Color = Color.Red,
                    });
                }
            }

            return result;
        }

        /// <summary>获取节点的显示颜色（取自标签颜色）</summary>
        private Color GetLineColor(OutlineLine line)
        {
            if (line.LabelKeywords != null && line.LabelKeywords.Count > 0)
            {
                var labelColors = richTreeView.BuildLabelColorMap();
                if (labelColors.TryGetValue(line.LabelKeywords[0], out var c))
                    return c;
            }
            return Color.FromArgb(100, 100, 100); // 默认灰色
        }

        /// <summary>获取 $TASK$> 节点的颜色：自身有 Label 用自身，否则向上查找第一个有 Label 的祖先</summary>
        private Color GetTaskColor(OutlineLine line)
        {
            var allLines = richTreeView.GetAllLines();
            var current = line;
            while (current != null)
            {
                if (current.LabelKeywords != null && current.LabelKeywords.Count > 0)
                    return GetLineColor(current);
                if (string.IsNullOrEmpty(current.ParentGUID)) break;
                current = allLines.Find(l => l.GUID == current.ParentGUID);
            }
            return Color.FromArgb(100, 100, 100); // 默认灰色
        }

        /// <summary>从 $TASK$>...@{Mon, Wed} 中提取每周生效的星期几</summary>
        private static string[] ParseWeeklyDays(string taskText)
        {
            if (string.IsNullOrEmpty(taskText)) return Array.Empty<string>();
            // 匹配末尾的 @{Mon, Wed, Fri} 语法
            var match = System.Text.RegularExpressions.Regex.Match(taskText, @"@\{([^}]+)\}\s*$");
            if (!match.Success) return Array.Empty<string>();
            return match.Groups[1].Value.Split(',').Select(d => d.Trim()).ToArray();
        }

        /// <summary>去除 $TASK$> 文本末尾的 @{Mon, Wed} 后缀</summary>
        private static string StripWeeklySuffix(string taskText)
        {
            if (string.IsNullOrEmpty(taskText)) return taskText;
            var match = System.Text.RegularExpressions.Regex.Match(taskText, @"@\{[^}]+\}\s*$");
            if (!match.Success) return taskText;
            return taskText.Substring(0, match.Index).TrimEnd();
        }

        /// <summary>将 $SCHL$> 按其父 $TASK$> 的范围每周重复生成副本</summary>
        private void RepeatWeekly(OutlineLine schlLine)
        {
            var allLines = richTreeView.GetAllLines();
            var parent = allLines.Find(l => l.GUID == schlLine.ParentGUID);
            if (parent == null || parent.MetaType != NodeMetaType.Task) return;

            var baseDate = ParseSchlDate(schlLine.Text);
            if (baseDate == DateTime.MinValue) return;
            var taskEnd = ParseTaskEnd(parent.Text);
            if (taskEnd == DateTime.MinValue) return;

            // 解析 SCHL 的其余字段（时间、颜色、位置等）
            string t = schlLine.Text.StartsWith("$SCHL$>") ? schlLine.Text.Substring(7) : schlLine.Text;
            var parts = t.Split('@');
            string name = parts.Length > 0 ? parts[0] : "";
            string timeColorLoc = parts.Length > 2
                ? string.Join("@", parts.Skip(2))
                : "";

            int baseOrdering = allLines.Where(l => l.ParentGUID == parent.GUID).Max(l => l.Ordering) + 1;

            DateTime nextDate = baseDate.AddDays(7);
            while (nextDate <= taskEnd)
            {
                string newText = $"$SCHL$>{name}@{nextDate:yyyy.MM.dd}";
                if (!string.IsNullOrEmpty(timeColorLoc))
                    newText += "@" + timeColorLoc;
                var newLine = new OutlineLine
                {
                    GUID = Guid.NewGuid().ToString(),
                    Text = newText,
                    ParentGUID = parent.GUID,
                    Ordering = baseOrdering++,
                    Expanded = false,
                };
                lstNoteLog.Add(newLine);
                nextDate = nextDate.AddDays(7);
            }

            // 先序列化全局数据，再从 lstNoteLog 重建面板
            SerializeNow();
            LoadOutline();
            richTreeView.RootTitle = "To Do List";
            richTreeView.OutlinePanel.LabelColors = richTreeView.BuildLabelColorMap();
            richTreeView.OutlinePanel.LabelForeColors = richTreeView.BuildLabelForeColorMap();
            richTreeView.ApplyLabelColorsToRows();
        }

        /// <summary>将 $TASK$> 及其子树归档到 SysNote: Archive（按完成时刻的月→日两层分组）</summary>
        private void ArchiveTask(OutlineLine taskLine)
        {
            if (taskLine.MetaType != NodeMetaType.Task) return;

            // 确保 Archive Note 存在
            var archiveNote = G.glb.lstNote.Find(o => o.Topic == SysNoteArchiveName);
            if (archiveNote == null)
            {
                archiveNote = new NoteDocument
                {
                    Topic = SysNoteArchiveName,
                    GUID = Guid.NewGuid().ToString(),
                    Created = DateTime.Today,
                };
                G.glb.lstNote.Add(archiveNote);
            }

            var allLines = richTreeView.GetAllLines();

            // 收集 taskLine 及其所有子节点
            var linesToArchive = new List<OutlineLine> { taskLine };
            CollectDescendants(allLines, taskLine.GUID, linesToArchive);

            // 为归档节点重新分配 GUID，避免和 TDL 冲突
            var guidMap = new Dictionary<string, string>();
            foreach (var line in linesToArchive)
            {
                string newGUID = Guid.NewGuid().ToString();
                guidMap[line.GUID] = newGUID;
            }

            // 按完成时刻创建 月→日 分组结构（仅在当前会话内存中）
            DateTime archiveTime = DateTime.Now;
            string monthKey = archiveTime.ToString("yyyy.MM");
            string dayKey = archiveTime.ToString("MM.dd");

            // Find or create month node
            var monthNode = archiveNote.Lines.Find(l => l.Text == monthKey && l.ParentGUID == archiveNote.GUID);
            if (monthNode == null)
            {
                monthNode = new OutlineLine { Text = monthKey, GUID = Guid.NewGuid().ToString(), Level = 1, ParentGUID = archiveNote.GUID, IsMetaNode = true, Expanded = true };
                archiveNote.Lines.Add(monthNode);
            }

            // Find or create day node
            var dayNode = archiveNote.Lines.Find(l => l.Text == dayKey && l.ParentGUID == monthNode.GUID);
            if (dayNode == null)
            {
                dayNode = new OutlineLine { Text = dayKey, GUID = Guid.NewGuid().ToString(), Level = 2, ParentGUID = monthNode.GUID, IsMetaNode = true, Expanded = true };
                archiveNote.Lines.Add(dayNode);
            }

            // Add archived task lines
            foreach (var line in linesToArchive)
            {
                string newGUID = guidMap[line.GUID];
                string fatherGUID = (line.GUID == taskLine.GUID) ? dayNode.GUID
                    : (guidMap.ContainsKey(line.ParentGUID) ? guidMap[line.ParentGUID] : dayNode.GUID);
                var newLine = new OutlineLine { Text = line.Text, GUID = newGUID, ParentGUID = fatherGUID,
                    Level = 3, MetaType = line.MetaType, MetaValue = line.MetaValue, Expanded = line.Expanded,
                    LabelKeywords = line.LabelKeywords, ProgressPercent = line.ProgressPercent };
                newLine.Ordering = archiveNote.Lines.Count(l => l.ParentGUID == fatherGUID);
                archiveNote.Lines.Add(newLine);
            }

            // 从 TDL 的本地列表中删除
            foreach (var kv in guidMap)
            {
                var local = lstNoteLog.Find(l => l.GUID == kv.Key);
                if (local != null) lstNoteLog.Remove(local);
            }

            // 保存全局状态并重建面板
            SerializeNow();
            LoadOutline();
            richTreeView.RootTitle = "To Do List";
            richTreeView.OutlinePanel.LabelColors = richTreeView.BuildLabelColorMap();
            richTreeView.OutlinePanel.LabelForeColors = richTreeView.BuildLabelForeColorMap();
            richTreeView.ApplyLabelColorsToRows();
            DrawMonthView();
        }

        private void CollectDescendants(List<OutlineLine> allLines, string parentGUID, List<OutlineLine> result)
        {
            foreach (var line in allLines.Where(l => l.ParentGUID == parentGUID).OrderBy(l => l.Ordering))
            {
                result.Add(line);
                CollectDescendants(allLines, line.GUID, result);
            }
        }

        #endregion

        #region SysNote: Note (所有普通 Note 索引)
        private void InitNotesIndexPanel()
        {
            splitMain.Panel2Collapsed = true;
            richTreeView.IsReadOnly = true;
            richTreeView.IconDisplayMode = true;
            LoadNotesIndexTree();
            BuildNotesIndexContextMenu();

            // 搜索栏左侧添加创建按钮
            AddCreationButtons(
                (s, e) => CreateNewNoteFromIndex(),
                (s, e) => CreateNewLiterature(),
                (s, e) => CreateNewLiteratureReview());
        }

        #endregion

        /// <summary>刷新 Note 索引树（新建/删除 Note 后调用）</summary>
        private void RefreshNotesIndex()
        {
            LoadNotesIndexTree();
        }

        private void LoadNotesIndexTree() => TreeBuilderService.LoadNotesIndexTree(richTreeView.OutlinePanel);

        private void BuildNotesIndexContextMenu()
        {
            // context menu handled by RichTreeView // 由 OnLineRightClicked 统一处理
        }

        private void DeleteNoteFromIndex(OutlineLine line)
        {
            if (line.MetaType != NodeMetaType.NoteRef || string.IsNullOrEmpty(line.MetaValue))
                return;

            var note = G.glb.lstNote.Find(o => o.Topic == line.MetaValue);
            if (note == null) return;

            if (MessageBox.Show("Delete note \"" + note.Topic + "\"?\nThis action cannot be undone.",
                "Delete Note", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes) return;

            // 关闭已打开的该 Note 窗口
            if (M.NoteExists(note.GUID))
            {
                var f = M.FindNoteForm(note.GUID);
                if (f != null)
                {
                    f.FormClosing -= frmInfoNoteV2_FormClosing;
                    f.Close();
                }
            }

            // 删除 Note 关联数据
            G.glb.lstNote.Remove(note);
            SerializeNow();

            // 刷新索引树
            RefreshNotesIndex();
        }

        private void CreateNewNoteFromIndex()
        {
            string topic = Microsoft.VisualBasic.Interaction.InputBox(
                "New Note topic:", "New Note", "(New Note)", 300, 300);
            if (string.IsNullOrEmpty(topic)) return;

            var newNote = new NoteDocument
            {
                Topic = topic,
                GUID = Guid.NewGuid().ToString(),
                Created = DateTime.Today,
            };
            G.glb.lstNote.Add(newNote);
            SerializeNow();

            var f = new frmInfoNoteV2(newNote);
            f.FormClosed += (s, e) =>
            {
                // 只刷新打开的 Note Archive 窗口，不刷新当前编辑窗口
            };
            M.notesOpened.Add(f);
            f.Show();
        }

        /// <summary>从 Diary 创建新 Note（以指定日期为 TagTime）</summary>
        private void CreateNewNoteFromDate(DateTime date)
        {
            string topic = Microsoft.VisualBasic.Interaction.InputBox(
                "New Note topic:", "New Note", "(New Note)", 300, 300);
            if (string.IsNullOrEmpty(topic)) return;

            var newNote = new NoteDocument
            {
                Topic = topic,
                GUID = Guid.NewGuid().ToString(),
                Created = date,
            };
            G.glb.lstNote.Add(newNote);
            SerializeNow();

            var f = new frmInfoNoteV2(newNote);
            M.notesOpened.Add(f);
            f.Show();
        }

        #region SysNote: Archive 面板
        /// <summary>初始化 Archive 面板：只读索引，按 年→月→Note 展示所有过期 $TASK$> 和 $SCHL$></summary>
        private void InitArchivePanel()
        {
            splitMain.Panel2Collapsed = true;
            richTreeView.IsReadOnly = true;
            richTreeView.IconDisplayMode = true;

            BuildArchiveIndexTree();
            BuildArchiveContextMenu();
        }

        private void BuildArchiveIndexTree() => TreeBuilderService.BuildArchiveIndexTree(richTreeView.OutlinePanel);

        private void BuildArchiveContextMenu()
        {
            // context menu handled by RichTreeView // 使用 OnLineRightClicked 处理
        }
        #endregion

        #region 构造函数
        public frmInfoNoteV2()
        {
            InitializeComponent();
        }

        // 私有构造函数：不调用 InitializeComponent，由调用方通过 InitCommon 初始化
        private frmInfoNoteV2(int _) { }

        public frmInfoNoteV2(NoteDocument info)
        {
            note = info;
            GUID = note.GUID;
            noteType = ENoteType.Note;

            // 从 .md 文件加载 body：按标题/日期构建路径，避免索引 GUID 不一致导致 body 丢失
            string filePath;
            if (PersistedSysNotes.Contains(note.Topic ?? ""))
                filePath = MarkdownNoteConverter.MakeSysNotePath(note.Topic);
            else
                filePath = MarkdownNoteConverter.MakeNotePath(note.Created, note.Topic);

            if (note.Lines.Count > 0)
            {
                // 内存中已有缓存（之前打开过或刚保存过），直接使用共享引用
                lstNoteLog = CloneOutlineLines(note.Lines);
                lstNoteColor = note.Colors;
                _lines = note.Lines;
            }
            else
            {
                var mdData = GameDocument.Load(filePath) as NoteDocument;
                if (mdData != null)
                {
                    // 首次打开：从磁盘加载并写入共享引用
                    note.Lines = mdData.Lines;
                    note.Colors = mdData.Colors;
                    note.Tasks = mdData.Tasks;
                    note.DDLs = mdData.DDLs;
                    note.Created = mdData.Created;
                    note.Modified = mdData.Modified;
                    note.Topic = mdData.Topic;
                    lstNoteLog = CloneOutlineLines(note.Lines);
                    lstNoteColor = note.Colors;
                    _lines = note.Lines;
                }
                else
                {
                    lstNoteLog = new List<OutlineLine>();
                    lstNoteColor = new List<RNoteColor>();
                    _lines = new List<OutlineLine>();
                }
            }

            // 检测 SysNote 类型
            DetectSysNoteType();

            if (sysNoteType == ESysNoteType.Calendar)
            {
                InitCommon("LifeGame - Calendar");
                InitCalendarPanel();
                DrawMonthView();
                return;
            }

            if (sysNoteType == ESysNoteType.Archive)
            {
                InitCommon("LifeGame - Task History");
                this.WindowState = FormWindowState.Normal;
                this.ClientSize = new Size(820, 640);
                this.StartPosition = FormStartPosition.CenterScreen;
                InitArchivePanel();
                return;
            }


            // SysNote: Diary — 作为 DiaryDocument 的临时编辑容器
            if (sysNoteType == ESysNoteType.Diary)
            {
                isSysDiary = true;
                InitSysDiary(DateTime.Today);
                return;
            }

            // Note Archive — 查看所有普通 Note
            if (isSysNote && note.Topic == SysNoteNoteName)
            {
                InitCommon("LifeGame - Note Archive");
                this.WindowState = FormWindowState.Normal;
                this.ClientSize = new Size(820, 640);
                this.StartPosition = FormStartPosition.CenterScreen;
                InitNotesIndexPanel();
                return;
            }

            else
            {
                InitCommon("LifeGame - Note - " + note.Topic + " - " + note.Created.ToShortDateString());
                // 在搜索框左侧添加创建按钮
                AddCreationButtons(
                    (s, e) => CreateNewNoteFromIndex(),
                    (s, e) => CreateNewLiterature(),
                    (s, e) => CreateNewLiteratureReview());
                splitMain.Panel2Collapsed = true;
            }

            LoadOutline();
            richTreeView.RebuildAllContentLabels();
            richTreeView.RootTitle = note.Topic;
            richTreeView.OutlinePanel.LabelColors = richTreeView.BuildLabelColorMap();
            richTreeView.OutlinePanel.LabelForeColors = richTreeView.BuildLabelForeColorMap();
            richTreeView.ApplyLabelColorsToRows();

            this.Text = "LifeGame - Note - " + note.Topic + " - " + note.Created.ToShortDateString();
        }

        public frmInfoNoteV2(LiteratureDocument lit)
        {
            literature = lit;
            GUID = literature.GUID;
            noteType = ENoteType.Literature;

            // 从 .md 文件加载数据（按标题构建路径，避免索引 GUID 不一致导致 body 丢失）
            string filePath = MarkdownNoteConverter.MakeLiteraturePath(literature.Title);
            var litData = GameDocument.Load(filePath) as LiteratureDocument;
            if (litData != null)
            {
                lstNoteLog = CloneOutlineLines(litData.Lines);
                lstNoteColor = litData.Colors;
                _lines = litData.Lines;
                lstLiteratureTag = litData.Tags;
                lstLiteratureAuthor = litData.Authors;
                literature.Topic = litData.Topic ?? literature.Topic;
                literature.Created = litData.Created;
                literature.Modified = litData.Modified;
                literature.Author = litData.Author;
                literature.Journal = litData.Journal;
                literature.Year = litData.Year;
                literature.Volume = litData.Volume;
                literature.Pages = litData.Pages;
                literature.Doi = litData.Doi;
                literature.Publisher = litData.Publisher;
                literature.Booktitle = litData.Booktitle;
                literature.School = litData.School;
                literature.PublishYear = litData.PublishYear;
                literature.Star = litData.Star;
                literature.JournalOrConferenceName = litData.JournalOrConferenceName;
            }
            else
            {
                lstNoteLog = new List<OutlineLine>();
                lstNoteColor = new List<RNoteColor>();
                var fallbackLit = G.glb.lstLiterature.Find(o => o.Title == literature.Title);
                lstLiteratureTag = fallbackLit?.Tags.ToList() ?? new List<RLiteratureTag>();
                lstLiteratureAuthor = fallbackLit?.Authors.OrderBy(o => o.Ordering).ToList() ?? new List<RLiteratureAuthor>();
            }

            InitCommon("LifeGame - Literature - " + literature.Title + " - " + literature.DateAdded.ToShortDateString());
            splitMain.Panel2Collapsed = true;
            // 在搜索框左侧添加创建按钮
            AddCreationButtons(
                (s, e) => CreateNewNoteFromIndex(),
                (s, e) => CreateNewLiterature(),
                (s, e) => CreateNewLiteratureReview());

            LoadLiteratureToSidePanel();
            LoadOutline();
            richTreeView.RootTitle = literature.Topic;
            richTreeView.OutlinePanel.LabelColors = richTreeView.BuildLabelColorMap();
            richTreeView.OutlinePanel.LabelForeColors = richTreeView.BuildLabelForeColorMap();
            richTreeView.ApplyLabelColorsToRows();

            BindLiteratureEvents();
            this.Text = "LifeGame - Literature - " + literature.Title + " - " + literature.DateAdded.ToShortDateString();
        }

        public frmInfoNoteV2(DiaryDocument dr)
        {
            diary = dr;
            GUID = diary.GUID;
            noteType = ENoteType.DailyReport;

            // 从 .md 文件加载数据（按日期构建路径，避免索引 GUID 不一致导致 body 丢失）
            string filePath = MarkdownNoteConverter.MakeDiaryPath(diary.Date);
            var diaryData = GameDocument.Load(filePath) as DiaryDocument;
            if (diaryData != null)
            {
                lstNoteLog = CloneOutlineLines(diaryData.Lines);
                lstNoteColor = diaryData.Colors;
                _lines = diaryData.Lines;
            }
            else
            {
                lstNoteLog = new List<OutlineLine>();
                lstNoteColor = new List<RNoteColor>();
                _lines = new List<OutlineLine>();
            }

            lstTDLNoteLog = LoadTDLNoteLogs();
            lstTDLNoteColor = LoadTDLNoteColors();

            InitCommon("LifeGame - Diary - " + diary.Date.ToString("dd/MM/yyyy"));
            InitDiarySchedule();
            DrawDiarySchedule();
            LoadOutline();
            richTreeView.RootTitle = diary.Topic;
            richTreeView.OutlinePanel.LabelColors = richTreeView.BuildLabelColorMap();
            richTreeView.OutlinePanel.LabelForeColors = richTreeView.BuildLabelForeColorMap();
            richTreeView.ApplyLabelColorsToRows();

            // 在设置按钮右侧添加创建按钮
            AddCreationButtons(
                (s, e) => CreateNewNoteFromDate(diary.Date),
                (s, e) => CreateNewLiterature(),
                (s, e) => CreateNewLiteratureReview());

            this.Text = "LifeGame - Diary - " + diary.Date.ToString("dd/MM/yyyy");
        }

        public frmInfoNoteV2(DateTime date)
        {
            noteType = ENoteType.Note;
            GUID = Guid.NewGuid().ToString();
            note = new NoteDocument { Topic = "New Note", GUID = GUID, Created = date };
            lstNoteLog = new List<OutlineLine>();
            lstNoteColor = new List<RNoteColor>();

            InitCommon("LifeGame - Note - New Note - " + date.ToShortDateString());
            splitMain.Panel2Collapsed = true;
            LoadOutline();
            richTreeView.RootTitle = "New Note";
            richTreeView.OutlinePanel.LabelColors = richTreeView.BuildLabelColorMap();
            richTreeView.OutlinePanel.LabelForeColors = richTreeView.BuildLabelForeColorMap();
            richTreeView.ApplyLabelColorsToRows();
            this.Text = "LifeGame - Note - New Note - " + date.ToShortDateString();
        }

        public frmInfoNoteV2(DateTime date, bool isDiary)
        {
            if (isDiary)
            {
                noteType = ENoteType.DailyReport;
                diary = G.glb.lstDiary.Find(o => o.Date.Date == date.Date);
                if (diary == null)
                {
                    diary = new DiaryDocument { Date = date, GUID = Guid.NewGuid().ToString() };
                    G.glb.lstDiary.Add(diary);
                    DataStore.SaveDiaryIndex();
                }
                GUID = diary.GUID;

                // 从 .md 文件加载数据（按日期构建路径，避免索引 GUID 不一致导致 body 丢失）
                string filePath2 = MarkdownNoteConverter.MakeDiaryPath(diary.Date);
                var diaryData = GameDocument.Load(filePath2) as DiaryDocument;
                if (diaryData != null)
                {
                    lstNoteLog = CloneOutlineLines(diaryData.Lines);
                    lstNoteColor = diaryData.Colors;
                }
                else
                {
                    lstNoteLog = new List<OutlineLine>();
                    lstNoteColor = new List<RNoteColor>();
                }

                InitCommon("LifeGame - Diary - " + diary.Date.ToString("dd/MM/yyyy"));
                InitDiarySchedule();
                DrawDiarySchedule();
                LoadOutline();
                richTreeView.RootTitle = "Diary";
                richTreeView.OutlinePanel.LabelColors = richTreeView.BuildLabelColorMap();
                richTreeView.OutlinePanel.LabelForeColors = richTreeView.BuildLabelForeColorMap();
                richTreeView.ApplyLabelColorsToRows();
                this.Text = "LifeGame - Diary - " + diary.Date.ToString("dd/MM/yyyy");
            }
        }
        #endregion

        #region LiteratureReviewDocument 构造函数
        public frmInfoNoteV2(LiteratureReviewDocument revData)
        {
            InitializeComponent();
            GUID = revData.GUID;
            literatureReview = revData;
            noteType = ENoteType.LiteratureReview;
            lstLiteratureAuthor = new List<RLiteratureAuthor>();
            lstLiteratureTag = new List<RLiteratureTag>();

            string filePath = MarkdownNoteConverter.MakeLiteratureReviewPath(revData.Created, revData.Topic);
            if (filePath != null) revData.EnsureBodyLoaded(filePath);

            _lines = revData.Lines;
            lstNoteColor = revData.Colors;

            InitCommon("LifeGame - Literature Review: " + revData.Topic);
            this.ClientSize = new Size(1440, 680);
            richTreeView.NoteColors = lstNoteColor;
            richTreeView.SysNoteType = ESysNoteType.None;
            richTreeView.IconDisplayMode = true;
            richTreeView.AllowEditNonMeta = true;
            richTreeView.BlockMetaEdit = false;
            richTreeView.Initialize();
            richTreeView.LiteratureTagToggled += RefreshReviewPanel;
            richTreeView.OpenLiteratureReviewByGUID += OpenLiteratureReview;
            richTreeView.OpenLiteratureByTitle += OpenLiterature;
            richTreeView.ContentModified += () => SaveLiteratureReview();

            splitMain.Panel2Collapsed = false;

            // 在搜索框左侧添加创建按钮
            AddCreationButtons(
                (s, e) => CreateNewNoteFromIndex(),
                (s, e) => CreateNewLiterature(),
                (s, e) => CreateNewLiteratureReview());

            LoadLiteratureReviewToSidePanel();

            richTreeView.LoadLines(_lines);
            richTreeView.RootTitle = revData.Topic;
            BuildMetaNode();
            RefreshReviewPanel();
        }

        public frmInfoNoteV2(bool literatureReviewListMode)
        {
            InitializeComponent();
            noteType = ENoteType.LiteratureReview;
            lstLiteratureAuthor = new List<RLiteratureAuthor>();
            lstLiteratureTag = new List<RLiteratureTag>();
            _lines = new List<OutlineLine>();

            InitCommon("LifeGame - Literature Review");
            richTreeView.SysNoteType = ESysNoteType.None;
            richTreeView.AllowEditNonMeta = false;
            richTreeView.BlockMetaEdit = true;
            richTreeView.Initialize();
            richTreeView.OpenLiteratureReviewByGUID += OpenLiteratureReview;
            richTreeView.DeleteLiteratureReviewRequested += (guid) =>
            {
                var rev = G.glb.lstLiteratureReview.Find(r => r.GUID == guid);
                if (rev == null) return;
                if (MessageBox.Show("Delete Literature Review \"" + rev.Topic + "\"?\nThis action cannot be undone.",
                    "Delete Literature Review", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    != DialogResult.Yes) return;
                string filePath = DataStore.GetLiteratureReviewFilePath(rev.GUID);
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                    File.Delete(filePath);
                if (M.NoteExists(rev.GUID))
                {
                    var f = M.FindNoteForm(rev.GUID);
                    if (f != null) { f.FormClosing -= frmInfoNoteV2_FormClosing; f.Close(); }
                }
                G.glb.lstLiteratureReview.Remove(rev);
                DataStore.SaveLiteratureReviewIndex();
                DataStore.RebuildLiteratureReviewList();
                BuildLiteratureReviewList();
            };

            splitMain.Panel2Collapsed = true;

            // 在搜索框左侧添加创建按钮
            AddCreationButtons(
                (s, e) => CreateNewNoteFromIndex(),
                (s, e) => CreateNewLiterature(),
                (s, e) => CreateNewLiteratureReview());

            BuildLiteratureReviewList();
        }
        #endregion

        #region 界面初始化
        internal void InitCommon(string title)
        {
            // 根据 Note 类型设定初始大小和位置
            if (sysNoteType == ESysNoteType.Calendar || sysNoteType == ESysNoteType.Archive)
            {
                this.WindowState = FormWindowState.Normal;
                this.ClientSize = new Size(1440, 680);
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (noteType == ENoteType.DailyReport)
            {
                this.WindowState = FormWindowState.Normal;
                this.ClientSize = new Size(960, 680);
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.ClientSize = new Size(480, 640);
                this.StartPosition = FormStartPosition.CenterScreen;
            }

            InitializeBaseUI();
            LoadIconsFromDisk();

            // 重新设置 ClientSize（InitializeBaseUI 不设置 ClientSize）
            if (sysNoteType == ESysNoteType.Calendar || sysNoteType == ESysNoteType.Archive)
            {
                this.ClientSize = new Size(1440, 680);
            }
            else if (noteType == ENoteType.DailyReport)
            {
                this.ClientSize = new Size(960, 680);
            }
            else
            {
                this.ClientSize = new Size(480, 640);
            }

            this.Text = title;

            // === 重建 topPanel 布局 ===
            RebuildTopPanel();

            // === 主题应用 ===
            if (Theme.Current == null)
            {
                this.BackColor = Color.FromArgb(245, 242, 235);
            }

            btnSearch.FlatAppearance.BorderSize = 0;
            StyleButton(btnSearch, Theme.Current.ButtonPrimaryBg, Theme.Current.ButtonPrimaryFg);

            assignEvents();

            richTreeView.Initialize();
            richTreeView.SysNoteType = sysNoteType;
            richTreeView.SysNoteTopic = note.Topic;
            richTreeView.NoteColors = lstNoteColor;
            outlineSidePanel.LineRightClicked += OnSidePanelRightClicked;

            // Wire events
            richTreeView.ContentModified += () => { /* dirty already tracked internally */ };
            richTreeView.MetaSectionModified += () => { ParseMetaNode(); SaveOrHandleMetaChange(); };
            richTreeView.TaskOrScheduleChanged += () => DrawMonthView();
            richTreeView.OpenNoteByGUID += (guid) => {
                var n = G.glb.lstNote.Find(o => o.GUID == guid);
                if (n != null) OpenOrActivateNote(n);
            };
            richTreeView.OpenLiteratureByTitle += (t) => {
                var lit = G.glb.lstLiterature.Find(o => o.Title == t);
                if (lit != null) {
                    if (M.NoteExists(lit.GUID)) M.FindNoteForm(lit.GUID).BringToFront();
                    else { var f = new frmInfoNoteV2(lit); f.Show(); M.notesOpened.Add(f); }
                }
            };
            richTreeView.OpenUrl += (url) => { try { System.Diagnostics.Process.Start(url); } catch { } };
            richTreeView.OpenDiary += (date) => OpenDiaryFromMenu(date);
            richTreeView.DeleteNoteRequested += (topic) => {
                var delNote = G.glb.lstNote.Find(o => o.Topic == topic);
                if (delNote != null) {
                    if (MessageBox.Show("Delete note \"" + delNote.Topic + "\"?\nThis action cannot be undone.",
                        "Delete Note", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        != DialogResult.Yes) return;
                    if (M.NoteExists(delNote.GUID))
                    {
                        var f = M.FindNoteForm(delNote.GUID);
                        if (f != null) { f.FormClosing -= frmInfoNoteV2_FormClosing; f.Close(); }
                    }
                    G.glb.lstNote.Remove(delNote);
                    SerializeNow();
                    RefreshNotesIndex();
                }
            };
            richTreeView.ArchiveTaskRequested += (line) => ArchiveTask(line);
            richTreeView.RepeatWeeklyRequested += (line) => RepeatWeekly(line);
            richTreeView.NoteRenamed += (oldTopic, newTopic, tagTime) =>
            {
                this.Text = this.Text.Replace(oldTopic, newTopic);
                richTreeView.RootTitle = newTopic;
                SaveNote();
                foreach (var form in M.notesOpened)
                {
                    if (form is frmInfoNoteV2 f && f != this)
                        f.richTreeView.UpdateNoteRefsInTree(oldTopic, newTopic, tagTime);
                }
            };

            // === 美化顶部栏 ===
            if (Theme.Current != null)
                topPanel.BackColor = Theme.Current.TopBarBg;
            topPanel.Invalidate();


            // === 美化 splitMain ===
            splitMain.BackColor = Theme.Current?.Border ?? Color.FromArgb(225, 218, 205);

            this.Shown += (s, e) =>
            {
                richTreeView.RefreshLayout();
            };
        }

        private void SaveOrHandleMetaChange()
        {
            if (noteType == ENoteType.Note) SaveNote();
            else if (noteType == ENoteType.Literature) SaveLiterature();
            else SaveNote();
            if (noteType == ENoteType.DailyReport) DrawDiarySchedule();
        }

        /// <summary>显示设置弹出菜单</summary>
        private void ShowSettingsMenu(Button btn)
        {
            var cms = new ContextMenuStrip();
            var mnuMode = new ToolStripMenuItem("主题模式");
            var mnuLight = new ToolStripMenuItem("☀ Light Mode", null, (s, e) => SwitchTheme(ThemeMode.Light));
            var mnuDark = new ToolStripMenuItem("🌙 Dark Mode", null, (s, e) => SwitchTheme(ThemeMode.Dark));
            mnuLight.Checked = Theme.Current?.Mode == ThemeMode.Light;
            mnuDark.Checked = Theme.Current?.Mode == ThemeMode.Dark;
            mnuMode.DropDownItems.Add(mnuLight);
            mnuMode.DropDownItems.Add(mnuDark);
            cms.Items.Add(mnuMode);
            cms.Show(btn, new Point(0, btn.Height));
        }

        /// <summary>在搜索框左侧插入一个额外按钮</summary>
        protected override void OnSettingsClick(object sender, EventArgs e)
        {
            ShowSettingsMenu((Button)sender);
        }

        /// <summary>主题切换</summary>
        private void SwitchTheme(ThemeMode mode)
        {
            Theme.SetTheme(mode);
            ApplyThemeToForm();
        }

        /// <summary>将当前主题应用到窗体所有控件</summary>
        protected override void ApplyThemeToForm()
        {
            this.BackColor = Theme.Current.FormBackground;
            topPanel.BackColor = Theme.Current.TopBarBg;
            splitMain.BackColor = Theme.Current.Border;

            // 搜索框
            StyleSearchBox();
            StyleButton(btnSearch, Theme.Current.ButtonPrimaryBg, Theme.Current.ButtonPrimaryFg);

            // 设置按钮样式
            if (toolbarTable != null && toolbarTable.Controls.Count > 0)
            {
                foreach (Control c in toolbarTable.Controls)
                {
                    if (c is Button b && b.Text.StartsWith("设置"))
                        StyleButton(b, Theme.Current.ButtonSecondaryBg, Theme.Current.ButtonSecondaryFg);
                    else if (c is Button b2 && (b2.Text == "+ Note" || b2.Text == "+ Lit"))
                        StyleButton(b2, Theme.Current.ButtonPrimaryBg, Theme.Current.ButtonPrimaryFg);
                }
            }
            topPanel.Invalidate(); // 重画分割线

            // 面板
            if (scheduleToolbar != null) scheduleToolbar.BackColor = Theme.Current.ToolbarBackground;
            if (scheduleCanvas != null) scheduleCanvas.BackColor = Theme.Current.ScheduleBg;
            if (calendarToolbar != null) calendarToolbar.BackColor = Theme.Current.ToolbarBackground;
            if (calendarPanel != null) calendarPanel.BackColor = Theme.Current.ScheduleBg;

            // SidePanel top bar
            if (splitMain.Panel2.Controls.Count > 0 && splitMain.Panel2.Controls[0] is Panel stb)
            {
                stb.BackColor = Theme.Current.ToolbarBackground;
            }

            // Outline panels - 刷新面板及所有行颜色
            richTreeView.OutlinePanel.BackColor = Theme.Current.PanelBackground;
            richTreeView.OutlinePanel.ApplyTheme();
            outlineSidePanel.BackColor = Theme.Current.PanelBackground;
            outlineSidePanel.ApplyTheme();

            // 日程表重绘
            if (noteType == ENoteType.DailyReport)
                DrawDiarySchedule();
            if (sysNoteType == ESysNoteType.Calendar)
                DrawMonthView();

        }

        #endregion

        #region 事件绑定
        private void assignEvents()
        {
            btnSearch.Click += btnSearch_Click;
            this.FormClosing += frmInfoNoteV2_FormClosing;
        }

        private string RootText => richTreeView.GetAllLines()
            .Where(l => !l.IsMetaNode && !l.IsMetaSectionHeader && l.Level == 0)
            .Select(l => l.Text)
            .FirstOrDefault() ?? "";
        #endregion

        #region 加载/保存
        private void LoadOutline()
        {
            if (lstNoteLog.Count == 0)
            {
                richTreeView.LoadLines(new List<OutlineLine>());
            }
            else
            {
                var lines = CloneOutlineLines(lstNoteLog);
                richTreeView.LoadLines(lines);
            }
            BuildMetaNode();
            richTreeView.IsDirty = false;
        }

        /// <summary>Get content lines (non-meta) from the tree in DFS order.</summary>
        private List<OutlineLine> GetContentLines()
        {
            var lines = richTreeView.GetAllLines()
                .Where(l => l.GUID != "__ROOT__" && !l.IsMetaNode && !l.IsMetaSectionHeader)
                .ToList();
            return OutlineConverter.OrderByTree(lines);
        }

        /// <summary>Deep clone a list of OutlineLine to avoid shared reference mutation.</summary>
        private static List<OutlineLine> CloneOutlineLines(List<OutlineLine> source)
        {
            return source.Select(l => new OutlineLine
            {
                Text = l.Text,
                Level = l.Level,
                GUID = l.GUID,
                ParentGUID = l.ParentGUID,
                Ordering = l.Ordering,
                IsMetaNode = l.IsMetaNode,
                IsMetaSectionHeader = l.IsMetaSectionHeader,
                MetaType = l.MetaType,
                MetaValue = l.MetaValue,
                Expanded = l.Expanded,
                AllowAddChild = l.AllowAddChild,
                EditFormatHint = l.EditFormatHint,
                EditFormatRegex = l.EditFormatRegex,
                LabelKeywords = l.LabelKeywords != null ? new List<string>(l.LabelKeywords) : null,
                ProgressPercent = l.ProgressPercent,
            }).ToList();
        }

        private void SaveNoteLog()
        {
            lstNoteLog = CloneOutlineLines(GetContentLines());
        }

        private void SaveNote()
        {
            if (isSearchResult) return; // 搜索结果窗口不保存

            LogDebug($"[SaveNote] ENTER: GUID={GUID}, noteType={noteType}");

            ParseMetaNode();
            SaveNoteLog();

            if (noteType == ENoteType.Note)
            {
                // Generate tasks from Lines for YAML
                var contentLines = GetContentLines();
                var tasks = new List<NoteTask>();
                foreach (var l in contentLines)
                {
                    if (l.MetaType == NodeMetaType.Task || l.MetaType == NodeMetaType.Schedule
                        || l.MetaType == NodeMetaType.Deadline || l.MetaType == NodeMetaType.Progress)
                    {
                        tasks.Add(new NoteTask { Text = l.Text, MetaType = l.MetaType.ToString() });
                    }
                }
                var ddls = new List<DDLEntry>();
                var seenTexts = new HashSet<string>();
                for (int i = 0; i < contentLines.Count; i++)
                {
                    if (contentLines[i].MetaType != NodeMetaType.Deadline) continue;
                    string text = contentLines[i].Text.Trim();
                    if (!seenTexts.Add(text)) continue;
                    string parent = "";
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (contentLines[j].Level < contentLines[i].Level)
                        {
                            parent = contentLines[j].Text;
                            break;
                        }
                    }
                    ddls.Add(new DDLEntry { Text = text, Parent = parent });
                }

                if (PersistedSysNotes.Contains(note?.Topic ?? ""))
                {
                    // SysNote：写入 data/sysnotes/SYSN_xxx.md
                    string sysPath = MarkdownNoteConverter.MakeSysNotePath(note.Topic);
                    string yaml = BuildSysNoteYaml(GUID, note.Topic, note.Created, DateTime.Now, lstNoteColor, ddls, tasks);
                    string body = MarkdownNoteConverter.BuildOutlineBodyWithTitle(note.Topic, contentLines);
                    string content = "---\n" + yaml + "---\n\n" + body;
                    DataFileHelper.AtomicWriteText(sysPath, content);
                }
                else
                {
                    try
                    {
                    string oldPath = DataStore.GetNoteFilePath(GUID);
                    var noteData = new NoteDocument
                    {
                        GUID = GUID,
                        Topic = note?.Topic ?? "",
                        Created = note?.Created ?? DateTime.Today,
                        Modified = DateTime.Now,
                        Colors = lstNoteColor,
                        DDLs = ddls,
                        Tasks = tasks,
                        Lines = contentLines,
                    };
                    string newPath = noteData.Save(oldPath);
                    LogDebug($"[SaveNote] oldPath={oldPath}, newPath={newPath}, contentLines={contentLines.Count}, fileExists={File.Exists(newPath)}");

                    // 同步更新 G.glb.lstNote 中的内存引用（必须在 SaveNoteIndex 之前）
                    if (note != null)
                    {
                        note.Topic = noteData.Topic;
                        note.Created = noteData.Created;
                        note.Modified = noteData.Modified;
                        note.Colors = noteData.Colors;
                        note.Tasks = noteData.Tasks;
                        note.DDLs = noteData.DDLs;
                        note.Lines = noteData.Lines;
                    }

                    DataStore.SaveNoteIndex();
                    }
                    catch (Exception ex)
                    {
                        LogDebug($"[SaveNote] EXCEPTION: {ex.Message}\n{ex.StackTrace}");
                        MessageBox.Show($"Save failed: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (noteType == ENoteType.DailyReport)
            {
                var contentLines = GetContentLines();
                var tasks = new List<NoteTask>();
                foreach (var l in contentLines)
                {
                    if (l.MetaType == NodeMetaType.Task || l.MetaType == NodeMetaType.Schedule
                        || l.MetaType == NodeMetaType.Deadline || l.MetaType == NodeMetaType.Progress)
                    {
                        tasks.Add(new NoteTask { Text = l.Text, MetaType = l.MetaType.ToString() });
                    }
                }
                var ddls = new List<DDLEntry>();
                var seenTexts = new HashSet<string>();
                for (int i = 0; i < contentLines.Count; i++)
                {
                    if (contentLines[i].MetaType != NodeMetaType.Deadline) continue;
                    string text = contentLines[i].Text.Trim();
                    if (!seenTexts.Add(text)) continue;
                    string parent = "";
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (contentLines[j].Level < contentLines[i].Level)
                        {
                            parent = contentLines[j].Text;
                            break;
                        }
                    }
                    ddls.Add(new DDLEntry { Text = text, Parent = parent });
                }

                string oldPath = isSysDiary ? DataStore.GetDiaryFilePath(diary.GUID) : DataStore.GetDiaryFilePath(GUID);
                var diaryData = new DiaryDocument
                {
                    GUID = isSysDiary ? diary.GUID : GUID,
                    Date = diary?.Date ?? DateTime.Today,
                    Colors = lstNoteColor,
                    DDLs = ddls,
                    Tasks = tasks,
                    Lines = contentLines,
                };
                string newPath = diaryData.Save(oldPath);
                DataStore.SaveDiaryIndex();
            }
            else if (noteType == ENoteType.Literature)
            {
                string oldPath = DataStore.GetLiteratureFilePath(GUID);
                var litData = new LiteratureDocument
                {
                    GUID = GUID,
                    Topic = literature?.Topic ?? "",
                    Created = literature?.Created ?? DateTime.Today,
                    Modified = DateTime.Now,
                    Author = literature?.Author ?? "",
                    Journal = literature?.Journal ?? "",
                    Year = literature?.Year ?? "",
                    Volume = literature?.Volume ?? "",
                    Pages = literature?.Pages ?? "",
                    Doi = literature?.Doi ?? "",
                    Publisher = literature?.Publisher ?? "",
                    Booktitle = literature?.Booktitle ?? "",
                    School = literature?.School ?? "",
                    PublishYear = literature?.PublishYear ?? 0,
                    Star = literature?.Star ?? false,
                    JournalOrConferenceName = literature?.JournalOrConferenceName ?? literature?.Journal ?? literature?.Booktitle ?? "",
                    Colors = lstNoteColor,
                    Authors = lstLiteratureAuthor,
                    Tags = lstLiteratureTag,
                    Lines = GetContentLines(),
                };
                string newPath = litData.Save(oldPath);
                DataStore.SaveLiteratureIndex();
            }

            richTreeView.RefreshModifiedTimestamp();
            richTreeView.IsDirty = false;
        }

        private void SerializeNow()
        {
            // 保存所有打开的笔记
            SaveNote();

            // 保存全局配置状态
            DataStore.SaveAppConfig();
            DataStore.SaveNoteIndex();
            DataStore.SaveLiteratureIndex();
            DataStore.SaveDiaryIndex();
        }

        private void SaveLiterature()
        {
            ParseMetaNode();

            if (string.IsNullOrEmpty(literature.JournalOrConferenceName))
            { MessageBox.Show("Journal/Conference Name is missing"); return; }
            if (lstLiteratureAuthor.Count == 0)
            { MessageBox.Show("Add author"); return; }
            if (lstLiteratureTag.Count == 0)
            { MessageBox.Show("Add tag"); return; }

            // 更新全局列表
            string litTitle = literature.Title;
            var lit = G.glb.lstLiterature.Find(o => o.Title == litTitle);
            if (lit != null)
            {
                lit.Topic = literature.Topic;
                lit.PublishYear = literature.PublishYear;
                lit.JournalOrConferenceName = literature.JournalOrConferenceName;
                lit.Modified = DateTime.Today;
                lit.Star = literature.Star;
                lit.Authors = new List<RLiteratureAuthor>(lstLiteratureAuthor);
                lit.Tags = new List<RLiteratureTag>(lstLiteratureTag);
            }
            else
            {
                // 新增 Literature
                lit = literature;
                G.glb.lstLiterature.Add(lit);
            }

            SaveNote(); // SaveNote 内部已处理 .md 写入
            DataStore.SaveLiteratureIndex();
            RefreshTab?.Invoke();
        }

        #region === Diary 日程面板辅助 ===

        /// <summary>从 TDL Note 的 .md 文件加载 NoteLog</summary>
        private List<OutlineLine> LoadTDLNoteLogs()
        {
            string tdlPath = MarkdownNoteConverter.MakeSysNotePath(SysNoteTDLName);
            var mdData = GameDocument.Load(tdlPath) as NoteDocument;
            if (mdData != null)
                return CloneOutlineLines(mdData.Lines);

            return new List<OutlineLine>();
        }

        private List<RNoteColor> LoadTDLNoteColors()
        {
            string tdlPath = MarkdownNoteConverter.MakeSysNotePath(SysNoteTDLName);
            var mdData = GameDocument.Load(tdlPath) as NoteDocument;
            if (mdData != null)
                return mdData.Colors;

            return new List<RNoteColor>();
        }

        /// <summary>将 Diary .md 中的 Logs/Events 同步到全局列表</summary>
        private void InitSysDiary(DateTime date)
        {
            noteType = ENoteType.DailyReport;
            diary = G.glb.lstDiary.Find(o => o.Date.Date == date.Date);
            if (diary == null)
            {
                diary = new DiaryDocument { Date = date, GUID = Guid.NewGuid().ToString() };
                G.glb.lstDiary.Add(diary);
                DataStore.SaveDiaryIndex();
            }

            // 从 .md 文件加载数据
            string filePath3 = MarkdownNoteConverter.MakeDiaryPath(diary.Date);
            var diaryData = GameDocument.Load(filePath3) as DiaryDocument;
            if (diaryData != null)
            {
                lstNoteLog = CloneOutlineLines(diaryData.Lines);
                lstNoteColor = diaryData.Colors;
            }
            else
            {
                lstNoteLog = new List<OutlineLine>();
                lstNoteColor = new List<RNoteColor>();
            }

            lstTDLNoteLog = LoadTDLNoteLogs();
            lstTDLNoteColor = LoadTDLNoteColors();

            InitCommon("LifeGame - Diary - " + diary.Date.ToString("dd/MM/yyyy"));
            InitDiarySchedule();
            DrawDiarySchedule();
            LoadOutline();
            richTreeView.RootTitle = "Diary";
            richTreeView.OutlinePanel.LabelColors = richTreeView.BuildLabelColorMap();
            richTreeView.OutlinePanel.LabelForeColors = richTreeView.BuildLabelForeColorMap();
            richTreeView.ApplyLabelColorsToRows();
            this.Text = "LifeGame - Diary - " + diary.Date.ToString("dd/MM/yyyy");
        }

        #endregion

        private void InitDiarySchedule()
        {
            splitMain.Panel2.Controls.Clear();
            splitMain.Panel2Collapsed = false;
            splitMain.SplitterDistance = this.ClientSize.Width * 1 / 4; // 左右 1:3

            // 顶部工具栏
            scheduleToolbar = new Panel
            {
                Dock = DockStyle.Top,
                BackColor = Theme.Current.ToolbarBackground,
                Height = 36,
                Padding = new Padding(10, 4, 10, 4),
            };

            // DateTimePicker 切换日期
            dtpDiaryDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy/MM/dd  ddd",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Width = 160,
                Location = new Point(10, 5),
                Value = diary.Date,
            };
            dtpDiaryDate.ValueChanged += DtpDiaryDate_ValueChanged;
            scheduleToolbar.Controls.Add(dtpDiaryDate);

            // 画布
            scheduleCanvas = new PictureBox
            {
                Dock = DockStyle.Fill,
                BackColor = Theme.Current.ScheduleBg,
            };
            scheduleCanvas.SizeMode = PictureBoxSizeMode.Normal;

            // 容器
            scheduleContainer = new Panel { Dock = DockStyle.Fill, Visible = true };
            scheduleContainer.Controls.Add(scheduleCanvas);
            scheduleContainer.Controls.Add(scheduleToolbar);

            splitMain.Panel2.Controls.Add(scheduleContainer);

            scheduleCanvas.Resize += (s, e) => DrawDiarySchedule();
        }

        private void DtpDiaryDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDiaryDate.Value.Date == diary.Date) return;
            SwitchDiaryDate(dtpDiaryDate.Value.Date);
        }

        /// <summary>切换到指定日期的 Diary Note</summary>
        public void SwitchDiaryDate(DateTime newDate)
        {
            diary = G.glb.lstDiary.Find(o => o.Date.Date == newDate.Date);
            if (diary == null)
            {
                diary = new DiaryDocument { Date = newDate, GUID = Guid.NewGuid().ToString() };
                G.glb.lstDiary.Add(diary);
                DataStore.SaveDiaryIndex();
            }
            // SysDiary 保持 GUID 不变；普通 Diary 窗口使用 DiaryDocument GUID
            if (!isSysDiary)
                GUID = diary.GUID;

            // 从 .md 文件加载数据（按日期构建路径，避免索引 GUID 不一致导致 body 丢失）
            string filePath3 = MarkdownNoteConverter.MakeDiaryPath(diary.Date);
            var diaryData = GameDocument.Load(filePath3) as DiaryDocument;
            if (diaryData != null)
            {
                lstNoteLog = CloneOutlineLines(diaryData.Lines);
                lstNoteColor = diaryData.Colors;
            }
            else
            {
                lstNoteLog = new List<OutlineLine>();
                lstNoteColor = new List<RNoteColor>();
            }

            lstTDLNoteLog = LoadTDLNoteLogs();
            lstTDLNoteColor = LoadTDLNoteColors();

            this.Text = "LifeGame - Diary - " + diary.Date.ToString("dd/MM/yyyy");
            LoadOutline();
            richTreeView.RootTitle = "Diary";
            richTreeView.OutlinePanel.LabelColors = richTreeView.BuildLabelColorMap();
            richTreeView.OutlinePanel.LabelForeColors = richTreeView.BuildLabelForeColorMap();
            richTreeView.ApplyLabelColorsToRows();
            DrawDiarySchedule();
            RefreshTab?.Invoke();
        }

        private void DrawDiarySchedule()
        {
            this.Text = "LifeGame - Diary - " + diary.Date.ToString("dd/MM/yyyy");

            if (scheduleCanvas == null || scheduleCanvas.Height < 100) return;

            int availableHeight = scheduleCanvas.Height;
            if (availableHeight < 300) availableHeight = 600;
            int realHourHeight = availableHeight / 24;

            var plot = new plot();
            plot.DrawDiaryTimeline(scheduleCanvas, diary.Date, realHourHeight);
        }

        /// <summary>创建 Meta 根节点及固定树结构（Level 0，在内容根之前）</summary>
        private void BuildMetaNode()
        {
            var allLines = richTreeView.GetAllLines();

            // 如果 lstReferenceLinks 尚未被 ParseMetaNode 填充（如初始加载），
            // 先从现有 allLines 中捕获 Reference 子节点
            if (lstReferenceLinks.Count == 0)
            {
                var existingRefSection = allLines.Find(l =>
                    l.IsMetaSectionHeader && l.Text == "Reference" && l.Level == 1);
                if (existingRefSection != null)
                {
                    foreach (var child in allLines.Where(l =>
                        l.ParentGUID == existingRefSection.GUID && !l.IsMetaSectionHeader))
                        lstReferenceLinks.Add(child.Text);
                }
            }

            // 删除所有旧的 Meta 节点
            allLines.RemoveAll(l => l.IsMetaNode || l.IsMetaSectionHeader);
            richTreeView.SetMetaRoot(null);

            string typeSuffix = noteType == ENoteType.Note ? "Note"
                : noteType == ENoteType.Literature ? "Literature"
                : noteType == ENoteType.LiteratureReview ? "LiteratureReview"
                : "Diary";

            // Meta 根节点（Level 0）
            var metaRoot = new OutlineLine
            {
                Text = "Meta - " + typeSuffix,
                Level = 0,
                ParentGUID = "",
                IsMetaNode = true,
                IsMetaSectionHeader = true,
                AllowAddChild = false,
                Expanded = true,
                Ordering = -1 // 在内容根之前
            };
            allLines.Insert(0, metaRoot);
            richTreeView.SetMetaRoot(metaRoot);

            int order = 0;

            // === Literature 特有 ===
            if (noteType == ENoteType.Literature)
            {
                // Publisher section（不可新增子节点，固定格式）
                var pubSection = AddMetaSection(allLines, metaRoot.GUID, "Publisher", order++, false,
                    false, @"^(Title|Year|Journal): .+$", "Title/Year/Journal: value");
                AddMetaLeaf(allLines, pubSection.GUID, "Title: " + literature.Title, 0);
                AddMetaLeaf(allLines, pubSection.GUID, "Year: " + literature.PublishYear, 1);
                AddMetaLeaf(allLines, pubSection.GUID, "Journal: " + (literature.JournalOrConferenceName ?? ""), 2);

                // Authorship section（可新增子节点）
                var authSection = AddMetaSection(allLines, metaRoot.GUID, "Authorship", order++, true,
                    true, @"^(Author: .+|\$LINK\$>.*)$", "Author: name / $LINK$>path");
                int aOrder = 0;
                foreach (var a in lstLiteratureAuthor)
                    AddMetaLeaf(allLines, authSection.GUID, "Author: " + a.Author, aOrder++);

                // Tag section（可新增子节点）
                var tagSection = AddMetaSection(allLines, metaRoot.GUID, "Tag", order++, true,
                    true, @"^Tag: .+$", "Tag: Name");
                int tOrder = 0;
                foreach (var t in lstLiteratureTag)
                    AddMetaLeaf(allLines, tagSection.GUID, "Tag: " + t.Tag, tOrder++);

                // Reference section（不可修改，可新增子节点）
                var refSection = AddMetaSection(allLines, metaRoot.GUID, "Reference", order++, false,
                    true, @"^\$LINK\$>.+$", "$LINK$>path_or_url");
                // 恢复已保存的 Reference 子节点，若无则种子化默认链接
                if (lstReferenceLinks.Count > 0)
                {
                    int rOrder = 0;
                    foreach (var link in lstReferenceLinks)
                        AddMetaLeaf(allLines, refSection.GUID, link, rOrder++);
                }
                else
                {
                    string scholarUrl = "https://scholar.google.com/scholar?q=" + Uri.EscapeDataString(literature.Title);
                    string safeTitle = literature.Title ?? "paper";
                    foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                        safeTitle = safeTitle.Replace(c, '_');
                    AddMetaLeaf(allLines, refSection.GUID, "$LINK$>" + scholarUrl, 0);
                    AddMetaLeaf(allLines, refSection.GUID, "$LINK$>D:\\Literature\\" + safeTitle + ".pdf", 1);
                }

                // Label color（放到最后）
                var labelSection = AddMetaSection(allLines, metaRoot.GUID, "Label color", order++, true,
                    true, @"^[^:]+: .+$", "TagName: ColorName");
                foreach (var nc in lstNoteColor)
                {
                    var leaf = AddMetaLeaf(allLines, labelSection.GUID, string.Format("{0}: {1}", nc.Keyword, nc.Color), order++);
                    leaf.LabelKeywords = new List<string> { nc.Keyword };
                }
            }

            // === Note 特有（只有 Label color）===
            if (noteType == ENoteType.Note)
            {
                var labelSection = AddMetaSection(allLines, metaRoot.GUID, "Label color", order++, true,
                    true, @"^[^:]+: .+$", "TagName: ColorName");
                foreach (var nc in lstNoteColor)
                {
                    var leaf = AddMetaLeaf(allLines, labelSection.GUID, string.Format("{0}: {1}", nc.Keyword, nc.Color), order++);
                    leaf.LabelKeywords = new List<string> { nc.Keyword };
                }
            }

            // === Diary 特有 ===
            if (noteType == ENoteType.DailyReport)
            {
                // Label color
                var labelSection = AddMetaSection(allLines, metaRoot.GUID, "Label color", order++, true,
                    true, @"^[^:]+: .+$", "TagName: ColorName");
                foreach (var nc in lstNoteColor)
                {
                    var leaf = AddMetaLeaf(allLines, labelSection.GUID, string.Format("{0}: {1}", nc.Keyword, nc.Color), order++);
                    leaf.LabelKeywords = new List<string> { nc.Keyword };
                }

                // Log section — 格式 $SCHL$>LogName@HH:mm-HH:mm@Color@Location
                // 追加从 TDL + Archive 导入的 $TASK$> 和 $SCHL$>
                var logSection = AddMetaSection(allLines, metaRoot.GUID, "Log", order++, false,
                    true, @"^(\$SCHL\$>.+|$TASK\$>.+)$",
                    "$SCHL$>Name@HH:mm-HH:mm@Color@Location");
                int lOrder = 0;
                foreach (var s in diary.Schedules)
                {
                    string logText = ScheduleToText(s);
                    AddMetaLeaf(allLines, logSection.GUID, logText, lOrder++);
                }

                // 从 TDL 导入匹配今天的 $TASK$> 和独立 $SCHL$>
                if (lstTDLNoteLog.Count > 0)
                    ImportTDLToLog(allLines, logSection.GUID, ref lOrder);

                // 从 Archive 导入匹配今天的 $TASK$> 和 $SCHL$>
                var archiveNote = G.glb.lstNote.Find(o => o.Topic == SysNoteArchiveName);
                if (archiveNote != null)
                {
                    string archivePath = MarkdownNoteConverter.MakeNotePath(archiveNote.Created, archiveNote.Topic);
                    if (archivePath != null) { try { archiveNote.EnsureBodyLoaded(archivePath); } catch { } }
                    if (archiveNote.Lines.Count > 0)
                    {
                        // 为 archive 条目标记归档
                        foreach (var line in archiveNote.Lines)
                        {
                            if (line.IsMetaNode) continue;
                            var subLog = line.Text;
                            if (subLog.StartsWith("$TASK$>"))
                            {
                                var start = ParseTaskStart(subLog);
                                var end = ParseTaskEnd(subLog);
                                if (start != DateTime.MinValue && end != DateTime.MinValue && diary.Date >= start && diary.Date <= end)
                                {
                                    string[] wd = ParseWeeklyDays(subLog);
                                    if (wd.Length > 0 && !wd.Contains(diary.Date.ToString("ddd"), StringComparer.OrdinalIgnoreCase))
                                        continue;
                                    AddMetaLeaf(allLines, logSection.GUID, subLog + " ✓", lOrder++);
                                }
                            }
                            else if (subLog.StartsWith("$SCHL$>"))
                            {
                                var schlDate = ParseSchlDate(subLog);
                                if (schlDate != DateTime.MinValue && schlDate.Date == diary.Date)
                                    AddMetaLeaf(allLines, logSection.GUID, subLog + " ✓", lOrder++);
                            }
                        }
                    }
                }

            }

            // === LiteratureReview 特有（只有 Label color）===
            if (noteType == ENoteType.LiteratureReview)
            {
                var labelSection = AddMetaSection(allLines, metaRoot.GUID, "Label color", order++, true,
                    true, @"^[^:]+: .+$", "TagName: ColorName");
                foreach (var nc in lstNoteColor)
                {
                    var leaf = AddMetaLeaf(allLines, labelSection.GUID, string.Format("{0}: {1}", nc.Keyword, nc.Color), order++);
                    leaf.LabelKeywords = new List<string> { nc.Keyword };
                }
            }

            OutlineConverter.ComputeLevels(allLines);
            richTreeView.RefreshLayout();
        }

        // ========== Schedule 辅助方法 ==========

        private static string ScheduleToText(ScheduleEntry s)
        {
            string name = string.IsNullOrEmpty(s.Name) ? "[Log]" : s.Name;
            return $"$SCHL$>{name}@{s.Start}-{s.End}@{s.Color}@{s.Location}";
        }

        private static ScheduleEntry TextToSchedule(string t)
        {
            if (!t.StartsWith("$SCHL$>")) return null;
            t = t.Substring(7);
            var parts = t.Split('@');
            if (parts.Length < 3) return null;
            return new ScheduleEntry
            {
                Name = parts[0].Trim(),
                Start = parts[1].Split('-')[0].Trim(),
                End = parts[1].Split('-').Length > 1 ? parts[1].Split('-')[1].Trim() : "",
                Color = parts[2].Trim(),
                Location = parts.Length >= 4 ? parts[3].Trim() : "",
                WithWho = parts.Length >= 5 ? parts[4].Trim() : "",
            };
        }

        /// <summary>将 TDL 中匹配今天日期的 $TASK$> 和独立 $SCHL$> 导入 Diary Log</summary>
        private void ImportTDLToLog(List<OutlineLine> allLines, string logSectionGUID, ref int lOrder)
        {
            var tdlLines = CloneOutlineLines(lstTDLNoteLog);
            foreach (var line in tdlLines)
            {
                if (line.IsMetaNode || line.IsMetaSectionHeader) continue;
                if (line.MetaType == NodeMetaType.Task)
                {
                    var start = ParseTaskStart(line.Text);
                    var end = ParseTaskEnd(line.Text);
                    if (start == DateTime.MinValue || end == DateTime.MinValue) continue;
                    if (diary.Date < start || diary.Date > end) continue;
                    // Weekly 过滤
                    string[] wd = ParseWeeklyDays(line.Text);
                    if (wd.Length > 0 && !wd.Contains(diary.Date.ToString("ddd"), StringComparer.OrdinalIgnoreCase))
                        continue;
                    // $TASK$> 导入不带具体时间
                    AddMetaLeaf(allLines, logSectionGUID, "$TASK$>" + ParseTaskName(line.Text), lOrder++);
                }
                else if (line.MetaType == NodeMetaType.Schedule)
                {
                    if (IsChildOfTaskNode(line)) continue; // $TASK$> 下的 $SCHL$> 不独立导入
                    var schlDate = ParseSchlDate(line.Text);
                    if (schlDate == DateTime.MinValue || schlDate.Date != diary.Date) continue;
                    AddMetaLeaf(allLines, logSectionGUID, line.Text, lOrder++);
                }
            }
        }

        private OutlineLine AddMetaSection(List<OutlineLine> allLines, string parentGUID, string text,
            int ordering, bool expanded, bool allowAddChild, string formatRegex, string formatHint)
        {
            var line = new OutlineLine
            {
                Text = text,
                Level = 1,
                ParentGUID = parentGUID,
                IsMetaNode = true,
                IsMetaSectionHeader = true,
                AllowAddChild = allowAddChild,
                EditFormatRegex = formatRegex,
                EditFormatHint = formatHint,
                Expanded = expanded,
                Ordering = ordering
            };
            allLines.Add(line);
            return line;
        }

        private OutlineLine AddMetaLeaf(List<OutlineLine> allLines, string parentGUID, string text, int ordering)
        {
            var line = new OutlineLine
            {
                Text = text,
                Level = 2,
                ParentGUID = parentGUID,
                IsMetaNode = true,
                IsMetaSectionHeader = false,
                AllowAddChild = false,
                Expanded = true,
                Ordering = ordering
            };
            allLines.Add(line);
            return line;
        }

        /// <summary>解析 Meta 节点内容，回写 lstNoteColor / literature 等数据</summary>
        private void ParseMetaNode()
        {
            var allLines = richTreeView.GetAllLines();
            var metaRoot = allLines.Find(l => l.IsMetaSectionHeader && l.Level == 0);
            if (metaRoot == null) return;

            // 找到各 Section
            var sections = allLines.Where(l => l.IsMetaSectionHeader && l.Level == 1 && l.ParentGUID == metaRoot.GUID)
                .OrderBy(l => l.Ordering).ToList();

            lstNoteColor.Clear();

            foreach (var section in sections)
            {
                var children = allLines.Where(l => l.ParentGUID == section.GUID && !l.IsMetaSectionHeader)
                    .OrderBy(l => l.Ordering).ToList();

                switch (section.Text)
                {
                    case "Label color":
                        foreach (var child in children)
                        {
                            var ci = child.Text.IndexOf(": ");
                            if (ci > 0)
                            {
                                string kw = child.Text.Substring(0, ci).Trim();
                                string color = child.Text.Substring(ci + 2).Trim();
                                if (kw.Length > 0 && color.Length > 0)
                                {
                                    lstNoteColor.Add(new RNoteColor { GUID = GUID, Keyword = kw, Color = color });
                                    child.LabelKeywords = new List<string> { kw };
                                }
                            }
                        }
                        break;

                    case "Publisher":
                        if (noteType == ENoteType.Literature)
                        {
                            foreach (var child in children)
                            {
                                string t = child.Text.Trim();
                                if (t.StartsWith("Title:")) literature.Title = t.Substring(6).Trim();
                                else if (t.StartsWith("Year:")) int.TryParse(t.Substring(5).Trim(), out literature.PublishYear);
                                else if (t.StartsWith("Journal:")) literature.JournalOrConferenceName = t.Substring(8).Trim();
                            }
                        }
                        break;

                    case "Authorship":
                        if (noteType == ENoteType.Literature)
                        {
                            lstLiteratureAuthor.Clear();
                            int authOrder = 0;
                            foreach (var child in children)
                            {
                                if (child.Text.StartsWith("Author: "))
                                    lstLiteratureAuthor.Add(new RLiteratureAuthor { Title = literature.Title, Author = child.Text.Substring(8).Trim(), Ordering = authOrder++ });
                            }
                        }
                        break;

                    case "Tag":
                        if (noteType == ENoteType.Literature)
                        {
                            lstLiteratureTag.Clear();
                            foreach (var child in children)
                            {
                                if (child.Text.StartsWith("Tag: "))
                                    lstLiteratureTag.Add(new RLiteratureTag { Title = literature.Title, Tag = child.Text.Substring(5).Trim() });
                            }
                        }
                        break;

                    case "Reference":
                        // 保存 Reference 子节点内容，供 BuildMetaNode 恢复
                        lstReferenceLinks.Clear();
                        foreach (var child in children)
                            lstReferenceLinks.Add(child.Text);
                        break;

                    case "Log":
                        if (noteType == ENoteType.DailyReport)
                        {
                            diary.Schedules.Clear();
                            foreach (var child in children)
                            {
                                string t = child.Text.Trim();
                                var entry = TextToSchedule(t);
                                if (entry != null)
                                    diary.Schedules.Add(entry);
                            }
                        }
                        break;

                    }

                }

            // 更新颜色映射和侧栏，同时刷新正文中所有 [label] 标签
            richTreeView.RebuildAllContentLabels();
            if (noteType == ENoteType.Literature)
                LoadLiteratureToSidePanel();
            BuildMetaNode();
        }

        private void CreateNewLiterature()
        {
            string strTitle = Interaction.InputBox("Input literature title", "Add Literature", "(New Literature)", 300, 300);
            if (string.IsNullOrEmpty(strTitle)) return;
            if (G.glb.lstLiterature.Exists(o => o.Title == strTitle))
            {
                MessageBox.Show("Literature exists, please check!");
                return;
            }
            LiteratureDocument newLit = new LiteratureDocument
            {
                Topic = strTitle,
                GUID = Guid.NewGuid().ToString(),
                Created = DateTime.Today,
                Modified = DateTime.Today,
                Star = false,
                JournalOrConferenceName = "",
                PublishYear = 9999,
            };
            G.glb.lstLiterature.Add(newLit);

            var frmInfoNote = new frmInfoNoteV2(newLit);
            frmInfoNote.FormClosed += (s, e) => M.notesOpened.Remove(frmInfoNote);
            M.notesOpened.Add(frmInfoNote);
            frmInfoNote.Show();
        }

        private void CreateNewLiteratureReview()
        {
            string topic = Interaction.InputBox("New Literature Review topic:", "New Literature Review",
                "(New Literature Review)", 300, 300);
            if (string.IsNullOrEmpty(topic)) return;

            var newReview = new LiteratureReviewDocument
            {
                Topic = topic,
                GUID = Guid.NewGuid().ToString(),
                Created = DateTime.Today,
                Modified = DateTime.Today,
                Colors = new List<RNoteColor>(),
                Lines = new List<OutlineLine>(),
            };
            G.glb.lstLiteratureReview.Add(newReview);

            string filePath = MarkdownNoteConverter.MakeLiteratureReviewPath(newReview.Created, newReview.Topic);
            newReview.Save(filePath);
            DataStore.SaveLiteratureReviewIndex();
            DataStore.RebuildLiteratureReviewList();

            var f = new frmInfoNoteV2(newReview);
            f.FormClosed += (s, e) => M.notesOpened.Remove(f);
            M.notesOpened.Add(f);
            f.Show();
        }
        #endregion


        /// <summary>右侧面板右键 → 打开 Literature Note</summary>
        private void OnSidePanelRightClicked(OutlineLine line, Point loc)
        {
            if (line.MetaType == NodeMetaType.Literature)
            {
                var cms = new ContextMenuStrip();
                var tsmOpen = new ToolStripMenuItem("Open Literature Note");
                string title = line.MetaValue ?? line.Text.Replace("$LITR$>", "");
                tsmOpen.Click += (s, e) => OpenLiterature(title);
                cms.Items.Add(tsmOpen);
                cms.Show(outlineSidePanel, outlineSidePanel.PointToClient(Control.MousePosition));
            }
        }

        #region 文献资料 Stubs（LiteratureDocument 构造函数引用）
        private void LoadLiteratureToSidePanel()
        {
            if (noteType == ENoteType.LiteratureReview)
            {
                RefreshReviewPanel();
            }
        }

        private void LoadLiteratureReviewToSidePanel()
        {
            if (noteType == ENoteType.LiteratureReview && !splitMain.Panel2Collapsed)
            {
                RefreshReviewPanel();
            }
        }

        private void BindLiteratureEvents() { }
        #endregion

        #region LiteratureReview 方法
        private void BuildLiteratureReviewList()
        {
            var allLines = new List<OutlineLine>();
            int order = 0;
            foreach (var rev in G.glb.lstLiteratureReview.OrderBy(r => r.Created).ThenBy(r => r.Topic))
            {
                string dateStr = rev.Created.ToString("yyyy.MM.dd");
                allLines.Add(new OutlineLine
                {
                    Level = 0, ParentGUID = "", GUID = rev.GUID,
                    Text = $"$LREV$>{dateStr}@{rev.Topic}",
                    MetaType = NodeMetaType.LiteratureReview,
                    MetaValue = $"{dateStr}@{rev.Topic}",
                    IsMetaNode = true,
                    Ordering = order++,
                });
            }
            richTreeView.LoadLines(allLines);
            richTreeView.RootTitle = "Literature Review";
        }

        private void RefreshReviewPanel()
        {
            if (noteType != ENoteType.LiteratureReview || splitMain.Panel2Collapsed) return;

            // Collect selected tags (☑ $LTAG$>)
            var selectedTags = new HashSet<string>();
            foreach (var line in _lines)
            {
                if (line.Text.StartsWith("☑ $LTAG$>"))
                {
                    string tag = line.Text.Substring(9).Trim(); // after "☑ $LTAG$>"
                    selectedTags.Add(tag);
                }
            }

            var allLines = new List<OutlineLine>();

            if (selectedTags.Count == 0)
            {
                allLines.Add(new OutlineLine { Level = 0, Text = "Select $LTAG$> tags to filter", GUID = Guid.NewGuid().ToString() });
            }
            else
            {
                int order = 1;
                var matched = G.glb.lstLiterature
                    .Where(lit => lit.Tags.Any(t => selectedTags.Contains(t.Tag)))
                    .OrderBy(l => l.Title)
                    .ToList();

                foreach (var lit in matched)
                {
                    var litGUID = lit.GUID;
                    allLines.Add(new OutlineLine
                    {
                        Level = 0, GUID = litGUID,
                        Text = $"$LITR$>{lit.Title}",
                        MetaType = NodeMetaType.Literature,
                        MetaValue = lit.Title,
                        IsMetaNode = true,
                        Ordering = order++,
                    });
                    if (!string.IsNullOrEmpty(lit.Year))
                        allLines.Add(new OutlineLine { Level = 1, ParentGUID = litGUID, Text = "Year: " + lit.Year, Ordering = order++, MetaType = NodeMetaType.None });
                    if (!string.IsNullOrEmpty(lit.JournalOrConferenceName))
                        allLines.Add(new OutlineLine { Level = 1, ParentGUID = litGUID, Text = lit.JournalOrConferenceName, Ordering = order++, MetaType = NodeMetaType.None });
                    if (lit.Authors.Count > 0)
                        allLines.Add(new OutlineLine { Level = 1, ParentGUID = litGUID, Text = string.Join(", ", lit.Authors.Select(a => a.Author)), Ordering = order++, MetaType = NodeMetaType.None });
                }
            }

            if (outlineSidePanel != null) outlineSidePanel.LoadLines(allLines);
        }

        private void SaveLiteratureReview()
        {
            if (literatureReview == null) return;
            literatureReview.Lines = richTreeView.GetAllLines().Where(l => !l.IsMetaNode || l.MetaType == NodeMetaType.LiteratureTag).ToList();
            literatureReview.Modified = DateTime.Now;
            string filePath = MarkdownNoteConverter.MakeLiteratureReviewPath(literatureReview.Created, literatureReview.Topic);
            literatureReview.Save(filePath);
            DataStore.SaveLiteratureReviewIndex();
            DataStore.RebuildLiteratureReviewList();
        }

        private void OpenLiteratureReview(string guid)
        {
            var rev = G.glb.lstLiteratureReview.Find(r => r.GUID == guid);
            if (rev == null) { MessageBox.Show("Literature Review not found"); return; }
            var f = new frmInfoNoteV2(rev);
            M.notesOpened.Add(f);
            f.Show();
        }

        private void OpenLiterature(string title)
        {
            var lit = G.glb.lstLiterature.Find(l => l.Title == title);
            if (lit == null) { MessageBox.Show("Literature not found"); return; }
            var f = new frmInfoNoteV2(lit);
            M.notesOpened.Add(f);
            f.Show();
        }
        #endregion

        #region 按钮事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            LogDebug($"[btnSave_Click] noteType={noteType}");
            if (noteType == ENoteType.Note || noteType == ENoteType.DailyReport)
                SaveNote();
            if (noteType == ENoteType.Literature)
            {
                SaveLiterature();
                SaveNote();
                try { RefreshTab?.Invoke(); } catch { }
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            var lines = richTreeView.OutlinePanel.GetVisibleLines();
            string txtFile = RootText.Replace(":", "-");
            using (StreamWriter file = new StreamWriter(txtFile + ".txt", false))
            {
                foreach (var line in lines)
                {
                    string indent = new string('\t', line.Level);
                    file.WriteLine(indent + line.Text);
                }
                MessageBox.Show("Write notes to " + txtFile + ".txt");
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Multiselect = false,
                Title = "Please select a .txt file.",
                Filter = "Text files (*.txt)|*.txt"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            string[] logList = File.ReadAllLines(ofd.FileName);
            if (logList.Length == 0) { MessageBox.Show("Empty .txt file."); return; }

            string rootText = noteType == ENoteType.Note ? note.Topic
                : noteType == ENoteType.Literature ? literature.Title : "Daily Report";
            if (logList[0].TrimStart('\t') != rootText)
            { MessageBox.Show("Does not match with title"); return; }
            if (logList.Length <= 1) return;

            var newLines = ParseTabbedLines(logList);
            richTreeView.LoadLines(newLines);
            richTreeView.IsDirty = true;
        }

        private List<OutlineLine> ParseTabbedLines(string[] logList)
        {
            var result = new List<OutlineLine>();
            var stack = new Stack<(OutlineLine line, int level)>();

            for (int i = 0; i < logList.Length; i++)
            {
                string raw = logList[i];
                int level = 0;
                while (level < raw.Length && raw[level] == '\t') level++;
                string text = raw.Substring(level).Trim();

                if (i == 0) continue; // skip root title line

                var line = new OutlineLine { Text = text, Level = level };

                // Find parent node
                while (stack.Count > 0 && stack.Peek().level >= level)
                    stack.Pop();

                if (stack.Count > 0)
                    line.ParentGUID = stack.Peek().line.GUID;
                else
                    line.ParentGUID = "";

                line.Ordering = result.Count(l => l.ParentGUID == line.ParentGUID);
                result.Add(line);
                stack.Push((line, level));
            }
            return result;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string search = txtSearch.Text.ToUpper();
            if (string.IsNullOrEmpty(search)) return;

            // 收集匹配的 Note 和 Literature
            var notes = G.glb.lstNote.FindAll(o => o.Topic.ToUpper().Contains(search));
            var lits = G.glb.lstLiterature.FindAll(o => o.Title.ToUpper().Contains(search));
            var totalMatches = notes.Count + lits.Count;
            if (totalMatches == 0) return;

            // 精确匹配（Topic/Title 完全等于搜索词）
            var exactNotes = notes.Where(o => o.Topic.ToUpper() == search).ToList();
            var exactLits = lits.Where(o => o.Title.ToUpper() == search).ToList();
            int exactCount = exactNotes.Count + exactLits.Count;

            // 唯一精确匹配 → 直接打开
            if (exactCount == 1 && totalMatches == 1)
            {
                if (exactNotes.Count == 1)
                {
                    var n = exactNotes[0];
                    OpenNoteForm(n);
                }
                else
                {
                    var lit = exactLits[0];
                    if (M.NoteExists(lit.GUID))
                    { M.FindNoteForm(lit.GUID).Show(); M.FindNoteForm(lit.GUID).BringToFront(); }
                    else { var f = new frmInfoNoteV2(lit); f.Show(); M.notesOpened.Add(f); }
                }
                return;
            }

            // 多个匹配 → 显示搜索结果临时窗口
            ShowSearchResults(search, notes, lits);
        }

        /// <summary>打开或激活指定 Note 的窗口</summary>
        private void OpenNoteForm(NoteDocument n)
        {
            if (M.NoteExists(n.GUID))
            { M.FindNoteForm(n.GUID).Show(); M.FindNoteForm(n.GUID).BringToFront(); }
            else { var f = new frmInfoNoteV2(n); f.Show(); M.notesOpened.Add(f); }
        }

        /// <summary>创建临时只读的搜索结果窗口，按年-月-日分组显示匹配的 Note/Literature</summary>
        private void ShowSearchResults(string searchUpper, List<NoteDocument> notes, List<LiteratureDocument> lits)
        {
            var treeLines = BuildSearchResultTree(searchUpper, notes, lits);

            var f = new frmInfoNoteV2(0);
            f.isSearchResult = true;
            f.note = new NoteDocument { Topic = "Search: " + searchUpper, GUID = Guid.NewGuid().ToString(), Created = DateTime.Now };
            f.GUID = f.note.GUID;
            f.noteType = ENoteType.Note;
            f.sysNoteType = ESysNoteType.None;
            f.isSysNote = false;
            f.isSysDiary = false;
            f.lstNoteLog = new List<OutlineLine>();
            f.lstNoteColor = new List<RNoteColor>();

            f.InitCommon("LifeGame - Search Results");
            f.splitMain.Panel2Collapsed = true;
            f.richTreeView.IsReadOnly = true;
            f.richTreeView.IconDisplayMode = true;
            f.richTreeView.LoadLines(treeLines);
            f.richTreeView.RootTitle = "Search Results: \"" + searchUpper + "\"";
            f.Text = "LifeGame - Search Results";
            f.Show();
            M.notesOpened.Add(f);
        }

        /// <summary>构建搜索结果树：年 → 月 → $NOTE$> / $LITR$> 节点</summary>
        private List<OutlineLine> BuildSearchResultTree(string searchUpper, List<NoteDocument> notes, List<LiteratureDocument> lits)
        {
            var treeLines = new List<OutlineLine>();
            int order = 0;

            // 收集所有带日期的条目来分组（Item1=date, Item2=label, Item3=metaType, Item4=metaValue）
            var entries = new List<(DateTime, string, string, string)>();

            foreach (var n in notes)
            {
                var dt = n.Created.Date;
                string dateStr = dt.ToString("yyyy.MM.dd");
                entries.Add((dt, "$NOTE$>" + dateStr + "@" + n.Topic, "NoteRef", dateStr + "@" + n.Topic));
            }
            foreach (var lit in lits)
            {
                var dt = lit.Created.Date;
                entries.Add((dt, "$LITR$>" + lit.Title, "Literature", lit.Title));
            }

            // 按年 → 月分组
            var yearGroups = entries
                .GroupBy(e => e.Item1.Year)
                .OrderByDescending(g => g.Key);

            foreach (var yearGroup in yearGroups)
            {
                string yearGUID = "SRC_YEAR_" + order;
                treeLines.Add(new OutlineLine
                {
                    Level = 0, ParentGUID = "", GUID = yearGUID,
                    Text = yearGroup.Key.ToString(),
                    Ordering = order++, Expanded = true,
                });

                var monthGroups = yearGroup
                    .GroupBy(e => e.Item1.Month)
                    .OrderByDescending(g => g.Key);

                foreach (var monthGroup in monthGroups)
                {
                    string monthGUID = "SRC_MONTH_" + order;
                    treeLines.Add(new OutlineLine
                    {
                        Level = 1, ParentGUID = yearGUID, GUID = monthGUID,
                        Text = new DateTime(2000, monthGroup.Key, 1).ToString("MMMM"),
                        Ordering = order++, Expanded = true,
                    });

                    foreach (var entry in monthGroup.OrderByDescending(e => e.Item1))
                    {
                        string entryGUID = "SRC_ENTRY_" + order;
                        var line = new OutlineLine
                        {
                            Level = 2, ParentGUID = monthGUID, GUID = entryGUID,
                            Text = entry.Item2,
                            MetaType = entry.Item3 == "NoteRef" ? NodeMetaType.NoteRef : NodeMetaType.Literature,
                            MetaValue = entry.Item4,
                            Ordering = order++, Expanded = false,
                        };
                        treeLines.Add(line);
                    }
                }
            }

            return treeLines;
        }

        private void frmInfoNoteV2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 搜索结果临时窗口 — 不保存，直接释放
            if (isSearchResult)
            {
                M.RemoveNoteForm(GUID);
                return;
            }

            LogDebug($"[FormClosing] GUID={GUID}, noteType={noteType}, Topic={note?.Topic}");
            // 始终保存，不依赖 IsDirty（其追踪不完整）
            btnSave_Click(sender, e);
            M.RemoveNoteForm(GUID);
        }
        #endregion

        private static void LogDebug(string msg)
        {
            try
            {
                string logPath = "data\\logs\\save_debug.log";
                string dir = System.IO.Path.GetDirectoryName(logPath);
                if (!string.IsNullOrEmpty(dir)) System.IO.Directory.CreateDirectory(dir);
                System.IO.File.AppendAllText(logPath,
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {msg}{Environment.NewLine}",
                    System.Text.Encoding.UTF8);
            }
            catch { }
        }
    }
}
