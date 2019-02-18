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
    public partial class frmConvertBudget : Form
    {
        DateTime curDate;
        public frmConvertBudget(DateTime date)
        {
            InitializeComponent();
            curDate = date;
            dtpDate.Value = curDate;
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void LoadBudget()
        {
            lsbBudget.Items.Clear();
            List<CTransaction> budgets = G.glb.lstBudget.FindAll(o => o.TagTime == curDate).ToList();
            foreach (CTransaction due in budgets)
            {
                lsbBudget.Items.Add(due.Summary);
            }
        }

        private void tsmConvert_Click(object sender, EventArgs e)
        {
            if (lsbBudget.SelectedItems != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to convert?", "Convert", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        CTransaction convert = G.glb.lstBudget.Find(o => o.TagTime == curDate && o.Summary == lsbBudget.SelectedItem.ToString());
                        G.glb.lstTransaction.Add(convert);
                        G.glb.lstBudget.RemoveAll(o => o.TagTime == curDate && o.Summary == lsbBudget.SelectedItem.ToString());
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
                LoadBudget();
            }
        }

        private void frmConvertTransactionDue_Load(object sender, EventArgs e)
        {
            LoadBudget();
        }

        private void frmConvertTransactionDue_FormClosing(object sender, FormClosingEventArgs e)
        {
            DrawLog();
        }
    }
}
