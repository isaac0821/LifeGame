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
    public partial class frmInfoEvent : Form
    {
        CEvent eve;
        Timer timer = new Timer();
        public frmInfoEvent(CEvent info)
        {
            InitializeComponent();
            eve = info;            
            lblEventName.Text = eve.EventName;
            if (eve.EventState== EEventState.Succeed)
            {
                tlpEvent.BackColor = Color.Green;
                lblSucceed.Text = "Succeed";
            }
            else if (eve.EventState == EEventState.Failed)
            {
                tlpEvent.BackColor = Color.Red;
                lblSucceed.Text = "Failed";
            }
            else if (eve.EventState == EEventState.LogEvent)
            {
                tlpEvent.BackColor = Color.Gray;
                lblSucceed.Text = "Log Event";
            }
            timer.Interval = 10000;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblEventName_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblSucceed_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tlpEvent_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmInfoEvent_Deactivate(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
