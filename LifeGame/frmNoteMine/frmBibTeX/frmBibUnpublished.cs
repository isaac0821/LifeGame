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
    public partial class frmBibUnpublished : Form
    {
        ParseBibTeX ParseBib = new ParseBibTeX();
        CLiterature literature = new CLiterature();
        CBibTeX bibTeX = new CBibTeX();
        DateTime dateAdded = new DateTime();
        public frmBibUnpublished()
        {
            InitializeComponent();
        }

        public frmBibUnpublished(CLiterature inputLiterature, List<RLiteratureAuthor> inputAuthorList)
        {
            InitializeComponent();
            bibTeX.BibEntry = EBibEntry.Unpublished;
            literature = inputLiterature;
            txtTitle.Text = literature.Title;
            txtBibKey.Text = literature.BibKey;
            bibTeX.BibKey = literature.BibKey;

            if (inputLiterature.BibTeX != null)
            {
                if (inputLiterature.BibTeX.BibEntry != EBibEntry.Unpublished) {
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

            if (inputLiterature.BibTeX == null || inputLiterature.BibTeX.Note == "" || inputLiterature.BibTeX.Note == null)
            {
                txtBibNote.Text = literature.JournalOrConferenceName;
                bibTeX.Note = literature.JournalOrConferenceName;
            }
            else
            {
                txtBibNote.Text = literature.BibTeX.Note;
                bibTeX.Note = literature.BibTeX.Note;
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
                if (inputLiterature.BibTeX.Month != null)
                {
                    cbxBibMonth.Text = inputLiterature.BibTeX.Month;
                    bibTeX.Month = inputLiterature.BibTeX.Month;
                }
                if (inputLiterature.BibTeX.Key != null)
                {
                    txtBibKeyBackup.Text = inputLiterature.BibTeX.Key;
                    bibTeX.Key = inputLiterature.BibTeX.Key;
                }
            }

            dateAdded = literature.DateAdded;
            txtBibTeX.Text = ParseBib.ParseBibTeXUnpublished(bibTeX, dateAdded, DateTime.Today);
        }

        public delegate void BuildBibTeXHandler(CBibTeX bib);
        public event BuildBibTeXHandler BuildBibTeX;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXUnpublished(bibTeX, dateAdded, DateTime.Today);
            if (txtBibTitle.Text != "" && txtBibAuthor.Text != "" && txtBibNote.Text != "")
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
            txtBibTeX.Text = ParseBib.ParseBibTeXUnpublished(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibTitle_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Title = txtBibTitle.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXUnpublished(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibYear_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Year = txtBibYear.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXUnpublished(bibTeX, dateAdded, DateTime.Today);
        }

        private void cbxBibMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            bibTeX.Month = cbxBibMonth.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXUnpublished(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibNote_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Note = txtBibNote.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXUnpublished(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibKeyBackup_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Key = txtBibKeyBackup.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXUnpublished(bibTeX, dateAdded, DateTime.Today);
        }
    }
}
