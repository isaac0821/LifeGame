using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace LifeGame
{
    /// <summary>
    /// Note 窗体基类 — 提供统一的 UI 骨架：
    /// topPanel(toolbar) + splitMain(Panel1:RichTreeView + Panel2:flexible)
    /// </summary>
    public class frmNoteBase : Form
    {
        #region 共享 UI 控件
        internal SplitContainer splitMain;
        internal RichTreeView richTreeView;
        internal OutlinePanel outlineSidePanel;
        protected Panel topPanel;
        protected TableLayoutPanel toolbarTable;
        protected TextBox txtSearch;
        protected Button btnSearch;
        protected ImageList iglIcon;
        #endregion

        #region 构造函数
        public frmNoteBase()
        {
            this.KeyPreview = true;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                var asm = Assembly.GetExecutingAssembly();
                using (var stream = asm.GetManifestResourceStream("LifeGame.Resources.favicon.ico"))
                {
                    if (stream != null)
                        this.Icon = new Icon(stream);
                }
            }
            catch { }
        }
        #endregion

        #region UI 初始化
        /// <summary>创建 UI 骨架：topPanel、splitMain、richTreeView、outlineSidePanel、iglIcon、搜索控件</summary>
        protected void InitializeBaseUI()
        {
            // === iglIcon ===
            iglIcon = new ImageList { ColorDepth = ColorDepth.Depth32Bit, ImageSize = new Size(23, 17) };
            if (NoteIconProvider.IconList == null)
                NoteIconProvider.IconList = this.iglIcon;

            // === splitMain ===
            splitMain = new SplitContainer { Dock = DockStyle.Fill, FixedPanel = FixedPanel.None };

            // Panel1: RichTreeView
            richTreeView = new RichTreeView { Dock = DockStyle.Fill, IconDisplayMode = true };
            splitMain.Panel1.Controls.Add(richTreeView);

            // Panel2: 默认 outlineSidePanel（子类可替换）
            outlineSidePanel = new OutlinePanel { Dock = DockStyle.Fill };
            splitMain.Panel2.Controls.Add(outlineSidePanel);

            // === topPanel ===
            topPanel = new Panel { Dock = DockStyle.Top, Height = 38, Padding = new Padding(8, 4, 8, 4) };
            topPanel.Paint += (s, e) =>
            {
                var penColor = Theme.Current?.Border ?? Color.FromArgb(225, 218, 205);
                using (var pen = new Pen(penColor, 1))
                    e.Graphics.DrawLine(pen, 0, topPanel.Height - 1, topPanel.Width, topPanel.Height - 1);
            };

            // === 搜索控件 ===
            txtSearch = new TextBox
            {
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                Text = "Search...",
                BorderStyle = BorderStyle.FixedSingle,
            };
            txtSearch.Enter += (s, e) =>
            {
                if (txtSearch.Text == "Search...") { txtSearch.Text = ""; txtSearch.ForeColor = SystemColors.WindowText; }
            };
            txtSearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = "Search..."; txtSearch.ForeColor = Color.Gray; }
            };

            btnSearch = new Button
            {
                Text = "搜索",
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
            };
            btnSearch.FlatAppearance.BorderSize = 0;

            // === 添加到 Form ===
            this.Controls.Add(splitMain);
            this.Controls.Add(topPanel);

            // === 主题 ===
            if (Theme.Current != null)
                this.BackColor = Theme.Current.FormBackground;
            else
                this.BackColor = Color.FromArgb(245, 242, 235);
        }
        #endregion

        #region 顶部工具栏
        /// <summary>默认工具栏布局：[设置] [搜索框] [搜索按钮]（3列弹性布局）</summary>
        protected virtual void RebuildTopPanel()
        {
            topPanel.Controls.Clear();
            topPanel.Height = 38;
            topPanel.Padding = new Padding(8, 4, 8, 4);

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
            toolbarTable.Controls.Add(btnSearch, 2, 0);

            topPanel.Controls.Add(toolbarTable);
        }

        /// <summary>设置按钮点击（子类重写以自定义菜单）</summary>
        protected virtual void OnSettingsClick(object sender, EventArgs e) { }

        /// <summary>在搜索框左侧插入一个额外按钮</summary>
        protected void InsertToolbarButton(Button btn)
        {
            if (toolbarTable == null) return;
            int nextIdx = toolbarTable.ColumnStyles.Count - 2;
            toolbarTable.ColumnCount++;
            toolbarTable.ColumnStyles.Insert(nextIdx, new ColumnStyle(SizeType.Absolute, btn.Width + 8));
            toolbarTable.Controls.Add(btn, nextIdx, 0);
            toolbarTable.SetColumn(txtSearch, nextIdx + 1);
            toolbarTable.SetColumn(btnSearch, nextIdx + 2);
        }

        /// <summary>在搜索框左侧追加 +Note、+Lit、+Review 按钮（从左到右）</summary>
        protected void AddCreationButtons(EventHandler onNote, EventHandler onLit, EventHandler onReview)
        {
            if (toolbarTable == null) return;

            var btnNewNote = new Button
            {
                Text = "+ Note",
                Size = new Size(56, 26),
                Font = new Font("Segoe UI", 8F),
            };
            var btnNewLit = new Button
            {
                Text = "+ Lit",
                Size = new Size(44, 26),
                Font = new Font("Segoe UI", 8F),
            };
            var btnNewReview = new Button
            {
                Text = "+ Review",
                Size = new Size(62, 26),
                Font = new Font("Segoe UI", 8F),
            };

            if (Theme.Current != null)
            {
                StyleButton(btnNewNote, Theme.Current.ButtonPrimaryBg, Theme.Current.ButtonPrimaryFg);
                StyleButton(btnNewLit, Theme.Current.ButtonPrimaryBg, Theme.Current.ButtonPrimaryFg);
                StyleButton(btnNewReview, Theme.Current.ButtonPrimaryBg, Theme.Current.ButtonPrimaryFg);
            }

            btnNewNote.Click += onNote;
            btnNewLit.Click += onLit;
            btnNewReview.Click += onReview;

            // 在搜索框左侧依次追加三列和按钮：Note → Lit → Review
            int col = toolbarTable.ColumnCount - 2; // 搜索框所在列
            foreach (var btn in new[] { btnNewNote, btnNewLit, btnNewReview })
            {
                toolbarTable.ColumnCount++;
                toolbarTable.ColumnStyles.Insert(col, new ColumnStyle(SizeType.Absolute, btn.Width + 8));
                toolbarTable.Controls.Add(btn, col, 0);
                col++;
            }
            // 修正搜索框和搜索按钮的列位置
            toolbarTable.SetColumn(txtSearch, col);
            toolbarTable.SetColumn(btnSearch, col + 1);
        }
        #endregion

        #region 图标加载
        protected void LoadIconsFromDisk()
        {
            try
            {
                var asm = Assembly.GetExecutingAssembly();
                string prefix = "LifeGame.Resources.Note_";
                foreach (string resName in asm.GetManifestResourceNames())
                {
                    if (!resName.StartsWith(prefix)) continue;
                    string key = resName.Substring("LifeGame.Resources.".Length); // "Note_DDL.png"
                    try
                    {
                        using (var stream = asm.GetManifestResourceStream(resName))
                        using (var src = Image.FromStream(stream))
                        {
                            var bmp = new Bitmap(src);
                            iglIcon.Images.Add(key, bmp);
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }
        #endregion

        #region 样式
        protected void StyleButton(Button btn, Color backColor, Color foreColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(
                Math.Min(255, backColor.R + 15),
                Math.Min(255, backColor.G + 15),
                Math.Min(255, backColor.B + 15));
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(
                Math.Max(0, backColor.R - 15),
                Math.Max(0, backColor.G - 15),
                Math.Max(0, backColor.B - 15));
        }

        protected void StyleSearchBox()
        {
            if (Theme.Current == null) return;
            txtSearch.BackColor = Theme.Current.Surface;
            txtSearch.ForeColor = Theme.Current.TextPrimary;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
        }
        #endregion

        #region 主题
        protected virtual void ApplyThemeToForm()
        {
            if (Theme.Current == null) return;
            this.BackColor = Theme.Current.FormBackground;
            if (topPanel != null) topPanel.BackColor = Theme.Current.TopBarBg;
            if (splitMain != null) splitMain.BackColor = Theme.Current.Border;

            StyleSearchBox();
            StyleButton(btnSearch, Theme.Current.ButtonPrimaryBg, Theme.Current.ButtonPrimaryFg);

            topPanel?.Invalidate();

            if (richTreeView?.OutlinePanel != null)
            {
                richTreeView.OutlinePanel.BackColor = Theme.Current.PanelBackground;
                richTreeView.OutlinePanel.ApplyTheme();
            }
            if (outlineSidePanel != null)
            {
                outlineSidePanel.BackColor = Theme.Current.PanelBackground;
                outlineSidePanel.ApplyTheme();
            }
        }
        #endregion

        #region 键盘
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (richTreeView != null && richTreeView.HandleKeyCommand(keyData))
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNoteBase));
            this.SuspendLayout();
            // 
            // frmNoteBase
            // 
            this.ClientSize = new System.Drawing.Size(274, 229);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNoteBase";
            this.ResumeLayout(false);

        }
    }
}
