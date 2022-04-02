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
    public partial class frmAddSurveyLiterature : Form
    {
        public delegate void GetSurvey(string Survey);
        public event GetSurvey SendSurvey;

        public frmAddSurveyLiterature(string Literature)
        {
            LiteratureTitle = Literature;
            InitializeComponent();
        }

        private string LiteratureTitle;

        private void frmAddSurveyLiterature_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtSurvey;
            foreach (CSurvey survey in G.glb.lstSurvey)
            {
                lsbSurvey.Items.Add(survey.SurveyTitle);
            }
        }

        private void lsbSurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbSurvey.SelectedItem != null)
            {
                txtSurvey.Text = lsbSurvey.SelectedItem.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (SendSurvey != null)
            {
                SendSurvey(txtSurvey.Text);
                Dispose();
            }
        }

        private void txtSurvey_TextChanged(object sender, EventArgs e)
        {
            if (txtSurvey.Text.Length >= 1)
            {
                lsbSurvey.Items.Clear();
                foreach (string ins in GetSimilarSurvey(txtSurvey.Text))
                {
                    lsbSurvey.Items.Add(ins);
                }
            }
        }

        private List<string> GetSimilarSurvey(string SubStr)
        {
            List<string> Similar = new List<string>();
            List<string> All = new List<string>();
            foreach (CSurvey item in G.glb.lstSurvey)
            {
                if (!All.Exists(o => o == item.SurveyTitle))
                {
                    All.Add(item.SurveyTitle);
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
    }
}
