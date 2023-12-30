using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Runtime.Serialization.Formatters.Binary;

namespace LifeGame
{
    public partial class frmInfoLiterature : Form
    {
        bool modifiedFlag = false;

        CLiterature literature = new CLiterature();
        string InOneSentence = "";
        List<RLiteratureAuthor> lstLiteratureAuthor = new List<RLiteratureAuthor>();
        List<RLiteratureTag> lstLiteratureTag = new List<RLiteratureTag>();
        List<RLiteratureInstitution> lstLiteratureInstitution = new List<RLiteratureInstitution>();
        List<RLiteratureInCiting> lstLiteratureInCiting = new List<RLiteratureInCiting>();
        // List<RLiteratureOutSource> lstLiteratureOutsource = new List<RLiteratureOutSource>();
        List<RSurveyLiterature> lstSurveyLiterature = new List<RSurveyLiterature>();
        CBibTeX literatureBib = new CBibTeX();
        public frmInfoLiterature(string LiteratureTitle)
        {
            literature = G.glb.lstLiterature.Find(o => o.Title == LiteratureTitle);
            lstLiteratureTag = G.glb.lstLiteratureTag.FindAll(o => o.Title == LiteratureTitle).ToList();
            lstLiteratureAuthor = G.glb.lstLiteratureAuthor.FindAll(o => o.Title == LiteratureTitle).ToList();
            lstLiteratureAuthor = lstLiteratureAuthor.OrderBy(o => o.Rank).ToList();
            InOneSentence = literature.InOneSentence;
            lstLiteratureInCiting = G.glb.lstLiteratureCiting.FindAll(o => o.Title == LiteratureTitle).ToList();
            lstSurveyLiterature = G.glb.lstSurveyLiterature.FindAll(o => o.LiteratureTitle == LiteratureTitle).ToList();
            literatureBib = literature.BibTeX;
            InitializeComponent();
            LoadLiterature();
            modifiedFlag = false;
        }

        public frmInfoLiterature()
        {
            InitializeComponent();
            NewLiterature();
            modifiedFlag = false;
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
                    txtBibRef.Text = ParseBib.ParseBibTeXConference(bib, literature.DateAdded, literature.DateModified);
                    break;
                case EBibEntry.Inbook:
                    break;
                case EBibEntry.Incollection:
                    break;
                case EBibEntry.Manual:
                    break;
                case EBibEntry.Mastersthesis:
                    txtBibRef.Text = ParseBib.ParseBibTeXMastersthesis(bib, literature.DateAdded, literature.DateModified);
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
                    txtBibRef.Text = ParseBib.ParseBibTeXUnpublished(bib, literature.DateAdded, literature.DateModified);
                    break;
                default:
                    break;
            }
            literatureBib = bib;
            literature.DateModified = DateTime.Today;
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
            lsbInCiting.Items.Clear();
            lsbSurvey.Items.Clear();
            chkStar.Checked = false;
        }

        private void LoadLiterature()
        {
            txtTitle.Enabled = false;
            txtTitle.Text = literature.Title;
            txtYear.Text = literature.PublishYear.ToString();
            txtJournalConference.Text = literature.JournalOrConferenceName;
            txtInOneSentence.Text = literature.InOneSentence;
            txtBibKey.Text = literature.BibKey;
            chkStar.Checked = literature.Star;
            chkPredatroyAlert.Checked = literature.PredatoryAlert;
            if (literature.BibTeX != null)
            {
                cbxBibEntryType.Text = literature.BibTeX.BibEntry.ToString();
                ParseBibTeXText(literature.BibTeX);
            }
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
            lsbInCiting.Items.Clear();
            foreach (RLiteratureInCiting cited in lstLiteratureInCiting)
            {
                lsbInCiting.Items.Add(cited.TitleOfMyArticle);
            }
            foreach (RSurveyLiterature survey in lstSurveyLiterature)
            {
                lsbSurvey.Items.Add(survey.SurveyTitle);
            }
        }

