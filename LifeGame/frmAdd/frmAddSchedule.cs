﻿using System;
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
                        bool CanAddScheduleAtThatDay = true;
                        bool ReplaceExistFlag = false;
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

                        if (CanAddScheduleAtThatDay && G.glb.lstSchedule.Exists(o => (o.StartTime <= StartTime && o.EndTime >= StartTime) || (o.StartTime >= StartTime && o.StartTime <= EndTime)))
                        {
                            DialogResult result = MessageBox.Show("Already have logs at that time, Do you replace?", "Log", MessageBoxButtons.YesNo);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    ReplaceExistFlag = true;
                                    break;
                                case DialogResult.No:
                                    CanAddScheduleAtThatDay = false;
                                    break;
                                default:
                                    break;
                            }
                        }

                        if (ReplaceExistFlag)
                        {
                            G.glb.lstSchedule.RemoveAll(o => (o.StartTime <= StartTime && o.EndTime >= StartTime) || (o.StartTime >= StartTime && o.StartTime <= EndTime));
                        }

                        if (CanAddScheduleAtThatDay)
                        {
                            CLog newSchedule = new CLog();
                            newSchedule.LogName = txtSchedule.Text;
                            newSchedule.StartTime = StartTime;
                            newSchedule.EndTime = EndTime;
                            newSchedule.Location = txtWhere.Text;
                            newSchedule.WithWho = txtWith.Text;
                            newSchedule.Color = cbxColor.Text;
                            newSchedule.Alarm = chkAlarm.Checked;
                            newSchedule.AlarmTime = StartTime - new TimeSpan(0, Convert.ToInt16(txtMinsAhead.Text), 0);
                            G.glb.lstSchedule.Add(newSchedule);
                        }
                    }
                }
                DrawLog();
                Dispose();
            }
        }

        private void frmAddSchedule_Load(object sender, EventArgs e)
        {

            cbxColor.SelectedIndex = 0;
        }

        private void chkAlarm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlarm.Checked)
            {
                txtMinsAhead.Enabled = true;
            }
            else
            {
                txtMinsAhead.Enabled = false;
            }
        }
    }
}
