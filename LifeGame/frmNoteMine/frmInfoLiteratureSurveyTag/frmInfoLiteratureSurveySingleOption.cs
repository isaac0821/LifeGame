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
    public partial class frmInfoLiteratureSurveyTagSingleOption : Form
    {
        public frmInfoLiteratureSurveyTagSingleOption(string Literature, string Survey, string Tag)
        {
            LiteratureTitle = Literature;
            SurveyName = Survey;
            TagName = Tag;
            InitializeComponent();
        }

        public delegate void RefreshDgvHandler();
        public event RefreshDgvHandler RefreshDgv;

        private string LiteratureTitle;
        private string SurveyName;
        private string TagName;

        private void frmInfoLiteratureSurveyTagSingleOption_Load(object sender, EventArgs e)
        {
            lblLiteratureTitle.Text = LiteratureTitle;
            lblSurveyName.Text = SurveyName;
            lblTagName.Text = TagName;

            if (!G.glb.lstSurveyTagValueOption.Exists(o =>
                o.SurveyTitle == SurveyName
                && o.Tag == TagName))
            {
                lsbTagValueOption.Items.Clear();
            }
            else
            {
                foreach (RSurveyTagValueOption item in G.glb.lstSurveyTagValueOption.FindAll(o =>
                    o.SurveyTitle == lblSurveyName.Text
                    && o.Tag == lblTagName.Text).ToList())
                {
                    lsbTagValueOption.Items.Add(item.TagOption);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTagValueOption.Text != "")
            {
                if (!G.glb.lstSurveyLiteratureTagValue.Exists(o =>
                    o.LiteratureTitle == LiteratureTitle
                    && o.SurveyTitle == SurveyName
                    && o.Tag == TagName))
                {
                    RSurveyLiteratureTagValue tagValue = new RSurveyLiteratureTagValue();
                    tagValue.LiteratureTitle = LiteratureTitle;
                    tagValue.SurveyTitle = SurveyName;
                    tagValue.Tag = TagName;
                    tagValue.TagValueString = txtTagValueOption.Text;
                    G.glb.lstSurveyLiteratureTagValue.Add(tagValue);
                }
                else
                {
                    G.glb.lstSurveyLiteratureTagValue.Find(o =>
                        o.LiteratureTitle == LiteratureTitle
                        && o.SurveyTitle == SurveyName
                        && o.Tag == TagName).TagValueString = txtTagValueOption.Text;
                }
            }
            RefreshDgv();
            Dispose();
        }

        private void lsbTagValueOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbTagValueOption.SelectedItem != null)
            {
                txtTagValueOption.Text = lsbTagValueOption.SelectedItem.ToString();
            }
        }
    }
}
