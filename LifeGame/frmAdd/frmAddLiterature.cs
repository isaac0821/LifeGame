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
    public partial class frmAddLiterature : Form
    {
        public delegate void GetLiterature(string Literature);
        public event GetLiterature SendLiterature;

        public frmAddLiterature()
        {
            InitializeComponent();
        }

        private void frmAddLiterature_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtLiterature;
        }

        private void lsbCandidates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbCandidates.SelectedItem != null)
            {
                txtLiterature.Text = lsbCandidates.SelectedItem.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (SendLiterature != null)
            {
                SendLiterature(txtLiterature.Text);
                txtLiterature.Text = "";
            }
        }

        private List<string> GetSimilarLiterature(string SubStr)
        {
            List<string> Similar = new List<string>();
            List<string> All = new List<string>();
            foreach (CLiterature item in G.glb.lstLiterature)
            {
                if (!All.Exists(o => o == item.Title))
                {
                    All.Add(item.Title);
                }
            }
            for (int i = 0; i < All.Count; i++)
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

        private void txtLiterature_TextChanged(object sender, EventArgs e)
        {
            if (txtLiterature.Text.Length >= 1)
            {
                lsbCandidates.Items.Clear();
                foreach (string ins in GetSimilarLiterature(txtLiterature.Text))
                {
                    lsbCandidates.Items.Add(ins);
                }
            }
        }
    }
}
