using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        public frmInfoNote(CNote info)
        {
            note = info;
            noteLogs = G.glb.lstNoteLog.FindAll(o => o.TagTime == info.TagTime && o.Topic == info.Topic);
            noteOutsources = G.glb.lstNoteOutsource.FindAll(o => o.TagTime == info.TagTime && o.Topic == info.Topic);
            noteColors = G.glb.lstNoteColor.FindAll(o => o.TagTime == info.TagTime && o.Topic == info.Topic);
            InitializeComponent();
            LoadNoteColor();
            LoadNoteLog();
            LoadNoteOutsource();            
            dtpDate.Value = note.TagTime;
            txtTopic.Enabled = false;
            btnSave.Enabled = false;
        }

        public frmInfoNote(DateTime selectedDate)
        {
            InitializeComponent();
            note = new CNote();
            noteLogs = new List<RNoteLog>();
            noteOutsources = new List<RNoteOutsource>();
            noteColors = new List<RNoteColor>();
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

        private void LoadNote()
        {
            txtTopic.Text = note.Topic;
            txtLiteratureTitle.Text = note.LiteratureTitle;
            cbxTask.Text = note.TaskName;
            chkFinished.Checked = note.FinishedNote;
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
                item.Checked = true;
                lsvColor.Items.Add(item);
            }
        }

        private void LoadNoteLog()
        {
            trvNote.Nodes.Clear();
            TreeNode rootNode = new TreeNode(note.Topic, 0, 0);
            rootNode.Name = note.Topic;
            LoadChildNoteLog(rootNode, note.Topic);
            trvNote.Nodes.Add(rootNode);
        }        

        private void LoadChildNoteLog(TreeNode treeNode, string topic)
        {
            // 如果本条NoteLog作为上级NoteLog存在，添加所有的SubLog
            if (noteLogs.Exists(o => o.Log == treeNode.Text && o.Topic == topic))
            {
                List<RNoteLog> subNoteLog = G.glb.lstNoteLog.FindAll(o => o.Log == treeNode.Text && o.Topic == note.Topic).ToList();
                subNoteLog = subNoteLog.OrderBy(o => o.Index).ToList();
                foreach (RNoteLog sub in subNoteLog)
                {
                    TreeNode childNode = new TreeNode(sub.SubLog);
                    childNode.Name = sub.SubLog;
                    childNode.BackColor = SystemColors.Window;
                    foreach (ListViewItem item in lsvColor.CheckedItems)
                    {
                        if (sub.SubLog.ToUpper().Contains(item.Text.ToUpper()))
                        {
                            childNode.BackColor = C.GetColor(noteColors.Find(o => o.Keyword == item.Text).Color);
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
            newNoteLog.TagTime = dtpDate.Value.Date;
            newNoteLog.Log = treeNode.Parent.Text;
            newNoteLog.SubLog = treeNode.Text;
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
                string NewLog = Interaction.InputBox("Input new note node", "New Note", "New Note", 300, 300);
                TreeNode newNode = new TreeNode(NewLog, 0, 0);
                newNode.Name = NewLog;
                newNode.BackColor = SystemColors.Window;
                foreach (ListViewItem item in lsvColor.CheckedItems)
                {
                    if (NewLog.ToUpper().Contains(item.Text.ToUpper()))
                    {
                        newNode.BackColor = C.GetColor(noteColors.Find(o => o.Keyword == item.Text).Color);
                    }
                }
                trvNote.SelectedNode.Nodes.Add(newNode);
            }
            btnSave.Enabled = true;
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Parent != null)
            {
                string newLog = Interaction.InputBox("Rename Note", "Rename Note", trvNote.SelectedNode.Text, 300, 300);
                trvNote.SelectedNode.Text = newLog;
                trvNote.SelectedNode.Name = newLog;
                trvNote.SelectedNode.BackColor = SystemColors.Window;
                foreach (ListViewItem item in lsvColor.CheckedItems)
                {
                    if (newLog.ToUpper().Contains(item.Text.ToUpper()))
                    {
                        trvNote.SelectedNode.BackColor = C.GetColor(noteColors.Find(o => o.Keyword == item.Text).Color);
                    }
                }
            }
            btnSave.Enabled = true;
        }

        private void tsmRemove_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Parent != null)
            {
                if (trvNote.SelectedNode.Nodes.Count == 0)
                {
                    string UpperNote = trvNote.SelectedNode.Parent.Text;
                    string NoteName = trvNote.SelectedNode.Text;
                    trvNote.Nodes.Remove(trvNote.SelectedNode);
                }
                else
                {
                    MessageBox.Show("To be cautious, can not remove note with sub node");
                }
            }
            btnSave.Enabled = true;
        }

        private void ReIndex(string UpperNote)
        {
            List<RNoteLog> sameLevel = noteLogs.FindAll(o => o.Log == UpperNote).ToList();
            foreach (RNoteLog sub in sameLevel)
            {
                noteLogs.Find(o => o.Log == UpperNote && o.SubLog == sub.SubLog).Index = trvNote.Nodes.Find(sub.SubLog, true).FirstOrDefault().Index;
            }
        }

        private void tsmUp_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                string upperNote = trvNote.SelectedNode.Parent.Text;
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
                string upperNote = trvNote.SelectedNode.Parent.Text;
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
                TreeNode parentNode = node.Parent;
                TreeNode newNode = (TreeNode)node.Clone();
                if (node.Parent != null && node.PrevNode != null)
                {
                    string preNodeName = preNode.Text;
                    string parentNodeName = parentNode.Text;
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
                    string parentNodeName = parentNode.Text;
                    string grandparentNodeName = grandparentNode.Text;
                    grandparentNode.Nodes.Insert(parentNode.Index + 1, newNode);
                    node.Remove();
                    trvNote.SelectedNode = newNode;
                    ReIndex(grandparentNodeName);
                    ReIndex(parentNodeName);
                }
            }
            btnSave.Enabled = true;
        }

        private void txtTopic_TextChanged(object sender, EventArgs e)
        {
            note.Topic = txtTopic.Text;
            trvNote.Nodes[0].Text = txtTopic.Text;
            trvNote.Nodes[0].Name = txtTopic.Text;
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

        private void addNoteColor(string Keyword, string Color)
        {
            if (!noteColors.Exists(o => o.Keyword == Keyword))
            {      
                RNoteColor newNoteColor = new RNoteColor();
                newNoteColor.Topic = txtTopic.Text;
                newNoteColor.TagTime = dtpDate.Value.Date;
                newNoteColor.Keyword = Keyword;
                newNoteColor.Color = Color;
                noteColors.Add(newNoteColor);

                ListViewItem item = new ListViewItem();
                item.Text = Keyword;                
                plot C = new plot();
                item.BackColor = C.GetColor(Color);
                item.Checked = true;
                lsvColor.Items.Add(item);                
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
                LoadNoteLog();
            }
        }

        private void lsvColor_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            LoadNoteLog();
        }
    }
}
