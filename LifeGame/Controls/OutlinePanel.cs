using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace LifeGame
{
    /// <summary>Outline 编辑器主面板 - 替代 TreeView</summary>
    public class OutlinePanel : UserControl
    {
        private Panel scrollPanel;
        private List<OutlineLine> allLines = new List<OutlineLine>();
        private List<OutlineRow> visibleRows = new List<OutlineRow>();
        private HashSet<string> selectedGUIDs = new HashSet<string>();
        private Font baseFont;
        private OutlineLine rootLine; // Level 0 root node (non-deletable/non-editable)
        private OutlineLine metaRootLine; // Meta Level 0 sibling (before rootLine, non-movable)

        // Undo/Redo
        private List<string> undoStack = new List<string>();
        private List<string> redoStack = new List<string>();
        private const int MAX_UNDO = 50;
        private bool isUndoing = false;
        private string _preEditSnapshot; // snapshot taken before BeginEdit, pushed on commit

        // Color scheme
        public Color SelectionColor = Theme.LightTheme.Selection;
        public Dictionary<string, Color> LabelColors = new Dictionary<string, Color>();
        public Dictionary<string, Color> LabelForeColors = new Dictionary<string, Color>();
        public bool IconDisplayMode { get; set; } = true;
        public bool IsReadOnly { get; set; } = false;
        public bool AllowEditNonMeta { get; set; } = false;
        public bool BlockMetaEdit { get; set; } = false; // 禁止 Meta 节点编辑（Menu 用）
        public bool IsEditing => visibleRows.Any(r => r.IsEditing);

        // 事件
        public event Action<List<OutlineLine>> SelectionChanged;
        public event Action<OutlineLine> TextEdited;
        public event Action LinesChanged;
        public event Action<OutlineLine, Point> LineRightClicked;
        public event Action<OutlineLine> LineClicked;
        public event Action<OutlineLine> TagCheckToggled;

        private static readonly Color DefaultPanelBg = Color.FromArgb(252, 250, 245);

        public OutlinePanel()
        {
            this.DoubleBuffered = true;
            baseFont = new Font("Segoe UI", 10f, FontStyle.Regular);

            var bg = Theme.Current?.PanelBackground ?? DefaultPanelBg;
            scrollPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = bg
            };
            typeof(Panel).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(scrollPanel, true, null);
            this.BackColor = bg;
            this.Controls.Add(scrollPanel);

            this.KeyDown += OutlinePanel_KeyDown;
            this.AllowDrop = true;
            this.SetStyle(ControlStyles.Selectable, true);
        }

        /// <summary>拦截方向键，阻止子 Panel (AutoScroll) 将其解释为滚动命令，同时提供键盘导航</summary>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            Keys key = keyData & Keys.KeyCode;
            if (key == Keys.Up || key == Keys.Down || key == Keys.Left || key == Keys.Right)
            {
                // 编辑模式下，让 TextBox 正常处理方向键
                if (this.ActiveControl is TextBox && this.ActiveControl.Parent is OutlineRow)
                    return base.ProcessDialogKey(keyData);
                if (IsEditing)
                    return base.ProcessDialogKey(keyData);

                bool ctrl = (keyData & Keys.Control) == Keys.Control;
                bool alt = (keyData & Keys.Alt) == Keys.Alt;
                bool shift = (keyData & Keys.Shift) == Keys.Shift;

                if ((ctrl || alt) && (key == Keys.Up || key == Keys.Down))
                {
                    // Ctrl/Alt + Up/Down: 移动行
                    if (key == Keys.Up) MoveUpSelected();
                    else MoveDownSelected();
                }
                else if (shift && (key == Keys.Up || key == Keys.Down))
                {
                    // Shift + Up/Down: 扩展选择
                    ExtendSelectionVertical(key == Keys.Down);
                }
                else if (key == Keys.Up || key == Keys.Down)
                {
                    NavigateVertical(key == Keys.Down);
                }
                else
                {
                    NavigateHorizontal(key == Keys.Right);
                }
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void ExtendSelectionVertical(bool down)
        {
            if (visibleRows.Count == 0) return;
            int curIdx = 0;
            if (selectedGUIDs.Count > 0)
            {
                curIdx = visibleRows.FindIndex(r => selectedGUIDs.Contains(r.Data.GUID));
                if (curIdx < 0) curIdx = 0;
            }
            int newIdx = down ? Math.Min(curIdx + 1, visibleRows.Count - 1)
                              : Math.Max(curIdx - 1, 0);
            if (selectedGUIDs.Add(visibleRows[newIdx].Data.GUID))
            {
                visibleRows[newIdx].SetSelected(true);
                SelectionChanged?.Invoke(GetSelectedLines());
            }
        }

        /// <summary>公开方法，供外部（frmInfoNoteV2）调用</summary>
        public void ScrollVertical(bool down)
        {
            NavigateVertical(down);
        }

        private void NavigateVertical(bool down)
        {
            if (visibleRows.Count == 0) return;

            // 找到当前选中行索引
            string prevGuid = null;
            int curIdx = 0;
            if (selectedGUIDs.Count > 0)
            {
                prevGuid = selectedGUIDs.First();
                int found = visibleRows.FindIndex(r => r.Data.GUID == prevGuid);
                if (found >= 0) curIdx = found;
            }

            // 计算新索引
            int newIdx = down ? Math.Min(curIdx + 1, visibleRows.Count - 1)
                              : Math.Max(curIdx - 1, 0);
            if (newIdx == curIdx && prevGuid != null) return;

            // 更新选中状态
            if (prevGuid != null)
            {
                var oldRow = visibleRows.Find(r => r.Data.GUID == prevGuid);
                oldRow?.SetSelected(false);
            }
            var newRow = visibleRows[newIdx];
            selectedGUIDs.Clear();
            selectedGUIDs.Add(newRow.Data.GUID);
            newRow.SetSelected(true);
            SelectionChanged?.Invoke(GetSelectedLines());

            // 确保选中行在可视区域内
            EnsureRowVisible(newRow);
        }

        private void EnsureRowVisible(OutlineRow row)
        {
            // 使用内置方法确保控件在可视区域内
            this.BeginInvoke(new Action(() =>
            {
                scrollPanel.ScrollControlIntoView(row);
            }));
        }

        private void NavigateHorizontal(bool right)
        {
            if (selectedGUIDs.Count == 0) return;
            var line = allLines.Find(l => selectedGUIDs.Contains(l.GUID));
            if (line == null) return;

            bool hasChildren = allLines.Any(l => l.ParentGUID == line.GUID);
            if (hasChildren)
            {
                if (right && !line.Expanded)
                {
                    ExpandCollapseInPlace(line);
                }
                else if (!right && line.Expanded)
                {
                    ExpandCollapseInPlace(line);
                }
                else if (right)
                {
                    // 已展开，跳到第一个子节点
                    var firstChild = allLines.Where(l => l.ParentGUID == line.GUID)
                        .OrderBy(l => l.Ordering).FirstOrDefault();
                    if (firstChild != null)
                    {
                        SwitchSelectionTo(line.GUID, firstChild.GUID);
                    }
                }
                else
                {
                    // 已折叠，跳到父节点
                    GoToParent(line);
                }
            }
            else
            {
                // 无子节点
                if (right)
                {
                    // 跳到下一个可见行
                    var vis = GetVisibleLines();
                    int curIdx = vis.FindIndex(l => l.GUID == line.GUID);
                    if (curIdx >= 0 && curIdx < vis.Count - 1)
                    {
                        SwitchSelectionTo(line.GUID, vis[curIdx + 1].GUID);
                    }
                }
                else
                {
                    GoToParent(line);
                }
            }
        }

        private void GoToParent(OutlineLine line)
        {
            if (string.IsNullOrEmpty(line.ParentGUID)) return;
            var parent = allLines.Find(l => l.GUID == line.ParentGUID);
            if (parent != null)
            {
                SwitchSelectionTo(line.GUID, parent.GUID);
            }
        }

        /// <summary>精确切换选择从旧行到新行，不触发全局刷新，不改变滚动位置</summary>
        private void SwitchSelectionTo(string oldGuid, string newGuid)
        {
            if (oldGuid != null)
            {
                var oldRow = visibleRows.Find(r => r.Data.GUID == oldGuid);
                oldRow?.SetSelected(false);
            }
            selectedGUIDs.Clear();
            selectedGUIDs.Add(newGuid);
            var newRow = visibleRows.Find(r => r.Data.GUID == newGuid);
            newRow?.SetSelected(true);
            SelectionChanged?.Invoke(GetSelectedLines());
        }

        /// <summary>主题切换后调用，刷新自身及所有可见行的颜色</summary>
        public void ApplyTheme()
        {
            var bg = Theme.Current?.PanelBackground ?? DefaultPanelBg;
            this.BackColor = bg;
            scrollPanel.BackColor = bg;
            foreach (var row in visibleRows)
                row.ApplyThemeColors();
        }

        // ============ 数据加载 ============

        /// <summary>用扁平行列表加载数据。自动创建/保留根节点。</summary>
        public void LoadLines(List<OutlineLine> lines)
        {
            allLines = lines ?? new List<OutlineLine>();

            // 始终创建新根节点，不重用数据行
            rootLine = new OutlineLine
            {
                Text = "(Root)",
                GUID = "__ROOT__",
                Level = 0,
                ParentGUID = "",
                Expanded = true,
                Ordering = 0
            };
            allLines.Insert(0, rootLine);

            // Meta 根节点：如果已设置但不在 allLines 中，重新加入（LoadLines 会替换整个列表）
            if (metaRootLine != null && !allLines.Contains(metaRootLine))
            {
                metaRootLine.ParentGUID = ""; // 确保 Meta 根不被孤儿修复挂到 rootLine
                allLines.Insert(0, metaRootLine);
            }

            // 修复孤儿节点：将 ParentGUID 不存在的行重新挂到根节点下（跳过 Meta 根节点）
            var existingGUIDs = new HashSet<string>(allLines.Select(l => l.GUID));
            foreach (var line in allLines)
            {
                if (line == rootLine || line == metaRootLine) continue;
                if (string.IsNullOrEmpty(line.ParentGUID) || !existingGUIDs.Contains(line.ParentGUID))
                {
                    line.ParentGUID = rootLine.GUID;
                }
            }

            // 统一修复 MetaType：ParseOutlineBody 不会设置 MetaType，在此根据前缀推断
            foreach (var line in allLines)
            {
                if (line.MetaType != NodeMetaType.None || line.IsMetaNode) continue;
                var text = line.Text;
                if (string.IsNullOrEmpty(text)) continue;

                if (text.StartsWith("$NOTE$>"))
                {
                    line.MetaType = NodeMetaType.NoteRef;
                    line.MetaValue = text.Substring(7);
                }
                else if (text.StartsWith("$LINK$>"))
                {
                    line.MetaType = NodeMetaType.Link;
                    line.MetaValue = text.Substring(7);
                }
                else if (text.StartsWith("$LITR$>"))
                {
                    line.MetaType = NodeMetaType.Literature;
                    line.MetaValue = text.Substring(7);
                }
                else if (text.StartsWith("$FUNC$>"))
                {
                    line.MetaType = NodeMetaType.FuncRef;
                    line.MetaValue = text.Substring(7);
                }
                else if (text.StartsWith("$JUMP$>"))
                {
                    line.MetaType = NodeMetaType.Jump;
                    line.MetaValue = text.Substring(7);
                }
                else if (text.StartsWith("$TASK$>"))
                {
                    line.MetaType = NodeMetaType.Task;
                    line.MetaValue = text.Substring(7);
                    DetectProgressPercent(line, text);
                }
                else if (text.StartsWith("$SCHL$>"))
                {
                    line.MetaType = NodeMetaType.Schedule;
                    line.MetaValue = text.Substring(7);
                    DetectProgressPercent(line, text);
                }
                else if (text.StartsWith("$DDLI$>", StringComparison.OrdinalIgnoreCase))
                {
                    line.MetaType = NodeMetaType.Deadline;
                    line.MetaValue = text.StartsWith("$DDLI$>") ? text.Substring(7) : text;
                }
                else if (text.StartsWith("$LTAG$>") || text.StartsWith("☐ $LTAG$>") || text.StartsWith("☑ $LTAG$>"))
                {
                    line.MetaType = NodeMetaType.LiteratureTag;
                    string clean = text;
                    if (clean.StartsWith("☐ ")) clean = clean.Substring(2);
                    if (clean.StartsWith("☑ ")) clean = clean.Substring(2);
                    line.MetaValue = clean.StartsWith("$LTAG$>") ? clean.Substring(7) : clean;
                }
                else
                {
                    string lower = text.ToLower();
                    if (lower.StartsWith("date: "))
                    {
                        line.MetaType = NodeMetaType.Deadline;
                        int colonIdx = text.IndexOf(": ");
                        if (colonIdx > 0) line.MetaValue = text.Substring(colonIdx + 2).Trim();
                    }
                    else
                    {
                        DetectProgressPercent(line, text);
                    }
                }
            }

            // 重新计算所有行的 Level
            OutlineConverter.ComputeLevels(allLines);

            selectedGUIDs.Clear();
            RebuildVisibleRows();
        }

        /// <summary>设置根节点标题（Note名称等）</summary>
        public void SetRootTitle(string title)
        {
            if (rootLine != null)
                rootLine.Text = title;
        }

        /// <summary>获取根节点 GUID</summary>
        public string RootGUID => rootLine?.GUID;

        /// <summary>获取 Meta 根节点 GUID</summary>
        public string MetaRootGUID => metaRootLine?.GUID;

        /// <summary>设置 Meta 根节点</summary>
        public void SetMetaRoot(OutlineLine metaRoot)
        {
            metaRootLine = metaRoot;
            if (metaRootLine != null && !allLines.Contains(metaRootLine))
                allLines.Add(metaRootLine);
        }

        /// <summary>重新刷新布局（窗口大小改变后调用）</summary>
        public void RefreshLayout()
        {
            RebuildVisibleRows();
        }

        /// <summary>获取当前数据</summary>
        public List<OutlineLine> GetAllLines() => allLines;

        /// <summary>获取选中的行</summary>
        public List<OutlineLine> GetSelectedLines() =>
            allLines.Where(l => selectedGUIDs.Contains(l.GUID)).ToList();

        /// <summary>获取可见行（展开状态下的）</summary>
        public List<OutlineLine> GetVisibleLines()
        {
            var result = new List<OutlineLine>();
            if (rootLine == null) return result;

            var stack = new Stack<OutlineLine>();
            var visited = new HashSet<string>(); // 防止循环引用导致无限递归

            // Meta root 放在最前面（Stack 是 LIFO，后 push 先弹出）
            stack.Push(rootLine);
            if (metaRootLine != null)
                stack.Push(metaRootLine);

            while (stack.Count > 0)
            {
                var line = stack.Pop();
                string key = line.GUID ?? "\0";
                if (!visited.Add(key)) continue; // 已访问过，跳过（循环检测）
                result.Add(line);
                if (line.Expanded)
                {
                    var children = allLines.Where(l => l.ParentGUID == line.GUID)
                        .OrderBy(l => l.Ordering).ToList();
                    for (int i = children.Count - 1; i >= 0; i--)
                        stack.Push(children[i]);
                }
            }
            return result;
        }

        // ============ 行操作 ============

        /// <summary>添加新行（增量插入，不全局重绘）</summary>
        public OutlineLine AddLine(string text, OutlineLine parent = null, int index = -1)
        {
            PushUndoSnapshot();

            var line = new OutlineLine
            {
                Text = text,
                Level = parent != null ? parent.Level + 1 : 1,
                ParentGUID = parent?.GUID ?? (rootLine?.GUID ?? ""),
                Ordering = index >= 0 ? index : (parent != null
                    ? allLines.Count(l => l.ParentGUID == parent.GUID)
                    : allLines.Count(l => l.ParentGUID == (rootLine?.GUID ?? "")))
            };

            foreach (var sibling in allLines.Where(l => l.ParentGUID == line.ParentGUID && l.Ordering >= line.Ordering))
                sibling.Ordering++;

            allLines.Add(line);

            // 确保父节点展开
            if (parent != null && !parent.Expanded)
                parent.Expanded = true;

            InsertLineRow(line);
            if (parent != null)
            {
                var parentRow = visibleRows.Find(r => r.Data.GUID == parent.GUID);
                if (parentRow != null) parentRow.UpdateHasChildren(true);
            }
            SelectLine(line.GUID);
            LinesChanged?.Invoke();
            return line;
        }

        /// <summary>增量插入单行 row 到 visibleRows 的正确位置（放在父节点可见后代末尾）</summary>
        private void InsertLineRow(OutlineLine line)
        {
            var parent = allLines.Find(l => l.GUID == line.ParentGUID);
            int insertIndex = -1;
            if (parent != null)
            {
                int parentIdx = visibleRows.FindIndex(r => r.Data.GUID == parent.GUID);
                if (parentIdx >= 0)
                {
                    insertIndex = parentIdx + 1;
                    while (insertIndex < visibleRows.Count)
                    {
                        var r = visibleRows[insertIndex];
                        if (r.Data.Level <= parent.Level)
                            break;
                        insertIndex++;
                    }
                }
            }
            if (insertIndex < 0) insertIndex = visibleRows.Count;

            bool hasChildren = false;
            bool isRoot = line.Level == 0;
            var row = new OutlineRow(line, hasChildren, isRoot ? new Font(baseFont, FontStyle.Bold) : baseFont);
            row.Width = scrollPanel.ClientSize.Width > 0 ? scrollPanel.ClientSize.Width - 20 : 400;
            row.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            row.RowClicked += OnRowClicked;
            row.RowDoubleClicked += OnRowDoubleClicked;
            row.RowRightClicked += OnRowRightClicked;
            row.TextEditCommitted += OnTextEditCommitted;
            row.ExpandToggled += OnExpandToggled;
            row.TagCheckToggled += OnTagCheckToggled;
            row.Tag = line.GUID;
            row.SetIconDisplayMode(IconDisplayMode);
            row.SetAllowEditNonMeta(AllowEditNonMeta);
            row.SetBlockMetaEdit(BlockMetaEdit);
            if (line.LabelKeywords != null && line.LabelKeywords.Count > 0)
                row.SetLabelBadgeColors(LabelColors, LabelForeColors);
            row.SetSelected(false);

            if (insertIndex < visibleRows.Count)
            {
                row.Top = visibleRows[insertIndex].Top;
                visibleRows.Insert(insertIndex, row);
                scrollPanel.Controls.Add(row);
                int curY = insertIndex > 0 ? visibleRows[insertIndex - 1].Top + visibleRows[insertIndex - 1].Height : 0;
                for (int i = insertIndex; i < visibleRows.Count; i++)
                {
                    visibleRows[i].Top = curY;
                    curY += visibleRows[i].Height;
                }
            }
            else
            {
                row.Top = visibleRows.Count > 0
                    ? visibleRows[visibleRows.Count - 1].Top + visibleRows[visibleRows.Count - 1].Height
                    : 0;
                scrollPanel.Controls.Add(row);
                visibleRows.Add(row);
            }
        }

        /// <summary>添加新行并进入编辑状态，不重建全部 UI</summary>
        public OutlineLine AddLineInPlace(string text, OutlineLine parent = null)
        {
            PushUndoSnapshot();

            var line = new OutlineLine
            {
                Text = text,
                Level = parent != null ? parent.Level + 1 : 1,
                ParentGUID = parent?.GUID ?? (rootLine?.GUID ?? ""),
                Ordering = parent != null
                    ? allLines.Count(l => l.ParentGUID == parent.GUID)
                    : allLines.Count(l => l.ParentGUID == (rootLine?.GUID ?? ""))
            };

            foreach (var sibling in allLines.Where(l => l.ParentGUID == line.ParentGUID && l.Ordering >= line.Ordering))
                sibling.Ordering++;

            allLines.Add(line);

            if (parent != null && !parent.Expanded)
                parent.Expanded = true;

            InsertLineRow(line);

            if (parent != null)
            {
                var parentRow = visibleRows.Find(r => r.Data.GUID == parent.GUID);
                if (parentRow != null) parentRow.UpdateHasChildren(true);
            }

            selectedGUIDs.Clear();
            selectedGUIDs.Add(line.GUID);
            RefreshSelectionVisual();

            // 进入编辑状态
            var row = visibleRows.Find(r => r.Data.GUID == line.GUID);
            if (!IsReadOnly) row?.BeginEdit();

            LinesChanged?.Invoke();
            return line;
        }

        /// <summary>删除选中的行（根节点、Meta 根和 Meta 标题不可删）</summary>
        public void RemoveSelectedLines()
        {
            PushUndoSnapshot();

            var allToRemove = new HashSet<string>();
            foreach (var guid in selectedGUIDs)
            {
                var line = allLines.Find(l => l.GUID == guid);
                if (line != null && (line.Level == 0 || line.IsMetaSectionHeader)) continue;
                CollectDescendants(guid, allToRemove);
            }

            // 记录被删除前第一个选中行的位置，用于删除后选中下一行
            int fallbackIndex = -1;
            if (allToRemove.Count > 0)
            {
                var firstRemoved = allToRemove.First();
                fallbackIndex = visibleRows.FindIndex(r => r.Data.GUID == firstRemoved);
            }

            allLines.RemoveAll(l => allToRemove.Contains(l.GUID));
            selectedGUIDs.Clear();
            RemoveLinesInPlace(allToRemove);
            RefreshParentExpandIcons(allToRemove);

            // 选中被删行原来位置的下一行（或最后一行）
            if (fallbackIndex >= 0 && visibleRows.Count > 0)
            {
                if (fallbackIndex >= visibleRows.Count)
                    fallbackIndex = visibleRows.Count - 1;
                var nextLine = visibleRows[fallbackIndex].Data;
                selectedGUIDs.Add(nextLine.GUID);
                visibleRows[fallbackIndex].SetSelected(true);
            }

            LinesChanged?.Invoke();
            SelectionChanged?.Invoke(GetSelectedLines());
        }

        private void CollectDescendants(string parentGUID, HashSet<string> result)
        {
            result.Add(parentGUID);
            foreach (var child in allLines.Where(l => l.ParentGUID == parentGUID))
                CollectDescendants(child.GUID, result);
        }

        /// <summary>删除节点后，更新受影响的父节点的展开三角形图标</summary>
        private void RefreshParentExpandIcons(HashSet<string> removedGUIDs)
        {
            var parentsToCheck = new HashSet<string>();
            foreach (var guid in removedGUIDs)
            {
                var line = allLines.FirstOrDefault(l => l.GUID == guid);
                if (line != null && !string.IsNullOrEmpty(line.ParentGUID) && !removedGUIDs.Contains(line.ParentGUID))
                    parentsToCheck.Add(line.ParentGUID);
            }

            foreach (var parentGUID in parentsToCheck)
            {
                bool hasChildren = allLines.Any(l => l.ParentGUID == parentGUID);
                if (!hasChildren)
                {
                    var row = visibleRows.Find(r => r.Data.GUID == parentGUID);
                    if (row != null)
                    {
                        row.UpdateHasChildren(false);
                        // 如果父节点之前是展开状态，现在设为折叠
                        var parentLine = allLines.Find(l => l.GUID == parentGUID);
                        if (parentLine != null && parentLine.Expanded)
                            parentLine.Expanded = false;
                    }
                }
            }
        }

        /// <summary>删除选中节点的所有子节点</summary>
        public void RemoveChildren()
        {
            var toRemove = new HashSet<string>();
            foreach (var guid in selectedGUIDs)
            {
                var line = allLines.Find(l => l.GUID == guid);
                if (line.Level == 0 || line.IsMetaSectionHeader) continue;
                foreach (var child in allLines.Where(l => l.ParentGUID == guid))
                    CollectDescendants(child.GUID, toRemove);
            }
            allLines.RemoveAll(l => toRemove.Contains(l.GUID));
            RemoveLinesInPlace(toRemove);
            RefreshParentExpandIcons(toRemove);
            LinesChanged?.Invoke();
            SelectionChanged?.Invoke(GetSelectedLines());
        }

        /// <summary>删除选中节点及其子节点中所有文本匹配的行（用于删除层）</summary>
        public void RemoveLayer()
        {
            var selected = GetSelectedLines();
            if (selected.Count == 0) return;
            // 收集选中节点及其所有子节点
            var allToCheck = new HashSet<string>();
            foreach (var guid in selectedGUIDs)
            {
                var line = allLines.Find(l => l.GUID == guid);
                if (line.Level == 0 || line.IsMetaSectionHeader) continue; // 跳过根节点和 Meta 标题
                CollectDescendants(guid, allToCheck);
            }
            // 在 allToCheck 中找文本相同的行删除
            var toRemove = new HashSet<string>();
            foreach (var guid in allToCheck)
            {
                var line = allLines.Find(l => l.GUID == guid);
                if (line == null) continue;
                foreach (var other in allToCheck)
                {
                    var otherLine = allLines.Find(l => l.GUID == other);
                    if (otherLine != null && otherLine.Text == line.Text && otherLine.Level == line.Level)
                        toRemove.Add(other);
                }
            }
            allLines.RemoveAll(l => toRemove.Contains(l.GUID));
            selectedGUIDs.RemoveWhere(g => toRemove.Contains(g));
            RemoveLinesInPlace(toRemove);
            LinesChanged?.Invoke();
            SelectionChanged?.Invoke(GetSelectedLines());
        }

        /// <summary>
        /// 原地重排行：仅更新 visibleRows 顺序和各行 Top 坐标，不销毁/重建任何控件。
        /// 适用场景：上移/下移/缩进/减少缩进——可见行 GUID 集合不变，仅顺序或 Level 变化。
        /// </summary>
        public void RepositionInPlace()
        {
            int savedScrollY = -scrollPanel.AutoScrollPosition.Y;

            var newOrder = GetVisibleLines();
            var guidToRow = new Dictionary<string, OutlineRow>();
            foreach (var row in visibleRows)
                guidToRow[row.Data.GUID] = row;

            // 禁用 AutoScroll 防止改 Top 时滚动位置被 UpdateScrollBars 重置
            scrollPanel.AutoScroll = false;
            visibleRows.Clear();
            int y = 0;
            foreach (var line in newOrder)
            {
                OutlineRow row;
                if (guidToRow.TryGetValue(line.GUID, out row))
                {
                    row.Top = y;
                    row.SetIconDisplayMode(IconDisplayMode);
                    row.SetAllowEditNonMeta(AllowEditNonMeta);
                    row.SetBlockMetaEdit(BlockMetaEdit);
                    row.ApplyData();
                    if (line.LabelKeywords != null && line.LabelKeywords.Count > 0)
                        row.SetLabelBadgeColors(LabelColors, LabelForeColors);
                }
                else
                {
                    // 新增可见行（如 IndentSelected 展开父节点后出现子节点）
                    bool hasChildren = allLines.Any(l => l.ParentGUID == line.GUID);
                    bool isRoot = line.Level == 0;
                    row = new OutlineRow(line, hasChildren, isRoot ? new Font(baseFont, FontStyle.Bold) : baseFont);
                    row.Width = scrollPanel.ClientSize.Width > 0 ? scrollPanel.ClientSize.Width - 20 : 400;
                    row.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    row.RowClicked += OnRowClicked;
                    row.RowDoubleClicked += OnRowDoubleClicked;
                    row.RowRightClicked += OnRowRightClicked;
                    row.TextEditCommitted += OnTextEditCommitted;
                    row.ExpandToggled += OnExpandToggled;
                    row.TagCheckToggled += OnTagCheckToggled;
                    row.Top = y;
                    row.Tag = line.GUID;
                    row.SetIconDisplayMode(IconDisplayMode);
                    row.SetAllowEditNonMeta(AllowEditNonMeta);
                    row.SetBlockMetaEdit(BlockMetaEdit);
                    if (line.LabelKeywords != null && line.LabelKeywords.Count > 0)
                        row.SetLabelBadgeColors(LabelColors, LabelForeColors);
                    scrollPanel.Controls.Add(row);
                }
                visibleRows.Add(row);
                y += row.Height;
            }

            scrollPanel.AutoScroll = true;
            this.BeginInvoke(new Action(() =>
            {
                scrollPanel.AutoScrollPosition = new Point(0, savedScrollY);
            }));
            RefreshSelectionVisual();
            this.Focus();
        }

        /// <summary>增加缩进</summary>
        public void IndentSelected()
        {
            PushUndoSnapshot();

            foreach (var guid in selectedGUIDs.ToList())
            {
                var line = allLines.Find(l => l.GUID == guid);
                if (line == null || line.Level <= 0 || line.IsMetaNode) continue;

                var siblings = allLines.Where(l => l.ParentGUID == line.ParentGUID)
                    .OrderBy(l => l.Ordering).ToList();
                int idx = siblings.FindIndex(l => l.GUID == guid);
                if (idx <= 0) continue;

                var newParent = siblings[idx - 1];
                line.ParentGUID = newParent.GUID;
                line.Level = newParent.Level + 1;
                line.Ordering = allLines.Count(l => l.ParentGUID == newParent.GUID);
                newParent.Expanded = true;
            }
            NormalizeOrdering();
            OutlineConverter.ComputeLevels(allLines);
            RepositionInPlace();
            LinesChanged?.Invoke();
        }

        /// <summary>减少缩进</summary>
        public void UnindentSelected()
        {
            PushUndoSnapshot();

            foreach (var guid in selectedGUIDs.ToList())
            {
                var line = allLines.Find(l => l.GUID == guid);
                if (line == null || line.Level <= 1 || line.IsMetaNode) continue;

                var parent = allLines.Find(l => l.GUID == line.ParentGUID);
                if (parent == null || parent.Level == 0) continue;

                // 插入到原父节点的紧后面，而非同级末尾
                int insertOrder = parent.Ordering + 1;
                var siblingsToShift = allLines.Where(l =>
                    l.ParentGUID == parent.ParentGUID &&
                    l.GUID != line.GUID &&
                    l.Ordering >= insertOrder).ToList();
                foreach (var sib in siblingsToShift)
                    sib.Ordering++;

                line.ParentGUID = parent.ParentGUID;
                line.Level = Math.Max(1, line.Level - 1);
                line.Ordering = insertOrder;
            }
            NormalizeOrdering();
            OutlineConverter.ComputeLevels(allLines);
            RepositionInPlace();
            LinesChanged?.Invoke();
        }

        /// <summary>定向重排 visibleRows：根据 GetVisibleLines 新顺序复用已有行，
        /// 仅创建新增行 / 销毁多余行，不重建全部 UI</summary>
        public void ReorderVisibleInPlace()
        {
            // 保存当前滚动位置（AutoScrollPosition.Y 为负值表示向下滚动的量）
            int savedScrollY = -scrollPanel.AutoScrollPosition.Y;

            var newOrder = GetVisibleLines();
            var newGuids = new HashSet<string>(newOrder.Select(l => l.GUID));

            // 收集需要复用的已有行
            var reused = new Dictionary<string, OutlineRow>();
            var toDispose = new List<OutlineRow>();
            foreach (var row in visibleRows)
            {
                if (newGuids.Contains(row.Data.GUID))
                    reused[row.Data.GUID] = row;
                else
                    toDispose.Add(row);
            }

            // 销毁不再可见的行
            foreach (var row in toDispose)
            {
                scrollPanel.Controls.Remove(row);
                row.Dispose();
            }

            // 禁用 AutoScroll 防止清空/重建过程中滚动位置被重置
            scrollPanel.AutoScroll = false;
            scrollPanel.SuspendLayout();
            scrollPanel.Controls.Clear();
            visibleRows.Clear();

            int y = 0;
            foreach (var line in newOrder)
            {
                OutlineRow row;
                if (!reused.TryGetValue(line.GUID, out row))
                {
                    // 新增行（因父节点展开而新出现的行）
                    bool hasChildren = allLines.Any(l => l.ParentGUID == line.GUID);
                    bool isRoot = line.Level == 0;
                    row = new OutlineRow(line, hasChildren, isRoot ? new Font(baseFont, FontStyle.Bold) : baseFont);
                    row.Width = scrollPanel.ClientSize.Width > 0 ? scrollPanel.ClientSize.Width - 20 : 400;
                    row.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    row.RowClicked += OnRowClicked;
                    row.RowDoubleClicked += OnRowDoubleClicked;
                    row.RowRightClicked += OnRowRightClicked;
                    row.TextEditCommitted += OnTextEditCommitted;
                    row.ExpandToggled += OnExpandToggled;
                    row.TagCheckToggled += OnTagCheckToggled;
                    row.Tag = line.GUID;
                }

                row.Top = y;
                row.SetIconDisplayMode(IconDisplayMode);
                row.SetAllowEditNonMeta(AllowEditNonMeta);
                row.SetBlockMetaEdit(BlockMetaEdit);
                row.ApplyData();
                if (line.LabelKeywords != null && line.LabelKeywords.Count > 0)
                    row.SetLabelBadgeColors(LabelColors, LabelForeColors);
                row.SetSelected(selectedGUIDs.Contains(line.GUID));

                scrollPanel.Controls.Add(row);
                visibleRows.Add(row);
                y += row.Height;
            }

            scrollPanel.ResumeLayout(true);
            scrollPanel.PerformLayout();
            // 重新启用 AutoScroll，此时子控件已就位，不会产生错误偏移
            scrollPanel.AutoScroll = true;
            // 延迟恢复滚动位置，等待消息泵完成布局计算后再设置
            this.BeginInvoke(new Action(() =>
            {
                scrollPanel.AutoScrollPosition = new Point(0, savedScrollY);
            }));

            RefreshSelectionVisual();
            this.Focus();
        }

        /// <summary>上移选中行</summary>
        public void MoveUpSelected()
        {
            PushUndoSnapshot();

            foreach (var guid in selectedGUIDs.OrderBy(g =>
            {
                var l = allLines.Find(x => x.GUID == g);
                return l?.Ordering ?? 0;
            }))
            {
                var line = allLines.Find(l => l.GUID == guid);
                if (line == null || line.Ordering <= 0 || line.IsMetaNode) continue;
                var siblings = allLines.Where(l => l.ParentGUID == line.ParentGUID).ToList();
                var prev = siblings.Find(l => l.Ordering == line.Ordering - 1);
                if (prev == null) continue;
                prev.Ordering++;
                line.Ordering--;
            }
            NormalizeOrdering();
            RepositionInPlace();
            LinesChanged?.Invoke();
        }

        /// <summary>下移选中行</summary>
        public void MoveDownSelected()
        {
            PushUndoSnapshot();

            foreach (var guid in selectedGUIDs.OrderByDescending(g =>
            {
                var l = allLines.Find(x => x.GUID == g);
                return l?.Ordering ?? 0;
            }))
            {
                var line = allLines.Find(l => l.GUID == guid);
                if (line == null || line.IsMetaNode) continue;
                var siblings = allLines.Where(l => l.ParentGUID == line.ParentGUID).ToList();
                if (line.Ordering >= siblings.Count - 1) continue;
                var next = siblings.Find(l => l.Ordering == line.Ordering + 1);
                if (next == null) continue;
                next.Ordering--;
                line.Ordering++;
            }
            NormalizeOrdering();
            RepositionInPlace();
            LinesChanged?.Invoke();
        }

        /// <summary>规范化同一父节点下的 Ordering（0,1,2,3...连续）</summary>
        private void NormalizeOrdering()
        {
            var parentGroups = allLines.GroupBy(l => l.ParentGUID ?? "");
            foreach (var group in parentGroups)
            {
                var sorted = group.OrderBy(l => l.Ordering).ToList();
                for (int i = 0; i < sorted.Count; i++)
                    sorted[i].Ordering = i;
            }
        }

        // ============ 选择 ============

        public void SelectLine(string guid, bool addToSelection = false)
        {
            if (addToSelection && !string.IsNullOrEmpty(guid))
            {
                selectedGUIDs.Add(guid);
                var row = visibleRows.Find(r => r.Data.GUID == guid);
                row?.SetSelected(true);
            }
            else
            {
                if (selectedGUIDs.Count == 1 && selectedGUIDs.Contains(guid))
                {
                    // 同一行，无需操作（避免不必要的刷新）
                    this.Focus();
                    return;
                }
                // 精确更新：只改旧行和新行
                if (selectedGUIDs.Count == 1)
                {
                    var oldGuid = selectedGUIDs.First();
                    var oldRow = visibleRows.Find(r => r.Data.GUID == oldGuid);
                    oldRow?.SetSelected(false);
                }
                else
                {
                    foreach (var oldGuid in selectedGUIDs)
                    {
                        var oldRow = visibleRows.Find(r => r.Data.GUID == oldGuid);
                        oldRow?.SetSelected(false);
                    }
                }
                selectedGUIDs.Clear();
                if (!string.IsNullOrEmpty(guid))
                {
                    selectedGUIDs.Add(guid);
                    var newRow = visibleRows.Find(r => r.Data.GUID == guid);
                    newRow?.SetSelected(true);
                }
            }
            SelectionChanged?.Invoke(GetSelectedLines());
            this.Focus();
        }

        public void ClearSelection()
        {
            foreach (var guid in selectedGUIDs)
            {
                var row = visibleRows.Find(r => r.Data.GUID == guid);
                row?.SetSelected(false);
            }
            selectedGUIDs.Clear();
            SelectionChanged?.Invoke(GetSelectedLines());
        }

        /// <summary>键盘导航：左（折叠或跳父节点）</summary>
        public bool NavigateLeft()
        {
            if (selectedGUIDs.Count == 0) return false;
            NavigateHorizontal(false);
            return true;
        }

        /// <summary>键盘导航：右（展开或跳子节点/下一行）</summary>
        public bool NavigateRight()
        {
            if (selectedGUIDs.Count == 0) return false;
            NavigateHorizontal(true);
            return true;
        }

        // ============ UI 重建 ============

        /// <summary>增量展开/折叠节点，不重建全部 UI</summary>
        public void ExpandCollapseInPlace(OutlineLine line)
        {
            line.Expanded = !line.Expanded;

            // 找到该行在 visibleRows 中的索引
            int idx = visibleRows.FindIndex(r => r.Data.GUID == line.GUID);
            if (idx < 0) { RebuildVisibleRows(); return; }

            visibleRows[idx].ApplyData();
            // ApplyData 重建了 badge 控件，需重新上色
            if (line.LabelKeywords != null && line.LabelKeywords.Count > 0)
                visibleRows[idx].SetLabelBadgeColors(LabelColors, LabelForeColors);
            visibleRows[idx].SetSelected(selectedGUIDs.Contains(line.GUID));

            if (!line.Expanded)
            {
                // 折叠：移除所有可见后代
                int removeStart = idx + 1;
                int removeCount = 0;
                while (removeStart + removeCount < visibleRows.Count)
                {
                    var r = visibleRows[removeStart + removeCount];
                    if (r.Data.Level <= line.Level) break;
                    r.Dispose();
                    scrollPanel.Controls.Remove(r);
                    removeCount++;
                }
                if (removeCount > 0)
                {
                    int removedHeight = 0;
                    for (int i = 0; i < removeCount; i++)
                        removedHeight += visibleRows[removeStart + i].Height;
                    visibleRows.RemoveRange(removeStart, removeCount);
                    // 上移后续行
                    for (int i = removeStart; i < visibleRows.Count; i++)
                        visibleRows[i].Top -= removedHeight;
                }
            }
            else
            {
                // 展开：插入直接子节点及其可见后代
                var children = allLines.Where(l => l.ParentGUID == line.GUID)
                    .OrderBy(l => l.Ordering).ToList();
                if (children.Count == 0) return;

                int insertAt = idx + 1;
                int insertBaseY = visibleRows[idx].Top + visibleRows[idx].Height;
                int insertedHeight = 0;
                var newRows = new List<OutlineRow>();

                foreach (var child in children)
                {
                    InsertLineRecursive(child, newRows, ref insertedHeight);
                }

                // 将新行的 Y 偏移到插入基点
                for (int i = 0; i < newRows.Count; i++)
                    newRows[i].Top += insertBaseY;

                // 下移后续行
                for (int i = insertAt; i < visibleRows.Count; i++)
                    visibleRows[i].Top += insertedHeight;

                // 插入新行
                visibleRows.InsertRange(insertAt, newRows);
                foreach (var r in newRows)
                    scrollPanel.Controls.Add(r);
            }

            LinesChanged?.Invoke();
        }

        private void InsertLineRecursive(OutlineLine line, List<OutlineRow> newRows, ref int totalHeight)
        {
            bool hasChildren = allLines.Any(l => l.ParentGUID == line.GUID);
            bool isRoot = line.Level == 0;
            var row = new OutlineRow(line, hasChildren, isRoot ? new Font(baseFont, FontStyle.Bold) : baseFont);
            row.Width = scrollPanel.ClientSize.Width > 0 ? scrollPanel.ClientSize.Width - 20 : 400;
            row.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            row.RowClicked += OnRowClicked;
            row.RowDoubleClicked += OnRowDoubleClicked;
            row.RowRightClicked += OnRowRightClicked;
            row.TextEditCommitted += OnTextEditCommitted;
            row.ExpandToggled += OnExpandToggled;
            row.TagCheckToggled += OnTagCheckToggled;
            row.Tag = line.GUID;
            row.SetIconDisplayMode(IconDisplayMode);
            row.SetAllowEditNonMeta(AllowEditNonMeta);
            row.SetBlockMetaEdit(BlockMetaEdit);
            if (line.LabelKeywords != null && line.LabelKeywords.Count > 0)
                row.SetLabelBadgeColors(LabelColors, LabelForeColors);
            row.SetSelected(selectedGUIDs.Contains(line.GUID));
            row.Top = totalHeight;
            totalHeight += row.Height;
            newRows.Add(row);

            if (line.Expanded)
            {
                var children = allLines.Where(l => l.ParentGUID == line.GUID)
                    .OrderBy(l => l.Ordering).ToList();
                foreach (var child in children)
                    InsertLineRecursive(child, newRows, ref totalHeight);
            }
        }

        /// <summary>刷新单个已可见行的显示，不重建全部 UI</summary>
        public void RefreshRowDisplay(OutlineLine line)
        {
            var row = visibleRows.Find(r => r.Data.GUID == line.GUID);
            if (row == null) return;
            row.ApplyData();
            if (line.LabelKeywords != null && line.LabelKeywords.Count > 0)
                row.SetLabelBadgeColors(LabelColors, LabelForeColors);
        }

        /// <summary>增量删除行（不重建全部 UI）</summary>
        public void RemoveLinesInPlace(HashSet<string> guidsToRemove)
        {
            if (guidsToRemove.Count == 0) return;

            // 从后往前删除，避免索引变化问题
            for (int i = visibleRows.Count - 1; i >= 0; i--)
            {
                if (guidsToRemove.Contains(visibleRows[i].Data.GUID))
                {
                    var row = visibleRows[i];
                    int removedHeight = row.Height;
                    row.Dispose();
                    scrollPanel.Controls.Remove(row);
                    visibleRows.RemoveAt(i);
                    // 下移后续行
                    for (int j = i; j < visibleRows.Count; j++)
                        visibleRows[j].Top -= removedHeight;
                }
            }
            RefreshSelectionVisual();
        }

        /// <summary>仅更新所有可见行的显示（进度/标签/图标模式变化后）</summary>
        public void RefreshAllRowDisplays()
        {
            foreach (var row in visibleRows)
            {
                row.SetIconDisplayMode(IconDisplayMode);
                row.SetAllowEditNonMeta(AllowEditNonMeta);
                row.SetBlockMetaEdit(BlockMetaEdit);
                row.ApplyData();
                if (row.Data.LabelKeywords != null && row.Data.LabelKeywords.Count > 0)
                    row.SetLabelBadgeColors(LabelColors, LabelForeColors);
                row.SetSelected(selectedGUIDs.Contains(row.Data.GUID));
            }
        }

        /// <summary>仅重绘含有 label 的可见行（标签颜色变化后调用，比重建全部 UI 快得多）</summary>
        public void RefreshRowsWithLabels()
        {
            foreach (var row in visibleRows)
            {
                if (row.Data.LabelKeywords == null || row.Data.LabelKeywords.Count == 0)
                    continue;
                row.ApplyData();
                row.SetLabelBadgeColors(LabelColors, LabelForeColors);
                row.SetIconDisplayMode(IconDisplayMode);
                row.SetAllowEditNonMeta(AllowEditNonMeta);
                row.SetBlockMetaEdit(BlockMetaEdit);
                row.SetSelected(selectedGUIDs.Contains(row.Data.GUID));
            }
        }

        private void RebuildVisibleRows()
        {
            // 先滚回顶部再禁用 AutoScroll，避免清空/重建过程中
            // AutoScroll 内部状态根据变化的子控件范围产生错误的滚动偏移
            scrollPanel.AutoScroll = false;
            scrollPanel.SuspendLayout();

            // 清理旧行
            foreach (var row in visibleRows)
                row.Dispose();
            visibleRows.Clear();
            scrollPanel.Controls.Clear();

            var visible = GetVisibleLines();
            int y = 0;
            foreach (var line in visible)
            {
                bool hasChildren = allLines.Any(l => l.ParentGUID == line.GUID);
                bool isRoot = line.Level == 0;
                var row = new OutlineRow(line, hasChildren, isRoot ? new Font(baseFont, FontStyle.Bold) : baseFont);
                row.Width = scrollPanel.ClientSize.Width > 0 ? scrollPanel.ClientSize.Width - 20 : 400;
                row.Top = y;
                row.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                row.RowClicked += OnRowClicked;
                row.RowDoubleClicked += OnRowDoubleClicked;
                row.RowRightClicked += OnRowRightClicked;
                row.TextEditCommitted += OnTextEditCommitted;
                row.ExpandToggled += OnExpandToggled;
                row.TagCheckToggled += OnTagCheckToggled;
                row.Tag = line.GUID;
                row.SetIconDisplayMode(IconDisplayMode);
                row.SetAllowEditNonMeta(AllowEditNonMeta);
                row.SetBlockMetaEdit(BlockMetaEdit);

                if (line.LabelKeywords != null && line.LabelKeywords.Count > 0)
                {
                    row.SetLabelBadgeColors(LabelColors, LabelForeColors);
                }

                row.SetSelected(selectedGUIDs.Contains(line.GUID));
                scrollPanel.Controls.Add(row);
                visibleRows.Add(row);
                y += row.Height;
            }

            scrollPanel.ResumeLayout(true);
            scrollPanel.PerformLayout();
            // 重新启用 AutoScroll，此时子控件已就位，不会产生错误偏移
            scrollPanel.AutoScroll = true;
            scrollPanel.AutoScrollPosition = new Point(0, 0);
            RefreshSelectionVisual();
        }

        private void RefreshSelectionVisual()
        {
            foreach (var row in visibleRows)
            {
                var guid = row.Tag as string;
                row.SetSelected(guid != null && selectedGUIDs.Contains(guid));
            }
        }

        // ============ 事件处理 ============

        private void OnTagCheckToggled(OutlineRow row)
        {
            RefreshRowDisplay(row.Data);
            TagCheckToggled?.Invoke(row.Data);
        }

        private void OnRowClicked(OutlineRow row)
        {
            var guid = row.Tag as string;

            bool ctrl = (ModifierKeys & Keys.Control) != 0;
            bool shift = (ModifierKeys & Keys.Shift) != 0;
            if (ctrl)
            {
                if (selectedGUIDs.Contains(guid))
                    selectedGUIDs.Remove(guid);
                else
                    selectedGUIDs.Add(guid);
            }
            else if (shift && selectedGUIDs.Count > 0)
            {
                // Range select
                var visible = GetVisibleLines();
                int firstIdx = visible.FindIndex(l => selectedGUIDs.Contains(l.GUID));
                int lastIdx = visible.FindIndex(l => l.GUID == guid);
                if (firstIdx >= 0 && lastIdx >= 0)
                {
                    int from = Math.Min(firstIdx, lastIdx);
                    int to = Math.Max(firstIdx, lastIdx);
                    for (int i = from; i <= to; i++)
                        selectedGUIDs.Add(visible[i].GUID);
                }
            }
            else
            {
                selectedGUIDs.Clear();
                if (guid != null) selectedGUIDs.Add(guid);
            }
            RefreshSelectionVisual();
            SelectionChanged?.Invoke(GetSelectedLines());
        }

        private void OnRowDoubleClicked(OutlineRow row)
        {
            ExpandCollapseInPlace(row.Data);
        }

        private void OnTextEditCommitted(OutlineRow row)
        {
            // 文本确实被修改了，把编辑前的快照推到撤销栈
            if (_preEditSnapshot != null)
            {
                undoStack.Add(_preEditSnapshot);
                if (undoStack.Count > MAX_UNDO)
                    undoStack.RemoveAt(0);
                redoStack.Clear();
                _preEditSnapshot = null;
            }

            var line = row.Data;

            // 格式验证：检查父节点的编辑格式约束
            if (!string.IsNullOrEmpty(line.ParentGUID))
            {
                var parent = allLines.Find(l => l.GUID == line.ParentGUID);
                if (parent != null && !string.IsNullOrEmpty(parent.EditFormatRegex))
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(line.Text, parent.EditFormatRegex))
                    {
                        MessageBox.Show(string.Format("Invalid format.\nExpected: {0}",
                            parent.EditFormatHint ?? parent.EditFormatRegex),
                            "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        row.SetText(line.Text); // restore old text
                        return;
                    }
                }
            }

            TextEdited?.Invoke(row.Data);
        }

        private void OnRowRightClicked(OutlineRow row, Point loc)
        {
            // 先选中当前行
            if (!selectedGUIDs.Contains(row.Data.GUID))
            {
                selectedGUIDs.Clear();
                selectedGUIDs.Add(row.Data.GUID);
                RefreshSelectionVisual();
            }
            LineRightClicked?.Invoke(row.Data, loc);
        }

        private void OnExpandToggled(OutlineRow row)
        {
            ExpandCollapseInPlace(row.Data);
        }

        private void OutlinePanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;
                if (e.Shift) UnindentSelected();
                else IndentSelected();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                RemoveSelectedLines();
            }
            else if (e.KeyCode == Keys.F2)
            {
                e.SuppressKeyPress = true;
                var row = visibleRows.Find(r => selectedGUIDs.Contains(r.Tag as string));
                if (!IsReadOnly && row != null)
                {
                    _preEditSnapshot = SerializeToSnapshot();
                    row.BeginEdit();
                }
            }
            // 方向键已在 ProcessDialogKey 中统一处理
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            foreach (var row in visibleRows)
            {
                row.Width = scrollPanel.ClientSize.Width > 0 ? scrollPanel.ClientSize.Width - 20 : 400;
                row.LayoutControls();
            }
        }

        // ============ 清理 ============

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                baseFont?.Dispose();
                foreach (var row in visibleRows)
                    row.Dispose();
                visibleRows.Clear();
            }
            base.Dispose(disposing);
        }

        #region Undo/Redo

        private class OutlineLineDTO
        {
            public string GUID;
            public string Text;
            public int Level;
            public string ParentGUID;
            public bool Expanded;
            public int Ordering;
            public short MetaType;
            public string MetaValue;
            public List<string> LabelKeywords;
            public int ProgressPercent;
            public bool IsMetaNode;
            public bool IsMetaSectionHeader;
            public bool AllowAddChild;
            public string EditFormatRegex;
            public string EditFormatHint;

            public OutlineLineDTO() { }

            public OutlineLineDTO(OutlineLine line)
            {
                GUID = line.GUID;
                Text = line.Text;
                Level = line.Level;
                ParentGUID = line.ParentGUID;
                Expanded = line.Expanded;
                Ordering = line.Ordering;
                MetaType = (short)line.MetaType;
                MetaValue = line.MetaValue;
                LabelKeywords = line.LabelKeywords?.ToList();
                ProgressPercent = line.ProgressPercent;
                IsMetaNode = line.IsMetaNode;
                IsMetaSectionHeader = line.IsMetaSectionHeader;
                AllowAddChild = line.AllowAddChild;
                EditFormatRegex = line.EditFormatRegex;
                EditFormatHint = line.EditFormatHint;
            }

            public OutlineLine ToOutlineLine()
            {
                return new OutlineLine
                {
                    GUID = this.GUID,
                    Text = this.Text,
                    Level = this.Level,
                    ParentGUID = this.ParentGUID,
                    Expanded = this.Expanded,
                    Ordering = this.Ordering,
                    MetaType = (NodeMetaType)this.MetaType,
                    MetaValue = this.MetaValue,
                    LabelKeywords = this.LabelKeywords?.ToList() ?? new List<string>(),
                    ProgressPercent = this.ProgressPercent,
                    IsMetaNode = this.IsMetaNode,
                    IsMetaSectionHeader = this.IsMetaSectionHeader,
                    AllowAddChild = this.AllowAddChild,
                    EditFormatRegex = this.EditFormatRegex,
                    EditFormatHint = this.EditFormatHint
                };
            }
        }

        private class OutlineSnapshot
        {
            public List<OutlineLineDTO> Lines;
            public List<string> SelectedGUIDs;
        }

        private string SerializeToSnapshot()
        {
            var snap = new OutlineSnapshot
            {
                Lines = allLines.Select(l => new OutlineLineDTO(l)).ToList(),
                SelectedGUIDs = selectedGUIDs.ToList()
            };
            return JsonConvert.SerializeObject(snap);
        }

        private void RestoreFromSnapshot(string json)
        {
            var snap = JsonConvert.DeserializeObject<OutlineSnapshot>(json);
            if (snap == null) return;

            allLines.Clear();
            allLines.AddRange(snap.Lines.Select(d => d.ToOutlineLine()));

            // 恢复 rootLine 和 metaRootLine 引用
            rootLine = allLines.Find(l => l.GUID == "__ROOT__");
            metaRootLine = allLines.Find(l => l.IsMetaSectionHeader);

            selectedGUIDs.Clear();
            if (snap.SelectedGUIDs != null)
                selectedGUIDs.UnionWith(snap.SelectedGUIDs);

            RebuildVisibleRows();
            RefreshSelectionVisual();
        }

        public void PushUndoSnapshot()
        {
            if (isUndoing) return;

            string json = SerializeToSnapshot();
            undoStack.Add(json);
            if (undoStack.Count > MAX_UNDO)
                undoStack.RemoveAt(0);
            redoStack.Clear();
        }

        public void Undo()
        {
            if (undoStack.Count == 0) return;
            isUndoing = true;

            redoStack.Add(SerializeToSnapshot());
            RestoreFromSnapshot(undoStack[undoStack.Count - 1]);
            undoStack.RemoveAt(undoStack.Count - 1);

            isUndoing = false;
        }

        public void Redo()
        {
            if (redoStack.Count == 0) return;
            isUndoing = true;

            undoStack.Add(SerializeToSnapshot());
            RestoreFromSnapshot(redoStack[redoStack.Count - 1]);
            redoStack.RemoveAt(redoStack.Count - 1);

            isUndoing = false;
        }

        #endregion

        /// <summary>检测文本中的 [XX%] 进度标记并设置 ProgressPercent</summary>
        private static void DetectProgressPercent(OutlineLine line, string text)
        {
            if (!text.Contains("%")) return;
            var match = Regex.Match(text, @"\[(\d+)%\]");
            if (match.Success)
                line.ProgressPercent = Convert.ToInt32(match.Groups[1].Value);
        }
    }
}
