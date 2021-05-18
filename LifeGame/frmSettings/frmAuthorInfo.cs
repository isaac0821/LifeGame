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
    public partial class frmAuthorInfo : Form
    {
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

        public frmAuthorInfo()
        {
            InitializeComponent();
        }

        public frmAuthorInfo(string initAuthor)
        {
            InitAuthor = initAuthor;
            InitializeComponent();
        }

        private string InitAuthor;
        public delegate void RefreshLitsHandler();
        public event RefreshLitsHandler RefreshLits;

        string CurrentAuthor = "";
        List<string> lstCurrentAuthored = new List<string>();
        List<string> lstCurrentFirstAuthored = new List<string>();

        List<CItem> lstCurrentAuthoredTopic = new List<CItem>();
        List<CItem> lstCurrentFirstAuthoredTopic = new List<CItem>();

        Dictionary<string, List<string>> AuthorAbbr = new Dictionary<string, List<string>>();
        List<string> lstAuthorName = new List<string>();
        List<string> lstAuthorAbbr = new List<string>();
        names names = new names();
        private void frmAuthorInfo_Load(object sender, EventArgs e)
        {
            G.glb.lstAuthor.RemoveAll(o =>
                !G.glb.lstLiteratureAuthor.Exists(p=>p.Author == o.Author));

            foreach (CAuthor author in G.glb.lstAuthor)
            {
                if (!lstAuthorName.Exists(o => o == author.Author))
                {
                    lstAuthorName.Add(author.Author);
                }
            }
            foreach (string author in lstAuthorName)
            {
                string processedAuthorName = names.processName(author);
                if (!AuthorAbbr.ContainsKey(processedAuthorName))
                {
                    AuthorAbbr.Add(processedAuthorName, new List<string>());
                }
                if (!AuthorAbbr[processedAuthorName].Exists(o => o == author))
                {
                    AuthorAbbr[processedAuthorName].Add(author);
                }
            }
            lstAuthorAbbr = AuthorAbbr.Keys.ToList();
            lstAuthorAbbr.Sort();
            foreach (string author in lstAuthorAbbr)
            {
                lsbAuthor.Items.Add(author);
            }
            if (InitAuthor != "")
            {
                lsbAuthor.SelectedItem = names.processName(InitAuthor);
            }
        }

        private void btnSetActive_Click(object sender, EventArgs e)
        {
            if (lsbFromRecord.SelectedItem != null)
            {
                foreach (string author in AuthorAbbr[CurrentAuthor])
                {
                    if (!G.glb.lstAuthorAffiliation.Exists(
                        o=>o.Author == author &&
                        o.Affiliation == lsbFromRecord.SelectedItem.ToString()))
                    {
                        RAuthorAffiliation authorAffiliation = new RAuthorAffiliation();
                        authorAffiliation.Author = author;
                        authorAffiliation.Affiliation = lsbFromRecord.SelectedItem.ToString();
                        authorAffiliation.IsPrime = false;
                        G.glb.lstAuthorAffiliation.Add(authorAffiliation);
                    }
                }
                lsbActive.Items.Clear();
                foreach (RAuthorAffiliation affiliation in G.glb.lstAuthorAffiliation.FindAll(
                    o=>o.Author==AuthorAbbr[CurrentAuthor][0]))
                {
                    lsbActive.Items.Add(affiliation.Affiliation);
                }
            }
        }
        private void btnDeactive_Click(object sender, EventArgs e)
        {
            if (lsbActive.SelectedItem != null)
            {
                foreach (string author in AuthorAbbr[CurrentAuthor])
                {
                    G.glb.lstAuthorAffiliation.RemoveAll(
                        o => o.Author == author 
                        && o.Affiliation == lsbActive.SelectedItem.ToString());
                    if (G.glb.lstAuthor.Find(o=>o.Author == author).PrimeAffiliation == lsbActive.SelectedItem.ToString())
                    {
                        G.glb.lstAuthor.Find(o => o.Author == author).PrimeAffiliation = "";
                        lblPrimeAffiliation.Text = "";
                    }
                }
                lsbActive.Items.Clear();
                foreach (RAuthorAffiliation affiliation in G.glb.lstAuthorAffiliation.FindAll(
                    o => o.Author == AuthorAbbr[CurrentAuthor][0]))
                {
                    lsbActive.Items.Add(affiliation.Affiliation);
                }
            }
        }

        private void btnSetPrime_Click(object sender, EventArgs e)
        {
            if (lsbActive.SelectedItem != null)
            {
                foreach (string author in AuthorAbbr[CurrentAuthor])
                {
                    G.glb.lstAuthor.Find(o => o.Author == author).PrimeAffiliation = lsbActive.SelectedItem.ToString();
                }
                lblPrimeAffiliation.Text = lsbActive.SelectedItem.ToString();
            }
        }

        private void btnDeprime_Click(object sender, EventArgs e)
        {
            foreach (string author in AuthorAbbr[CurrentAuthor])
            {
                G.glb.lstAuthor.Find(o => o.Author == author).PrimeAffiliation = "";
                lblPrimeAffiliation.Text = "";
            }
        }

        private void lsbAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbAuthor.SelectedItem != null)
            {
                lsbTopicAll.Items.Clear();
                lsbTopicFirstAuthor.Items.Clear();
                lsbFromRecord.Items.Clear();
                lsbActive.Items.Clear();

                // Author name
                CurrentAuthor = lsbAuthor.SelectedItem.ToString();
                lblAuthor.Text = CurrentAuthor;
                string AuthorFullName = "";
                foreach (string authorFullName in AuthorAbbr[CurrentAuthor])
                {
                    AuthorFullName += authorFullName;
                    AuthorFullName += "; ";
                }
                AuthorFullName = AuthorFullName.Substring(0, AuthorFullName.Length - 2);
                lblAuthorInPaper.Text = AuthorFullName;

                // Get reliable
                chkReliable.Checked = G.glb.lstAuthor.Find(o => o.Author == AuthorAbbr[CurrentAuthor][0]).IsReliable;

                // Get affiliations
                lblPrimeAffiliation.Text = G.glb.lstAuthor.Find(o => o.Author == AuthorAbbr[CurrentAuthor][0]).PrimeAffiliation;
                lsbActive.Items.Clear();
                foreach (RAuthorAffiliation affiliation in G.glb.lstAuthorAffiliation.FindAll(
                    o => o.Author == AuthorAbbr[CurrentAuthor][0]))
                {
                    lsbActive.Items.Add(affiliation.Affiliation);
                }

                // Get list of literature that authored
                lstCurrentAuthored = new List<string>();
                lstCurrentFirstAuthored = new List<string>();
                foreach (CLiterature literature in G.glb.lstLiterature)
                {
                    if (G.glb.lstLiteratureAuthor.Exists(
                        o => AuthorAbbr[CurrentAuthor].Exists(p => p == o.Author)
                        && o.Title == literature.Title))
                    {
                        lstCurrentAuthored.Add(literature.Title);
                        if (G.glb.lstLiteratureAuthor.Exists(
                        o => AuthorAbbr[CurrentAuthor].Exists(p => p == o.Author)
                        && o.Title == literature.Title
                        && o.Rank == 0))
                        {
                            lstCurrentFirstAuthored.Add(literature.Title);
                        }
                    }
                }

                // Get tags
                lstCurrentAuthoredTopic = new List<CItem>();                
                foreach (string literature in lstCurrentAuthored)
                {
                    List<RLiteratureTag> lstTag = G.glb.lstLiteratureTag.FindAll(o => o.Title == literature).ToList();
                    foreach (RLiteratureTag tag in lstTag)
                    {
                        if (lstCurrentAuthoredTopic.Exists(o => o.ItemName == tag.Tag))
                        {
                            lstCurrentAuthoredTopic[lstCurrentAuthoredTopic.FindIndex(o => o.ItemName == tag.Tag)].ItemCount += 1;
                        }
                        else
                        {
                            lstCurrentAuthoredTopic.Add(new CItem(tag.Tag, 1));
                        }
                    }
                    lstCurrentAuthoredTopic = lstCurrentAuthoredTopic.OrderBy(o => o.ItemName).ToList();
                    lstCurrentAuthoredTopic = lstCurrentAuthoredTopic.OrderByDescending(o => o.ItemCount).ToList();
                    lsbTopicAll.Items.Clear();
                    foreach (CItem item in lstCurrentAuthoredTopic)
                    {
                        lsbTopicAll.Items.Add(item.ItemName + "[" + item.ItemCount + "]");
                    }
                }
                lstCurrentFirstAuthoredTopic = new List<CItem>();
                foreach (string literature in lstCurrentFirstAuthored)
                {
                    List<RLiteratureTag> lstFirstTag = G.glb.lstLiteratureTag.FindAll(o => o.Title == literature).ToList();
                    foreach (RLiteratureTag tag in lstFirstTag)
                    {
                        if (lstCurrentFirstAuthoredTopic.Exists(o => o.ItemName == tag.Tag))
                        {
                            lstCurrentFirstAuthoredTopic[lstCurrentFirstAuthoredTopic.FindIndex(o => o.ItemName == tag.Tag)].ItemCount += 1;
                        }
                        else
                        {
                            lstCurrentFirstAuthoredTopic.Add(new CItem(tag.Tag, 1));
                        }
                    }
                    lstCurrentFirstAuthoredTopic = lstCurrentFirstAuthoredTopic.OrderBy(o => o.ItemName).ToList();
                    lstCurrentFirstAuthoredTopic = lstCurrentFirstAuthoredTopic.OrderByDescending(o => o.ItemCount).ToList();
                    lsbTopicFirstAuthor.Items.Clear();
                    foreach (CItem item in lstCurrentFirstAuthoredTopic)
                    {
                        lsbTopicFirstAuthor.Items.Add(item.ItemName + "[" + item.ItemCount + "]");
                    }
                }

                // Find the institutions that author appeared in the paper
                List<string> RelatedInstitution = new List<string>();
                foreach (string lit in lstCurrentAuthored)
                {
                    foreach (RLiteratureInstitution institution in G.glb.lstLiteratureInstitution)
                    {
                        if (institution.Title == lit && !RelatedInstitution.Exists(o => o == institution.Institution))
                        {
                            RelatedInstitution.Add(institution.Institution);
                        }
                    }
                }
                RelatedInstitution.Sort();
                foreach (string institution in RelatedInstitution)
                {
                    lsbFromRecord.Items.Add(institution);
                }
            }
        }

        private void btnGoogleScholar_Click(object sender, EventArgs e)
        {
            if (CurrentAuthor != "")
            {
                string url = "https://scholar.google.com/scholar?hl=en&as_sdt=0%2C33&q=" + AuthorAbbr[CurrentAuthor][0].Replace(" ", "+") + "&btnG=";
                System.Diagnostics.Process.Start("chrome.exe", url);
            }
        }

        private void chkReliable_CheckedChanged(object sender, EventArgs e)
        {
            foreach (string author in AuthorAbbr[CurrentAuthor])
            {
                G.glb.lstAuthor.Find(o => o.Author == author).IsReliable = chkReliable.Checked;
            }
        }
    }
}
