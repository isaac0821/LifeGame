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
        bool SaveFlag = false;
        string LiteratureTitle = "";
        string SurveyTitle = "";

        List<RSurveyTag> lstTag = new List<RSurveyTag>();
        List<RSurveyTagValueOption> lstOptions = new List<RSurveyTagValueOption>();
        List<RSurveySubTag> lstSubTag = new List<RSurveySubTag>();

        List<RSurveyLiteratureTagValue> lstTagValue = new List<RSurveyLiteratureTagValue>();

        public frmInfoLiteratureSurvey(string tmpLiteratureTitle, string tmpSurveyTitle)
        {
            LiteratureTitle = tmpLiteratureTitle;
            SurveyTitle = tmpSurveyTitle;
            lstTag = G.glb.lstSurveyTag.FindAll(o => o.SurveyTitle == SurveyTitle);
            lstOptions = G.glb.lstSurveyTagValueOption.FindAll(o => o.SurveyTitle == SurveyTitle);
            lstSubTag = G.glb.lstSurveySubTag.FindAll(o => o.SurveyTitle == SurveyTitle);
            lstTagValue = G.glb.lstSurveyLiteratureTagValue.FindAll(
                o => o.SurveyTitle == SurveyTitle && o.LiteratureTitle == LiteratureTitle);
            InitializeComponent();
            LoadSurveyTags();
        }

        private void frmInfoLiteratureSurvey_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SaveFlag)
            {
                G.glb.lstSurveyLiteratureTagValue.RemoveAll(
                    o => o.SurveyTitle == SurveyTitle && o.LiteratureTitle == LiteratureTitle);
                foreach (RSurveyLiteratureTagValue tagValue in lstTagValue)
                {
                    G.glb.lstSurveyLiteratureTagValue.Add(tagValue);
                }
            }
        }

        private void LoadSurveyTags()
        {
            lblLiterature.Text = LiteratureTitle;
            lblSurvey.Text = SurveyTitle;
            lblBibTeX.Text = G.glb.lstLiterature.Find(o => o.Title == LiteratureTitle).BibKey;
            LoadTrvTag();
        }

        private void LoadTrvTag()
        {
            trvSurveyTag.Nodes.Clear();
            TreeNode rootNode = new TreeNode("(Root)", 0, 0);
            rootNode.Name = "(Root)";
            rootNode.ImageIndex = 0;
            LoadChildTagNode(rootNode);
            trvSurveyTag.Nodes.Add(rootNode);
        }

        private void LoadChildTagNode(TreeNode treeNode)
        {
            if (lstSubTag.Exists(o => o.Tag == treeNode.Text))
            {
                List<RSurveySubTag> subTags = lstSubTag.FindAll(o => o.Tag == treeNode.Text);
                subTags = subTags.OrderBy(o => o.index).ToList();
                foreach (RSurveySubTag subTag in subTags)
                {
                    TreeNode childNode = new TreeNode(subTag.SubTag);
                    childNode.Name = subTag.SubTag;
                    childNode.ImageIndex = (int)lstTag.Find(o => o.Tag == subTag.SubTag).TagType;
                    LoadChildTagNode(childNode);
                    treeNode.Nodes.Add(childNode);
                }
            }
        }

        private void trvSurveyTag_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvSurveyTag.SelectedNode != null)
            {
                RSurveyTag SelectedTag = new RSurveyTag();
                SelectedTag = lstTag.Find(o => o.Tag == trvSurveyTag.SelectedNode.Text);
                lblSurveyTagDescription.Text = SelectedTag.Description;
                List<RSurveyLiteratureTagValue> lstSelectedTagValue = new List<RSurveyLiteratureTagValue>();
                lstSelectedTagValue = lstTagValue.FindAll(o => o.Tag == trvSurveyTag.SelectedNode.Text);
                List<RSurveyTagValueOption> lstSelectedValueOptions = new List<RSurveyTagValueOption>();
                if (SelectedTag.TagType == ESurveyTagType.SingleOption)
                {
                    lstSelectedValueOptions = lstOptions.FindAll(o => o.Tag == trvSurveyTag.SelectedNode.Text);
                    lstSelectedValueOptions = lstSelectedValueOptions.OrderBy(o => o.TagOptionIndex).ToList();
                }
                pnlOptions.Controls.Clear();
                if (SelectedTag.IsBottom)
                {
                    ESurveyTagType TagType = SelectedTag.TagType;
                    switch (TagType)
                    {
                        case ESurveyTagType.Boolean:
                            CheckBox chkTagBoolean = new CheckBox();
                            chkTagBoolean.Text = SelectedTag.Tag;
                            chkTagBoolean.Checked = (bool)lstSelectedTagValue[0].TagValueBoolean;
                            chkTagBoolean.CheckedChanged += new EventHandler(chkTagBoolean_CheckedChanged);
                            pnlOptions.Controls.Add(chkTagBoolean);
                            break;
                        case ESurveyTagType.SingleOption:
                            for (int i = 0; i < lstSelectedValueOptions.Count; i++)
                            {
                                RadioButton rdoTagSingleOption = new RadioButton();
                                rdoTagSingleOption.Text = lstSelectedValueOptions[i].TagOption;
                                if (i == (int)lstSelectedTagValue[0].TagValueOptionIndex)
                                {
                                    rdoTagSingleOption.Checked = true;
                                }
                                else
                                {
                                    rdoTagSingleOption.Checked = false;
                                }
                                rdoTagSingleOption.CheckedChanged += new EventHandler(rdoTagSingleOption_CheckedChanged);
                                rdoTagSingleOption.Top = i * 25;
                                pnlOptions.Controls.Add(rdoTagSingleOption);
                            }
                            break;
                        case ESurveyTagType.String:
                            TextBox txtTagString = new TextBox();
                            txtTagString.Text = lstSelectedTagValue[0].TagValueString;
                            txtTagString.TextChanged += new EventHandler(txtTagString_TextChanged);
                            txtTagString.Dock = DockStyle.Fill;
                            txtTagString.Multiline = true;
                            pnlOptions.Controls.Add(txtTagString);
                            break;
                        case ESurveyTagType.Number:
                            TextBox txtTagInt = new TextBox();
                            txtTagInt.Text = lstSelectedTagValue[0].TagValueNumber.ToString();
                            txtTagInt.TextChanged += new EventHandler(txtTagString_TextChanged);
                            txtTagInt.Dock = DockStyle.Fill;
                            txtTagInt.Multiline = true;
                            pnlOptions.Controls.Add(txtTagInt);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void chkTagBoolean_CheckedChanged(object sender, EventArgs e)
        {
            SaveFlag = true;
            CheckBox Self = (CheckBox)sender;
            lstTagValue.Find(o => o.Tag == trvSurveyTag.SelectedNode.Text).TagValueBoolean = Self.Checked;
        }

        private void rdoTagSingleOption_CheckedChanged(object sender, EventArgs e)
        {
            SaveFlag = true;
            RadioButton Self = (RadioButton)sender;
            int OptionIndex = 0;
            List<RSurveyTagValueOption> lstSelectedValueOptions = new List<RSurveyTagValueOption>();
            lstSelectedValueOptions = lstOptions.FindAll(o => o.Tag == trvSurveyTag.SelectedNode.Text);
            for (int i = 0; i < lstSelectedValueOptions.Count; i++)
            {
                if (Self.Text == lstSelectedValueOptions[i].TagOption)
                {
                    OptionIndex = lstSelectedValueOptions[i].TagOptionIndex;
                }
            }
            lstTagValue.Find(o => o.Tag == trvSurveyTag.SelectedNode.Text).TagValueOptionIndex = OptionIndex;
        }

        private void chkTagMultipleOptions_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtTagString_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTagInt_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
