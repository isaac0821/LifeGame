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
    public partial class frmAddEvent : Form
    {
        private DateTime curDate;
        public frmAddEvent(DateTime selectedDate)
        {
            curDate = selectedDate;
            InitializeComponent();
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool CanAddFlag = true;
            if (G.glb.lstEvent.Exists(o=>o.TagTime == curDate && o.EventName == txtEvent.Text))
            {
                MessageBox.Show("Can not add two event in the same name at the same day.");
                CanAddFlag = false;
            }

            if (CanAddFlag)
            {
                CEvent newEvent = new CEvent();
                newEvent.EventName = txtEvent.Text;
                newEvent.TagTime = dtpDate.Value.Date;
                switch (cbxEventState.Text)
                {
                    case "Log Event":
                        newEvent.EventState = EEventState.LogEvent;
                        break;
                    case "Succeed":
                        newEvent.EventState = EEventState.Succeed;
                        break;
                    case "Failed":
                        newEvent.EventState = EEventState.Failed;
                        break;
                    default:
                        break;
                }
                G.glb.lstEvent.Add(newEvent);
                DrawLog();
                Dispose();
            }
        }

        private void frmAddEvent_Load(object sender, EventArgs e)
        {
            dtpDate.Value = curDate.Date;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            curDate = dtpDate.Value.Date;
        }
    }
}
