using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace LifeGame
{
    public partial class frmLauncher : frmNoteBase
    {
        #region Constants
        private const string MenuNoteTopic = "SysNote: Menu";
        private const string SysNoteTDLName = "SysNote: Calendar";
        private const string SysNoteDiaryName = "SysNote: Diary";
        private const string SysNoteNoteName = "SysNote: Note Archive";
        private const string SysNoteArchiveName = "SysNote: Task History";
        private const string SysNoteLiteratureReviewName = "SysNote: Literature Review";
        #endregion

        #region Fields
        private string menuGUID;
        private List<OutlineLine> _lines = new List<OutlineLine>();
        private List<RNoteColor> lstMenuNoteColor = new List<RNoteColor>();
        private ContextMenuStrip cmsNote;
        private NotifyIcon trayIcon;
        private bool _isExiting;
        #endregion

        public frmLauncher()
        {
            // 从 data/sysnotes/ 加载 Menu（固定路径，无日期问题）
            string menuPath = MarkdownNoteConverter.MakeSysNotePath(MenuNoteTopic);
            if (!File.Exists(menuPath))
            {
                CreateSysNoteFile(menuPath, MenuNoteTopic);
            }
            var mdData = GameDocument.Load(menuPath) as NoteDocument;
            if (mdData != null)
            {
                menuGUID = mdData.GUID;
                _lines = mdData.Lines;
                lstMenuNoteColor = mdData.Colors;
            }

            InitializeUI();
            LoadMenuContent();
            BuildMenuContextMenu();
            SetupTray();
        }

        #region UI Creation
        private void InitializeUI()
        {
            InitializeBaseUI();
            splitMain.Panel2Collapsed = true;

            this.ClientSize = new Size(480, 640);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ShowInTaskbar = true;
            this.Text = "LifeGame";

            if (Theme.Current == null)
                this.BackColor = Color.FromArgb(245, 242, 235);

            RebuildTopPanel();
            LoadIconsFromDisk();

            // === RichTreeView 配置 ===
            richTreeView.AllowEditNonMeta = true;
            richTreeView.BlockMetaEdit = true;
            richTreeView.SysNoteType = ESysNoteType.Menu;
            richTreeView.SysNoteTopic = MenuNoteTopic;
            richTreeView.NoteColors = lstMenuNoteColor;
            richTreeView.Initialize();
            richTreeView.ContentModified += () => { };

            // 订阅右键菜单
            richTreeView.OutlinePanel.LineRightClicked += (line, loc) =>
            {
                if (cmsNote == null) return;
                cmsNote.Items.Clear();

                if (line.IsMetaNode && (line.MetaType == NodeMetaType.NoteRef || line.MetaType == NodeMetaType.FuncRef))
                {
                    var topic = line.MetaValue ?? "";
                    if (topic == SysNoteDiaryName)
                        AddCMItem("Open Today's Diary", () => BeginInvoke(new Action(() => OpenDiary(DateTime.Today))));
                    else if (topic == SysNoteLiteratureReviewName)
                        AddCMItem("Open Literature Review", () => BeginInvoke(new Action(() => OpenLiteratureReviewList())));
                    else
                        AddCMItem("Open " + line.Text.Replace("$FUNC$>", "").Replace("$NOTE$>", ""),
                            () => BeginInvoke(new Action(() => OpenSysNote(topic))));
                }
                else if (!line.IsMetaNode && !line.IsMetaSectionHeader)
                {
                    PopulateContentContextItems();
                }

                cmsNote.Show(richTreeView.OutlinePanel,
                    richTreeView.OutlinePanel.PointToClient(Cursor.Position));
            };

            // 订阅导航事件
            richTreeView.OpenNoteByGUID += (guid) => BeginInvoke(new Action(() =>
            {
                var note = G.glb.lstNote.Find(o => o.GUID == guid);
                if (note == null) return;
                if (M.NoteExists(guid))
                {
                    M.FindNoteForm(guid).Show();
                    M.FindNoteForm(guid).BringToFront();
                }
                else
                {
                    var f = new frmInfoNoteV2(note);
                    M.notesOpened.Add(f);
                    f.Show();
                }
            }));
            richTreeView.OpenDiary += (date) => BeginInvoke(new Action(() => OpenDiary(date)));
            richTreeView.OpenLiteratureReviewByGUID += (guid) => BeginInvoke(new Action(() =>
            {
                if (guid == "__LIST__") OpenLiteratureReviewList();
            }));
        }

        protected override void RebuildTopPanel()
        {
            topPanel.Controls.Clear();
            topPanel.Height = 38;
            topPanel.Padding = new Padding(8, 4, 8, 4);

            if (Theme.Current != null)
                topPanel.BackColor = Theme.Current.TopBarBg;
            else
                topPanel.BackColor = Color.FromArgb(245, 246, 250);

            toolbarTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            toolbarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62));
            toolbarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            toolbarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 48));
            toolbarTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // 列 0：设置按钮
            var btnSettings = new Button
            {
                Text = "设置 ▾",
                Size = new Size(58, 28),
                Font = new Font("Segoe UI", 8.5F),
                Anchor = AnchorStyles.Left,
            };
            if (Theme.Current != null)
            {
                StyleButton(btnSettings, Theme.Current.ButtonSecondaryBg, Theme.Current.ButtonSecondaryFg);
                btnSettings.FlatAppearance.BorderColor = Theme.Current.Border;
            }
            btnSettings.Click += OnSettingsClick;
            toolbarTable.Controls.Add(btnSettings, 0, 0);

            // 列 1：搜索框
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Margin = new Padding(6, 0, 6, 0);
            toolbarTable.Controls.Add(txtSearch, 1, 0);

            // 列 2：搜索按钮
            btnSearch.Margin = new Padding(0);
            btnSearch.Click += btnSearch_Click;
            toolbarTable.Controls.Add(btnSearch, 2, 0);

            topPanel.Controls.Add(toolbarTable);

            // 在搜索框左侧添加创建按钮
            AddCreationButtons(
                (s, e) => CreateNewNote(),
                (s, e) => CreateNewLiterature(),
                (s, e) => CreateNewLiteratureReview());
        }
        #endregion

        #region Menu Content
        private void LoadMenuContent()
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

            AddMenuMetaLine(allLines, ref order, "MENU_CAL", "$FUNC$>" + SysNoteTDLName, SysNoteTDLName, funcGUID);
            AddMenuMetaLine(allLines, ref order, "MENU_DIARY", "$FUNC$>" + SysNoteDiaryName, SysNoteDiaryName, funcGUID);

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

            AddMenuMetaLine(allLines, ref order, "MENU_ARC", "$FUNC$>" + SysNoteArchiveName, SysNoteArchiveName, idxGUID);
            AddMenuMetaLine(allLines, ref order, "MENU_NOTES", "$FUNC$>" + SysNoteNoteName, SysNoteNoteName, idxGUID);
            AddMenuMetaLine(allLines, ref order, "MENU_LREV", "$FUNC$>" + SysNoteLiteratureReviewName, SysNoteLiteratureReviewName, idxGUID);

            // ========== Notes 分区（用户自定义，来自 .md body） ==========
            const string notesGUID = "MENU_NOTES_SECTION";
            var notesHeader = new OutlineLine
            {
                Text = "Notes",
                Level = 0, ParentGUID = "", GUID = notesGUID,
                IsMetaNode = true, IsMetaSectionHeader = true,
                AllowAddChild = false, Expanded = true,
                Ordering = order++,
            };
            allLines.Add(notesHeader);

            int contentOrder = order;
            if (_lines.Count > 0)
            {
                // 已知的 RootTitle 残留（历史 bug 导致的污染），跳过
                var knownRootTitles = new HashSet<string> { "LifeGame Menu", "(Root)" };
                // 收集 _lines 中的有效 GUID（ParseBody 已移除标题行，其 GUID 不在集合中）
                var validGUIDs = new HashSet<string>(_lines.Where(l => !knownRootTitles.Contains(l.Text ?? "")).Select(l => l.GUID));
                foreach (var line in _lines)
                {
                    if (knownRootTitles.Contains(line.Text ?? "")) continue;
                    // 只修复孤儿子节点（父节点是已被 ParseBody 移除的标题行）
                    if (string.IsNullOrEmpty(line.ParentGUID) || !validGUIDs.Contains(line.ParentGUID))
                        line.ParentGUID = notesGUID;
                    line.Ordering = contentOrder++;
                    allLines.Add(line);
                }
            }
            if (contentOrder == order)
            {
                // 没有用户内容时显示欢迎占位
                allLines.Add(new OutlineLine
                {
                    Level = 1, ParentGUID = notesGUID, GUID = "MENU_DEFAULT",
                    Text = "Welcome to LifeGame!", Ordering = contentOrder++,
                });
            }

            richTreeView.LoadLines(allLines);
            richTreeView.RootTitle = "LifeGame Menu";
            richTreeView.RefreshLayout();
        }

        private void AddMenuMetaLine(List<OutlineLine> lines, ref int order, string guid,
            string displayText, string sysNoteTopic, string parentGUID)
        {
            lines.Add(new OutlineLine
            {
                Level = 1, ParentGUID = parentGUID, GUID = guid,
                Text = displayText,
                MetaType = NodeMetaType.FuncRef,
                MetaValue = sysNoteTopic,
                IsMetaNode = true,
                Ordering = order++,
            });
        }
        #endregion

        #region Context Menu
        private void BuildMenuContextMenu()
        {
            cmsNote = new ContextMenuStrip();
        }

        private ToolStripMenuItem AddCMItem(string text, Action handler)
        {
            var item = new ToolStripMenuItem(text);
            item.Click += (s, e) => handler();
            cmsNote.Items.Add(item);
            return item;
        }

        private void PopulateContentContextItems()
        {
            cmsNote.Items.Add(AddCMItem("跳转 (&G)", () => richTreeView.HandleGoto()));
            cmsNote.Items.Add(new ToolStripSeparator());
            cmsNote.Items.Add(AddCMItem("添加子节点 (&A)", () => {
                var sel = richTreeView.OutlinePanel.GetSelectedLines().FirstOrDefault();
                if (sel != null) richTreeView.OutlinePanel.AddLineInPlace("New node", sel);
            }));
            cmsNote.Items.Add(new ToolStripSeparator());
            cmsNote.Items.Add(AddCMItem("折叠 (&N)", () => {
                foreach (var l in richTreeView.OutlinePanel.GetSelectedLines())
                    if (l.Expanded) richTreeView.OutlinePanel.ExpandCollapseInPlace(l);
            }));
            cmsNote.Items.Add(AddCMItem("展开 (&M)", () => {
                foreach (var l in richTreeView.OutlinePanel.GetSelectedLines())
                    if (!l.Expanded) richTreeView.OutlinePanel.ExpandCollapseInPlace(l);
            }));
            cmsNote.Items.Add(new ToolStripSeparator());
            cmsNote.Items.Add(AddCMItem("右移 (&J)", () => richTreeView.OutlinePanel.IndentSelected()));
            cmsNote.Items.Add(AddCMItem("左移 (&L)", () => richTreeView.OutlinePanel.UnindentSelected()));
            cmsNote.Items.Add(new ToolStripSeparator());
            cmsNote.Items.Add(AddCMItem("上移 (&I)", () => richTreeView.OutlinePanel.MoveUpSelected()));
            cmsNote.Items.Add(AddCMItem("下移 (&K)", () => richTreeView.OutlinePanel.MoveDownSelected()));
            cmsNote.Items.Add(new ToolStripSeparator());
            cmsNote.Items.Add(AddCMItem("复制 (&C)", () => richTreeView.CopySelected()));
            cmsNote.Items.Add(AddCMItem("复制跳转 (&X)", () => richTreeView.CopyJumpNode()));
            cmsNote.Items.Add(AddCMItem("粘贴 (&V)", () => richTreeView.PasteCopied()));
            cmsNote.Items.Add(new ToolStripSeparator());
            cmsNote.Items.Add(AddCMItem("删除 (&D)", () => richTreeView.DeleteSelected()));
        }
        #endregion

        #region Save
        private void SaveMenuContent()
        {
            var allLines = richTreeView.GetAllLines();
            var contentLines = allLines
                .Where(l => !l.IsMetaNode && !l.IsMetaSectionHeader && l.GUID != "MENU_DEFAULT" && l.GUID != "__ROOT__")
                .ToList();

            // 直接写入 data/sysnotes/SYSN_Menu.md（固定路径）
            string menuPath = MarkdownNoteConverter.MakeSysNotePath(MenuNoteTopic);
            string yaml = BuildNoteYaml(menuGUID, MenuNoteTopic, DateTime.Today, DateTime.Now, lstMenuNoteColor);
            string body = MarkdownNoteConverter.BuildOutlineBodyWithTitle(MenuNoteTopic, contentLines);
            WriteSysNoteFile(menuPath, yaml, body);
        }
        #endregion

        #region Tray
        private void SetupTray()
        {
            trayIcon = new NotifyIcon
            {
                Text = "LifeGame",
                Visible = false,
                Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath),
            };
            trayIcon.DoubleClick += (s, e) =>
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                trayIcon.Visible = false;
            };

            var trayMenu = new ContextMenuStrip();
            var mnuShow = new ToolStripMenuItem("Show");
            mnuShow.Click += (s, e) =>
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                trayIcon.Visible = false;
            };
            trayMenu.Items.Add(mnuShow);
            var mnuExit = new ToolStripMenuItem("Exit");
            mnuExit.Click += (s, e) => { _isExiting = true; trayIcon.Visible = false; SaveMenuContent(); Application.Exit(); };
            trayMenu.Items.Add(mnuExit);
            trayIcon.ContextMenuStrip = trayMenu;

            this.Resize += (s, e) =>
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    trayIcon.Visible = true;
                    this.ShowInTaskbar = false;
                }
                else
                {
                    trayIcon.Visible = false;
                    this.ShowInTaskbar = true;
                }
            };

            this.FormClosing += (s, e) =>
            {
                if (_isExiting)
                {
                    SaveMenuContent();
                    trayIcon.Visible = false;
                    return;
                }
                // 关闭时弹框让用户选择
                var result = MessageBox.Show(
                    "关闭窗口，请选择：\n\n是(Y) - 最小化到托盘\n否(N) - 退出应用\n取消 - 返回窗口",
                    "LifeGame", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = true;
                    this.WindowState = FormWindowState.Minimized;
                }
                else if (result == DialogResult.No)
                {
                    _isExiting = true;
                    SaveMenuContent();
                    trayIcon.Visible = false;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            };
        }
        #endregion

        #region SysNote Navigation
        // Index SysNotes: auto-generated, not persisted
        private static readonly HashSet<string> _indexSysNotes = new HashSet<string>
        {
            SysNoteArchiveName, SysNoteNoteName, SysNoteLiteratureReviewName
        };

        private void OpenSysNote(string topic)
        {
            // Literature Review 索引打开专用的列表视图
            if (topic == SysNoteLiteratureReviewName)
            {
                OpenLiteratureReviewList();
                return;
            }

            NoteDocument sysNote;
            if (_indexSysNotes.Contains(topic))
            {
                // 索引型 SysNote：每次打开时临时生成，不查找也不保存到 lstNote
                sysNote = new NoteDocument
                {
                    GUID = Guid.NewGuid().ToString(),
                    Topic = topic,
                    Created = DateTime.Today,
                    Modified = DateTime.Today,
                };
            }
            else
            {
                // 持久化 SysNote：从 data/sysnotes/ 加载
                string sysPath = MarkdownNoteConverter.MakeSysNotePath(topic);
                if (!File.Exists(sysPath))
                    CreateSysNoteFile(sysPath, topic);
                var md = GameDocument.Load(sysPath) as NoteDocument;
                if (md != null)
                {
                    sysNote = md;
                }
                else
                {
                    sysNote = new NoteDocument
                    {
                        GUID = Guid.NewGuid().ToString(),
                        Topic = topic,
                        Created = DateTime.Today,
                        Modified = DateTime.Today,
                    };
                }
            }

            if (M.NoteExists(sysNote.GUID))
            {
                M.FindNoteForm(sysNote.GUID).Show();
                M.FindNoteForm(sysNote.GUID).BringToFront();
            }
            else
            {
                var f = new frmInfoNoteV2(sysNote);
                M.notesOpened.Add(f);
                f.Show();
            }
        }

        private void OpenDiary(DateTime date)
        {
            string sysPath = MarkdownNoteConverter.MakeSysNotePath(SysNoteDiaryName);
            if (!File.Exists(sysPath))
                CreateSysNoteFile(sysPath, SysNoteDiaryName);
            var sysDiaryNote = GameDocument.Load(sysPath) as NoteDocument;

            if (sysDiaryNote != null)
            {
                if (M.NoteExists(sysDiaryNote.GUID))
                {
                    var fExists = (frmInfoNoteV2)M.FindNoteForm(sysDiaryNote.GUID);
                    fExists.SwitchDiaryDate(date);
                    fExists.BringToFront();
                    return;
                }

                var f = new frmInfoNoteV2(sysDiaryNote);
                f.SwitchDiaryDate(date);
                f.Show();
                M.notesOpened.Add(f);
            }
        }

        private void OpenLiteratureReviewList()
        {
            var f = new frmInfoNoteV2(true);
            M.notesOpened.Add(f);
            f.Show();
        }

        private void CreateNewNote()
        {
            string topic = Interaction.InputBox(
                "New Note topic:", "New Note", "(New Note)", 300, 300);
            if (string.IsNullOrEmpty(topic)) return;

            var noteData = new NoteDocument
            {
                GUID = Guid.NewGuid().ToString(),
                Topic = topic,
                Created = DateTime.Today,
                Modified = DateTime.Today,
                Colors = new List<RNoteColor>(),
                Lines = new List<OutlineLine>(),
            };
            G.glb.lstNote.Add(noteData);

            DataStore.SaveNoteIndex();
            noteData.Save(null);

            var f = new frmInfoNoteV2(noteData);
            M.notesOpened.Add(f);
            f.Show();
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
            DataStore.SaveLiteratureIndex();

            var f = new frmInfoNoteV2(newLit);
            f.FormClosed += (s, e) => M.notesOpened.Remove(f);
            M.notesOpened.Add(f);
            f.Show();
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

        /// <summary>确保 data/sysnotes/ 下的 SysNote .md 文件存在（不再经过 _index.json）</summary>
        private static void EnsureSysNote(string topic)
        {
            string path = MarkdownNoteConverter.MakeSysNotePath(topic);
            if (!File.Exists(path))
                CreateSysNoteFile(path, topic);
        }

        private static void CreateSysNoteFile(string path, string topic)
        {
            string guid = Guid.NewGuid().ToString();
            string yaml = BuildNoteYaml(guid, topic, DateTime.Today, DateTime.Today, new List<RNoteColor>());
            string body = topic + "\n";
            WriteSysNoteFile(path, yaml, body);
        }

        private static string BuildNoteYaml(string guid, string topic, DateTime created, DateTime modified, List<RNoteColor> colors)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"guid: \"{guid}\"");
            sb.AppendLine($"topic: \"{EscapeYaml(topic)}\"");
            sb.AppendLine("type: Note");
            sb.AppendLine($"created: \"{created:o}\"");
            sb.AppendLine($"modified: \"{modified:o}\"");
            if (colors != null && colors.Count > 0)
            {
                sb.AppendLine("colors:");
                foreach (var c in colors)
                     sb.AppendLine($"  - keyword: \"{EscapeYaml(c.Keyword)}\"\n    color: \"{EscapeYaml(c.Color)}\"");
            }
            else
            {
                sb.AppendLine("colors: []");
            }
            return sb.ToString();
        }

        private static void WriteSysNoteFile(string path, string yaml, string body)
        {
            string content = "---\n" + yaml + "---\n\n" + body;
            DataFileHelper.AtomicWriteText(path, content);
        }

        private static string EscapeYaml(string s)
        {
            return (s ?? "").Replace("\\", "\\\\").Replace("\"", "\\\"");
        }

        public static void EnsureSysNotesExist()
        {
            EnsureSysNote(MenuNoteTopic);
            EnsureSysNote(SysNoteTDLName);
            EnsureSysNote(SysNoteDiaryName);
        }

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToUpper();
            if (string.IsNullOrEmpty(search)) return;

            var notes = G.glb.lstNote.FindAll(o => o.Topic.ToUpper().Contains(search));
            var lits = G.glb.lstLiterature.FindAll(o => o.Title.ToUpper().Contains(search));
            if (notes.Count == 0 && lits.Count == 0) return;

            var exactNotes = notes.Where(o => o.Topic.ToUpper() == search).ToList();
            var exactLits = lits.Where(o => o.Title.ToUpper() == search).ToList();
            int exactCount = exactNotes.Count + exactLits.Count;
            int totalMatches = notes.Count + lits.Count;

            // 唯一精确匹配 → 直接打开
            if (exactCount == 1 && totalMatches == 1)
            {
                if (exactNotes.Count == 1)
                {
                    var n = exactNotes[0];
                    var fn = new frmInfoNoteV2(n);
                    M.notesOpened.Add(fn);
                    fn.Show();
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

            // 多个匹配 → 创建临时搜索结果窗口
            ShowSearchResults(search, notes, lits);
        }

        private void ShowSearchResults(string searchUpper, List<NoteDocument> notes, List<LiteratureDocument> lits)
        {
            var treeLines = new List<OutlineLine>();
            int order = 0;

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

            var yearGroups = entries.GroupBy(e => e.Item1.Year).OrderByDescending(g => g.Key);
            foreach (var yearGroup in yearGroups)
            {
                string yearGUID = "SRC_YEAR_" + order;
                treeLines.Add(new OutlineLine
                {
                    Level = 0, ParentGUID = "", GUID = yearGUID,
                    Text = yearGroup.Key.ToString(), Ordering = order++, Expanded = true,
                });

                var monthGroups = yearGroup.GroupBy(e => e.Item1.Month).OrderByDescending(g => g.Key);
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
                        string txt = entry.Item2;
                        var metaType = entry.Item3 == "NoteRef" ? NodeMetaType.NoteRef : NodeMetaType.Literature;
                        treeLines.Add(new OutlineLine
                        {
                            Level = 2, ParentGUID = monthGUID, GUID = entryGUID,
                            Text = txt, Ordering = order++, IsMetaNode = true,
                            MetaType = metaType, MetaValue = entry.Item4,
                        });
                    }
                }
            }

            var f = new frmInfoNoteV2();
            f.note = new NoteDocument { Topic = "Search: " + searchUpper, GUID = Guid.NewGuid().ToString(), Created = DateTime.Now };
            f.GUID = f.note.GUID;
            f.noteType = ENoteType.Note;
            f.sysNoteType = ESysNoteType.None;
            f.isSysNote = false;
            f.isSysDiary = false;
            f.lstNoteLog = treeLines;
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLauncher));
            this.SuspendLayout();
            // 
            // frmLauncher
            // 
            this.ClientSize = new System.Drawing.Size(274, 229);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLauncher";
            this.ResumeLayout(false);

        }
    }
}
