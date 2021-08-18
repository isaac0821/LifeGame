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
    public partial class frmReliableJournal : Form
    {
        public frmReliableJournal()
        {
            InitializeComponent();
        }

        private void frmGoodJournal_Load(object sender, EventArgs e)
        {
            refresh();
        }

        public delegate void RefreshLitsHandler();
        public event RefreshLitsHandler RefreshLits;

        private void refresh()
        {
            lsbJournalGood.Items.Clear();
            lsbJournalRemain.Items.Clear();
            List<string> lstAllJournal = new List<string>();
            foreach (CLiterature lit in G.glb.lstLiterature)
            {
                if (!lstAllJournal.Exists(o=>o == lit.JournalOrConferenceName))
                {
                    lstAllJournal.Add(lit.JournalOrConferenceName);
                }
            }
            lstAllJournal = lstAllJournal.OrderBy(o => o).ToList();
            foreach (string jour in lstAllJournal)
            {
                if (G.glb.lstGoodJournal.Exists(o => o == jour))
                {
                    lsbJournalGood.Items.Add(jour);
                }
                else
                {
                    lsbJournalRemain.Items.Add(jour);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lsbJournalRemain.SelectedItems != null)
            {
                foreach (object selected in lsbJournalRemain.SelectedItems)
                {
                    G.glb.lstGoodJournal.Add(selected.ToString());
                }
            }
            refresh();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lsbJournalGood.SelectedItems != null)
            {
                foreach(object selected in lsbJournalGood.SelectedItems)
                {
                    G.glb.lstGoodJournal.Remove(selected.ToString());
                }
            }
            refresh();
        }
    }
}
