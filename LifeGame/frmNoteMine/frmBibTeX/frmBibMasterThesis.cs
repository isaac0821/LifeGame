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
    public partial class frmBibMasterThesis : Form
    {
        ParseBibTeX ParseBib = new ParseBibTeX();
        CLiterature literature = new CLiterature();
        DateTime dateAdded = new DateTime();
        public frmBibMasterThesis()
        {
            InitializeComponent();
        }

        public frmBibMasterThesis(CLiterature inputLiterature, RLiteratureAuthor inputAuthor)
        {
            InitializeComponent();
            literature.BibEntry = EBibEntry.Mastersthesis;
            literature = inputLiterature;
            txtTitle.Text = literature.Title;
            txtBibKey.Text = literature.BibKey;

            if (inputLiterature != null)
            {
                if (inputLiterature.BibEntry != EBibEntry.Mastersthesis)
                {
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
                string[] thesisAuthorFullName = inputAuthor.Author.Split(" ".ToCharArray());
                string thesisAuthor = thesisAuthorFullName[0].Substring(0, 1).ToUpper() + ". " + thesisAuthorFullName[thesisAuthorFullName.Length - 1];
                txtBibAuthor.Text = thesisAuthor;
                literature.Author = thesisAuthor;
            }
            else
            {
                txtBibAuthor.Text = inputLiterature.Author;
                literature.Author = inputLiterature.Author;
            }

            if (inputLiterature == null || inputLiterature.Booktitle == "" || inputLiterature.Booktitle == null)
            {
                txtBibSchool.Text = "";
                literature.School = "";
            }
            else
            {
                txtBibSchool.Text = literature.School;
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
                if (inputLiterature.Address != null)
                {
                    txtBibAddress.Text = inputLiterature.Address;
                    literature.Address = inputLiterature.Address;
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
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(literature, dateAdded, DateTime.Today);
        }

        public delegate void BuildBibTeXHandler(CLiterature bib);
        public event BuildBibTeXHandler BuildBibTeX;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(literature, dateAdded, DateTime.Today);
            if (txtBibTitle.Text != "" && txtBibSchool.Text != "" && txtBibAuthor.Text != "" && txtBibYear.Text != "")
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
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(literature, dateAdded, DateTime.Today);
        }

        private void txtBibTitle_TextChanged(object sender, EventArgs e)
        {
            literature.Title = txtBibTitle.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(literature, dateAdded, DateTime.Today);
        }

        private void txtBibSchool_TextChanged(object sender, EventArgs e)
        {
            literature.School = txtBibSchool.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(literature, dateAdded, DateTime.Today);
        }

        private void txtBibYear_TextChanged(object sender, EventArgs e)
        {
            literature.Year = txtBibYear.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(literature, dateAdded, DateTime.Today);
        }

        private void txtBibAddress_TextChanged(object sender, EventArgs e)
        {
            literature.Address = txtBibAddress.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(literature, dateAdded, DateTime.Today);
        }

        private void cbxBibMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            literature.Month = cbxBibMonth.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(literature, dateAdded, DateTime.Today);
        }

        private void txtBibNote_TextChanged(object sender, EventArgs e)
        {
            literature.Note = txtBibNote.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(literature, dateAdded, DateTime.Today);
        }

        private void txtBibKeyBackup_TextChanged(object sender, EventArgs e)
        {
            literature.Key = txtBibKeyBackup.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(literature, dateAdded, DateTime.Today);
        }
    }
}
