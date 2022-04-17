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
    public partial class frmUnreliableJournal : Form
    {
        public frmUnreliableJournal()
        {
            InitializeComponent();
        }

        private void frmBadJournal_Load(object sender, EventArgs e)
        {
            refresh();
        }

        public delegate void RefreshLitsHandler();
        public event RefreshLitsHandler RefreshLits;

        private void refresh()
        {
            lsbJournalBad.Items.Clear();
            lsbJournalRemain.Items.Clear();
            List<string> lstAllJournal = new List<string>();
            foreach (CLiterature lit in G.glb.lstLiterature)
            {
                if (!lstAllJournal.Exists(o=>o == lit.JournalOrConferenceName) && !G.glb.lstGoodJournal.Exists(o => o == lit.JournalOrConferenceName))
                {
                    lstAllJournal.Add(lit.JournalOrConferenceName);
                }
            }
            lstAllJournal = lstAllJournal.OrderBy(o => o).ToList();
            foreach (string jour in lstAllJournal)
            {
                if (G.glb.lstBadJournal.Exists(o => o == jour))
                {
                    lsbJournalBad.Items.Add(jour);
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
                    G.glb.lstBadJournal.Add(selected.ToString());
                }
            }
            refresh();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lsbJournalBad.SelectedItems != null)
            {
                foreach(object selected in lsbJournalBad.SelectedItems)
                {
                    G.glb.lstBadJournal.Remove(selected.ToString());
                }
            }
            refresh();
        }
    }
}
