﻿using System;
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
        CBibTeX bibTeX = new CBibTeX();
        DateTime dateAdded = new DateTime();
        public frmBibMasterThesis()
        {
            InitializeComponent();
        }

        public frmBibMasterThesis(CLiterature inputLiterature, RLiteratureAuthor inputAuthor)
        {
            InitializeComponent();
            bibTeX.BibEntry = EBibEntry.Mastersthesis;
            literature = inputLiterature;
            txtTitle.Text = literature.Title;
            txtBibKey.Text = literature.BibKey;
            bibTeX.BibKey = literature.BibKey;

            if (inputLiterature.BibTeX != null)
            {
                if (inputLiterature.BibTeX.BibEntry != EBibEntry.Mastersthesis)
                {
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
                string[] thesisAuthorFullName = inputAuthor.Author.Split(" ".ToCharArray());
                string thesisAuthor = thesisAuthorFullName[0].Substring(0, 1).ToUpper() + ". " + thesisAuthorFullName[thesisAuthorFullName.Length - 1];
                txtBibAuthor.Text = thesisAuthor;
                bibTeX.Author = thesisAuthor;
            }
            else
            {
                txtBibAuthor.Text = inputLiterature.BibTeX.Author;
                bibTeX.Author = inputLiterature.BibTeX.Author;
            }

            if (inputLiterature.BibTeX == null || inputLiterature.BibTeX.Booktitle == "" || inputLiterature.BibTeX.Booktitle == null)
            {
                txtBibSchool.Text = "";
                bibTeX.School = "";
            }
            else
            {
                txtBibSchool.Text = literature.BibTeX.School;
                bibTeX.School = literature.BibTeX.School;
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
                if (inputLiterature.BibTeX.Address != null)
                {
                    txtBibAddress.Text = inputLiterature.BibTeX.Address;
                    bibTeX.Address = inputLiterature.BibTeX.Address;
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
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(bibTeX, dateAdded, DateTime.Today);
        }

        public delegate void BuildBibTeXHandler(CBibTeX bib);
        public event BuildBibTeXHandler BuildBibTeX;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(bibTeX, dateAdded, DateTime.Today);
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
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibTitle_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Title = txtBibTitle.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibSchool_TextChanged(object sender, EventArgs e)
        {
            bibTeX.School = txtBibSchool.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibYear_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Year = txtBibYear.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibAddress_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Address = txtBibAddress.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(bibTeX, dateAdded, DateTime.Today);
        }

        private void cbxBibMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            bibTeX.Month = cbxBibMonth.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibNote_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Note = txtBibNote.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(bibTeX, dateAdded, DateTime.Today);
        }

        private void txtBibKeyBackup_TextChanged(object sender, EventArgs e)
        {
            bibTeX.Key = txtBibKeyBackup.Text;
            txtBibTeX.Text = ParseBib.ParseBibTeXMastersthesis(bibTeX, dateAdded, DateTime.Today);
        }
    }
}
