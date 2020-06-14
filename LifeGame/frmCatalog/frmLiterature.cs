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
    public partial class frmLiterature : Form
    {
        List<CItem> Tags = new List<CItem>();
        List<CItem> Authors = new List<CItem>();
        List<CItem> Years = new List<CItem>();
        List<CItem> Institutions = new List<CItem>();
        List<CItem> JournalConferences = new List<CItem>();
        List<CItem> Projects = new List<CItem>();

        public frmLiterature()
        {
            InitializeComponent();
        }

        bool AndOrMode = false;
        private void frmLiterature_Load(object sender, EventArgs e)
        {
            LoadTab();
        }

        private class CItem
        {
            public CItem(string name, int count)
            {
                ItemName = name;
                ItemCount = count;
            }
            public string ItemName;
            public int ItemCount;
        }

        private void LoadTab()
        {
            Tags = new List<CItem>();
            Authors = new List<CItem>();
            Years = new List<CItem>();
            Institutions = new List<CItem>();
            JournalConferences = new List<CItem>();
            Projects = new List<CItem>();
            foreach (CLiterature literature in G.glb.lstLiterature)
            {
                List<RLiteratureTag> lstTag = G.glb.lstLiteratureTag.FindAll(o => o.Title == literature.Title).ToList();
                List<RLiteratureAuthor> lstAuthor = G.glb.lstLiteratureAuthor.FindAll(o => o.Title == literature.Title).ToList();
                List<RLiteratureInstitution> lstInstitution = G.glb.lstLiteratureInstitution.FindAll(o => o.Title == literature.Title).ToList();
                List<RLiteratureInCiting> lstCiting = G.glb.lstLiteratureCiting.FindAll(o => o.Title == literature.Title).ToList();
                foreach (RLiteratureTag tag in lstTag)
                {
                    if (Tags.Exists(o => o.ItemName == tag.Tag))
                    {
                        Tags[Tags.FindIndex(o => o.ItemName == tag.Tag)].ItemCount += 1;
                    }
                    else
                    {
                        Tags.Add(new CItem(tag.Tag, 1));
                    }
                }
                Tags = Tags.OrderBy(o => o.ItemName).ToList();
                Tags = Tags.OrderByDescending(o => o.ItemCount).ToList();
                foreach (RLiteratureAuthor author in lstAuthor)
                {
                    if (Authors.Exists(o => o.ItemName == author.Author))
                    {
                        Authors[Authors.FindIndex(o => o.ItemName == author.Author)].ItemCount += 1;
                    }
                    else
                    {
                        Authors.Add(new CItem(author.Author, 1));
                    }
                }
                Authors = Authors.OrderBy(o => o.ItemName).ToList();
                Authors = Authors.OrderByDescending(o => o.ItemCount).ToList();
                foreach (RLiteratureInstitution insitution in lstInstitution)
                {
                    if (Institutions.Exists(o => o.ItemName == insitution.Institution))
                    {
                        Institutions[Institutions.FindIndex(o => o.ItemName == insitution.Institution)].ItemCount += 1;
                    }
                    else
                    {
                        Institutions.Add(new CItem(insitution.Institution, 1));
                    }
                }
                Institutions = Institutions.OrderBy(o => o.ItemName).ToList();
                Institutions = Institutions.OrderByDescending(o => o.ItemCount).ToList();
                if (Years.Exists(o => o.ItemName == literature.PublishYear.ToString()))
                {
                    Years[Years.FindIndex(o => o.ItemName == literature.PublishYear.ToString())].ItemCount += 1;
                }
                else
                {
                    Years.Add(new CItem(literature.PublishYear.ToString(), 1));
                }
                Years = Years.OrderByDescending(o => Convert.ToInt16(o.ItemName)).ToList();
                if (JournalConferences.Exists(o => o.ItemName == literature.JournalOrConferenceName))
                {
                    JournalConferences[JournalConferences.FindIndex(o => o.ItemName == literature.JournalOrConferenceName)].ItemCount += 1;
                }
                else
                {
                    JournalConferences.Add(new CItem(literature.JournalOrConferenceName, 1));
                }
                JournalConferences = JournalConferences.OrderBy(o => o.ItemName).ToList();
                JournalConferences = JournalConferences.OrderByDescending(o => o.ItemCount).ToList();
                foreach (RLiteratureInCiting citing in lstCiting)
                {
                    if (Projects.Exists(o => o.ItemName == citing.TitleOfMyArticle))
                    {
                        Projects[Projects.FindIndex(o => o.ItemName == citing.TitleOfMyArticle)].ItemCount += 1;
                    }
                    else
                    {
                        Projects.Add(new CItem(citing.TitleOfMyArticle, 1));
                    }
                }
                Projects = Projects.OrderBy(o => o.ItemName).ToList();
                Projects = Projects.OrderByDescending(o => o.ItemCount).ToList();
            }

            clbTag.Items.Clear();
            for (int i = 0; i < Tags.Count; i++)
            {
                clbTag.Items.Add(Tags[i].ItemName + "[" + Tags[i].ItemCount + "]");
            }
            clbAuthor.Items.Clear();
            for (int i = 0; i < Authors.Count; i++)
            {
                clbAuthor.Items.Add(Authors[i].ItemName + "[" + Authors[i].ItemCount + "]");
            }
            clbYear.Items.Clear();
            for (int i = 0; i < Years.Count; i++)
            {
                clbYear.Items.Add(Years[i].ItemName + "[" + Years[i].ItemCount + "]");
            }
            clbInstitution.Items.Clear();
            for (int i = 0; i < Institutions.Count; i++)
            {
                clbInstitution.Items.Add(Institutions[i].ItemName + "[" + Institutions[i].ItemCount + "]");
            }
            clbJournalConference.Items.Clear();
            for (int i = 0; i < JournalConferences.Count; i++)
            {
                clbJournalConference.Items.Add(JournalConferences[i].ItemName + "[" + JournalConferences[i].ItemCount + "]");
            }
            clbProject.Items.Clear();
            for (int i = 0; i < Projects.Count; i++)
            {
                clbProject.Items.Add(Projects[i].ItemName + "[" + Projects[i].ItemCount + "]");
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
            if (dgvLiterature.SelectedCells.Count == 1)
            {
                frmInfoLiterature frmInfoLiterature = new frmInfoLiterature(dgvLiterature.CurrentRow.Cells[0].Value.ToString());
                frmInfoLiterature.RefreshTab += new frmInfoLiterature.RefreshTabHandler(LoadTab);
                frmInfoLiterature.Show();
            }
        }

        private void tsmRemoveLiterature_Click(object sender, EventArgs e)
        {
            if (dgvLiterature.SelectedCells.Count == 1)
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

        private void LoadLiteratureList(string SearchText)
        {
            List<string> ShownTitle = new List<string>();
            foreach (CLiterature literature in G.glb.lstLiterature)
            {
                if (literature.Title.ToUpper().Contains(SearchText.ToUpper()))
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

        private void LoadLiteratureList()
        {
            List<string> chosenTag = new List<string>();
            List<string> chosenAuthor = new List<string>();
            List<string> chosenInstitution = new List<string>();
            List<int> chosenYear = new List<int>();
            List<string> chosenJournalConference = new List<string>();
            List<string> chosenProject = new List<string>();

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
            for (int i = 0; i < clbProject.CheckedItems.Count; i++)
            {
                chosenProject.Add(clbProject.CheckedItems[i].ToString().Split('[').First());
            }

            List<string> ShownTitle = new List<string>();
            foreach (CLiterature literature in G.glb.lstLiterature)
            {
                if (chosenYear.Exists(o => o == literature.PublishYear))
                {
                    ShownTitle.Add(literature.Title);
                }
                if (chosenJournalConference.Exists(o => o == literature.JournalOrConferenceName))
                {
                    ShownTitle.Add(literature.Title);
                }
                if (chosenTag.Exists(o => G.glb.lstLiteratureTag.Exists(p => p.Title == literature.Title && p.Tag == o)))
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
                if (chosenProject.Exists(o => G.glb.lstLiteratureCiting.Exists(p => p.Title == literature.Title && p.TitleOfMyArticle == o)))
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            LoadLiteratureList(txtSearch.Text);
        }

        private void btnTagAll_Click(object sender, EventArgs e)
        {
            clbTag.Items.Clear();
            for (int i = 0; i < Tags.Count; i++)
            {
                clbTag.Items.Add(Tags[i].ItemName + "[" + Tags[i].ItemCount + "]", true);
            }
            LoadLiteratureList();
        }

        private void btnTagClear_Click(object sender, EventArgs e)
        {
            clbTag.Items.Clear();
            for (int i = 0; i < Tags.Count; i++)
            {
                clbTag.Items.Add(Tags[i].ItemName + "[" + Tags[i].ItemCount + "]", false);
            }
            LoadLiteratureList();
        }

        private void btnAuthorAll_Click(object sender, EventArgs e)
        {
            clbAuthor.Items.Clear();
            for (int i = 0; i < Authors.Count; i++)
            {
                clbAuthor.Items.Add(Authors[i].ItemName + "[" + Authors[i].ItemCount + "]", true);
            }
            LoadLiteratureList();
        }

        private void btnAuthorClear_Click(object sender, EventArgs e)
        {
            clbAuthor.Items.Clear();
            for (int i = 0; i < Authors.Count; i++)
            {
                clbAuthor.Items.Add(Authors[i].ItemName + "[" + Authors[i].ItemCount + "]", false);
            }
            LoadLiteratureList();
        }

        private void btnYearAll_Click(object sender, EventArgs e)
        {
            clbYear.Items.Clear();
            for (int i = 0; i < Years.Count; i++)
            {
                clbYear.Items.Add(Years[i].ItemName + "[" + Years[i].ItemCount + "]", true);
            }
            LoadLiteratureList();
        }

        private void btnYearClear_Click(object sender, EventArgs e)
        {
            clbYear.Items.Clear();
            for (int i = 0; i < Years.Count; i++)
            {
                clbYear.Items.Add(Years[i].ItemName + "[" + Years[i].ItemCount + "]", false);
            }
            LoadLiteratureList();
        }

        private void btnInsAll_Click(object sender, EventArgs e)
        {
            clbInstitution.Items.Clear();
            for (int i = 0; i < Institutions.Count; i++)
            {
                clbInstitution.Items.Add(Institutions[i].ItemName + "[" + Institutions[i].ItemCount + "]", true);
            }
            LoadLiteratureList();
        }

        private void btnInsClear_Click(object sender, EventArgs e)
        {
            clbInstitution.Items.Clear();
            for (int i = 0; i < Institutions.Count; i++)
            {
                clbInstitution.Items.Add(Institutions[i].ItemName + "[" + Institutions[i].ItemCount + "]", false);
            }
            LoadLiteratureList();
        }

        private void btnJourAll_Click(object sender, EventArgs e)
        {
            clbJournalConference.Items.Clear();
            for (int i = 0; i < JournalConferences.Count; i++)
            {
                clbJournalConference.Items.Add(JournalConferences[i].ItemName + "[" + JournalConferences[i].ItemCount + "]", true);
            }
            LoadLiteratureList();
        }

        private void btnJourClear_Click(object sender, EventArgs e)
        {
            clbJournalConference.Items.Clear();
            for (int i = 0; i < JournalConferences.Count; i++)
            {
                clbJournalConference.Items.Add(JournalConferences[i].ItemName + "[" + JournalConferences[i].ItemCount + "]", false);
            }
            LoadLiteratureList();
        }

        private void btnProjectAll_Click(object sender, EventArgs e)
        {
            clbProject.Items.Clear();
            for (int i = 0; i < Projects.Count; i++)
            {
                clbProject.Items.Add(Projects[i].ItemName + "[" + Projects[i].ItemCount + "]", true);
            }
            LoadLiteratureList();
        }

        private void btnProjectClear_Click(object sender, EventArgs e)
        {
            clbProject.Items.Clear();
            for (int i = 0; i < Projects.Count; i++)
            {
                clbProject.Items.Add(Projects[i].ItemName + "[" + Projects[i].ItemCount + "]", false);
            }
            LoadLiteratureList();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadLiteratureList();
        }

        private void tsmExportBib_Click(object sender, EventArgs e)
        {
            string strProject = Interaction.InputBox("Project", "Project", "Project", 300, 300);
            List<RLiteratureInCiting> lstLiterature = G.glb.lstLiteratureCiting.FindAll(o => o.TitleOfMyArticle == strProject);
            List<CLiterature> lstLitsToBeExported = new List<CLiterature>();

            string bib = "";

            foreach (RLiteratureInCiting lit in lstLiterature)
            {
                lstLitsToBeExported.Add(G.glb.lstLiterature.Find(o => o.Title == lit.Title));
            }
            foreach (CLiterature lit in lstLitsToBeExported)
            {
                ParseBibTeX ParseBibTeX = new ParseBibTeX();
                string bibLog = "";
                switch (lit.BibTeX.BibEntry)
                {
                    case EBibEntry.Article:
                        bibLog = ParseBibTeX.ParseBibTeXArticle(lit.BibTeX, lit.DateAdded, lit.DateModified);
                        break;
                    case EBibEntry.Book:
                        break;
                    case EBibEntry.Booklet:
                        break;
                    case EBibEntry.Conference:
                        bibLog = ParseBibTeX.ParseBibTeXConference(lit.BibTeX, lit.DateAdded, lit.DateModified);
                        break;
                    case EBibEntry.Inbook:
                        break;
                    case EBibEntry.Incollection:
                        break;
                    case EBibEntry.Manual:
                        break;
                    case EBibEntry.Mastersthesis:
                        bibLog = ParseBibTeX.ParseBibTeXMastersthesis(lit.BibTeX, lit.DateAdded, lit.DateModified);
                        break;
                    case EBibEntry.Misc:
                        break;
                    case EBibEntry.Phdthesis:
                        bibLog = ParseBibTeX.ParseBibTeXPhdthesis(lit.BibTeX, lit.DateAdded, lit.DateModified);
                        break;
                    case EBibEntry.Proceedings:
                        break;
                    case EBibEntry.Techreport:
                        break;
                    case EBibEntry.Unpublished:
                        bibLog = ParseBibTeX.ParseBibTeXUnpublished(lit.BibTeX, lit.DateAdded, lit.DateModified);
                        break;
                    default:
                        break;
                }

                bib += bibLog + "\n\n";
            }

            System.IO.File.WriteAllText(@"D:\" + strProject + "Bib.bib", bib);
        }
    }
}
