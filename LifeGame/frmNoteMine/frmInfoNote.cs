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
        CNote note = new CNote();
        List<RNoteLog> noteLogs = new List<RNoteLog>();
        List<RNoteOutsource> noteOutsources = new List<RNoteOutsource>();
        bool RefreshInMain = true;
        public frmInfoNote(CNote info)
        {
            note = info;
            noteLogs = G.glb.lstNoteLog.FindAll(o => o.TagTime == info.TagTime && o.Topic == info.Topic);
            noteOutsources = G.glb.lstNoteOutsource.FindAll(o => o.TagTime == info.TagTime && o.Topic == info.Topic);
            InitializeComponent();
            LoadNoteLog();
            LoadNoteOutsource();
            dtpDate.Value = note.TagTime;
            txtTopic.Enabled = false;
        }

        public frmInfoNote(DateTime selectedDate)
        {
            InitializeComponent();
            note = new CNote();
            noteLogs = new List<RNoteLog>();
            noteOutsources = new List<RNoteOutsource>();
            LoadNoteLog();
            LoadNoteOutsource();
            dtpDate.Value = selectedDate;
        }

        public frmInfoNote(string LiteratureTitle)
        {
            RefreshInMain = false;
            InitializeComponent();
            note = new CNote();
            noteLogs = new List<RNoteLog>();
            List<RLiteratureOutSource> litOutSources = G.glb.lstLiteratureOutSource.FindAll(o => o.Title == LiteratureTitle).ToList();
            for (int i = 0; i < litOutSources.Count; i++)
            {
                RNoteOutsource noteOutsource = new RNoteOutsource();
                noteOutsource.TagTime = DateTime.Today.Date;
                noteOutsource.Topic = litOutSources[i].Title;
                noteOutsource.Outsourcepath = litOutSources[i].OutsourcePath;
                noteOutsources.Add(noteOutsource);
            }
            LoadNoteLog();
            LoadNoteOutsource();
            txtTopic.Text = LiteratureTitle;
            dtpDate.Value = DateTime.Today.Date;
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

        private void LoadNoteLog()
        {
            trvNote.Nodes.Clear();
            TreeNode rootNode = new TreeNode(note.Topic, 0, 0);
            rootNode.Name = note.Topic;
            LoadChildNoteLog(rootNode);
            trvNote.Nodes.Add(rootNode);
        }

        private void LoadChildNoteLog(TreeNode treeNode)
        {
            // 如果本条NoteLog作为上级NoteLog存在，添加所有的SubLog
            if (noteLogs.Exists(o => o.Log == treeNode.Text))
            {
                List<RNoteLog> subNoteLog = G.glb.lstNoteLog.FindAll(o => o.Log == treeNode.Text).ToList();
                subNoteLog = subNoteLog.OrderBy(o => o.Index).ToList();
                foreach (RNoteLog sub in subNoteLog)
                {
                    TreeNode childNode = new TreeNode(sub.SubLog);
                    childNode.Name = sub.SubLog;
                    LoadChildNoteLog(childNode);
                    treeNode.Nodes.Add(childNode);
                }
            }
        }

        private void frmInfoNote_FormClosing(object sender, FormClosingEventArgs e)
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
                if (RefreshInMain)
                {
                    DrawLog();
                }
            }
            Dispose();
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void frmInfoNote_Load(object sender, EventArgs e)
        { 
            // Bind Task
            List<CTask> taskChoices = G.glb.lstTask.FindAll(o => o.IsBottom && o.TaskState != ETaskState.Finished && o.TaskState != ETaskState.Aborted).ToList();
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

                if (noteLogs.Exists(o => o.Log == trvNote.SelectedNode.Text && o.SubLog == NewLog) || NewLog == note.Topic)
                {
                    MessageBox.Show("The note exists!");
                }
                else
                {
                    RNoteLog newNoteLog = new RNoteLog();
                    newNoteLog.TagTime = dtpDate.Value.Date;
                    newNoteLog.Log = trvNote.SelectedNode.Text;
                    newNoteLog.SubLog = NewLog;
                    newNoteLog.Index = trvNote.SelectedNode.Nodes.Count;
                    noteLogs.Add(newNoteLog);
                    TreeNode newNode = new TreeNode(NewLog, 0, 0);
                    newNode.Name = NewLog;
                    trvNote.SelectedNode.Nodes.Add(newNode);
                }
            }
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Parent != null)
            {
                string OldLog = trvNote.SelectedNode.Text;
                string NewLog = Interaction.InputBox("Rename Note", "Rename Note", trvNote.SelectedNode.Text, 300, 300);
                foreach (RNoteLog noteLog in noteLogs)
                {
                    if (noteLog.Log == OldLog)
                    {
                        noteLog.Log = NewLog;
                    }
                    if (noteLog.SubLog == OldLog)
                    {
                        noteLog.SubLog = NewLog;
                    }
                    trvNote.SelectedNode.Text = NewLog;
                    trvNote.SelectedNode.Name = NewLog;
                }
            }
        }

        private void tsmRemove_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Parent != null)
            {
                if (trvNote.SelectedNode.Nodes.Count == 0)
                {
                    string UpperNote = trvNote.SelectedNode.Parent.Text;
                    string NoteName = trvNote.SelectedNode.Text;
                    noteLogs.RemoveAll(o => o.Log == UpperNote && o.SubLog == NoteName);
                    trvNote.Nodes.Remove(trvNote.SelectedNode);
                    ReIndex(UpperNote);
                }
                else
                {
                    MessageBox.Show("To be cautious, can not remove note with sub node");
                }
            }
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
                string UpperNote = trvNote.SelectedNode.Parent.Text;
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
                    ReIndex(UpperNote);
                }
            }
        }

        private void tsmDown_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                string UpperNote = trvNote.SelectedNode.Parent.Text;
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
                    ReIndex(UpperNote);
                }
            }
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
                    noteLogs.RemoveAll(o => o.Log == parentNode.Text && o.SubLog == node.Text);
                    RNoteLog newSub = new RNoteLog();
                    newSub.Log = preNode.Text;
                    newSub.SubLog = node.Text;
                    newSub.Index = preNode.Nodes.Count;
                    noteLogs.Add(newSub);
                    preNode.Nodes.Insert(preNode.Nodes.Count, newNode);
                    node.Remove();
                    trvNote.SelectedNode = newNode;
                    ReIndex(parentNodeName);
                    ReIndex(preNodeName);
                }
            }
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
                    noteLogs.RemoveAll(o => o.Log == parentNode.Text && o.SubLog == node.Text);
                    RNoteLog newSub = new RNoteLog();
                    newSub.Log = grandparentNode.Text;
                    newSub.SubLog = node.Text;
                    newSub.Index = grandparentNode.Nodes.Count;
                    noteLogs.Add(newSub);
                    grandparentNode.Nodes.Insert(parentNode.Index + 1, newNode);
                    node.Remove();
                    trvNote.SelectedNode = newNode;
                    ReIndex(grandparentNodeName);
                    ReIndex(parentNodeName);
                }
            }
        }

        private void tsmChangeLogo_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {

            }
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
        }

        private void tsmDeleteOutsource_Click(object sender, EventArgs e)
        {
            if (lsbOutsource.SelectedItem != null)
            {
                noteOutsources.RemoveAll(o => o.Outsourcepath == lsbOutsource.SelectedItem.ToString());
                LoadNoteOutsource();
            }
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
    }
}
