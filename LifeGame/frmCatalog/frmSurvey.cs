﻿using System;
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
            trvSurveyTag.Nodes.Add(rootNode);
            LoadChildTagNode(tmpSurveyTitle, rootNode);            
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
                    childNode.SelectedImageIndex = 1 + (int)(G.glb.lstSurveyTag.Find(o => o.SurveyTitle == SurveyTitle && o.Tag == subTag.SubTag).TagType);
                    childNode.ImageIndex = 1 + (int)(G.glb.lstSurveyTag.Find(o => o.SurveyTitle == SurveyTitle && o.Tag == subTag.SubTag).TagType);
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
                LoadSurveyLits(lsbSurvey.SelectedItem.ToString());
            }
            else
            {
                LoadTrvTag();
                dgvSurvey.DataSource = null;
            }
        }

        private void cmsAddTag_Click(object sender, EventArgs e)
        {
            if (trvSurveyTag.SelectedNode != null)
            {
                if (!G.glb.lstSurveyTag.Exists(o => o.SurveyTitle == lblSurvey.Text && o.Tag == trvSurveyTag.SelectedNode.Text) && trvSurveyTag.SelectedNode.Text != "(Root)")
                {
                    MessageBox.Show("Cannot find the survey tag.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if(trvSurveyTag.SelectedNode.Text == "(Root)")
                    {
                        TreeNode node = trvSurveyTag.SelectedNode;
                        frmAddSurveyTag frmAddSurveyTag = new frmAddSurveyTag(trvSurveyTag.SelectedNode.Text, lblSurvey.Text);
                        frmAddSurveyTag.AddChildNode += new frmAddSurveyTag.DrawLogHandler(AddChildNode);
                        frmAddSurveyTag.Show();
                    }
                    else
                    {
                        if (G.glb.lstSurveyTag.Find(o => 
                            o.SurveyTitle == lblSurvey.Text 
                            && o.Tag == trvSurveyTag.SelectedNode.Text).TagType != ESurveyTagType.NonBottom)
                        {
                            MessageBox.Show("This survey tag is unextendable.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            TreeNode node = trvSurveyTag.SelectedNode;
                            frmAddSurveyTag frmAddSurveyTag = new frmAddSurveyTag(trvSurveyTag.SelectedNode.Text, lblSurvey.Text);
                            frmAddSurveyTag.AddChildNode += new frmAddSurveyTag.DrawLogHandler(AddChildNode);
                            frmAddSurveyTag.Show();
                        }
                    }
                }
            }       
        }

        private void AddChildNode(string nodeName)
        {
            if (trvSurveyTag.SelectedNode != null)
            {
                TreeNode node = trvSurveyTag.SelectedNode;
                TreeNode newNode = new TreeNode(nodeName, 1, 1);
                newNode.Name = nodeName;
                newNode.SelectedImageIndex = 1 + (int)G.glb.lstSurveyTag.Find(o => o.SurveyTitle == lblSurvey.Text && o.Tag == nodeName).TagType;
                newNode.ImageIndex = 1 + (int)G.glb.lstSurveyTag.Find(o => o.SurveyTitle == lblSurvey.Text && o.Tag == nodeName).TagType;
                node.Nodes.Add(newNode);
            }
        }

        private void cmsEditTag_Click(object sender, EventArgs e)
        {
            if (trvSurveyTag.SelectedNode != null)
            {
                // Check if exists Survey

            }
        }
        private void cmsTagRemove_Click(object sender, EventArgs e)
        {
            if (trvSurveyTag.SelectedNode != null)
            {
                // Check if exists Survey

            }
        }

        private void cmsTagUp_Click(object sender, EventArgs e)
        {
            if (trvSurveyTag.SelectedNode != null)
            {
                if (trvSurveyTag.SelectedNode.Text != "(Root)")
                {
                    string UpperTag = trvSurveyTag.SelectedNode.Parent.Text;
                    TreeNode node = trvSurveyTag.SelectedNode;
                    TreeNode preNode = node.PrevNode;
                    if (preNode != null)
                    {
                        TreeNode newNode = (TreeNode)node.Clone();
                        if (node.Parent == null)
                        {
                            trvSurveyTag.Nodes.Insert(preNode.Index, newNode);
                        }
                        else
                        {
                            node.Parent.Nodes.Insert(preNode.Index, newNode);
                        }
                        node.Remove();
                        trvSurveyTag.SelectedNode = newNode;
                        ReIndex(UpperTag);
                    }
                }
            }
        }

        private void cmsTagDown_Click(object sender, EventArgs e)
        {
            if (trvSurveyTag.SelectedNode != null)
            {
                if (trvSurveyTag.SelectedNode.Text != "(Root)")
                {
                    string UpperTag = trvSurveyTag.SelectedNode.Parent.Text;
                    TreeNode node = trvSurveyTag.SelectedNode;
                    TreeNode nextNode = node.NextNode;
                    if (nextNode != null)
                    {
                        TreeNode newNode = (TreeNode)node.Clone();
                        if (node.Parent == null)
                        {
                            trvSurveyTag.Nodes.Insert(nextNode.Index + 1, newNode);
                        }
                        else
                        {
                            node.Parent.Nodes.Insert(nextNode.Index + 1, newNode);
                        }
                        node.Remove();
                        trvSurveyTag.SelectedNode = newNode;
                        ReIndex(UpperTag);
                    }
                }
            }
        }

        private void cmsTagBelongTo_Click(object sender, EventArgs e)
        {
            if (trvSurveyTag.SelectedNode != null)
            {
                TreeNode node = trvSurveyTag.SelectedNode;
                TreeNode preNode = node.PrevNode;
                TreeNode parentNode = node.Parent;
                TreeNode newNode = (TreeNode)node.Clone();
                if (node.Parent != null && node.PrevNode != null)
                {
                    string preNodeName = preNode.Text;
                    string parentNodeName = parentNode.Text;
                    G.glb.lstSurveySubTag.RemoveAll(o => o.Tag == parentNode.Text && o.SubTag == node.Text);
                    RSurveySubTag newSub = new RSurveySubTag();
                    newSub.SurveyTitle = lsbSurvey.SelectedItem.ToString();
                    newSub.Tag = preNode.Text;
                    newSub.SubTag = node.Text;
                    newSub.SubTagIndex = preNode.Nodes.Count;
                    G.glb.lstSurveySubTag.Add(newSub);
                    preNode.Nodes.Insert(preNode.Nodes.Count, newNode);
                    node.Remove();
                    trvSurveyTag.SelectedNode = newNode;
                    ReIndex(parentNodeName);
                    ReIndex(preNodeName);
                }
            }
        }

        private void cmsTagIndependent_Click(object sender, EventArgs e)
        {
            if (trvSurveyTag.SelectedNode != null)
            {
                TreeNode node = trvSurveyTag.SelectedNode;
                TreeNode parentNode = node.Parent;
                TreeNode grandparentNode = node.Parent.Parent;
                TreeNode newNode = (TreeNode)node.Clone();
                if (node.Parent != null && node.Parent.Parent != null)
                {
                    string parentNodeName = parentNode.Text;
                    string grandparentNodeName = grandparentNode.Text;
                    G.glb.lstSurveySubTag.RemoveAll(o => o.Tag == parentNode.Text && o.SubTag == node.Text);
                    RSurveySubTag newSub = new RSurveySubTag();
                    newSub.SurveyTitle = lsbSurvey.SelectedItem.ToString();
                    newSub.Tag = grandparentNode.Text;
                    newSub.SubTag = node.Text;
                    newSub.SubTagIndex = grandparentNode.Nodes.Count;
                    G.glb.lstSurveySubTag.Add(newSub);
                    grandparentNode.Nodes.Insert(parentNode.Index + 1, newNode);
                    node.Remove();
                    trvSurveyTag.SelectedNode = newNode;
                    ReIndex(grandparentNodeName);
                    ReIndex(parentNodeName);
                }
            }
        }
        private void ReIndex(string UpperTask)
        {
            List<RSurveySubTag> sameLevel = G.glb.lstSurveySubTag.FindAll(o => o.Tag == UpperTask);
            foreach (RSurveySubTag subTag in sameLevel)
            {
                G.glb.lstSurveySubTag.Find(o => o.Tag == UpperTask && o.SubTag == subTag.SubTag).SubTagIndex = trvSurveyTag.Nodes.Find(subTag.SubTag, true).FirstOrDefault().Index;
            }
        }
        private void trvSurveyTag_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvSurveyTag.SelectedNode != null)
            {
                if (trvSurveyTag.SelectedNode.Text == "(Root)")
                {
                    LoadTagInfo();
                    tsmAddTag.Enabled = true;
                    tsmEditTag.Enabled = false;
                    tsmRemoveTag.Enabled = false;
                    tsmUpTag.Enabled = false;
                    tsmDownTag.Enabled = false;
                    tsmBelongToTag.Enabled = false;
                    tsmIndependentTag.Enabled = false;
                }
                else
                {
                    LoadTagInfo(lsbSurvey.SelectedItem.ToString(), trvSurveyTag.SelectedNode.Text);
                    tsmEditTag.Enabled = true;
                    tsmRemoveTag.Enabled = true;
                    tsmUpTag.Enabled = true;
                    tsmDownTag.Enabled = true;
                    tsmIndependentTag.Enabled = true;
                    if (G.glb.lstSurveyTag.Find(o => 
                        o.SurveyTitle == lsbSurvey.SelectedItem.ToString() 
                        && o.Tag == trvSurveyTag.SelectedNode.Text).TagType == ESurveyTagType.NonBottom)
                    {
                        tsmAddTag.Enabled = true;
                    }
                    else
                    {
                        tsmAddTag.Enabled = false;
                    }
                    if (trvSurveyTag.SelectedNode.PrevNode != null)
                    {
                        if (G.glb.lstSurveyTag.Find(o =>
                            o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                            && o.Tag == trvSurveyTag.SelectedNode.PrevNode.Text).TagType == ESurveyTagType.NonBottom)
                        {
                            tsmBelongToTag.Enabled = true;
                        }
                        else
                        {
                            tsmBelongToTag.Enabled = false;
                        }
                    }
                }
            }
        }

        private void LoadTagInfo()
        {
            lblTagName.Text = "";
            lblTagType.Text = "";
            lsbOption.Items.Clear();
        }

        private void LoadTagInfo(string SurveyTitle, string SurveyTag)
        {
            lblTagName.Text = SurveyTag;
            lblTagType.Text = G.glb.lstSurveyTag.Find(o =>
                o.Tag == SurveyTag
                && o.SurveyTitle == SurveyTitle).TagType.ToString();
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
                foreach (RSurveyTagValueOption option in lstRSurveyTagValueOption)
                {
                    lsbOption.Items.Add(option.TagOption);
                }
            }
        }
        
        private List<string> lstBottomTag = new List<string>();
        private void FindChildTag(string Tag)
        {
            List<RSurveySubTag> tags = G.glb.lstSurveySubTag.FindAll(o =>
                o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                && o.Tag == Tag).ToList();
            tags.OrderBy(o => o.SubTagIndex);
            foreach (RSurveySubTag item in tags)
            {
                if (G.glb.lstSurveyTag.Find(o =>
                    o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
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
        private void LoadSurveyLits(string SurveyTitle)
        {
            lstBottomTag = new List<string>();
            FindChildTag("(Root)");

            dgvSurvey.Rows.Clear();
            dgvSurvey.ColumnCount = 1 + lstBottomTag.Count;
            dgvSurvey.Columns[0].Name = "Literature";
            for (int i = 0; i < lstBottomTag.Count; i++)
            {
                dgvSurvey.Columns[i + 1].Name = lstBottomTag[i];
            }

            foreach (RSurveyLiterature surveyLiterature in G.glb.lstSurveyLiterature.FindAll(o =>
                o.SurveyTitle == SurveyTitle).ToList())
            {
                DataGridViewRow row = new DataGridViewRow();
                for (int i = 0; i < lstBottomTag.Count + 1; i++)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell());
                }
                row.Cells[0].Value = surveyLiterature.LiteratureTitle;
                for (int i = 0; i < lstBottomTag.Count; i++)
                {
                    if (!G.glb.lstSurveyLiteratureTagValue.Exists(o =>
                        o.LiteratureTitle == surveyLiterature.LiteratureTitle
                        && o.SurveyTitle == SurveyTitle
                        && o.Tag == lstBottomTag[i]))
                    {
                        row.Cells[i + 1].Value = "(null)";
                    }
                    else
                    {
                        string cellValue = "";
                        if (G.glb.lstSurveyTag.Find(o => 
                            o.SurveyTitle == SurveyTitle
                            && o.Tag == lstBottomTag[i]).TagType == ESurveyTagType.Boolean)
                        {
                            cellValue = G.glb.lstSurveyLiteratureTagValue.Find(o =>
                                o.LiteratureTitle == surveyLiterature.LiteratureTitle
                                && o.SurveyTitle == SurveyTitle
                                && o.Tag == lstBottomTag[i]).TagValueBoolean.ToString();
                        }
                        else if (G.glb.lstSurveyTag.Find(o =>
                            o.SurveyTitle == SurveyTitle
                            && o.Tag == lstBottomTag[i]).TagType == ESurveyTagType.String)
                        {
                            cellValue = G.glb.lstSurveyLiteratureTagValue.Find(o =>
                                o.LiteratureTitle == surveyLiterature.LiteratureTitle
                                && o.SurveyTitle == SurveyTitle
                                && o.Tag == lstBottomTag[i]).TagValueString;
                        }
                        else if (G.glb.lstSurveyTag.Find(o =>
                           o.SurveyTitle == SurveyTitle
                           && o.Tag == lstBottomTag[i]).TagType == ESurveyTagType.SingleOption)
                        {
                            cellValue = G.glb.lstSurveyLiteratureTagValue.Find(o =>
                                o.LiteratureTitle == surveyLiterature.LiteratureTitle
                                && o.SurveyTitle == SurveyTitle
                                && o.Tag == lstBottomTag[i]).TagValueString;
                        }
                        else if (G.glb.lstSurveyTag.Find(o =>
                           o.SurveyTitle == SurveyTitle
                           && o.Tag == lstBottomTag[i]).TagType == ESurveyTagType.Number)
                        {
                            cellValue = G.glb.lstSurveyLiteratureTagValue.Find(o =>
                                o.LiteratureTitle == surveyLiterature.LiteratureTitle
                                && o.SurveyTitle == SurveyTitle
                                && o.Tag == lstBottomTag[i]).TagValueNumber.ToString();
                        }
                        row.Cells[i + 1].Value = cellValue;
                    }
                }
                dgvSurvey.Rows.Add(row);
            }
        }

        private void exportSurveyEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cmsAddLiterature_Click(object sender, EventArgs e)
        {

        }
    }
}
