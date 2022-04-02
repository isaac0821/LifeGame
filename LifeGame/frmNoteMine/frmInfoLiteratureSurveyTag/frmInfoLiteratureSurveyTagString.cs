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
    public partial class frmInfoLiteratureSurveyTagString : Form
    {
        public frmInfoLiteratureSurveyTagString(string Literature, string Survey, string Tag)
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

        private void frmInfoLiteratureSurveyTagBoolean_Load(object sender, EventArgs e)
        {
            lblLiteratureTitle.Text = LiteratureTitle;
            lblSurveyName.Text = SurveyName;
            lblTagName.Text = TagName;

            if (!G.glb.lstSurveyLiteratureTagValue.Exists(o =>
                o.LiteratureTitle == LiteratureTitle
                && o.SurveyTitle == SurveyName
                && o.Tag == TagName))
            {
                txtTagValueString.Text = "";
            }
            else
            {
                txtTagValueString.Text = G.glb.lstSurveyLiteratureTagValue.Find(o =>
                    o.LiteratureTitle == LiteratureTitle
                    && o.SurveyTitle == SurveyName
                    && o.Tag == TagName).TagValueString;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!G.glb.lstSurveyLiteratureTagValue.Exists(o =>
                o.LiteratureTitle == LiteratureTitle
                && o.SurveyTitle == SurveyName
                && o.Tag == TagName))
            {
                if (txtTagValueString.Text != "")
                {
                    RSurveyLiteratureTagValue value = new RSurveyLiteratureTagValue();
                    value.LiteratureTitle = LiteratureTitle;
                    value.SurveyTitle = SurveyName;
                    value.Tag = TagName;
                    value.TagValueString = txtTagValueString.Text;
                    G.glb.lstSurveyLiteratureTagValue.Add(value);
                }
            }
            else
            {
                G.glb.lstSurveyLiteratureTagValue.Find(o =>
                    o.LiteratureTitle == LiteratureTitle
                    && o.SurveyTitle == SurveyName
                    && o.Tag == TagName).TagValueString = txtTagValueString.Text;
            }
            RefreshDgv();
            Dispose();
        }
    }
}
