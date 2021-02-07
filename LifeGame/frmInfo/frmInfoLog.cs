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
    public partial class frmInfoLog : Form
    {
        Timer timer = new Timer();
        bool AutoClose = true;
        public frmInfoLog(string TimePeriod, string LogName, string Location, string WithWho, string TaskName, Color color, bool IsAlarm, bool autoClose)
        {
            InitializeComponent();
            lblTimePeriod.Text = TimePeriod;
            lblLogName.Text = LogName;
            lblLocation.Text = Location;
            lblWithWho.Text = WithWho;
            lblTask.Text = TaskName;
            tlpLogInfo.BackColor = color;
            Color contri = new Color();
            contri = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
            lblTimePeriod.ForeColor = contri;
            lblLogName.ForeColor = contri;
            lblLocation.ForeColor = contri;
            lblWithWho.ForeColor = contri;
            lblTask.ForeColor = contri;
            AutoClose = autoClose;
            if (IsAlarm)
            {
                picClock.Image = icon.iconClock;
            }
            if (AutoClose)
            {
                timer.Interval = 20000;
                timer.Start();
                timer.Tick += Timer_Tick;
            }
        }
        
        public frmInfoLog(string TimePeriod, string LogName, string Location, string WithWho, string TaskName, Color color, bool IsAlarm)
        {
            InitializeComponent();
            lblTimePeriod.Text = TimePeriod;
            lblLogName.Text = LogName;
            lblLocation.Text = Location;
            lblWithWho.Text = WithWho;
            lblTask.Text = TaskName;
            tlpLogInfo.BackColor = color;
            Color contri = new Color();
            contri = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
            lblTimePeriod.ForeColor = contri;
            lblLogName.ForeColor = contri;
            lblLocation.ForeColor = contri;
            lblWithWho.ForeColor = contri;
            lblTask.ForeColor = contri;
            if (IsAlarm)
            {
                picClock.Image = icon.iconClock;
            }
            timer.Interval = 20000;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmLogInfo_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblTimePeriod_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblLogName_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblLocation_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblWithWho_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmLogInfo_Leave(object sender, EventArgs e)
        {
            if (AutoClose)
            {
                Dispose();
            }
        }

        private void frmLogInfo_Deactivate(object sender, EventArgs e)
        {
            if (AutoClose)
            {
                Dispose();
            }
        }
    }
}
