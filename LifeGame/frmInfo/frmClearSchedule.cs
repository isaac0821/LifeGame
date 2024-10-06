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
    public partial class frmClearSchedule : Form
    {
        public frmClearSchedule()
        {
            InitializeComponent();
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void btnClear_Click(object sender, EventArgs e)
        {
            bool CanClearFlag = true;
            if (chkPlusOneDay.Checked != true)
            {
                if (dtpTimeEnd.Value < dtpTimeStart.Value)
                {
                    MessageBox.Show("End time can not earlier than start time");
                    CanClearFlag = false;
                }
            }

            if (CanClearFlag)
            {
                DateTime startDate = dtpPeriodStart.Value.Date;
                DateTime endDate = dtpPeriodEnd.Value.Date;
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
                            if (chkTh.Checked)
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
                        bool CanClearScheduleAtThatDay = true;
                        DateTime StartTime = new DateTime(day.Year, day.Month, day.Day, dtpTimeStart.Value.Hour, dtpTimeStart.Value.Minute, dtpTimeStart.Value.Second);
                        DateTime EndTime;
                        if (chkPlusOneDay.Checked != true)
                        {
                            EndTime = new DateTime(day.Year, day.Month, day.Day, dtpTimeEnd.Value.Hour, dtpTimeEnd.Value.Minute, dtpTimeEnd.Value.Second);
                        }
                        else
                        {
                            EndTime = new DateTime(day.AddDays(1).Year, day.AddDays(1).Month, day.AddDays(1).Day, dtpTimeEnd.Value.Hour, dtpTimeEnd.Value.Minute, dtpTimeEnd.Value.Second);
                        }
                        if (CanClearScheduleAtThatDay && G.glb.lstSchedule.Exists(o => (o.StartTime <= StartTime && o.EndTime >= StartTime) || (o.StartTime >= StartTime && o.StartTime <= EndTime)))
                        {
                            DialogResult result = MessageBox.Show("Do you confirm to clear from " + StartTime.ToShortDateString() + " " + StartTime.ToShortTimeString() + " to " + EndTime.ToShortDateString() + " " + EndTime.ToShortTimeString() + "?", "Clear Schedule", MessageBoxButtons.YesNoCancel);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    CanClearScheduleAtThatDay = true;
                                    break;
                                case DialogResult.No:
                                    CanClearScheduleAtThatDay = false;
                                    break;
                                default:
                                    break;
                            }
                        }

                        if (CanClearScheduleAtThatDay)
                        {
                            G.glb.lstSchedule.RemoveAll(o => (o.StartTime <= StartTime && o.EndTime >= StartTime) || (o.StartTime >= StartTime && o.StartTime <= EndTime));
                        }
                    }
                }
                DrawLog();
                Dispose();
            }
        }
    }
}
