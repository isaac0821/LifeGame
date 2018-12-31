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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void taskTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTask frmTask = new frmTask();
            frmTask.Show();
        }

        private void moneyMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccount frmAccount = new frmAccount();
            frmAccount.Show();
        }

        private void addScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddSchedule frmAddSchedule = new frmAddSchedule();
            frmAddSchedule.Show();
        }

        private void addLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddLog frmAddLog = new frmAddLog();
            frmAddLog.Show();
        }
    }
}
