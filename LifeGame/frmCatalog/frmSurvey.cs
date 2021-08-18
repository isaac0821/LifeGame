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
            LoadTrvTag();
        }

        // 初始化Tag Tree
        private void LoadTrvTag()
        {
            trvSurveyTag.Nodes.Clear();
            TreeNode rootNode = new TreeNode("(Root)", 0, 0);
            rootNode.Name = "(Root)";
            rootNode.ImageIndex = 0;
            LoadTagInfo();
        }

        // 已知Survey的Title，初始化Tag Tree
        private void LoadTrvTag(string tmpSurveyTitle)
        {
            trvSurveyTag.Nodes.Clear();
            TreeNode rootNode = new TreeNode("(Root)", 0, 0);
            rootNode.Name = "(Root)";
            rootNode.ImageIndex = 0;
            LoadChildTagNode(tmpSurveyTitle, rootNode);
            trvSurveyTag.Nodes.Add(rootNode);
            LoadTagInfo();
        }
        private void LoadChildTagNode(string SurveyTitle, TreeNode treeNode)
        {
            if (G.glb.lstSurveySubTag.Exists(o => o.SurveyTitle == SurveyTitle && o.Tag == treeNode.Text))
            {
                List<RSurveySubTag> subTags = G.glb.lstSurveySubTag.FindAll(o => o.SurveyTitle == SurveyTitle && o.Tag == treeNode.Text);
                subTags = subTags.OrderBy(o => o.SubTagIndex).ToList();
                foreach (RSurveySubTag subTag in subTags)
                {
                    TreeNode childNode = new TreeNode(subTag.SubTag);
                    childNode.Name = subTag.SubTag;
                    childNode.ImageIndex = 1 + (int)G.glb.lstSurveyTag.Find(o => o.SurveyTitle == SurveyTitle && o.Tag == subTag.SubTag).TagType;
                    LoadChildTagNode(SurveyTitle, childNode);
                    treeNode.Nodes.Add(childNode);
                }
            }
        }

        private void cmsAddSurvey_Click(object sender, EventArgs e)
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
            }
            else
            {
                MessageBox.Show("Survey exists!");
            }
            LoadTrvTag();
        }

        private void cmsEditSurvey_Click(object sender, EventArgs e)
        {
            if (lsbSurvey.SelectedItem != null)
            {
                string oldSurveyTitle = lsbSurvey.SelectedItem.ToString();
                string newSurveyTitle = Interaction.InputBox("Rename Survey", "Rename Survey", oldSurveyTitle, 300, 300);
                if (G.glb.lstSurvey.Exists(o => o.SurveyTitle == newSurveyTitle))
                {
                    MessageBox.Show("Survey exists!");
                }
                else
                {
                    // 把Survey相关的表的SurveyTitle全部替换一遍
                    foreach (CSurvey survey in G.glb.lstSurvey.FindAll(o => o.SurveyTitle == oldSurveyTitle))
                    {
                        survey.SurveyTitle = newSurveyTitle;
                    }
                    foreach (RSurveyTag surveyTag in G.glb.lstSurveyTag.FindAll(o => o.SurveyTitle == oldSurveyTitle))
                    {
                        surveyTag.SurveyTitle = newSurveyTitle;
                    }
                    foreach (RSurveyLiteratureTagValue surveyLit in G.glb.lstSurveyLiteratureTagValue.FindAll(o => o.SurveyTitle == oldSurveyTitle))
                    {
                        surveyLit.SurveyTitle = newSurveyTitle;
                    }
                    foreach (RSurveySubTag surveySubTag in G.glb.lstSurveySubTag.FindAll(o => o.SurveyTitle == oldSurveyTitle))
                    {
                        surveySubTag.SurveyTitle = newSurveyTitle;
                    }
                    foreach (RSurveyTagValueOption surveyTagValueOption in G.glb.lstSurveyTagValueOption.FindAll(o => o.SurveyTitle == oldSurveyTitle))
                    {
                        surveyTagValueOption.SurveyTitle = newSurveyTitle;
                    }

                    lsbSurvey.Items.Clear();
                    foreach (CSurvey sur in G.glb.lstSurvey)
                    {
                        lsbSurvey.Items.Add(sur.SurveyTitle);
                    }
                }
                LoadTrvTag(newSurveyTitle);
            }
        }

        private void cmsRemoveSurvey_Click(object sender, EventArgs e)
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
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
                LoadTrvTag();
            }
        }

        private void lsbSurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbSurvey.SelectedItem != null)
            {
                lblSurvey.Text = lsbSurvey.SelectedItem.ToString();
                LoadTrvTag(lsbSurvey.SelectedItem.ToString());
            }
            else
            {
                LoadTrvTag();
            }
        }

        private void cmsAddTag_Click(object sender, EventArgs e)
        {
            if (trvSurveyTag.SelectedNode != null)
            {
                string tagName = Interaction.InputBox("Create new tag", "New Tag", "New Tag", 300, 300);
                if (!G.glb.lstSurveyTag.Exists(o =>
                    o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                    && o.Tag == tagName))
                {
                    // 添加Survey的新Tag
                    RSurveyTag surveyTag = new RSurveyTag();
                    surveyTag.SurveyTitle = lsbSurvey.SelectedItem.ToString();
                    surveyTag.Tag = tagName;
                    surveyTag.TagType = ESurveyTagType.NonBottom;
                    G.glb.lstSurveyTag.Add(surveyTag);
                    // 添加新Tag的隶属关系
                    RSurveySubTag surveySubTag = new RSurveySubTag();
                    surveySubTag.SurveyTitle = lsbSurvey.SelectedItem.ToString();
                    surveySubTag.Tag = trvSurveyTag.SelectedNode.Text;
                    surveySubTag.SubTag = tagName;
                    surveySubTag.SubTagIndex = trvSurveyTag.SelectedNode.Nodes.Count;
                    G.glb.lstSurveySubTag.Add(surveySubTag);
                    trvSurveyTag.SelectedNode.Nodes.Add(tagName, tagName, 1);
                    LoadTagInfo(lsbSurvey.SelectedItem.ToString(), tagName);
                }
                else
                {
                    MessageBox.Show("Tag exists");
                }
            }       
        }
        private void cmsEditTag_Click(object sender, EventArgs e)
        {
            if (trvSurveyTag.SelectedNode != null && trvSurveyTag.SelectedNode.Text != "(Root)")
            {
                string oldTagName = lblTagName.Text;
                string newTagName = Interaction.InputBox("Create new tag", "New Tag", "New Tag", 300, 300);
                if (!G.glb.lstSurveyTag.Exists(o =>
                    o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                    && o.Tag == newTagName))
                {
                    foreach (RSurveyTag surveyTag in G.glb.lstSurveyTag.FindAll(o =>
                        o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                        && o.Tag == oldTagName))
                    {
                        surveyTag.Tag = newTagName;
                    }
                    foreach (RSurveyLiteratureTagValue surveyLit in G.glb.lstSurveyLiteratureTagValue.FindAll(o =>
                        o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                        && o.Tag == oldTagName))
                    {
                        surveyLit.Tag = newTagName;
                    }
                    foreach (RSurveySubTag surveySubTag in G.glb.lstSurveySubTag.FindAll(o =>
                        o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                        && o.Tag == oldTagName))
                    {
                        surveySubTag.Tag = newTagName;
                    }
                    foreach (RSurveySubTag surveySubTag in G.glb.lstSurveySubTag.FindAll(o =>
                        o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                        && o.SubTag == oldTagName))
                    {
                        surveySubTag.SubTag = newTagName;
                    }
                    foreach (RSurveyTagValueOption surveyTagValueOption in G.glb.lstSurveyTagValueOption.FindAll(o =>
                        o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                        && o.Tag == oldTagName))
                    {
                        surveyTagValueOption.Tag = newTagName;
                    }
                    trvSurveyTag.SelectedNode.Text = newTagName;
                    LoadTagInfo(lsbSurvey.SelectedItem.ToString(), newTagName);
                }
                else
                {
                    MessageBox.Show("Tag exists");
                }
            }
        }
        private void cmsTagRemove_Click(object sender, EventArgs e)
        {
            if (trvSurveyTag.SelectedNode != null && trvSurveyTag.SelectedNode.Nodes.Count == 0)
            {
                string selectedSurvey = lsbSurvey.SelectedItem.ToString();
                string selectedSurveyTag = trvSurveyTag.SelectedNode.Text;
                DialogResult result = MessageBox.Show("Warning: Survey tag that has been deleted cannot be restored!", "Delete", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        G.glb.lstSurveyTag.RemoveAll(o => o.SurveyTitle == selectedSurvey && o.Tag == selectedSurveyTag);
                        G.glb.lstSurveyTagValueOption.RemoveAll(o => o.SurveyTitle == selectedSurvey && o.Tag == selectedSurveyTag);
                        G.glb.lstSurveySubTag.RemoveAll(o => o.SurveyTitle == selectedSurvey && o.Tag == selectedSurveyTag);
                        G.glb.lstSurveySubTag.RemoveAll(o => o.SurveyTitle == selectedSurvey && o.SubTag == selectedSurveyTag);
                        G.glb.lstSurveyLiteratureTagValue.RemoveAll(o => o.SurveyTitle == selectedSurvey && o.Tag == selectedSurveyTag);
                        TreeNode parent = trvSurveyTag.SelectedNode.Parent;
                        trvSurveyTag.SelectedNode.Remove();
                        for (int i = 0; i < parent.Nodes.Count; i++)
                        {
                            G.glb.lstSurveySubTag.Find(o =>
                                o.SurveyTitle == selectedSurvey
                                && o.Tag == parent.Text
                                && o.SubTag == parent.Nodes[i].Text).SubTagIndex = i;                              
                        }                        
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
                LoadTrvTag(lsbSurvey.SelectedItem.ToString());
            }
        }

        private void cmsTagUp_Click(object sender, EventArgs e)
        {

        }

        private void cmsTagDown_Click(object sender, EventArgs e)
        {

        }

        private void cmsTagBelongTo_Click(object sender, EventArgs e)
        {

        }

        private void cmsTagIndependent_Click(object sender, EventArgs e)
        {

        }

        private void trvSurveyTag_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvSurveyTag.SelectedNode != null && trvSurveyTag.SelectedNode.Text != "(Root)")
            {
                LoadTagInfo(lsbSurvey.SelectedItem.ToString(), trvSurveyTag.SelectedNode.Text);
            }
            else
            {
                LoadTagInfo();
            }
        }

        private void LoadTagInfo()
        {
            lblTagName.Text = "";
            cmbTagType.Text = "";
            chkBottom.Checked = false;
            lsbOption.Items.Clear();
        }

        private void LoadTagInfo(string SurveyTitle, string SurveyTag)
        {
            lblTagName.Text = SurveyTag;
            lsbOption.Items.Clear();
            if (G.glb.lstSurveyTag.Find(o =>
                o.Tag == SurveyTag
                && o.SurveyTitle == SurveyTitle).TagType == ESurveyTagType.SingleOption)
            {
                lsbOption.Enabled = true;
                List<RSurveyTagValueOption> lstRSurveyTagValueOption = new List<RSurveyTagValueOption>();
                lstRSurveyTagValueOption = G.glb.lstSurveyTagValueOption.FindAll(o =>
                                    o.SurveyTitle == SurveyTitle &&
                                    o.Tag == SurveyTag);
                lstRSurveyTagValueOption = lstRSurveyTagValueOption.OrderBy(o => o.TagOptionIndex).ToList();
                foreach (RSurveyTagValueOption option in lstRSurveyTagValueOption)
                {
                    lsbOption.Items.Add(option.TagOption);
                }
            }
        }

        // 初始化表格
        private void LoadSurveyLits()
        {
            dgvSurvey.DataSource = null;
        }


        List<string> shownTags = new List<string>();
        List<string> shownLits = new List<string>();
        private void LoadSurveyLits(string SurveyTitle)
        {
            dgvSurvey.Columns.Add("Literature", "Literature");
            dgvSurvey.Columns[0].ReadOnly = true;
            foreach (string tag in shownTags)
            {
                dgvSurvey.Columns.Add(tag, tag);
            }
            foreach (string lit in shownLits)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell title = new DataGridViewTextBoxCell();
                title.Value = lit;
                row.Cells.Add(title);
                foreach (string tag in shownTags)
                {

                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    cell.Value = G.glb.lstSurveyLiteratureTagValue.Find(o =>
                        o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                        && o.Tag == tag
                        && o.LiteratureTitle == lit).TagValueString;
                    row.Cells.Add(cell);                    
                }
                dgvSurvey.Rows.Add(row);
            }
        }

        private void UpdateShownTags()
        {
            shownTags.Clear();
            GetCheckedBottomTag(trvSurveyTag.Nodes[0]);
        }

        private void GetCheckedBottomTag(TreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                if (node.Checked)
                {
                    shownTags.Add(node.Text);
                }
            }
            else
            {
                foreach (TreeNode child in node.Nodes)
                {
                    GetCheckedBottomTag(child);
                }
            }
        }

        private void UpdateShownLits()
        {
            shownLits.Clear();
            foreach (RSurveyLiteratureTagValue log in G.glb.lstSurveyLiteratureTagValue.FindAll(o => o.SurveyTitle == lsbSurvey.SelectedItem.ToString()))
            {
                if (!shownLits.Exists(o => o == log.LiteratureTitle))
                {

                }
            }
        }

        private void dgvSurvey_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSurvey.CurrentCell != null)
            {
                // Type control
                bool isGo = true;
                string lit = dgvSurvey.Rows[dgvSurvey.CurrentCell.RowIndex].Cells[0].Value.ToString();
                string tag = dgvSurvey.Columns[dgvSurvey.CurrentCell.ColumnIndex].HeaderText;
                string oriContent = G.glb.lstSurveyLiteratureTagValue.Find(o =>
                       o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                       && o.LiteratureTitle == lit
                       && o.Tag == tag).TagValueString;
                ESurveyTagType type = G.glb.lstSurveyTag.Find(o => 
                    o.SurveyTitle == lsbSurvey.SelectedItem.ToString() 
                    && o.Tag == tag).TagType;

                if (isGo)
                {
                    G.glb.lstSurveyLiteratureTagValue.Find(o =>
                       o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                       && o.LiteratureTitle == lit
                       && o.Tag == tag).TagValueString = dgvSurvey.SelectedCells.ToString();
                }
                else
                {
                    dgvSurvey.CurrentCell.Value = oriContent;
                }
            }
        }
    }
}
