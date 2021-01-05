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
    public partial class frmAddSurveyTagPlain : Form
    {
        string Survey = "";
        bool EditMode = true;
        ESurveyTagType TagType = new ESurveyTagType();
        string OldTagName = "";
        string UpperTag = "";

        public frmAddSurveyTagPlain(string tmpSurvey, string tmpUpperTag, ESurveyTagType tmpTagType, bool tmpEditMode)
        {            
            Survey = tmpSurvey;
            UpperTag = tmpUpperTag;
            EditMode = tmpEditMode;
            if (EditMode)
            {
                OldTagName = txtTagName.Text;
            }
            TagType = tmpTagType;
            InitializeComponent();
        }

        public delegate void DrawLogHandler(string TagName, ESurveyTagType TagType);
        public event DrawLogHandler AddChildNode;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!EditMode)
            {
                if (G.glb.lstSurveyTag.Exists(o=>o.SurveyTitle == Survey && o.Tag == txtTagName.Text))
                {
                    MessageBox.Show("Tag exists in " + Survey, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    RSurveyTag newSurveyTag = new RSurveyTag();
                    newSurveyTag.SurveyTitle = Survey;
                    newSurveyTag.IsBottom = chkBottom.Checked;
                    newSurveyTag.TagType = TagType;
                    newSurveyTag.Tag = txtTagName.Text;
                    newSurveyTag.Description = txtDescription.Text;
                    G.glb.lstSurveyTag.Add(newSurveyTag);
                    RSurveySubTag newSurveySubTag = new RSurveySubTag();
                    int maxIndex;
                    if (G.glb.lstSurveySubTag.Exists(o => o.SurveyTitle == Survey && o.Tag == UpperTag))
                    {
                        List<RSurveySubTag> sameLevel = G.glb.lstSurveySubTag.FindAll(o => o.SurveyTitle == Survey && o.Tag == UpperTag).ToList();
                        sameLevel = sameLevel.OrderByDescending(o => o.index).ToList();
                        maxIndex = sameLevel[0].index + 1;
                    }
                    else
                    {
                        maxIndex = 0;
                    }
                    newSurveySubTag.Tag = UpperTag;
                    newSurveySubTag.SubTag = txtTagName.Text;
                    newSurveySubTag.index = maxIndex;
                    G.glb.lstSurveySubTag.Add(newSurveySubTag);
                    AddChildNode(txtTagName.Text, TagType);
                    Dispose();
                }
            }
            else
            {
                if (G.glb.lstSurveyTag.Exists(o => o.SurveyTitle == Survey && o.Tag == txtTagName.Text))
                {
                    MessageBox.Show("Tag exists in " + Survey, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Need to rename every tag
                    if (OldTagName == txtTagName.Text)
                    {
                        // Rename tag name
                        G.glb.lstSurveyTag.Find(o => o.SurveyTitle == Survey && o.Tag == OldTagName).Tag = txtTagName.Text;

                        // Rename tag name in subtags
                        List<RSurveySubTag> rSubTag = G.glb.lstSurveySubTag.FindAll(o => o.SurveyTitle == Survey && o.Tag == OldTagName);
                        foreach (RSurveySubTag subTag in rSubTag)
                        {
                            subTag.Tag = txtTagName.Text;
                        }
                        G.glb.lstSurveySubTag.Find(o => o.SurveyTitle == Survey && o.SubTag == OldTagName).SubTag = txtTagName.Text;

                        // Rename tag name in tag value
                        List<RSurveyTagValueOption> rTagOpt = G.glb.lstSurveyTagValueOption.FindAll(o => o.SurveyTitle == Survey && o.Tag == OldTagName);
                        foreach (RSurveyTagValueOption tagOpt in rTagOpt)
                        {
                            tagOpt.Tag = txtTagName.Text;
                        }

                        // Rename tag name in Literature
                        List<RSurveyLiteratureTagValue> rLitTag = G.glb.lstSurveyLiteratureTagValue.FindAll(o => o.SurveyTitle == Survey && o.Tag == OldTagName);
                        foreach (RSurveyLiteratureTagValue litTag in rLitTag)
                        {
                            litTag.Tag = txtTagName.Text;
                        }
                    }

                    // Now it has new name
                    G.glb.lstSurveyTag.Find(o => o.SurveyTitle == Survey && o.Tag == txtTagName.Text).Description = txtDescription.Text;
                }
            }
        }
    }
}
