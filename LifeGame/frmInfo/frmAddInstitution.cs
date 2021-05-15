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
    public partial class frmAddInstitution : Form
    {
        public delegate void GetInstitution(string Institution);
        public event GetInstitution SendInstitution;

        List<string> candidateInstitution = new List<string>();
        public frmAddInstitution(List<string> authors)
        {
            foreach (string author in authors)
            {
                foreach (RAuthorAffiliation affiliation in G.glb.lstAuthorAffiliation.FindAll(o => o.Author == author))
                {
                    if (!candidateInstitution.Exists(o => o == affiliation.Affiliation))
                    {
                        candidateInstitution.Add(affiliation.Affiliation);
                    }
                }
            }
            InitializeComponent();
        }

        private void frmAddInstitution_Load(object sender, EventArgs e)
        {
            foreach (string ins in candidateInstitution)
            {
                lsbCandidates.Items.Add(ins);
            }
        }

        private void lsbCandidates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbCandidates.SelectedItem != null)
            {
                txtInstitution.Text = lsbCandidates.SelectedItem.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (SendInstitution != null)
            {
                SendInstitution(txtInstitution.Text);
            }
        }
    }
}
