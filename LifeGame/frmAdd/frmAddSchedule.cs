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
            bool CanAddFlag = true;
            if (chkPlusOneDay.Checked != true)
            {
                if (dtpTimeEnd.Value < dtpTimeStart.Value)
                {
                    MessageBox.Show("End time can not earlier than start time");
                    CanAddFlag = false;
                }
            }

            if (CanAddFlag)
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
                        newSchedule.Color = cbxColor.Text;
                        G.glb.lstSchedule.Add(newSchedule);
                    }
                }
                DrawLog();
                Dispose();
            }
        }

        private void frmAddSchedule_Load(object sender, EventArgs e)
        {
            List<CTask> taskChoices = G.glb.lstTask.FindAll(o => o.IsBottom && !o.IsFinished && !o.IsAbort).ToList();
            List<string> choices = new List<string>();
            choices.Add("");
            foreach (CTask task in taskChoices)
            {
                choices.Add(task.TaskName);
            }
            cbxTask.DataSource = choices;
            cbxColor.SelectedIndex = 0;
        }
    }
}
