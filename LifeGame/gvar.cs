using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace LifeGame
{
    public static class G
    {
        public static Mem glb = new Mem();
    }

    [Serializable]
    public class Mem
    {
        // Logs and Events
        public List<CDiary> lstDiary = new List<CDiary>();
        public List<CLog> lstLog = new List<CLog>();
        public List<CEvent> lstEvent = new List<CEvent>();

        // Finance
        public List<CTransaction> lstTransaction = new List<CTransaction>();
        public List<CTransaction> lstBudget = new List<CTransaction>();
        public List<CAccount> lstAccount = new List<CAccount>();
        public List<RSubAccount> lstSubAccount = new List<RSubAccount>();
        public List<RCurrencyRate> lstCurrencyRate = new List<RCurrencyRate>();

        // Note
        public List<CNote> lstNote = new List<CNote>();
        public List<RNoteColor> lstNoteColor = new List<RNoteColor>();
        public List<RNoteLog> lstNoteLog = new List<RNoteLog>();

        // Literature
        public List<CLiterature> lstLiterature = new List<CLiterature>();
        public List<CLiteratureTag> lstLiteratureTagType = new List<CLiteratureTag>();
        public List<RSubLiteratureTag> lstSubLiteratureTag = new List<RSubLiteratureTag>();        
        public List<RLiteratureAuthor> lstLiteratureAuthor = new List<RLiteratureAuthor>();
        public List<RLiteratureTag> lstLiteratureTag = new List<RLiteratureTag>();
    }

    public static class IO
    {
        public static void LoadData()
        {
            string dbfile = "Data Source=lifegame.db";
            using (SQLiteConnection con = new SQLiteConnection(dbfile))
            {
                con.Open();



            }
        }

        public static void SaveData()
        {
            string dbfile = "Data Source=lifegame.db";
            using (SQLiteConnection con = new SQLiteConnection(dbfile))
            {
                con.Open();
                
                SQLiteCommand clc = new SQLiteCommand();
                SQLiteCommand cmd = new SQLiteCommand();

                // lstLog
                //clc = new SQLiteCommand("DELETE FROM Class_Log;", con);
                //clc.ExecuteNonQuery();
                //foreach (CLog item in G.glb.lstLog)
                //{
                //    string sql = "INSERT INTO Class_Log (" +
                //        "LogName, " +
                //        "StartTime, " +
                //        "EndTime, " +
                //        "Location, " +
                //        "WithWho, " +
                //        "Color, " +
                //        "Alarm, " +
                //        "AlarmTime) VALUES (";
                //    sql += "'" + Convert.ToString(item.LogName).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.StartTime).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.EndTime).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Location).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.WithWho).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Color).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Alarm).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.AlarmTime).Replace("'", "''") + "'";
                //    sql += ");";

                //    cmd = new SQLiteCommand(sql, con);
                //    cmd.ExecuteNonQuery();
                //}

                // Note
                //clc = new SQLiteCommand("DELETE FROM Class_Note;", con);
                //clc.ExecuteNonQuery();
                //foreach (CNote item in G.glb.lstNote)
                //{
                //    string sql = "INSERT INTO Class_Note (" +
                //        "TagTime, " +
                //        "FatherGUID, " +
                //        "Topic, " +
                //        "NoteType) VALUES (";
                //    sql += "'" + Convert.ToString(item.TagTime).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.FatherGUID).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Topic).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.NoteType).Replace("'", "''") + "'";
                //    sql += ");";

                //    cmd = new SQLiteCommand(sql, con);
                //    cmd.ExecuteNonQuery();
                //}

                //// NoteColor
                //clc = new SQLiteCommand("DELETE FROM Relation_NoteColor;", con);
                //clc.ExecuteNonQuery();
                //foreach (RNoteColor item in G.glb.lstNoteColor)
                //{
                //    string sql = "INSERT INTO Relation_NoteColor (" +
                //        "Topic, " +
                //        "TagTime, " +
                //        "Keyword, " +
                //        "Color) VALUES (";
                //    sql += "'" + Convert.ToString(item.Topic).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.TagTime).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Keyword).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Color).Replace("'", "''") + "'";
                //    sql += ");";

                //    cmd = new SQLiteCommand(sql, con);
                //    cmd.ExecuteNonQuery();
                //}

                //// NoteLog
                //clc = new SQLiteCommand("DELETE FROM Relation_NoteLog;", con);
                //clc.ExecuteNonQuery();
                //foreach (RNoteLog item in G.glb.lstNoteLog)
                //{
                //    string sql = "INSERT INTO Relation_NoteLog (" +
                //        "Topic, " +
                //        "GUID, " +
                //        "TagTime, " +
                //        "FatherLog, " +
                //        "FatherGUID, " +
                //        "SubLog, " +
                //        "SubGUID, " +
                //        "IsExpand, " +
                //        "Ordering) VALUES (";
                //    sql += "'" + Convert.ToString(item.Topic).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.GUID).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.TagTime).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.FatherLog).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.FatherGUID).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.SubLog).Replace("'", "''") + "', "; 
                //    sql += "'" + Convert.ToString(item.SubGUID).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.IsExpand).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Ordering).Replace("'", "''") + "'";
                //    sql += ");";

                //    cmd = new SQLiteCommand(sql, con);
                //    cmd.ExecuteNonQuery();
                //}

                //// Literature
                //clc = new SQLiteCommand("DELETE FROM Class_Literature;", con);
                //clc.ExecuteNonQuery();                
                //foreach (CLiterature item in G.glb.lstLiterature)
                //{
                //    string sql = "INSERT INTO Class_Literature (" +
                //        "Title, " +
                //        "DateAdded, " +
                //        "DateModified, " +
                //        "PredatoryAlert, " +
                //        "PublishYear, " +
                //        "JournalOrConferenceName, " +
                //        "Star, " +
                //        "BibKey, " +
                //        "BibEntry, " +
                //        "Address, " +
                //        "Annote, " +
                //        "Booktitle, " +
                //        "Chapter, " +
                //        "Crossref, " +
                //        "Doi, " +
                //        "Edition, " +
                //        "Howpublished, " +
                //        "Institution, " +
                //        "Journal, " +
                //        "Key, " +
                //        "Month, " +
                //        "Note, " +
                //        "Number, " +
                //        "Organization, " +
                //        "Pages, " +
                //        "Publisher, " +
                //        "School, " +
                //        "Series, " +
                //        "Type, " +
                //        "Volume, " +
                //        "Year) VALUES (";
                //    sql += "'" + Convert.ToString(item.Title).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.DateAdded).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.DateModified).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.PredatoryAlert).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.PublishYear).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.JournalOrConferenceName).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Star).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.BibKey).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.BibEntry).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Address).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Annote).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Booktitle).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Chapter).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Crossref).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Doi).Replace("'", "''") + "', ";  
                //    sql += "'" + Convert.ToString(item.Edition).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Howpublished).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Institution).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Journal).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Key).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Month).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Note).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Number).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Organization).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Pages).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Publisher).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.School).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Series).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Type).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Volume).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Year).Replace("'", "''") + "'";
                //    sql += ");";

                //    cmd = new SQLiteCommand(sql, con);
                //    cmd.ExecuteNonQuery();
                //}

                //// LiteratureTagType
                //clc = new SQLiteCommand("DELETE FROM Class_LiteratureTag;", con);
                //clc.ExecuteNonQuery();
                //foreach (CLiteratureTag item in G.glb.lstLiteratureTagType)
                //{
                //    string sql = "INSERT INTO Class_LiteratureTag (" +
                //        "Tag, " +
                //        "FatherGUID) VALUES (";
                //    sql += "'" + Convert.ToString(item.Tag).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.FatherGUID).Replace("'", "''") + "'";
                //    sql += ");";

                //    cmd = new SQLiteCommand(sql, con);
                //    cmd.ExecuteNonQuery();
                //}

                //// SubLiteratureTag
                //clc = new SQLiteCommand("DELETE FROM Relation_SubLiteratureTag;", con);
                //clc.ExecuteNonQuery();
                //foreach (RSubLiteratureTag item in G.glb.lstSubLiteratureTag)
                //{
                //    string sql = "INSERT INTO Relation_SubLiteratureTag (" +
                //        "Tag, " +
                //        "FatherGUID, " +
                //        "SubTag, " +
                //        "SubGUID, " +
                //        "Ordering) VALUES (";
                //    sql += "'" + Convert.ToString(item.Tag).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.FatherGUID).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.SubTag).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.SubGUID).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Ordering).Replace("'", "''") + "'";
                //    sql += ");";

                //    cmd = new SQLiteCommand(sql, con);
                //    cmd.ExecuteNonQuery();
                //}

                //// LiteratureAuthor
                //clc = new SQLiteCommand("DELETE FROM Relation_LiteratureAuthor;", con);
                //clc.ExecuteNonQuery();
                //foreach (RLiteratureAuthor item in G.glb.lstLiteratureAuthor)
                //{
                //    string sql = "INSERT INTO Relation_LiteratureAuthor (" +
                //        "Title, " +
                //        "Author, " +
                //        "Ordering) VALUES (";
                //    sql += "'" + Convert.ToString(item.Title).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Author).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Ordering).Replace("'", "''") + "'";
                //    sql += ");";

                //    cmd = new SQLiteCommand(sql, con);
                //    cmd.ExecuteNonQuery();
                //}

                //// LiteratureTag
                //clc = new SQLiteCommand("DELETE FROM Relation_LiteratureTag;", con);
                //clc.ExecuteNonQuery();
                //foreach (RLiteratureTag item in G.glb.lstLiteratureTag)
                //{
                //    string sql = "INSERT INTO Relation_LiteratureTag (" +
                //        "Title, " +
                //        "Tag) VALUES (";
                //    sql += "'" + Convert.ToString(item.Title).Replace("'", "''") + "', ";
                //    sql += "'" + Convert.ToString(item.Tag).Replace("'", "''") + "'";
                //    sql += ");";

                //    cmd = new SQLiteCommand(sql, con);
                //    cmd.ExecuteNonQuery();
                //}

                con.Close();
            }
        }
    }
}
