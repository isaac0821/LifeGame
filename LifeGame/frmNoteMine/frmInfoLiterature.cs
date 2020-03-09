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
    public partial class frmInfoLiterature : Form
    {
        CLiterature literature = new CLiterature();
        string InOneSentence = "";
        List<RLiteratureAuthor> lstLiteratureAuthor = new List<RLiteratureAuthor>();
        List<RLiteratureTag> lstLiteratureTag = new List<RLiteratureTag>();
        List<RLiteratureInstitution> lstLiteratureInstitution = new List<RLiteratureInstitution>();
        List<RLiteratureInCiting> lstLiteratureInCiting = new List<RLiteratureInCiting>();
        List<RLiteratureOutSource> lstLiteratureOutsource = new List<RLiteratureOutSource>();
        List<CNote> lstNote = new List<CNote>();
        CBibTeX literatureBib = new CBibTeX();
        public frmInfoLiterature(string LiteratureTitle)
        {
            literature = G.glb.lstLiterature.Find(o => o.Title == LiteratureTitle);
            lstLiteratureTag = G.glb.lstLiteratureTag.FindAll(o => o.Title == LiteratureTitle).ToList();
            lstLiteratureAuthor = G.glb.lstLiteratureAuthor.FindAll(o => o.Title == LiteratureTitle).ToList();
            lstLiteratureAuthor = lstLiteratureAuthor.OrderBy(o => o.Rank).ToList();
            InOneSentence = literature.InOneSentence;
            lstLiteratureInstitution = G.glb.lstLiteratureInstitution.FindAll(o => o.Title == LiteratureTitle).ToList();
            lstLiteratureInCiting = G.glb.lstLiteratureCiting.FindAll(o => o.Title == LiteratureTitle).ToList();
            lstLiteratureOutsource = G.glb.lstLiteratureOutSource.FindAll(o => o.Title == LiteratureTitle).ToList();
            lstNote = G.glb.lstNote.FindAll(o => o.LiteratureTitle == LiteratureTitle).ToList();
            literatureBib = literature.BibTeX;
            InitializeComponent();
            LoadLiterature();
        }

        public frmInfoLiterature()
        {
            InitializeComponent();
            NewLiterature();
        }

        public delegate void RefreshTabHandler();
        public event RefreshTabHandler RefreshTab;

        ParseBibTeX ParseBib = new ParseBibTeX();
        private void ParseBibTeXText(CBibTeX bib)
        {
            switch (bib.BibEntry)
            {
                case EBibEntry.Article:
                    txtBibRef.Text = ParseBib.ParseBibTeXArticle(bib, literature.DateAdded, literature.DateModified);
                    break;
                case EBibEntry.Book:
                    break;
                case EBibEntry.Booklet:
                    break;
                case EBibEntry.Conference:
                    break;
                case EBibEntry.Inbook:
                    break;
                case EBibEntry.Incollection:
                    break;
                case EBibEntry.Inproceedings:
                    break;
                case EBibEntry.Manual:
                    break;
                case EBibEntry.Mastersthesis:
                    break;
                case EBibEntry.Misc:
                    break;
                case EBibEntry.Phdthesis:
                    txtBibRef.Text = ParseBib.ParseBibTeXPhdthesis(bib, literature.DateAdded, literature.DateModified);
                    break;
                case EBibEntry.Proceedings:
                    break;
                case EBibEntry.Techreport:
                    break;
                case EBibEntry.Unpublished:
                    break;
                default:
                    break;
            }
            literatureBib = bib;
        }

        private void NewLiterature()
        {
            txtTitle.Enabled = true;
            txtTitle.Text = "";
            txtYear.Text = "";
            txtJournalConference.Text = "";
            txtInOneSentence.Text = "";
            txtBibKey.Text = "";
            lsbAuthor.Items.Clear();
            lsbTag.Items.Clear();
            lsbOutSource.Items.Clear();
            lsbInstitution.Items.Clear();
            lsbNote.Items.Clear();
            lsbInCiting.Items.Clear();
        }

        private void LoadLiterature()
        {
            txtTitle.Enabled = false;

            txtTitle.Text = literature.Title;
            txtYear.Text = literature.PublishYear.ToString();
            txtJournalConference.Text = literature.JournalOrConferenceName;
            txtInOneSentence.Text = literature.InOneSentence;
            txtBibKey.Text = literature.BibKey;
            cbxBibEntryType.Text = literature.BibTeX.BibEntry.ToString();
            lsbAuthor.Items.Clear();
            foreach (RLiteratureAuthor author in lstLiteratureAuthor)
            {
                lsbAuthor.Items.Add(author.Author);
            }
            lsbTag.Items.Clear();
            foreach (RLiteratureTag tag in lstLiteratureTag)
            {
                lsbTag.Items.Add(tag.Tag);
            }
            lsbOutSource.Items.Clear();
            foreach (RLiteratureOutSource outSource in lstLiteratureOutsource)
            {
                lsbOutSource.Items.Add(outSource.OutsourcePath);
            }
            lsbInstitution.Items.Clear();
            foreach (RLiteratureInstitution institution in lstLiteratureInstitution)
            {
                lsbInstitution.Items.Add(institution.Institution);
            }
            lsbInCiting.Items.Clear();
            foreach (RLiteratureInCiting cited in lstLiteratureInCiting)
            {
                lsbInCiting.Items.Add(cited.TitleOfMyArticle);
            }
            lsbNote.Items.Clear();
            foreach (CNote note in lstNote)
            {
                lsbNote.Items.Add(note.TagTime.Year.ToString() + "." + note.TagTime.Month.ToString() + "." + note.TagTime.Day.ToString() + " - " + note.Topic);
            }
            ParseBibTeXText(literature.BibTeX);
        }

        private void frmAddLiterature_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool CanSaveFlag = true;
            bool EntirelyEmptyFlag = true;
            if (txtTitle.Text == "")
            {
                MessageBox.Show("Title is missing.");
                CanSaveFlag = false;
            }
            else
            {
                EntirelyEmptyFlag = false;
            }
            if (G.glb.lstLiterature.Exists(o => o.Title == txtTitle.Text) && txtTitle.Enabled == true)
            {
                MessageBox.Show("Literature exists.");
                CanSaveFlag = false;
            }
            if (G.glb.lstLiterature.Exists(o => o.BibKey != "" && o.BibKey == txtBibKey.Text && o.Title != txtTitle.Text))
            {
                MessageBox.Show("Bibkey exists.");
                CanSaveFlag = false;
            }
            if (txtYear.Text == "")
            {
                MessageBox.Show("Publish year is missing");
                CanSaveFlag = false;
            }
            else
            {
                EntirelyEmptyFlag = false;
            }
            if (txtJournalConference.Text == "")
            {
                MessageBox.Show("Journal/Conference Name is missing");
                CanSaveFlag = false;
            }
            else
            {
                EntirelyEmptyFlag = false;
            }
            if (lsbAuthor.Items.Count == 0)
            {
                MessageBox.Show("Add author");
                CanSaveFlag = false;
            }
            else
            {
                EntirelyEmptyFlag = false;
            }
            if (lsbTag.Items.Count == 0)
            {
                MessageBox.Show("Add tag");
                CanSaveFlag = false;
            }
            else
            {
                EntirelyEmptyFlag = false;
            }
            if (lsbInstitution.Items.Count == 0)
            {
                MessageBox.Show("Add institution");
                CanSaveFlag = false;
            }
            else
            {
                EntirelyEmptyFlag = false;
            }
            if (CanSaveFlag)
            {
                // 如果本来没有这篇文献，说明是新增文献，否则是删改文献
                if (!G.glb.lstLiterature.Exists(o => o.Title == txtTitle.Text))
                {
                    CLiterature newLiterature = new CLiterature();
                    newLiterature.Title = txtTitle.Text;
                    newLiterature.PublishYear = Convert.ToInt32(txtYear.Text);
                    newLiterature.JournalOrConferenceName = txtJournalConference.Text;
                    newLiterature.InOneSentence = txtInOneSentence.Text;
                    newLiterature.BibKey = txtBibKey.Text;
                    newLiterature.BibTeX = literatureBib;
                    newLiterature.DateAdded = DateTime.Today;
                    newLiterature.DateModified = DateTime.Today;
                    foreach (RLiteratureAuthor author in lstLiteratureAuthor)
                    {
                        author.Title = txtTitle.Text;
                    }
                    foreach (RLiteratureOutSource outSource in lstLiteratureOutsource)
                    {
                        outSource.Title = txtTitle.Text;
                    }
                    foreach (RLiteratureTag tag in lstLiteratureTag)
                    {
                        tag.Title = txtTitle.Text;
                    }
                    foreach (RLiteratureInstitution institution in lstLiteratureInstitution)
                    {
                        institution.Title = txtTitle.Text;
                    }
                    foreach (RLiteratureInCiting inCiting in lstLiteratureInCiting)
                    {
                        inCiting.Title = txtTitle.Text;
                    }
                    G.glb.lstLiterature.Add(newLiterature);
                    G.glb.lstLiteratureTag.AddRange(lstLiteratureTag);
                    G.glb.lstLiteratureAuthor.AddRange(lstLiteratureAuthor);
                    G.glb.lstLiteratureOutSource.AddRange(lstLiteratureOutsource);
                    G.glb.lstLiteratureInstitution.AddRange(lstLiteratureInstitution);
                    G.glb.lstLiteratureCiting.AddRange(lstLiteratureInCiting);
                }
                else
                {
                    G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).PublishYear = Convert.ToInt32(txtYear.Text);
                    G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).JournalOrConferenceName = txtJournalConference.Text;
                    G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).InOneSentence = txtInOneSentence.Text;
                    G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).BibKey = txtBibKey.Text;
                    G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).BibTeX = literatureBib;
                    G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).DateModified = DateTime.Today;
                    foreach (RLiteratureAuthor author in lstLiteratureAuthor)
                    {
                        author.Title = txtTitle.Text;
                    }
                    foreach (RLiteratureTag tag in lstLiteratureTag)
                    {
                        tag.Title = txtTitle.Text;
                    }
                    foreach (RLiteratureOutSource outSource in lstLiteratureOutsource)
                    {
                        outSource.Title = txtTitle.Text;
                    }
                    foreach (RLiteratureInstitution institution in lstLiteratureInstitution)
                    {
                        institution.Title = txtTitle.Text;
                    }
                    foreach (RLiteratureInCiting inCiting in lstLiteratureInCiting)
                    {
                        inCiting.Title = txtTitle.Text;
                    }
                    G.glb.lstLiteratureAuthor.RemoveAll(o => o.Title == txtTitle.Text);
                    G.glb.lstLiteratureTag.RemoveAll(o => o.Title == txtTitle.Text);
                    G.glb.lstLiteratureOutSource.RemoveAll(o => o.Title == txtTitle.Text);
                    G.glb.lstLiteratureInstitution.RemoveAll(o => o.Title == txtTitle.Text);
                    G.glb.lstLiteratureCiting.RemoveAll(o => o.Title == txtTitle.Text);
                    G.glb.lstLiteratureTag.AddRange(lstLiteratureTag);
                    G.glb.lstLiteratureAuthor.AddRange(lstLiteratureAuthor);
                    G.glb.lstLiteratureOutSource.AddRange(lstLiteratureOutsource);
                    G.glb.lstLiteratureInstitution.AddRange(lstLiteratureInstitution);
                    G.glb.lstLiteratureCiting.AddRange(lstLiteratureInCiting);
                }
                RefreshTab();
                Dispose();
            }
            else
            {
                if (!EntirelyEmptyFlag)
                {
                    e.Cancel = true;
                }
            }
        }

        private string SelectedAttri = "";
        private void cmsAttri_Opening(object sender, CancelEventArgs e)
        {
            SelectedAttri = (sender as ContextMenuStrip).SourceControl.Name;
        }
        private void tsmAttriAdd_Click(object sender, EventArgs e)
        {
            switch (SelectedAttri)
            {
                case "lsbTag":
                    string strTag = Interaction.InputBox("Literature Tag", "Literature Tag", "Literature Tag", 300, 300);
                    RLiteratureTag newTag = new RLiteratureTag();
                    newTag.Tag = strTag;
                    lstLiteratureTag.Add(newTag);
                    lsbTag.Items.Add(strTag);
                    break;
                case "lsbInstitution":
                    string strInstitution = Interaction.InputBox("Literature Institution", "Literature Institution", "Literature Institution", 300, 300);
                    RLiteratureInstitution newInstitution = new RLiteratureInstitution();
                    newInstitution.Institution = strInstitution;
                    lstLiteratureInstitution.Add(newInstitution);
                    lsbInstitution.Items.Add(strInstitution);
                    break;
                case "lsbInCiting":
                    string strInCiting = Interaction.InputBox("Literature InCiting", "Literature InCiting", "Literature InCiting", 300, 300);
                    RLiteratureInCiting newInCiting = new RLiteratureInCiting();
                    newInCiting.TitleOfMyArticle = strInCiting;
                    lstLiteratureInCiting.Add(newInCiting);
                    lsbInCiting.Items.Add(strInCiting);
                    break;
                default:
                    break;
            }
        }

        private void tsmAttriRemove_Click(object sender, EventArgs e)
        {
            switch (SelectedAttri)
            {
                case "lsbTag":
                    if (lsbTag.SelectedItem != null)
                    {
                        lstLiteratureTag.RemoveAll(o => o.Tag == lsbTag.SelectedItem.ToString());
                    }
                    lsbTag.Items.Clear();
                    foreach (RLiteratureTag Tag in lstLiteratureTag)
                    {
                        lsbTag.Items.Add(Tag.Tag);
                    }
                    break;
                case "lsbInstitution":
                    if (lsbInstitution.SelectedItem != null)
                    {
                        lstLiteratureInstitution.RemoveAll(o => o.Institution == lsbInstitution.SelectedItem.ToString());
                    }
                    lsbInstitution.Items.Clear();
                    foreach (RLiteratureInstitution Institution in lstLiteratureInstitution)
                    {
                        lsbInstitution.Items.Add(Institution.Institution);
                    }
                    break;
                case "lsbInCiting":
                    if (lsbInCiting.SelectedItem != null)
                    {
                        lstLiteratureInCiting.RemoveAll(o => o.TitleOfMyArticle == lsbInCiting.SelectedItem.ToString());
                    }
                    lsbInCiting.Items.Clear();
                    foreach (RLiteratureInCiting InCiting in lstLiteratureInCiting)
                    {
                        lsbInCiting.Items.Add(InCiting.TitleOfMyArticle);
                    }
                    break;
                default:
                    break;
            }
        }

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            if (lsbNote.SelectedItem!=null)
            {
                string selectedItemText = lsbNote.SelectedItem.ToString();
                string[] split = selectedItemText.Split('-');
                string[] datelist = split[0].Split('.');
                int Year = Convert.ToInt16(datelist[0]);
                int Month = Convert.ToInt16(datelist[1]);
                int Day = Convert.ToInt16(datelist[2].Substring(0, datelist[2].Length - 1));
                DateTime date = new DateTime(Year, Month, Day, 0, 0, 0);
                split[1] = split[1].Substring(1, split[1].Length - 1);
                string NoteTopic = "";
                for (int i = 1; i < split.Length; i++)
                {
                    NoteTopic += split[i];
                    NoteTopic += "-";
                }
                NoteTopic = NoteTopic.Substring(0, NoteTopic.Length - 1);
                CNote note = G.glb.lstNote.Find(o => o.TagTime == date && o.Topic == NoteTopic);
                Draw D = new Draw();
                D.CallInfoNote(note);
            }
        }

        private void tsmNewNote_Click(object sender, EventArgs e)
        {
            Draw D = new Draw();
            D.CallInfoNoteAddNew(txtTitle.Text);
        }

        private void GetBibKey()
        {
            string bibKey = "";
            if (lsbAuthor.Items.Count > 0)
            {
                string firstAuthor = lsbAuthor.Items[0].ToString();
                string[] firstAuthorNameSplit = firstAuthor.Split(" ".ToCharArray());
                bibKey = firstAuthorNameSplit[firstAuthorNameSplit.Length - 1] + txtYear.Text;
            }
            txtBibKey.Text = bibKey;
        }

        private void tsmAuthorAdd_Click(object sender, EventArgs e)
        {
            string strAuthor = Interaction.InputBox("Literature Author", "Literature Author", "Literature Author", 300, 300);
            RLiteratureAuthor newAuthor = new RLiteratureAuthor();
            newAuthor.Author = strAuthor;
            newAuthor.Rank = lsbAuthor.Items.Count;
            lstLiteratureAuthor.Add(newAuthor);
            lsbAuthor.Items.Add(strAuthor);
            GetBibKey();
        }

        private void tsmAuthorRemove_Click(object sender, EventArgs e)
        {
            if (lsbAuthor.SelectedItem != null)
            {
                lstLiteratureAuthor.RemoveAll(o => o.Author == lsbAuthor.SelectedItem.ToString());
            }
            lsbAuthor.Items.Clear();
            lstLiteratureAuthor = lstLiteratureAuthor.OrderBy(o => o.Rank).ToList();
            for (int i = 0; i < lstLiteratureAuthor.Count; i++)
            {
                lsbAuthor.Items.Add(lstLiteratureAuthor[i].Author);
                lstLiteratureAuthor[i].Rank = i;
            }
            GetBibKey();
        }

        private void tsmAuthorUp_Click(object sender, EventArgs e)
        {
            if (lsbAuthor.SelectedItem != null)
            {
                if (lsbAuthor.SelectedIndex > 0)
                {
                    int selectedIndex = lsbAuthor.SelectedIndex;
                    string itemSelected = lsbAuthor.SelectedItem.ToString();
                    string itemAhead = lsbAuthor.Items[lsbAuthor.SelectedIndex - 1].ToString();
                    lsbAuthor.Items.RemoveAt(selectedIndex);
                    lsbAuthor.Items.Insert(selectedIndex - 1, itemSelected);
                    lstLiteratureAuthor[selectedIndex].Rank = selectedIndex - 1;
                    lstLiteratureAuthor[selectedIndex - 1].Rank = selectedIndex;
                    lstLiteratureAuthor = lstLiteratureAuthor.OrderBy(o => o.Rank).ToList();
                }
            }
            GetBibKey();
        }

        private void tsmAuthorDown_Click(object sender, EventArgs e)
        {
            if (lsbAuthor.SelectedItem!=null)
            {
                if (lsbAuthor.SelectedIndex<lsbAuthor.Items.Count-1)
                {
                    int selectedIndex = lsbAuthor.SelectedIndex;
                    string itemSelected = lsbAuthor.SelectedItem.ToString();
                    string itemNext = lsbAuthor.Items[lsbAuthor.SelectedIndex + 1].ToString();
                    lsbAuthor.Items.RemoveAt(selectedIndex);
                    lsbAuthor.Items.Insert(selectedIndex + 1, itemSelected);
                    lstLiteratureAuthor[selectedIndex].Rank = selectedIndex + 1;
                    lstLiteratureAuthor[selectedIndex + 1].Rank = selectedIndex;
                    lstLiteratureAuthor = lstLiteratureAuthor.OrderBy(o => o.Rank).ToList();
                }
            }
            GetBibKey();
        }

        private void tsmOpenOutSource_Click(object sender, EventArgs e)
        {
            if (lsbOutSource.SelectedItem != null)
            {
                string selectedPath = lsbOutSource.SelectedItem.ToString();
                string[] checkUrl = selectedPath.Split(':');
                if (checkUrl[0] == "http" || checkUrl[0] == "https")
                {
                    System.Diagnostics.Process.Start("chrome.exe", selectedPath);
                }
                else
                {
                    try
                    {
                        System.Diagnostics.Process.Start(selectedPath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("File type is not supported.");
                    }
                }
            }
        }

        private void tsmAddOutSource_Click(object sender, EventArgs e)
        {
            string tmpPath = "D:\\paper\\" + txtTitle.Text + ".pdf"; 
            string strOutsource = Interaction.InputBox("Literature Link", "Literature Link", tmpPath, 300, 300);
            RLiteratureOutSource newOutSource = new RLiteratureOutSource();
            newOutSource.Title = txtTitle.Text;
            newOutSource.OutsourcePath = strOutsource;
            lstLiteratureOutsource.Add(newOutSource);
            lsbOutSource.Items.Add(strOutsource);
        }

        private void DeleteOutSource_Click(object sender, EventArgs e)
        {
            if (lsbOutSource.SelectedItem != null)
            {
                lstLiteratureOutsource.RemoveAll(o => o.OutsourcePath == lsbOutSource.SelectedItem.ToString());
            }
            lsbOutSource.Items.Clear();
            for (int i = 0; i < lstLiteratureOutsource.Count; i++)
            {
                lsbOutSource.Items.Add(lstLiteratureOutsource[i].OutsourcePath);
            }
        }

        private void btnBibTeX_Click(object sender, EventArgs e)
        {
            // First, create a temp literature log, use it to generate BibTeX
            // So that we don't need to care if the BibTeX is generated for new literature log or existing literature log
            // Anyway, BibTeX is just a set of attribution and eventually become a string
            CLiterature tmpLiterature = new CLiterature();
            tmpLiterature.Title = txtTitle.Text;
            tmpLiterature.BibKey = txtBibKey.Text;
            tmpLiterature.JournalOrConferenceName = txtJournalConference.Text;
            if (txtTitle.Enabled == false)
            {
                tmpLiterature.DateAdded = G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).DateAdded;
            }
            else
            {
                tmpLiterature.DateAdded = DateTime.Today;
            }
            tmpLiterature.DateModified = DateTime.Today;
            if (txtYear.Text == "")
            {
                tmpLiterature.PublishYear = 9999;
            }
            else
            {
                tmpLiterature.PublishYear = Convert.ToInt32(txtYear.Text);
            }           
            List<RLiteratureAuthor> tmpAuthorList = new List<RLiteratureAuthor>();
            for (int i = 0; i < lsbAuthor.Items.Count; i++)
            {
                RLiteratureAuthor tmpAuthor = new RLiteratureAuthor();
                tmpAuthor.Author = lsbAuthor.Items[i].ToString();
                tmpAuthor.Rank = i;
                tmpAuthorList.Add(tmpAuthor);
            }
            List<RLiteratureInstitution> tmpInstitutionList = new List<RLiteratureInstitution>();
            for (int i = 0; i < lsbInstitution.Items.Count; i++)
            {
                RLiteratureInstitution tmpInstitution = new RLiteratureInstitution();
                tmpInstitution.Institution = lsbInstitution.Items[i].ToString();
                tmpInstitutionList.Add(tmpInstitution);
            }

            switch (cbxBibEntryType.Text)
            {
                case "Article":
                    frmBibArticle frmBibArticle = new frmBibArticle(tmpLiterature, tmpAuthorList);
                    frmBibArticle.BuildBibTeX += new frmBibArticle.BuildBibTeXHandler(ParseBibTeXText); 
                    frmBibArticle.Show();
                    break;
                case "Phdthesis":
                    RLiteratureAuthor tmpAuthor = new RLiteratureAuthor();
                    if (tmpAuthorList.Count > 0)
                    {
                        tmpAuthor = tmpAuthorList[0];
                    }
                    else
                    {
                        tmpAuthor.Author = "";   
                    }
                    RLiteratureInstitution tmpInstitution = new RLiteratureInstitution();
                    if (tmpInstitutionList.Count > 0)
                    {
                        tmpInstitution = tmpInstitutionList[0];
                    }
                    else
                    {
                        tmpInstitution.Institution = "";
                    }
                    frmBibPhDThesis frmBibPhDThesis = new frmBibPhDThesis(tmpLiterature, tmpAuthor, tmpInstitution);
                    frmBibPhDThesis.BuildBibTeX += new frmBibPhDThesis.BuildBibTeXHandler(ParseBibTeXText);
                    frmBibPhDThesis.Show();
                    break;
                default:
                    break;
            }
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            GetBibKey();
        }
    }
}
