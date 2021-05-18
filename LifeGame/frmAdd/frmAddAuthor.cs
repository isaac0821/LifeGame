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
    public partial class frmAddAuthor : Form
    {
        public delegate void GetAuthor(string Author);
        public event GetAuthor SendAuthor;

        public frmAddAuthor()
        {
            InitializeComponent();
        }

        private void frmAddAuthor_Load(object sender, EventArgs e)
        {

        }

        private void lsbCandidates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbCandidates.SelectedItem != null)
            {
                txtAuthor.Text = lsbCandidates.SelectedItem.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (SendAuthor != null)
            {
                SendAuthor(txtAuthor.Text);
            }
        }

        private List<string> GetSimilarAuthor(string SubStr)
        {
            List<string> Similar = new List<string>();
            List<string> All = new List<string>();
            foreach (RLiteratureAuthor item in G.glb.lstLiteratureAuthor)
            {
                if (!All.Exists(o => o == item.Author))
                {
                    All.Add(item.Author);
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

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {
            if (txtAuthor.Text.Length >= 1)
            {
                lsbCandidates.Items.Clear();
                foreach (string ins in GetSimilarAuthor(txtAuthor.Text))
                {
                    lsbCandidates.Items.Add(ins);
                }
            }
        }
    }
}
