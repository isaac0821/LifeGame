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
                chkFinished.Checked = task.IsFinished;
                CalAndFind C = new CalAndFind();
                lblTaskTimeSpent.Text = C.CalTimeSpentInTask(task.TaskName, G.glb.lstSubTask, G.glb.lstLog).ToString();
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
                            log.StartTime.Year.ToString(),
                            log.StartTime.Month.ToString(),
                            log.StartTime.Day.ToString(),
                            bottomTask,
                            log.LogName,
                            span.TotalHours
                            );
                    }
                }
            }
            else
            {
                lblTaskTitle.Text = "(No Record)";
                chkBottom.Checked = false;
                chkFinished.Checked = false;
                chkInfinite.Checked = false;
                lblTaskTimeSpent.Text = "----";
                dtpNextTimeMarker.Value = DateTime.Today;
                dtpDeadline.Value = DateTime.Today;
            }
        }

        private void RefreshIcon(TreeNode node)
        {
            int iconIndex;
            if (G.glb.lstTask.Exists(o => o.TaskName == node.Text))
            {
                if (G.glb.lstTask.Find(o => o.TaskName == node.Text).IsAbort)
                {
                    iconIndex = 3;
                }
                else if (G.glb.lstTask.Find(o => o.TaskName == node.Text).IsFinished)
                {
                    iconIndex = 2;
                }
                else
                {
                    iconIndex = 1;
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
                CalAndFind C = new CalAndFind();
                C.RefreshFinishTask(trvTask.SelectedNode.Text, G.glb.lstSubTask, G.glb.lstTask);
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
                    CalAndFind C = new CalAndFind();
                    bool CanDeleteFlag = C.DeleteTask(trvTask.SelectedNode.Text, G.glb.lstSubTask, G.glb.lstTask, G.glb.lstLog, G.glb.lstSchedule);
                    if (CanDeleteFlag)
                    {
                        trvTask.Nodes.Remove(trvTask.SelectedNode);
                        C.RefreshFinishTask(UpperTask, G.glb.lstSubTask, G.glb.lstTask);
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
                    CalAndFind C = new CalAndFind();
                    C.RefreshFinishTask(preNodeName, G.glb.lstSubTask, G.glb.lstTask);
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
                    CalAndFind C = new CalAndFind();
                    C.RefreshFinishTask(parentNodeName, G.glb.lstSubTask, G.glb.lstTask);
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
                    if (!G.glb.lstTask.Find(o => o.TaskName == trvTask.SelectedNode.Text).IsFinished)
                    {
                        CalAndFind C = new CalAndFind();
                        C.FinishTask(trvTask.SelectedNode.Text, G.glb.lstSubTask, G.glb.lstTask);
                        RefreshIcon(trvTask.Nodes[0]);
                    }
                    else
                    {
                        CalAndFind C = new CalAndFind();
                        C.UnfinishTask(trvTask.SelectedNode.Text, G.glb.lstSubTask, G.glb.lstTask);
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
                    if (!G.glb.lstTask.Find(o => o.TaskName == trvTask.SelectedNode.Text).IsAbort)
                    {
                        CalAndFind C = new CalAndFind();
                        C.AbortTask(trvTask.SelectedNode.Text, G.glb.lstSubTask, G.glb.lstTask);
                        RefreshIcon(trvTask.Nodes[0]);
                    }
                    else
                    {
                        CalAndFind C = new CalAndFind();
                        C.ReAssignTask(trvTask.SelectedNode.Text, G.glb.lstSubTask, G.glb.lstTask);
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
                    if (G.glb.lstTask.Find(o => o.TaskName == trvTask.SelectedNode.Text).IsAbort)
                    {
                        if (trvTask.SelectedNode.Parent != null)
                        {
                            if (trvTask.SelectedNode.Parent.Text != "(Root)")
                            {
                                if (G.glb.lstTask.Find(o => o.TaskName == trvTask.SelectedNode.Parent.Text).IsAbort)
                                {
                                    tsmAbort.Enabled = false;
                                }
                            }
                        }
                        tsmAbort.Text = "Reassign";
                        tsmFinished.Enabled = false;
                    }
                    else
                    {
                        tsmAbort.Text = "Mark as Aborted";
                    }
                    if (G.glb.lstSubTask.Exists(o=>o.Task==trvTask.SelectedNode.Text))
                    {
                        tsmFinished.Enabled = false;
                    }
                    if (G.glb.lstTask.Find(o => o.TaskName == trvTask.SelectedNode.Text).IsFinished)
                    {
                        tsmFinished.Text = "Mark as Unfinished";
                    }
                    else
                    {
                        tsmFinished.Text = "Mark as Finished";
                    }

                }
            }
        }
    }
}
