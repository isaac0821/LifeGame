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
            TreeNode rootNode = new TreeNode("(Root)");
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
                    TreeNode childNode = new TreeNode(subTask.SubTask);
                    LoadChildTaskNode(childNode);
                    treeNode.Nodes.Add(childNode);
                }
            }
        }

        private void LoadSelectedTaskNode(string taskName)
        {
            if (G.glb.lstTask.Exists(o => o.TaskName == taskName))
            {
                CTask task = G.glb.lstTask.Find(o => o.TaskName == taskName);
                txtTaskName.Text = task.TaskName;

            }
            else
            {

            }
        }
    }
}
