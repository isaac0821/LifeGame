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
    public partial class frmAddSleepLog : Form
    {
        private DateTime curDate;
        public frmAddSleepLog(DateTime selectDate)
        {
            curDate = selectDate;
            InitializeComponent();
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CSleep newSleep = new CSleep();
            newSleep.Date = curDate;
            newSleep.IsGoToBedBeforeMidNight = chkMinusOneDay.Checked;
            if (chkMinusOneDay.Checked)
            {
                newSleep.GoToBedTime = new DateTime(curDate.AddDays(-1).Year, curDate.AddDays(-1).Month, curDate.AddDays(-1).Day, dtpTimeStart.Value.Hour, dtpTimeStart.Value.Minute, dtpTimeStart.Value.Second);
            }
            else
            {
                newSleep.GoToBedTime = new DateTime(curDate.Year, curDate.Month, curDate.Day, dtpTimeStart.Value.Hour, dtpTimeStart.Value.Minute, dtpTimeStart.Value.Second);
            }
            newSleep.GetUpTime = new DateTime(curDate.Year, curDate.Month, curDate.Day, dtpTimeEnd.Value.Hour, dtpTimeEnd.Value.Minute, dtpTimeEnd.Value.Second);
            if (G.glb.lstSleepLog.Exists(o => o.Date == curDate))
            {
                G.glb.lstSleepLog.RemoveAll(o => o.Date == curDate);
                G.glb.lstSleepLog.Add(newSleep);
            }
            else
            {
                G.glb.lstSleepLog.Add(newSleep);
            }
            DrawLog();
            Dispose();
        }

        private void frmAddSleepLog_Load(object sender, EventArgs e)
        {
            dtpDate.Value = curDate;
        }
    }
}
