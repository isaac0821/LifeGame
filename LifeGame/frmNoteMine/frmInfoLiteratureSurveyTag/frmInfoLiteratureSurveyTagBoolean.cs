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
    public partial class frmInfoLiteratureSurveyTagBoolean : Form
    {
        public frmInfoLiteratureSurveyTagBoolean(string Literature, string Survey, string Tag)
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
                rdoTrue.Checked = false;
                rdoFalse.Checked = false;
            }
            else
            {
                if (G.glb.lstSurveyLiteratureTagValue.Find(o =>
                o.LiteratureTitle == LiteratureTitle
                && o.SurveyTitle == SurveyName
                && o.Tag == TagName).TagValueBoolean)
                {
                    rdoTrue.Checked = true;
                    rdoFalse.Checked = false;
                }
                else
                {
                    rdoTrue.Checked = false;
                    rdoFalse.Checked = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!G.glb.lstSurveyLiteratureTagValue.Exists(o =>
                o.LiteratureTitle == LiteratureTitle
                && o.SurveyTitle == SurveyName
                && o.Tag == TagName))
            {
                if (rdoTrue.Checked || rdoFalse.Checked)
                {
                    RSurveyLiteratureTagValue value = new RSurveyLiteratureTagValue();
                    value.LiteratureTitle = LiteratureTitle;
                    value.SurveyTitle = SurveyName;
                    value.Tag = TagName;
                    if (rdoTrue.Checked)
                    {
                        value.TagValueBoolean = true;
                    }
                    else
                    {
                        value.TagValueBoolean = false;
                    }
                    G.glb.lstSurveyLiteratureTagValue.Add(value);
                }
            }
            else
            {
                if (rdoTrue.Checked || rdoFalse.Checked)
                {
                    if (rdoTrue.Checked)
                    {
                        G.glb.lstSurveyLiteratureTagValue.Find(o =>
                            o.LiteratureTitle == LiteratureTitle
                            && o.SurveyTitle == SurveyName
                            && o.Tag == TagName).TagValueBoolean = true;
                    }
                    else
                    {
                        G.glb.lstSurveyLiteratureTagValue.Find(o =>
                            o.LiteratureTitle == LiteratureTitle
                            && o.SurveyTitle == SurveyName
                            && o.Tag == TagName).TagValueBoolean = false;
                    }
                }
            }
            RefreshDgv();
            Dispose();
        }
    }
}
