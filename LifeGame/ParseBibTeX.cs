using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    public class ParseBibTeX
    {
        public string GetAuthor(List<RLiteratureAuthor> authors)
        {
            string Authors = "";
            List<string> lstAuthorFullNames = new List<string>();
            for (int i = 0; i < authors.Count; i++)
            {
                lstAuthorFullNames.Add("");
            }
            for (int i = 0; i < authors.Count; i++)
            {
                lstAuthorFullNames[authors[i].Rank] = authors[i].Author;
            }
            for (int i = 0; i < lstAuthorFullNames.Count; i++)
            {
                string[] truncName = lstAuthorFullNames[i].Split(" ".ToCharArray());
                Authors += truncName[0].Substring(0, 1).ToUpper();
                Authors += ". ";
                Authors += truncName[truncName.Length - 1];
                if (i < lstAuthorFullNames.Count - 1)
                {
                    Authors += " and ";
                }
            }
            return Authors;
        }

        public string ParseBibTeXArticle(CBibTeX bib, DateTime DateAdded, DateTime DateModified)
        {
            string BibTeX = "";
            BibTeX += "@Article{" + bib.BibKey + ",\r\n";
            BibTeX += "    author = {" + bib.Author + "},\r\n";
            BibTeX += "    title = {" + bib.Title + "},\r\n";
            BibTeX += "    journal = {" + bib.Journal + "},\r\n";
            BibTeX += "    year = " + bib.Year + ",\r\n";
            if (bib.Volume != "" && bib.Volume != null)
            {
                BibTeX += "    volume = {" + bib.Volume + "},\r\n";
            }
            if (bib.Number != "" && bib.Number != null)
            {
                BibTeX += "    number = {" + bib.Number + "},\r\n";
            }
            if (bib.Pages != "" && bib.Pages != null)
            {
                BibTeX += "    pages = {" + bib.Pages + "},\r\n";
            }
            if (bib.Month != "" && bib.Month != null)
            {
                BibTeX += "    month = {" + bib.Month + "},\r\n";
            }
            if (bib.Note != "" && bib.Note != null)
            {
                BibTeX += "    note = {" + bib.Note + "},\r\n";
            }
            if (bib.Key != "" && bib.Key != null)
            {
                BibTeX += "    key = {" + bib.Key + "},\r\n";
            }
            BibTeX += "    Date-Added = {" + DateAdded + "},\r\n";
            BibTeX += "    Date-Modified = {" + DateModified + "},\r\n";
            BibTeX += "}";
            return BibTeX;
        }

        public string ParseBibTeXPhdthesis(CBibTeX bib, DateTime DateAdded, DateTime DateModified)
        {
            string BibTeX = "";
            BibTeX += "@Phdthesis{" + bib.BibKey + ",\r\n";
            BibTeX += "    author = {" + bib.Author + "},\r\n";
            BibTeX += "    title = {" + bib.Title + "},\r\n";
            BibTeX += "    school = {" + bib.School + "},\r\n";
            BibTeX += "    year = " + bib.Year + ",\r\n";
            if (bib.Month != "" && bib.Month != null)
            {
                BibTeX += "    month = {" + bib.Month + "},\r\n";
            }
            if (bib.Note != "" && bib.Note != null)
            {
                BibTeX += "    note = {" + bib.Note + "},\r\n";
            }
            if (bib.Key != "" && bib.Key != null)
            {
                BibTeX += "    key = {" + bib.Key + "},\r\n";
            }
            BibTeX += "    Date-Added = {" + DateAdded + "},\r\n";
            BibTeX += "    Date-Modified = {" + DateModified + "},\r\n";
            BibTeX += "}";
            return BibTeX;
        }

        public string ParseBibTeXConference(CBibTeX bib, DateTime DateAdded, DateTime DateModified)
        {
            string BibTeX = "";
            BibTeX += "@Conference{" + bib.BibKey + ",\r\n";
            BibTeX += "    author = {" + bib.Author + "},\r\n";
            BibTeX += "    title = {" + bib.Title + "},\r\n";
            BibTeX += "    booktitle = {" + bib.Booktitle + "},\r\n";
            BibTeX += "    year = " + bib.Year + ",\r\n";
            if (bib.Editor != "" && bib.Editor != null)
            {
                BibTeX += "    editor = {" + bib.Editor + "},\r\n";
            }
            if (bib.Pages != "" && bib.Pages != null)
            {
                BibTeX += "    pages = {" + bib.Pages + "},\r\n";
            }
            if (bib.Organization != "" && bib.Organization != null)
            {
                BibTeX += "    organization = {" + bib.Organization + "},\r\n";
            }
            if (bib.Publisher != "" && bib.Publisher != null)
            {
                BibTeX += "    publisher = {" + bib.Publisher + "},\r\n";
            }
            if (bib.Address != "" && bib.Address != null)
            {
                BibTeX += "    address = {" + bib.Address + "},\r\n";
            }
            if (bib.Month != "" && bib.Month != null)
            {
                BibTeX += "    month = {" + bib.Month + "},\r\n";
            }
            if (bib.Note != "" && bib.Note != null)
            {
                BibTeX += "    note = {" + bib.Note + "},\r\n";
            }
            if (bib.Key != "" && bib.Key != null)
            {
                BibTeX += "    key = {" + bib.Key + "},\r\n";
            }
            BibTeX += "    Date-Added = {" + DateAdded + "},\r\n";
            BibTeX += "    Date-Modified = {" + DateModified + "},\r\n";
            BibTeX += "}";
            return BibTeX;
        }
    }
}
