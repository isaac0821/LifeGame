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
            DateTime StartTime = new DateTime(curDate.Year, curDate.Month, curDate.Day, dtpTimeStart.Value.Hour, dtpTimeStart.Value.Minute, dtpTimeStart.Value.Second);
            DateTime EndTime;
            if (chkPlusOneDay.Checked != true)
            {
                EndTime = new DateTime(curDate.Year, curDate.Month, curDate.Day, dtpTimeEnd.Value.Hour, dtpTimeEnd.Value.Minute, dtpTimeEnd.Value.Second);
            }
            else
            {
                EndTime = new DateTime(curDate.AddDays(1).Year, curDate.AddDays(1).Month, curDate.AddDays(1).Day, dtpTimeEnd.Value.Hour, dtpTimeEnd.Value.Minute, dtpTimeEnd.Value.Second);
            }

            bool CanAddFlag = true;
            bool ReplaceExistFlag = false;
            if (EndTime < StartTime)
            {
                MessageBox.Show("End time can not earlier than start time");
                CanAddFlag = false;
            }
            if (G.glb.lstSleepLog.Exists(o => (o.GoToBedTime <= StartTime && o.GetUpTime >= StartTime) || (o.GoToBedTime >= StartTime && o.GoToBedTime <= EndTime)))
            {
                MessageBox.Show("Overlapped with sleep time, please check");
                CanAddFlag = false;
            }
            if (CanAddFlag && G.glb.lstLog.Exists(o => (o.StartTime <= StartTime && o.EndTime >= StartTime) || (o.StartTime >= StartTime && o.StartTime <= EndTime)))
            {
                DialogResult result = MessageBox.Show("Already has a log at that time, Do you replace it?", "Log", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        ReplaceExistFlag = true;
                        break;
                    case DialogResult.No:
                        CanAddFlag = false;
                        break;
                    default:
                        break;
                }
            }
            if (ReplaceExistFlag)
            {
                G.glb.lstLog.RemoveAll(o => (o.StartTime <= StartTime && o.EndTime >= StartTime) || (o.StartTime >= StartTime && o.StartTime <= EndTime));
            }

            if (CanAddFlag)
            {
                CLog newLog = new CLog();
                newLog.LogName = txtLog.Text;
                newLog.StartTime = StartTime;
                newLog.EndTime = EndTime;
                newLog.Location = txtWhere.Text;
                newLog.WithWho = txtWith.Text;
                newLog.ContributionToTask = cbxTask.Text;
                newLog.Color = cbxColor.Text;
                G.glb.lstLog.Add(newLog);
                DrawLog();
                Dispose();
            }
        }

        private void frmAddLog_Load(object sender, EventArgs e)
        {
            dtpDate.Value = curDate;
            List<CTask> taskChoices = G.glb.lstTask.FindAll(o => o.IsBottom && o.TaskState != ETaskState.Finished && o.TaskState != ETaskState.Aborted).ToList();
            List<string> choices = new List<string>();
            choices.Add("");
            foreach (CTask task in taskChoices)
            {
                choices.Add(task.TaskName);
            }
            choices = choices.OrderBy(o => o).ToList();
            cbxTask.DataSource = choices;
            cbxColor.SelectedIndex = 0;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            curDate = dtpDate.Value.Date;
        }
    }
}
