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
    public partial class frmConvertSchedule : Form
    {
        DateTime curDate;
        public frmConvertSchedule(DateTime date)
        {
            InitializeComponent();
            curDate = date;
            dtpDate.Value = curDate;
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void LoadSchedule()
        {
            lsbSchedule.Items.Clear();
            List<CLog> schedules = G.glb.lstLog.FindAll(o => o.StartTime.Date == curDate).ToList();
            foreach (CLog schedule in schedules)
            {
                lsbSchedule.Items.Add(schedule.LogName);
            }
        }

        private void tsmConvert_Click(object sender, EventArgs e)
        {
            if (lsbSchedule.SelectedItems != null)
            {
                
            }
        }

        private void frmConvertSchedule_Load(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        private void frmConvertSchedule_FormClosing(object sender, FormClosingEventArgs e)
        {
            DrawLog();
        }
    }
}
