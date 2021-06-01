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
    public partial class frmAddTag : Form
    {
        public delegate void GetTag(string Tag);
        public event GetTag SendTag;

        public frmAddTag()
        {
            InitializeComponent();
        }

        private void frmAddTag_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtTag;
        }

        private void lsbCandidates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbCandidates.SelectedItem != null)
            {
                txtTag.Text = lsbCandidates.SelectedItem.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (SendTag != null)
            {
                SendTag(txtTag.Text);
                txtTag.Text = "";
            }
        }

        private List<string> GetSimilarTag(string SubStr)
        {
            List<string> Similar = new List<string>();
            List<string> All = new List<string>();
            foreach (RLiteratureTag item in G.glb.lstLiteratureTag)
            {
                if (!All.Exists(o => o == item.Tag))
                {
                    All.Add(item.Tag);
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

        private void txtTag_TextChanged(object sender, EventArgs e)
        {
            if (txtTag.Text.Length >= 1)
            {
                lsbCandidates.Items.Clear();
                foreach (string ins in GetSimilarTag(txtTag.Text))
                {
                    lsbCandidates.Items.Add(ins);
                }
            }
        }
    }
}
