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
    public partial class frmDelInfoMine : Form
    {
        DateTime curDate;
        public frmDelInfoMine(DateTime date)
        {
            InitializeComponent();
            curDate = date;
            dtpDate.Value = curDate;
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void frmDelInfoMine_Load(object sender, EventArgs e)
        {
            LoadEvents();
            LoadTransaction();
            LoadBudget();
        }

        private void LoadEvents()
        {
            lsbEvent.Items.Clear();
            List<CEvent> eves = G.glb.lstEvent.FindAll(o => o.TagTime == curDate).ToList();
            foreach (CEvent eve in eves)
            {
                lsbEvent.Items.Add(eve.EventName);
            }
        }

        private void LoadTransaction()
        {
            lsbTransaction.Items.Clear();
            List<CTransaction> transactions = G.glb.lstTransaction.FindAll(o => o.TagTime == curDate).ToList();
            foreach (CTransaction trans in transactions)
            {
                lsbTransaction.Items.Add(trans.Summary);
            }
        }

        private void LoadBudget()
        {
            lsbBudget.Items.Clear();
            List<CTransaction> transactionDues = G.glb.lstBudget.FindAll(o => o.TagTime == curDate).ToList();
            foreach (CTransaction tranDues in transactionDues)
            {
                lsbBudget.Items.Add(tranDues.Summary);
            }
        }

        private void frmDelInfoMine_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DrawLog();
            }
            catch { }
        }

        string SelectedCat = "";
        private void cmsDelete_Opening(object sender, CancelEventArgs e)
        {
            SelectedCat = (sender as ContextMenuStrip).SourceControl.Name;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (SelectedCat)
            {
                case "lsbEvent":
                    if (lsbEvent.SelectedItems!=null)
                    {
                        G.glb.lstEvent.RemoveAll(o => o.TagTime == curDate && o.EventName == lsbEvent.SelectedItem.ToString());
                        LoadEvents();
                    }
                    break;
                case "lsbTransaction":
                    if (lsbTransaction.SelectedItems != null)
                    {
                        G.glb.lstTransaction.RemoveAll(o => o.TagTime == curDate && o.Summary == lsbTransaction.SelectedItem.ToString());
                        LoadTransaction();
                    }
                    break;
                case "lsbBudget":
                    if (lsbBudget.SelectedItems!=null)
                    {
                        G.glb.lstBudget.RemoveAll(o => o.TagTime == curDate && o.Summary == lsbBudget.SelectedItem.ToString());
                        LoadBudget();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
