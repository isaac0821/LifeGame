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
        DateTime dateAdded = new DateTime();
        public frmBibArticle()
        {
            InitializeComponent();
        }

        public frmBibArticle(CLiterature inputLiterature, List<RLiteratureAuthor> inputAuthorList)
        {
            InitializeComponent();
            literature.BibEntry = EBibEntry.Article;
            literature = inputLiterature;
            txtTitle.Text = literature.Title;
            txtBibKey.Text = literature.BibKey;

            if (inputLiterature != null)
            {
                if (inputLiterature.BibEntry != EBibEntry.Article) {
                    inputLiterature = null;
                }
            }
            
            if (inputLiterature == null || inputLiterature.Title == "" || inputLiterature.Title == null)
            {
                txtBibTitle.Text = literature.Title;
            }
            else
            {
                txtBibTitle.Text = literature.Title;
            }

            if (inputLiterature == null || inputLiterature.Author == "" || inputLiterature.Author == null)
            {
                txtBibAuthor.Text = ParseBib.GetAuthor(inputAuthorList);
                literature.Author = txtBibAuthor.Text;
            }
            else
            {
                txtBibAuthor.Text = inputLiterature.Author;
                literature.Author = inputLiterature.Author;
            }

            if (inputLiterature == null || inputLiterature.Journal == "" || inputLiterature.Journal == null)
            {
                txtBibJournal.Text = literature.JournalOrConferenceName;
                literature.Journal = literature.JournalOrConferenceName;
            }
            else
            {
                txtBibJournal.Text = literature.Journal;
            }

            if (inputLiterature == null || inputLiterature.Year == "" || inputLiterature.Year == null)
            {
                if (literature.PublishYear != 9999)
                {
                    txtBibYear.Text = literature.PublishYear.ToString();
                    literature.Year = literature.PublishYear.ToString();
                }
                else
                {
                    txtBibYear.Text = "";
                    literature.Year = "";
                }
            }
            else
            {
                txtBibYear.Text = inputLiterature.Year;
                literature.Year = inputLiterature.Year;
            }

            if (inputLiterature != null)
            {
                if (inputLiterature.Volume != null)
                {
                    txtBibVolume.Text = inputLiterature.Volume;
                    literature.Volume = inputLiterature.Volume;
                }
                if (inputLiterature.Number != null)
                {
                    txtBibNumber.Text = inputLiterature.Number;
                    literature.Number = inputLiterature.Number;
                }
                if (inputLiterature.Pages != null)
                {
                    txtBibPages.Text = inputLiterature.Pages;
                    literature.Pages = inputLiterature.Pages;
                }
                if (inputLiterature.Month != null)
                {
                    cbxBibMonth.Text = inputLiterature.Month;
                    literature.Month = inputLiterature.Month;
                }
                if (inputLiterature.Note != null)
                {
                    txtBibNote.Text = inputLiterature.Note;
                    literature.Note = inputLiterature.Note;
                }
                if (inputLiterature.Key != null)
                {
                    txtBibKeyBackup.Text = inputLiterature.Key;
                    literature.Key = inputLiterature.Key;
                }
            }

            dateAdded = literature.DateAdded;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(literature, dateAdded, DateTime.Today);
        }

        public delegate void BuildBibTeXHandler(CLiterature bib);
        public event BuildBibTeXHandler BuildBibTeX;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(literature, dateAdded, DateTime.Today);
            if (txtBibTitle.Text != "" && txtBibJournal.Text != "" && txtBibAuthor.Text != "" && txtBibYear.Text != "")
            {
                BuildBibTeX(literature);
            }
            else
            {
                MessageBox.Show("Please fill in required fields");
            }
        }

        private void txtBibAuthor_TextChanged(object sender, EventArgs e)
        {
            literature.Author = txtBibAuthor.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(literature, dateAdded, DateTime.Today);
        }

        private void txtBibTitle_TextChanged(object sender, EventArgs e)
        {
            literature.Title = txtBibTitle.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(literature, dateAdded, DateTime.Today);
        }

        private void txtBibJournal_TextChanged(object sender, EventArgs e)
        {
            literature.Journal = txtBibJournal.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(literature, dateAdded, DateTime.Today);
        }

        private void txtBibYear_TextChanged(object sender, EventArgs e)
        {
            literature.Year = txtBibYear.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(literature, dateAdded, DateTime.Today);
        }

        private void txtBibVolume_TextChanged(object sender, EventArgs e)
        {
            literature.Volume = txtBibVolume.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(literature, dateAdded, DateTime.Today);
        }

        private void txtBibNumber_TextChanged(object sender, EventArgs e)
        {
            literature.Number = txtBibNumber.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(literature, dateAdded, DateTime.Today);
        }

        private void txtBibPages_TextChanged(object sender, EventArgs e)
        {
            literature.Pages = txtBibPages.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(literature, dateAdded, DateTime.Today);
        }

        private void cbxBibMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            literature.Month = cbxBibMonth.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(literature, dateAdded, DateTime.Today);
        }

        private void txtBibNote_TextChanged(object sender, EventArgs e)
        {
            literature.Note = txtBibNote.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(literature, dateAdded, DateTime.Today);
        }

        private void txtBibKeyBackup_TextChanged(object sender, EventArgs e)
        {
            literature.Key = txtBibKeyBackup.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXArticle(literature, dateAdded, DateTime.Today);
        }
    }
}
