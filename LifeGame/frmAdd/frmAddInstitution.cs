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
            this.ActiveControl = txtInstitution;
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
                txtInstitution.Text = "";
            }
        }

        private List<string> GetSimilarInstitution(string SubStr)
        {
            List<string> Similar = new List<string>();
            List<string> All = new List<string>();
            foreach (RLiteratureInstitution item in G.glb.lstLiteratureInstitution)
            {
                if (!All.Exists(o => o == item.Institution)
                    && !candidateInstitution.Exists(o => o == item.Institution))
                {
                    All.Add(item.Institution);
                }
            }
            for (int i = 0; i < All.Count; i ++)
            {
                bool SimilarFlag = true;
                if (SubStr.Length > All[i].Length)
                {
                    SimilarFlag = false;
                }
                else
                {
                    for (int j = 0; j < SubStr.Length; j++)
                    {
                        if (SimilarFlag && All[i][j] == SubStr[j])
                        {
                            SimilarFlag = true;
                        }
                        else
                        {
                            SimilarFlag = false;
                            break;
                        }
                    }
                }
                if (SimilarFlag)
                {
                    Similar.Add(All[i]);
                }
            }
            Similar.Sort();
            return Similar;
        }

        private void txtInstitution_TextChanged(object sender, EventArgs e)
        {
            if (txtInstitution.Text.Length >= 1)
            {
                lsbCandidates.Items.Clear();
                foreach (string ins in candidateInstitution)
                {
                    lsbCandidates.Items.Add(ins);
                }
                foreach (string ins in GetSimilarInstitution(txtInstitution.Text))
                {
                    lsbCandidates.Items.Add(ins);
                }
            }
            else
            {
                lsbCandidates.Items.Clear();
                foreach (string ins in candidateInstitution)
                {
                    lsbCandidates.Items.Add(ins);
                }
            }
        }
    }
}
