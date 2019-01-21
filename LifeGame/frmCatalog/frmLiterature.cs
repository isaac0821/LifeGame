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
    public partial class frmLiterature : Form
    {
        public frmLiterature()
        {
            InitializeComponent();
        }

        bool AndOrMode = false;
        private void frmLiterature_Load(object sender, EventArgs e)
        {
            LoadTab();
        }

        private void LoadTab()
        {
            List<string> Tags = new List<string>();
            List<string> Authors = new List<string>();
            List<string> Years = new List<string>();
            List<string> Institutions = new List<string>();
            List<string> JournalConferences = new List<string>();
            List<int> TagNum = new List<int>();
            List<int> AuthorNum = new List<int>();
            List<int> YearNum = new List<int>();
            List<int> InstitutionNum = new List<int>();
            List<int> JournalConferenceNum = new List<int>();

            foreach (CLiterature literature in G.glb.lstLiterature)
            {
                List<RLiteratureTag> lstTag = G.glb.lstLiteratureTag.FindAll(o => o.Title == literature.Title).ToList();
                List<RLiteratureAuthor> lstAuthor = G.glb.lstLiteratureAuthor.FindAll(o => o.Title == literature.Title).ToList();
                List<RLiteratureInstitution> lstInstitution = G.glb.lstLiteratureInstitution.FindAll(o => o.Title == literature.Title).ToList();
                foreach (RLiteratureTag tag in lstTag)
                {
                    if (Tags.Exists(o => o == tag.Tag))
                    {
                        TagNum[Tags.FindIndex(o => o == tag.Tag)] += 1;
                    }
                    else
                    {
                        Tags.Add(tag.Tag);
                        TagNum.Add(1);
                    }
                }
                foreach (RLiteratureAuthor author in lstAuthor)
                {
                    if (Authors.Exists(o => o == author.Author))
                    {
                        AuthorNum[Authors.FindIndex(o => o == author.Author)] += 1;
                    }
                    else
                    {
                        Authors.Add(author.Author);
                        AuthorNum.Add(1);
                    }
                }
                foreach (RLiteratureInstitution insitution in lstInstitution)
                {
                    if (Institutions.Exists(o => o == insitution.Institution))
                    {
                        InstitutionNum[Institutions.FindIndex(o => o == insitution.Institution)] += 1;
                    }
                    else
                    {
                        Institutions.Add(insitution.Institution);
                        InstitutionNum.Add(1);
                    }
                }
                if (Years.Exists(o => o == literature.PublishYear.ToString()))
                {
                    YearNum[Years.FindIndex(o => o == literature.PublishYear.ToString())] += 1;
                }
                else
                {
                    Years.Add(literature.PublishYear.ToString());
                    YearNum.Add(1);
                }
                if (JournalConferences.Exists(o => o == literature.JournalOrConferenceName))
                {
                    JournalConferenceNum[JournalConferences.FindIndex(o => o == literature.JournalOrConferenceName)] += 1;
                }
                else
                {
                    JournalConferences.Add(literature.JournalOrConferenceName);
                    JournalConferenceNum.Add(1);
                }
            }

            clbTag.Items.Clear();
            for (int i = 0; i < Tags.Count; i++)
            {
                clbTag.Items.Add(Tags[i] + "[" + TagNum[i] + "]");
            }
            clbAuthor.Items.Clear();
            for (int i = 0; i < Authors.Count; i++)
            {
                clbAuthor.Items.Add(Authors[i] + "[" + AuthorNum[i] + "]");
            }
            clbYear.Items.Clear();
            for (int i = 0; i < Years.Count; i++)
            {
                clbYear.Items.Add(Years[i] + "[" + YearNum[i] + "]");
            }
            clbInstitution.Items.Clear();
            for (int i = 0; i < Institutions.Count; i++)
            {
                clbInstitution.Items.Add(Institutions[i] + "[" + InstitutionNum[i] + "]");
            }
            clbJournalConference.Items.Clear();
            for (int i = 0; i < JournalConferences.Count; i++)
            {
                clbJournalConference.Items.Add(JournalConferences[i] + "[" + JournalConferenceNum[i] + "]");
            }
        }

        private void tsmAddLiterature_Click(object sender, EventArgs e)
        {
            frmInfoLiterature frmInfoLiterature = new frmInfoLiterature();
            frmInfoLiterature.RefreshTab += new frmInfoLiterature.RefreshTabHandler(LoadTab);
            frmInfoLiterature.Show();
        }

        private void tsmViewLiterature_Click(object sender, EventArgs e)
        {
            if (dgvLiterature.SelectedRows != null)
            {
                frmInfoLiterature frmInfoLiterature = new frmInfoLiterature(dgvLiterature.CurrentRow.Cells[0].Value.ToString());
                frmInfoLiterature.RefreshTab += new frmInfoLiterature.RefreshTabHandler(LoadTab);
                frmInfoLiterature.Show();
            }
        }

        private void tsmRemoveLiterature_Click(object sender, EventArgs e)
        {
            if (dgvLiterature.SelectedRows != null)
            {
                DialogResult result = MessageBox.Show("Delete this literature?", "Delete", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        G.glb.lstLiterature.RemoveAll(o => o.Title == dgvLiterature.CurrentRow.Cells[0].Value.ToString());
                        G.glb.lstLiteratureTag.RemoveAll(o => o.Title == dgvLiterature.CurrentRow.Cells[0].Value.ToString());
                        G.glb.lstLiteratureAuthor.RemoveAll(o => o.Title == dgvLiterature.CurrentRow.Cells[0].Value.ToString());
                        G.glb.lstLiteratureInstitution.RemoveAll(o => o.Title == dgvLiterature.CurrentRow.Cells[0].Value.ToString());
                        G.glb.lstLiteratureCiting.RemoveAll(o => o.Title == dgvLiterature.CurrentRow.Cells[0].Value.ToString());
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
            LoadTab();
            LoadLiteratureList();
        }

        private void LoadLiteratureList()
        {
            List<string> chosenTag = new List<string>();
            List<string> chosenAuthor = new List<string>();
            List<string> chosenInstitution = new List<string>();
            List<int> chosenYear = new List<int>();
            List<string> chosenJournalConference = new List<string>();

            for (int i = 0; i < clbTag.CheckedItems.Count; i++)
            {
                chosenTag.Add(clbTag.CheckedItems[i].ToString().Split('[').First());
            }
            for (int i = 0; i < clbAuthor.CheckedItems.Count; i++)
            {
                chosenAuthor.Add(clbAuthor.CheckedItems[i].ToString().Split('[').First());
            }
            for (int i = 0; i < clbInstitution.CheckedItems.Count; i++)
            {
                chosenInstitution.Add(clbInstitution.CheckedItems[i].ToString().Split('[').First());
            }
            for (int i = 0; i < clbYear.CheckedItems.Count; i++)
            {
                chosenYear.Add(Convert.ToInt16(clbYear.CheckedItems[i].ToString().Split('[').First()));
            }
            for (int i = 0; i < clbJournalConference.CheckedItems.Count; i++)
            {
                chosenJournalConference.Add(clbJournalConference.CheckedItems[i].ToString().Split('[').First());
            }

            // 如果是And模式
            if (AndOrMode)
            {
                List<string> ShownTitle = new List<string>();
                // Year和Journal/Conference比较容易过滤，先过滤这俩
                foreach (CLiterature literature in G.glb.lstLiterature)
                {
                    if (chosenYear.Exists(o => o == literature.PublishYear) && chosenJournalConference.Exists(o => o == literature.JournalOrConferenceName))
                    {
                        ShownTitle.Add(literature.Title);
                    }
                }
                List<string> tmp = new List<string>();
                foreach (string title in ShownTitle)
                {
                    if (chosenTag.Exists(o => G.glb.lstLiteratureTag.Exists(p => p.Title == title && p.Tag == o)))
                    {
                        if (chosenAuthor.Exists(o => G.glb.lstLiteratureAuthor.Exists(p => p.Title == title && p.Author == o)))
                        {
                            if (chosenInstitution.Exists(o => G.glb.lstLiteratureInstitution.Exists(p => p.Title == title && p.Institution == o)))
                            {
                                tmp.Add(title);
                            }
                        }
                    }
                }
                ShownTitle = tmp.ToList();
                dgvLiterature.Rows.Clear();
                foreach (string title in ShownTitle)
                {
                    dgvLiterature.Rows.Add(title);
                }
            }
            // 如果是Or模式
            else
            {
                List<string> ShownTitle = new List<string>();
                foreach (CLiterature literature in G.glb.lstLiterature)
                {
                    if (chosenYear.Exists(o=>o==literature.PublishYear))
                    {
                        ShownTitle.Add(literature.Title);
                    }
                    if (chosenJournalConference.Exists(o=>o==literature.JournalOrConferenceName))
                    {
                        ShownTitle.Add(literature.Title);
                    }
                    if (chosenTag.Exists(o=>G.glb.lstLiteratureTag.Exists(p=>p.Title==literature.Title&&p.Tag ==o)))
                    {
                        ShownTitle.Add(literature.Title);
                    }
                    if (chosenAuthor.Exists(o => G.glb.lstLiteratureAuthor.Exists(p => p.Title == literature.Title && p.Author == o)))
                    {
                        ShownTitle.Add(literature.Title);
                    }
                    if (chosenInstitution.Exists(o => G.glb.lstLiteratureInstitution.Exists(p => p.Title == literature.Title && p.Institution == o)))
                    {
                        ShownTitle.Add(literature.Title);
                    }
                }
                ShownTitle = ShownTitle.Distinct().ToList();
                dgvLiterature.Rows.Clear();
                foreach (string title in ShownTitle)
                {
                    dgvLiterature.Rows.Add(title);
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            LoadLiteratureList();
            btnApply.Enabled = false;
        }

        private void clbTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void clbAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void clbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void clbInstitution_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void clbJournalConference_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void rdoAnd_CheckedChanged(object sender, EventArgs e)
        {
            AndOrMode = true;
            btnApply.Enabled = true;
        }

        private void rdoOr_CheckedChanged(object sender, EventArgs e)
        {
            AndOrMode = false;
            btnApply.Enabled = true;
        }
    }
}
