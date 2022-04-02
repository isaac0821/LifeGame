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
    public partial class frmAddSurveyTag : Form
    {
        public frmAddSurveyTag(string UpperSurveyTagName, string SurveyName)
        {
            UpperSurveyTag = UpperSurveyTagName;            
            InitializeComponent();
            lblSurveyName.Text = SurveyName;
        }

        private string UpperSurveyTag;
        private List<string> lstOption;

        private void frmAddSurveyTag_Load(object sender, EventArgs e)
        {
            lstOption = new List<string>();
            cmbTagType.SelectedIndex = 0;
        }

        public delegate void DrawLogHandler(string SurveyTagName);
        public event DrawLogHandler AddChildNode;

        private void cmbTagType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTagType.SelectedItem.ToString() == "NonBottom")
            {
                chkIsBottom.Checked = false;
            }
            else
            {
                chkIsBottom.Checked = true;
            }
            if (cmbTagType.SelectedItem.ToString() != "SingleOption")
            {
                lsbOption.Enabled = false;
                lsbOption.Items.Clear();
            }
            else
            {
                lsbOption.Enabled = true;
                lsbOption.Items.Clear();
                foreach (string item in lstOption)
                {
                    lsbOption.Items.Add(item);
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strTagOption = Interaction.InputBox("Add survey tag option", "Add survey tag option", "", 300, 300);
            if (lstOption.Exists(o => o == strTagOption))
            {
                MessageBox.Show("Tag option exists!");
            }
            else
            {
                lsbOption.Items.Add(strTagOption);
                lstOption.Add(strTagOption);
            }
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsbOption.SelectedItem != null)
            {
                lstOption.Remove(lsbOption.SelectedItem.ToString());
                lsbOption.Items.Clear();
                foreach (string item in lstOption)
                {
                    lsbOption.Items.Add(item);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (G.glb.lstSurveyTag.Exists(o => o.SurveyTitle == lblSurveyName.Text && o.Tag == txtTagName.Text))
            {
                MessageBox.Show("Survey tag exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbTagType.Text == "SingleOption" && lsbOption.Items.Count == 0) 
            {
                MessageBox.Show("Please provide options", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Add survey tag
                RSurveyTag newSurveyTag = new RSurveyTag();
                newSurveyTag.SurveyTitle = lblSurveyName.Text;
                newSurveyTag.Tag = txtTagName.Text;
                newSurveyTag.TagType = (ESurveyTagType)(cmbTagType.SelectedIndex);
                G.glb.lstSurveyTag.Add(newSurveyTag);
                // Add survey tag relation
                RSurveySubTag newSurveySubTag = new RSurveySubTag();
                newSurveySubTag.SurveyTitle = lblSurveyName.Text;
                newSurveySubTag.Tag = UpperSurveyTag;
                newSurveySubTag.SubTag = txtTagName.Text;
                int maxIndex;
                if (G.glb.lstSurveySubTag.Exists(o => o.Tag == UpperSurveyTag))
                {
                    List<RSurveySubTag> sameLevel = G.glb.lstSurveySubTag.FindAll(o => o.Tag == UpperSurveyTag).ToList();
                    sameLevel = sameLevel.OrderByDescending(o => o.SubTagIndex).ToList();
                    maxIndex = sameLevel[0].SubTagIndex + 1;
                }
                else
                {
                    maxIndex = 0;
                }
                newSurveySubTag.SubTagIndex = maxIndex;
                G.glb.lstSurveySubTag.Add(newSurveySubTag);
                // Add survey tag options
                if (cmbTagType.Text == "SingleOption" && lstOption.Count > 0)
                {
                    foreach (string item in lstOption)
                    {
                        RSurveyTagValueOption newSurveyTagValueOption = new RSurveyTagValueOption();
                        newSurveyTagValueOption.SurveyTitle = lblSurveyName.Text;
                        newSurveyTagValueOption.Tag = txtTagName.Text;
                        newSurveyTagValueOption.TagOption = item;
                        G.glb.lstSurveyTagValueOption.Add(newSurveyTagValueOption);
                    }
                }
                AddChildNode(txtTagName.Text);
                Dispose();
            }
        }
    }
}
