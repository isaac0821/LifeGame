using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void LoadTrvTask()
        {
            trvTask.Nodes.Clear();
            TreeNode rootNode = new TreeNode("(Root)", 0, 0);
            LoadChildTaskNode(rootNode);
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
                    int iconIndex;
                    TreeNode childNode;
                    if (G.glb.lstTask.Exists(o=>o.TaskName == subTask.SubTask))
                    {
                        iconIndex = (int)G.glb.lstTask.Find(o => o.TaskName == subTask.SubTask).TaskState;
                        childNode = new TreeNode(subTask.SubTask, iconIndex, iconIndex);
                    }
                    else
                    {
                        childNode = new TreeNode(subTask.SubTask, 0, 0);
                    }
                    LoadChildTaskNode(childNode);
                    treeNode.Nodes.Add(childNode);
                }
            }
        }

        private void LoadTask(string taskName)
        {
            txtTaskName.Enabled = false;
            chkBottom.Enabled = false;
            dtpDeadline.Enabled = false;
            chkInfinite.Enabled = false;
            dgvLog.Rows.Clear();
            if (G.glb.lstTask.Exists(o => o.TaskName == taskName))
            {
                CTask task = G.glb.lstTask.Find(o => o.TaskName == taskName);
                txtTaskName.Text = task.TaskName;
                chkBottom.Checked = task.IsBottom;
                CalAndFind C = new CalAndFind();
                lblTaskTimeSpent.Text = C.CalTimeSpentInTask(task.TaskName, G.glb.lstSubTask, G.glb.lstLog).ToString();
                DateTime? NextTimeMarker = C.FindNextTimeMarker(task.TaskName, G.glb.lstSubTask, G.glb.lstTask);
                if (NextTimeMarker != null)
                {
                    dtpNextTimeMarker.Value = C.FindNextTimeMarker(task.TaskName, G.glb.lstSubTask, G.glb.lstTask);
                }
                else
                {
                    dtpNextTimeMarker.Value = new DateTime(9999, 12, 31);
                }
                if (task.IsInfinite)
                {
                    chkInfinite.Checked = true;
                    dtpDeadline.Value = new DateTime(9999, 12, 31);
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
                txtTaskName.Text = "(No Record)";
                chkBottom.Checked = false;
                chkInfinite.Checked = false;
                lblTaskTimeSpent.Text = "----";
                dtpNextTimeMarker.Value = DateTime.Today;
                dtpDeadline.Value = DateTime.Today;
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
                        node.Nodes.Add(new TreeNode("(New Task)", 0, 0));
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
                            node.Nodes.Add(new TreeNode("(New Task)", 0, 0));
                        }
                    }
                }
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
                // 如果节点已经关联了任务，不让删
                else if (G.glb.lstTask.Exists(o=>o.TaskName == trvTask.SelectedNode.Text))
                {
                    MessageBox.Show("The task has already in act.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                // (New Task)让删
                else if (trvTask.SelectedNode.Text == "(New Task)")
                {
                    trvTask.Nodes.Remove(trvTask.SelectedNode);
                }
            }
        }

        private void tsmUp_Click(object sender, EventArgs e)
        {

        }

        private void tsmDown_Click(object sender, EventArgs e)
        {

        }

        private void tsmBelongTo_Click(object sender, EventArgs e)
        {

        }

        private void tsmIndependent_Click(object sender, EventArgs e)
        {

        }

        private void tsmFinished_Click(object sender, EventArgs e)
        {

        }

        private void tsmAbort_Click(object sender, EventArgs e)
        {

        }
    }
}
