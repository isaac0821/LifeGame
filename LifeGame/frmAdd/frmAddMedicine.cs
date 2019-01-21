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
    public partial class frmAddMedicine : Form
    {
        private DateTime curDate;
        public frmAddMedicine(DateTime selectDate)
        {
            curDate = selectDate;
            InitializeComponent();
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool CanAddFlag = true;
            EMedicineTiming medicineTiming;
            switch (cbxMedicineTiming.Text)
            {
                case "Before Breakfast":
                    medicineTiming = EMedicineTiming.BeforeBreakfast;
                    break;
                case "After Breakfast":
                    medicineTiming = EMedicineTiming.AfterBreakfast;
                    break;
                case "Before Lunch":
                    medicineTiming = EMedicineTiming.BeforeLunch;
                    break;
                case "After Lunch":
                    medicineTiming = EMedicineTiming.AfterLunch;
                    break;
                case "Before Dinner":
                    medicineTiming = EMedicineTiming.BeforeDinner;
                    break;
                case "After Dinner":
                    medicineTiming = EMedicineTiming.AfterDinner;
                    break;
                case "Before Sleep":
                    medicineTiming = EMedicineTiming.BeforeSleep;
                    break;
                case "When Needed":
                    medicineTiming = EMedicineTiming.WhenNeeded;
                    break;
                default:
                    medicineTiming = EMedicineTiming.WhenNeeded;
                    break;
            }
            if (G.glb.lstMedicine.Exists(o => o.TagTime == curDate && o.MedicineName == txtMedicineName.Text && o.MedicineTime == medicineTiming))
            {
                MessageBox.Show("Medicine log exists.");
                CanAddFlag = false;
            }

            if(CanAddFlag)
            {
                CMedicine newMedicine = new CMedicine();
                newMedicine.TagTime = dtpDate.Value.Date;
                newMedicine.MedicineName = txtMedicineName.Text;
                newMedicine.MedicineQty = Convert .ToDouble( txtMedicineQty.Text);
                newMedicine.MedicineUnit = txtMedicineUnit.Text;
                newMedicine.MedicineTime = medicineTiming;
                G.glb.lstMedicine.Add(newMedicine);
                DrawLog();
                Dispose();
            }
        }

        private void frmAddMedicine_Load(object sender, EventArgs e)
        {
            dtpDate.Value = curDate.Date;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            curDate = dtpDate.Value.Date;
        }
    }
}
