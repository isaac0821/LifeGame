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
    public partial class frmDelLog : Form
    {
        DateTime curDate;
        bool LogOrSchedule;
        public frmDelLog(DateTime date, bool logOrSchedule)
        {
            InitializeComponent();
            curDate = date;
            dtpDate.Value = curDate;
            LogOrSchedule = logOrSchedule;
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void frmEditLogList_Load(object sender, EventArgs e)
        {
            LoadLogs();
        }

        private void LoadLogs()
        {
            lsbLogList.Items.Clear();
            List<CLog> logs = new List<CLog>();
            if (LogOrSchedule)
            {
                logs = G.glb.lstLog.FindAll(o => o.StartTime.Date == curDate).ToList();
            }
            else
            {
                logs = G.glb.lstSchedule.FindAll(o => o.StartTime.Date == curDate).ToList();
            }
            foreach (CLog log in logs)
            {
                lsbLogList.Items.Add(log.LogName);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsbLogList.SelectedItem!=null)
            {
                if (LogOrSchedule)
                {
                    G.glb.lstLog.RemoveAll(o => o.StartTime.Date == curDate && o.LogName == lsbLogList.SelectedItem.ToString());
                }
                else
                {
                    G.glb.lstSchedule.RemoveAll(o => o.StartTime.Date == curDate && o.LogName == lsbLogList.SelectedItem.ToString());
                }
                LoadLogs();
            }
        }

        private void frmEditLogList_FormClosing(object sender, FormClosingEventArgs e)
        {
            DrawLog();
        }
    }
}
