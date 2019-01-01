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
    public partial class frmMain : Form
    {
        private DateTime SelectedDay;
        private DateTime SelectedMonday;
        private DateTime SelectedTuesday;
        private DateTime SelectedWednesday;
        private DateTime SelectedThursday;
        private DateTime SelectedFriday;
        private DateTime SelectedSaturday;
        private DateTime SelectedSunday;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SelectedDay = DateTime.Today.Date;
            dtpDate.Value = SelectedDay;
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

        private void addScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddSchedule frmAddSchedule = new frmAddSchedule();
            frmAddSchedule.Show();
        }

        private void addLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddLog frmAddLog = new frmAddLog(SelectedDay);
            frmAddLog.Show();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            SelectedDay = dtpDate.Value.Date;
            switch (SelectedDay.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    SelectedMonday = SelectedDay.Date.AddDays(-6);
                    SelectedTuesday = SelectedDay.Date.AddDays(-5);
                    SelectedWednesday = SelectedDay.Date.AddDays(-4);
                    SelectedThursday = SelectedDay.Date.AddDays(-3);
                    SelectedFriday = SelectedDay.Date.AddDays(-2);
                    SelectedSaturday = SelectedDay.Date.AddDays(-1);
                    SelectedSunday = SelectedDay.Date.AddDays(0);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Monday:
                    SelectedMonday = SelectedDay.Date.AddDays(0);
                    SelectedTuesday = SelectedDay.Date.AddDays(1);
                    SelectedWednesday = SelectedDay.Date.AddDays(2);
                    SelectedThursday = SelectedDay.Date.AddDays(3);
                    SelectedFriday = SelectedDay.Date.AddDays(4);
                    SelectedSaturday = SelectedDay.Date.AddDays(5);
                    SelectedSunday = SelectedDay.Date.AddDays(6);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Tuesday:
                    SelectedMonday = SelectedDay.Date.AddDays(-1);
                    SelectedTuesday = SelectedDay.Date.AddDays(0);
                    SelectedWednesday = SelectedDay.Date.AddDays(1);
                    SelectedThursday = SelectedDay.Date.AddDays(2);
                    SelectedFriday = SelectedDay.Date.AddDays(3);
                    SelectedSaturday = SelectedDay.Date.AddDays(4);
                    SelectedSunday = SelectedDay.Date.AddDays(5);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Wednesday:
                    SelectedMonday = SelectedDay.Date.AddDays(-2);
                    SelectedTuesday = SelectedDay.Date.AddDays(-1);
                    SelectedWednesday = SelectedDay.Date.AddDays(0);
                    SelectedThursday = SelectedDay.Date.AddDays(1);
                    SelectedFriday = SelectedDay.Date.AddDays(2);
                    SelectedSaturday = SelectedDay.Date.AddDays(3);
                    SelectedSunday = SelectedDay.Date.AddDays(4);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Thursday:
                    SelectedMonday = SelectedDay.Date.AddDays(-3);
                    SelectedTuesday = SelectedDay.Date.AddDays(-2);
                    SelectedWednesday = SelectedDay.Date.AddDays(-1);
                    SelectedThursday = SelectedDay.Date.AddDays(0);
                    SelectedFriday = SelectedDay.Date.AddDays(1);
                    SelectedSaturday = SelectedDay.Date.AddDays(2);
                    SelectedSunday = SelectedDay.Date.AddDays(3);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Friday:
                    SelectedMonday = SelectedDay.Date.AddDays(-4);
                    SelectedTuesday = SelectedDay.Date.AddDays(-3);
                    SelectedWednesday = SelectedDay.Date.AddDays(-2);
                    SelectedThursday = SelectedDay.Date.AddDays(-1);
                    SelectedFriday = SelectedDay.Date.AddDays(0);
                    SelectedSaturday = SelectedDay.Date.AddDays(1);
                    SelectedSunday = SelectedDay.Date.AddDays(2);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Saturday:
                    SelectedMonday = SelectedDay.Date.AddDays(-5);
                    SelectedTuesday = SelectedDay.Date.AddDays(-4);
                    SelectedWednesday = SelectedDay.Date.AddDays(-3);
                    SelectedThursday = SelectedDay.Date.AddDays(-2);
                    SelectedFriday = SelectedDay.Date.AddDays(-1);
                    SelectedSaturday = SelectedDay.Date.AddDays(0);
                    SelectedSunday = SelectedDay.Date.AddDays(1);
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
        }

        private void btnPreDate_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(-1);
        }

        private void btnNextDate_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(1);
        }

        private void picLeftMon_Click(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedMonday);
            frmDaily.Show();
        }

        private void picRightMon_Click(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedMonday);
            frmDaily.Show();
        }

        private void picLeftTue_Click(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedTuesday);
            frmDaily.Show();
        }

        private void picRightTue_Click(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedTuesday);
            frmDaily.Show();
        }

        private void picLeftWed_Click(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedWednesday);
            frmDaily.Show();
        }

        private void picRightWed_Click(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedWednesday);
            frmDaily.Show();
        }

        private void picLeftThu_Click(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedThursday);
            frmDaily.Show();
        }

        private void picRightThu_Click(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedThursday);
            frmDaily.Show();
        }

        private void picLeftFri_Click(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedFriday);
            frmDaily.Show();
        }

        private void picRightFri_Click(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedFriday);
            frmDaily.Show();
        }

        private void picLeftSat_Click(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedSaturday);
            frmDaily.Show();
        }

        private void picRightSat_Click(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedSaturday);
            frmDaily.Show();
        }

        private void picLeftSun_Click(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedSunday);
            frmDaily.Show();
        }

        private void picRightSun_Click(object sender, EventArgs e)
        {
            frmDaily frmDaily = new frmDaily(SelectedSunday);
            frmDaily.Show();
        }


    }
}
