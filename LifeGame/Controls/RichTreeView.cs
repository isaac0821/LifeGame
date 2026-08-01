﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class RichTreeView : UserControl
    {
        #region Fields

        private OutlinePanel outlinePanel;

        private ContextMenuStrip cmsNote;
        private ToolStripMenuItem tsmAddChild, tsmDelete;
        private ToolStripMenuItem tsmMoveUp, tsmMoveDown, tsmIndent, tsmUnindent;
        private ToolStripMenuItem tsmFold, tsmExpand;
        private ToolStripMenuItem tsmCopy, tsmCut, tsmPaste, tsmCopyJump;
        private ToolStripMenuItem tsmProgressAdd, tsmProgressMinus;
        private ToolStripMenuItem tsmGoto, tsmRemoveChildren, tsmRemoveLayer;
        private ToolStripMenuItem tsmReplace;
        private ToolStripMenuItem tsmToggleDisplay;
        internal ToolStripMenuItem btnSaveMenu = new ToolStripMenuItem();

        private List<OutlineLine> copiedLines = new List<OutlineLine>();
        private List<string> lstReferenceLinks = new List<string>();
        private bool showRawMeta = true;
        private string previousSelectedGUID = null;

        private plot _plotCalc = new plot();

        #endregion

        #region Properties

        public OutlinePanel OutlinePanel { get { return outlinePanel; } }

        public bool IsReadOnly { get { return outlinePanel.IsReadOnly; } set { outlinePanel.IsReadOnly = value; } }

        public bool IconDisplayMode { get { return outlinePanel.IconDisplayMode; } set { outlinePanel.IconDisplayMode = value; } }

        public bool AllowEditNonMeta { get { return outlinePanel.AllowEditNonMeta; } set { outlinePanel.AllowEditNonMeta = value; } }

        public bool BlockMetaEdit { get { return outlinePanel.BlockMetaEdit; } set { outlinePanel.BlockMetaEdit = value; } }

        public bool IsDirty { get { return btnSaveMenu.Enabled; } set { btnSaveMenu.Enabled = value; } }

        public List<RNoteColor> NoteColors { get; set; }

        public ESysNoteType SysNoteType { get; set; }

        public string SysNoteTopic { get; set; }

        public plot C { get { return C; } }

        public string RootTitle { set { outlinePanel.SetRootTitle(value); } }

        public List<OutlineLine> GetAllLines() { return outlinePanel.GetAllLines(); }

        #endregion

        #region Events

        public event Action ContentModified;
        public event Action MetaSectionModified;
        public event Action TaskOrScheduleChanged;
        public event Action LabelColorsChanged;
        public event Action<string> OpenNoteByGUID;
        public event Action<string> OpenLiteratureByTitle;
        public event Action<string> OpenUrl;
        public event Action<DateTime> OpenDiary;
        public event Action<string> DeleteNoteRequested;
        public event Action<OutlineLine> ArchiveTaskRequested;
        public event Action<OutlineLine> RepeatWeeklyRequested;
        public event Action<string> OpenSysNoteRequested;
        public event Action ExitRequested;
        public event Action<string, string, DateTime> NoteRenamed;
        public event Action<string> OpenLiteratureReviewByGUID;
        public event Action<string> DeleteLiteratureReviewRequested;
        public event Action LiteratureTagToggled;

        #endregion

        #region Constructor & Initialize

        public RichTreeView()
        {
            outlinePanel = new OutlinePanel { Dock = DockStyle.Fill };
            this.Controls.Add(outlinePanel);
        }

        public void Initialize()
        {
            outlinePanel.LinesChanged += () => btnSaveMenu.Enabled = true;
            outlinePanel.TextEdited += OnTextEdited;
            outlinePanel.SelectionChanged += OnSelectionChanged;
            outlinePanel.LineRightClicked += OnLineRightClicked;
            outlinePanel.LineClicked += OnLineClicked;
            outlinePanel.TagCheckToggled += OnTagCheckToggled;
            BuildContextMenu();
        }

        #endregion

        #region Public Methods

        public bool HandleKeyCommand(Keys keyData)
        {
            var focused = this.ActiveControl;
            bool inEditor = (focused is TextBox && focused.Parent is OutlineRow) || outlinePanel.IsEditing;

            if (inEditor) return false;

            if (outlinePanel.IsReadOnly)
            {
                if (keyData == Keys.Up) { NavigateSelection(-1); return true; }
                if (keyData == Keys.Down) { NavigateSelection(1); return true; }
                if (keyData == (Keys.Control | Keys.G)) { HandleGoto(); return true; }
                return false;
            }

            if (keyData == (Keys.Control | Keys.I)) { outlinePanel.MoveUpSelected(); return true; }
            if (keyData == (Keys.Control | Keys.K)) { outlinePanel.MoveDownSelected(); return true; }
            if (keyData == (Keys.Control | Keys.L)) { outlinePanel.IndentSelected(); return true; }
            if (keyData == (Keys.Control | Keys.J)) { outlinePanel.UnindentSelected(); return true; }
            if (keyData == (Keys.Control | Keys.A)) { AddChildNode(); return true; }
            if (keyData == (Keys.Control | Keys.N)) { FoldSelected(); return true; }
            if (keyData == (Keys.Control | Keys.M)) { ExpandSelected(); return true; }
            if (keyData == (Keys.Control | Keys.R)) { RotateLabel(1); return true; }
            if (keyData == (Keys.Control | Keys.T)) { RotateLabel(-1); return true; }
            if (keyData == (Keys.Control | Keys.Oemplus)) { AdjustProgress(5); return true; }
            if (keyData == (Keys.Control | Keys.OemMinus)) { AdjustProgress(-5); return true; }
            if (keyData == (Keys.Control | Keys.Oemtilde)) { SetProgress(0); return true; }
            if (keyData == (Keys.Control | Keys.D1)) { SetProgress(10); return true; }
            if (keyData == (Keys.Control | Keys.D2)) { SetProgress(20); return true; }
            if (keyData == (Keys.Control | Keys.D3)) { SetProgress(30); return true; }
            if (keyData == (Keys.Control | Keys.D4)) { SetProgress(40); return true; }
            if (keyData == (Keys.Control | Keys.D5)) { SetProgress(50); return true; }
            if (keyData == (Keys.Control | Keys.D6)) { SetProgress(60); return true; }
            if (keyData == (Keys.Control | Keys.D7)) { SetProgress(70); return true; }
            if (keyData == (Keys.Control | Keys.D8)) { SetProgress(80); return true; }
            if (keyData == (Keys.Control | Keys.D9)) { SetProgress(90); return true; }
            if (keyData == (Keys.Control | Keys.D0)) { SetProgress(100); return true; }
            if (keyData == (Keys.Control | Keys.G)) { HandleGoto(); return true; }
            if (keyData == (Keys.Control | Keys.E)) { EditSelected(); return true; }
            if (keyData == (Keys.Control | Keys.C)) { CopySelected(); return true; }
            if (keyData == (Keys.Control | Keys.X)) { CopyJumpNode(); return true; }
            if (keyData == (Keys.Control | Keys.V)) { PasteCopied(); return true; }
            if (keyData == (Keys.Control | Keys.D)) { DeleteSelected(); return true; }
            if (keyData == (Keys.Control | Keys.O)) { RemoveChildren(); return true; }
            if (keyData == (Keys.Control | Keys.P)) { RemoveLayer(); return true; }
            if (keyData == (Keys.Control | Keys.S)) { ContentModified?.Invoke(); return true; }
            if (keyData == (Keys.Control | Keys.Z)) { outlinePanel.Undo(); return true; }
            if (keyData == (Keys.Control | Keys.Shift | Keys.Z)) { outlinePanel.Redo(); return true; }
            if (keyData == (Keys.Control | Keys.Shift | Keys.B)) { ToggleFormatTag("[Bold]"); return true; }
            if (keyData == (Keys.Control | Keys.Shift | Keys.U)) { ToggleFormatTag("[Underline]"); return true; }
            if (keyData == (Keys.Control | Keys.Shift | Keys.I)) { ToggleFormatTag("[Italic]"); return true; }
            if (keyData == Keys.F2) { TryRenameSelectedNote(); return true; }
            if (keyData == (Keys.Control | Keys.Q)) { RestorePreviousSelection(); return true; }
            if (keyData == (Keys.Control | Keys.Y)) { ToggleDisplayMode(); return true; }

            if (keyData == Keys.Up) { NavigateSelection(-1); return true; }
            if (keyData == Keys.Down) { NavigateSelection(1); return true; }
            if (keyData == Keys.Left) { outlinePanel.NavigateLeft(); return true; }
            if (keyData == Keys.Right) { outlinePanel.NavigateRight(); return true; }
            return false;
        }

        public void LoadLines(List<OutlineLine> lines) { outlinePanel.LoadLines(lines); }
        public void RefreshLayout() { outlinePanel.RefreshLayout(); }
        public void RefreshAllRowDisplays() { outlinePanel.RefreshAllRowDisplays(); }
        public void SetMetaRoot(OutlineLine root) { outlinePanel.SetMetaRoot(root); }

        #endregion

        #region Context Menu

        private void BuildContextMenu()
        {
            cmsNote = new ContextMenuStrip();
            btnSaveMenu.Enabled = false;

            tsmGoto = AddMenuItem("跳转 (&G)", (s, e) => HandleGoto());
            cmsNote.Items.Add(new ToolStripSeparator());

            tsmToggleDisplay = new ToolStripMenuItem("Meta 模式 (&Y)");
            tsmToggleDisplay.Click += (s, e) => ToggleDisplayMode();
            cmsNote.Items.Add(tsmToggleDisplay);
            cmsNote.Items.Add(new ToolStripSeparator());

            tsmAddChild = AddMenuItem("添加子节点 (&A)", (s, e) => AddChildNode());
            cmsNote.Items.Add(new ToolStripSeparator());

            tsmFold = AddMenuItem("折叠 (&N)", (s, e) => FoldSelected());
            tsmExpand = AddMenuItem("展开 (&M)", (s, e) => ExpandSelected());
            cmsNote.Items.Add(new ToolStripSeparator());

            tsmIndent = AddMenuItem("右移 (&J)", (s, e) => outlinePanel.IndentSelected());
            tsmUnindent = AddMenuItem("左移 (&L)", (s, e) => outlinePanel.UnindentSelected());
            cmsNote.Items.Add(new ToolStripSeparator());

            var progressMenu = new ToolStripMenuItem("进度");
            for (int p = 0; p <= 100; p += 10)
            {
                int pp = p;
                progressMenu.DropDownItems.Add(new ToolStripMenuItem(pp + "%", null, (s, e) => SetProgress(pp)));
            }
            tsmProgressAdd = AddMenuItem("进度 +5%", (s, e) => AdjustProgress(5));
            tsmProgressMinus = AddMenuItem("进度 -5%", (s, e) => AdjustProgress(-5));
            cmsNote.Items.Add(progressMenu);
            cmsNote.Items.Add(tsmProgressAdd);
            cmsNote.Items.Add(tsmProgressMinus);
            cmsNote.Items.Add(new ToolStripSeparator());

            tsmCopy = AddMenuItem("复制 (&C)", (s, e) => CopySelected());
            tsmCopyJump = AddMenuItem("复制跳转 (&X)", (s, e) => CopyJumpNode());
            tsmPaste = AddMenuItem("粘贴 (&V)", (s, e) => PasteCopied());
            cmsNote.Items.Add(new ToolStripSeparator());

            tsmDelete = AddMenuItem("删除 (&D)", (s, e) => DeleteSelected());
            tsmRemoveChildren = AddMenuItem("删除子节点 (&O)", (s, e) => RemoveChildren());
            tsmRemoveLayer = AddMenuItem("删除层 (&P)", (s, e) => RemoveLayer());
            cmsNote.Items.Add(new ToolStripSeparator());

            tsmMoveUp = AddMenuItem("上移 (&I)", (s, e) => outlinePanel.MoveUpSelected());
            tsmMoveDown = AddMenuItem("下移 (&K)", (s, e) => outlinePanel.MoveDownSelected());
        }

        private ToolStripMenuItem AddMenuItem(string text, EventHandler handler)
        {
            var item = new ToolStripMenuItem(text);
            item.Click += handler;
            cmsNote.Items.Add(item);
            return item;
        }

        private void OnLineRightClicked(OutlineLine line, Point loc)
        {
            previousSelectedGUID = outlinePanel.GetSelectedLines().FirstOrDefault()?.GUID;

            if (SysNoteType == ESysNoteType.Menu)
                return; // Menu 的右键菜单由 frmInfoNoteV2 通过 OutlinePanel.ContextMenuStrip 处理

            if (SysNoteType == ESysNoteType.Calendar || SysNoteType == ESysNoteType.Archive
                || SysNoteTopic == "SysNote: Note Archive")
            {
                cmsNote.Items.Clear();
                string sourceGUID = line.MetaValue;
                if (line.MetaType == NodeMetaType.NoteRef && !string.IsNullOrEmpty(sourceGUID))
                {
                    // MetaValue 可能是 GUID 也可能是 Topic（Note Archive 树存的是 Topic）
                    string resolvedGUID = sourceGUID;
                    var targetNote = G.glb.lstNote.Find(o => o.GUID == sourceGUID)
                        ?? G.glb.lstNote.Find(o => o.Topic == sourceGUID);
                    if (targetNote != null)
                        resolvedGUID = targetNote.GUID;
                    cmsNote.Items.Add("转到 (&G)", null, (s2, e2) => OpenNoteByGUID?.Invoke(resolvedGUID));
                    if (SysNoteTopic == "SysNote: Note Archive")
                    {
                        var topic = line.MetaValue ?? "";
                        if (!IsSysNoteTopic(topic))
                            cmsNote.Items.Add("重命名 (&R)", null, (s2, e2) => TryRenameNote(line));
                        cmsNote.Items.Add("删除 (&D)", null, (s2, e2) => DeleteNoteRequested?.Invoke(line.MetaValue ?? ""));
                    }
                }
                else if ((line.MetaType == NodeMetaType.Task || line.MetaType == NodeMetaType.Schedule)
                    && !string.IsNullOrEmpty(sourceGUID))
                {
                    string resolvedGUID = sourceGUID;
                    var targetNote = G.glb.lstNote.Find(o => o.GUID == sourceGUID);
                    if (targetNote != null)
                        resolvedGUID = targetNote.GUID;
                    cmsNote.Items.Add("转到来源 Note", null, (s2, e2) => OpenNoteByGUID?.Invoke(resolvedGUID));
                }
                if (cmsNote.Items.Count > 0)
                    cmsNote.Show(outlinePanel, outlinePanel.PointToClient(Cursor.Position));
                return;
            }

            bool isRoot = line.Level == 0;
            bool isMetaSection = line.IsMetaSectionHeader;
            bool isMeta = line.IsMetaNode;

            // LiteratureReview 列表节点：跳转 + 删除
            if (line.MetaType == NodeMetaType.LiteratureReview && !string.IsNullOrEmpty(line.GUID))
            {
                cmsNote.Items.Clear();
                cmsNote.Items.Add("跳转 (&G)", null, (s2, e2) => OpenLiteratureReviewByGUID?.Invoke(line.GUID));
                cmsNote.Items.Add(new ToolStripSeparator());
                cmsNote.Items.Add("删除 (&D)", null, (s2, e2) => DeleteLiteratureReviewRequested?.Invoke(line.GUID));
                cmsNote.Show(outlinePanel, outlinePanel.PointToClient(Cursor.Position));
                return;
            }

            tsmDelete.Enabled = !isRoot && !isMetaSection;
            tsmRemoveChildren.Enabled = !isRoot && outlinePanel.GetAllLines().Any(l => l.ParentGUID == line.GUID) && !isMetaSection;
            tsmRemoveLayer.Enabled = !isRoot && !isMetaSection;

            tsmMoveUp.Enabled = !isRoot && !isMeta;
            tsmMoveDown.Enabled = !isRoot && !isMeta;
            tsmIndent.Enabled = !isRoot && !isMeta;
            tsmUnindent.Enabled = line.Level > 1 && !isMeta;
            tsmFold.Enabled = !isRoot && outlinePanel.GetAllLines().Any(l => l.ParentGUID == line.GUID) && !isMetaSection;
            tsmExpand.Enabled = tsmFold.Enabled;
            tsmPaste.Enabled = (copiedLines.Count > 0 || Clipboard.ContainsText()) && !isMeta;

            if (line.IsMetaSectionHeader && line.AllowAddChild) tsmAddChild.Enabled = true;
            else if (line.IsMetaNode && !line.IsMetaSectionHeader) tsmAddChild.Enabled = false;
            else tsmAddChild.Enabled = !isMetaSection;

            bool hasProgress = line.ProgressPercent > 0
                || (line.Text.IndexOf("$DDLI$>", StringComparison.OrdinalIgnoreCase) >= 0)
                || (line.Text.IndexOf("Date:", StringComparison.OrdinalIgnoreCase) >= 0)
                || (line.Text.IndexOf("date:", StringComparison.OrdinalIgnoreCase) >= 0);
            tsmProgressAdd.Visible = hasProgress;
            tsmProgressMinus.Visible = hasProgress;

            bool canGoto = line.MetaType == NodeMetaType.Link || line.MetaType == NodeMetaType.Literature
                || line.MetaType == NodeMetaType.NoteRef || line.MetaType == NodeMetaType.Jump
                || line.MetaType == NodeMetaType.FuncRef
                || line.Text.StartsWith("$LINK$>") || line.Text.StartsWith("$LITR$>")
                || line.Text.StartsWith("$NOTE$>") || line.Text.StartsWith("$JUMP$>")
                || line.Text.StartsWith("$FUNC$>") || line.Text.StartsWith("$LREV$>");
            tsmGoto.Enabled = canGoto;

            if (SysNoteType == ESysNoteType.Calendar)
            {
                if (line.MetaType == NodeMetaType.Task)
                {
                    cmsNote.Items.Add(new ToolStripSeparator());
                    cmsNote.Items.Add("Archive", null, (s, ev) => ArchiveTaskRequested?.Invoke(line));
                }
                else if (line.MetaType == NodeMetaType.Schedule && IsChildOfTaskNode(line))
                {
                    cmsNote.Items.Add(new ToolStripSeparator());
                    cmsNote.Items.Add("Repeat Weekly", null, (s, ev) => RepeatWeeklyRequested?.Invoke(line));
                }
            }

            cmsNote.Show(outlinePanel, outlinePanel.PointToClient(Cursor.Position));
        }

        #endregion

        #region Event Handlers

        private void OnSelectionChanged(List<OutlineLine> selected) { }

        private void OnTextEdited(OutlineLine line)
        {
            btnSaveMenu.Enabled = true;
            string text = line.Text;
            if (text.StartsWith("$LINK$>")) { line.MetaType = NodeMetaType.Link; line.MetaValue = text.Substring(7); }
            else if (text.StartsWith("$NOTE$>")) { line.MetaType = NodeMetaType.NoteRef; line.MetaValue = text.Substring(7); }
            else if (text.StartsWith("$JUMP$>")) { line.MetaType = NodeMetaType.Jump; line.MetaValue = text.Substring(7); }
            else if (text.StartsWith("$LITR$>")) { line.MetaType = NodeMetaType.Literature; line.MetaValue = text.Substring(7); }
            else if (text.StartsWith("$TASK$>")) { line.MetaType = NodeMetaType.Task; line.MetaValue = text.Substring(7); }
            else if (text.StartsWith("$SCHL$>")) { line.MetaType = NodeMetaType.Schedule; line.MetaValue = text.Substring(7); }
            else if (text.StartsWith("$LTAG$>") || text.StartsWith("☐ $LTAG$>") || text.StartsWith("☑ $LTAG$>"))
            {
                line.MetaType = NodeMetaType.LiteratureTag;
                string clean = text;
                if (clean.StartsWith("☐ ")) clean = clean.Substring(2);
                if (clean.StartsWith("☑ ")) clean = clean.Substring(2);
                line.MetaValue = clean.StartsWith("$LTAG$>") ? clean.Substring(7) : clean;
            }
            else if (text.StartsWith("$LREV$>")) { line.MetaType = NodeMetaType.LiteratureReview; line.MetaValue = text.Substring(7); }
            else if (text.StartsWith("$DDLI$>", StringComparison.OrdinalIgnoreCase))
            {
                line.MetaType = NodeMetaType.Deadline;
                line.MetaValue = text.StartsWith("$DDLI$>") ? text.Substring(7) : text;
            }
            else if (text.ToLower().StartsWith("date: "))
            {
                line.MetaType = NodeMetaType.Deadline;
                int ci = text.IndexOf(": ");
                if (ci > 0) line.MetaValue = text.Substring(ci + 2).Trim();
            }
            else { line.MetaType = NodeMetaType.None; line.MetaValue = null; }

            var labelColors = BuildLabelColorMap();
            line.LabelKeywords = new List<string>();
            var labelMatches = System.Text.RegularExpressions.Regex.Matches(text, @"\[([^\]]+)\]");
            foreach (System.Text.RegularExpressions.Match lm in labelMatches)
            {
                string kw = lm.Groups[1].Value;
                if (labelColors.ContainsKey(kw)) line.LabelKeywords.Add(kw);
            }

            var m = System.Text.RegularExpressions.Regex.Match(text, @"\[(\d+)%\]");
            if (m.Success) { line.MetaType = NodeMetaType.Progress; line.ProgressPercent = int.Parse(m.Groups[1].Value); }
            else { line.ProgressPercent = 0; if (line.MetaType == NodeMetaType.Progress) line.MetaType = NodeMetaType.None; }

            outlinePanel.LabelColors = labelColors;
            outlinePanel.LabelForeColors = BuildLabelForeColorMap();

            if (line.IsMetaNode)
            {
                MetaSectionModified?.Invoke();
                var parentSection = outlinePanel.GetAllLines().Find(l => l.IsMetaSectionHeader && l.GUID == line.ParentGUID);
                if (parentSection != null && parentSection.Text == "Label color")
                {
                    RebuildAllContentLabels();
                    LabelColorsChanged?.Invoke();
                }
                ContentModified?.Invoke();
                outlinePanel.RefreshRowsWithLabels();
            }
            else
            {
                outlinePanel.RefreshRowDisplay(line);
                UpdateModifiedNode(line);
                if (line.MetaType == NodeMetaType.Task || line.MetaType == NodeMetaType.Schedule)
                    TaskOrScheduleChanged?.Invoke();
            }
        }

        #endregion

        #region Line Operations

        private void AddChildNode()
        {
            var sel = outlinePanel.GetSelectedLines().FirstOrDefault();
            if (sel == null) return;

            if (sel.IsMetaSectionHeader)
            {
                if (sel.AllowAddChild)
                    outlinePanel.AddLine(sel.EditFormatHint ?? "New", sel);
                return;
            }
            if (sel.IsMetaNode) return;
            outlinePanel.AddLineInPlace("New node", sel);
        }

        private void AddSiblingNode()
        {
            var sel = outlinePanel.GetSelectedLines().FirstOrDefault();
            if (sel == null || sel.Level == 0 || sel.IsMetaSectionHeader) return;
            var parent = outlinePanel.GetAllLines().Find(l => l.GUID == sel.ParentGUID);

            if (sel.IsMetaNode)
            {
                if (parent != null && parent.IsMetaSectionHeader && parent.AllowAddChild)
                    outlinePanel.AddLine(parent.EditFormatHint ?? "New", parent);
                return;
            }

            if (parent != null && !parent.IsMetaNode)
                outlinePanel.AddLine("New node", parent);
            else if (!sel.IsMetaNode)
                outlinePanel.AddLine("New node", null);
        }

        internal void DeleteSelected()
        {
            var hasMeta = outlinePanel.GetSelectedLines().Any(l => l.IsMetaNode);
            var allLines = outlinePanel.GetAllLines();
            bool labelColorChanged = outlinePanel.GetSelectedLines().Any(l =>
            {
                var parent = allLines.Find(p => p.IsMetaSectionHeader && p.GUID == l.ParentGUID);
                return parent != null && parent.Text == "Label color";
            });
            var deletedTaskOrSchl = outlinePanel.GetSelectedLines()
                .Any(l => l.MetaType == NodeMetaType.Task || l.MetaType == NodeMetaType.Schedule);

            outlinePanel.RemoveSelectedLines();

            if (hasMeta)
            {
                MetaSectionModified?.Invoke();
                if (labelColorChanged)
                {
                    RebuildAllContentLabels();
                    LabelColorsChanged?.Invoke();
                }
                ContentModified?.Invoke();
            }

            if (deletedTaskOrSchl)
                TaskOrScheduleChanged?.Invoke();
        }

        private void FoldSelected()
        {
            foreach (var l in outlinePanel.GetSelectedLines())
                if (l.Expanded) outlinePanel.ExpandCollapseInPlace(l);
        }

        private void ExpandSelected()
        {
            foreach (var l in outlinePanel.GetSelectedLines())
                if (!l.Expanded) outlinePanel.ExpandCollapseInPlace(l);
        }

        internal void CopySelected()
        {
            copiedLines.Clear();
            var sel = outlinePanel.GetSelectedLines();
            foreach (var line in sel)
            {
                var clone = line.Clone();
                CopyChildren(clone.GUID, line.GUID);
                copiedLines.Add(clone);
            }

            if (copiedLines.Count > 0)
            {
                try { Clipboard.SetText(JsonConvert.SerializeObject(copiedLines)); }
                catch { }
            }
        }

        private void CopyChildren(string newParentGUID, string oldParentGUID)
        {
            var children = outlinePanel.GetAllLines().Where(l => l.ParentGUID == oldParentGUID).OrderBy(l => l.Ordering);
            foreach (var child in children)
            {
                var clone = child.Clone();
                clone.GUID = Guid.NewGuid().ToString();
                clone.ParentGUID = newParentGUID;
                copiedLines.Add(clone);
                CopyChildren(clone.GUID, child.GUID);
            }
        }

        internal void PasteCopied()
        {
            var pasteLines = TryGetFromClipboard() ?? copiedLines;
            if (pasteLines.Count == 0) return;

            var sel = outlinePanel.GetSelectedLines().FirstOrDefault();
            string parentGUID = sel?.GUID ?? "";
            int baseOrdering = outlinePanel.GetAllLines().Count(l => l.ParentGUID == parentGUID);

            var guidMap = new Dictionary<string, string>();
            var newLines = new List<OutlineLine>();
            foreach (var line in pasteLines)
            {
                var clone = line.Clone();
                string oldGUID = clone.GUID;
                clone.GUID = Guid.NewGuid().ToString();
                guidMap[oldGUID] = clone.GUID;
                newLines.Add(clone);
            }

            foreach (var line in newLines)
            {
                if (guidMap.ContainsKey(line.ParentGUID))
                    line.ParentGUID = guidMap[line.ParentGUID];
                else
                {
                    line.ParentGUID = parentGUID;
                    line.Ordering = baseOrdering++;
                    int levelDelta = line.Level - (pasteLines.Min(l => l.Level));
                    line.Level = (sel?.Level ?? 0) + 1 + levelDelta;
                }
            }

            outlinePanel.GetAllLines().AddRange(newLines);
            outlinePanel.RefreshLayout();
            btnSaveMenu.Enabled = true;
        }

        private List<OutlineLine> TryGetFromClipboard()
        {
            try
            {
                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text)) return null;
                return JsonConvert.DeserializeObject<List<OutlineLine>>(text);
            }
            catch { return null; }
        }

        private void AdjustProgress(int delta)
        {
            foreach (var line in outlinePanel.GetSelectedLines())
            {
                if (line.ProgressPercent > 0)
                {
                    int newPercent = Math.Max(0, Math.Min(100, line.ProgressPercent + delta));
                    line.ProgressPercent = newPercent;
                    line.Text = System.Text.RegularExpressions.Regex.Replace(line.Text, @"\[(\d+)%\]", "[" + newPercent + "%]");
                }
                else if (line.Text.IndexOf("$DDLI$>", StringComparison.OrdinalIgnoreCase) >= 0
                    || line.Text.IndexOf("Date:", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    AdjustDate(line, delta > 0 ? 1 : -1);
                }
            }
            outlinePanel.RefreshAllRowDisplays();
            btnSaveMenu.Enabled = true;
        }

        private void AdjustDate(OutlineLine line, int dayDelta)
        {
            string dateKey = line.Text.StartsWith("$DDLI$>", StringComparison.OrdinalIgnoreCase) ? "$DDLI$>"
                : line.Text.StartsWith("Date:", StringComparison.OrdinalIgnoreCase) ? "Date:"
                : "date:";
            string dateStr = line.Text.Substring(dateKey.Length).Split(' ')[0];
            string[] parts = dateStr.Split('.');
            if (parts.Length == 3
                && int.TryParse(parts[0], out int y)
                && int.TryParse(parts[1], out int m)
                && int.TryParse(parts[2], out int d))
            {
                var dt = new DateTime(y, m, d).AddDays(dayDelta);
                line.Text = dateKey + " " + dt.ToString("yyyy.MM.dd");
            }
        }

        private void SetProgress(int percent)
        {
            foreach (var line in outlinePanel.GetSelectedLines())
            {
                line.ProgressPercent = percent;
                string text = line.Text;
                if (percent > 0)
                {
                    text = System.Text.RegularExpressions.Regex.Replace(text, @"\[(\d+)%\]", "[" + percent + "%]");
                    if (!System.Text.RegularExpressions.Regex.IsMatch(text, @"\[\d+%\]"))
                        text = text.TrimEnd() + " [" + percent + "%]";
                }
                else
                {
                    text = System.Text.RegularExpressions.Regex.Replace(text, @"\s*\[\d+%\]\s*", "").Trim();
                }
                line.Text = text;
            }
            outlinePanel.RefreshAllRowDisplays();
            btnSaveMenu.Enabled = true;
        }

        private void RotateLabel(int direction)
        {
            if (NoteColors == null || NoteColors.Count == 0) return;
            var labels = NoteColors.Select(nc => nc.Keyword).ToList();

            foreach (var line in outlinePanel.GetSelectedLines())
            {
                var matches = System.Text.RegularExpressions.Regex.Matches(line.Text, @"\[([^\]]+)\]");
                if (matches.Count > 0)
                {
                    int matchIdx = -1;
                    string currentLabel = null;
                    for (int i = 0; i < matches.Count; i++)
                    {
                        string kw = matches[i].Groups[1].Value;
                        int li = labels.FindIndex(l => l == kw);
                        if (li >= 0) { matchIdx = i; currentLabel = kw; break; }
                    }
                    if (matchIdx >= 0)
                    {
                        int oldIdx = labels.FindIndex(l => l == currentLabel);
                        int newIdx = (oldIdx + direction + labels.Count) % labels.Count;
                        line.Text = line.Text.Replace("[" + currentLabel + "]", "[" + labels[newIdx] + "]");
                    }
                }
                else if (direction > 0)
                {
                    line.Text = line.Text + " [" + labels[0] + "]";
                }
            }
            outlinePanel.RefreshAllRowDisplays();
            btnSaveMenu.Enabled = true;
        }

        internal void ToggleFormatTag(string tag)
        {
            if (IsReadOnly) return;
            var selected = outlinePanel.GetSelectedLines();
            if (selected.Count == 0) return;

            foreach (var line in selected)
            {
                if (line.IsMetaNode || line.IsMetaSectionHeader) continue;
                if (line.Text.Contains(tag))
                    line.Text = line.Text.Replace(tag, "");
                else
                    line.Text = tag + line.Text;
            }
            outlinePanel.RefreshAllRowDisplays();
            IsDirty = true;
            ContentModified?.Invoke();
        }

        private void OnLineClicked(OutlineLine line)
        {
        }

        private void OnTagCheckToggled(OutlineLine line)
        {
            OnTextEdited(line);
            outlinePanel.RefreshRowDisplay(line);
            LiteratureTagToggled?.Invoke();
        }

        public void HandleGoto()
        {
            var line = outlinePanel.GetSelectedLines().FirstOrDefault();
            if (line == null) return;

            if (line.Text.StartsWith("$LINK$>"))
            {
                string link = line.MetaValue ?? line.Text.Substring(7);
                int atIdx = link.IndexOf('@');
                if (atIdx > 0) link = link.Substring(0, atIdx);
                OpenUrl?.Invoke(link);
                return;
            }

            if (line.Text.StartsWith("$LITR$>"))
            {
                string title = line.MetaValue ?? line.Text.Substring(7);
                OpenLiteratureByTitle?.Invoke(title);
                return;
            }

            if (line.Text.StartsWith("$NOTE$>"))
            {
                // 普通内容节点的 $NOTE$> 引用（MetaType == None 时不会进入 NoteRef case）
                string noteRef = line.MetaValue ?? line.Text.Substring(7);
                var parts = noteRef.Split('@');
                if (parts.Length >= 2)
                {
                    var dateParts = parts[0].Split('.');
                    if (dateParts.Length == 3 &&
                        int.TryParse(dateParts[0], out int yr) &&
                        int.TryParse(dateParts[1], out int mo) &&
                        int.TryParse(dateParts[2], out int dy))
                    {
                        try
                        {
                            DateTime date = new DateTime(yr, mo, dy);
                            var note = G.glb.lstNote.Find(o => o.Created == date && o.Topic == parts[1]);
                            if (note != null) OpenNoteByGUID?.Invoke(note.GUID);
                            else MessageBox.Show("Note not found");
                        }
                        catch { MessageBox.Show("Invalid date in note link"); }
                    }
                    else MessageBox.Show("Incorrect Note Format, use $NOTE$>YYYY.MM.DD@NoteName");
                }
                else
                {
                    var topicNote = G.glb.lstNote.Find(o => o.Topic == noteRef);
                    if (topicNote != null)
                        OpenNoteByGUID?.Invoke(topicNote.GUID);
                    else if (noteRef == "SysNote: Diary")
                        OpenDiary?.Invoke(DateTime.Today);
                    else
                        MessageBox.Show("Note '" + noteRef + "' not found");
                }
                return;
            }

            if (line.Text.StartsWith("$FUNC$>"))
            {
                // 普通内容节点的 $FUNC$> 引用（MetaType == None 时不会进入 FuncRef case）
                string funcTopic = line.MetaValue ?? line.Text.Substring(7);
                var funcNote = G.glb.lstNote.Find(o => o.Topic == funcTopic);
                if (funcNote != null)
                    OpenNoteByGUID?.Invoke(funcNote.GUID);
                else if (funcTopic == "SysNote: Diary")
                    OpenDiary?.Invoke(DateTime.Today);
                else if (funcTopic == "SysNote: Literature Review")
                    OpenLiteratureReviewByGUID?.Invoke("__LIST__");
                else
                    MessageBox.Show("SysNote '" + funcTopic + "' not found");
                return;
            }

            if (line.Text.StartsWith("$LREV$>"))
            {
                string lrevRef = line.MetaValue ?? line.Text.Substring(7);
                var parts = lrevRef.Split('@');
                if (parts.Length >= 2)
                {
                    var dateParts = parts[0].Split('.');
                    if (dateParts.Length == 3 &&
                        int.TryParse(dateParts[0], out int yr) &&
                        int.TryParse(dateParts[1], out int mo) &&
                        int.TryParse(dateParts[2], out int dy))
                    {
                        try
                        {
                            DateTime date = new DateTime(yr, mo, dy);
                            var rev = G.glb.lstLiteratureReview.Find(o => o.Created.Date == date && o.Topic == parts[1]);
                            if (rev != null) OpenLiteratureReviewByGUID?.Invoke(rev.GUID);
                            else MessageBox.Show("Literature Review not found");
                        }
                        catch { MessageBox.Show("Invalid date in LREV link"); }
                    }
                    else MessageBox.Show("Incorrect LREV Format, use $LREV$>YYYY.MM.DD@Topic");
                }
                return;
            }

            switch (line.MetaType)
            {
                case NodeMetaType.Literature:
                    string litTitle = line.MetaValue ?? line.Text;
                    OpenLiteratureByTitle?.Invoke(litTitle);
                    break;
                case NodeMetaType.NoteRef:
                    string noteRef = line.MetaValue ?? line.Text.Substring(line.Text.StartsWith("$NOTE$>") ? 7 : 0);
                    var parts = noteRef.Split('@');
                    if (parts.Length >= 2)
                    {
                        var dateParts = parts[0].Split('.');
                        if (dateParts.Length == 3 &&
                            int.TryParse(dateParts[0], out int yr) &&
                            int.TryParse(dateParts[1], out int mo) &&
                            int.TryParse(dateParts[2], out int dy))
                        {
                            try
                            {
                                DateTime date = new DateTime(yr, mo, dy);
                                var note = G.glb.lstNote.Find(o => o.Created == date && o.Topic == parts[1]);
                                if (note != null)
                                    OpenNoteByGUID?.Invoke(note.GUID);
                                else
                                    MessageBox.Show("Note not found");
                            }
                            catch { MessageBox.Show("Invalid date in note link"); }
                        }
                        else MessageBox.Show("Incorrect Note Format, use $NOTE$>YYYY.MM.DD@NoteName");
                    }
                    else
                    {
                        var topicNote = G.glb.lstNote.Find(o => o.Topic == noteRef);
                        if (topicNote != null)
                            OpenNoteByGUID?.Invoke(topicNote.GUID);
                        else if (noteRef == "SysNote: Diary")
                            OpenDiary?.Invoke(DateTime.Today);
                        else
                            MessageBox.Show("Note '" + noteRef + "' not found");
                    }
                    break;
                case NodeMetaType.FuncRef:
                    string funcTopic = line.MetaValue ?? line.Text.Substring(line.Text.StartsWith("$FUNC$>") ? 7 : 0);
                    var funcNote = G.glb.lstNote.Find(o => o.Topic == funcTopic);
                    if (funcNote != null)
                        OpenNoteByGUID?.Invoke(funcNote.GUID);
                    else if (funcTopic == "SysNote: Diary")
                        OpenDiary?.Invoke(DateTime.Today);
                    else if (funcTopic == "SysNote: Literature Review")
                        OpenLiteratureReviewByGUID?.Invoke("__LIST__");
                    else
                        MessageBox.Show("Note '" + funcTopic + "' not found");
                    break;
                case NodeMetaType.LiteratureReview:
                    // Handled by $LREV$> prefix check above
                    break;
                case NodeMetaType.Jump:
                    string target = line.MetaValue ?? line.Text;
                    var found = outlinePanel.GetAllLines().Find(l => l.Text.Contains(target));
                    if (found != null) outlinePanel.SelectLine(found.GUID);
                    break;
            }
        }

        private void NavigateSelection(int direction) { outlinePanel.ScrollVertical(direction > 0); }

        private void RestorePreviousSelection()
        {
            if (!string.IsNullOrEmpty(previousSelectedGUID))
                outlinePanel.SelectLine(previousSelectedGUID);
        }

        private void EditSelected()
        {
            var sel = outlinePanel.GetSelectedLines().FirstOrDefault();
            if (sel != null)
            {
                foreach (Control c in outlinePanel.Controls[0].Controls)
                    if (c is OutlineRow ow && (string)ow.Tag == sel.GUID) { ow.BeginEdit(); break; }
            }
        }

        private void RemoveChildren() { outlinePanel.RemoveChildren(); btnSaveMenu.Enabled = true; }

        private void RemoveLayer() { outlinePanel.RemoveLayer(); btnSaveMenu.Enabled = true; }

        internal void CopyJumpNode()
        {
            var sel = outlinePanel.GetSelectedLines().FirstOrDefault();
            if (sel == null) return;
            Clipboard.SetText(sel.Text);
            MessageBox.Show("Copied jump node");
        }

        private void ToggleDisplayMode()
        {
            if (outlinePanel.IsReadOnly) return;
            showRawMeta = !showRawMeta;
            tsmToggleDisplay.Text = showRawMeta ? "Meta 模式 (&Y)" : "Icon 模式 (&Y)";
            outlinePanel.IconDisplayMode = !showRawMeta;
            outlinePanel.RefreshAllRowDisplays();
        }

        #endregion

        #region Task / Schedule Parsing (Static)

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

        private bool IsChildOfTaskNode(OutlineLine line)
        {
            if (line == null || string.IsNullOrEmpty(line.ParentGUID)) return false;
            var parent = outlinePanel.GetAllLines().Find(l => l.GUID == line.ParentGUID);
            return parent != null && parent.MetaType == NodeMetaType.Task;
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

        public static DateTime ParseDdlDate(string text)
        {
            if (string.IsNullOrEmpty(text)) return DateTime.MinValue;
            string t = text.StartsWith("$DDLI$>", StringComparison.OrdinalIgnoreCase) ? text.Substring(7)
                : text.StartsWith("date:", StringComparison.OrdinalIgnoreCase) ? text.Substring(5) : text;
            int atIdx = t.IndexOf('@');
            if (atIdx < 0) return DateTime.MinValue;
            var match = System.Text.RegularExpressions.Regex.Match(t.Substring(0, atIdx), @"^(\d{4}\.\d{1,2}\.\d{1,2})$");
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

        public static string[] ParseWeeklyDays(string taskText)
        {
            if (string.IsNullOrEmpty(taskText)) return new string[0];
            var match = System.Text.RegularExpressions.Regex.Match(taskText, @"@\{([^}]+)\}\s*$");
            if (!match.Success) return new string[0];
            return match.Groups[1].Value.Split(',').Select(d => d.Trim()).ToArray();
        }

        public static string StripWeeklySuffix(string taskText)
        {
            if (string.IsNullOrEmpty(taskText)) return taskText;
            var match = System.Text.RegularExpressions.Regex.Match(taskText, @"@\{[^}]+\}\s*$");
            if (!match.Success) return taskText;
            return taskText.Substring(0, match.Index).TrimEnd();
        }

        #endregion

        #region Label / Color

        public Dictionary<string, Color> BuildLabelColorMap()
        {
            var map = new Dictionary<string, Color>();
            if (NoteColors != null)
                foreach (var nc in NoteColors)
                    map[nc.Keyword] = _plotCalc.GetColor(nc.Color);
            return map;
        }

        public Dictionary<string, Color> BuildLabelForeColorMap()
        {
            var map = new Dictionary<string, Color>();
            if (NoteColors != null)
                foreach (var nc in NoteColors)
                    map[nc.Keyword] = (nc.Color == "Red" || nc.Color == "Green" || nc.Color == "Blue"
                        || nc.Color == "DarkGreen" || nc.Color == "Brown") ? Color.White : Color.Black;
            return map;
        }

        public void ApplyLabelColorsToRows()
        {
            outlinePanel.LabelColors = BuildLabelColorMap();
            outlinePanel.LabelForeColors = BuildLabelForeColorMap();
        }

        public void RebuildAllContentLabels()
        {
            var labelColors = BuildLabelColorMap();
            outlinePanel.LabelColors = labelColors;
            outlinePanel.LabelForeColors = BuildLabelForeColorMap();

            var allLines = outlinePanel.GetAllLines();
            foreach (var line in allLines)
            {
                if (line.IsMetaNode) continue;
                line.LabelKeywords = new List<string>();
                var matches = System.Text.RegularExpressions.Regex.Matches(line.Text, @"\[([^\]]+)\]");
                foreach (System.Text.RegularExpressions.Match m in matches)
                {
                    string kw = m.Groups[1].Value;
                    if (labelColors.ContainsKey(kw)) line.LabelKeywords.Add(kw);
                }
            }
        }

        private Color GetLineColor(OutlineLine line)
        {
            if (line.LabelKeywords != null && line.LabelKeywords.Count > 0)
            {
                var labelColors = BuildLabelColorMap();
                if (labelColors.TryGetValue(line.LabelKeywords[0], out var c)) return c;
            }
            return Color.FromArgb(100, 100, 100);
        }

        private Color GetTaskColor(OutlineLine line)
        {
            var allLines = outlinePanel.GetAllLines();
            var current = line;
            while (current != null)
            {
                if (current.LabelKeywords != null && current.LabelKeywords.Count > 0)
                    return GetLineColor(current);
                if (string.IsNullOrEmpty(current.ParentGUID)) break;
                current = allLines.Find(l => l.GUID == current.ParentGUID);
            }
            return Color.FromArgb(100, 100, 100);
        }

        #endregion

        #region Helpers

       public void UpdateModifiedNode(OutlineLine changedLine)
        {
            if (changedLine == null) return;

            var allLines = outlinePanel.GetAllLines();
            var current = changedLine;
            while (current != null)
            {
                var siblings = allLines.Where(l => l.ParentGUID == current.ParentGUID).ToList();
                foreach (var sib in siblings)
                {
                    string t = sib.Text ?? "";
                    string prefix = null;
                    if (t.Contains("modified: ")) prefix = "modified: ";
                    else if (t.Contains("Modified: ")) prefix = "Modified: ";
                    else if (t.Contains("MODIFIED: ")) prefix = "MODIFIED: ";

                    if (prefix != null)
                    {
                        sib.Text = prefix + DateTime.Now.ToString("F");
                        outlinePanel.RefreshRowDisplay(sib);
                        break;
                    }
                }
                current = allLines.Find(l => l.GUID == current.ParentGUID);
            }
        }

        public void RefreshModifiedTimestamp()
        {
            var allLines = outlinePanel.GetAllLines();
            var rootLine = allLines.Find(l => l.GUID == "__ROOT__");
            if (rootLine == null) return;

            var rootChildren = allLines.Where(l => l.ParentGUID == "__ROOT__").ToList();
            foreach (var sib in rootChildren)
            {
                string t = sib.Text ?? "";
                if (t.StartsWith("modified: ") || t.StartsWith("Modified: ") || t.StartsWith("MODIFIED: "))
                {
                    int ci = t.IndexOf(": ");
                    sib.Text = t.Substring(0, ci + 2) + DateTime.Now.ToString("F");
                    outlinePanel.RefreshRowDisplay(sib);
                    return;
                }
            }
        }

        public string RootText
        {
            get
            {
                return outlinePanel.GetAllLines()
                    .Where(l => !l.IsMetaNode && !l.IsMetaSectionHeader && l.Level == 0)
                    .Select(l => l.Text)
                    .FirstOrDefault() ?? "";
            }
        }

        public void CollectDescendants(List<OutlineLine> allLines, string parentGUID, List<OutlineLine> result)
        {
            foreach (var line in allLines.Where(l => l.ParentGUID == parentGUID).OrderBy(l => l.Ordering))
            {
                result.Add(line);
                CollectDescendants(allLines, line.GUID, result);
            }
        }

        #region Note Rename

        private static readonly HashSet<string> SysNoteNames = new HashSet<string>
        {
            "SysNote: Menu",
            "SysNote: Note Archive", "SysNote: Task History", "SysNote: Literature Review",
            "SysNote: Calendar", "SysNote: Diary"
        };

        private static bool IsSysNoteTopic(string topic)
        {
            return SysNoteNames.Contains(topic) || (topic ?? "").StartsWith("SysNote:");
        }

        private void TryRenameSelectedNote()
        {
            var sel = outlinePanel.GetSelectedLines().FirstOrDefault();
            if (sel == null) return;
            if (sel.MetaType == NodeMetaType.NoteRef && !string.IsNullOrEmpty(sel.MetaValue)
                && !IsSysNoteTopic(sel.MetaValue))
            {
                TryRenameNote(sel);
            }
        }

        private void TryRenameNote(OutlineLine noteRefLine)
        {
            // Parse from Text: $NOTE$>yyyy.MM.dd@Topic
            string topic = noteRefLine.MetaValue ?? "";
            DateTime tagTime = DateTime.MinValue;
            string text = noteRefLine.Text ?? "";
            int atIdx = text.IndexOf('@');
            if (atIdx >= 0 && text.StartsWith("$NOTE$>"))
            {
                string datePart = text.Substring("$NOTE$>".Length, atIdx - "$NOTE$>".Length);
                DateTime parsed = TryParseDate(datePart);
                if (parsed != DateTime.MinValue)
                    tagTime = parsed;
            }

            var note = G.glb.lstNote.Find(n =>
                n.Topic == topic && (tagTime == DateTime.MinValue || n.Created.Date == tagTime.Date));
            if (note == null) return;

            string oldTopic = note.Topic;
            string noteGUID = note.GUID;

            string newName = Interaction.InputBox("New Name", "Rename Note", oldTopic, 300, 300);
            if (string.IsNullOrWhiteSpace(newName) || newName == oldTopic) return;
            if (IsSysNoteTopic(newName) || newName.StartsWith("SysNote:"))
            {
                MessageBox.Show("Cannot use SysNote: prefix", "Rename", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check: same date + same topic?
            var conflictNote = G.glb.lstNote.Find(n =>
                n.Created.Date == note.Created.Date && n.Topic == newName && n.GUID != noteGUID);
            if (conflictNote != null)
            {
                MessageBox.Show("Name already exists on this date: " + newName, "Rename", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RenameNote(noteGUID, oldTopic, newName, note.Created);
        }

        private void RenameNote(string noteGUID, string oldTopic, string newTopic, DateTime tagTime)
        {
            // 1. Move .md file
            string oldPath = MarkdownNoteConverter.MakeNotePath(tagTime, oldTopic);
            string newPath = MarkdownNoteConverter.MakeNotePath(tagTime, newTopic);
            if (File.Exists(oldPath))
                File.Move(oldPath, newPath);

            // 2. Update NoteDocument.Topic in memory
            var note = G.glb.lstNote.Find(n => n.GUID == noteGUID);
            if (note != null) note.Topic = newTopic;

            // 3. Update all $NOTE$> cross-references in all .md files
            string oldRef = "$NOTE$>" + tagTime.ToString("yyyy.MM.dd") + "@" + oldTopic;
            string newRef = "$NOTE$>" + tagTime.ToString("yyyy.MM.dd") + "@" + newTopic;
            string[] dirs = { DataFileHelper.NotesDir, DataFileHelper.DiariesDir, DataFileHelper.LitsDir, DataFileHelper.LiteratureReviewDir };
            foreach (var dir in dirs)
            {
                if (!Directory.Exists(dir)) continue;
                foreach (var file in Directory.GetFiles(dir, "*.md"))
                {
                    try
                    {
                        string content = File.ReadAllText(file, Encoding.UTF8);
                        if (content.Contains(oldRef))
                        {
                            string updated = content.Replace(oldRef, newRef);
                            DataFileHelper.AtomicWriteText(file, updated);
                        }
                    }
                    catch { }
                }
            }

            // 4. Update _index.json
            DataStore.SaveNoteIndex();

            // 5. Refresh current tree - update note refs in displayed tree
            UpdateNoteRefsInTree(oldTopic, newTopic, tagTime);

            // 6. Fire event
            NoteRenamed?.Invoke(oldTopic, newTopic, tagTime);
        }

        public void UpdateNoteRefsInTree(string oldTopic, string newTopic, DateTime tagTime)
        {
            string oldRef = "$NOTE$>" + tagTime.ToString("yyyy.MM.dd") + "@" + oldTopic;
            string newRef = "$NOTE$>" + tagTime.ToString("yyyy.MM.dd") + "@" + newTopic;

            var allLines = outlinePanel.GetAllLines();
            foreach (var line in allLines)
            {
                if (line.Text == oldRef)
                {
                    line.Text = newRef;
                    line.MetaValue = newTopic;
                    outlinePanel.RefreshRowDisplay(line);
                }
            }
        }

        #endregion

        #endregion
    }
}
