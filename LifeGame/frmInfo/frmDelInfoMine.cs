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
            LoadTransactionDue();
            LoadWorkOut();
            LoadMedicine();
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

        private void LoadTransactionDue()
        {
            lsbTransactionDue.Items.Clear();
            List<CTransaction> transactionDues = G.glb.lstTransactionDue.FindAll(o => o.TagTime == curDate).ToList();
            foreach (CTransaction tranDues in transactionDues)
            {
                lsbTransactionDue.Items.Add(tranDues.Summary);
            }
        }

        private void LoadWorkOut()
        {
            lsbWorkOut.Items.Clear();
            List<CWorkOut> workOuts = G.glb.lstWorkOut.FindAll(o => o.TagTime == curDate).ToList();
            foreach (CWorkOut workOut in workOuts)
            {
                lsbWorkOut.Items.Add(workOut.WorkOutType);
            }
        }

        private void LoadMedicine()
        {
            lsbMedicine.Items.Clear();
            List<CMedicine> medicines = G.glb.lstMedicine.FindAll(o => o.TagTime == curDate).ToList();
            foreach (CMedicine medicine in medicines)
            {
                lsbMedicine.Items.Add(medicine.MedicineName);
            }
        }

        private void frmDelInfoMine_FormClosing(object sender, FormClosingEventArgs e)
        {
            DrawLog();
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
                case "lsbTransactionDue":
                    if (lsbTransactionDue.SelectedItems!=null)
                    {
                        G.glb.lstTransactionDue.RemoveAll(o => o.TagTime == curDate && o.Summary == lsbTransactionDue.SelectedItem.ToString());
                        LoadTransactionDue();
                    }
                    break;
                case "lsbWorkOut":
                    if (lsbWorkOut.SelectedItems!=null)
                    {
                        G.glb.lstWorkOut.RemoveAll(o => o.TagTime == curDate && o.WorkOutType == lsbWorkOut.SelectedItem.ToString());
                        LoadWorkOut();
                    }
                    break;
                case "lsbMedicine":
                    if (lsbMedicine.SelectedItems!=null)
                    {
                        G.glb.lstMedicine.RemoveAll(o => o.TagTime == curDate && o.MedicineName == lsbMedicine.SelectedItem.ToString());
                        LoadMedicine();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
