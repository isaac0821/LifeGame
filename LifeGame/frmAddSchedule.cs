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
    public partial class frmAddSchedule : Form
    {
        public frmAddSchedule()
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
                    CLog newSchedule = new CLog();
                    newSchedule.LogName = txtSchedule.Text;
                    newSchedule.StartTime = new DateTime(day.Year, day.Month, day.Day, dtpTimeStart.Value.Hour, dtpTimeStart.Value.Minute, dtpTimeStart.Value.Second);
                    if (chkPlusOneDay.Checked != true)
                    {
                        newSchedule.EndTime = new DateTime(day.Year, day.Month, day.Day, dtpTimeEnd.Value.Hour, dtpTimeEnd.Value.Minute, dtpTimeEnd.Value.Second);
                    }
                    else
                    {
                        newSchedule.EndTime = new DateTime(day.AddDays(1).Year, day.AddDays(1).Month, day.AddDays(1).Day, dtpTimeEnd.Value.Hour, dtpTimeEnd.Value.Minute, dtpTimeEnd.Value.Second);
                    }
                    newSchedule.Location = txtWhere.Text;
                    newSchedule.WithWho = txtWith.Text;
                    newSchedule.ContributionToTask = cbxTask.Text;
                    newSchedule.ProgressPercentageToTask = txtPercent.Text == "" ? 0 : Convert.ToInt16(txtPercent.Text);
                    newSchedule.Color = cbxColor.Text;
                    G.glb.lstSchedule.Add(newSchedule);
                }
            }
            DrawLog();
            Close();
        }
    }
}
