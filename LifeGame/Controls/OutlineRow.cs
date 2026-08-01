using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LifeGame
{
    /// <summary>Outline 编辑器中的一行</summary>
    public class OutlineRow : UserControl
    {
        public OutlineLine Data { get; private set; }
        public new bool HasChildren { set { hasChildren = value; } }

        // 子控件
        private Panel pnlExpand;
        private Label lblExpand;
        private Panel pnlIcon;          // 替代 PictureBox，OnPaint 中用 ImageList.Draw
        private Label lblText;
        private TextBox txtEdit;
        private List<Label> lblBadges = new List<Label>();
        private Panel pnlBadges;
        private Panel pnlProgress;
        private Panel pnlProgressFill;
        private Label lblProgress;
        private CheckBox chkTag;
        private Font safeFont;

        // 图标信息（iglIcon 中的索引，-1 表示无图标）
        private int iconIndex = -1;
        private ImageList iconImageList;

        // Meta 样式标签缓存（解析自 Data.Text，在 SetSelected/ApplyThemeColors 时保留）
        private Color? _customTextColor;
        private FontStyle _customFontStyle = FontStyle.Regular;

        private static Color T(Func<Theme, Color> getter, Color fallback)
            => Theme.Current != null ? getter(Theme.Current) : fallback;

        private bool isEditing;
        private bool hasChildren;
        private int indentPerLevel = 20;
        private int rowHeight = 32;
        private bool iconDisplayMode = true;
        private bool allowEditNonMeta = false;
        private bool blockMetaEdit = false;
        private List<string> cachedLabelKeywords = new List<string>();
        private int cachedLevel = -1;

        public event Action<OutlineRow> TextEditCommitted;
        public event Action<OutlineRow> ExpandToggled;
        public event Action<OutlineRow> RowClicked;
        public event Action<OutlineRow> RowDoubleClicked;
        public event Action<OutlineRow, Point> RowRightClicked;
        public event Action<OutlineRow> TagCheckToggled;

        public OutlineRow(OutlineLine data, bool hasChildren, Font baseFont)
        {
            this.Data = data;
            this.hasChildren = hasChildren;
            this.Height = rowHeight;
            this.DoubleBuffered = true;
            this.Margin = new Padding(0);
            this.Padding = new Padding(0);

            BuildControls(baseFont);
            ApplyData();
        }

        private void BuildControls(Font baseFont)
        {
            try
            {
                safeFont = new Font(baseFont.FontFamily, baseFont.Size, baseFont.Style);
            }
            catch
            {
                safeFont = new Font("Segoe UI", 10f, FontStyle.Regular);
            }

            pnlExpand = new Panel
            {
                Width = indentPerLevel, Height = rowHeight,
                Cursor = hasChildren ? Cursors.Hand : Cursors.Default
            };
            lblExpand = new Label
            {
                Text = hasChildren ? (Data.Expanded ? "▼" : "▶") : "",
                Font = new Font("Segoe UI", 8f),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = T(t => t.ExpandArrow, Color.Gray)
            };
            pnlExpand.Controls.Add(lblExpand);
            if (hasChildren)
            {
                pnlExpand.Click += (s, e) => ExpandToggled?.Invoke(this);
                lblExpand.Click += (s, e) => ExpandToggled?.Invoke(this);
            }

            // 图标面板 — OnPaint 中用 ImageList.Draw 直接画
            pnlIcon = new Panel
            {
                Width = 23, Height = 17,
                BackColor = Color.Transparent,
                Visible = false
            };
            pnlIcon.Paint += PnlIcon_Paint;

            lblText = new Label
            {
                AutoSize = false,
                Height = rowHeight,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = safeFont,
                Padding = new Padding(0, 2, 0, 2),
                ForeColor = T(t => t.TextPrimary, Color.Black)
            };

            txtEdit = new TextBox
            {
                Visible = false,
                Height = rowHeight,
                BorderStyle = BorderStyle.FixedSingle,
                Font = safeFont
            };
            txtEdit.KeyDown += TxtEdit_KeyDown;
            txtEdit.LostFocus += TxtEdit_LostFocus;

            pnlBadges = new Panel
            {
                AutoSize = false,
                Height = rowHeight,
                Visible = true
            };

            pnlProgress = new Panel
            {
                Width = 60, Height = 18,
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };
            pnlProgressFill = new Panel
            {
                Height = 16,
                BackColor = T(t => t.ProgressBarFill, Color.FromArgb(0, 120, 215)),
                Left = 1, Top = 1
            };
            pnlProgress.Controls.Add(pnlProgressFill);

            lblProgress = new Label
            {
                AutoSize = false,
                Width = 28, Height = 18,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 7f),
                Visible = false,
                BackColor = Color.Transparent
            };

            chkTag = new CheckBox
            {
                Width = 18, Height = 18,
                Visible = false,
                Appearance = Appearance.Button,
                AutoCheck = false,
                TabStop = false,
                FlatStyle = FlatStyle.Flat,
                Text = "",
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            chkTag.Click += ChkTag_Click;

            this.Controls.Add(pnlExpand);
            this.Controls.Add(pnlIcon);
            this.Controls.Add(lblText);
            this.Controls.Add(txtEdit);
            this.Controls.Add(pnlBadges);
            this.Controls.Add(pnlProgress);
            this.Controls.Add(lblProgress);
            this.Controls.Add(chkTag);

            foreach (Control c in new Control[] { this, lblText, pnlIcon, pnlExpand })
            {
                c.Click += (s, e) => RowClicked?.Invoke(this);
                c.DoubleClick += (s, e) => RowDoubleClicked?.Invoke(this);
                c.MouseClick += (s, e) => {
                    if (e.Button == MouseButtons.Right)
                        RowRightClicked?.Invoke(this, e.Location);
                };
            }
        }

        private void PnlIcon_Paint(object sender, PaintEventArgs e)
        {
            if (iconImageList == null || iconIndex < 0 || iconIndex >= iconImageList.Images.Count) return;
            iconImageList.Draw(e.Graphics, 0, 0, 23, 17, iconIndex);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            LayoutControls();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(T(t => t.RowSeparator, Color.FromArgb(235, 235, 240))))
            {
                e.Graphics.DrawLine(pen, 0, this.Height - 1, this.Width, this.Height - 1);
            }

            int guidelineX = indentPerLevel / 2;
            for (int i = 1; i < Data.Level; i++)
            {
                int gx = i * indentPerLevel + guidelineX;
                using (var dotPen = new Pen(T(t => t.Guideline, Color.FromArgb(215, 208, 195))) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot })
                {
                    e.Graphics.DrawLine(dotPen, gx, 0, gx, this.Height);
                }
            }
        }

        public void LayoutControls()
        {
            if (pnlExpand == null) return;
            int x = Data.Level * indentPerLevel;
            pnlExpand.SetBounds(x, 0, indentPerLevel, rowHeight);
            x += indentPerLevel;

            if (pnlIcon.Visible)
            {
                pnlIcon.SetBounds(x, (rowHeight - 17) / 2, 23, 17);
                x += 25;
            }

            if (chkTag.Visible)
            {
                chkTag.SetBounds(x + 2, (rowHeight - 18) / 2, 18, 18);
                chkTag.BringToFront();
                x += 22;
            }

            int right = this.Width - 4;
            if (pnlProgress.Visible)
            {
                lblProgress.SetBounds(right - 92, (rowHeight - 18) / 2, 28, 18);
                lblProgress.Text = Data.ProgressPercent + "%";
                pnlProgress.SetBounds(right - 60, (rowHeight - 18) / 2, 60, 18);
                pnlProgressFill.Width = (int)(56 * Data.ProgressPercent / 100.0);
                right -= 96;
            }

            if (pnlBadges.Controls.Count > 0)
            {
                int badgePanelW = 0;
                foreach (Control c in pnlBadges.Controls)
                    badgePanelW += c.Width + 2;
                pnlBadges.SetBounds(right - badgePanelW, 0, badgePanelW, rowHeight);
                right -= badgePanelW + 4;
            }

            int textWidth = right - x - 4;
            if (textWidth < 50) textWidth = 50;
            lblText.SetBounds(x, 0, textWidth, rowHeight);
            txtEdit.SetBounds(x, 0, textWidth, rowHeight);
        }

        public void SetText(string text)
        {
            Data.Text = text;
            lblText.Text = text;
        }

        public void ApplyData()
        {
            if (hasChildren)
                lblExpand.Text = Data.Expanded ? "▼" : "▶";
            else
                lblExpand.Text = "▷";

            // 图标 — Icon 模式下获取索引和 ImageList，不克隆
            bool oldIconVisible = pnlIcon.Visible;
            pnlIcon.Visible = false;
            iconIndex = -1;
            iconImageList = null;
            if (iconDisplayMode)
            {
                iconIndex = NoteIconProvider.GetIconIndex(Data.Text);
                iconImageList = NoteIconProvider.IconList;
                pnlIcon.Visible = iconIndex >= 0;
            }
            pnlIcon.Invalidate();
            bool layoutNeeded = oldIconVisible != pnlIcon.Visible;

            // 缩进级别变化时需要重新布局
            if (cachedLevel != Data.Level)
            {
                layoutNeeded = true;
                cachedLevel = Data.Level;
            }

            // DDL 节点用红色显示
            bool isDdl = Data.MetaType == NodeMetaType.Deadline;

            string displayText = Data.Text;
            if (iconDisplayMode && !string.IsNullOrEmpty(displayText))
            {
                if (displayText.StartsWith("$LINK$>")) displayText = displayText.Substring(7);
                else if (displayText.StartsWith("$NOTE$>"))
                {
                    // $NOTE$>YYYY.MM.DD@Name 或 $NOTE$>Name，只显示 Name
                    string t = displayText.Substring(7);
                    int at = t.LastIndexOf('@');
                    displayText = at >= 0 ? t.Substring(at + 1) : t;
                }
                else if (displayText.StartsWith("$JUMP$>")) displayText = displayText.Substring(7);
                else if (displayText.StartsWith("$LITR$>")) displayText = displayText.Substring(7);
                else if (displayText.StartsWith("$SCHL$>")) displayText = displayText.Substring(7);
                else if (displayText.StartsWith("$TASK$>"))
                {
                    // $TASK$>Name@date@{...}，只显示第一个 @ 之前的 Name
                    string t = displayText.Substring(7);
                    int at = t.IndexOf('@');
                    displayText = at >= 0 ? t.Substring(0, at) : t;
                }
                else if (displayText.StartsWith("$FUNC$>"))
                {
                    // $FUNC$>SysNote: Name，只显示 Name
                    string t = displayText.Substring(7);
                    int colon = t.IndexOf(": ");
                    displayText = colon >= 0 ? t.Substring(colon + 2) : t;
                }
                else if (displayText.ToLower().StartsWith("$ddli$>"))
                {
                    // $DDLI$>YYYY.MM.DD@内容，只显示 @ 后面的内容
                    string t = displayText.Substring(7);
                    int at = t.IndexOf('@');
                    displayText = at >= 0 ? t.Substring(at + 1) : t;
                }
                else if (displayText.ToLower().StartsWith("date: ")) displayText = displayText.Substring(6);
                else if (displayText.StartsWith("$LREV$>"))
                {
                    string t = displayText.Substring(7);
                    int at = t.LastIndexOf('@');
                    displayText = at >= 0 ? t.Substring(at + 1) : t;
                }
                else if (displayText.StartsWith("☐ $LTAG$>") || displayText.StartsWith("☑ $LTAG$>") || displayText.StartsWith("$LTAG$>"))
                {
                    string clean = displayText;
                    if (clean.StartsWith("☐ ")) clean = clean.Substring(2);
                    if (clean.StartsWith("☑ ")) clean = clean.Substring(2);
                    displayText = clean.StartsWith("$LTAG$>") ? clean.Substring(7) : clean;
                }

                if (!Data.IsMetaNode)
                {
                    displayText = System.Text.RegularExpressions.Regex.Replace(displayText, @"\s*\[\d+%\]\s*", "");
                    displayText = System.Text.RegularExpressions.Regex.Replace(displayText, @"\s*\[[^\]]+\]\s*", " ");
                }
            }
            // 从显示文本中移除格式标签
            displayText = Regex.Replace(displayText, @"\[Bold\]", "", RegexOptions.IgnoreCase);
            displayText = Regex.Replace(displayText, @"\[Italic\]", "", RegexOptions.IgnoreCase);
            displayText = Regex.Replace(displayText, @"\[Underline\]", "", RegexOptions.IgnoreCase);
            displayText = Regex.Replace(displayText, @"\[#[0-9A-Fa-f]{6}\]", "");
            // 清理标签移除后的残留多余空格
            displayText = Regex.Replace(displayText, @"\s{2,}", " ");
            lblText.Text = displayText.Trim();
            txtEdit.Text = Data.Text;
            lblText.ForeColor = isDdl ? Color.Red : T(t => t.TextPrimary, Color.Black);

            // LTAG checkbox
            bool isLtag = Data.MetaType == NodeMetaType.LiteratureTag;
            bool wasVisible = chkTag.Visible;
            chkTag.Visible = isLtag;
            if (isLtag)
            {
                bool isChecked = (Data.Text ?? "").StartsWith("☑ $LTAG$>");
                chkTag.Checked = isChecked;
                chkTag.BackColor = isChecked ? Color.FromArgb(50, 50, 50) : Color.White;
                if (!wasVisible) chkTag.BringToFront();
                layoutNeeded = true;
            }

            // === 解析 Meta 样式标签：[#RRGGBB] / [Bold] / [Underline] / [Italic] ===
            string rawText = Data.Text ?? "";
            _customFontStyle = FontStyle.Regular;
            if (Regex.IsMatch(rawText, @"\[Bold\]", RegexOptions.IgnoreCase))
                _customFontStyle |= FontStyle.Bold;
            if (Regex.IsMatch(rawText, @"\[Italic\]", RegexOptions.IgnoreCase))
                _customFontStyle |= FontStyle.Italic;
            if (Regex.IsMatch(rawText, @"\[Underline\]", RegexOptions.IgnoreCase))
                _customFontStyle |= FontStyle.Underline;
            lblText.Font = _customFontStyle != FontStyle.Regular
                ? new Font(safeFont.FontFamily, safeFont.Size, _customFontStyle)
                : safeFont;

            _customTextColor = null;
            var colorMatch = Regex.Match(rawText, @"\[#([0-9A-Fa-f]{6})\]");
            if (colorMatch.Success)
            {
                try { _customTextColor = ColorTranslator.FromHtml("#" + colorMatch.Groups[1].Value); }
                catch { _customTextColor = null; }
            }

            // 仅在 LabelKeywords 变化时才重建 badge 控件
            bool labelsChanged = !LabelsEqual(Data.LabelKeywords, cachedLabelKeywords);
            if (labelsChanged)
            {
                layoutNeeded = true;
                foreach (var b in lblBadges)
                    b.Dispose();
                lblBadges.Clear();
                pnlBadges.Controls.Clear();

                if (Data.LabelKeywords != null && Data.LabelKeywords.Count > 0)
                {
                    int x = 0;
                    foreach (var kw in Data.LabelKeywords)
                    {
                        var badge = new Label
                        {
                            Text = kw,
                            AutoSize = false,
                            Height = 20,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Segoe UI", 8f, FontStyle.Bold),
                            Padding = new Padding(6, 0, 6, 0),
                            Margin = new Padding(2, 0, 2, 0),
                            ForeColor = Color.White,
                            BackColor = Color.Gray
                        };
                        badge.SetBounds(x, (rowHeight - 20) / 2, TextRenderer.MeasureText(kw, badge.Font).Width + 14, 20);
                        pnlBadges.Controls.Add(badge);
                        lblBadges.Add(badge);
                        x += badge.Width + 2;
                    }
                }
                cachedLabelKeywords = new List<string>(Data.LabelKeywords ?? new List<string>());
            }

            bool oldProgressVisible = pnlProgress.Visible;
            if (Data.ProgressPercent > 0)
            {
                pnlProgress.Visible = true;
                pnlProgressFill.Width = (int)(56 * Data.ProgressPercent / 100.0);
                lblProgress.Text = Data.ProgressPercent + "%";
                lblProgress.Visible = true;
            }
            else
            {
                pnlProgress.Visible = false;
                lblProgress.Visible = false;
            }
            if (oldProgressVisible != pnlProgress.Visible)
                layoutNeeded = true;

            if (layoutNeeded)
                LayoutControls();
        }

        public void SetLabelBadgeColors(Dictionary<string, Color> colorMap, Dictionary<string, Color> foreMap)
        {
            for (int i = 0; i < lblBadges.Count && i < Data.LabelKeywords.Count; i++)
            {
                string kw = Data.LabelKeywords[i];
                if (colorMap.ContainsKey(kw))
                {
                    lblBadges[i].BackColor = colorMap[kw];
                    lblBadges[i].ForeColor = foreMap.ContainsKey(kw) ? foreMap[kw] : Color.White;
                    lblBadges[i].Invalidate();
                }
            }
        }

        public void SetIconDisplayMode(bool showIcons)
        {
            if (iconDisplayMode == showIcons) return;
            iconDisplayMode = showIcons;
            ApplyData();
        }

        public void SetAllowEditNonMeta(bool allow)
        {
            allowEditNonMeta = allow;
        }

        public void SetBlockMetaEdit(bool block)
        {
            blockMetaEdit = block;
        }

        public void SetSelected(bool selected)
        {
            this.BackColor = selected ? T(t => t.Selection, Color.FromArgb(230, 240, 255)) : T(t => t.RowBackground, Color.Transparent);
            lblText.ForeColor = selected
                ? T(t => t.SelectionText, Color.Black)
                : _customTextColor ?? T(t => t.TextPrimary, Color.Black);
        }

        public void ApplyThemeColors()
        {
            lblText.ForeColor = _customTextColor ?? T(t => t.TextPrimary, Color.Black);
            lblExpand.ForeColor = T(t => t.ExpandArrow, Color.Gray);
            pnlProgressFill.BackColor = T(t => t.ProgressBarFill, Color.FromArgb(0, 120, 215));
            this.BackColor = T(t => t.RowBackground, Color.Transparent);
            this.Invalidate();
        }

        private static bool LabelsEqual(List<string> a, List<string> b)
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            if (a.Count != b.Count) return false;
            for (int i = 0; i < a.Count; i++)
                if (a[i] != b[i]) return false;
            return true;
        }

        public void BeginEdit()
        {
            if (isEditing) return;
            if (iconDisplayMode && !Data.IsMetaNode && !allowEditNonMeta) return;
            if (iconDisplayMode && Data.IsMetaNode && blockMetaEdit) return;
            isEditing = true;
            lblText.Visible = false;
            txtEdit.Visible = true;
            txtEdit.Text = Data.Text;
            txtEdit.Focus();
            txtEdit.SelectAll();
        }

        /// <summary>是否真正处于编辑中（TextBox 可见且拥有焦点）</summary>
        public bool IsEditing => isEditing && txtEdit.Visible && txtEdit.Focused;

        public void CommitEdit()
        {
            if (!isEditing) return;
            isEditing = false;
            string newText = txtEdit.Text.Trim();
            txtEdit.Visible = false;
            lblText.Visible = true;
            if (newText != Data.Text && !string.IsNullOrEmpty(newText))
            {
                Data.Text = newText;
                lblText.Text = newText;
                TextEditCommitted?.Invoke(this);
            }
        }

        private void TxtEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CommitEdit();
                this.BeginInvoke(new Action(() => this.Parent?.Parent?.Focus()));
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                txtEdit.Text = Data.Text;
                CommitEdit();
                this.BeginInvoke(new Action(() => this.Parent?.Parent?.Focus()));
            }
        }

        private void TxtEdit_LostFocus(object sender, EventArgs e)
        {
            CommitEdit();
        }

        public void UpdateHasChildren(bool children)
        {
            hasChildren = children;
            pnlExpand.Cursor = children ? Cursors.Hand : Cursors.Default;
            lblExpand.Text = children ? (Data.Expanded ? "▼" : "▶") : "▷";
        }

        private void ChkTag_Click(object sender, EventArgs e)
        {
            string text = Data.Text ?? "";
            if (chkTag.Checked)
            {
                // Uncheck: ☑ → ☐
                if (text.StartsWith("☑ $LTAG$>"))
                    Data.Text = "☐ " + text.Substring(2);
                else if (text.StartsWith("$LTAG$>"))
                    Data.Text = "☐ " + text;
            }
            else
            {
                // Check: ☐ → ☑
                if (text.StartsWith("☐ $LTAG$>"))
                    Data.Text = "☑ " + text.Substring(2);
                else if (text.StartsWith("$LTAG$>"))
                    Data.Text = "☑ " + text;
            }
            chkTag.Checked = !chkTag.Checked;
            chkTag.BackColor = chkTag.Checked ? Color.FromArgb(50, 50, 50) : Color.White;
            TagCheckToggled?.Invoke(this);
        }
    }
}
