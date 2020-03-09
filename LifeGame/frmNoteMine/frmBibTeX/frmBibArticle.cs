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
            txtBibTitle.Text = literature.Title;
            bibTeX.Title = literature.Title;
            txtBibAuthor.Text = ParseBib.GetAuthor(inputAuthorList);
            bibTeX.Author = txtBibAuthor.Text;
            txtBibKey.Text = literature.BibKey;
            bibTeX.BibKey = literature.BibKey;
            txtBibJournal.Text = literature.JournalOrConferenceName;
            bibTeX.Journal = literature.JournalOrConferenceName;
            if (literature.PublishYear != 9999)
            {
                txtBibYear.Text = literature.PublishYear.ToString();
                bibTeX.Year = literature.PublishYear.ToString();
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
