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
            Draw.DrawScheduleAndLog(picSchedule, curDate, G.glb.lstSchedule, G.glb.lstHealth, false, "all");
        }

        private void LoadSchedule(DateTime date, List<CLog> log)
        {
            List<CLog> todayLogs = log.FindAll(o => o.StartTime.Date == date).ToList();
            List<CLog> yesterdayLogs = log.FindAll(o => o.StartTime.Date == date.AddDays(-1) && o.EndTime.Date == date).ToList();


        }
    }
}