        private void frmAddLiterature_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool CanSaveFlag = true;
            bool EntirelyEmptyFlag = true;
            if (modifiedFlag)
            {
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
                        newLiterature.Star = chkStar.Checked;
                        newLiterature.PredatoryAlert = chkPredatroyAlert.Checked;

                        foreach (RLiteratureAuthor author in lstLiteratureAuthor)
                        {
                            author.Title = txtTitle.Text;
                        }
                        foreach (RLiteratureTag tag in lstLiteratureTag)
                        {
                            tag.Title = txtTitle.Text;
                        }
                        foreach (RLiteratureInCiting inCiting in lstLiteratureInCiting)
                        {
                            inCiting.Title = txtTitle.Text;
                        }
                        foreach (RSurveyLiterature surveyLiterature in lstSurveyLiterature)
                        {
                            surveyLiterature.LiteratureTitle = txtTitle.Text;
                            if (!G.glb.lstSurvey.Exists(o => o.SurveyTitle == surveyLiterature.SurveyTitle))
                            {
                                CSurvey survey = new CSurvey();
                                survey.SurveyTitle = surveyLiterature.SurveyTitle;
                                G.glb.lstSurvey.Add(survey);
                            }
                        }
                        G.glb.lstLiterature.Add(newLiterature);
                        G.glb.lstLiteratureTag.AddRange(lstLiteratureTag);
                        G.glb.lstLiteratureAuthor.AddRange(lstLiteratureAuthor);
                        G.glb.lstLiteratureCiting.AddRange(lstLiteratureInCiting);
                        G.glb.lstSurveyLiterature.AddRange(lstSurveyLiterature);
                    }
                    else
                    {
                        G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).PublishYear = Convert.ToInt32(txtYear.Text);
                        G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).JournalOrConferenceName = txtJournalConference.Text;
                        G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).InOneSentence = txtInOneSentence.Text;
                        G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).BibKey = txtBibKey.Text;
                        G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).BibTeX = literatureBib;
                        G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).DateModified = DateTime.Today;
                        G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).Star = chkStar.Checked;
                        G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).PredatoryAlert = chkPredatroyAlert.Checked;
                        foreach (RLiteratureAuthor author in lstLiteratureAuthor)
                        {
                            author.Title = txtTitle.Text;
                        }
                        foreach (RLiteratureTag tag in lstLiteratureTag)
                        {
                            tag.Title = txtTitle.Text;
                        }
                        foreach (RLiteratureInCiting inCiting in lstLiteratureInCiting)
                        {
                            inCiting.Title = txtTitle.Text;
                        }
                        G.glb.lstLiteratureAuthor.RemoveAll(o => o.Title == txtTitle.Text);
                        G.glb.lstLiteratureTag.RemoveAll(o => o.Title == txtTitle.Text);
                        G.glb.lstLiteratureCiting.RemoveAll(o => o.Title == txtTitle.Text);
                        G.glb.lstLiteratureTag.AddRange(lstLiteratureTag);
                        G.glb.lstLiteratureAuthor.AddRange(lstLiteratureAuthor);
                        G.glb.lstLiteratureCiting.AddRange(lstLiteratureInCiting);
                    }

                    try
                    {
                        // 有可能literature窗口已经关掉了，没法callback
                        RefreshTab();

                        FileStream f = new FileStream("data.dat", FileMode.Create);
                        BinaryFormatter b = new BinaryFormatter();
                        b.Serialize(f, G.glb);
                        f.Close();
                    }
                    catch (Exception)
                    {
                        // 下次打开自然会刷新，所以不用catch
                    }
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
        }

        private string SelectedAttri = "";
        private void cmsAttri_Opening(object sender, CancelEventArgs e)
        {
            SelectedAttri = (sender as ContextMenuStrip).SourceControl.Name;
        }

        private void GetTag(string strTag)
        {
            if (!lsbTag.Items.Contains(strTag))
            {
                RLiteratureTag newTag = new RLiteratureTag();
                newTag.Tag = strTag;
                lstLiteratureTag.Add(newTag);
                lsbTag.Items.Add(strTag);
            }
        }

        private void tsmAttriAdd_Click(object sender, EventArgs e)
        {
            modifiedFlag = true;
            switch (SelectedAttri)
            {
                case "lsbTag":
                    frmAddTag frmAddTag = new frmAddTag();
                    frmAddTag.SendTag += new frmAddTag.GetTag(GetTag);
                    frmAddTag.Show();
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
            modifiedFlag = true;
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

        private void GetAuthor(string strAuthor)
        {
            RLiteratureAuthor newAuthor = new RLiteratureAuthor();
            newAuthor.Author = strAuthor;
            newAuthor.Rank = lsbAuthor.Items.Count;
            lstLiteratureAuthor.Add(newAuthor);
            lsbAuthor.Items.Add(strAuthor);
            GetBibKey();
        }

        private void tsmAuthorAdd_Click(object sender, EventArgs e)
        {
            modifiedFlag = true;
            frmAddAuthor frmAddAuthor = new frmAddAuthor();
            frmAddAuthor.SendAuthor += new frmAddAuthor.GetAuthor(GetAuthor);
            frmAddAuthor.Show();
        }

        private void tsmAuthorRemove_Click(object sender, EventArgs e)
        {
            modifiedFlag = true;
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
            modifiedFlag = true;
            if (lsbAuthor.SelectedItem != null)
            {
                if (lsbAuthor.SelectedIndex > 0)
                {
                    int selectedIndex = lsbAuthor.SelectedIndex;
                    string itemSelected = lsbAuthor.SelectedItem.ToString();
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
            modifiedFlag = true;
            if (lsbAuthor.SelectedItem != null)
            {
                if (lsbAuthor.SelectedIndex < lsbAuthor.Items.Count - 1)
                {
                    int selectedIndex = lsbAuthor.SelectedIndex;
                    string itemSelected = lsbAuthor.SelectedItem.ToString();
                    lsbAuthor.Items.RemoveAt(selectedIndex);
                    lsbAuthor.Items.Insert(selectedIndex + 1, itemSelected);
                    lstLiteratureAuthor[selectedIndex].Rank = selectedIndex + 1;
                    lstLiteratureAuthor[selectedIndex + 1].Rank = selectedIndex;
                    lstLiteratureAuthor = lstLiteratureAuthor.OrderBy(o => o.Rank).ToList();
                }
            }
            GetBibKey();
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
            tmpLiterature.BibTeX = literatureBib;
            modifiedFlag = true;

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

            switch (cbxBibEntryType.Text)
            {
                case "Article":
                    frmBibArticle frmBibArticle = new frmBibArticle(tmpLiterature, tmpAuthorList);
                    frmBibArticle.BuildBibTeX += new frmBibArticle.BuildBibTeXHandler(ParseBibTeXText);
                    frmBibArticle.Show();
                    break;
                case "Mastersthesis":
                    RLiteratureAuthor tmpMasterAuthor = new RLiteratureAuthor();
                    if (tmpAuthorList.Count > 0)
                    {
                        tmpMasterAuthor = tmpAuthorList[0];
                    }
                    else
                    {
                        tmpMasterAuthor.Author = "";
                    }
                    frmBibMasterThesis frmBibMasterThesis = new frmBibMasterThesis(tmpLiterature, tmpMasterAuthor);
                    frmBibMasterThesis.BuildBibTeX += new frmBibMasterThesis.BuildBibTeXHandler(ParseBibTeXText);
                    frmBibMasterThesis.Show();
                    break;
                case "Phdthesis":
                    RLiteratureAuthor tmpPhDAuthor = new RLiteratureAuthor();
                    if (tmpAuthorList.Count > 0)
                    {
                        tmpPhDAuthor = tmpAuthorList[0];
                    }
                    else
                    {
                        tmpPhDAuthor.Author = "";
                    }
                    frmBibPhDThesis frmBibPhDThesis = new frmBibPhDThesis(tmpLiterature, tmpPhDAuthor);
                    frmBibPhDThesis.BuildBibTeX += new frmBibPhDThesis.BuildBibTeXHandler(ParseBibTeXText);
                    frmBibPhDThesis.Show();
                    break;
                case "Conference":
                    frmBibConference frmBibConference = new frmBibConference(tmpLiterature, tmpAuthorList);
                    frmBibConference.BuildBibTeX += new frmBibConference.BuildBibTeXHandler(ParseBibTeXText);
                    frmBibConference.Show();
                    break;
                case "Unpublished":
                    frmBibUnpublished frmBibUnpublished = new frmBibUnpublished(tmpLiterature, tmpAuthorList);
                    frmBibUnpublished.BuildBibTeX += new frmBibUnpublished.BuildBibTeXHandler(ParseBibTeXText);
                    frmBibUnpublished.Show();
                    break;
                default:
                    break;
            }
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            modifiedFlag = true;
            GetBibKey();
        }

        private void btnGoogleScholar_Click(object sender, EventArgs e)
        {
            string url = "https://scholar.google.com/scholar?hl=en&as_sdt=0%2C33&q=" + txtTitle.Text.Replace(" ", "+") + "&btnG=";
            System.Diagnostics.Process.Start("chrome.exe", url);
        }

        private void frmInfoLiterature_Load(object sender, EventArgs e)
        {
            if (txtTitle.Enabled)
            {
                this.ActiveControl = txtTitle;
            }
            //靠！！气死了，白写了，谷歌学术会检查是不是机器人...咋绕过去呢...
            //try
            //{
            //    string url = "https://scholar.google.com/scholar?hl=en&as_sdt=0%2C33&q=" + txtTitle.Text.Replace(" ", "+") + "&btnG=";
            //    WebRequest request = WebRequest.Create(url);
            //    WebResponse response = request.GetResponse();
            //    StreamReader reader = new StreamReader(response.GetResponseStream());
            //    string htmlStr = reader.ReadToEnd();
            //    reader.Close();
            //    response.Close();
            //    Regex citation = new Regex(@"(Cited)\s(by)\s[0-9]*");
            //    bool cite = citation.IsMatch(htmlStr);
            //    Match m = citation.Match(htmlStr);
            //    lblCited.Text = m.ToString();
            //}
            //catch (Exception)
            //{
            //    lblCited.Text = "NaN";
            //}
        }

        private void txtJournalConference_TextChanged(object sender, EventArgs e)
        {
            modifiedFlag = true;
        }

        private void cbxBibEntryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            modifiedFlag = true;
        }

        private void txtInOneSentence_TextChanged(object sender, EventArgs e)
        {
            modifiedFlag = true;
        }

        private void chkStar_CheckedChanged(object sender, EventArgs e)
        {
            modifiedFlag = true;
        }

        private void chkPredatroyAlert_CheckedChanged(object sender, EventArgs e)
        {
            modifiedFlag = true;
        }

        private void tsmOpenSurvey_Click(object sender, EventArgs e)
        {
            if (lsbSurvey.SelectedItem != null)
            {
                if (G.glb.lstSurveyLiterature.Exists(o =>
                    o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                    && o.LiteratureTitle == txtTitle.Text))
                {
                    frmInfoLiteratureSurvey frmInfoLiteratureSurvey = new frmInfoLiteratureSurvey(txtTitle.Text, lsbSurvey.SelectedItem.ToString());
                    frmInfoLiteratureSurvey.Show();
                }
            }
        }

        private void tsmAddSurvey_Click(object sender, EventArgs e)
        {
            frmAddSurveyLiterature frmAddSurveyLiterature = new frmAddSurveyLiterature(txtTitle.Text);
            frmAddSurveyLiterature.SendSurvey += new frmAddSurveyLiterature.GetSurvey(GetSurvey);
            frmAddSurveyLiterature.Show();
        }

        private void GetSurvey(string strSurvey)
        {
            // 如果文献标题可编辑，先暂存到缓存区，否则直接操作存储区
            if (txtTitle.Enabled == true)
            {
                if (!lstSurveyLiterature.Exists(o => o.SurveyTitle == strSurvey))
                {
                    RSurveyLiterature newSurveyLiterature = new RSurveyLiterature();
                    newSurveyLiterature.SurveyTitle = strSurvey;
                    lstSurveyLiterature.Add(newSurveyLiterature);
                    lsbSurvey.Items.Add(strSurvey);
                }
                else
                {
                    MessageBox.Show("Already included in survey");
                }
            }
            else
            {
                if (!G.glb.lstSurvey.Exists(o => o.SurveyTitle == strSurvey))
                {
                    CSurvey survey = new CSurvey();
                    survey.SurveyTitle = strSurvey;
                    G.glb.lstSurvey.Add(survey);
                }
                if (!G.glb.lstSurveyLiterature.Exists(o => o.LiteratureTitle == txtTitle.Text && o.SurveyTitle == strSurvey))
                {
                    RSurveyLiterature newSurveyLiterature = new RSurveyLiterature();
                    newSurveyLiterature.LiteratureTitle = txtTitle.Text;
                    newSurveyLiterature.SurveyTitle = strSurvey;
                    G.glb.lstSurveyLiterature.Add(newSurveyLiterature);
                    lsbSurvey.Items.Add(strSurvey);
                }
                else
                {
                    MessageBox.Show("Already included in survey");
                }
            }
        }

        private void tsmRemoveSurvey_Click(object sender, EventArgs e)
        {
            if (lsbSurvey.SelectedItem != null)
            {
                if (txtTitle.Enabled == true)
                {
                    lstSurveyLiterature.RemoveAll(o => o.SurveyTitle == lsbSurvey.SelectedItem.ToString());
                    lsbSurvey.Items.Clear();
                    foreach (RSurveyLiterature item in lstSurveyLiterature)
                    {
                        lsbSurvey.Items.Add(item.SurveyTitle);
                    }
                }
                else
                {
                    // 如果已经有数据， 跳出确认框确认下，否则直接删
                    if (G.glb.lstSurveyLiteratureTagValue.Exists(o =>
                        o.LiteratureTitle == txtTitle.Text
                        && o.SurveyTitle == lsbSurvey.SelectedItem.ToString()))
                    {
                        DialogResult result = MessageBox.Show("Warning: There are some records for this literature, delete can not be restored!", "Delete", MessageBoxButtons.YesNo);
                        switch (result)
                        {
                            case DialogResult.Yes:
                                G.glb.lstSurveyLiteratureTagValue.RemoveAll(o =>
                                    o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                                    && o.LiteratureTitle == txtTitle.Text);
                                G.glb.lstSurveyLiterature.RemoveAll(o =>
                                    o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                                    && o.LiteratureTitle == txtTitle.Text);
                                lsbSurvey.Items.Clear();
                                foreach (RSurveyLiterature item in G.glb.lstSurveyLiterature)
                                {
                                    lsbSurvey.Items.Add(item.SurveyTitle);
                                }
                                break;
                            case DialogResult.No:
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        G.glb.lstSurveyLiterature.RemoveAll(o =>
                            o.SurveyTitle == lsbSurvey.SelectedItem.ToString()
                            && o.LiteratureTitle == txtTitle.Text);
                        lsbSurvey.Items.Clear();
                        foreach (RSurveyLiterature item in G.glb.lstSurveyLiterature)
                        {
                            lsbSurvey.Items.Add(item.SurveyTitle);
                        }
                    }
                }
            }
        }

        private void lsbSurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsmOpenSurvey.Enabled = false;
            if (lsbSurvey.SelectedItem != null)
            {
                if (G.glb.lstSurveyLiterature.Exists(o =>
                    o.LiteratureTitle == txtTitle.Text
                    && o.SurveyTitle == lsbSurvey.SelectedItem.ToString())
                    && txtTitle.Enabled == false)
                {
                    tsmOpenSurvey.Enabled = true;
                }
            }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            if (txtTitle.Enabled)
            {
                if (G.glb.lstLiterature.Exists(o => o.Title == txtTitle.Text))
                {
                    MessageBox.Show("Literature exists!");
                }
            }
        }

        private void btnFullText_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "D:\\Literature\\" + txtTitle.Text + ".pdf";
                path = path.Replace(":", "-");
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot find full text in 'D:\\Literature\\'.");
            }
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            if (G.glb.lstNote.Exists(o => o.LiteratureTitle == txtTitle.Text))
            {
                if (M.notesOpened.Exists(o => o.note.LiteratureTitle == txtTitle.Text))
                {
                    M.notesOpened.Find(o => o.note.LiteratureTitle == txtTitle.Text).Show();
                    M.notesOpened.Find(o => o.note.LiteratureTitle == txtTitle.Text).BringToFront();
                }
                else
                {
                    frmInfoNote frmInfoNote = new frmInfoNote(G.glb.lstNote.Find(o => o.LiteratureTitle == txtTitle.Text));
                    M.notesOpened.Add(frmInfoNote);
                    frmInfoNote.Show();
                }
            }
            else
            {
                frmInfoNote frmInfoNote = new frmInfoNote(txtTitle.Text);
                frmInfoNote.Show();
            }
        }
    }
}
