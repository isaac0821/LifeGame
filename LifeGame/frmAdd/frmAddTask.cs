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
    public partial class frmAddTask : Form
    {
        public frmAddTask(string UpperTaskName)
        {
            UpperTask = UpperTaskName;
            InitializeComponent();
        }

        private string UpperTask;
        private void frmAddTask_Load(object sender, EventArgs e)
        {

        }

        public delegate void DrawLogHandler(string TaskName);
        public event DrawLogHandler AddChildNode;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (G.glb.lstTask.Exists(o => o.TaskName == txtTask.Text))
            {
                MessageBox.Show("Task exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CTask newTask = new CTask();
                newTask.TaskName = txtTask.Text;
                newTask.DeadLine = dtpDeadLine.Value.Date;
                newTask.IsFinished = false;
                newTask.IsBottom = chkBottom.Checked;
                newTask.IsAbort = false;
                newTask.IsInfinite = chkInfinite.Checked;
                G.glb.lstTask.Add(newTask);
                RSubTask newRSubTask = new RSubTask();
                int maxIndex;
                if (G.glb.lstSubTask.Exists(o => o.Task == UpperTask))
                {
                    List<RSubTask> sameLevel = G.glb.lstSubTask.FindAll(o => o.Task == UpperTask).ToList();
                    sameLevel = sameLevel.OrderByDescending(o => o.index).ToList();
                    maxIndex = sameLevel[0].index + 1;
                }
                else
                {
                    maxIndex = 0;
                }
                newRSubTask.Task = UpperTask;
                newRSubTask.SubTask = txtTask.Text;
                newRSubTask.index = maxIndex;
                G.glb.lstSubTask.Add(newRSubTask);
                AddChildNode(txtTask.Text);
                Dispose();
            }
        }

        private void chkInfinite_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInfinite.Checked)
            {
                dtpDeadLine.Value = new DateTime(9998, 12, 31);
                dtpDeadLine.Enabled = false;
            }
            else
            {
                dtpDeadLine.Value = DateTime.Today.Date;
                dtpDeadLine.Enabled = true;
            }
        }
    }
}
