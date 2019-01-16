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
    public partial class frmAddSleepSchedule : Form
    {
        public frmAddSleepSchedule()
        {
            InitializeComponent();
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpPeriodStart.Value.Date.Date;
            DateTime endDate = dtpPeriodEnd.Value.Date.Date;
            for (DateTime day = startDate; day <= endDate; day = day.AddDays(1))
            {
                bool IsAddSchedule = false;
                switch (day.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        if (chkSu.Checked)
                        {
                            IsAddSchedule = true;
                        }
                        break;
                    case DayOfWeek.Monday:
                        if (chkMo.Checked)
                        {
                            IsAddSchedule = true;
                        }
                        break;
                    case DayOfWeek.Tuesday:
                        if (chkTu.Checked)
                        {
                            IsAddSchedule = true;
                        }
                        break;
                    case DayOfWeek.Wednesday:
                        if (chkWe.Checked)
                        {
                            IsAddSchedule = true;
                        }
                        break;
                    case DayOfWeek.Thursday:
                        if (chkTu.Checked)
                        {
                            IsAddSchedule = true;
                        }
                        break;
                    case DayOfWeek.Friday:
                        if (chkFr.Checked)
                        {
                            IsAddSchedule = true;
                        }
                        break;
                    case DayOfWeek.Saturday:
                        if (chkSa.Checked)
                        {
                            IsAddSchedule = true;
                        }
                        break;
                    default:
                        break;
                }
                if (IsAddSchedule)
                {
                    CSleep newSleep = new CSleep();
                    newSleep.Date = day.Date;
                    newSleep.IsGoToBedBeforeMidNight = chkMinusOneDay.Checked;
                    if (chkMinusOneDay.Checked)
                    {
                        newSleep.GoToBedTime = new DateTime(day.AddDays(-1).Year, day.AddDays(-1).Month, day.AddDays(-1).Day, dtpTimeStart.Value.Hour, dtpTimeStart.Value.Minute, dtpTimeStart.Value.Second);
                    }
                    else
                    {
                        newSleep.GoToBedTime = new DateTime(day.Year, day.Month, day.Day, dtpTimeStart.Value.Hour, dtpTimeStart.Value.Minute, dtpTimeStart.Value.Second);
                    }
                    newSleep.GetUpTime = new DateTime(day.Year, day.Month, day.Day, dtpTimeEnd.Value.Hour, dtpTimeEnd.Value.Minute, dtpTimeEnd.Value.Second);
                    if (G.glb.lstSleepSchedule.Exists(o => o.Date == day))
                    {
                        G.glb.lstSleepSchedule.RemoveAll(o => o.Date == day);
                        G.glb.lstSleepSchedule.Add(newSleep);
                    }
                    else
                    {
                        G.glb.lstSleepSchedule.Add(newSleep);
                    }
                }
            }
            DrawLog();
            Dispose();
        }
    }
}
