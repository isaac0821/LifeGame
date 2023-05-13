﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace LifeGame
{
    public partial class frmInfoNote : Form
    {
        private plot C = new plot();
        CNote note = new CNote();
        List<RNoteLog> noteLogs = new List<RNoteLog>();
        List<RNoteOutsource> noteOutsources = new List<RNoteOutsource>();
        List<RNoteColor> noteColors = new List<RNoteColor>();
        bool RefreshInMain = true;
        string topicGUID = "";
        private bool lockMode = false;

        public frmInfoNote(CNote info)
        {
            note = info;
            noteLogs = G.glb.lstNoteLog.FindAll(o => o.TagTime == info.TagTime && o.Topic == info.Topic);
            noteOutsources = G.glb.lstNoteOutsource.FindAll(o => o.TagTime == info.TagTime && o.Topic == info.Topic);
            noteColors = G.glb.lstNoteColor.FindAll(o => o.TagTime == info.TagTime && o.Topic == info.Topic);
            topicGUID = info.GUID;
            InitializeComponent();
            LoadNoteColor();
            LoadNoteLog();
            LoadNoteOutsource();
            dtpDate.Value = note.TagTime;
            txtTopic.Enabled = false;
            btnSave.Enabled = false;
            lockMode = info.Locked;
            if (lockMode)
            {
                btnRead.Enabled = false;
                btnWrite.Enabled = false;
                btnSave.Enabled = false;
                btnLock.Text = "Unlock";
                trvNote.Hide();
            }
            else
            {
                btnRead.Enabled = true;
                btnWrite.Enabled = true;
                btnSave.Enabled = true;
                btnLock.Text = "Lock";
                trvNote.Show();
            }
        }

        public frmInfoNote(DateTime selectedDate)
        {
            InitializeComponent();
            note = new CNote();
            noteLogs = new List<RNoteLog>();
            noteOutsources = new List<RNoteOutsource>();
            noteColors = new List<RNoteColor>();
            topicGUID = Guid.NewGuid().ToString();
            LoadNoteColor();
            LoadNoteLog();
            LoadNoteOutsource();
            dtpDate.Value = selectedDate;
            btnSave.Enabled = true;
        }

        public frmInfoNote(string LiteratureTitle)
        {
            RefreshInMain = false;
            InitializeComponent();
            note = new CNote();
            noteLogs = new List<RNoteLog>();
            noteColors = new List<RNoteColor>();
            topicGUID = Guid.NewGuid().ToString();
            List<RLiteratureOutSource> litOutSources = G.glb.lstLiteratureOutSource.FindAll(o => o.Title == LiteratureTitle).ToList();
            for (int i = 0; i < litOutSources.Count; i++)
            {
                RNoteOutsource noteOutsource = new RNoteOutsource();
                noteOutsource.TagTime = DateTime.Today.Date;
                noteOutsource.Topic = litOutSources[i].Title;
                noteOutsource.Outsourcepath = litOutSources[i].OutsourcePath;
                noteOutsources.Add(noteOutsource);
            }
            LoadNoteColor();
            LoadNoteLog();
            LoadNoteOutsource();
            txtTopic.Text = LiteratureTitle;
            dtpDate.Value = DateTime.Today.Date;
            btnSave.Enabled = true;
        }

        private void LoadNoteOutsource()
        {
            lsbOutsource.Items.Clear();
            foreach (RNoteOutsource noteOutsource in noteOutsources)
            {
                lsbOutsource.Items.Add(noteOutsource.Outsourcepath);
            }
        }

        private void LoadNoteColor()
        {
            lsvColor.Items.Clear();
            foreach (RNoteColor noteColor in noteColors)
            {
                ListViewItem item = new ListViewItem();
                item.Text = noteColor.Keyword;
                item.BackColor = C.GetColor(noteColor.Color);
                if (noteColor.Color == "Red" || noteColor.Color == "Green" || noteColor.Color == "Blue" || noteColor.Color == "DarkGreen" || noteColor.Color == "Brown")
                {
                    item.ForeColor = Color.White;
                }
                else
                {
                    item.ForeColor = Color.Black;
                }
                lsvColor.Items.Add(item);
            }
        }

        private void LoadNoteLog()
        {
            trvNote.Nodes.Clear();
            TreeNode rootNode = new TreeNode(note.Topic, 0, 0);
            rootNode.Name = note.GUID;
            rootNode.Text = note.Topic;
            rootNode.ExpandAll();
            LoadChildNoteLog(rootNode, note.Topic);
            trvNote.Nodes.Add(rootNode);
        }

        private void LoadChildNoteLog(TreeNode treeNode, string topic)
        {
            // 如果本条NoteLog作为上级NoteLog存在，添加所有的SubLog
            if (noteLogs.Exists(o => o.Log == treeNode.Text && o.GUID == treeNode.Name && o.Topic == topic))
            {
                List<RNoteLog> subNoteLog = noteLogs.FindAll(o => o.Log == treeNode.Text && o.GUID == treeNode.Name && o.Topic == note.Topic).ToList();
                subNoteLog = subNoteLog.OrderBy(o => o.Index).ToList();
                foreach (RNoteLog sub in subNoteLog)
                {
                    TreeNode childNode = new TreeNode(sub.SubLog);
                    childNode.Name = sub.SubGUID;
                    childNode.Text = sub.SubLog;
                    childNode.BackColor = SystemColors.Window;
                    childNode.ForeColor = Color.Black;
                    childNode.ExpandAll();
                    if (highlightText != "" && sub.SubLog.Contains(highlightText))
                    {
                        childNode.ForeColor = Color.Black;
                        childNode.BackColor = Color.OrangeRed;
                    }
                    else
                    {
                        foreach (ListViewItem item in lsvColor.Items)
                        {
                            if (sub.SubLog.Contains(item.Text))
                            {
                                string itemColor = noteColors.Find(o => o.Keyword == item.Text).Color;
                                childNode.BackColor = C.GetColor(itemColor);
                                if (itemColor == "Red" || itemColor == "Green" || itemColor == "Blue" || itemColor == "DarkGreen" || itemColor == "Brown")
                                {
                                    childNode.ForeColor = Color.White;
                                }
                                else
                                {
                                    childNode.ForeColor = Color.Black;
                                }
                            }
                        }
                        if (sub.SubLog.Contains("$LINK$>"))
                        {
                            childNode.ForeColor = Color.Blue;
                            childNode.NodeFont = new Font(Font, FontStyle.Underline);
                        }
                        if (sub.SubLog.Contains("$LITR$>"))
                        {
                            childNode.ForeColor = Color.Brown;
                            childNode.NodeFont = new Font(Font, FontStyle.Underline);
                        }
                        if (sub.SubLog.Contains("$NOTE$>"))
                        {
                            childNode.ForeColor = Color.DarkGreen;
                            childNode.NodeFont = new Font(Font, FontStyle.Underline);
                        }
                    }
                    LoadChildNoteLog(childNode, note.Topic);
                    treeNode.Nodes.Add(childNode);
                }
            }
        }

        private void SaveNoteLog()
        {
            noteLogs = new List<RNoteLog>();
            foreach (TreeNode child in trvNote.Nodes[0].Nodes)
            {
                SaveChildNoteLog(child);
            }
        }

        private void SaveChildNoteLog(TreeNode treeNode)
        {
            RNoteLog newNoteLog = new RNoteLog();
            newNoteLog.Topic = txtTopic.Text;
            newNoteLog.TopicGUID = topicGUID;
            newNoteLog.TagTime = dtpDate.Value.Date;
            newNoteLog.Log = treeNode.Parent.Text;
            newNoteLog.GUID = treeNode.Parent.Name;
            newNoteLog.SubLog = treeNode.Text;
            newNoteLog.SubGUID = treeNode.Name;
            newNoteLog.Index = treeNode.Index;
            noteLogs.Add(newNoteLog);
            foreach (TreeNode child in treeNode.Nodes)
            {
                SaveChildNoteLog(child);
            }
        }

        private void SaveNote()
        {
            // 表示已经存在这个Note了，提示是否覆盖，否则提示是否新建
            if (G.glb.lstNote.Exists(o => o.Topic == note.Topic && o.TagTime == dtpDate.Value.Date))
            {
                DialogResult result = MessageBox.Show("Wanna save?", "Saving", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        G.glb.lstNoteLog.RemoveAll(o => o.Topic == note.Topic && o.TagTime == dtpDate.Value.Date);
                        G.glb.lstNoteOutsource.RemoveAll(o => o.Topic == note.Topic && o.TagTime == dtpDate.Value.Date);
                        G.glb.lstNoteColor.RemoveAll(o => o.Topic == note.Topic && o.TagTime == dtpDate.Value.Date);
                        SaveNoteLog();
                        foreach (RNoteLog noteLog in noteLogs)
                        {
                            noteLog.Topic = txtTopic.Text;
                            noteLog.TagTime = dtpDate.Value.Date;
                            G.glb.lstNoteLog.Add(noteLog);
                        }
                        foreach (RNoteOutsource noteOutsource in noteOutsources)
                        {
                            noteOutsource.Topic = txtTopic.Text;
                            noteOutsource.TagTime = dtpDate.Value.Date;
                            G.glb.lstNoteOutsource.Add(noteOutsource);
                        }
                        foreach (RNoteColor noteColor in noteColors)
                        {
                            noteColor.Topic = txtTopic.Text;
                            noteColor.TagTime = dtpDate.Value.Date;
                            G.glb.lstNoteColor.Add(noteColor);
                        }
                        G.glb.lstNote.Find(o => o.Topic == note.Topic && o.TagTime == dtpDate.Value.Date).FinishedNote = chkFinished.Checked;
                        G.glb.lstNote.Find(o => o.Topic == note.Topic && o.TagTime == dtpDate.Value.Date).LiteratureTitle = txtLiteratureTitle.Text;
                        G.glb.lstNote.Find(o => o.Topic == note.Topic && o.TagTime == dtpDate.Value.Date).TaskName = cbxTask.Text;
                        G.glb.lstNote.Find(o => o.Topic == note.Topic && o.TagTime == dtpDate.Value.Date).TagTime = dtpDate.Value.Date;
                        G.glb.lstNote.Find(o => o.Topic == note.Topic && o.TagTime == dtpDate.Value.Date).Topic = txtTopic.Text;
                        G.glb.lstNote.Find(o => o.Topic == note.Topic && o.TagTime == dtpDate.Value.Date).Locked = lockMode;
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                note.Topic = txtTopic.Text;
                note.FinishedNote = chkFinished.Checked;
                note.LiteratureTitle = txtLiteratureTitle.Text;
                note.TaskName = cbxTask.Text;
                note.TagTime = dtpDate.Value.Date;
                note.Locked = lockMode;
                G.glb.lstNote.Add(note);
                SaveNoteLog();
                foreach (RNoteLog noteLog in noteLogs)
                {
                    noteLog.Topic = txtTopic.Text;
                    noteLog.TagTime = dtpDate.Value.Date;
                    G.glb.lstNoteLog.Add(noteLog);
                }
                foreach (RNoteOutsource noteOutsource in noteOutsources)
                {
                    noteOutsource.Topic = txtTopic.Text;
                    noteOutsource.TagTime = dtpDate.Value.Date;
                    G.glb.lstNoteOutsource.Add(noteOutsource);
                }
                foreach (RNoteColor noteColor in noteColors)
                {
                    noteColor.Topic = txtTopic.Text;
                    noteColor.TagTime = dtpDate.Value.Date;
                    G.glb.lstNoteColor.Add(noteColor);
                }
                if (RefreshInMain)
                {
                    DrawLog();
                }
            }
        }

        private void frmInfoNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNote();
            Dispose();
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void frmInfoNote_Load(object sender, EventArgs e)
        {
            // Bind Task
            List<CTask> taskChoices = G.glb.lstTask.FindAll(o => o.TaskState != ETaskState.Finished && o.TaskState != ETaskState.Aborted).ToList();
            List<string> choices = new List<string>();
            choices.Add("");
            foreach (CTask task in taskChoices)
            {
                choices.Add(task.TaskName);
            }
            choices = choices.OrderBy(o => o).ToList();
            cbxTask.DataSource = choices;

            if (note.Topic != null)
            {
                txtTopic.Text = note.Topic;
                txtLiteratureTitle.Text = note.LiteratureTitle;
                cbxTask.Text = note.TaskName;
                chkFinished.Checked = note.FinishedNote;
            }
        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                string newLog = Interaction.InputBox("Input new note node", "New Note", "New Note", 300, 300);
                if (newLog != "")
                {
                    TreeNode newNode = new TreeNode(newLog, 0, 0);
                    newNode.Text = newLog;
                    newNode.Name = Guid.NewGuid().ToString();
                    newNode.BackColor = SystemColors.Window;
                    newNode.ForeColor = Color.Black;
                    newNode.ExpandAll();
                    trvNote.SelectedNode.ExpandAll();
                    foreach (ListViewItem item in lsvColor.Items)
                    {
                        if (newLog.Contains(item.Text)
                            && !newLog.Contains("$LINK$>")
                            && !newLog.Contains("$LITR$>")
                            && !newLog.Contains("$NOTE$>"))
                        {
                            string itemColor = noteColors.Find(o => o.Keyword == item.Text).Color;
                            newNode.BackColor = C.GetColor(itemColor);
                            if (itemColor == "Red" || itemColor == "Green" || itemColor == "Blue" || itemColor == "DarkGreen" || itemColor == "Brown")
                            {
                                newNode.ForeColor = Color.White;
                            }
                            else
                            {
                                newNode.ForeColor = Color.Black;
                            }
                        }
                    }
                    if (newLog.Contains("$LINK$>"))
                    {
                        newNode.ForeColor = Color.Blue;
                        newNode.NodeFont = new Font(Font, FontStyle.Underline);
                    }
                    if (newLog.Contains("$LITR$>"))
                    {
                        newNode.ForeColor = Color.Brown;
                        newNode.NodeFont = new Font(Font, FontStyle.Underline);
                    }
                    if (newLog.Contains("$NOTE$>"))
                    {
                        newNode.ForeColor = Color.DarkGreen;
                        newNode.NodeFont = new Font(Font, FontStyle.Underline);
                    }
                    trvNote.SelectedNode.Nodes.Add(newNode);
                }
            }
            btnSave.Enabled = true;
        }

        private void tsmAddBatch_Click(object sender, EventArgs e)
        {
            // 考虑之后改成正则表达式
            if (trvNote.SelectedNode != null)
            {
                bool canAddBatch = false;
                string NewLogBatch = Interaction.InputBox("Input new note node in batch, e.g., xxx_{1-10}_xxx, or xxx_{a,b,c}_xxx, or xxx_{1-10,a,b,c}_xxx", "New Notes", "New Note", 300, 300);
                if (NewLogBatch != "")
                {
                    // 分离得到大括号内的集合
                    string[] splitLeft = NewLogBatch.Split('{');
                    string beforeBracket = "";
                    string afterBracket = "";
                    List<string> inBracketCollection = new List<string>();
                    if (splitLeft.Length == 2)
                    {
                        beforeBracket = splitLeft[0];
                        string[] splitRight = splitLeft[1].Split('}');
                        if (splitRight.Length == 2)
                        {
                            afterBracket = splitRight[1];
                            // 先被','分割，再被'-'分割
                            string[] inBracketByComma = splitRight[0].Split(',');
                            foreach (string item in inBracketByComma)
                            {
                                string[] inBrackByHypen = item.Split('-');
                                if (inBrackByHypen.Length == 1)
                                {
                                    inBracketCollection.Add(item);
                                    canAddBatch = true;
                                }
                                else if (inBrackByHypen.Length == 2)
                                {
                                    bool batchDetectedFlag = false;

                                    // 看看是不是按小写字母增序
                                    if (!batchDetectedFlag)
                                    {
                                        string[] lowercaseAlphabet = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
                                        if (lowercaseAlphabet.Contains(inBrackByHypen[0]) && lowercaseAlphabet.Contains(inBrackByHypen[1]))
                                        {
                                            int startIndex = -1;
                                            int endIndex = -1;
                                            for (int i = 0; i < lowercaseAlphabet.Length; i++)
                                            {
                                                if (lowercaseAlphabet[i] == inBrackByHypen[0])
                                                {
                                                    startIndex = i;
                                                }
                                                if (lowercaseAlphabet[i] == inBrackByHypen[1])
                                                {
                                                    endIndex = i;
                                                }
                                            }
                                            for (int i = startIndex; i < endIndex; i++)
                                            {
                                                inBracketCollection.Add(lowercaseAlphabet[i]);
                                            }
                                        }
                                    }

                                    // 看看是不是按大写字母增序
                                    if (!batchDetectedFlag)
                                    {
                                        string[] uppercaseAlphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                                        if (uppercaseAlphabet.Contains(inBrackByHypen[0]) && uppercaseAlphabet.Contains(inBrackByHypen[1]))
                                        {
                                            int startIndex = -1;
                                            int endIndex = -1;
                                            for (int i = 0; i < uppercaseAlphabet.Length; i++)
                                            {
                                                if (uppercaseAlphabet[i] == inBrackByHypen[0])
                                                {
                                                    startIndex = i;
                                                }
                                                if (uppercaseAlphabet[i] == inBrackByHypen[1])
                                                {
                                                    endIndex = i;
                                                }
                                            }
                                            for (int i = startIndex; i < endIndex; i++)
                                            {
                                                inBracketCollection.Add(uppercaseAlphabet[i]);
                                            }
                                        }
                                    }

                                    // 看看是不是按数字增序
                                    if (!batchDetectedFlag)
                                    {
                                        if (Regex.IsMatch(inBrackByHypen[0], @"^[0-9]+$") && Regex.IsMatch(inBrackByHypen[1], @"^[0-9]+$"))
                                        {
                                            int startIndex = Convert.ToInt32(inBrackByHypen[0]);
                                            int endIndex = Convert.ToInt32(inBrackByHypen[1]);
                                            for (int i = startIndex; i < endIndex; i++)
                                            {
                                                inBracketCollection.Add(i.ToString());
                                            }
                                        }
                                    }

                                    if (batchDetectedFlag)
                                    {
                                        canAddBatch = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect format, correct example will be xxx_{1-10}_xxx, or xxx_{a,b,c}_xxx, or xxx_{1-10,a,b,c}_xxx");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect format, correct example will be xxx_{1-10}_xxx, or xxx_{a,b,c}_xxx, or xxx_{1-10,a,b,c}_xxx");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect format, correct example will be xxx_{1-10}_xxx, or xxx_{a,b,c}_xxx, or xxx_{1-10,a,b,c}_xxx");
                    }
                    if (canAddBatch)
                    {
                        foreach (string inc in inBracketCollection)
                        {
                            string NewLog = beforeBracket + inc + afterBracket;
                            TreeNode newNode = new TreeNode(NewLog, 0, 0);
                            newNode.Text = NewLog;
                            newNode.Name = Guid.NewGuid().ToString();
                            newNode.BackColor = SystemColors.Window;
                            newNode.ForeColor = Color.Black;
                            newNode.ExpandAll();
                            trvNote.SelectedNode.ExpandAll();
                            foreach (ListViewItem item in lsvColor.Items)
                            {
                                if (NewLog.Contains(item.Text)
                                    && !NewLog.Contains("$LINK$>")
                                    && !NewLog.Contains("$LITR$>")
                                    && !NewLog.Contains("$NOTE$>"))
                                {
                                    string itemColor = noteColors.Find(o => o.Keyword == item.Text).Color;
                                    newNode.BackColor = C.GetColor(itemColor);
                                    if (itemColor == "Red" || itemColor == "Green" || itemColor == "Blue" || itemColor == "DarkGreen" || itemColor == "Brown")
                                    {
                                        newNode.ForeColor = Color.White;
                                    }
                                    else
                                    {
                                        newNode.ForeColor = Color.Black;
                                    }
                                }
                            }
                            trvNote.SelectedNode.Nodes.Add(newNode);
                        }
                        btnSave.Enabled = true;
                    }
                }
            }
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Parent != null)
            {
                trvNote.LabelEdit = true;
                if (!trvNote.SelectedNode.IsEditing)
                {
                    trvNote.SelectedNode.BeginEdit();
                }
            }
        }

        private void tsmRemove_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Parent != null)
            {
                if (trvNote.SelectedNode.Nodes.Count == 0)
                {
                    trvNote.Nodes.Remove(trvNote.SelectedNode);
                    btnSave.Enabled = true;
                }
                else
                {
                    if (MessageBox.Show("Confirm to remove.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        trvNote.Nodes.Remove(trvNote.SelectedNode);
                        btnSave.Enabled = true;
                    }
                }
            }
        }

        private void removeChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Nodes.Count > 0)
            {
                bool canRemoveFlag = true;
                foreach (TreeNode child in trvNote.SelectedNode.Nodes)
                {
                    if (child.Nodes.Count > 0)
                    {
                        canRemoveFlag = false;
                        break;
                    }
                }
                if (canRemoveFlag)
                {
                    trvNote.SelectedNode.Nodes.Clear();
                    btnSave.Enabled = true;
                }
                else
                {
                    MessageBox.Show("To be cautious, can not remove note with sub node");
                }
            }
        }

        private void tsmUp_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                TreeNode node = trvNote.SelectedNode;
                TreeNode preNode = node.PrevNode;
                if (preNode != null)
                {
                    TreeNode newNode = (TreeNode)node.Clone();
                    if (node.Parent == null)
                    {
                        trvNote.Nodes.Insert(preNode.Index, newNode);
                    }
                    else
                    {
                        node.Parent.Nodes.Insert(preNode.Index, newNode);
                    }
                    node.Remove();
                    trvNote.SelectedNode = newNode;
                }
            }
            btnSave.Enabled = true;
        }

        private void tsmDown_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                TreeNode node = trvNote.SelectedNode;
                TreeNode nextNode = node.NextNode;
                if (nextNode != null)
                {
                    TreeNode newNode = (TreeNode)node.Clone();
                    if (node.Parent == null)
                    {
                        trvNote.Nodes.Insert(nextNode.Index + 1, newNode);
                    }
                    else
                    {
                        node.Parent.Nodes.Insert(nextNode.Index + 1, newNode);
                    }
                    node.Remove();
                    trvNote.SelectedNode = newNode;
                }
            }
            btnSave.Enabled = true;
        }

        private void tsmBelongTo_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Parent != null)
            {
                TreeNode node = trvNote.SelectedNode;
                TreeNode preNode = node.PrevNode;
                TreeNode newNode = (TreeNode)node.Clone();
                if (node.Parent != null && node.PrevNode != null)
                {
                    preNode.Nodes.Insert(preNode.Nodes.Count, newNode);
                    node.Remove();
                    trvNote.SelectedNode = newNode;
                }
            }
            btnSave.Enabled = true;
        }

        private void tsmIndependent_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                TreeNode node = trvNote.SelectedNode;
                TreeNode parentNode = node.Parent;
                TreeNode grandparentNode = node.Parent.Parent;
                TreeNode newNode = (TreeNode)node.Clone();
                if (node.Parent != null && node.Parent.Parent != null)
                {
                    grandparentNode.Nodes.Insert(parentNode.Index + 1, newNode);
                    node.Remove();
                    trvNote.SelectedNode = newNode;
                }
            }
            btnSave.Enabled = true;
        }

        private void txtTopic_TextChanged(object sender, EventArgs e)
        {
            note.Topic = txtTopic.Text;
            trvNote.Nodes[0].Text = txtTopic.Text;
            trvNote.Nodes[0].Name = topicGUID;
        }

        private void tsmAddOutsource_Click(object sender, EventArgs e)
        {
            string newOutsourcePath = Interaction.InputBox("Add outsource", "Add outsource", "Add outsource", 300, 300);
            RNoteOutsource newNoteOutsource = new RNoteOutsource();
            newNoteOutsource.Topic = note.Topic;
            newNoteOutsource.TagTime = dtpDate.Value;
            newNoteOutsource.Outsourcepath = newOutsourcePath;
            noteOutsources.Add(newNoteOutsource);
            LoadNoteOutsource();
            btnSave.Enabled = true;
        }

        private void tsmDeleteOutsource_Click(object sender, EventArgs e)
        {
            if (lsbOutsource.SelectedItem != null)
            {
                noteOutsources.RemoveAll(o => o.Outsourcepath == lsbOutsource.SelectedItem.ToString());
                LoadNoteOutsource();
            }
            btnSave.Enabled = true;
        }

        private void tsmOpenOutsource_Click(object sender, EventArgs e)
        {
            if (lsbOutsource.SelectedItem != null)
            {
                string selectedPath = lsbOutsource.SelectedItem.ToString();
                string[] checkUrl = selectedPath.Split(':');
                if (checkUrl[0] == "http" || checkUrl[0] == "https")
                {
                    System.Diagnostics.Process.Start("chrome.exe", selectedPath);
                }
                else
                {
                    try
                    {
                        System.Diagnostics.Process.Start(selectedPath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("File type is not supported.");
                        throw;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveNote();
            txtTopic.Enabled = false;
            btnSave.Enabled = false;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNoteColor frmAddNoteColor = new frmAddNoteColor();
            frmAddNoteColor.SendColorLabel += new frmAddNoteColor.SetColorLabel(addNoteColor);
            frmAddNoteColor.Show();
        }

        private void addNoteColor(string Keyword, string NoteColor)
        {
            if (!noteColors.Exists(o => o.Keyword == Keyword))
            {
                RNoteColor newNoteColor = new RNoteColor();
                newNoteColor.Topic = txtTopic.Text;
                newNoteColor.TagTime = dtpDate.Value.Date;
                newNoteColor.Keyword = Keyword;
                newNoteColor.Color = NoteColor;
                noteColors.Add(newNoteColor);

                ListViewItem item = new ListViewItem();
                item.Text = Keyword;
                plot C = new plot();
                item.BackColor = C.GetColor(NoteColor);
                if (NoteColor == "Red" || NoteColor == "Green" || NoteColor == "Blue" || NoteColor == "DarkGreen" || NoteColor == "Brown")
                {
                    item.ForeColor = Color.White;
                }
                else
                {
                    item.ForeColor = Color.Black;
                }
                item.Checked = true;
                lsvColor.Items.Add(item);
                SaveNoteLog();
                LoadNoteLog();
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvColor.SelectedItems != null)
            {
                foreach (ListViewItem item in lsvColor.SelectedItems)
                {
                    noteColors.RemoveAll(o => o.Keyword == item.Text);
                    lsvColor.Items.Remove(item);
                }
                SaveNoteLog();
                LoadNoteLog();
            }
        }

        private void tsmChangeLabel_Click(object sender, EventArgs e)
        {
            string SelectedNoteLabel = "(No Label)";
            foreach (ListViewItem item in lsvColor.Items)
            {
                if (trvNote.SelectedNode.Text.Contains(item.Text))
                {
                    SelectedNoteLabel = item.Text;
                    break;
                }
            }
            List<string> LabelOptions = new List<string>();
            foreach (RNoteColor item in noteColors)
            {
                LabelOptions.Add(item.Keyword);
            }
            frmNoteChangeLabel frmNoteChangeLabel = new frmNoteChangeLabel(SelectedNoteLabel, LabelOptions);
            frmNoteChangeLabel.SendNewLabel += new frmNoteChangeLabel.SetNewLabel(changeLabel);
            frmNoteChangeLabel.Show();
        }

        private void changeLabel(string newLabel, bool changeDescendantFlag)
        {
            changeNodeLabel(trvNote.SelectedNode, newLabel, changeDescendantFlag);
        }

        private void changeNodeLabel(TreeNode node, string newLabel, bool changeDescendant)
        {
            foreach (ListViewItem item in lsvColor.Items)
            {
                if (node.Text.Contains(item.Text)
                    && !node.Text.Contains("$LINK$>")
                    && !node.Text.Contains("$LITR$>")
                    && !node.Text.Contains("$NOTE$>"))
                {
                    node.Text = node.Text.Replace(item.Text, newLabel);
                    node.BackColor = SystemColors.Window;
                    node.ForeColor = Color.Black;
                    string itemColor = noteColors.Find(o => o.Keyword == newLabel).Color;
                    node.BackColor = C.GetColor(itemColor);
                    if (itemColor == "Red" || itemColor == "Green" || itemColor == "Blue" || itemColor == "DarkGreen" || itemColor == "Brown")
                    {
                        node.ForeColor = Color.White;
                    }
                    else
                    {
                        node.ForeColor = Color.Black;
                    }
                }
            }
            if (node.Text.Contains("$LINK$>"))
            {
                node.ForeColor = Color.Blue;
                node.NodeFont = new Font(Font, FontStyle.Underline);
            }
            if (node.Text.Contains("$LITR$>"))
            {
                node.ForeColor = Color.Brown;
                node.NodeFont = new Font(Font, FontStyle.Underline);
            }
            if (node.Text.Contains("$NOTE$>"))
            {
                node.ForeColor = Color.DarkGreen;
                node.NodeFont = new Font(Font, FontStyle.Underline);
            }
            if (changeDescendant)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    changeNodeLabel(child, newLabel, changeDescendant);
                }
            }
        }

        private void updateNodeColor(TreeNode node)
        {
            // 检查是不是存在标签
            bool labeled = false;
            foreach (ListViewItem item in lsvColor.Items)
            {
                if (node.Text.Contains(item.Text)
                    && !node.Text.Contains("$LINK$>")
                    && !node.Text.Contains("$LITR$>")
                    && !node.Text.Contains("$NOTE$>"))
                {
                    labeled = true;
                    string itemColor = noteColors.Find(o => o.Keyword == item.Text).Color;
                    node.BackColor = C.GetColor(itemColor);
                    if (itemColor == "Red" || itemColor == "Green" || itemColor == "Blue" || itemColor == "DarkGreen" || itemColor == "Brown")
                    {
                        node.ForeColor = Color.White;
                    }
                    else
                    {
                        node.ForeColor = Color.Black;
                    }
                }
            }
            if (node.Text.Contains("$LINK$>"))
            {
                node.ForeColor = Color.Blue;
                node.NodeFont = new Font(Font, FontStyle.Underline);
            }
            if (node.Text.Contains("$LITR$>"))
            {
                node.ForeColor = Color.Brown;
                node.NodeFont = new Font(Font, FontStyle.Underline);
            }
            if (node.Text.Contains("$NOTE$>"))
            {
                node.ForeColor = Color.DarkGreen;
                node.NodeFont = new Font(Font, FontStyle.Underline);
            }
            if (!labeled)
            {
                node.ForeColor = Color.Black;
                node.BackColor = Color.White;
            }
        }

        private void replaceNodeText(TreeNode node, string oldString, string newString)
        {
            if (node.Text.Contains(oldString))
            {
                node.Text = node.Text.Replace(oldString, newString);
                updateNodeColor(node);

            }
            foreach (TreeNode child in node.Nodes)
            {
                replaceNodeText(child, oldString, newString);
            }
        }

        private void replaceText(string oldString, string newString)
        {
            replaceNodeText(trvNote.SelectedNode, oldString, newString);
        }

        private void appendNodeText(TreeNode node, string appString)
        {
            node.Text = node.Text + appString;
            updateNodeColor(node);
            foreach (TreeNode child in node.Nodes)
            {
                appendNodeText(child, appString);
            }
        }

        private void prependNodeText(TreeNode node, string preString)
        {
            node.Text = preString + node.Text;
            updateNodeColor(node);
            foreach (TreeNode child in node.Nodes)
            {
                prependNodeText(child, preString);
            }
        }

        private void trvNote_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvNote.SelectedNode.Text == txtTopic.Text)
            {
                tsmEdit.Enabled = false;
                tsmChangeLabel.Enabled = false;
                tsmUp.Enabled = false;
                tsmDown.Enabled = false;
                tsmBelongTo.Enabled = false;
                tsmIndependent.Enabled = false;
                tsmCopy.Enabled = false;
            }
            else
            {
                tsmEdit.Enabled = true;
                tsmChangeLabel.Enabled = true;
                tsmUp.Enabled = true;
                tsmDown.Enabled = true;
                tsmBelongTo.Enabled = true;
                tsmIndependent.Enabled = true;
                tsmCopy.Enabled = true;
            }
            if (M.mem.copiedNodes.Count == 0)
            {
                tsmPaste.Enabled = false;
            }
            else
            {
                tsmPaste.Enabled = true;
            }
            if (trvNote.SelectedNode.Text.Contains("$LINK$>")
                || trvNote.SelectedNode.Text.Contains("$LITR$>")
                || trvNote.SelectedNode.Text.Contains("$NOTE$>"))
            {
                tsmGoto.Enabled = true;
            }
            else
            {
                tsmGoto.Enabled = false;
            }
        }

        private void tsmGoto_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                if (trvNote.SelectedNode.Text.Contains("$LINK$>"))
                {
                    string selectedPath = trvNote.SelectedNode.Text.Replace("$LINK$>", "");
                    string[] checkUrl = selectedPath.Split(':');
                    if (checkUrl[0] == "http" || checkUrl[0] == "https")
                    {
                        System.Diagnostics.Process.Start("chrome.exe", selectedPath);
                    }
                    else
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(selectedPath);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("File/link is not found.");
                            throw;
                        }
                    }
                }
                else if (trvNote.SelectedNode.Text.Contains("$LITR$>"))
                {
                    string selectedPath = trvNote.SelectedNode.Text.Replace("$LITR$>", "");
                    if (G.glb.lstLiterature.Exists(o => o.Title == selectedPath))
                    {
                        frmInfoLiterature frmInfoLiterature = new frmInfoLiterature(selectedPath);
                        frmInfoLiterature.Show();
                    }
                    else if (G.glb.lstLiterature.Exists(o => o.BibKey == selectedPath))
                    {
                        string lit = G.glb.lstLiterature.FirstOrDefault(o => o.BibKey == selectedPath).Title;
                        frmInfoLiterature frmInfoLiterature = new frmInfoLiterature(lit);
                        frmInfoLiterature.Show();
                    }
                    else
                    {
                        MessageBox.Show("Literature does not exist in database");
                    }
                }
                else if (trvNote.SelectedNode.Text.Contains("$NOTE$>"))
                {
                    string selectedPath = trvNote.SelectedNode.Text.Replace("$NOTE$>", "");
                    string[] checkNote = selectedPath.Split('@');
                    DateTime noteDate = new DateTime();
                    string noteTitle = "";
                    bool tryOpenFlag = true;
                    if (checkNote.Length != 2)
                    {
                        MessageBox.Show("Incorrect Note Format, correct format should be 'YYYY.MM.DD@Note'");
                        tryOpenFlag = false;
                    }
                    else
                    {
                        string[] dateNote = checkNote[0].Split('.');
                        if (dateNote.Length != 3)
                        {
                            MessageBox.Show("Incorrect Note Format, correct format should be 'YYYY.MM.DD@Note'");
                            tryOpenFlag = false;
                        }
                        else
                        {
                            noteDate = new DateTime(Convert.ToInt32(dateNote[0]), Convert.ToInt32(dateNote[1]), Convert.ToInt32(dateNote[2]));
                        }
                    }

                    for (int i = 1; i < checkNote.Length; i++)
                    {
                        noteTitle = noteTitle + checkNote[i];
                        if (i < checkNote.Length - 1)
                        {
                            noteTitle = noteTitle + " ";
                        }
                    }
                    if (tryOpenFlag && G.glb.lstNote.Exists(o => o.TagTime == noteDate && o.Topic == noteTitle))
                    {
                        frmInfoNote frmInfoNote = new frmInfoNote(G.glb.lstNote.Find(o => o.TagTime == noteDate && o.Topic == noteTitle));
                        frmInfoNote.Show();
                    }
                    else
                    {
                        MessageBox.Show("Cannot find record.");
                    }
                }
            }
        }

        private void tsmAddNoteOutsource_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                string NewLog = Interaction.InputBox("Input new link note", "New Link", "New Link", 300, 300);
                TreeNode newNode = new TreeNode(NewLog, 0, 0);
                newNode.Text = "$LINK$>" + NewLog;
                newNode.Name = Guid.NewGuid().ToString();
                newNode.BackColor = SystemColors.Window;
                newNode.ForeColor = Color.Blue;
                newNode.NodeFont = new Font(Font, FontStyle.Underline);
                newNode.ExpandAll();
                trvNote.SelectedNode.ExpandAll();
                trvNote.SelectedNode.Nodes.Add(newNode);
            }
            btnSave.Enabled = true;
        }

        private void tsmAddNoteLiterature_Click(object sender, EventArgs e)
        {
            // 临时这么弄，晚些时候要换成列表选的那种
            if (trvNote.SelectedNode != null)
            {
                string NewLog = Interaction.InputBox("Input new literature note", "New Link", "New Link", 300, 300);
                TreeNode newNode = new TreeNode(NewLog, 0, 0);
                newNode.Text = "$LITR$>" + NewLog;
                newNode.Name = Guid.NewGuid().ToString();
                newNode.BackColor = SystemColors.Window;
                newNode.ForeColor = Color.Brown;
                newNode.NodeFont = new Font(Font, FontStyle.Underline);
                newNode.ExpandAll();
                trvNote.SelectedNode.ExpandAll();
                trvNote.SelectedNode.Nodes.Add(newNode);
            }
            btnSave.Enabled = true;
        }

        private void tsmNote_Click(object sender, EventArgs e)
        {
            // 临时这么弄，晚些时候要换成列表选的那种
            if (trvNote.SelectedNode != null)
            {
                string NewLog = Interaction.InputBox("Input new note link, in a format of 'YYYY.MM.DD@Note_Title'", "New Link", "New Link", 300, 300);
                TreeNode newNode = new TreeNode(NewLog, 0, 0);
                newNode.Text = "$NOTE$>" + NewLog;
                newNode.Name = Guid.NewGuid().ToString();
                newNode.BackColor = SystemColors.Window;
                newNode.ForeColor = Color.DarkGreen;
                newNode.NodeFont = new Font(Font, FontStyle.Underline);
                newNode.ExpandAll();
                trvNote.SelectedNode.ExpandAll();
                trvNote.SelectedNode.Nodes.Add(newNode);
            }
            btnSave.Enabled = true;
        }

        private void tsmReplace_Click(object sender, EventArgs e)
        {
            frmReplaceNote frmReplaceNote = new frmReplaceNote();
            frmReplaceNote.SendReplace += new frmReplaceNote.ReplaceString(replaceText);
            frmReplaceNote.Show();
        }

        private void tsmPrepend_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                string NewLog = Interaction.InputBox("Prepend to notes", "Prepend", "", 300, 300);
                if (NewLog != "")
                {
                    prependNodeText(trvNote.SelectedNode, NewLog);
                }
            }
            btnSave.Enabled = true;
        }

        private void tsmAppend_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                string NewLog = Interaction.InputBox("Append to notes", "Append", "", 300, 300);
                if (NewLog != "")
                {
                    appendNodeText(trvNote.SelectedNode, NewLog);
                }
            }
            btnSave.Enabled = true;
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            List<string> logList = writeByNode(trvNote.Nodes[0], 0);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(trvNote.Nodes[0].Text + ".txt", false))
            {
                foreach (string log in logList)
                {
                    file.WriteLine(log);
                }
                MessageBox.Show("Write notes to " + txtTopic.Text + ".txt");
            }
        }

        private List<string> writeByNode(TreeNode logNode, int level)
        {
            List<string> logList = new List<string>();
            string levelStr = "";
            for (int i = 0; i < level; i++)
            {
                levelStr += "\t";
            }
            logList.Add(levelStr + logNode.Text);
            foreach (TreeNode item in logNode.Nodes)
            {
                List<string> childLogList = writeByNode(item, level + 1);
                logList.AddRange(childLogList);
            }
            return logList;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Please select a .txt file.";
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            ;
            string openFilePath;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openFilePath = openFileDialog.FileName;
                string[] logList = System.IO.File.ReadAllLines(openFilePath);

                // validate - empty
                if (logList.Length == 0)
                {
                    MessageBox.Show("Emty .txt file.");
                }

                // validate - title
                else if (logList[0] != txtTopic.Text)
                {
                    MessageBox.Show("Does not match with title");
                }

                // reconstruct
                else if (logList.Length > 1)
                {
                    trvNote.Nodes.Clear();

                    TreeNode rootNode = new TreeNode(logList[0], 0, 0);
                    rootNode.Text = logList[0];
                    rootNode.Name = topicGUID;
                    rootNode.Expand();

                    trvNote.Nodes.Add(rootNode);

                    List<TreeNode> curTreeNode = new List<TreeNode>();
                    int curLevel = 0;
                    curTreeNode.Add(rootNode);

                    for (int i = 1; i < logList.Length; i++)
                    {
                        string[] sp = logList[i].Split('\t');
                        int level = sp.Length - 1;
                        string log = sp[sp.Length - 1];

                        TreeNode newNode = new TreeNode(log, 0, 0);
                        newNode.Text = log;
                        newNode.Name = Guid.NewGuid().ToString();
                        newNode.Expand();
                        updateNodeColor(newNode);

                        // 如果和上一行同级别，curTreeNode倒数第二个追加子节点，更新最后一个
                        if (curLevel == level && level > 0)
                        {
                            curTreeNode[curTreeNode.Count - 2].Nodes.Add(newNode);
                            curTreeNode[curTreeNode.Count - 1] = newNode;
                        }
                        // 如果比上一行级别多一，说明是上一行子节点
                        else if (curLevel + 1 == level)
                        {
                            curTreeNode[curTreeNode.Count - 1].Nodes.Add(newNode);
                            curTreeNode.Add(newNode);
                        }
                        // 如果比上一行少，说明回溯了
                        else if (curLevel > level)
                        {
                            curTreeNode[level - 1].Nodes.Add(newNode);
                            curTreeNode.RemoveRange(level, curTreeNode.Count - level);
                            curTreeNode.Add(newNode);
                        }
                        // 否则，不合法
                        else
                        {
                            MessageBox.Show("Illegal structure");
                        }
                        curLevel = level;
                    }
                }
            }
        }

        private bool validateNote(string[] logList)
        {
            List<int> levelList = new List<int>();
            foreach (string log in logList)
            {
                string[] sp = log.Split('\t');
                levelList.Add(sp.Length - 1);
            }
            return true;
        }

        private void tsmCopy_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Parent != null)
            {
                M.mem.copiedNodes.Clear();
                copyNode(trvNote.SelectedNode);
                tsmPaste.Enabled = true;
            }
        }

        private void copyNode(TreeNode node)
        {
            M.mem.copiedNodes.Add(new copiedNodeStruct(node.Text, node.Name, node.Parent.Name));
            foreach (TreeNode child in node.Nodes)
            {
                copyNode(child);
            }
        }

        private void tsmPaste_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && M.mem.copiedNodes.Count > 0)
            {
                TreeNode newCopiedRoot = new TreeNode();
                newCopiedRoot.Text = M.mem.copiedNodes[0].nodeText;
                pasteNode(newCopiedRoot, M.mem.copiedNodes[0].nodeGUID);
                newCopiedRoot.Name = Guid.NewGuid().ToString();
                updateNodeColor(newCopiedRoot);
                trvNote.SelectedNode.Nodes.Add(newCopiedRoot);
                btnSave.Enabled = true;
            }
        }

        private void pasteNode(TreeNode node, string nodeGUID)
        {
            if (M.mem.copiedNodes.Exists(o => o.nodeParentGUID == nodeGUID))
            {
                foreach (copiedNodeStruct item in M.mem.copiedNodes.FindAll(o => o.nodeParentGUID == nodeGUID))
                {
                    TreeNode newCopiedChild = new TreeNode();
                    newCopiedChild.Text = item.nodeText;
                    pasteNode(newCopiedChild, item.nodeGUID);
                    newCopiedChild.Name = Guid.NewGuid().ToString();
                    updateNodeColor(newCopiedChild);
                    node.Nodes.Add(newCopiedChild);
                }
            }
        }

        private void tsmProperties_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                CNoteProperties p = new CNoteProperties();
                p.Note = trvNote.SelectedNode.Text;
                p.NoteType = "NORM";
                if (trvNote.SelectedNode.Parent == null)
                {
                    p.NoteType = "ROOT";
                }
                else if (trvNote.SelectedNode.Text.Contains("$LINK$>"))
                {
                    p.NoteType = "LINK";
                }
                else if (trvNote.SelectedNode.Text.Contains("$NOTE$>"))
                {
                    p.NoteType = "NOTE";
                }
                else if (trvNote.SelectedNode.Text.Contains("$LITR$>"))
                {
                    p.NoteType = "LITR";
                }
                p.numChildren = trvNote.SelectedNode.Nodes.Count;
                foreach (TreeNode item in trvNote.SelectedNode.Nodes)
                {
                    if (item.Text.Contains("$LINK$>"))
                    {
                        p.numCLinks += 1;
                    }
                    else if (item.Text.Contains("$NOTE$>"))
                    {
                        p.numCNotes += 1;
                    }
                    else if (item.Text.Contains("$LITR$>"))
                    {
                        p.numCLitrs += 1;
                    }
                }
                int[] count = nodeProperties(trvNote.SelectedNode);
                p.numOffsprings = count[0];
                p.numOLinks = count[1];
                p.numONotes = count[2];
                p.numOLitrs = count[3];

                frmNoteProperties frmNoteProperties = new frmNoteProperties(p);
                frmNoteProperties.Show();
            }
        }

        private int[] nodeProperties(TreeNode node)
        {
            int[] count = new int[] { 0, 0, 0, 0 };
            foreach (TreeNode item in node.Nodes)
            {
                count[0] += 1;
                if (item.Text.Contains("$LINK$>"))
                {
                    count[1] += 1;
                }
                else if (item.Text.Contains("$NOTE$>"))
                {
                    count[2] += 1;
                }
                else if (item.Text.Contains("$LITR$>"))
                {
                    count[3] += 1;
                }
                int[] childCount = nodeProperties(item);
                for (int i = 0; i < childCount.Length; i++)
                {
                    count[i] += childCount[i];
                }
            }
            return count;
        }

        private void tsmFold_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                foreach (TreeNode item in trvNote.SelectedNode.Nodes)
                {
                    item.Collapse(true);
                }
            }
        }

        private void tsmExpand_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                trvNote.SelectedNode.ExpandAll();
                foreach (TreeNode item in trvNote.SelectedNode.Nodes)
                {
                    item.ExpandAll();
                }
            }
        }

        public int TreeNodeCompare(TreeNode x, TreeNode y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;
            return String.Compare(tx.Text, ty.Text);
        }

        private void tsmSort_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null &&
                MessageBox.Show("Confirm to sort children nodes.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                Comparison<TreeNode> sorterX = new Comparison<TreeNode>(TreeNodeCompare);
                List<TreeNode> al = new List<TreeNode>();

                foreach (TreeNode tn in trvNote.SelectedNode.Nodes)
                {
                    al.Add(tn);
                }
                al.Sort(sorterX);

                trvNote.SelectedNode.Nodes.Clear();
                foreach (TreeNode tn in al)
                {
                    trvNote.SelectedNode.Nodes.Add(tn);
                }
            }
        }

        private void trvNote_KeyDown(object sender, KeyEventArgs e)
        {
            // 新建节点
            if (e.Control && e.KeyCode == Keys.A)
            {
                tsmAdd_Click(trvNote, e);
            }
            // 批量新建
            else if (e.Control && e.KeyCode == Keys.B)
            {
                tsmAddBatch_Click(trvNote, e);
            }
            // 折叠
            else if (e.Control && e.KeyCode == Keys.N)
            {
                tsmFold_Click(trvNote, e);
            }
            // 展开
            else if (e.Control && e.KeyCode == Keys.M)
            {
                tsmExpand_Click(trvNote, e);
            }
            // 转到
            else if (e.Control && e.KeyCode == Keys.G)
            {
                tsmGoto_Click(trvNote, e);
            }
            // 编辑节点
            else if (e.Control && e.KeyCode == Keys.E)
            {
                tsmEdit_Click(trvNote, e);
            }
            // 复制
            else if (e.Control && e.KeyCode == Keys.C)
            {
                tsmCopy_Click(trvNote, e);
            }
            // 粘贴
            else if (e.Control && e.KeyCode == Keys.V)
            {
                tsmPaste_Click(trvNote, e);
            }
            // 删除
            else if (e.Control && e.KeyCode == Keys.D)
            {
                tsmRemove_Click(trvNote, e);
            }
            // 上移
            else if (e.Control && e.KeyCode == Keys.I)
            {
                tsmUp_Click(trvNote, e);
            }
            // 下移
            else if (e.Control && e.KeyCode == Keys.K)
            {
                tsmDown_Click(trvNote, e);
            }
            // 左移
            else if (e.Control && e.KeyCode == Keys.L)
            {
                tsmBelongTo_Click(trvNote, e);
            }
            // 右移
            else if (e.Control && e.KeyCode == Keys.J)
            {
                tsmIndependent_Click(trvNote, e);
            }
            // 节点属性
            else if (e.Control && e.KeyCode == Keys.P)
            {
                tsmProperties_Click(trvNote, e);
            }
            
        }

        private void trvNote_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null && e.Label.Trim().Length > 0)
            {
                string newLog = e.Label.Trim();
                trvNote.SelectedNode.Text = newLog;
                trvNote.SelectedNode.BackColor = SystemColors.Window;
                trvNote.SelectedNode.ForeColor = Color.Black;
                foreach (ListViewItem item in lsvColor.Items)
                {
                    if (newLog.Contains(item.Text)
                        && !newLog.Contains("$LINK$>")
                        && !newLog.Contains("$LITR$>")
                        && !newLog.Contains("$NOTE$>"))
                    {
                        string itemColor = noteColors.Find(o => o.Keyword == item.Text).Color;
                        trvNote.SelectedNode.BackColor = C.GetColor(itemColor);
                        if (itemColor == "Red" || itemColor == "Green" || itemColor == "Blue" || itemColor == "DarkGreen" || itemColor == "Brown")
                        {
                            trvNote.SelectedNode.ForeColor = Color.White;
                        }
                        else
                        {
                            trvNote.SelectedNode.ForeColor = Color.Black;
                        }
                    }
                }
                if (newLog.Contains("$LINK$>"))
                {
                    trvNote.SelectedNode.ForeColor = Color.Blue;
                    trvNote.SelectedNode.NodeFont = new Font(Font, FontStyle.Underline);
                }
                if (newLog.Contains("$LITR$>"))
                {
                    trvNote.SelectedNode.ForeColor = Color.Brown;
                    trvNote.SelectedNode.NodeFont = new Font(Font, FontStyle.Underline);
                }
                if (newLog.Contains("$NOTE$>"))
                {
                    trvNote.SelectedNode.ForeColor = Color.DarkGreen;
                    trvNote.SelectedNode.NodeFont = new Font(Font, FontStyle.Underline);
                }
                btnSave.Enabled = true;
            }
            else
            {
                e.CancelEdit = true;
            }
        }

        private void trvNote_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        string highlightText = "";
        private void btnHighlight_Click(object sender, EventArgs e)
        {
            if (txtHighlight.Text.Length > 0)
            {
                highlightText = txtHighlight.Text;
            }
            else
            {
                highlightText = "";
            }
            SaveNoteLog();
            LoadNoteLog();
        }

        private void txtHighlight_TextChanged(object sender, EventArgs e)
        {
            if (txtHighlight.Text.Length == 0)
            {
                highlightText = ""; 
                SaveNoteLog();
                LoadNoteLog();
            }
        }

        private void CheckPassword(string password)
        {
            if (password == "1992Linear?Peng0821")
            {
                btnRead.Enabled = true;
                btnWrite.Enabled = true;
                btnSave.Enabled = true;
                btnLock.Text = "Lock";
                trvNote.Show();
                lockMode = false;
            }
            else
            {
                MessageBox.Show("Incorrect Password, access denied");
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (!lockMode)
            {
                btnRead.Enabled = false;
                btnWrite.Enabled = false;
                btnSave.Enabled = false;
                btnLock.Text = "Unlock";
                trvNote.Hide();
                lockMode = true;
            }
            else
            {
                frmNotePassword frmNotePassword = new frmNotePassword();
                frmNotePassword.SendPassword += new frmNotePassword.GetPassword(CheckPassword);
                frmNotePassword.Show();
            }
        }
    }
    public class CNoteProperties
    {
        public string Note = "";
        public string NoteType = "";
        public int numChildren = 0;
        public int numCLinks = 0;
        public int numCNotes = 0;
        public int numCLitrs = 0;
        public int numOffsprings = 0;
        public int numOLinks = 0;
        public int numONotes = 0;
        public int numOLitrs = 0;
    }
}
