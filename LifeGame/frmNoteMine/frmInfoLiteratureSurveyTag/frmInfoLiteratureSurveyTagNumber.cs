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
    public partial class frmInfoLiteratureSurveyTagNumber : Form
    {
        public frmInfoLiteratureSurveyTagNumber(string Literature, string Survey, string Tag)
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
                txtTagValueInteger.Text = "";
            }
            else
            {
                txtTagValueInteger.Text = G.glb.lstSurveyLiteratureTagValue.Find(o =>
                    o.LiteratureTitle == LiteratureTitle
                    && o.SurveyTitle == SurveyName
                    && o.Tag == TagName).TagValueNumber.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!G.glb.lstSurveyLiteratureTagValue.Exists(o =>
                o.LiteratureTitle == LiteratureTitle
                && o.SurveyTitle == SurveyName
                && o.Tag == TagName))
            {
                RSurveyLiteratureTagValue value = new RSurveyLiteratureTagValue();
                value.LiteratureTitle = LiteratureTitle;
                value.SurveyTitle = SurveyName;
                value.Tag = TagName;
                if (System.Text.RegularExpressions.Regex.IsMatch(txtTagValueInteger.Text, "^[0-9]*$"))
                {
                    value.TagValueNumber = Convert.ToInt32(txtTagValueInteger.Text);
                    G.glb.lstSurveyLiteratureTagValue.Add(value);
                }
                else
                {
                    MessageBox.Show("Please enter an integer");
                }               
            }
            else
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtTagValueInteger.Text, "^[0-9]*$"))
                {
                    G.glb.lstSurveyLiteratureTagValue.Find(o =>
                        o.LiteratureTitle == LiteratureTitle
                        && o.SurveyTitle == SurveyName
                        && o.Tag == TagName).TagValueNumber = Convert.ToInt32(txtTagValueInteger.Text);
                }
                else
                {
                    MessageBox.Show("Please enter an integer");
                }
            }
            RefreshDgv();
            Dispose();
        }
    }
}
