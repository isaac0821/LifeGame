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
    public partial class frmBibConference : Form
    {
        ParseBibTeX ParseBib = new ParseBibTeX();
        CLiterature literature = new CLiterature();
        DateTime dateAdded = new DateTime();
        public frmBibConference()
        {
            InitializeComponent();
        }

        public frmBibConference(CLiterature inputLiterature, List<RLiteratureAuthor> inputAuthorList)
        {
            InitializeComponent();
            inputLiterature.BibEntry = EBibEntry.Conference;
            literature = inputLiterature;
            txtTitle.Text = literature.Title;
            txtBibKey.Text = literature.BibKey;
            inputLiterature.BibKey = literature.BibKey;

            if (inputLiterature != null)
            {
                if (inputLiterature.BibEntry != EBibEntry.Conference)
                {
                    inputLiterature = null;
                }
            }

            if (inputLiterature == null || inputLiterature.Title == "" || inputLiterature.Title == null)
            {
                txtBibTitle.Text = literature.Title;
                inputLiterature.Title = literature.Title;
            }
            else
            {
                txtBibTitle.Text = literature.Title;
                inputLiterature.Title = literature.Title;
            }

            if (inputLiterature == null || inputLiterature.Author == "" || inputLiterature.Author == null)
            {
                txtBibAuthor.Text = ParseBib.GetAuthor(inputAuthorList);
                inputLiterature.Author = txtBibAuthor.Text;
            }
            else
            {
                txtBibAuthor.Text = inputLiterature.Author;
            }

            if (inputLiterature == null || inputLiterature.Booktitle == "" || inputLiterature.Booktitle == null)
            {
                txtBibBooktitle.Text = literature.JournalOrConferenceName;
                inputLiterature.Booktitle = literature.JournalOrConferenceName;
            }
            else
            {
                txtBibBooktitle.Text = literature.Booktitle;
                inputLiterature.Booktitle = literature.Booktitle;
            }

            if (inputLiterature == null || inputLiterature.Year == "" || inputLiterature.Year == null)
            {
                if (literature.PublishYear != 9999)
                {
                    txtBibYear.Text = literature.PublishYear.ToString();
                    inputLiterature.Year = literature.PublishYear.ToString();
                }
                else
                {
                    txtBibYear.Text = "";
                    inputLiterature.Year = "";
                }
            }
            else
            {
                txtBibYear.Text = inputLiterature.Year;
            }

            if (inputLiterature != null)
            {
                if (inputLiterature.Editor != null)
                {
                    txtBibEditor.Text = inputLiterature.Editor;
                }
                if (inputLiterature.Pages != null)
                {
                    txtBibPages.Text = inputLiterature.Pages;
                }
                if (inputLiterature.Organization != null)
                {
                    txtBibOrganization.Text = inputLiterature.Organization;
                }
                if (inputLiterature.Publisher != null)
                {
                    txtBibPublisher.Text = inputLiterature.Publisher;
                }
                if (inputLiterature.Address != null)
                {
                    txtBibAddress.Text = inputLiterature.Address;
                }
                if (inputLiterature.Month != null)
                {
                    cbxBibMonth.Text = inputLiterature.Month;
                }
                if (inputLiterature.Note != null)
                {
                    txtBibNote.Text = inputLiterature.Note;
                }
                if (inputLiterature.Key != null)
                {
                    txtBibKeyBackup.Text = inputLiterature.Key;
                }
            }
            dateAdded = literature.DateAdded;
            txtBibTeX.Text = ParseBib.ParseBibTeXConference(literature, dateAdded, DateTime.Today);
        }

        public delegate void BuildBibTeXHandler(CLiterature bib);
        public event BuildBibTeXHandler BuildBibTeX;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXConference(literature, dateAdded, DateTime.Today);
            if (txtBibTitle.Text != "" && txtBibBooktitle.Text != "" && txtBibAuthor.Text != "" && txtBibYear.Text != "")
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
            txtBibTeX.Text = ParseBib.ParseBibTeXConference(literature, dateAdded, DateTime.Today);
        }

        private void txtBibTitle_TextChanged(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXConference(literature, dateAdded, DateTime.Today);
        }

        private void txtBibYear_TextChanged(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXConference(literature, dateAdded, DateTime.Today);
        }

        private void txtBibPages_TextChanged(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXConference(literature, dateAdded, DateTime.Today);
        }

        private void cbxBibMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXConference(literature, dateAdded, DateTime.Today);
        }

        private void txtBibNote_TextChanged(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXConference(literature, dateAdded, DateTime.Today);
        }

        private void txtBibKeyBackup_TextChanged(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXConference(literature, dateAdded, DateTime.Today);
        }

        private void txtBibEditor_TextChanged(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXConference(literature, dateAdded, DateTime.Today);
        }

        private void txtBibOrganization_TextChanged(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXConference(literature, dateAdded, DateTime.Today);
        }

        private void txtBibPublisher_TextChanged(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXConference(literature, dateAdded, DateTime.Today);
        }

        private void txtBibAddress_TextChanged(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXConference(literature, dateAdded, DateTime.Today);
        }

        private void txtBibBooktitle_TextChanged(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXConference(literature, dateAdded, DateTime.Today);
        }
    }
}
