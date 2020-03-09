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
    public partial class frmBibPhDThesis : Form
    {
        ParseBibTeX ParseBib = new ParseBibTeX();
        CLiterature literature = new CLiterature();
        CBibTeX bibTeX = new CBibTeX();
        DateTime dateAdded = new DateTime();
        public frmBibPhDThesis()
        {
            InitializeComponent();
        }

        public frmBibPhDThesis(CLiterature inputLiterature, RLiteratureAuthor inputAuthor, RLiteratureInstitution inputSchool)
        {
            InitializeComponent();
            bibTeX.BibEntry = EBibEntry.Phdthesis;
            literature = inputLiterature;
            txtTitle.Text = literature.Title;
            txtBibTitle.Text = literature.Title;
            bibTeX.Title = literature.Title;
            if (inputAuthor.Author != "")
            {
                string[] thesisAuthorFullName = inputAuthor.Author.Split(" ".ToCharArray());
                string thesisAuthor = thesisAuthorFullName[0].Substring(0, 1).ToUpper() + ". " + thesisAuthorFullName[thesisAuthorFullName.Length - 1];
                txtBibAuthor.Text = thesisAuthor;
                bibTeX.Author = thesisAuthor;
            }
            else
            {
                txtBibAuthor.Text = "";
                bibTeX.Author = "";
            }
            txtBibKey.Text = literature.BibKey;
            bibTeX.BibKey = literature.BibKey;
            txtBibSchool.Text = inputSchool.Institution;
            bibTeX.School = inputSchool.Institution;
            if (literature.PublishYear != 9999)
            {
                txtBibYear.Text = literature.PublishYear.ToString();
                bibTeX.Year = literature.PublishYear.ToString();
            }
            dateAdded = literature.DateAdded;
            txtBibTeX.Text = ParseBib.ParseBibTeXPhdthesis(bibTeX, dateAdded, DateTime.Today);
        }

        public delegate void BuildBibTeXHandler(CBibTeX bib);
        public event BuildBibTeXHandler BuildBibTeX;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXPhdthesis(bibTeX, dateAdded, DateTime.Today);
            if (txtBibTitle.Text != "" && txtBibSchool.Text != "" && txtBibAuthor.Text != "" && txtBibYear.Text != "")
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
            txtBibTeX.Text = ParseBib.ParseBibTeXPhdthesis(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibTitle_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Title = txtBibTitle.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXPhdthesis(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibSchool_TextChanged(object sender, EventArgs e)
        {
            bibTeX.School = txtBibSchool.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXPhdthesis(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibYear_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Year = txtBibYear.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXPhdthesis(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibAddress_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Address = txtBibAddress.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXPhdthesis(bibTeX, dateAdded, DateTime.Today);
        }

        private void cbxBibMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            bibTeX.Month = cbxBibMonth.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXPhdthesis(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibNote_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Note = txtBibNote.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXPhdthesis(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibKeyBackup_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Key = txtBibKeyBackup.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXPhdthesis(bibTeX, dateAdded, DateTime.Today);
        }
    }
}
