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
    public partial class frmDaily : Form
    {
        private DateTime curDate;
        public frmDaily(DateTime date)
        {
            curDate = date;
            InitializeComponent();
        }

        private void frmDaily_Load(object sender, EventArgs e)
        {
            dtpToday.Value = curDate;
            LoadDaily();
        }

        private void frmDaily_Resize(object sender, EventArgs e)
        {
            Draw Draw = new Draw();
            Draw.DrawScheduleAndLog(picSchedule, curDate, G.glb.lstSchedule, G.glb.lstSleepSchedule, false, "all");
            Draw.DrawScheduleAndLog(picLog, curDate, G.glb.lstLog, G.glb.lstSleepLog, false, "all");
        }

        private void LoadDaily()
        {
            Draw Draw = new Draw();
            Draw.DrawScheduleAndLog(picSchedule, curDate, G.glb.lstSchedule, G.glb.lstSleepSchedule, false, "all");
            Draw.DrawScheduleAndLog(picLog, curDate, G.glb.lstLog, G.glb.lstSleepLog, false, "all");

            LoadSchedule(curDate, G.glb.lstSchedule);
            LoadLog(curDate, G.glb.lstLog);
            LoadSleep(curDate, G.glb.lstSleepSchedule, G.glb.lstSleepLog);
            LoadFinancial(curDate, G.glb.lstMoneyDetail);
            LoadWorkOut(curDate, G.glb.lstWorkOutSchedule, G.glb.lstWorkOutLog);
            LoadMedicine(curDate, G.glb.lstMedicine);
        }

        private void LoadSchedule(DateTime date, List<CLog> schedules)
        {
            List<CLog> todaySchedules = schedules.FindAll(o => o.StartTime.Date == date).ToList();
            List<CLog> yesterdaySchedules = schedules.FindAll(o => o.StartTime.Date == date.AddDays(-1) && o.EndTime.Date == date).ToList();
            dgvSchedule.Rows.Clear();
            foreach (CLog schedule in todaySchedules)
            {
                if (schedule.EndTime.Date == date.AddDays(1))
                {
                    dgvSchedule.Rows.Add(
                        schedule.LogName,
                        schedule.Location,
                        schedule.WithWho,
                        false,
                        schedule.StartTime.ToShortTimeString(),
                        schedule.EndTime.ToShortTimeString(),
                        true,
                        schedule.ContributionToTask);
                }
                else
                {
                    dgvSchedule.Rows.Add(
                        schedule.LogName, 
                        schedule.Location, 
                        schedule.WithWho, 
                        false,
                        schedule.StartTime.ToShortTimeString(),
                        schedule.EndTime.ToShortTimeString(), 
                        false, 
                        schedule.ContributionToTask);
                }
            }
            foreach (CLog schedule in yesterdaySchedules)
            {
                dgvSchedule.Rows.Add(
                    schedule.LogName,
                    schedule.Location,
                    schedule.WithWho,
                    true,
                    schedule.StartTime.ToShortTimeString(),
                    schedule.EndTime.ToShortTimeString(),
                    false,
                    schedule.ContributionToTask);
            }
        }

        private void LoadLog(DateTime date, List<CLog> logs)
        {
            List<CLog> todayLogs = logs.FindAll(o => o.StartTime.Date == date).ToList();
            List<CLog> yesterdayLogs = logs.FindAll(o => o.StartTime.Date == date.AddDays(-1) && o.EndTime.Date == date).ToList();
            dgvLog.Rows.Clear();
            foreach (CLog log in todayLogs)
            {
                if (log.EndTime.Date == date.AddDays(1))
                {
                    dgvLog.Rows.Add(
                        log.LogName,
                        log.Location,
                        log.WithWho,
                        false,
                        log.StartTime.ToShortTimeString(),
                        log.EndTime.ToShortTimeString(),
                        true,
                        log.ContributionToTask);
                }
                else
                {
                    dgvLog.Rows.Add(
                        log.LogName,
                        log.Location,
                        log.WithWho,
                        false,
                        log.StartTime.ToShortTimeString(),
                        log.EndTime.ToShortTimeString(),
                        false,
                        log.ContributionToTask);
                }
            }
            foreach (CLog log in yesterdayLogs)
            {
                dgvLog.Rows.Add(
                    log.LogName,
                    log.Location,
                    log.WithWho,
                    true,
                    log.StartTime.ToShortTimeString(),
                    log.EndTime.ToShortTimeString(),
                    false,
                    log.ContributionToTask);
            }
        }

        private void LoadSleep(DateTime date, List<CSleep> scheduleSleeps, List<CSleep> sleeps)
        {
            CSleep schedule = scheduleSleeps.Find(o => o.Date == date);
            CSleep log = sleeps.Find(o => o.Date == date);
            chkScheduleSleepMinusOneDay.Checked = false;
            lblScheduleSleepGoToBedTime.Text = "---";
            lblScheduleSleepGetUpTime.Text = "---";
            lblScheduleSleepTime.Text = "---";
            chkLogSleepMinusOneDay.Checked = false;
            lblLogSleepGoToBedTime.Text = "---";
            lblLogSleepGetUpTime.Text = "---";
            lblLogSleepTime.Text = "---";
            if (schedule != null)
            {
                chkScheduleSleepMinusOneDay.Checked = schedule.IsGoToBedBeforeMidNight;
                lblScheduleSleepGoToBedTime.Text = schedule.GoToBedTime.ToShortTimeString();
                lblScheduleSleepGetUpTime.Text = schedule.GetUpTime.ToShortTimeString();
                TimeSpan scheduleSleepTime = schedule.GetUpTime - schedule.GoToBedTime;
                lblScheduleSleepTime.Text = scheduleSleepTime.TotalHours.ToString()+"h";
            }
            if (log != null)
            {
                chkLogSleepMinusOneDay.Checked = log.IsGoToBedBeforeMidNight;
                lblLogSleepGoToBedTime.Text = log.GoToBedTime.ToShortTimeString();
                lblLogSleepGetUpTime.Text = log.GetUpTime.ToShortTimeString();
                TimeSpan logSleepTime = log.GetUpTime - log.GoToBedTime;
                lblLogSleepTime.Text = logSleepTime.TotalHours.ToString()+"h";
            }
        }

        private void LoadFinancial(DateTime date, List<CMoneyDetail> moneyDetails)
        {

        }

        private void LoadWorkOut(DateTime date, List<CWorkOut> workOutSchedules, List<CWorkOut> workOuts)
        {

        }

        private void LoadMedicine(DateTime date, List<CMedicine> medicines)
        {

        }

        private void tsmAddLog_Click(object sender, EventArgs e)
        {
            frmAddLog frmAddLog = new frmAddLog(curDate);
            frmAddLog.DrawLog += new frmAddLog.DrawLogHandler(LoadDaily);
            frmAddLog.Show();
        }

        private void tsmDeleteLog_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.Rows.Count > 0)
            {
                string logName = dgvLog.CurrentRow.Cells[0].Value.ToString();
                G.glb.lstLog.RemoveAll(o => o.LogName == logName && o.StartTime.Date == curDate);
                LoadDaily();
            }
        }

        private void tsmAddScheduleSleep_Click(object sender, EventArgs e)
        {
            frmAddSleepSchedule frmAddScheduleSleep = new frmAddSleepSchedule();
            frmAddScheduleSleep.DrawLog += new frmAddSleepSchedule.DrawLogHandler(LoadDaily);
            frmAddScheduleSleep.Show();
        }

        private void addLogSleep_Click(object sender, EventArgs e)
        {
            frmAddSleepLog frmAddLogSleep = new frmAddSleepLog(curDate);
            frmAddLogSleep.DrawLog += new frmAddSleepLog.DrawLogHandler(LoadDaily);
            frmAddLogSleep.Show();
        }

        private void tsmConvertToLog_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.Rows.Count > 0)
            {
                string scheduleName = dgvSchedule.CurrentRow.Cells[0].Value.ToString();
                CLog choosenSchedule = G.glb.lstSchedule.Find(o => o.LogName == scheduleName && o.StartTime.Date == curDate);
                G.glb.lstLog.Add(choosenSchedule);
                LoadDaily();
            }
        }

        private void tsmAddSchedule_Click(object sender, EventArgs e)
        {
            frmAddSchedule frmAddSchedule = new frmAddSchedule();
            frmAddSchedule.DrawLog += new frmAddSchedule.DrawLogHandler(LoadDaily);
            frmAddSchedule.Show();
        }

        private void tsmDeleteSchedule_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.Rows.Count>0)
            {
                string scheduleName = dgvSchedule.CurrentRow.Cells[0].Value.ToString();
                G.glb.lstSchedule.RemoveAll(o => o.LogName == scheduleName && o.StartTime.Date == curDate);
                LoadDaily();
            }
        }
    }
}
