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
    public partial class frmInfoLiteratureSurvey : Form
    {
        public frmInfoLiteratureSurvey(string Literature, string Survey)
        {
            LiteratureTitle = Literature;
            SurveyName = Survey;
            InitializeComponent();
        }

        public delegate void RefreshDgvHandler();
        public event RefreshDgvHandler RefreshDgv;

        private string LiteratureTitle;
        private string SurveyName;

        private void frmInfoLiteratureSurvey_Load(object sender, EventArgs e)
        {
            lblLiterature.Text = LiteratureTitle;
            lblSurvey.Text = SurveyName;
            FindChildTag("(Root)");
            LoadDgv();
        }

        private List<string> lstBottomTag = new List<string>();
        private void FindChildTag(string Tag)
        {
            List<RSurveySubTag> tags = G.glb.lstSurveySubTag.FindAll(o =>
                o.SurveyTitle == SurveyName
                && o.Tag == Tag).ToList();
            tags.OrderBy(o => o.SubTagIndex);
            foreach (RSurveySubTag item in tags)
            {
                if (G.glb.lstSurveyTag.Find(o => 
                    o.SurveyTitle == SurveyName
                    && o.Tag == item.SubTag).TagType == ESurveyTagType.NonBottom)
                {
                    FindChildTag(item.SubTag);
                }
                else
                {
                    lstBottomTag.Add(item.SubTag);
                }
            }
        }

        private void LoadDgv()
        {
            dgvLiteratureSurvey.Rows.Clear();
            foreach (string bottomTag in lstBottomTag)
            {
                string tagType = "";
                string tagName = bottomTag;
                string tagValue = "";
                tagType = G.glb.lstSurveyTag.Find(o =>
                    o.SurveyTitle == SurveyName
                    && o.Tag == bottomTag).TagType.ToString();
                if (!G.glb.lstSurveyLiteratureTagValue.Exists(o =>
                    o.LiteratureTitle == LiteratureTitle
                    && o.SurveyTitle == SurveyName
                    && o.Tag == bottomTag))
                {
                    tagValue = "(null)";
                }
                else
                {
                    if (tagType == "Number")
                    {
                        tagValue = G.glb.lstSurveyLiteratureTagValue.Find(o =>
                            o.LiteratureTitle == LiteratureTitle
                            && o.SurveyTitle == SurveyName
                            && o.Tag == bottomTag).TagValueNumber.ToString();
                    }
                    else if (tagType == "String" || tagType == "SingleOption")
                    {
                        tagValue = G.glb.lstSurveyLiteratureTagValue.Find(o =>
                            o.LiteratureTitle == LiteratureTitle
                            && o.SurveyTitle == SurveyName
                            && o.Tag == bottomTag).TagValueString;
                    }
                    else if (tagType == "Boolean")
                    {
                        if (G.glb.lstSurveyLiteratureTagValue.Find(o =>
                            o.LiteratureTitle == LiteratureTitle
                            && o.SurveyTitle == SurveyName
                            && o.Tag == bottomTag).TagValueBoolean)
                        {
                            tagValue = "True";
                        }
                        else
                        {
                            tagValue = "False";
                        }
                    }
                }
                dgvLiteratureSurvey.Rows.Add(tagType, tagName, tagValue);
            }
        }

        private void dgvLiteratureSurvey_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLiteratureSurvey.SelectedCells.Count == 1)
            {
                string tagType = dgvLiteratureSurvey.CurrentRow.Cells[0].Value.ToString();
                string tagName = dgvLiteratureSurvey.CurrentRow.Cells[1].Value.ToString();
                if (tagType == "Number")
                {
                    frmInfoLiteratureSurveyTagNumber frmInfoLiteratureSurveyTagNumber = new frmInfoLiteratureSurveyTagNumber(LiteratureTitle, SurveyName, tagName);
                    frmInfoLiteratureSurveyTagNumber.RefreshDgv += new frmInfoLiteratureSurveyTagNumber.RefreshDgvHandler(LoadDgv);
                    frmInfoLiteratureSurveyTagNumber.Show();
                }
                else if (tagType == "String")
                {
                    frmInfoLiteratureSurveyTagString frmInfoLiteratureSurveyTagString = new frmInfoLiteratureSurveyTagString(LiteratureTitle, SurveyName, tagName);
                    frmInfoLiteratureSurveyTagString.RefreshDgv += new frmInfoLiteratureSurveyTagString.RefreshDgvHandler(LoadDgv);
                    frmInfoLiteratureSurveyTagString.Show();
                }
                else if (tagType == "SingleOption")
                {
                    frmInfoLiteratureSurveyTagSingleOption frmInfoLiteratureSurveyTagSingleOption = new frmInfoLiteratureSurveyTagSingleOption(LiteratureTitle, SurveyName, tagName);
                    frmInfoLiteratureSurveyTagSingleOption.RefreshDgv += new frmInfoLiteratureSurveyTagSingleOption.RefreshDgvHandler(LoadDgv);
                    frmInfoLiteratureSurveyTagSingleOption.Show();
                }
                else if (tagType == "Boolean")
                {
                    frmInfoLiteratureSurveyTagBoolean frmInfoLiteratureSurveyTagBoolean = new frmInfoLiteratureSurveyTagBoolean(LiteratureTitle, SurveyName, tagName);
                    frmInfoLiteratureSurveyTagBoolean.RefreshDgv += new frmInfoLiteratureSurveyTagBoolean.RefreshDgvHandler(LoadDgv);
                    frmInfoLiteratureSurveyTagBoolean.Show();
                }

            }
        }
    }
}
