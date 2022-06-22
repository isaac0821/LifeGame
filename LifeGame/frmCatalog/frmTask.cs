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
    public partial class frmTask : Form
    {
        public frmTask()
        {
            InitializeComponent();
        }

        private void frmTask_Load(object sender, EventArgs e)
        {
            LoadTrvTask();
        }

        private void frmTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 重新刷新index
        }

        private void ReIndex(string UpperTask)
        {
            List<RSubTask> sameLevel = G.glb.lstSubTask.FindAll(o => o.Task == UpperTask);
            foreach (RSubTask subTask in sameLevel)
            {
                G.glb.lstSubTask.Find(o => o.Task == UpperTask && o.SubTask == subTask.SubTask).index = trvTask.Nodes.Find(subTask.SubTask, true).FirstOrDefault().Index;
            }
        }

        private void LoadTrvTask()
        {
            trvTask.Nodes.Clear();
            TreeNode rootNode = new TreeNode("(Root)", 0, 0);
            rootNode.Name = "(Root)";
            rootNode.ExpandAll();
            LoadChildTaskNode(rootNode);
            RefreshIcon(rootNode);
            trvTask.Nodes.Add(rootNode);
        }

        private void LoadChildTaskNode(TreeNode treeNode)
        {
            // 若在任务关系表中查找得到有该task作为上级task
            if (G.glb.lstSubTask.Exists(o => o.Task == treeNode.Text))
            {
                List<RSubTask> subTasks = G.glb.lstSubTask.FindAll(o => o.Task == treeNode.Text);
                subTasks = subTasks.OrderBy(o => o.index).ToList();
                foreach (RSubTask subTask in subTasks)
                {
                    TreeNode childNode = new TreeNode(subTask.SubTask);
                    childNode.Name = subTask.SubTask;
                    childNode.ExpandAll();
                    LoadChildTaskNode(childNode);
                    treeNode.Nodes.Add(childNode);
                }
            }
        }

        private void LoadTask(string taskName)
        {
            chkBottom.Enabled = false;
            chkFinished.Enabled = false;
            dtpDeadline.Enabled = false;
            chkInfinite.Enabled = false;
            dgvLog.Rows.Clear();
            if (G.glb.lstTask.Exists(o => o.TaskName == taskName))
            {
                CTask task = G.glb.lstTask.Find(o => o.TaskName == taskName);
                lblTaskTitle.Text = task.TaskName;
                chkBottom.Checked = task.IsBottom;
                if (task.TaskState == ETaskState.Finished)
                {
                    chkFinished.Checked = true;
                }
                calculate C = new calculate();
                lblTaskTimeSpent.Text = Math.Round(C.CalTimeSpentInTask(task.TaskName, G.glb.lstSubTask, G.glb.lstLog),2).ToString() + "h";
                DateTime? NextTimeMarker = C.FindNextTimeMarker(task.TaskName, G.glb.lstSubTask, G.glb.lstTask);
                if (NextTimeMarker != null)
                {
                    dtpNextTimeMarker.Value = (DateTime)NextTimeMarker;
                }
                else
                {
                    dtpNextTimeMarker.Value = new DateTime(9998, 12, 31);
                }
                if (task.IsInfinite)
                {
                    chkInfinite.Checked = true;
                    dtpDeadline.Value = new DateTime(9998, 12, 31);
                }
                else
                {
                    chkInfinite.Checked = false;
                    dtpDeadline.Value = task.DeadLine;
                }
                List<string> bottomTasks = C.FindAllBottomTask(taskName, G.glb.lstSubTask);
                foreach (string bottomTask in bottomTasks)
                {
                    List<CLog> logs = G.glb.lstLog.FindAll(o => o.ContributionToTask == bottomTask);
                    foreach (CLog log in logs)
                    {
                        TimeSpan span = log.EndTime - log.StartTime;
                        dgvLog.Rows.Add(
                            log.StartTime.ToString("MM/dd/yyyy"),
                            bottomTask,
                            log.LogName,
                            span.TotalHours
                            );
                    }
                }
                lsbTaskNote.Items.Clear();
                List<CNote> notes = G.glb.lstNote.FindAll(o => C.FindAllHeirTask(taskName, G.glb.lstSubTask).Exists(p => p == o.TaskName));
                foreach (CNote note in notes)
                {
                    lsbTaskNote.Items.Add(note.TagTime.Year.ToString() + "." + note.TagTime.Month.ToString() + "." + note.TagTime.Day.ToString() + " - " + note.Topic);
                }
            }
            else
            {
                lblTaskTitle.Text = "(No Record)";
                chkBottom.Checked = false;
                chkFinished.Checked = false;
                chkInfinite.Checked = false;
                lblTaskTimeSpent.Text = "----";
                lsbTaskNote.Items.Clear();
                dtpNextTimeMarker.Value = DateTime.Today;
                dtpDeadline.Value = DateTime.Today;
            }
        }

        private void RefreshIcon(TreeNode node)
        {
            int iconIndex;
            if (G.glb.lstTask.Exists(o => o.TaskName == node.Text))
            {
                if (!G.glb.lstTask.Find(o => o.TaskName == node.Text).IsInfinite)
                {
                    switch (G.glb.lstTask.Find(o => o.TaskName == node.Text).TaskState)
                    {
                        case ETaskState.NotStartedYet:
                            iconIndex = 1;
                            break;
                        case ETaskState.Ongoing:
                            iconIndex = 2;
                            break;
                        case ETaskState.Finished:
                            iconIndex = 3;
                            break;
                        case ETaskState.Aborted:
                            iconIndex = 4;
                            break;
                        default:
                            iconIndex = 0;
                            break;
                    }
                }
                else
                {
                    switch (G.glb.lstTask.Find(o => o.TaskName == node.Text).TaskState)
                    {
                        case ETaskState.NotStartedYet:
                            iconIndex = 5;
                            break;
                        case ETaskState.Ongoing:
                            iconIndex = 6;
                            break;
                        case ETaskState.Finished:
                            iconIndex = 7;
                            break;
                        case ETaskState.Aborted:
                            iconIndex = 8;
                            break;
                        default:
                            iconIndex = 0;
                            break;
                    }
                }
            }
            else
            {
                iconIndex = 0;
            }
            node.ImageIndex = iconIndex;
            node.SelectedImageIndex = iconIndex;
            foreach (TreeNode child in node.Nodes)
            {
                RefreshIcon(child);
            }
        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            if (trvTask.SelectedNode != null)
            {
                if (!G.glb.lstTask.Exists(o => o.TaskName == trvTask.SelectedNode.Text) && trvTask.SelectedNode.Text != "(Root)")
                {
                    MessageBox.Show("Cannot find the task.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (trvTask.SelectedNode.Text == "(Root)")
                    {
                        TreeNode node = trvTask.SelectedNode;
                        frmAddTask frmAddTask = new frmAddTask(trvTask.SelectedNode.Text);
                        frmAddTask.AddChildNode += new frmAddTask.DrawLogHandler(AddChildNode);
                        frmAddTask.Show();
                    }
                    else
                    {
                        if (G.glb.lstTask.Find(o => o.TaskName == trvTask.SelectedNode.Text).IsBottom)
                        {
                            MessageBox.Show("This task is unextendable.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            TreeNode node = trvTask.SelectedNode;
                            frmAddTask frmAddTask = new frmAddTask(trvTask.SelectedNode.Text);
                            frmAddTask.AddChildNode += new frmAddTask.DrawLogHandler(AddChildNode);
                            frmAddTask.Show();
                        }
                    }
                }
            }
        }

        private void AddChildNode(string nodeName)
        {
            if (trvTask.SelectedNode != null)
            {
                TreeNode node = trvTask.SelectedNode;
                TreeNode newNode = new TreeNode(nodeName, 1, 1);
                newNode.Name = nodeName;
                node.Nodes.Add(newNode);
                calculate C = new calculate();
                C.RefreshFinishTask(trvTask.SelectedNode.Text, G.glb.lstSubTask, G.glb.lstTask, G.glb.lstLog);
                RefreshIcon(trvTask.Nodes[0]);
            }
        }

        private void tsmRemove_Click(object sender, EventArgs e)
        {
            if (trvTask.SelectedNode != null)
            {
                // 对于根节点，不让删
                if (trvTask.SelectedNode.Text == "(Root)")
                {
                    MessageBox.Show("Cannot remove the root.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (G.glb.lstTask.Exists(o => o.TaskName == trvTask.SelectedNode.Text))
                {
                    string UpperTask = trvTask.SelectedNode.Parent.Text;
                    calculate C = new calculate();
                    bool CanDeleteFlag = C.DeleteTask(trvTask.SelectedNode.Text, G.glb.lstSubTask, G.glb.lstTask, G.glb.lstLog, G.glb.lstSchedule);
                    if (CanDeleteFlag)
                    {
                        trvTask.Nodes.Remove(trvTask.SelectedNode);
                        C.RefreshFinishTask(UpperTask, G.glb.lstSubTask, G.glb.lstTask, G.glb.lstLog);
                        ReIndex(UpperTask);
                        RefreshIcon(trvTask.Nodes[0]);
                    }
                }
            }
        }

        private void tsmUp_Click(object sender, EventArgs e)
        {
            if (trvTask.SelectedNode != null)
            {
                if (trvTask.SelectedNode.Text != "(Root)")
                {
                    string UpperTask = trvTask.SelectedNode.Parent.Text;
                    TreeNode node = trvTask.SelectedNode;
                    TreeNode preNode = node.PrevNode;
                    if (preNode != null)
                    {
                        TreeNode newNode = (TreeNode)node.Clone();
                        if (node.Parent == null)
                        {
                            trvTask.Nodes.Insert(preNode.Index, newNode);
                        }
                        else
                        {
                            node.Parent.Nodes.Insert(preNode.Index, newNode);
                        }
                        node.Remove();
                        trvTask.SelectedNode = newNode;
                        ReIndex(UpperTask);
                    }
                }
            }
        }

        private void tsmDown_Click(object sender, EventArgs e)
        {
            if (trvTask.SelectedNode != null)
            {
                if (trvTask.SelectedNode.Text != "(Root)")
                {
                    string UpperTask = trvTask.SelectedNode.Parent.Text;
                    TreeNode node = trvTask.SelectedNode;
                    TreeNode nextNode = node.NextNode;
                    if (nextNode != null)
                    {
                        TreeNode newNode = (TreeNode)node.Clone();
                        if (node.Parent == null)
                        {
                            trvTask.Nodes.Insert(nextNode.Index + 1, newNode);
                        }
                        else
                        {
                            node.Parent.Nodes.Insert(nextNode.Index + 1, newNode);
                        }
                        node.Remove();
                        trvTask.SelectedNode = newNode;
                        ReIndex(UpperTask);
                    }
                }
            }
        }

        private void tsmBelongTo_Click(object sender, EventArgs e)
        {
            if (trvTask.SelectedNode != null)
            {
                TreeNode node = trvTask.SelectedNode;
                TreeNode preNode = node.PrevNode;
                TreeNode parentNode = node.Parent;
                TreeNode newNode = (TreeNode)node.Clone();
                if (node.Parent != null && node.PrevNode != null)
                {
                    string preNodeName = preNode.Text;
                    string parentNodeName = parentNode.Text;
                    G.glb.lstSubTask.RemoveAll(o => o.Task == parentNode.Text && o.SubTask == node.Text);
                    RSubTask newSub = new RSubTask();
                    newSub.Task = preNode.Text;
                    newSub.SubTask = node.Text;
                    newSub.index = preNode.Nodes.Count;
                    G.glb.lstSubTask.Add(newSub);
                    preNode.Nodes.Insert(preNode.Nodes.Count, newNode);
                    node.Remove();
                    trvTask.SelectedNode = newNode;
                    ReIndex(parentNodeName);
                    ReIndex(preNodeName);
                    calculate C = new calculate();
                    C.RefreshFinishTask(preNodeName, G.glb.lstSubTask, G.glb.lstTask, G.glb.lstLog);
                    RefreshIcon(trvTask.Nodes[0]);
                }
            }
        }

        private void tsmIndependent_Click(object sender, EventArgs e)
        {
            if (trvTask.SelectedNode != null)
            {
                TreeNode node = trvTask.SelectedNode;
                TreeNode parentNode = node.Parent;
                TreeNode grandparentNode = node.Parent.Parent;
                TreeNode newNode = (TreeNode)node.Clone();
                if (node.Parent != null && node.Parent.Parent!=null)
                {
                    string parentNodeName = parentNode.Text;
                    string grandparentNodeName = grandparentNode.Text;
                    G.glb.lstSubTask.RemoveAll(o => o.Task == parentNode.Text && o.SubTask == node.Text);
                    RSubTask newSub = new RSubTask();
                    newSub.Task = grandparentNode.Text;
                    newSub.SubTask = node.Text;
                    newSub.index = grandparentNode.Nodes.Count;
                    G.glb.lstSubTask.Add(newSub);
                    grandparentNode.Nodes.Insert(parentNode.Index + 1, newNode);
                    node.Remove();
                    trvTask.SelectedNode = newNode;
                    ReIndex(grandparentNodeName);
                    ReIndex(parentNodeName);
                    calculate C = new calculate();
                    C.RefreshFinishTask(parentNodeName, G.glb.lstSubTask, G.glb.lstTask, G.glb.lstLog);
                    RefreshIcon(trvTask.Nodes[0]);
                }
            }
        }

        private void tsmFinished_Click(object sender, EventArgs e)
        {
            if (trvTask.SelectedNode != null)
            {
                if (trvTask.SelectedNode.Text == "(Root)")
                {
                    MessageBox.Show("Cannot finish the 'root'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (G.glb.lstTask.Exists(o => o.TaskName == trvTask.SelectedNode.Text))
                {
                    if (G.glb.lstTask.Find(o => o.TaskName == trvTask.SelectedNode.Text).TaskState != ETaskState.Finished)
                    {
                        calculate C = new calculate();
                        C.FinishTask(trvTask.SelectedNode.Text, G.glb.lstSubTask, G.glb.lstTask, G.glb.lstLog);
                        C.RefreshFinishTask(trvTask.SelectedNode.Parent.Text, G.glb.lstSubTask, G.glb.lstTask, G.glb.lstLog);
                        RefreshIcon(trvTask.Nodes[0]);
                    }
                    else
                    {
                        calculate C = new calculate();
                        C.UnfinishTask(trvTask.SelectedNode.Text, G.glb.lstSubTask, G.glb.lstTask, G.glb.lstLog);
                        C.RefreshFinishTask(trvTask.SelectedNode.Parent.Text, G.glb.lstSubTask, G.glb.lstTask, G.glb.lstLog);
                        RefreshIcon(trvTask.Nodes[0]);
                    }
                }
            }
        }

        private void tsmAbort_Click(object sender, EventArgs e)
        {
            if (trvTask.SelectedNode != null)
            {
                // 对于根节点，不让Abort
                if (trvTask.SelectedNode.Text == "(Root)")
                {
                    MessageBox.Show("Cannot abort the root.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (G.glb.lstTask.Exists(o => o.TaskName == trvTask.SelectedNode.Text))
                {
                    if (G.glb.lstTask.Find(o => o.TaskName == trvTask.SelectedNode.Text).TaskState != ETaskState.Aborted)
                    {
                        calculate C = new calculate();
                        C.AbortTask(trvTask.SelectedNode.Text, G.glb.lstSubTask, G.glb.lstTask, G.glb.lstLog);
                        C.RefreshFinishTask(trvTask.SelectedNode.Parent.Text, G.glb.lstSubTask, G.glb.lstTask, G.glb.lstLog);
                        RefreshIcon(trvTask.Nodes[0]);
                    }
                    else
                    {
                        calculate C = new calculate();
                        C.ReAssignTask(trvTask.SelectedNode.Text, G.glb.lstSubTask, G.glb.lstTask, G.glb.lstLog);
                        C.RefreshFinishTask(trvTask.SelectedNode.Parent.Text, G.glb.lstSubTask, G.glb.lstTask, G.glb.lstLog);
                        RefreshIcon(trvTask.Nodes[0]);
                    }
                }
            }
        }

        private void tsmRename_Click(object sender, EventArgs e)
        {
            if (trvTask.SelectedNode != null)
            {
                if (trvTask.SelectedNode.Text != "(Root)")
                {
                    string PreviousName = trvTask.SelectedNode.Text;
                    string NewName = Interaction.InputBox("Input New Task Name", "Rename", trvTask.SelectedNode.Text, 300, 300);
                    if (G.glb.lstTask.Exists(o => o.TaskName == NewName))
                    {
                        MessageBox.Show("New task name already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        G.glb.lstTask.Find(o => o.TaskName == PreviousName).TaskName = NewName;
                        List<RSubTask> rSubTasks = G.glb.lstSubTask.FindAll(o => o.Task == PreviousName);
                        foreach (RSubTask subTask in rSubTasks)
                        {
                            subTask.Task = NewName;
                        }
                        G.glb.lstSubTask.Find(o => o.SubTask == PreviousName).SubTask = NewName;
                        List<CLog> logs = G.glb.lstLog.FindAll(o => o.ContributionToTask == PreviousName);
                        foreach (CLog log in logs)
                        {
                            log.ContributionToTask = NewName;
                        }
                        List<CLog> schedules = G.glb.lstSchedule.FindAll(o => o.ContributionToTask == PreviousName);
                        foreach (CLog schedule in schedules)
                        {
                            schedule.ContributionToTask = NewName;
                        }
                        trvTask.SelectedNode.Text = NewName;
                        trvTask.SelectedNode.Name = NewName;
                    }
                }
            }
        }

        private void trvTask_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvTask.SelectedNode != null)
            {
                LoadTask(trvTask.SelectedNode.Text);
                if (!G.glb.lstTask.Exists(o => o.TaskName == trvTask.SelectedNode.Text))
                {
                    tsmAdd.Enabled = true;
                    tsmRename.Enabled = false;
                    tsmRemove.Enabled = false;
                    tsmUp.Enabled = false;
                    tsmDown.Enabled = false;
                    tsmBelongTo.Enabled = false;
                    tsmIndependent.Enabled = false;
                    tsmFinished.Enabled = false;
                    tsmAbort.Enabled = false;
                }
                else
                {
                    tsmAdd.Enabled = true;
                    tsmRename.Enabled = true;
                    tsmRemove.Enabled = true;
                    tsmUp.Enabled = true;
                    tsmDown.Enabled = true;
                    tsmBelongTo.Enabled = true;
                    tsmIndependent.Enabled = true;
                    tsmFinished.Enabled = true;
                    tsmAbort.Enabled = true;
                    if (G.glb.lstTask.Find(o => o.TaskName == trvTask.SelectedNode.Text).IsBottom)
                    {
                        tsmAdd.Enabled = false;
                    }
                    if (trvTask.SelectedNode.PrevNode != null)
                    {
                        if (G.glb.lstTask.Find(o => o.TaskName == trvTask.SelectedNode.PrevNode.Text).IsBottom)
                        {
                            tsmBelongTo.Enabled = false;
                        }
                    }
                    if (G.glb.lstTask.Find(o => o.TaskName == trvTask.SelectedNode.Text).IsBottom)
                    {
                        tsmFinished.Enabled = true;
                    }
                    else
                    {
                        tsmFinished.Enabled = false;
                    }
                    if (G.glb.lstTask.Find(o => o.TaskName == trvTask.SelectedNode.Text).TaskState == ETaskState.Finished)
                    {
                        tsmFinished.Text = "Mark as Unfinished";
                    }
                    else
                    {
                        tsmFinished.Text = "Mark as Finished";
                    }
                    if (G.glb.lstTask.Find(o => o.TaskName == trvTask.SelectedNode.Text).TaskState == ETaskState.Aborted)
                    {
                        tsmAbort.Text = "Reassign";
                        tsmFinished.Enabled = false;
                    }
                    else
                    {
                        tsmAbort.Text = "Mark as Aborted";
                    }
                    if (G.glb.lstSubTask.Exists(o => o.SubTask == trvTask.SelectedNode.Text))
                    {
                        string upperTask = G.glb.lstSubTask.Find(o => o.SubTask == trvTask.SelectedNode.Text).Task;
                        if (upperTask != "(Root)")
                        {
                            if (G.glb.lstTask.Find(o => o.TaskName == upperTask).TaskState == ETaskState.Aborted)
                            {
                                tsmAbort.Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            if (lsbTaskNote.SelectedItem != null)
            {
                string selectedItemText = lsbTaskNote.SelectedItem.ToString();
                string[] split = selectedItemText.Split('-');
                string[] datelist = split[0].Split('.');
                int Year = Convert.ToInt16(datelist[0]);
                int Month = Convert.ToInt16(datelist[1]);
                int Day = Convert.ToInt16(datelist[2].Substring(0, datelist[2].Length - 1));
                DateTime date = new DateTime(Year, Month, Day, 0, 0, 0);
                split[1] = split[1].Substring(1, split[1].Length - 1);
                string NoteTopic = "";
                for (int i = 1; i < split.Length; i++)
                {
                    NoteTopic += split[i];
                    NoteTopic += "-";
                }
                NoteTopic = NoteTopic.Substring(0, NoteTopic.Length - 1);
                CNote note = G.glb.lstNote.Find(o => o.TagTime == date && o.Topic == NoteTopic);
                plot D = new plot();
                D.CallInfoNote(note);
            }
        }
    }
}
