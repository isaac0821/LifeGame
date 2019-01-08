﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace LifeGame
{
    public partial class frmMain : Form
    {
        private DateTime SelectedDate;
        private DateTime SelectedMonday;
        private DateTime SelectedTuesday;
        private DateTime SelectedWednesday;
        private DateTime SelectedThursday;
        private DateTime SelectedFriday;
        private DateTime SelectedSaturday;
        private DateTime SelectedSunday;

        private void SerializeNow()
        {
            FileStream f = new FileStream("data.dat", FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(f, G.glb);
            f.Close();
        }
        private void Deserialize()
        {
            FileStream f = new FileStream("data.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter b = new BinaryFormatter();
            G.glb.lstTask.Clear();
            G.glb = b.Deserialize(f) as Mem;
            f.Close();
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Deserialize();
            SelectedDate = DateTime.Today.Date;
            dtpDate.Value = SelectedDate;
            DrawLog();
        }
        
        private void frmMain_Resize(object sender, EventArgs e)
        {
            DrawLog();
        }

        private void frmMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Wanna save?", "Saving", MessageBoxButtons.YesNoCancel);
            switch (result)
            {
                case DialogResult.Yes:
                    SerializeNow();
                    e.Cancel = false;
                    break;
                case DialogResult.No:
                    e.Cancel = false;
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                default:
                    e.Cancel = true;
                    break;
            }
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

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            SelectedDate = dtpDate.Value.Date;
            switch (SelectedDate.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    SelectedMonday = SelectedDate.Date.AddDays(-6);
                    SelectedTuesday = SelectedDate.Date.AddDays(-5);
                    SelectedWednesday = SelectedDate.Date.AddDays(-4);
                    SelectedThursday = SelectedDate.Date.AddDays(-3);
                    SelectedFriday = SelectedDate.Date.AddDays(-2);
                    SelectedSaturday = SelectedDate.Date.AddDays(-1);
                    SelectedSunday = SelectedDate.Date.AddDays(0);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Monday:
                    SelectedMonday = SelectedDate.Date.AddDays(0);
                    SelectedTuesday = SelectedDate.Date.AddDays(1);
                    SelectedWednesday = SelectedDate.Date.AddDays(2);
                    SelectedThursday = SelectedDate.Date.AddDays(3);
                    SelectedFriday = SelectedDate.Date.AddDays(4);
                    SelectedSaturday = SelectedDate.Date.AddDays(5);
                    SelectedSunday = SelectedDate.Date.AddDays(6);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Tuesday:
                    SelectedMonday = SelectedDate.Date.AddDays(-1);
                    SelectedTuesday = SelectedDate.Date.AddDays(0);
                    SelectedWednesday = SelectedDate.Date.AddDays(1);
                    SelectedThursday = SelectedDate.Date.AddDays(2);
                    SelectedFriday = SelectedDate.Date.AddDays(3);
                    SelectedSaturday = SelectedDate.Date.AddDays(4);
                    SelectedSunday = SelectedDate.Date.AddDays(5);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Wednesday:
                    SelectedMonday = SelectedDate.Date.AddDays(-2);
                    SelectedTuesday = SelectedDate.Date.AddDays(-1);
                    SelectedWednesday = SelectedDate.Date.AddDays(0);
                    SelectedThursday = SelectedDate.Date.AddDays(1);
                    SelectedFriday = SelectedDate.Date.AddDays(2);
                    SelectedSaturday = SelectedDate.Date.AddDays(3);
                    SelectedSunday = SelectedDate.Date.AddDays(4);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Thursday:
                    SelectedMonday = SelectedDate.Date.AddDays(-3);
                    SelectedTuesday = SelectedDate.Date.AddDays(-2);
                    SelectedWednesday = SelectedDate.Date.AddDays(-1);
                    SelectedThursday = SelectedDate.Date.AddDays(0);
                    SelectedFriday = SelectedDate.Date.AddDays(1);
                    SelectedSaturday = SelectedDate.Date.AddDays(2);
                    SelectedSunday = SelectedDate.Date.AddDays(3);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Friday:
                    SelectedMonday = SelectedDate.Date.AddDays(-4);
                    SelectedTuesday = SelectedDate.Date.AddDays(-3);
                    SelectedWednesday = SelectedDate.Date.AddDays(-2);
                    SelectedThursday = SelectedDate.Date.AddDays(-1);
                    SelectedFriday = SelectedDate.Date.AddDays(0);
                    SelectedSaturday = SelectedDate.Date.AddDays(1);
                    SelectedSunday = SelectedDate.Date.AddDays(2);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Saturday:
                    SelectedMonday = SelectedDate.Date.AddDays(-5);
                    SelectedTuesday = SelectedDate.Date.AddDays(-4);
                    SelectedWednesday = SelectedDate.Date.AddDays(-3);
                    SelectedThursday = SelectedDate.Date.AddDays(-2);
                    SelectedFriday = SelectedDate.Date.AddDays(-1);
                    SelectedSaturday = SelectedDate.Date.AddDays(0);
                    SelectedSunday = SelectedDate.Date.AddDays(1);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                default:
                    break;
            }
            DrawLog();
        }
        private void btnPreDate_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(-7);
        }
        private void btnNextDate_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(7);
        }

        private void picMon_DoubleClick(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedMonday);
            frmDaily.Show();
        }
        private void picTue_DoubleClick(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedTuesday);
            frmDaily.Show();
        }
        private void picWed_DoubleClick(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedWednesday);
            frmDaily.Show();
        }
        private void picThu_DoubleClick(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedThursday);
            frmDaily.Show();
        }
        private void picFri_DoubleClick(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedFriday);
            frmDaily.Show();
        }
        private void picSat_DoubleClick(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedSaturday);
            frmDaily.Show();
        }
        private void picSun_DoubleClick(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedSunday);
            frmDaily.Show();
        }

        private void chkShowSchedule_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowLog.Checked == false)
            {
                if (chkShowSchedule.Checked == false)
                {
                    chkShowSchedule.Checked = true;
                }
            }
            DrawLog();
        }
        private void chkShowLog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowSchedule.Checked == false)
            {
                if (chkShowLog.Checked == false)
                {
                    chkShowLog.Checked = true;
                }
            }
            DrawLog();
        }

        private void tsmAddSleepSchedule_Click(object sender, EventArgs e)
        {
            frmAddSleepSchedule frmAddScheduleSleep = new frmAddSleepSchedule();
            frmAddScheduleSleep.DrawLog += new frmAddSleepSchedule.DrawLogHandler(DrawLog);
            frmAddScheduleSleep.Show();
        }

        private void tsmAddSleepLog_Click(object sender, EventArgs e)
        {
            frmAddSleepLog frmAddLogSleep = new frmAddSleepLog(SelectedDate);
            frmAddLogSleep.DrawLog += new frmAddSleepLog.DrawLogHandler(DrawLog);
            frmAddLogSleep.Show();
        }

        private void tsmAddSchedule_Click(object sender, EventArgs e)
        {
            frmAddSchedule frmAddSchedule = new frmAddSchedule();
            frmAddSchedule.DrawLog += new frmAddSchedule.DrawLogHandler(DrawLog);
            frmAddSchedule.Show();
        }

        private void tsmAddLog_Click(object sender, EventArgs e)
        {
            frmAddLog frmAddLog = new frmAddLog(SelectedDate);
            frmAddLog.DrawLog += new frmAddLog.DrawLogHandler(DrawLog);
            frmAddLog.Show();
        }

        private void picMon_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedMonday;
            dtpDate.Value = SelectedDate;
        }
        private void picTue_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedTuesday;
            dtpDate.Value = SelectedDate;
        }
        private void picWed_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedWednesday;
            dtpDate.Value = SelectedDate;
        }
        private void picThu_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedThursday;
            dtpDate.Value = SelectedDate;
        }
        private void picFri_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedFriday;
            dtpDate.Value = SelectedDate;
        }
        private void picSat_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedSaturday;
            dtpDate.Value = SelectedDate;
        }
        private void picSun_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedSunday;
            dtpDate.Value = SelectedDate;
        }

        private void LoadLsbDaily(ListBox listBox, DateTime date)
        {
            listBox.Items.Clear();
            List<CTask> taskDeadline = G.glb.lstTask.FindAll(o => o.DeadLine.Date == date.Date).ToList();
            foreach (CTask task in taskDeadline)
            {
                listBox.Items.Add("Deadline:" + task.TaskName);
            }
        }

        private void DrawLog()
        {
            Draw Draw = new Draw();
            LoadLsbDaily(lsbMon, SelectedMonday);
            LoadLsbDaily(lsbTue, SelectedTuesday);
            LoadLsbDaily(lsbWed, SelectedWednesday);
            LoadLsbDaily(lsbThu, SelectedThursday);
            LoadLsbDaily(lsbFri, SelectedFriday);
            LoadLsbDaily(lsbSat, SelectedSaturday);
            LoadLsbDaily(lsbSun, SelectedSunday);

            if (chkShowSchedule.Checked && chkShowLog.Checked)
            {
                Draw.DrawScheduleAndLog(picMon, SelectedMonday, G.glb.lstSchedule, G.glb.lstSleepSchedule, true, "left");
                Draw.DrawScheduleAndLog(picTue, SelectedTuesday, G.glb.lstSchedule, G.glb.lstSleepSchedule, true, "left");
                Draw.DrawScheduleAndLog(picWed, SelectedWednesday, G.glb.lstSchedule, G.glb.lstSleepSchedule, true, "left");
                Draw.DrawScheduleAndLog(picThu, SelectedThursday, G.glb.lstSchedule, G.glb.lstSleepSchedule, true, "left");
                Draw.DrawScheduleAndLog(picFri, SelectedFriday, G.glb.lstSchedule, G.glb.lstSleepSchedule, true, "left");
                Draw.DrawScheduleAndLog(picSat, SelectedSaturday, G.glb.lstSchedule, G.glb.lstSleepSchedule, true, "left");
                Draw.DrawScheduleAndLog(picSun, SelectedSunday, G.glb.lstSchedule, G.glb.lstSleepSchedule, true, "left");
                Draw.DrawScheduleAndLog(picMon, SelectedMonday, G.glb.lstLog, G.glb.lstSleepLog, true, "right");
                Draw.DrawScheduleAndLog(picTue, SelectedTuesday, G.glb.lstLog, G.glb.lstSleepLog, true, "right");
                Draw.DrawScheduleAndLog(picWed, SelectedWednesday, G.glb.lstLog, G.glb.lstSleepLog, true, "right");
                Draw.DrawScheduleAndLog(picThu, SelectedThursday, G.glb.lstLog, G.glb.lstSleepLog, true, "right");
                Draw.DrawScheduleAndLog(picFri, SelectedFriday, G.glb.lstLog, G.glb.lstSleepLog, true, "right");
                Draw.DrawScheduleAndLog(picSat, SelectedSaturday, G.glb.lstLog, G.glb.lstSleepLog, true, "right");
                Draw.DrawScheduleAndLog(picSun, SelectedSunday, G.glb.lstLog, G.glb.lstSleepLog, true, "right");
            }
            else if (chkShowSchedule.Checked && !chkShowLog.Checked)
            {
                Draw.DrawScheduleAndLog(picMon, SelectedMonday, G.glb.lstSchedule, G.glb.lstSleepSchedule, true, "all");
                Draw.DrawScheduleAndLog(picTue, SelectedTuesday, G.glb.lstSchedule, G.glb.lstSleepSchedule, true, "all");
                Draw.DrawScheduleAndLog(picWed, SelectedWednesday, G.glb.lstSchedule, G.glb.lstSleepSchedule, true, "all");
                Draw.DrawScheduleAndLog(picThu, SelectedThursday, G.glb.lstSchedule, G.glb.lstSleepSchedule, true, "all");
                Draw.DrawScheduleAndLog(picFri, SelectedFriday, G.glb.lstSchedule, G.glb.lstSleepSchedule, true, "all");
                Draw.DrawScheduleAndLog(picSat, SelectedSaturday, G.glb.lstSchedule, G.glb.lstSleepSchedule, true, "all");
                Draw.DrawScheduleAndLog(picSun, SelectedSunday, G.glb.lstSchedule, G.glb.lstSleepSchedule, true, "all");
            }
            else if (!chkShowSchedule.Checked && chkShowLog.Checked)
            {
                Draw.DrawScheduleAndLog(picMon, SelectedMonday, G.glb.lstLog, G.glb.lstSleepLog, true, "all");
                Draw.DrawScheduleAndLog(picTue, SelectedTuesday, G.glb.lstLog, G.glb.lstSleepLog, true, "all");
                Draw.DrawScheduleAndLog(picWed, SelectedWednesday, G.glb.lstLog, G.glb.lstSleepLog, true, "all");
                Draw.DrawScheduleAndLog(picThu, SelectedThursday, G.glb.lstLog, G.glb.lstSleepLog, true, "all");
                Draw.DrawScheduleAndLog(picFri, SelectedFriday, G.glb.lstLog, G.glb.lstSleepLog, true, "all");
                Draw.DrawScheduleAndLog(picSat, SelectedSaturday, G.glb.lstLog, G.glb.lstSleepLog, true, "all");
                Draw.DrawScheduleAndLog(picSun, SelectedSunday, G.glb.lstLog, G.glb.lstSleepLog, true, "all");
            }         
        }


    }
}
