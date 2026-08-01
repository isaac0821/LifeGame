using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LifeGame
{
    /// <summary>统一侧栏面板</summary>
    public class SidePanel : UserControl
    {
        private TableLayoutPanel mainTable;

        // 标签颜色
        public ListView lsvColor;
        public ContextMenuStrip cmsNoteColor;
        public ToolStripMenuItem tsmAddColor;
        public ToolStripMenuItem tsmRemoveColor;

        // 统计
        private Label lblSelectedLabelCount;
        private Label lblSelectedWordCount;
        private Label lblLabelCount;
        private Label lblLabelWordCount;

        // 文献元数据
        public TextBox txtYear;
        public ComboBox cbxJournalConference;
        public TextBox txtBibKey;
        public CheckBox chkStar;
        public ComboBox cbxBibEntryType;
        public TextBox txtBibRef;
        public ListBox lsbAuthor;
        public ListBox lsbTag;
        public Button btnGoogleScholar;
        public Button btnFullText;
        public Button btnJournal;
        public Button btnBibTeX;

        // 日程
        public PictureBox picToday;
        public Button btnPrevDate;
        public Button btnNextDate;
        public Label lblDate;

        // Meta 编辑
        public ComboBox cbxMetaType;
        public TextBox txtMetaValue;
        public Button btnApplyMeta;

        // 可见性控制
        private ENoteType currentNoteType = ENoteType.Note;

        private static readonly Color AccentColor = Color.FromArgb(0, 120, 215);
        private static readonly Color LightBg = Color.FromArgb(245, 247, 250);
        private static readonly Color BorderColor = Color.FromArgb(220, 225, 230);

        private static readonly Color DefaultPanelBg = Color.FromArgb(250, 251, 253);

        public SidePanel()
        {
            this.DoubleBuffered = true;
            this.Width = 260;
            this.BackColor = Theme.Current?.PanelBackground ?? DefaultPanelBg;
            BuildUI();
        }

        private void BuildUI()
        {
            mainTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                AutoScroll = true,
                Padding = new Padding(6),
                BackColor = (Theme.Current?.PanelBackground) ?? DefaultPanelBg
            };
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            mainTable.Controls.Add(CreateSection("文献信息", BuildLiteratureContent()), 0, 0);
            mainTable.Controls.Add(CreateSection("日程", BuildDailyContent()), 0, 1);

            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            this.Controls.Add(mainTable);
        }

        private Panel CreateSection(string title, Control content)
        {
            var pnl = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 6),
                BackColor = (Theme.Current?.Surface) ?? Color.White,
                Padding = new Padding(8, 6, 8, 6)
            };
            // 圆角边框效果 - 用FlatStyle panel
            pnl.Paint += (s, e) =>
            {
                var rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
                using (var pen = new Pen(Theme.Current.Border, 1))
                    e.Graphics.DrawRectangle(pen, rect);
            };

            var header = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 22,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                TextAlign = ContentAlignment.MiddleLeft
            };

            content.Dock = DockStyle.Fill;
            pnl.Controls.Add(content);
            pnl.Controls.Add(header);
            return pnl;
        }

        // ============ 统计内容 ============
        private Control BuildStatsContent()
        {
            var tbl = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 4 };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            lblSelectedLabelCount = StatLabel();
            lblSelectedWordCount = StatLabel();
            lblLabelCount = StatLabel();
            lblLabelWordCount = StatLabel();

            var dimGray = Color.FromArgb(120, 120, 120);
            tbl.Controls.Add(StatCaption("选中行数", dimGray), 0, 0);
            tbl.Controls.Add(lblSelectedLabelCount, 1, 0);
            tbl.Controls.Add(StatCaption("选中字数", dimGray), 0, 1);
            tbl.Controls.Add(lblSelectedWordCount, 1, 1);
            tbl.Controls.Add(StatCaption("总行数", dimGray), 0, 2);
            tbl.Controls.Add(lblLabelCount, 1, 2);
            tbl.Controls.Add(StatCaption("总字数", dimGray), 0, 3);
            tbl.Controls.Add(lblLabelWordCount, 1, 3);

            return tbl;
        }

        private Label StatCaption(string text, Color color)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = color,
                Margin = new Padding(0, 1, 4, 1)
            };
        }

        private Label StatLabel()
        {
            return new Label
            {
                Text = "-",
                AutoSize = true,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = AccentColor,
                Margin = new Padding(0, 1, 0, 1)
            };
        }

        // ============ Meta 编辑内容 ============
        private Control BuildMetaContent()
        {
            var tbl = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 3 };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

            cbxMetaType = new ComboBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 8.5f),
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                Height = 24
            };
            cbxMetaType.Items.AddRange(new string[] {
                "", "$LINK$>", "$NOTE$>", "$JUMP$>", "$LITR$>", "$SCHL$>",
                "$DDLI$>", "Date:", "date:"
            });

            txtMetaValue = new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 8.5f),
                BorderStyle = BorderStyle.FixedSingle,
                Height = 24
            };

            btnApplyMeta = new Button
            {
                Text = "应用",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 8f, FontStyle.Bold),
                BackColor = AccentColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Height = 26,
                Margin = new Padding(0, 4, 0, 0),
                Cursor = Cursors.Hand
            };
            btnApplyMeta.FlatAppearance.BorderSize = 0;

            tbl.Controls.Add(CompactLabel("类型"), 0, 0);
            tbl.Controls.Add(cbxMetaType, 1, 0);
            tbl.Controls.Add(CompactLabel("值"), 0, 1);
            tbl.Controls.Add(txtMetaValue, 1, 1);
            tbl.Controls.Add(btnApplyMeta, 1, 2);

            return tbl;
        }

        // ============ 标签颜色内容 ============
        private Control BuildLabelColorContent()
        {
            cmsNoteColor = new ContextMenuStrip();
            tsmAddColor = new ToolStripMenuItem("添加标签");
            tsmRemoveColor = new ToolStripMenuItem("移除标签");
            cmsNoteColor.Items.Add(tsmAddColor);
            cmsNoteColor.Items.Add(tsmRemoveColor);

            lsvColor = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Tile,
                MultiSelect = false,
                FullRowSelect = true,
                ContextMenuStrip = cmsNoteColor,
                Font = new Font("Segoe UI", 8.5f),
                BorderStyle = BorderStyle.None,
                TileSize = new Size(200, 26),
                BackColor = Color.White
            };
            return lsvColor;
        }

        // ============ 文献内容 ============
        private Control BuildLiteratureContent()
        {
            var tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 12,
                AutoScroll = true
            };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            int r = 0;
            tbl.Controls.Add(CompactLabel("年份"), 0, r);
            txtYear = FormTextBox(); tbl.Controls.Add(txtYear, 1, r); r++;

            tbl.Controls.Add(CompactLabel("期刊"), 0, r);
            var jp = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, Height = 24 };
            jp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            jp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 24));
            cbxJournalConference = new ComboBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 8.5f), FlatStyle = FlatStyle.Flat };
            btnJournal = new Button { Text = "…", Width = 24, Height = 24, Font = new Font("Segoe UI", 7f), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            jp.Controls.Add(cbxJournalConference, 0, 0);
            jp.Controls.Add(btnJournal, 1, 0);
            tbl.Controls.Add(jp, 1, r); r++;

            tbl.Controls.Add(CompactLabel("BibKey"), 0, r);
            txtBibKey = FormTextBox(); tbl.Controls.Add(txtBibKey, 1, r); r++;

            tbl.Controls.Add(CompactLabel("星标"), 0, r);
            chkStar = new CheckBox { Text = "", AutoSize = true, Margin = new Padding(0, 4, 0, 0) };
            tbl.Controls.Add(chkStar, 1, r); r++;

            tbl.Controls.Add(CompactLabel("类型"), 0, r);
            cbxBibEntryType = new ComboBox
            {
                Dock = DockStyle.Fill, Font = new Font("Segoe UI", 8.5f),
                DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat
            };
            cbxBibEntryType.Items.AddRange(new[] { "Article", "Book", "Conference", "Mastersthesis", "Phdthesis", "Unpublished" });
            tbl.Controls.Add(cbxBibEntryType, 1, r); r++;

            // 搜索按钮行
            var btnRow = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, Height = 26, Margin = new Padding(0, 2, 0, 2) };
            btnRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            btnRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            btnRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            btnGoogleScholar = FlatBtn("Scholar"); btnRow.Controls.Add(btnGoogleScholar, 0, 0);
            btnFullText = FlatBtn("FullText"); btnRow.Controls.Add(btnFullText, 1, 0);
            btnBibTeX = FlatBtn("BibTeX"); btnRow.Controls.Add(btnBibTeX, 2, 0);
            tbl.Controls.Add(btnRow, 1, r); r++;

            tbl.Controls.Add(CompactLabel("作者"), 0, r);
            lsbAuthor = FormListBox(); tbl.Controls.Add(lsbAuthor, 1, r); r++;

            tbl.Controls.Add(CompactLabel("标签"), 0, r);
            lsbTag = FormListBox(); tbl.Controls.Add(lsbTag, 1, r); r++;

            tbl.Controls.Add(CompactLabel("BibTeX"), 0, r);
            txtBibRef = new TextBox
            {
                Dock = DockStyle.Fill, Multiline = true, Height = 40,
                Font = new Font("Consolas", 8f), ReadOnly = true,
                ScrollBars = ScrollBars.Vertical, BorderStyle = BorderStyle.FixedSingle
            };
            tbl.Controls.Add(txtBibRef, 1, r); r++;

            for (int i = 0; i < 12; i++)
                tbl.RowStyles.Add(new RowStyle(i <= 5 ? SizeType.Absolute : SizeType.AutoSize, 26));

            return tbl;
        }

        // ============ 日程内容 ============
        private Control BuildDailyContent()
        {
            var tbl = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, RowCount = 2 };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 28));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 28));

            btnPrevDate = FlatBtn("◀"); btnPrevDate.Width = 28;
            lblDate = new Label
            {
                Text = "", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = AccentColor
            };
            btnNextDate = FlatBtn("▶"); btnNextDate.Width = 28;
            tbl.Controls.Add(btnPrevDate, 0, 0);
            tbl.Controls.Add(lblDate, 1, 0);
            tbl.Controls.Add(btnNextDate, 2, 0);

            picToday = new PictureBox
            {
                Dock = DockStyle.Fill, BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                MinimumSize = new Size(0, 180)
            };
            tbl.Controls.Add(picToday, 0, 1);
            tbl.SetColumnSpan(picToday, 3);

            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            return tbl;
        }

        private TextBox FormTextBox()
        {
            return new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 8.5f),
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        private ListBox FormListBox()
        {
            return new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 8.5f),
                Height = 40,
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        private Button FlatBtn(string text)
        {
            return new Button
            {
                Text = text,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 7.5f),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Margin = new Padding(1)
            };
        }

        private Label CompactLabel(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = Color.FromArgb(100, 100, 100),
                Margin = new Padding(0, 3, 6, 3)
            };
        }

        // ============ 类型切换 ============
        public void SetNoteType(ENoteType noteType)
        {
            currentNoteType = noteType;
            // index 0 = 文献, index 1 = 日程
            if (mainTable.Controls.Count >= 2)
            {
                mainTable.Controls[0].Visible = noteType == ENoteType.Literature;
                mainTable.Controls[1].Visible = noteType == ENoteType.DailyReport;
            }
        }

        public void UpdateStats(int selectedCount, int selectedWords, int totalCount, int totalWords)
        {
            lblSelectedLabelCount.Text = selectedCount.ToString();
            lblSelectedWordCount.Text = selectedWords.ToString();
            lblLabelCount.Text = totalCount.ToString();
            lblLabelWordCount.Text = totalWords.ToString();
        }

        // ============ 标签颜色管理 ============
        public void LoadLabelColors(List<RNoteColor> noteColors, plot colorHelper)
        {
            lsvColor.Items.Clear();
            foreach (var nc in noteColors)
            {
                var item = new ListViewItem { Text = "  " + nc.Keyword };
                item.BackColor = colorHelper.GetColor(nc.Color);
                item.ForeColor = (nc.Color == "Red" || nc.Color == "Green" || nc.Color == "Blue"
                    || nc.Color == "DarkGreen" || nc.Color == "Brown") ? Color.White : Color.Black;
                lsvColor.Items.Add(item);
            }
        }

        public string GetSelectedLabelKeyword()
        {
            if (lsvColor.SelectedItems.Count > 0)
                return lsvColor.SelectedItems[0].Text.Trim();
            return "";
        }

        public void ShowMetaInfo(OutlineLine line)
        {
            if (line == null) { mainTable.Controls[1].Visible = false; return; }
            mainTable.Controls[1].Visible = true;
            string text = line.Text;
            if (text.StartsWith("$LINK$>"))        { cbxMetaType.Text = "$LINK$>"; txtMetaValue.Text = text.Substring(7); }
            else if (text.StartsWith("$NOTE$>"))   { cbxMetaType.Text = "$NOTE$>"; txtMetaValue.Text = text.Substring(7); }
            else if (text.StartsWith("$JUMP$>"))   { cbxMetaType.Text = "$JUMP$>"; txtMetaValue.Text = text.Substring(7); }
            else if (text.StartsWith("$LITR$>"))   { cbxMetaType.Text = "$LITR$>"; txtMetaValue.Text = text.Substring(7); }
            else if (text.StartsWith("$SCHL$>"))   { cbxMetaType.Text = "$SCHL$>"; txtMetaValue.Text = text.Substring(7); }
            else if (text.ToLower().StartsWith("$ddli$>"))  { cbxMetaType.Text = "$DDLI$>"; txtMetaValue.Text = text.Substring(7); }
            else if (text.ToLower().StartsWith("date: ")) { cbxMetaType.Text = "date: "; txtMetaValue.Text = text.Substring(6); }
            else { cbxMetaType.Text = ""; txtMetaValue.Text = text; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cmsNoteColor?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
