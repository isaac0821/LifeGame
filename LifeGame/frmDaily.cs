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
        }

        private void LoadDaily(DateTime date)
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
        }

        private void LoadSleep(DateTime data, List<CSleep> scheduleSleeps, List<CSleep> sleeps)
        {

        }

        private void LoadFinancial(DateTime data, List<CMoneyDetail> moneyDetails)
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

        }

        private void tsmDeleteLog_Click(object sender, EventArgs e)
        {

        }
    }
}
