using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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

        List<string> loadedLiteratures = new List<string>();

        public frmLiterature()
        {
            InitializeComponent();
        }

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
                // By Tag
                List<RLiteratureTag> lstTag = G.glb.lstLiteratureTag.FindAll(o => o.Title == literature.Title).ToList();
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

                // By Authors
                List<RLiteratureAuthor> lstAuthor = G.glb.lstLiteratureAuthor.FindAll(o => o.Title == literature.Title).ToList();
                names names = new names();
                foreach (RLiteratureAuthor author in lstAuthor)
                {
                    if (Authors.Exists(o => o.ItemName == names.processLastName(author.Author)))
                    {
                        Authors[Authors.FindIndex(o => o.ItemName == names.processLastName(author.Author))].ItemCount += 1;
                    }
                    else
                    {
                        Authors.Add(new CItem(names.processLastName(author.Author), 1));
                    }
                }

                // By Institute
                List<RLiteratureInstitution> lstInstitution = G.glb.lstLiteratureInstitution.FindAll(o => o.Title == literature.Title).ToList();
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

                // By Project (Citing)
                List<RLiteratureInCiting> lstCiting = G.glb.lstLiteratureCiting.FindAll(o => o.Title == literature.Title).ToList();
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

                // By Year
                if (Years.Exists(o => o.ItemName == literature.PublishYear.ToString()))
                {
                    Years[Years.FindIndex(o => o.ItemName == literature.PublishYear.ToString())].ItemCount += 1;
                }
                else
                {
                    Years.Add(new CItem(literature.PublishYear.ToString(), 1));
                }

                // By Journal/Conference
                if (JournalConferences.Exists(o => o.ItemName == literature.JournalOrConferenceName))
                {
                    JournalConferences[JournalConferences.FindIndex(o => o.ItemName == literature.JournalOrConferenceName)].ItemCount += 1;
                }
                else
                {
                    JournalConferences.Add(new CItem(literature.JournalOrConferenceName, 1));
                }
            }

            Tags = Tags.OrderBy(o => o.ItemName).ToList();
            // Tags = Tags.OrderByDescending(o => o.ItemCount).ToList();
            Authors = Authors.OrderBy(o => o.ItemName).ToList();
            // Authors = Authors.OrderByDescending(o => o.ItemCount).ToList();
            Institutions = Institutions.OrderBy(o => o.ItemName).ToList();
            Institutions = Institutions.OrderByDescending(o => o.ItemCount).ToList();
            Projects = Projects.OrderBy(o => o.ItemName).ToList();
            Projects = Projects.OrderByDescending(o => o.ItemCount).ToList();
            Years = Years.OrderByDescending(o => Convert.ToInt16(o.ItemName)).ToList();
            JournalConferences = JournalConferences.OrderBy(o => o.ItemName).ToList();
            JournalConferences = JournalConferences.OrderByDescending(o => o.ItemCount).ToList();

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
            LoadLiteratureList(loadedLiteratures);
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
                frmInfoLiterature frmInfoLiterature = new frmInfoLiterature(dgvLiterature.CurrentRow.Cells[1].Value.ToString());
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
                        string removedLit = dgvLiterature.CurrentRow.Cells[1].Value.ToString();
                        G.glb.lstLiterature.RemoveAll(o => o.Title == removedLit);
                        G.glb.lstLiteratureTag.RemoveAll(o => o.Title == removedLit);
                        G.glb.lstLiteratureAuthor.RemoveAll(o => o.Title == removedLit);
                        G.glb.lstLiteratureInstitution.RemoveAll(o => o.Title == removedLit);
                        G.glb.lstLiteratureCiting.RemoveAll(o => o.Title == removedLit);
                        G.glb.lstLiteratureOutSource.RemoveAll(o => o.Title == removedLit);
                        G.glb.lstSurveyLiterature.RemoveAll(o => o.LiteratureTitle == removedLit);
                        G.glb.lstSurveyLiteratureTagValue.RemoveAll(o => o.LiteratureTitle == removedLit);                        
                        loadedLiteratures.RemoveAll(o => o == removedLit);
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
            LoadTab();
        }

        private void LoadLiteratureList(List<string> loadedLits)
        {
            dgvLiterature.Rows.Clear();
            dgvLiterature.ShowCellToolTips = true;
            foreach (string title in loadedLits)
            {
                DateTime addedDate = new DateTime();
                DateTime lastModifyDate = new DateTime();
                addedDate = G.glb.lstLiterature.Find(o => o.Title == title).DateAdded;
                lastModifyDate = G.glb.lstLiterature.Find(o => o.Title == title).DateModified;
                string starStr = "";
                string predatoryStr = "";
                bool predatoryShowFlag = true; // true if we want to show it
                string goodJourStr = "";
                bool goodJourShowFlag = false;  // true if we want to show it
                bool showFlag = true;
                string litType = "";
                int year = G.glb.lstLiterature.Find(o => o.Title == title).PublishYear;
                if (G.glb.lstLiterature.Find(o => o.Title == title).Star)
                {
                    starStr = "√";
                }
                // If the journal is predatory
                if (G.glb.lstBadJournal.Exists(o => o == G.glb.lstLiterature.Find(p => p.Title == title).JournalOrConferenceName))
                {
                    predatoryStr = "√";
                    predatoryShowFlag = false;
                }
                if (G.glb.lstLiterature.Find(o => o.Title == title).PredatoryAlert)
                {
                    predatoryStr = "√";
                    predatoryShowFlag = false;
                }
                // If the journal is reliable
                if (G.glb.lstGoodJournal.Exists(o => o == G.glb.lstLiterature.Find(p => p.Title == title).JournalOrConferenceName))
                {
                    goodJourStr = "√";
                    goodJourShowFlag = true;
                }
                // If first author is reliable
                if (G.glb.lstAuthor.Find(o => o.Author == G.glb.lstLiteratureAuthor.Find(p => p.Title == title && p.Rank == 0).Author).IsReliable)
                {
                    goodJourStr = "√";
                    goodJourShowFlag = true;
                }
                // Only if chkOnlyGood is checked and goodJournalShowFlag is not true, don't show it.
                if (chkOnlyGood.Checked && !goodJourShowFlag)
                {
                    showFlag = false;
                }
                if (showFlag)
                {
                    // For those showing lits, if chkNoBad is checked and the journal could be bad, don't show it.
                    if (chkNoBad.Checked && !predatoryShowFlag)
                    {
                        showFlag = false;
                    }
                }
                switch (G.glb.lstLiterature.Find(o => o.Title == title).BibTeX.BibEntry)
                {
                    case EBibEntry.Article:
                        litType = "J";
                        break;
                    case EBibEntry.Book:
                        litType = "M";
                        break;
                    case EBibEntry.Booklet:
                        litType = "M";
                        break;
                    case EBibEntry.Conference:
                        litType = "C";
                        break;
                    case EBibEntry.Inbook:
                        litType = "M";
                        break;
                    case EBibEntry.Incollection:
                        litType = "A";
                        break;
                    case EBibEntry.Manual:
                        litType = "M";
                        break;
                    case EBibEntry.Mastersthesis:
                        litType = "D";
                        break;
                    case EBibEntry.Misc:
                        litType = "M";
                        break;
                    case EBibEntry.Phdthesis:
                        litType = "D";
                        break;
                    case EBibEntry.Proceedings:
                        litType = "C";
                        break;
                    case EBibEntry.Techreport:
                        litType = "R";
                        break;
                    case EBibEntry.Unpublished:
                        litType = "M";
                        break;
                    default:
                        break;
                }
                if (showFlag)
                {
                    dgvLiterature.Rows.Add(starStr, title, Convert.ToString(year), litType, goodJourStr, predatoryStr, addedDate.ToString("yyyy/MM/dd"), lastModifyDate.ToString("yyyy/MM/dd"));
                    dgvLiterature.Rows[dgvLiterature.Rows.Count - 1].Cells[1].ToolTipText = G.glb.lstLiterature.Find(o => o.Title == title).InOneSentence;
                }
                lblNumFound.Text = Convert.ToString(dgvLiterature.Rows.Count) + " result(s) found";
            }
        }

        private void LoadLiteratureList(string SearchText)
        {
            List<string> ShownTitle = new List<string>();            
            foreach (CLiterature literature in G.glb.lstLiterature)
            {
                // Find literature with the search text in its title
                if (literature.Title.ToUpper().Contains(SearchText.ToUpper()))
                {
                    ShownTitle.Add(literature.Title);
                }
                // Find literature with the search text as part of the bibtex
                if (literature.BibKey.ToUpper().Contains(SearchText.ToUpper()))
                {
                    ShownTitle.Add(literature.Title);
                }
            }
            // Find literature with the search text as the author name
            foreach (CAuthor author in G.glb.lstAuthor)
            {
                if (author.Author.ToUpper().Contains(SearchText.ToUpper()))
                {
                    foreach (RLiteratureAuthor literatureAuthor in G.glb.lstLiteratureAuthor.FindAll(o => o.Author == author.Author))
                    {
                        ShownTitle.Add(literatureAuthor.Title);
                    }
                }
            }           

            ShownTitle = ShownTitle.Distinct().ToList();
            loadedLiteratures = ShownTitle;
            LoadLiteratureList(loadedLiteratures);
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
                names names = new names();
                if (chosenAuthor.Exists(o => G.glb.lstLiteratureAuthor.Exists(p => p.Title == literature.Title && names.processLastName(p.Author) == o)))
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
            loadedLiteratures = ShownTitle;
            LoadLiteratureList(loadedLiteratures);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                LoadLiteratureList(txtSearch.Text);
            }
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

        private void removeTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> selectedTags = new List<string>();
            if (clbTag.CheckedItems != null)
            {
                foreach (var selected in clbTag.CheckedItems)
                {
                    string[] sub = selected.ToString().Split('[');
                    selectedTags.Add(sub[0]);
                }
                DialogResult result = MessageBox.Show("Do you want to remove these tags? Literature without tag will add a new tag called '(default)'", "Remove confirm", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        foreach (string tag in selectedTags)
                        {
                            G.glb.lstLiteratureTag.RemoveAll(o => o.Tag == tag);
                        }
                        foreach (CLiterature lit in G.glb.lstLiterature)
                        {
                            if (!G.glb.lstLiteratureTag.Exists(o => o.Title == lit.Title))
                            {
                                RLiteratureTag defaultTag = new RLiteratureTag();
                                defaultTag.Title = lit.Title;
                                defaultTag.Tag = "(default)";
                                G.glb.lstLiteratureTag.Add(defaultTag);
                            }
                        }
                        LoadTab();
                        LoadLiteratureList();
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> selectedTags = new List<string>();
            if (clbTag.CheckedItems != null)
            {
                foreach (var selected in clbTag.CheckedItems)
                {
                    string[] sub = selected.ToString().Split('[');
                    selectedTags.Add(sub[0]);
                }
            }
            string NewName = Interaction.InputBox("Input Group Tag Name", "Rename", "Rename Tag", 300, 300);
            List<string> existingTags = new List<string>();
            foreach (RLiteratureTag litTag in G.glb.lstLiteratureTag)
            {
                if (!existingTags.Exists(o => o == litTag.Tag))
                {
                    existingTags.Add(litTag.Tag);
                }
            }
            if (existingTags.Exists(o => o == NewName))
            {
                DialogResult result = MessageBox.Show("Tag '" + NewName + "' exists, do you want to add this tag?", "Group confirm", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        List<RLiteratureTag> newTags = new List<RLiteratureTag>();
                        foreach (RLiteratureTag litTag in G.glb.lstLiteratureTag)
                        {
                            if (selectedTags.Exists(o => o == litTag.Tag))
                            {
                                if (!G.glb.lstLiteratureTag.Exists(o => o.Title == litTag.Title && o.Tag == NewName) && !newTags.Exists(o => o.Title == litTag.Title && o.Tag == NewName))
                                {
                                    RLiteratureTag groupTag = new RLiteratureTag();
                                    groupTag.Title = litTag.Title;
                                    groupTag.Tag = NewName;
                                    newTags.Add(groupTag);
                                }
                            }
                        }
                        G.glb.lstLiteratureTag.AddRange(newTags);
                        LoadTab();
                        LoadLiteratureList();
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                List<RLiteratureTag> newTags = new List<RLiteratureTag>();
                foreach (RLiteratureTag litTag in G.glb.lstLiteratureTag)
                {
                    if (selectedTags.Exists(o => o == litTag.Tag))
                    {
                        if (!G.glb.lstLiteratureTag.Exists(o => o.Title == litTag.Title && o.Tag == NewName) && !newTags.Exists(o => o.Title == litTag.Title && o.Tag == NewName))
                        {
                            RLiteratureTag groupTag = new RLiteratureTag();
                            groupTag.Title = litTag.Title;
                            groupTag.Tag = NewName;
                            newTags.Add(groupTag);
                        }
                    }
                }
                G.glb.lstLiteratureTag.AddRange(newTags);
                LoadTab();
                LoadLiteratureList();
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> selectedTags = new List<string>();
            if (clbTag.CheckedItems != null)
            {
                foreach (var selected in clbTag.CheckedItems)
                {
                    string[] sub = selected.ToString().Split('[');
                    selectedTags.Add(sub[0]);
                }
            }
            string NewName = Interaction.InputBox("Input New Tag Name", "Rename", "Rename Tag", 300, 300);
            List<string> existingTags = new List<string>();
            foreach (RLiteratureTag litTag in G.glb.lstLiteratureTag)
            {
                if (!existingTags.Exists(o => o == litTag.Tag))
                {
                    existingTags.Add(litTag.Tag);
                }
            }
            if (existingTags.Exists(o => o == NewName))
            {
                DialogResult result = MessageBox.Show("Tag '" + NewName + "' exists, do you want to merge into this tag?", "Merge confirm", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        foreach (RLiteratureTag litTag in G.glb.lstLiteratureTag)
                        {
                            if (selectedTags.Exists(o => o == litTag.Tag) && !G.glb.lstLiteratureTag.Exists(p => p.Tag == NewName && p.Title == litTag.Title))
                            {
                                litTag.Tag = NewName;
                            }
                        }
                        LoadTab();
                        LoadLiteratureList();
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                foreach (RLiteratureTag litTag in G.glb.lstLiteratureTag)
                {
                    if (selectedTags.Exists(o => o == litTag.Tag) && !G.glb.lstLiteratureTag.Exists(p => p.Tag == NewName && p.Title == litTag.Title))
                    {
                        litTag.Tag = NewName;
                    }
                }
                LoadTab();
                LoadLiteratureList();
            }
        }

        private void renameProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 迟早有一天我要把各个字段的名字给统一喽
            List<string> selectedProjects = new List<string>();
            if (clbProject.CheckedItems != null)
            {
                foreach (var selected in clbProject.CheckedItems)
                {
                    string[] sub = selected.ToString().Split('[');
                    selectedProjects.Add(sub[0]);
                }
            }
            string NewName = Interaction.InputBox("Input New Project Name", "Rename", "Rename Project", 300, 300);
            List<string> existingProjects = new List<string>();
            foreach (RLiteratureInCiting litProject in G.glb.lstLiteratureCiting)
            {
                if (!existingProjects.Exists(o => o == litProject.TitleOfMyArticle))
                {
                    existingProjects.Add(litProject.TitleOfMyArticle);
                }
            }
            if (existingProjects.Exists(o => o == NewName))
            {
                DialogResult result = MessageBox.Show("Project '" + NewName + "' exists, do you want to merge into this Project?", "Merge confirm", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        foreach (RLiteratureInCiting litProject in G.glb.lstLiteratureCiting)
                        {
                            if (selectedProjects.Exists(o => o == litProject.TitleOfMyArticle) && !G.glb.lstLiteratureCiting.Exists(p => p.TitleOfMyArticle == NewName && p.Title == litProject.Title))
                            {
                                litProject.TitleOfMyArticle = NewName;
                            }
                        }
                        LoadTab();
                        LoadLiteratureList();
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                foreach (RLiteratureInCiting litProject in G.glb.lstLiteratureCiting)
                {
                    if (selectedProjects.Exists(o => o == litProject.TitleOfMyArticle) && !G.glb.lstLiteratureCiting.Exists(p => p.TitleOfMyArticle == NewName && p.Title == litProject.Title))
                    {
                        litProject.TitleOfMyArticle = NewName;
                    }
                }
                LoadTab();
                LoadLiteratureList();
            }
        }

        private void tsmRemoveProject_Click(object sender, EventArgs e)
        {
            List<string> selectedProjects = new List<string>();
            if (clbProject.CheckedItems != null)
            {
                foreach (var selected in clbProject.CheckedItems)
                {
                    string[] sub = selected.ToString().Split('[');
                    selectedProjects.Add(sub[0]);
                }
            }
            if (selectedProjects.Count > 0)
            {
                string projectList = "";
                if (selectedProjects.Count > 1)
                {
                    foreach (string proj in selectedProjects)
                    {
                        projectList += proj + "; ";
                    }
                    projectList = projectList.Remove(projectList.Length - 2, 2);
                }
                else
                {
                    projectList = selectedProjects[0];
                }
                DialogResult result = MessageBox.Show("Do you confirm to remove the following project(s):" + projectList + "? This process cannot be recovered.", "Clear Schedule", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        foreach (string proj in selectedProjects)
                        {
                            G.glb.lstLiteratureCiting.RemoveAll(o => o.TitleOfMyArticle == proj);
                        }
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
                LoadTab();
                LoadLiteratureList();
            }
        }

        private void RemoveDuplicatedTags()
        {
            List<RLiteratureTag> noDupTags = new List<RLiteratureTag>();
            foreach (RLiteratureTag item in G.glb.lstLiteratureTag)
            {
                if (!noDupTags.Exists(o => o.Title == item.Title && o.Tag == item.Tag))
                {
                    noDupTags.Add(item);
                }
            }
            G.glb.lstLiteratureTag.Clear();
            foreach (RLiteratureTag item in noDupTags)
            {
                G.glb.lstLiteratureTag.Add(item);
            }
        }
        private void btnTagRefresh_Click(object sender, EventArgs e)
        {
            LoadTab();
        }

        private void btnJournalRefresh_Click(object sender, EventArgs e)
        {
            LoadTab();
        }

        private void btnProjectRefresh_Click(object sender, EventArgs e)
        {
            LoadTab();
        }

        private void btnAuthorRefresh_Click(object sender, EventArgs e)
        {
            LoadTab();
        }

        private void btnYearRefresh_Click(object sender, EventArgs e)
        {
            LoadTab();
        }

        private void btnInstitutionRefresh_Click(object sender, EventArgs e)
        {
            LoadTab();
        }

        private void goodJournalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReliableJournal frmReliableJournal = new frmReliableJournal();
            frmReliableJournal.RefreshLits += new frmReliableJournal.RefreshLitsHandler(LoadLiteratureList);
            frmReliableJournal.Show();
        }

        private void chkOnlyGood_CheckedChanged(object sender, EventArgs e)
        {
            LoadLiteratureList();
        }

        private void chkNoBad_CheckedChanged(object sender, EventArgs e)
        {
            LoadLiteratureList();
        }

        private void dgvLiterature_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "colCited")
            {
                e.SortResult = (
                    Convert.ToString(e.CellValue1) == "" && Convert.ToString(e.CellValue2) == "" ? 0 :
                    Convert.ToString(e.CellValue1) != "" && Convert.ToString(e.CellValue2) == "" ? 1 :
                    Convert.ToString(e.CellValue1) == "" && Convert.ToString(e.CellValue2) != "" ? -1 :
                    Convert.ToInt32(e.CellValue1) > Convert.ToInt32(e.CellValue2) ? 1 :
                    Convert.ToInt32(e.CellValue1) < Convert.ToInt32(e.CellValue2) ? -1 :
                    0);
                e.Handled = true;
            }
        }

        private void authorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAuthorInfo frmAuthorInfo = new frmAuthorInfo();
            frmAuthorInfo.RefreshLits += new frmAuthorInfo.RefreshLitsHandler(LoadLiteratureList);
            frmAuthorInfo.Show();
        }

        private void unreliableSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnreliableJournal frmUnreliableJournal = new frmUnreliableJournal();
            frmUnreliableJournal.RefreshLits += new frmUnreliableJournal.RefreshLitsHandler(LoadLiteratureList);
            frmUnreliableJournal.Show();
        }
    }
}
