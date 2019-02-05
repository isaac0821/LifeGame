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

        private void NewLiterature()
        {
            txtTitle.Enabled = true;

            txtTitle.Text = "";
            txtYear.Text = "";
            txtJournalConference.Text = "";
            cbxImportance.SelectedIndex = 3;
            cbxReadingStatus.SelectedIndex = 5;
            txtInOneSentence.Text = "";
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
            cbxImportance.SelectedIndex = (int)literature.Importance;
            cbxReadingStatus.SelectedIndex = (int)literature.ReadingStatus;
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
        }

        private void frmAddLiterature_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool CanSaveFlag = true;
            if (txtTitle.Text == "")
            {
                MessageBox.Show("Title is missing.");
                CanSaveFlag = false;
            }
            if (G.glb.lstLiterature.Exists(o => o.Title == txtTitle.Text) && txtTitle.Enabled == true)
            {
                MessageBox.Show("Literature exists.");
                CanSaveFlag = false;
            }
            if (txtYear.Text == "")
            {
                MessageBox.Show("Publish year is missing");
                CanSaveFlag = false;
            }
            if (txtJournalConference.Text == "")
            {
                MessageBox.Show("Journal/Conference Name is missing");
                CanSaveFlag = false;
            }
            if (cbxImportance.Text == "")
            {
                MessageBox.Show("Choose an importance level");
                CanSaveFlag = false;
            }
            if (cbxReadingStatus.Text == "")
            {
                MessageBox.Show("Choose a reading status");
                CanSaveFlag = false;
            }
            if (lsbAuthor.Items.Count == 0)
            {
                MessageBox.Show("Add author");
                CanSaveFlag = false;
            }
            if (lsbTag.Items.Count == 0)
            {
                MessageBox.Show("Add tag");
                CanSaveFlag = false;
            }
            if (lsbInstitution.Items.Count == 0)
            {
                MessageBox.Show("Add institution");
                CanSaveFlag = false;
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
                    switch (cbxImportance.SelectedIndex)
                    {
                        case 0:
                            newLiterature.Importance = ELiteratureImportance.VeryImportant;
                            break;
                        case 1:
                            newLiterature.Importance = ELiteratureImportance.Important;
                            break;
                        case 2:
                            newLiterature.Importance = ELiteratureImportance.Medium;
                            break;
                        case 3:
                            newLiterature.Importance = ELiteratureImportance.Unimportant;
                            break;
                        default:
                            break;
                    }
                    switch (cbxReadingStatus.SelectedIndex)
                    {
                        case 0:
                            newLiterature.ReadingStatus = ELiteratureReadingStatus.ModelRecur;
                            break;
                        case 1:
                            newLiterature.ReadingStatus = ELiteratureReadingStatus.FormulaDerivation;
                            break;
                        case 2:
                            newLiterature.ReadingStatus = ELiteratureReadingStatus.UnderstandModel;
                            break;
                        case 3:
                            newLiterature.ReadingStatus = ELiteratureReadingStatus.GetIdeaAndStructure;
                            break;
                        case 4:
                            newLiterature.ReadingStatus = ELiteratureReadingStatus.AbstractAndConclusion;
                            break;
                        case 5:
                            newLiterature.ReadingStatus = ELiteratureReadingStatus.NotYetStarted;
                            break;
                        default:
                            break;
                    }
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
                    switch (cbxImportance.SelectedIndex)
                    {
                        case 0:
                            G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).Importance = ELiteratureImportance.VeryImportant;
                            break;
                        case 1:
                            G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).Importance = ELiteratureImportance.Important;
                            break;
                        case 2:
                            G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).Importance = ELiteratureImportance.Medium;
                            break;
                        case 3:
                            G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).Importance = ELiteratureImportance.Unimportant;
                            break;
                        default:
                            break;
                    }
                    switch (cbxReadingStatus.SelectedIndex)
                    {
                        case 0:
                            G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).ReadingStatus = ELiteratureReadingStatus.ModelRecur;
                            break;
                        case 1:
                            G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).ReadingStatus = ELiteratureReadingStatus.FormulaDerivation;
                            break;
                        case 2:
                            G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).ReadingStatus = ELiteratureReadingStatus.UnderstandModel;
                            break;
                        case 3:
                            G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).ReadingStatus = ELiteratureReadingStatus.GetIdeaAndStructure;
                            break;
                        case 4:
                            G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).ReadingStatus = ELiteratureReadingStatus.AbstractAndConclusion;
                            break;
                        case 5:
                            G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).ReadingStatus = ELiteratureReadingStatus.NotYetStarted;
                            break;
                        default:
                            break;
                    }
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

        private void tsmAuthorAdd_Click(object sender, EventArgs e)
        {
            string strAuthor = Interaction.InputBox("Literature Author", "Literature Author", "Literature Author", 300, 300);
            RLiteratureAuthor newAuthor = new RLiteratureAuthor();
            newAuthor.Author = strAuthor;
            newAuthor.Rank = lsbAuthor.Items.Count;
            lstLiteratureAuthor.Add(newAuthor);
            lsbAuthor.Items.Add(strAuthor);
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
                        throw;
                    }
                }
            }
        }

        private void tsmAddOutSource_Click(object sender, EventArgs e)
        {
            string strOutsource = Interaction.InputBox("Literature Link", "Literature Link", "Literature Link", 300, 300);
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
    }
}
