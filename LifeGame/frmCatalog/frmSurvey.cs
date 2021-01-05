using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace LifeGame
{
    public partial class frmSurvey : Form
    {
        string Survey = "";
        public frmSurvey()
        {
            InitializeComponent();
        }

        private void frmSurvey_Load(object sender, EventArgs e)
        {
            foreach (CSurvey survey in G.glb.lstSurvey)
            {
                lsbSurvey.Items.Add(survey.SurveyTitle);
            }
        }

        private void LoadSurvey()
        {
            Survey = "";
            lblSurvey.Text = "(Survey Name)";
            trvSurveyTag.Nodes.Clear();
            trvSurveyTag.Nodes.Add("(Root)");
        }

        private void LoadSurvey(string tmpSurvey)
        {
            Survey = tmpSurvey;
            List<RSurveyLiteratureTagValue> lstLitTagValue = G.glb.lstSurveyLiteratureTagValue.FindAll(o => o.SurveyTitle == Survey).ToList();
            List<string> lstLits = new List<string>();
            foreach (RSurveyLiteratureTagValue litTagValue in lstLitTagValue)
            {
                if (!lstLits.Exists(o => o == litTagValue.LiteratureTitle))
                {
                    lstLits.Add(litTagValue.LiteratureTitle);
                }
            }
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
            if (G.glb.lstSurveySubTag.Exists(o => o.SurveyTitle == Survey && o.Tag == treeNode.Text))
            {
                List<RSurveySubTag> subTags = G.glb.lstSurveySubTag.FindAll(o => o.SurveyTitle == Survey && o.Tag == treeNode.Text);
                subTags = subTags.OrderBy(o => o.index).ToList();
                foreach (RSurveySubTag subTag in subTags)
                {
                    TreeNode childNode = new TreeNode(subTag.SubTag);                    
                    childNode.Name = subTag.SubTag;
                    childNode.ImageIndex = (int)G.glb.lstSurveyTag.Find(o => o.SurveyTitle == Survey && o.Tag == subTag.SubTag).TagType;
                    childNode.Checked = true;
                    LoadChildTagNode(childNode);
                    treeNode.Nodes.Add(childNode);
                }
            }
        }

        private void addSurveyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string surveyTitle = Interaction.InputBox("Create new survey", "New Survey", "New Survey", 300, 300);
            if (!G.glb.lstSurvey.Exists(o => o.SurveyTitle == surveyTitle))
            {
                CSurvey survey = new CSurvey();
                survey.SurveyTitle = surveyTitle;
                G.glb.lstSurvey.Add(survey);
                lsbSurvey.Items.Clear();
                foreach (CSurvey sur in G.glb.lstSurvey)
                {
                    lsbSurvey.Items.Add(sur.SurveyTitle);
                }
                LoadSurvey();
            }
            else
            {
                MessageBox.Show("Survey exists!");
            }
        }

        private void editRenameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lsbSurvey.SelectedItem != null)
            {
                string oldSurvey = lsbSurvey.SelectedItem.ToString();
                string newSurvey = Interaction.InputBox("Rename Survey", "Rename Survey", oldSurvey, 300, 300);
                if (G.glb.lstSurvey.Exists(o => o.SurveyTitle == newSurvey))
                {
                    MessageBox.Show("Survey exists!");
                }
                else
                {
                    foreach (CSurvey survey in G.glb.lstSurvey.FindAll(o => o.SurveyTitle == oldSurvey))
                    {
                        survey.SurveyTitle = newSurvey;
                    }
                    foreach (RSurveyTag surveyTag in G.glb.lstSurveyTag.FindAll(o => o.SurveyTitle == oldSurvey))
                    {
                        surveyTag.SurveyTitle = newSurvey;
                    }
                    foreach (RSurveyLiteratureTagValue surveyLit in G.glb.lstSurveyLiteratureTagValue.FindAll(o=>o.SurveyTitle==oldSurvey))
                    {
                        surveyLit.SurveyTitle = newSurvey;
                    }
                    foreach (RSurveySubTag surveySubTag in G.glb.lstSurveySubTag.FindAll(o=>o.SurveyTitle==oldSurvey))
                    {
                        surveySubTag.SurveyTitle = newSurvey;
                    }
                    foreach (RSurveyTagValueOption surveyTagValueOption in G.glb.lstSurveyTagValueOption.FindAll(o=>o.SurveyTitle==oldSurvey))
                    {
                        surveyTagValueOption.SurveyTitle = newSurvey;
                    }

                    lsbSurvey.Items.Clear();
                    foreach (CSurvey sur in G.glb.lstSurvey)
                    {
                        lsbSurvey.Items.Add(sur.SurveyTitle);
                    }
                    LoadSurvey();
                }
            }
        }

        private void deleteSurveyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsbSurvey.SelectedItem != null)
            {
                string selectedSurvey = lsbSurvey.SelectedItem.ToString();
                DialogResult result = MessageBox.Show("Warning: Survey that has been deleted cannot be restored!", "Delete", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        G.glb.lstSurvey.RemoveAll(o => o.SurveyTitle == selectedSurvey);
                        G.glb.lstSurveyTag.RemoveAll(o => o.SurveyTitle == selectedSurvey);
                        G.glb.lstSurveyTagValueOption.RemoveAll(o => o.SurveyTitle == selectedSurvey);
                        G.glb.lstSurveySubTag.RemoveAll(o => o.SurveyTitle == selectedSurvey);
                        G.glb.lstSurveyLiteratureTagValue.RemoveAll(o => o.SurveyTitle == selectedSurvey);
                        lsbSurvey.Items.Clear();
                        foreach (CSurvey sur in G.glb.lstSurvey)
                        {
                            lsbSurvey.Items.Add(sur.SurveyTitle);
                        }
                        LoadSurvey();
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
        }

        private void nonBottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvSurveyTag.SelectedNode != null)
            {
                string tagName = Interaction.InputBox("Tag name", "Add Tag", "Tag Name", 300, 300);
            }
        }

        private void booleanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void singleOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stringToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void integerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
