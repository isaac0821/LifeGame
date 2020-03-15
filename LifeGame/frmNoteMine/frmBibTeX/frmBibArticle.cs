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
    public partial class frmBibArticle : Form
    {
        ParseBibTeX ParseBib = new ParseBibTeX();
        CLiterature literature = new CLiterature();
        CBibTeX bibTeX = new CBibTeX();
        DateTime dateAdded = new DateTime();
        public frmBibArticle()
        {
            InitializeComponent();
        }

        public frmBibArticle(CLiterature inputLiterature, List<RLiteratureAuthor> inputAuthorList)
        {
            InitializeComponent();
            bibTeX.BibEntry = EBibEntry.Article;
            literature = inputLiterature;
            txtTitle.Text = literature.Title;
            txtBibKey.Text = literature.BibKey;
            bibTeX.BibKey = literature.BibKey;

            if (inputLiterature.BibTeX != null)
            {
                if (inputLiterature.BibTeX.BibEntry != EBibEntry.Article) {
                    inputLiterature.BibTeX = null;
                }
            }
            
            if (inputLiterature.BibTeX == null || inputLiterature.BibTeX.Title == "" || inputLiterature.BibTeX.Title == null)
            {
                txtBibTitle.Text = literature.Title;
                bibTeX.Title = literature.Title;
            }
            else
            {
                txtBibTitle.Text = literature.BibTeX.Title;
                bibTeX.Title = literature.BibTeX.Title;
            }

            if (inputLiterature.BibTeX == null || inputLiterature.BibTeX.Author == "" || inputLiterature.BibTeX.Author == null)
            {
                txtBibAuthor.Text = ParseBib.GetAuthor(inputAuthorList);
                bibTeX.Author = txtBibAuthor.Text;
            }
            else
            {
                txtBibAuthor.Text = inputLiterature.BibTeX.Author;
                bibTeX.Author = inputLiterature.BibTeX.Author;
            }

            if (inputLiterature.BibTeX == null || inputLiterature.BibTeX.Journal == "" || inputLiterature.BibTeX.Journal == null)
            {
                txtBibJournal.Text = literature.JournalOrConferenceName;
                bibTeX.Journal = literature.JournalOrConferenceName;
            }
            else
            {
                txtBibJournal.Text = literature.BibTeX.Journal;
                bibTeX.Journal = literature.BibTeX.Journal;
            }

            if (inputLiterature.BibTeX == null || inputLiterature.BibTeX.Year == "" || inputLiterature.BibTeX.Year == null)
            {
                if (literature.PublishYear != 9999)
                {
                    txtBibYear.Text = literature.PublishYear.ToString();
                    bibTeX.Year = literature.PublishYear.ToString();
                }
                else
                {
                    txtBibYear.Text = "";
                    bibTeX.Year = "";
                }
            }
            else
            {
                txtBibYear.Text = inputLiterature.BibTeX.Year;
                bibTeX.Year = inputLiterature.BibTeX.Year;
            }

            if (inputLiterature.BibTeX != null)
            {
                if (inputLiterature.BibTeX.Volume != null)
                {
                    txtBibVolume.Text = inputLiterature.BibTeX.Volume;
                    bibTeX.Volume = inputLiterature.BibTeX.Volume;
                }
                if (inputLiterature.BibTeX.Number != null)
                {
                    txtBibNumber.Text = inputLiterature.BibTeX.Number;
                    bibTeX.Number = inputLiterature.BibTeX.Number;
                }
                if (inputLiterature.BibTeX.Pages != null)
                {
                    txtBibPages.Text = inputLiterature.BibTeX.Pages;
                    bibTeX.Pages = inputLiterature.BibTeX.Pages;
                }
                if (inputLiterature.BibTeX.Month != null)
                {
                    cbxBibMonth.Text = inputLiterature.BibTeX.Month;
                    bibTeX.Month = inputLiterature.BibTeX.Month;
                }
                if (inputLiterature.BibTeX.Note != null)
                {
                    txtBibNote.Text = inputLiterature.BibTeX.Note;
                    bibTeX.Note = inputLiterature.BibTeX.Note;
                }
                if (inputLiterature.BibTeX.Key != null)
                {
                    txtBibKeyBackup.Text = inputLiterature.BibTeX.Key;
                    bibTeX.Key = inputLiterature.BibTeX.Key;
                }
            }

            dateAdded = literature.DateAdded;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(bibTeX, dateAdded, DateTime.Today);
        }

        public delegate void BuildBibTeXHandler(CBibTeX bib);
        public event BuildBibTeXHandler BuildBibTeX;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(bibTeX, dateAdded, DateTime.Today);
            if (txtBibTitle.Text != "" && txtBibJournal.Text != "" && txtBibAuthor.Text != "" && txtBibYear.Text != "")
            {
                BuildBibTeX(bibTeX);
            }
            else
            {
                MessageBox.Show("Please fill in required fields");
            }
        }

        private void txtBibAuthor_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Author = txtBibAuthor.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibTitle_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Title = txtBibTitle.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibJournal_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Journal = txtBibJournal.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibYear_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Year = txtBibYear.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibVolume_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Volume = txtBibVolume.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibNumber_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Number = txtBibNumber.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibPages_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Pages = txtBibPages.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(bibTeX, dateAdded, DateTime.Today);
        }

        private void cbxBibMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            bibTeX.Month = cbxBibMonth.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibNote_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Note = txtBibNote.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibKeyBackup_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Key = txtBibKeyBackup.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(bibTeX, dateAdded, DateTime.Today);
        }
    }
}
