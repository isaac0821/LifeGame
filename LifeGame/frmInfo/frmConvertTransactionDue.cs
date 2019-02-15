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
    public partial class frmConvertTransactionDue : Form
    {
        DateTime curDate;
        public frmConvertTransactionDue(DateTime date)
        {
            InitializeComponent();
            curDate = date;
            dtpDate.Value = curDate;
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void LoadTransactionDue()
        {
            lsbTransactionDue.Items.Clear();
            List<CTransaction> transactionDues = G.glb.lstTransactionDue.FindAll(o => o.TagTime == curDate).ToList();
            foreach (CTransaction due in transactionDues)
            {
                lsbTransactionDue.Items.Add(due.Summary);
            }
        }

        private void tsmConvert_Click(object sender, EventArgs e)
        {
            if (lsbTransactionDue.SelectedItems != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to convert?", "Convert", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        CTransaction convert = G.glb.lstTransactionDue.Find(o => o.TagTime == curDate && o.Summary == lsbTransactionDue.SelectedItem.ToString());
                        G.glb.lstTransaction.Add(convert);
                        G.glb.lstTransactionDue.RemoveAll(o => o.TagTime == curDate && o.Summary == lsbTransactionDue.SelectedItem.ToString());
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
                LoadTransactionDue();
            }
        }

        private void frmConvertTransactionDue_Load(object sender, EventArgs e)
        {
            LoadTransactionDue();
        }

        private void frmConvertTransactionDue_FormClosing(object sender, FormClosingEventArgs e)
        {
            DrawLog();
        }
    }
}
