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
    public partial class frmAddLog : Form
    {
        private DateTime curDate;
        public frmAddLog(DateTime selectDate)
        {
            curDate = selectDate;
            InitializeComponent();
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CLog newLog = new CLog();
            newLog.LogName = txtLog.Text;
            newLog.StartTime = new DateTime(curDate.Year, curDate.Month, curDate.Day, dtpTimeStart.Value.Hour, dtpTimeStart.Value.Minute, dtpTimeStart.Value.Second);
            if (chkPlusOneDay.Checked != true)
            {
                newLog.EndTime = new DateTime(curDate.Year, curDate.Month, curDate.Day, dtpTimeEnd.Value.Hour, dtpTimeEnd.Value.Minute, dtpTimeEnd.Value.Second);
            }
            else
            {
                newLog.EndTime = new DateTime(curDate.AddDays(1).Year, curDate.AddDays(1).Month, curDate.AddDays(1).Day, dtpTimeEnd.Value.Hour, dtpTimeEnd.Value.Minute, dtpTimeEnd.Value.Second);
            }
            newLog.Location = txtWhere.Text;
            newLog.WithWho = txtWith.Text;
            newLog.ContributionToTask = cbxTask.Text;
            newLog.Color = cbxColor.Text;
            G.glb.lstLog.Add(newLog);
            DrawLog();
            Dispose();
        }

        private void frmAddLog_Load(object sender, EventArgs e)
        {
            dtpDate.Value = curDate;
            List<CTask> taskChoices = G.glb.lstTask.FindAll(o => o.IsBottom && !o.IsFinished && !o.IsAbort).ToList();
            List<string> choices = new List<string>();
            foreach (CTask task in taskChoices)
            {
                choices.Add(task.TaskName);
            }
            cbxTask.DataSource = choices;
            cbxColor.SelectedIndex = 0;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            curDate = dtpDate.Value.Date;
        }
    }
}
