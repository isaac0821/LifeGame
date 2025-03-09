using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Management.Instrumentation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace LifeGame
{
    public partial class frmInfoNote : Form
    {
        bool modifiedFlag = false;
        Timer curPointerTimer = new Timer();
        DateTime noteDateTime = new DateTime();

        // 先写死，之后改成系统环境变量
        string TDLNoteName = "SysNote: To Do List";

        // 通用信息
        private plot C = new plot();
        public CNote note = new CNote();
        List<RNoteLog> noteLogs = new List<RNoteLog>();
        List<RNoteColor> noteColors = new List<RNoteColor>();
        List<RNoteHierarchy> noteHierarchies = new List<RNoteHierarchy>();
        string topicGUID = "";
        private bool lockMode = false;

        // 如果是Literature用这些存信息
        CLiterature literature = new CLiterature();
        List<RLiteratureAuthor> lstLiteratureAuthor = new List<RLiteratureAuthor>();
        List<RLiteratureTag> lstLiteratureTag = new List<RLiteratureTag>();
        CBibTeX literatureBib = new CBibTeX();

        // 如果是Literature Review
        Dictionary<string, List<Tuple<string, string>>> dicLitReviewTag = new Dictionary<string, List<Tuple<string, string>>>();
        List<string> lstLitReviewTagHirearchy = new List<string>();
        Dictionary<string, List<string>> dictTagValues = new Dictionary<string, List<string>>();

        public ENoteType noteType = ENoteType.Note;

        // 已经有了note之后打开
        public frmInfoNote(CNote info)
        {
            note = info;
            noteLogs = G.glb.lstNoteLog.FindAll(o => o.TagTime == info.TagTime && o.Topic == info.Topic);
            noteColors = G.glb.lstNoteColor.FindAll(o => o.TagTime == info.TagTime && o.Topic == info.Topic);
            noteHierarchies = G.glb.lstNoteHierarchy.FindAll(o => o.TagTime == info.TagTime && o.Topic == info.Topic);
            topicGUID = info.GUID;
            noteType = note.NoteType;

            InitializeComponent();

            if (note.NoteType == ENoteType.DailyReport)
            {
                this.Text = "LifeGame - Daily Report - " + info.TagTime.Date.ToString("dd/MM/yyyy");
                DrawDailySchedule();
                LoadShareNoteLog();

                lblDate.Text = info.TagTime.Date.ToShortDateString();

                // 每一分钟绘制一次当前的时刻
                TimeSpan secToNextMin = new TimeSpan();
                DateTime datetimeWithoutSec = new DateTime(
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    DateTime.Now.Day,
                    DateTime.Now.Hour,
                    DateTime.Now.Minute,
                    0);
                secToNextMin = DateTime.Now - datetimeWithoutSec;
                curPointerTimer.Interval = (int)(1000 * (60 - secToNextMin.TotalSeconds));
                curPointerTimer.Start();
                curPointerTimer.Tick += RefreshDailySchedule;

                splitContainer1.Panel1Collapsed = false;
                splitContainer2.Panel1Collapsed = false;
            }
            else
            {
                this.Text = "LifeGame - Note - " + info.Topic;
                splitContainer1.Panel1Collapsed = true;
                splitContainer2.Panel1Collapsed = true;
            }

            tblNote.RowStyles[1].Height = 0;
            tblNote.RowStyles[2].Height = 0;
            tblNote.RowStyles[3].Height = 0;
            tblNote.RowStyles[4].Height = 0;
            tblNote.RowStyles[5].Height = 0;
            tblNote.RowStyles[6].Height = 0;
            tblNote.RowStyles[7].Height = 0;

            chkShow.Checked = false;

            LoadNoteColor(noteColors);
            LoadNoteLog();
            noteDateTime = note.TagTime;
            txtTopic.Enabled = false;
            btnSave.Enabled = false;
            lockMode = info.Locked;

            if (lockMode)
            {
                btnRead.Enabled = false;
                btnWrite.Enabled = false;
                btnSave.Enabled = false;
                btnLock.Text = "Unlock";
                trvNote.Hide();
            }
            else
            {
                btnRead.Enabled = true;
                btnWrite.Enabled = true;
                btnSave.Enabled = true;
                btnLock.Text = "Lock";
                trvNote.Show();
            }
        }

        public frmInfoNote(CLiterature lit)
        {
            literature = lit;
            string litTitle = lit.Title;
            lstLiteratureTag = G.glb.lstLiteratureTag.FindAll(o => o.Title == litTitle).ToList();
            lstLiteratureAuthor = G.glb.lstLiteratureAuthor.FindAll(o => o.Title == litTitle).ToList();
            lstLiteratureAuthor = lstLiteratureAuthor.OrderBy(o => o.Rank).ToList();
            literatureBib = literature.BibTeX;

            InitializeComponent();

            noteType = ENoteType.Literature;

            tblNote.RowStyles[1].Height = 0;
            tblNote.RowStyles[2].Height = 26;
            tblNote.RowStyles[3].Height = 26;
            tblNote.RowStyles[4].Height = 26;
            tblNote.RowStyles[5].Height = 120;
            tblNote.RowStyles[6].Height = 100;
            tblNote.RowStyles[7].Height = 0;

            chkShow.Checked = true;

            CNote info = G.glb.lstNote.Find(o => o.LiteratureTitle == lit.Title);
            note = info;
            noteLogs = G.glb.lstNoteLog.FindAll(o => o.TagTime == info.TagTime && o.Topic == info.Topic);
            noteColors = G.glb.lstNoteColor.FindAll(o => o.TagTime == info.TagTime && o.Topic == info.Topic);
            noteHierarchies = G.glb.lstNoteHierarchy.FindAll(o => o.TagTime == info.TagTime && o.Topic == info.Topic);
            topicGUID = info.GUID;

            this.Text = "LifeGame - Literature - " + lit.Title;

            LoadNoteColor(noteColors);
            LoadNoteLog();
            LoadLiterature();

            if (txtTitle.Enabled)
            {
                this.ActiveControl = txtTitle;
            }
            List<string> journalList = new List<string>();
            foreach (CLiterature l in G.glb.lstLiterature)
            {
                if (!journalList.Exists(o => o == l.JournalOrConferenceName))
                {
                    journalList.Add(l.JournalOrConferenceName);
                }
            }
            journalList.Sort();
            foreach (string jour in journalList)
            {
                cbxJournalConference.Items.Add(jour);
            }

            //靠！！气死了，白写了，谷歌学术会检查是不是机器人...咋绕过去呢...
            //try
            //{
            //    string url = "https://scholar.google.com/scholar?hl=en&as_sdt=0%2C33&q=" + txtTitle.Text.Replace(" ", "+") + "&btnG=";
            //    WebRequest request = WebRequest.Create(url);
            //    WebResponse response = request.GetResponse();
            //    StreamReader reader = new StreamReader(response.GetResponseStream());
            //    string htmlStr = reader.ReadToEnd();
            //    reader.Close();
            //    response.Close();
            //    Regex citation = new Regex(@"(Cited)\s(by)\s[0-9]*");
            //    bool cite = citation.IsMatch(htmlStr);
            //    Match m = citation.Match(htmlStr);
            //    lblCited.Text = m.ToString();
            //}
            //catch (Exception)
            //{
            //    lblCited.Text = "NaN";
            //}

            noteDateTime = note.TagTime;
            txtTopic.Enabled = false;
            btnSave.Enabled = false;
            lockMode = info.Locked;

            splitContainer1.Panel1Collapsed = true;
            splitContainer2.Panel1Collapsed = true;

            if (lockMode)
            {
                btnRead.Enabled = false;
                btnWrite.Enabled = false;
                btnSave.Enabled = false;
                btnLock.Text = "Unlock";
                trvNote.Hide();
            }
            else
            {
                btnRead.Enabled = true;
                btnWrite.Enabled = true;
                btnSave.Enabled = true;
                btnLock.Text = "Lock";
                trvNote.Show();
            }
        }

        // 新建空Literature
        public frmInfoNote()
        {
            InitializeComponent();

            noteType = ENoteType.Literature;

            tblNote.RowStyles[1].Height = 0;
            tblNote.RowStyles[2].Height = 26;
            tblNote.RowStyles[3].Height = 26;
            tblNote.RowStyles[4].Height = 26;
            tblNote.RowStyles[5].Height = 120;
            tblNote.RowStyles[6].Height = 100;
            tblNote.RowStyles[7].Height = 0;

            chkShow.Checked = true;

            note = new CNote();
            noteLogs = new List<RNoteLog>();
            noteColors = new List<RNoteColor>();
            noteHierarchies = new List<RNoteHierarchy>();

            literature = new CLiterature();
            lstLiteratureAuthor = new List<RLiteratureAuthor>();
            lstLiteratureTag = new List<RLiteratureTag>();
            literatureBib = new CBibTeX();

            topicGUID = Guid.NewGuid().ToString();
            note.GUID = topicGUID;
            note.TagTime = DateTime.Today.Date;

            splitContainer1.Panel1Collapsed = true;
            splitContainer2.Panel1Collapsed = true;

            List<string> journalList = new List<string>();
            foreach (CLiterature l in G.glb.lstLiterature)
            {
                if (!journalList.Exists(o => o == l.JournalOrConferenceName))
                {
                    journalList.Add(l.JournalOrConferenceName);
                }
            }
            journalList.Sort();
            foreach (string jour in journalList)
            {
                cbxJournalConference.Items.Add(jour);
            }

            this.Text = "LifeGame - Literature - (New)";

            LoadNoteColor(noteColors);
            LoadNoteLog();
            noteDateTime = DateTime.Today.Date;
            btnSave.Enabled = true;

            splitContainer1.Panel1Collapsed = true;
            splitContainer2.Panel1Collapsed = true;
        }

        // 新建空note
        public frmInfoNote(DateTime selectedDate)
        {
            InitializeComponent();

            noteType = ENoteType.Note;

            tblNote.RowStyles[1].Height = 26;
            tblNote.RowStyles[2].Height = 0;
            tblNote.RowStyles[3].Height = 0;
            tblNote.RowStyles[4].Height = 0;
            tblNote.RowStyles[5].Height = 0;
            tblNote.RowStyles[6].Height = 100;
            tblNote.RowStyles[7].Height = 0;

            chkShow.Checked = true;

            note = new CNote();
            noteLogs = new List<RNoteLog>();
            noteColors = new List<RNoteColor>();
            noteHierarchies = new List<RNoteHierarchy>();

            topicGUID = Guid.NewGuid().ToString();
            note.GUID = topicGUID;
            note.TagTime = selectedDate;

            splitContainer1.Panel1Collapsed = true;
            splitContainer2.Panel1Collapsed = true;

            this.Text = "LifeGame - Note - (New)";

            LoadNoteColor(noteColors);
            LoadNoteLog();
            noteDateTime = selectedDate;
            btnSave.Enabled = true;

            splitContainer1.Panel1Collapsed = true;
            splitContainer2.Panel1Collapsed = true;
        }

        public frmInfoNote(DateTime selectedDate, bool DiaryFlag)
        {
            InitializeComponent();

            note = new CNote();
            note.Topic = "Daily Report";
            topicGUID = Guid.NewGuid().ToString();
            note.GUID = topicGUID;
            note.TagTime = selectedDate.Date;

            noteType = ENoteType.DailyReport;

            tblNote.RowStyles[1].Height = 0;
            tblNote.RowStyles[2].Height = 0;
            tblNote.RowStyles[3].Height = 0;
            tblNote.RowStyles[4].Height = 0;
            tblNote.RowStyles[5].Height = 0;
            tblNote.RowStyles[6].Height = 0;
            tblNote.RowStyles[7].Height = 0;

            chkShow.Checked = false;

            this.Text = "LifeGame - Daily Report - " + selectedDate.Date.ToString("dd/MM/yyyy");
            lblDate.Text = selectedDate.ToShortDateString();
            DrawDailySchedule();
            LoadShareNoteLog();

            // 每一分钟绘制一次当前的时刻
            TimeSpan secToNextMin = new TimeSpan();
            DateTime datetimeWithoutSec = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                DateTime.Now.Hour,
                DateTime.Now.Minute,
                0);
            secToNextMin = DateTime.Now - datetimeWithoutSec;
            curPointerTimer.Interval = (int)(1000 * (60 - secToNextMin.TotalSeconds));
            curPointerTimer.Start();
            curPointerTimer.Tick += RefreshDailySchedule;

            // 加入template
            RNoteColor planning = new RNoteColor();
            planning.Topic = note.Topic;
            planning.Keyword = "[Planning]";
            planning.Color = "Cyan";
            planning.TagTime = DateTime.Today.Date;
            noteColors.Add(planning);

            RNoteColor mapped = new RNoteColor();
            mapped.Topic = note.Topic;
            mapped.Keyword = "[Mapped]";
            mapped.Color = "Red";
            mapped.TagTime = DateTime.Today.Date;
            noteColors.Add(mapped);

            RNoteColor done = new RNoteColor();
            done.Topic = note.Topic;
            done.Keyword = "[Done]";
            done.Color = "Green";
            done.TagTime = DateTime.Today.Date;
            noteColors.Add(done);

            noteLogs = new List<RNoteLog>();
            RNoteLog bure = new RNoteLog();
            bure.Topic = note.Topic;
            bure.TopicGUID = topicGUID;
            bure.Log = note.Topic;
            bure.GUID = topicGUID;
            bure.SubLog = "Bureaucracy";
            bure.SubGUID = Guid.NewGuid().ToString();
            bure.TagTime = DateTime.Today.Date;
            bure.Index = 0;
            noteLogs.Add(bure);

            RNoteLog social = new RNoteLog();
            social.Topic = note.Topic;
            social.TopicGUID = topicGUID;
            social.Log = note.Topic;
            social.GUID = topicGUID;
            social.SubLog = "Social";
            social.SubGUID = Guid.NewGuid().ToString();
            social.TagTime = DateTime.Today.Date;
            social.Index = 1;
            noteLogs.Add(social);

            RNoteLog project = new RNoteLog();
            project.Topic = note.Topic;
            project.TopicGUID = topicGUID;
            project.Log = note.Topic;
            project.GUID = topicGUID;
            project.SubLog = "Project";
            project.SubGUID = Guid.NewGuid().ToString();
            project.TagTime = DateTime.Today.Date;
            project.Index = 2;
            noteLogs.Add(project);

            RNoteLog research = new RNoteLog();
            research.Topic = note.Topic;
            research.TopicGUID = topicGUID;
            research.Log = note.Topic;
            research.GUID = topicGUID;
            research.SubLog = "Research";
            research.SubGUID = Guid.NewGuid().ToString();
            research.TagTime = DateTime.Today.Date;
            research.Index = 3;
            noteLogs.Add(research);

            RNoteLog transaction = new RNoteLog();
            transaction.Topic = note.Topic;
            transaction.TopicGUID = topicGUID;
            transaction.Log = note.Topic;
            transaction.GUID = topicGUID;
            transaction.SubLog = "Transaction";
            transaction.SubGUID = Guid.NewGuid().ToString();
            transaction.TagTime = DateTime.Today.Date;
            transaction.Index = 4;
            noteLogs.Add(transaction);

            noteHierarchies = new List<RNoteHierarchy>();

            LoadNoteColor(noteColors);
            LoadNoteLog();
            noteDateTime = selectedDate;
            btnSave.Enabled = true;
            txtTopic.Text = "Daily Report";

            splitContainer1.Panel1Collapsed = false;
            splitContainer2.Panel1Collapsed = false;
        }

        public frmInfoNote(string topic, List<string> lstLiterature)
        {
            InitializeComponent();

            note = new CNote();
            note.Topic = topic;
            topicGUID = Guid.NewGuid().ToString();
            note.GUID = topicGUID;
            note.TagTime = DateTime.Today.Date;

            noteType = ENoteType.LitReview;

            tblNote.RowStyles[1].Height = 26;
            tblNote.RowStyles[2].Height = 0;
            tblNote.RowStyles[3].Height = 0;
            tblNote.RowStyles[4].Height = 0;
            tblNote.RowStyles[5].Height = 0;
            tblNote.RowStyles[6].Height = 100;
            tblNote.RowStyles[7].Height = 26;

            chkShow.Checked = true;

            this.Text = "LifeGame - LitReview - " + note.Topic;

            TreeNode rootNode = new TreeNode();
            rootNode.Name = Guid.NewGuid().ToString();
            rootNode.Text = "Literature Review: " + topic;
            trvNote.Nodes.Add(rootNode);

            for (int i = 0; i < lstLiterature.Count; i++)
            {
                TreeNode litNode = new TreeNode();
                litNode.Name = Guid.NewGuid().ToString();
                litNode.Text = "$LITR$>" + lstLiterature[i];
                (litNode.BackColor, litNode.ForeColor, litNode.NodeFont) = getColor("$LITR$>" + lstLiterature[i]);
                litNode.StateImageIndex = getLogo("$LITR$>" + lstLiterature[i]);

                TreeNode yearNode = new TreeNode("year", 0, 0);
                yearNode.Name = Guid.NewGuid().ToString();
                yearNode.Text = "year: " + G.glb.lstLiterature.Find(o => o.Title == lstLiterature[i]).PublishYear.ToString();
                litNode.Nodes.Add(yearNode);

                TreeNode jourNode = new TreeNode("", 0, 0);
                jourNode.Name = Guid.NewGuid().ToString();
                jourNode.Text = "jourConf: " + G.glb.lstLiterature.Find(o => o.Title == lstLiterature[i]).JournalOrConferenceName;
                litNode.Nodes.Add(jourNode);

                List<RLiteratureAuthor> authors = new List<RLiteratureAuthor>();
                authors = G.glb.lstLiteratureAuthor.FindAll(o => o.Title == lstLiterature[i]).ToList();
                foreach (RLiteratureAuthor author in authors)
                {
                    TreeNode authorNode = new TreeNode(author.Author, 0, 0);
                    authorNode.Name = Guid.NewGuid().ToString();
                    authorNode.Text = "author: " + author.Author;
                    litNode.Nodes.Add(authorNode);
                }

                List<RLiteratureTag> tags = new List<RLiteratureTag>();
                tags = G.glb.lstLiteratureTag.FindAll(o => o.Title == lstLiterature[i]).ToList();
                foreach (RLiteratureTag tag in tags)
                {
                    TreeNode tagNode = new TreeNode(tag.Tag, 0, 0);
                    tagNode.Name = Guid.NewGuid().ToString();
                    tagNode.Text = "tag: " + tag.Tag;
                    litNode.Nodes.Add(tagNode);
                }
                trvNote.Nodes[0].Nodes.Add(litNode);
            }

            noteColors = new List<RNoteColor>();
            RNoteColor unread = new RNoteColor();
            unread.Topic = topic;
            unread.Keyword = "[Unread]";
            unread.Color = "Red";
            unread.TagTime = DateTime.Today.Date;
            noteColors.Add(unread);

            RNoteColor reading = new RNoteColor();
            reading.Topic = topic;
            reading.Keyword = "[Reading]";
            reading.Color = "Orange";
            reading.TagTime = DateTime.Today.Date;
            noteColors.Add(reading);

            RNoteColor read = new RNoteColor();
            read.Topic = topic;
            read.Keyword = "[Read]";
            read.Color = "Green";
            read.TagTime = DateTime.Today.Date;
            noteColors.Add(read);

            RNoteColor revisit = new RNoteColor();
            revisit.Topic = topic;
            revisit.Keyword = "[Revisit]";
            revisit.Color = "Orange";
            revisit.TagTime = DateTime.Today.Date;
            noteColors.Add(revisit);

            noteHierarchies = new List<RNoteHierarchy>();

            // LoadNoteTag();
            LoadNoteColor(noteColors);
            //LoadNoteLog();
            txtTopic.Text = topic;
            noteDateTime = DateTime.Today.Date;
            btnSave.Enabled = true;

            splitContainer1.Panel1Collapsed = true;
            splitContainer2.Panel1Collapsed = true;
        }

        private void RefreshDailySchedule(object sender, EventArgs e)
        {
            curPointerTimer.Interval = 1000 * 60;
            DrawDailySchedule();
        }

        private void LoadNoteColor(List<RNoteColor> noteColorSource)
        {
            lsvColor.Items.Clear();
            foreach (RNoteColor noteColor in noteColorSource)
            {
                ListViewItem item = new ListViewItem();
                item.Text = noteColor.Keyword;
                item.BackColor = C.GetColor(noteColor.Color);
                if (noteColor.Color == "Red" || noteColor.Color == "Green" || noteColor.Color == "Blue" || noteColor.Color == "DarkGreen" || noteColor.Color == "Brown")
                {
                    item.ForeColor = Color.White;
                }
                else
                {
                    item.ForeColor = Color.Black;
                }
                lsvColor.Items.Add(item);
            }
        }

        private void LoadNoteLog()
        {
            trvNote.Nodes.Clear();
            TreeNode rootNode = new TreeNode(note.Topic, 0, 0);
            rootNode.Name = note.GUID;
            rootNode.Text = note.Topic;
            rootNode.Expand();
            LoadChildNoteLog(rootNode, note.Topic);
            trvNote.Nodes.Add(rootNode);
        }

        private void LoadShareNoteLog()
        {
            trvShare.Nodes.Clear();
            TreeNode rootNode = new TreeNode(TDLNoteName, 0, 0);
            rootNode.Name = G.glb.lstNote.Find(o => o.Topic == TDLNoteName).GUID;
            rootNode.Text = TDLNoteName;
            rootNode.Expand();
            List<RNoteColor> sysNoteColor = G.glb.lstNoteColor.FindAll(o => o.Topic == TDLNoteName);
            LoadChildNoteLog(rootNode, TDLNoteName, G.glb.lstNoteLog, sysNoteColor);
            trvShare.Nodes.Add(rootNode);
        }

        private void LoadNoteHierarchy()
        {
            trvHierarchy.Nodes.Clear();

        }

        private int getLogo(string noteText)
        {
            if (noteText.Contains("ddl: ") || noteText.Contains("DDL: ") || noteText.Contains("Date: ") || noteText.Contains("date: "))
            {
                return 14;
            }
            else if (noteText.Contains("$LINK$>"))
            {
                string selectedPath = noteText.Split('@')[0];
                selectedPath = selectedPath.Replace("$LINK$>", "");
                string[] checkUrl = selectedPath.Split(':');
                if (checkUrl[0] == "http" || checkUrl[0] == "https")
                {
                    return 0;
                }
                else
                {
                    try
                    {
                        if (File.Exists(selectedPath))
                        {
                            return 0;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    catch (Exception)
                    {
                        return 1;
                    }
                }
            }
            else if (noteText.Contains("$NOTE$>"))
            {
                string selectedPath = noteText.Replace("$NOTE$>", "");
                string[] checkNote = selectedPath.Split('@');
                DateTime noteDate = new DateTime();
                string noteTitle = "";
                bool tryOpenFlag = true;
                if (checkNote.Length != 2)
                {
                    return 3;
                }
                else
                {
                    string[] dateNote = checkNote[0].Split('.');
                    if (dateNote.Length != 3)
                    {
                        return 3;
                    }
                    else
                    {
                        noteDate = new DateTime(Convert.ToInt32(dateNote[0]), Convert.ToInt32(dateNote[1]), Convert.ToInt32(dateNote[2]));
                    }
                }

                for (int i = 1; i < checkNote.Length; i++)
                {
                    noteTitle = noteTitle + checkNote[i];
                    if (i < checkNote.Length - 1)
                    {
                        noteTitle = noteTitle + " ";
                    }
                }
                if (tryOpenFlag && G.glb.lstNote.Exists(o => o.TagTime == noteDate && o.Topic == noteTitle))
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }
            else if (noteText.Contains("$JUMP$>"))
            {
                return 4;
            }
            else if (noteText.Contains("$LITR$>"))
            {
                string selectedPath = noteText.Split('@')[0];
                selectedPath = selectedPath.Replace("$LITR$>", "");
                if (G.glb.lstLiterature.Exists(o => o.Title == selectedPath))
                {
                    return 6;
                }
                else if (G.glb.lstLiterature.Exists(o => o.BibKey == selectedPath))
                {
                    return 6;
                }
                else
                {
                    return 7;
                }
            }
            else if (noteText.Contains("$SCHL$>"))
            {
                string sch = noteText.Replace("$SCHL$>", "");
                string[] sp = sch.Split('@');
                if (sp.Length < 3)
                {
                    return 9;
                }
                else
                {
                    try
                    {
                        // Log Name
                        string LogName = sp[0];
                        // Time
                        bool addOneDayFlag = sp[1].Contains("(+1)");
                        if (addOneDayFlag)
                        {
                            sp[1] = sp[1].Replace("(+1)", "");
                        }
                        string[] schTimeStr = sp[1].Split('-');
                        string[] schStartStr = schTimeStr[0].Split(':');
                        string[] schEndStr = schTimeStr[1].Split(':');
                        DateTime StartTime = new DateTime(
                            Convert.ToInt32(note.TagTime.Year), Convert.ToInt32(note.TagTime.Month), Convert.ToInt32(note.TagTime.Day),
                            Convert.ToInt32(schStartStr[0]), Convert.ToInt32(schStartStr[1]), 0);
                        DateTime EndTime = new DateTime(
                            Convert.ToInt32(note.TagTime.Year), Convert.ToInt32(note.TagTime.Month), Convert.ToInt32(note.TagTime.Day),
                            Convert.ToInt32(schEndStr[0]), Convert.ToInt32(schEndStr[1]), 0);
                        if (addOneDayFlag)
                        {
                            EndTime += new TimeSpan(1, 0, 0, 0);
                        }
                        // Color
                        string Color = sp[2];
                        // Location
                        string Location = "";
                        if (sp.Length >= 4)
                        {
                            Location = sp[3];
                        }
                        // With
                        string WithWho = "";
                        if (sp.Length >= 5)
                        {
                            WithWho = sp[4];
                        }

                        if (G.glb.lstSchedule.Exists(o =>
                            o.LogName == LogName
                            && o.StartTime == StartTime
                            && o.EndTime == EndTime
                            && o.Location == Location
                            && o.WithWho == WithWho
                            && o.Color == Color))
                        {
                            return 8;
                        }
                        else
                        {
                            return 9;
                        }
                    }
                    catch
                    {
                        return 9;
                    }
                }
            }
            else if (noteText.Contains("$RECO$>"))
            {
                string sch = noteText.Replace("$RECO$>", "");
                string[] sp = sch.Split('@');
                if (sp.Length < 3)
                {
                    return 11;
                }
                else
                {
                    try
                    {
                        // Log Name
                        string LogName = sp[0];
                        // Time
                        bool addOneDayFlag = sp[1].Contains("(+1)");
                        if (addOneDayFlag)
                        {
                            sp[1] = sp[1].Replace("(+1)", "");
                        }
                        string[] schTimeStr = sp[1].Split('-');
                        string[] schStartStr = schTimeStr[0].Split(':');
                        string[] schEndStr = schTimeStr[1].Split(':');
                        DateTime StartTime = new DateTime(
                            Convert.ToInt32(note.TagTime.Year), Convert.ToInt32(note.TagTime.Month), Convert.ToInt32(note.TagTime.Day),
                            Convert.ToInt32(schStartStr[0]), Convert.ToInt32(schStartStr[1]), 0);
                        DateTime EndTime = new DateTime(
                            Convert.ToInt32(note.TagTime.Year), Convert.ToInt32(note.TagTime.Month), Convert.ToInt32(note.TagTime.Day),
                            Convert.ToInt32(schEndStr[0]), Convert.ToInt32(schEndStr[1]), 0);
                        if (addOneDayFlag)
                        {
                            EndTime += new TimeSpan(1, 0, 0, 0);
                        }
                        // Color
                        string Color = sp[2];
                        // Location
                        string Location = "";
                        if (sp.Length >= 4)
                        {
                            Location = sp[3];
                        }
                        // With
                        string WithWho = "";
                        if (sp.Length >= 5)
                        {
                            WithWho = sp[4];
                        }

                        if (G.glb.lstLog.Exists(o =>
                            o.LogName == LogName
                            && o.StartTime == StartTime
                            && o.EndTime == EndTime
                            && o.Location == Location
                            && o.WithWho == WithWho
                            && o.Color == Color))
                        {
                            return 10;
                        }
                        else
                        {
                            return 11;
                        }
                    }
                    catch
                    {
                        return 11;
                    }
                }
            }
            else if (noteText.Contains("$TRSA$>"))
            {
                try
                {
                    string transactionSeg = noteText.Replace("$TRSA$>", "");
                    transactionSeg = transactionSeg.Replace("=>", "@");
                    string[] transactionNote = transactionSeg.Split('@');
                    string accountFrom = transactionNote[2];
                    string accountTo = transactionNote[3];
                    if (G.glb.lstTransaction.Exists(o => o.TagTime == note.TagTime && o.Summary == transactionNote[0]))
                    {
                        return 12;
                    }
                    else
                    {
                        return 13;
                    }
                }
                catch
                {
                    return 13;
                }
            }
            else
            {
                return -1;
            }
        }

        private (Color, Color, Font) getColor(string note, List<RNoteColor> noteColorsource)
        {
            Color BackColor = new Color();
            Color ForeColor = new Color();
            Font TextFont = new Font(Font, FontStyle.Regular);

            BackColor = Color.White;
            foreach (RNoteColor color in noteColorsource)
            {
                if (note.Contains(color.Keyword))
                {
                    string itemColor = color.Color;
                    BackColor = C.GetColor(itemColor);
                    // 看看有没有带百分号
                    int percentVal = 100;
                    if (note.Contains("%") && note.ToCharArray().Count(c => c == '%') == 1)
                    {
                        string percentStr = Regex.Match(note, @"(?<num>\d+)(?:\%)").Groups["num"].Value;
                        if (percentStr != "")
                        {
                            int percent = Convert.ToInt32(percentStr);
                            if (percent >= 100)
                            {
                                percent = 100;
                            }
                            percentVal = percent;
                            percent = percent * 4 / 5;
                            percent = 80 - percent;
                            int R = (int)((255 - BackColor.R) * (percent / 100.0)) + BackColor.R;
                            int G = (int)((255 - BackColor.G) * (percent / 100.0)) + BackColor.G;
                            int B = (int)((255 - BackColor.B) * (percent / 100.0)) + BackColor.B;
                            BackColor = Color.FromArgb(R, G, B);
                        }
                    }
                    if (itemColor == "Red" || itemColor == "Green" || itemColor == "Blue" || itemColor == "DarkGreen" || itemColor == "Brown" || itemColor == "Purple")
                    {
                        if (percentVal <= 50)
                        {
                            ForeColor = Color.Black;
                        }
                        else
                        {
                            ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        ForeColor = Color.Black;
                    }
                }
            }
            if (note.Contains("$LINK$>"))
            {
                ForeColor = Color.Blue;
                TextFont = new Font(Font, FontStyle.Underline);
            }
            else if (note.Contains("$LITR$>"))
            {
                ForeColor = Color.Brown;
                TextFont = new Font(Font, FontStyle.Underline);
            }
            else if (note.Contains("$NOTE$>"))
            {
                ForeColor = Color.DarkGreen;
                TextFont = new Font(Font, FontStyle.Underline);
            }
            else if (note.Contains("$JUMP$>"))
            {
                ForeColor = Color.Indigo;
                TextFont = new Font(Font, FontStyle.Bold);
            }
            else if (note.Contains("$SCHL$>"))
            {
                ForeColor = Color.Orange;
                TextFont = new Font(Font, FontStyle.Underline);
            }
            else if (note.Contains("$RECO$>"))
            {
                ForeColor = Color.Orchid;
                TextFont = new Font(Font, FontStyle.Underline);
            }
            else if (note.Contains("$TRSA$>"))
            {
                Color transactionColor = Color.Gray;
                try
                {
                    string transactionSeg = note.Replace("$TRSA$>", "");
                    transactionSeg = transactionSeg.Replace("=>", "@");
                    string[] transactionNote = transactionSeg.Split('@');
                    string accountFrom = transactionNote[2];
                    string accountTo = transactionNote[3];
                    if (G.glb.lstAccount.Exists(o => o.AccountName == accountFrom) && G.glb.lstAccount.Exists(o => o.AccountName == accountTo))
                    {
                        // 如果To账目是支出账目，表示这是支出
                        if (G.glb.lstAccount.Find(o => o.AccountName == accountTo).AccountType == EAccountType.Expense)
                        {
                            transactionColor = Color.Red;
                        }
                        // 如果From账目是收入账目，表示这是收入
                        else if (G.glb.lstAccount.Find(o => o.AccountName == accountFrom).AccountType == EAccountType.Income)
                        {
                            transactionColor = Color.Green;
                        }
                        else
                        {
                            transactionColor = Color.Navy;
                        }
                    }
                }
                catch { }
                ForeColor = transactionColor;
                TextFont = new Font(Font, FontStyle.Underline);
            }
            else if (note.Split('#').Length == 3)
            {
                ForeColor = Color.Indigo;
                TextFont = new Font(Font, FontStyle.Bold);
            }

            if (note.Contains("ddl: ") || note.Contains("DDL: ") || note.Contains("Date: ") || note.Contains("date: "))
            {
                string dateSeg = "";
                dateSeg = note.Replace("ddl: ", "");
                dateSeg = dateSeg.Replace("DDL: ", "");
                dateSeg = dateSeg.Replace("Date: ", "");
                dateSeg = dateSeg.Replace("date: ", "");
                string[] dateNote = dateSeg.Split('.');
                DateTime noteDate = new DateTime();
                try
                {
                    noteDate = new DateTime(Convert.ToInt32(dateNote[0]), Convert.ToInt32(dateNote[1]), Convert.ToInt32(dateNote[2]));

                    if (noteDate - DateTime.Today >= TimeSpan.FromDays(30))
                    {
                        BackColor = Color.Green;
                    }
                    else if (noteDate - DateTime.Today >= TimeSpan.FromDays(7))
                    {
                        BackColor = Color.Yellow;
                    }
                    else if (noteDate - DateTime.Today >= TimeSpan.FromDays(3))
                    {
                        BackColor = Color.Orange;
                    }
                    else if (noteDate - DateTime.Today >= TimeSpan.FromDays(0))
                    {
                        BackColor = Color.Red;
                    }
                    else
                    {
                        BackColor = Color.LightGray;
                    }
                }
                catch { }
            }
            else if (note.Contains("modified: ") || note.Contains("Modified: ") || note.Contains("MODIFIED: "))
            {
                BackColor = Color.Pink;
                TextFont = new Font(Font, FontStyle.Bold);
            }
            return (BackColor, ForeColor, TextFont);
        }

        private (Color, Color, Font) getColor(string note)
        {
            return getColor(note, noteColors);
        }

        private void LoadChildNoteLog(TreeNode treeNode, string topic, List<RNoteLog> noteSource, List<RNoteColor> noteColorSource)
        {
            // 如果本条NoteLog作为上级NoteLog存在，添加所有的SubLog
            if (noteSource.Exists(o => o.Log == treeNode.Text && o.GUID == treeNode.Name && o.Topic == topic))
            {
                List<RNoteLog> subNoteLog = noteSource.FindAll(o => o.Log == treeNode.Text && o.GUID == treeNode.Name && o.Topic == topic).ToList();
                subNoteLog = subNoteLog.OrderBy(o => o.Index).ToList();
                foreach (RNoteLog sub in subNoteLog)
                {
                    TreeNode childNode = new TreeNode(sub.SubLog);
                    childNode.Name = sub.SubGUID;
                    childNode.Text = sub.SubLog;
                    childNode.BackColor = SystemColors.Window;
                    childNode.ForeColor = Color.Black;
                    if (sub.IsExpand)
                    {
                        childNode.Expand();
                    }
                    childNode.StateImageIndex = getLogo(sub.SubLog);
                    if (highlightText != "" && sub.SubLog.Contains(highlightText))
                    {
                        childNode.ForeColor = Color.Black;
                        childNode.BackColor = Color.OrangeRed;
                    }
                    else
                    {
                        (childNode.BackColor, childNode.ForeColor, childNode.NodeFont) = getColor(sub.SubLog, noteColorSource);
                        // 看看子note中有没有着色label
                        if (childNode.Text.Contains("color: ") || childNode.Text.Contains("status: ") || childNode.Text.Contains("Color: ") || childNode.Text.Contains("Status: "))
                        {
                            treeNode.BackColor = childNode.BackColor;
                            treeNode.ForeColor = childNode.ForeColor;
                            treeNode.NodeFont = childNode.NodeFont;
                        }
                    }
                    LoadChildNoteLog(childNode, topic, noteSource, noteColorSource);
                    treeNode.Nodes.Add(childNode);
                }
            }
        }

        private void LoadChildNoteLog(TreeNode treeNode, string topic)
        {
            LoadChildNoteLog(treeNode, topic, noteLogs, noteColors);
        }

        private void UpdateModifiedTime(TreeNode node)
        {
            DateTime now = DateTime.Now;
            foreach (TreeNode sub in node.Nodes)
            {
                if (sub.Text.Contains("modified: "))
                {
                    sub.Text = "modified: " + now.ToString("F"); break;
                }
                else if (sub.Text.Contains("Modified: "))
                {
                    sub.Text = "Modified: " + now.ToString("F"); break;
                }
                else if (sub.Text.Contains("MODIFIED: "))
                {
                    sub.Text = "MODIFIED: " + now.ToString("F"); break;
                }
            }
        }

        private void UpdateModifiedNodeTime(TreeNode node)
        {
            UpdateModifiedTime(node);
            if (node.Parent != null)
            {
                UpdateModifiedNodeTime(node.Parent);
            }
        }

        private void SaveNoteLog()
        {
            noteLogs = new List<RNoteLog>();
            foreach (TreeNode child in trvNote.Nodes[0].Nodes)
            {
                SaveChildNoteLog(child);
            }
        }

        private void SaveChildNoteLog(TreeNode treeNode)
        {
            RNoteLog newNoteLog = new RNoteLog();
            newNoteLog.Topic = txtTopic.Text;
            newNoteLog.TopicGUID = topicGUID;
            newNoteLog.TagTime = noteDateTime;
            newNoteLog.Log = treeNode.Parent.Text;
            newNoteLog.GUID = treeNode.Parent.Name;
            newNoteLog.SubLog = treeNode.Text;
            newNoteLog.SubGUID = treeNode.Name;
            newNoteLog.IsExpand = treeNode.IsExpanded;
            newNoteLog.Index = treeNode.Index;
            noteLogs.Add(newNoteLog);
            foreach (TreeNode child in treeNode.Nodes)
            {
                SaveChildNoteLog(child);
            }
        }

        private void SaveLiterature()
        {
            bool CanSaveFlag = true;
            if (modifiedFlag)
            {
                if (txtTitle.Text == "")
                {
                    MessageBox.Show("Title is missing.");
                    CanSaveFlag = false;
                }
                if (G.glb.lstLiterature.Exists(o => o.Title == txtTitle.Text) && txtTitle.Enabled == true)
                {
                    MessageBox.Show("Literature exists.");
                    CanSaveFlag = false;
                }
                if (G.glb.lstLiterature.Exists(o => o.BibKey != "" && o.BibKey == txtBibKey.Text && o.Title != txtTitle.Text))
                {
                    MessageBox.Show("Bibkey exists.");
                    CanSaveFlag = false;
                }
                if (txtYear.Text == "")
                {
                    MessageBox.Show("Publish year is missing");
                    CanSaveFlag = false;
                }
                if (cbxJournalConference.Text == "")
                {
                    MessageBox.Show("Journal/Conference Name is missing");
                    CanSaveFlag = false;
                }
                if (lsbAuthor.Items.Count == 0)
                {
                    MessageBox.Show("Add author");
                    CanSaveFlag = false;
                }
                if (lsbTag.Items.Count == 0)
                {
                    MessageBox.Show("Add tag");
                    CanSaveFlag = false;
                }
                if (CanSaveFlag)
                {
                    // 如果本来没有这篇文献，说明是新增文献，否则是删改文献
                    if (!G.glb.lstLiterature.Exists(o => o.Title == txtTitle.Text))
                    {
                        CLiterature newLiterature = new CLiterature();
                        newLiterature.Title = txtTitle.Text;
                        newLiterature.PublishYear = Convert.ToInt32(txtYear.Text);
                        newLiterature.JournalOrConferenceName = cbxJournalConference.Text;
                        newLiterature.BibKey = txtBibKey.Text;
                        newLiterature.BibTeX = literatureBib;
                        newLiterature.DateAdded = DateTime.Today;
                        newLiterature.DateModified = DateTime.Today;
                        newLiterature.Star = chkStar.Checked;
                        newLiterature.PredatoryAlert = chkPredatroyAlert.Checked;

                        foreach (RLiteratureAuthor author in lstLiteratureAuthor)
                        {
                            author.Title = txtTitle.Text;
                        }
                        foreach (RLiteratureTag tag in lstLiteratureTag)
                        {
                            tag.Title = txtTitle.Text;
                        }
                        G.glb.lstLiterature.Add(newLiterature);
                        G.glb.lstLiteratureTag.AddRange(lstLiteratureTag);
                        G.glb.lstLiteratureAuthor.AddRange(lstLiteratureAuthor);
                    }
                    else
                    {
                        G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).PublishYear = Convert.ToInt32(txtYear.Text);
                        G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).JournalOrConferenceName = cbxJournalConference.Text;
                        G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).BibKey = txtBibKey.Text;
                        G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).BibTeX = literatureBib;
                        G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).DateModified = DateTime.Today;
                        G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).Star = chkStar.Checked;
                        G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).PredatoryAlert = chkPredatroyAlert.Checked;
                        foreach (RLiteratureAuthor author in lstLiteratureAuthor)
                        {
                            author.Title = txtTitle.Text;
                        }
                        foreach (RLiteratureTag tag in lstLiteratureTag)
                        {
                            tag.Title = txtTitle.Text;
                        }
                        G.glb.lstLiteratureAuthor.RemoveAll(o => o.Title == txtTitle.Text);
                        G.glb.lstLiteratureTag.RemoveAll(o => o.Title == txtTitle.Text);
                        G.glb.lstLiteratureTag.AddRange(lstLiteratureTag);
                        G.glb.lstLiteratureAuthor.AddRange(lstLiteratureAuthor);
                    }
                    modifiedFlag = false;
                    try
                    {
                        // 有可能literature窗口已经关掉了，没法callback
                        RefreshTab();

                        FileStream f = new FileStream("data.dat", FileMode.Create);
                        BinaryFormatter b = new BinaryFormatter();
                        b.Serialize(f, G.glb);
                        f.Close();
                    }
                    catch (Exception)
                    {
                        // 下次打开自然会刷新，所以不用catch
                    }
                    txtTitle.Enabled = false;
                    SaveNote();
                }
                else
                {
                    MessageBox.Show("Missing information, not saved yet.");
                }
            }
        }

        private void SaveNote()
        {
            G.glb.lstNoteLog.RemoveAll(o => o.Topic == note.Topic && o.TagTime == noteDateTime);
            G.glb.lstNoteColor.RemoveAll(o => o.Topic == note.Topic && o.TagTime == noteDateTime);
            SaveNoteLog();
            foreach (RNoteLog noteLog in noteLogs)
            {
                noteLog.Topic = txtTopic.Text;
                noteLog.TagTime = noteDateTime;
                G.glb.lstNoteLog.Add(noteLog);
            }
            foreach (RNoteColor noteColor in noteColors)
            {
                noteColor.Topic = txtTopic.Text;
                noteColor.TagTime = noteDateTime;
                G.glb.lstNoteColor.Add(noteColor);
            }
            if (G.glb.lstNote.Exists(o => o.Topic == note.Topic && o.TagTime == noteDateTime))
            {
                G.glb.lstNote.Find(o => o.Topic == note.Topic && o.TagTime == noteDateTime).TagTime = noteDateTime;
                G.glb.lstNote.Find(o => o.Topic == note.Topic && o.TagTime == noteDateTime).Topic = txtTopic.Text;
                G.glb.lstNote.Find(o => o.Topic == note.Topic && o.TagTime == noteDateTime).LiteratureTitle = txtTitle.Text;
                G.glb.lstNote.Find(o => o.Topic == note.Topic && o.TagTime == noteDateTime).Locked = lockMode;
            }
            else
            {
                CNote newNote = new CNote();
                newNote.Topic = txtTopic.Text;
                newNote.TagTime = noteDateTime;
                newNote.LiteratureTitle = txtTitle.Text;
                newNote.Locked = lockMode;
                newNote.GUID = topicGUID;
                newNote.NoteType = noteType;
                G.glb.lstNote.Add(newNote);
            }

            FileStream f = new FileStream("data.dat", FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(f, G.glb);
            f.Close();
        }

        private void frmInfoNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            M.notesOpened.RemoveAll(o => o.note.Topic == note.Topic && o.note.TagTime == note.TagTime);

            if (noteType == ENoteType.Note || noteType == ENoteType.DailyReport || noteType == ENoteType.System || noteType == ENoteType.LitReview)
            {
                SaveNote();
            }
            else if (noteType == ENoteType.Literature)
            {
                SaveLiterature();
            }
            Dispose();
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        private void frmInfoNote_Load(object sender, EventArgs e)
        {
            if (note.Topic != null && note.LiteratureTitle == "")
            {
                txtTopic.Text = note.Topic;
                chkShow.Checked = false;
            }
        }

        private void DrawDailySchedule()
        {
            plot Draw = new plot();
            picToday.Controls.Clear();
            Draw.DrawEventController(picToday, note.TagTime.Date, G.glb.lstEvent, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
            Draw.DrawScheduleAndLogController(picToday, note.TagTime.Date, G.glb.lstSchedule, "leftWithSupp");
            Draw.DrawScheduleAndLogController(picToday, note.TagTime.Date, G.glb.lstLog, "rightWithSupp");
        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                string newLog = Interaction.InputBox("Input new note node", "New Note", "New Note", 300, 300);
                if (newLog != "")
                {
                    TreeNode newNode = new TreeNode(newLog, 0, 0);
                    newNode.Text = newLog;
                    newNode.Name = Guid.NewGuid().ToString();
                    newNode.BackColor = SystemColors.Window;
                    newNode.ForeColor = Color.Black;
                    newNode.ExpandAll();
                    (newNode.BackColor, newNode.ForeColor, newNode.NodeFont) = getColor(newLog);
                    newNode.StateImageIndex = getLogo(newLog);
                    trvNote.SelectedNode.Nodes.Add(newNode);
                    if (trvNote.SelectedNode.Nodes.Count == 1)
                    {
                        trvNote.SelectedNode.ExpandAll();
                    }
                    UpdateModifiedNodeTime(trvNote.SelectedNode);
                }
            }
            btnSave.Enabled = true;
        }

        private void tsmAddBatch_Click(object sender, EventArgs e)
        {
            // 考虑之后改成正则表达式
            if (trvNote.SelectedNode != null)
            {
                bool canAddBatch = false;
                string NewLogBatch = Interaction.InputBox("Input new note node in batch, e.g., xxx_{1-10}_xxx, or xxx_{a,b,c}_xxx, or xxx_{1-10,a,b,c}_xxx", "New Notes", "New Note", 300, 300);
                if (NewLogBatch != "")
                {
                    // 分离得到大括号内的集合
                    string[] splitLeft = NewLogBatch.Split('{');
                    string beforeBracket = "";
                    string afterBracket = "";
                    List<string> inBracketCollection = new List<string>();
                    if (splitLeft.Length == 2)
                    {
                        beforeBracket = splitLeft[0];
                        string[] splitRight = splitLeft[1].Split('}');
                        if (splitRight.Length == 2)
                        {
                            afterBracket = splitRight[1];
                            // 先被','分割，再被'-'分割
                            string[] inBracketByComma = splitRight[0].Split(',');
                            foreach (string item in inBracketByComma)
                            {
                                string[] inBrackByHypen = item.Split('-');
                                if (inBrackByHypen.Length == 1)
                                {
                                    inBracketCollection.Add(item);
                                    canAddBatch = true;
                                }
                                else if (inBrackByHypen.Length == 2)
                                {
                                    bool batchDetectedFlag = false;

                                    // 看看是不是按小写字母增序
                                    if (!batchDetectedFlag)
                                    {
                                        string[] lowercaseAlphabet = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
                                        if (lowercaseAlphabet.Contains(inBrackByHypen[0]) && lowercaseAlphabet.Contains(inBrackByHypen[1]))
                                        {
                                            int startIndex = -1;
                                            int endIndex = -1;
                                            for (int i = 0; i < lowercaseAlphabet.Length; i++)
                                            {
                                                if (lowercaseAlphabet[i] == inBrackByHypen[0])
                                                {
                                                    startIndex = i;
                                                }
                                                if (lowercaseAlphabet[i] == inBrackByHypen[1])
                                                {
                                                    endIndex = i;
                                                }
                                            }
                                            for (int i = startIndex; i < endIndex; i++)
                                            {
                                                inBracketCollection.Add(lowercaseAlphabet[i]);
                                            }
                                        }
                                    }

                                    // 看看是不是按大写字母增序
                                    if (!batchDetectedFlag)
                                    {
                                        string[] uppercaseAlphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                                        if (uppercaseAlphabet.Contains(inBrackByHypen[0]) && uppercaseAlphabet.Contains(inBrackByHypen[1]))
                                        {
                                            int startIndex = -1;
                                            int endIndex = -1;
                                            for (int i = 0; i < uppercaseAlphabet.Length; i++)
                                            {
                                                if (uppercaseAlphabet[i] == inBrackByHypen[0])
                                                {
                                                    startIndex = i;
                                                }
                                                if (uppercaseAlphabet[i] == inBrackByHypen[1])
                                                {
                                                    endIndex = i;
                                                }
                                            }
                                            for (int i = startIndex; i < endIndex; i++)
                                            {
                                                inBracketCollection.Add(uppercaseAlphabet[i]);
                                            }
                                        }
                                    }

                                    // 看看是不是按数字增序
                                    if (!batchDetectedFlag)
                                    {
                                        if (Regex.IsMatch(inBrackByHypen[0], @"^[0-9]+$") && Regex.IsMatch(inBrackByHypen[1], @"^[0-9]+$"))
                                        {
                                            int startIndex = Convert.ToInt32(inBrackByHypen[0]);
                                            int endIndex = Convert.ToInt32(inBrackByHypen[1]);
                                            for (int i = startIndex; i < endIndex; i++)
                                            {
                                                inBracketCollection.Add(i.ToString());
                                            }
                                        }
                                    }

                                    if (batchDetectedFlag)
                                    {
                                        canAddBatch = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect format, correct example will be xxx_{1-10}_xxx, or xxx_{a,b,c}_xxx, or xxx_{1-10,a,b,c}_xxx");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect format, correct example will be xxx_{1-10}_xxx, or xxx_{a,b,c}_xxx, or xxx_{1-10,a,b,c}_xxx");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect format, correct example will be xxx_{1-10}_xxx, or xxx_{a,b,c}_xxx, or xxx_{1-10,a,b,c}_xxx");
                    }
                    if (canAddBatch)
                    {
                        foreach (string inc in inBracketCollection)
                        {
                            string newLog = beforeBracket + inc + afterBracket;
                            TreeNode newNode = new TreeNode(newLog, 0, 0);
                            newNode.Text = newLog;
                            newNode.Name = Guid.NewGuid().ToString();
                            newNode.BackColor = SystemColors.Window;
                            newNode.ForeColor = Color.Black;
                            newNode.ExpandAll();
                            trvNote.SelectedNode.ExpandAll();

                            (newNode.BackColor, newNode.ForeColor, newNode.NodeFont) = getColor(newLog);
                            newNode.StateImageIndex = getLogo(newLog);
                            trvNote.SelectedNode.Nodes.Add(newNode);
                        }
                        UpdateModifiedNodeTime(trvNote.SelectedNode);
                        btnSave.Enabled = true;
                    }
                }
            }
        }

        string oldEditNoteText = "";
        private void tsmEdit_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Parent != null)
            {
                trvNote.LabelEdit = true;
                UpdateModifiedNodeTime(trvNote.SelectedNode);
                if (!trvNote.SelectedNode.IsEditing)
                {
                    trvNote.SelectedNode.BeginEdit();
                }
                oldEditNoteText = trvNote.SelectedNode.Text;
            }
        }

        private void tsmRemove_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Parent != null)
            {
                if (MessageBox.Show("Confirm to remove.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    UpdateModifiedNodeTime(trvNote.SelectedNode.Parent);
                    trvNote.Nodes.Remove(trvNote.SelectedNode);
                    btnSave.Enabled = true;
                }
            }
        }

        private void tsmRemoveChildren_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Nodes.Count > 0)
            {
                bool canRemoveFlag = true;
                foreach (TreeNode child in trvNote.SelectedNode.Nodes)
                {
                    if (child.Nodes.Count > 0)
                    {
                        canRemoveFlag = false;
                        break;
                    }
                }
                if (canRemoveFlag)
                {
                    UpdateModifiedNodeTime(trvNote.SelectedNode);
                    trvNote.SelectedNode.Nodes.Clear();
                    btnSave.Enabled = true;
                }
                else
                {
                    MessageBox.Show("To be cautious, can not remove note with sub node");
                }
            }
        }
        private void tsmRemoveLayer_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Nodes.Count > 0)
            {
                int ordering = trvNote.SelectedNode.Index;
                // 把子节点都并入父节点里，拉平
                foreach (TreeNode child in trvNote.SelectedNode.Nodes)
                {
                    TreeNode childClone = (TreeNode)child.Clone();
                    trvNote.SelectedNode.Parent.Nodes.Insert(ordering, childClone);
                    ordering += 1;
                }
                trvNote.Nodes.Remove(trvNote.SelectedNode);
                btnSave.Enabled = true;
            }
        }

        private void tsmUp_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                TreeNode node = trvNote.SelectedNode;
                TreeNode preNode = node.PrevNode;
                if (preNode != null)
                {
                    TreeNode newNode = (TreeNode)node.Clone();
                    if (node.Parent == null)
                    {
                        trvNote.Nodes.Insert(preNode.Index, newNode);
                    }
                    else
                    {
                        node.Parent.Nodes.Insert(preNode.Index, newNode);
                    }
                    node.Remove();
                    trvNote.SelectedNode = newNode;
                    UpdateModifiedNodeTime(trvNote.SelectedNode);
                }
            }
            btnSave.Enabled = true;
        }

        private void tsmDown_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                TreeNode node = trvNote.SelectedNode;
                TreeNode nextNode = node.NextNode;
                if (nextNode != null)
                {
                    TreeNode newNode = (TreeNode)node.Clone();
                    if (node.Parent == null)
                    {
                        trvNote.Nodes.Insert(nextNode.Index + 1, newNode);
                    }
                    else
                    {
                        node.Parent.Nodes.Insert(nextNode.Index + 1, newNode);
                    }
                    node.Remove();
                    trvNote.SelectedNode = newNode;
                    UpdateModifiedNodeTime(trvNote.SelectedNode);
                }
            }
            btnSave.Enabled = true;
        }

        private void tsmBelongTo_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Parent != null)
            {
                TreeNode node = trvNote.SelectedNode;
                TreeNode preNode = node.PrevNode;
                TreeNode newNode = (TreeNode)node.Clone();
                if (node.Parent != null && node.PrevNode != null)
                {
                    preNode.Nodes.Insert(preNode.Nodes.Count, newNode);
                    node.Remove();
                    trvNote.SelectedNode = newNode;
                    UpdateModifiedNodeTime(trvNote.SelectedNode);
                }
            }
            btnSave.Enabled = true;
        }

        private void tsmIndependent_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                TreeNode node = trvNote.SelectedNode;
                TreeNode parentNode = node.Parent;
                TreeNode grandparentNode = node.Parent.Parent;
                TreeNode newNode = (TreeNode)node.Clone();
                if (node.Parent != null && node.Parent.Parent != null)
                {
                    grandparentNode.Nodes.Insert(parentNode.Index + 1, newNode);
                    node.Remove();
                    trvNote.SelectedNode = newNode;
                    UpdateModifiedNodeTime(trvNote.SelectedNode);
                }
            }
            btnSave.Enabled = true;
        }

        private void txtTopic_TextChanged(object sender, EventArgs e)
        {
            note.Topic = txtTopic.Text;
            trvNote.Nodes[0].Text = txtTopic.Text;
            trvNote.Nodes[0].Name = topicGUID;
            if (noteType == ENoteType.Note)
            {
                this.Text = "LifeGame - Note - " + txtTopic.Text;
            }
            else if (noteType == ENoteType.System)
            {
                this.Text = "LifeGame - Config - " + txtTopic.Text;
            }
            else if (noteType == ENoteType.Literature)
            {
                this.Text = "LifeGame - Literature - " + txtTopic.Text;
            }
            foreach (RNoteLog item in noteLogs)
            {
                item.Topic = txtTopic.Text;
                if (item.GUID == topicGUID)
                {
                    item.Log = txtTopic.Text;
                }
            }
            foreach (RNoteColor item in noteColors)
            {
                item.Topic = txtTopic.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (noteType == ENoteType.Note || noteType == ENoteType.DailyReport || noteType == ENoteType.System || noteType == ENoteType.LitReview)
            {
                SaveNote();
            }
            if (noteType == ENoteType.Literature)
            {
                SaveLiterature();
            }
            txtTopic.Enabled = false;
            btnSave.Enabled = false;
        }

        private void tsmAddColor_Click(object sender, EventArgs e)
        {
            frmAddNoteColor frmAddNoteColor = new frmAddNoteColor();
            frmAddNoteColor.SendColorLabel += new frmAddNoteColor.SetColorLabel(addNoteColor);
            frmAddNoteColor.Show();
        }

        private void addNoteColor(string Keyword, string NoteColor)
        {
            if (!noteColors.Exists(o => o.Keyword == Keyword))
            {
                RNoteColor newNoteColor = new RNoteColor();
                newNoteColor.Topic = txtTopic.Text;
                newNoteColor.TagTime = noteDateTime;
                newNoteColor.Keyword = Keyword;
                newNoteColor.Color = NoteColor;
                noteColors.Add(newNoteColor);

                ListViewItem item = new ListViewItem();
                item.Text = Keyword;
                plot C = new plot();
                item.BackColor = C.GetColor(NoteColor);
                if (NoteColor == "Red" || NoteColor == "Green" || NoteColor == "Blue" || NoteColor == "DarkGreen" || NoteColor == "Brown" || NoteColor == "Purple")
                {
                    item.ForeColor = Color.White;
                }
                else
                {
                    item.ForeColor = Color.Black;
                }
                item.Checked = true;
                lsvColor.Items.Add(item);
                SaveNoteLog();
                LoadNoteLog();
            }
        }

        private void tsmRemoveColor_Click(object sender, EventArgs e)
        {
            if (lsvColor.SelectedItems != null)
            {
                foreach (ListViewItem item in lsvColor.SelectedItems)
                {
                    noteColors.RemoveAll(o => o.Keyword == item.Text);
                    lsvColor.Items.Remove(item);
                }
                SaveNoteLog();
                LoadNoteLog();
            }
        }

        private void tsmChangeLabel_Click(object sender, EventArgs e)
        {
            string SelectedNoteLabel = "(No Label)";
            foreach (ListViewItem item in lsvColor.Items)
            {
                if (trvNote.SelectedNode.Text.Contains(item.Text))
                {
                    SelectedNoteLabel = item.Text;
                    break;
                }
            }
            List<string> LabelOptions = new List<string>();
            foreach (RNoteColor item in noteColors)
            {
                LabelOptions.Add(item.Keyword);
            }
            frmNoteChangeLabel frmNoteChangeLabel = new frmNoteChangeLabel(SelectedNoteLabel, LabelOptions);
            frmNoteChangeLabel.SendNewLabel += new frmNoteChangeLabel.SetNewLabel(changeLabel);
            frmNoteChangeLabel.Show();
        }

        private void changeLabel(string newLabel, bool changeDescendantFlag)
        {
            changeNodeLabel(trvNote.SelectedNode, newLabel, changeDescendantFlag);
        }

        private void changeNodeLabel(TreeNode node, string newLabel, bool changeDescendant)
        {
            foreach (ListViewItem item in lsvColor.Items)
            {
                if (node.Text.Contains(item.Text))
                {
                    node.Text = node.Text.Replace(item.Text, newLabel);
                }
            }
            (node.BackColor, node.ForeColor, node.NodeFont) = getColor(node.Text);
            node.StateImageIndex = getLogo(node.Text);

            if (changeDescendant)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    changeNodeLabel(child, newLabel, changeDescendant);
                }
            }
        }

        private void updateNodeColor(TreeNode node)
        {
            (node.BackColor, node.ForeColor, node.NodeFont) = getColor(node.Text);
            node.StateImageIndex = getLogo(node.Text);
        }

        private void replaceNodeText(TreeNode node, string oldString, string newString)
        {
            if (node.Text.Contains(oldString))
            {
                node.Text = node.Text.Replace(oldString, newString);
                updateNodeColor(node);

            }
            foreach (TreeNode child in node.Nodes)
            {
                replaceNodeText(child, oldString, newString);
            }
        }

        private void replaceText(string oldString, string newString)
        {
            replaceNodeText(trvNote.SelectedNode, oldString, newString);
        }

        private void appendNodeText(TreeNode node, string appString)
        {
            node.Text = node.Text + appString;
            updateNodeColor(node);
            foreach (TreeNode child in node.Nodes)
            {
                appendNodeText(child, appString);
            }
        }

        private void prependNodeText(TreeNode node, string preString)
        {
            node.Text = preString + node.Text;
            updateNodeColor(node);
            foreach (TreeNode child in node.Nodes)
            {
                prependNodeText(child, preString);
            }
        }

        private TreeNode previousSelected = null;
        private void trvNote_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            previousSelected = trvNote.SelectedNode;
        }

        private void trvNote_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (txtTopic.Text != "Daily Report")
            {
                tsmConvertToLog.Visible = false;
                tsmConvertToSchedule.Visible = false;
                tsmConvertToTransaction.Visible = false;
                tspDaily.Visible = false;
            }
            else
            {
                tsmConvertToLog.Visible = true;
                tsmConvertToSchedule.Visible = true;
                tsmConvertToTransaction.Visible = true;
                tspDaily.Visible = true;
            }

            UpdateWordCount();

            if (trvNote.SelectedNode.Parent == null)
            {
                tsmEdit.Enabled = false;
                tsmChangeLabel.Enabled = false;
                tsmUp.Enabled = false;
                tsmDown.Enabled = false;
                tsmBelongTo.Enabled = false;
                tsmIndependent.Enabled = false;
                tsmRenameNote.Enabled = true;
            }
            else
            {
                tsmEdit.Enabled = true;
                tsmChangeLabel.Enabled = true;
                tsmUp.Enabled = true;
                tsmDown.Enabled = true;
                tsmBelongTo.Enabled = true;
                tsmIndependent.Enabled = true;
                tsmRenameNote.Enabled = false;
            }

            if (M.mem.copiedNodes.Count == 0)
            {
                tsmPaste.Enabled = false;
            }
            else
            {
                tsmPaste.Enabled = true;
            }

            if (trvNote.SelectedNode.Text.Contains("%") && trvNote.SelectedNode.Text.ToCharArray().Count(c => c == '%') == 1)
            {
                string percentStr = Regex.Match(trvNote.SelectedNode.Text, @"(?<num>\d+)(?:\%)").Groups["num"].Value;
                if (percentStr != "")
                {
                    tsmProgressAdd.Visible = true;
                    tsmProgressMinus.Visible = true;
                }
            }
            else
            {
                tsmProgressAdd.Visible = false;
                tsmProgressMinus.Visible = false;
            }
            if (trvNote.SelectedNode.Text.Contains("$LINK$>")
                || trvNote.SelectedNode.Text.Contains("$LITR$>")
                || trvNote.SelectedNode.Text.Contains("$NOTE$>")
                || trvNote.SelectedNode.Text.Contains("$JUMP$>")
                || trvNote.SelectedNode.Text.Split('#').Length == 3)
            {
                tsmGoto.Enabled = true;
            }
            else
            {
                tsmGoto.Enabled = false;
            }
            if (trvNote.SelectedNode.Text.Contains("$SCHL$>"))
            {
                tsmConvertToSchedule.Enabled = true;
            }
            else
            {
                tsmConvertToSchedule.Enabled = false;
            }
            if (trvNote.SelectedNode.Text.Contains("$RECO$>"))
            {
                tsmConvertToLog.Enabled = true;
            }
            else
            {
                tsmConvertToLog.Enabled = false;
            }
            if (trvNote.SelectedNode.Text.Contains("$TRSA$>"))
            {
                tsmConvertToTransaction.Enabled = true;
            }
            else
            {
                tsmConvertToTransaction.Enabled = false;
            }
            if (trvNote.SelectedNode.Text.Contains("$LITR$>"))
            {
                tsmCopyFile.Enabled = true;
                tsmCopyBibTeX.Enabled = true;
            }
            else
            {
                tsmCopyFile.Enabled = false;
                tsmCopyBibTeX.Enabled = false;
            }
        }

        private void tsmGoto_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                if (trvNote.SelectedNode.Text.Contains("$LINK$>"))
                {
                    string selectedPath = trvNote.SelectedNode.Text.Split('@')[0];
                    selectedPath = selectedPath.Replace("$LINK$>", "");
                    string[] checkUrl = selectedPath.Split(':');
                    if (checkUrl[0] == "http" || checkUrl[0] == "https")
                    {
                        System.Diagnostics.Process.Start("chrome.exe", selectedPath);
                    }
                    else
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(selectedPath);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("File/link is not found.");
                        }
                    }
                }
                else if (trvNote.SelectedNode.Text.Contains("$LITR$>"))
                {
                    string selectedPath = trvNote.SelectedNode.Text.Split('@')[0];
                    selectedPath = selectedPath.Replace("$LITR$>", "");
                    if (G.glb.lstLiterature.Exists(o => o.Title == selectedPath))
                    {
                        if (M.notesOpened.Exists(o => o.note.LiteratureTitle == selectedPath))
                        {
                            M.notesOpened.Find(o => o.note.LiteratureTitle == selectedPath).Show();
                            M.notesOpened.Find(o => o.note.LiteratureTitle == selectedPath).BringToFront();
                        }
                        else
                        {
                            frmInfoNote frmInfoNote = new frmInfoNote(G.glb.lstLiterature.Find(o => o.Title == selectedPath));
                            M.notesOpened.Add(frmInfoNote);
                            frmInfoNote.Show();
                        }
                    }
                    else if (G.glb.lstLiterature.Exists(o => o.BibKey == selectedPath))
                    {
                        string selectedLit = G.glb.lstLiterature.Find(o => o.BibKey == selectedPath).Title;
                        if (M.notesOpened.Exists(o => o.note.LiteratureTitle == selectedLit))
                        {
                            M.notesOpened.Find(o => o.note.LiteratureTitle == selectedLit).Show();
                            M.notesOpened.Find(o => o.note.LiteratureTitle == selectedLit).BringToFront();
                        }
                        else
                        {
                            frmInfoNote frmInfoNote = new frmInfoNote(G.glb.lstLiterature.Find(o => o.Title == selectedLit));
                            M.notesOpened.Add(frmInfoNote);
                            frmInfoNote.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Literature does not exist in database");
                    }
                }
                else if (trvNote.SelectedNode.Text.Contains("$NOTE$>"))
                {
                    string selectedPath = trvNote.SelectedNode.Text.Replace("$NOTE$>", "");
                    string[] checkNote = selectedPath.Split('@');
                    DateTime noteDate = new DateTime();
                    string noteTitle = "";
                    bool tryOpenFlag = true;
                    if (checkNote.Length != 2)
                    {
                        MessageBox.Show("Incorrect Note Format, correct format should be 'YYYY.MM.DD@Note'");
                        tryOpenFlag = false;
                    }
                    else
                    {
                        string[] dateNote = checkNote[0].Split('.');
                        if (dateNote.Length != 3)
                        {
                            MessageBox.Show("Incorrect Note Format, correct format should be 'YYYY.MM.DD@Note'");
                            tryOpenFlag = false;
                        }
                        else
                        {
                            noteDate = new DateTime(Convert.ToInt32(dateNote[0]), Convert.ToInt32(dateNote[1]), Convert.ToInt32(dateNote[2]));
                        }
                    }

                    for (int i = 1; i < checkNote.Length; i++)
                    {
                        noteTitle = noteTitle + checkNote[i];
                        if (i < checkNote.Length - 1)
                        {
                            noteTitle = noteTitle + " ";
                        }
                    }
                    if (tryOpenFlag && G.glb.lstNote.Exists(o => o.TagTime == noteDate && o.Topic == noteTitle))
                    {
                        if (M.notesOpened.Exists(o => o.note.Topic == noteTitle && o.note.TagTime == noteDate))
                        {
                            M.notesOpened.Find(o => o.note.Topic == noteTitle && o.note.TagTime == noteDate).Show();
                            M.notesOpened.Find(o => o.note.Topic == noteTitle && o.note.TagTime == noteDate).BringToFront();
                        }
                        else
                        {
                            frmInfoNote frmInfoNote = new frmInfoNote(G.glb.lstNote.Find(o => o.TagTime == noteDate && o.Topic == noteTitle));
                            M.notesOpened.Add(frmInfoNote);
                            frmInfoNote.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot find record.");
                    }
                }
                else if (trvNote.SelectedNode.Text.Contains("$JUMP$>"))
                {
                    string selectedText = trvNote.SelectedNode.Text.Replace("$JUMP$>", "");
                    trvNote.SelectedNode = findByName(trvNote.Nodes[0], selectedText);
                }
                else if (trvNote.SelectedNode.Text.Split('#').Length == 3)
                {
                    string selectedText = trvNote.SelectedNode.Text.Split('#')[1];
                    trvNote.SelectedNode = findByName(trvNote.Nodes[0], selectedText);
                }
            }
        }

        private TreeNode findByName(TreeNode treeNode, string nodeText)
        {
            if (treeNode.Text == nodeText)
            {
                return treeNode;
            }
            else
            {
                foreach (TreeNode subNode in treeNode.Nodes)
                {
                    if (findByName(subNode, nodeText) != null)
                    {
                        return findByName(subNode, nodeText);
                    }
                }
            }
            return null;
        }

        private void updateJumpNode(TreeNode treeNode, string oldNodeText, string newNodeText)
        {
            if (treeNode.Text == "$JUMP$>" + oldNodeText)
            {
                treeNode.Text = "$JUMP$>" + newNodeText;
            }
            else
            {
                string[] sp = treeNode.Text.Split('#');
                if (sp.Length == 3)
                {
                    if (sp[1] == oldNodeText)
                    {
                        treeNode.Text = "#" + newNodeText + "#";
                    }
                }
            }

            foreach (TreeNode subNode in treeNode.Nodes)
            {
                updateJumpNode(subNode, oldNodeText, newNodeText);
            }
        }

        private void tsmReplace_Click(object sender, EventArgs e)
        {
            frmReplaceNote frmReplaceNote = new frmReplaceNote();
            frmReplaceNote.SendReplace += new frmReplaceNote.ReplaceString(replaceText);
            frmReplaceNote.Show();
        }

        private void tsmPrepend_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                string NewLog = Interaction.InputBox("Prepend to notes", "Prepend", "", 300, 300);
                if (NewLog != "")
                {
                    prependNodeText(trvNote.SelectedNode, NewLog);
                }
            }
            btnSave.Enabled = true;
        }

        private void tsmAppend_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                string NewLog = Interaction.InputBox("Append to notes", "Append", "", 300, 300);
                if (NewLog != "")
                {
                    appendNodeText(trvNote.SelectedNode, NewLog);
                }
            }
            btnSave.Enabled = true;
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            List<string> logList = writeByNode(trvNote.Nodes[0], 0);
            string txtFile = txtTopic.Text;
            txtFile = txtFile.Replace(":", "-");

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(txtFile + ".txt", false))
            {
                foreach (string log in logList)
                {
                    file.WriteLine(log);
                }

                MessageBox.Show("Write notes to " + txtFile + ".txt");
            }
        }

        private List<string> writeByNode(TreeNode logNode, int level)
        {
            List<string> logList = new List<string>();
            string levelStr = "";
            for (int i = 0; i < level; i++)
            {
                levelStr += "\t";
            }
            logList.Add(levelStr + logNode.Text);
            foreach (TreeNode item in logNode.Nodes)
            {
                List<string> childLogList = writeByNode(item, level + 1);
                logList.AddRange(childLogList);
            }
            return logList;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Please select a .txt file.";
            openFileDialog.Filter = "Text files (*.txt)|*.txt";

            string openFilePath;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openFilePath = openFileDialog.FileName;
                string[] logList = System.IO.File.ReadAllLines(openFilePath);

                // validate - empty
                if (logList.Length == 0)
                {
                    MessageBox.Show("Emty .txt file.");
                }

                // validate - title
                else if (logList[0] != txtTopic.Text)
                {
                    MessageBox.Show("Does not match with title");
                }

                // reconstruct
                else if (logList.Length > 1)
                {
                    trvNote.Nodes.Clear();

                    TreeNode rootNode = new TreeNode(logList[0], 0, 0);
                    rootNode.Text = logList[0];
                    rootNode.Name = topicGUID;
                    rootNode.Expand();

                    trvNote.Nodes.Add(rootNode);

                    List<TreeNode> curTreeNode = new List<TreeNode>();
                    int curLevel = 0;
                    curTreeNode.Add(rootNode);

                    for (int i = 1; i < logList.Length; i++)
                    {
                        string[] sp = logList[i].Split('\t');
                        int level = sp.Length - 1;
                        string log = sp[sp.Length - 1];

                        TreeNode newNode = new TreeNode(log, 0, 0);
                        newNode.Text = log;
                        newNode.Name = Guid.NewGuid().ToString();
                        newNode.Expand();
                        updateNodeColor(newNode);

                        // 如果和上一行同级别，curTreeNode倒数第二个追加子节点，更新最后一个
                        if (curLevel == level && level > 0)
                        {
                            curTreeNode[curTreeNode.Count - 2].Nodes.Add(newNode);
                            curTreeNode[curTreeNode.Count - 1] = newNode;
                        }
                        // 如果比上一行级别多一，说明是上一行子节点
                        else if (curLevel + 1 == level)
                        {
                            curTreeNode[curTreeNode.Count - 1].Nodes.Add(newNode);
                            curTreeNode.Add(newNode);
                        }
                        // 如果比上一行少，说明回溯了
                        else if (curLevel > level)
                        {
                            curTreeNode[level - 1].Nodes.Add(newNode);
                            curTreeNode.RemoveRange(level, curTreeNode.Count - level);
                            curTreeNode.Add(newNode);
                        }
                        // 否则，不合法
                        else
                        {
                            MessageBox.Show("Illegal structure");
                        }
                        curLevel = level;
                    }
                }
            }
        }

        private void tsmCopy_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                M.mem.copiedNodes.Clear();
                copyNode(trvNote.SelectedNode);
                tsmPaste.Enabled = true;
            }
        }

        private void copyNode(TreeNode node)
        {
            if (node.Parent != null)
            {
                M.mem.copiedNodes.Add(new copiedNodeStruct(node.Text, node.Name, node.Parent.Name));
            }
            else
            {
                M.mem.copiedNodes.Add(new copiedNodeStruct(node.Text, node.Name, null));
            }
            foreach (TreeNode child in node.Nodes)
            {
                copyNode(child);
            }
        }

        private void tsmPaste_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && M.mem.copiedNodes.Count > 0)
            {
                TreeNode newCopiedRoot = new TreeNode();
                newCopiedRoot.Text = M.mem.copiedNodes[0].nodeText;
                pasteNode(newCopiedRoot, M.mem.copiedNodes[0].nodeGUID);
                newCopiedRoot.Name = Guid.NewGuid().ToString();
                updateNodeColor(newCopiedRoot);
                trvNote.SelectedNode.Nodes.Add(newCopiedRoot);
                btnSave.Enabled = true;
            }
        }

        private void pasteNode(TreeNode node, string nodeGUID)
        {
            if (M.mem.copiedNodes.Exists(o => o.nodeParentGUID == nodeGUID))
            {
                foreach (copiedNodeStruct item in M.mem.copiedNodes.FindAll(o => o.nodeParentGUID == nodeGUID))
                {
                    TreeNode newCopiedChild = new TreeNode();
                    newCopiedChild.Text = item.nodeText;
                    pasteNode(newCopiedChild, item.nodeGUID);
                    newCopiedChild.Name = Guid.NewGuid().ToString();
                    updateNodeColor(newCopiedChild);
                    node.Nodes.Add(newCopiedChild);
                }
            }
        }

        private void UpdateWordCount()
        {
            int[] rootProperty = nodeProperties(trvNote.Nodes[0]);
            if (trvNote.SelectedNode != null)
            {
                int[] selectedProperty = nodeProperties(trvNote.SelectedNode);
                lblWordCount.Text = "Word Count: " + selectedProperty[0].ToString() + "/" + rootProperty[0].ToString();
            }
            else
            {
                lblWordCount.Text = "Word Count: 0/" + rootProperty[0].ToString();
            }

        }

        private int wordCount(string str)
        {
            int count = 0;

            int countEnglish = 0;
            countEnglish = Regex.Matches(str, @"[A-Za-z0-9][A-Za-z0-9\-.]*").Count;

            int countChinese = 0;
            countChinese = Regex.Matches(str, @"[\u4E00-\u9FA5]").Count;

            count = countEnglish + countChinese;

            return count;
        }

        private int[] nodeProperties(TreeNode node)
        {
            int[] count = new int[] { 0, 0, 0, 0, 0 };
            count[0] = wordCount(node.Text);
            foreach (TreeNode item in node.Nodes)
            {
                count[1] += 1;
                if (item.Text.Contains("$LINK$>"))
                {
                    count[2] += 1;
                }
                else if (item.Text.Contains("$NOTE$>"))
                {
                    count[3] += 1;
                }
                else if (item.Text.Contains("$LITR$>"))
                {
                    count[4] += 1;
                }
                int[] childCount = nodeProperties(item);
                for (int i = 0; i < childCount.Length; i++)
                {
                    count[i] += childCount[i];
                }
            }
            return count;
        }

        private int[] countLabel(TreeNode node, string label)
        {
            int count = 0;
            int countWord = 0;
            if (node.Text.Contains(label))
            {
                count++;
                countWord += wordCount(node.Text);
            }
            foreach (TreeNode sub in node.Nodes)
            {
                int[] subCount = countLabel(sub, label);
                count += subCount[0];
                countWord += subCount[1];
            }
            return new int[] { count, countWord };
        }

        private void tsmFold_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                foreach (TreeNode item in trvNote.SelectedNode.Nodes)
                {
                    item.Collapse(true);
                }
            }
        }

        private void tsmExpand_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                trvNote.SelectedNode.ExpandAll();
                foreach (TreeNode item in trvNote.SelectedNode.Nodes)
                {
                    item.ExpandAll();
                }
            }
        }

        public int TreeNodeCompare(TreeNode x, TreeNode y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;
            return String.Compare(tx.Text, ty.Text);
        }

        private void tsmSort_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null &&
                MessageBox.Show("Confirm to sort children nodes.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                Comparison<TreeNode> sorterX = new Comparison<TreeNode>(TreeNodeCompare);
                List<TreeNode> al = new List<TreeNode>();

                foreach (TreeNode tn in trvNote.SelectedNode.Nodes)
                {
                    al.Add(tn);
                }
                al.Sort(sorterX);

                trvNote.SelectedNode.Nodes.Clear();
                foreach (TreeNode tn in al)
                {
                    trvNote.SelectedNode.Nodes.Add(tn);
                }
            }
        }

        private void trvNote_KeyDown(object sender, KeyEventArgs e)
        {
            // 新建节点
            if (e.Control && e.KeyCode == Keys.A)
            {
                tsmAdd_Click(trvNote, e);
            }
            // 批量新建
            else if (e.Control && e.KeyCode == Keys.B)
            {
                tsmAddBatch_Click(trvNote, e);
            }
            // 折叠
            else if (e.Control && e.KeyCode == Keys.N)
            {
                tsmFold_Click(trvNote, e);
            }
            // 展开
            else if (e.Control && e.KeyCode == Keys.M)
            {
                tsmExpand_Click(trvNote, e);
            }
            // 更换label
            else if (e.Control && e.KeyCode == Keys.R)
            {
                tsmRotateLabelNext_Click(trvNote, e);
            }
            else if (e.Control && e.KeyCode == Keys.T)
            {
                tsmRotateLabelPrev_Click(trvNote, e);
            }
            // 调整百分比
            else if (e.Control && e.KeyCode == Keys.Oemplus)
            {
                tsmProgressAdd_Click(trvNote, e);
            }
            else if (e.Control && e.KeyCode == Keys.OemMinus)
            {
                tsmProgressMinus_Click(trvNote, e);
            }
            else if (e.Control && e.KeyCode == Keys.Oemtilde)
            {
                tsmProgressSetPtg(0);
            }
            else if (e.Control && e.KeyCode == Keys.D1)
            {
                tsmProgressSetPtg(10);
            }
            else if (e.Control && e.KeyCode == Keys.D2)
            {
                tsmProgressSetPtg(20);
            }
            else if (e.Control && e.KeyCode == Keys.D3)
            {
                tsmProgressSetPtg(30);
            }
            else if (e.Control && e.KeyCode == Keys.D4)
            {
                tsmProgressSetPtg(40);
            }
            else if (e.Control && e.KeyCode == Keys.D5)
            {
                tsmProgressSetPtg(50);
            }
            else if (e.Control && e.KeyCode == Keys.D6)
            {
                tsmProgressSetPtg(60);
            }
            else if (e.Control && e.KeyCode == Keys.D7)
            {
                tsmProgressSetPtg(70);
            }
            else if (e.Control && e.KeyCode == Keys.D8)
            {
                tsmProgressSetPtg(80);
            }
            else if (e.Control && e.KeyCode == Keys.D9)
            {
                tsmProgressSetPtg(90);
            }
            else if (e.Control && e.KeyCode == Keys.D0)
            {
                tsmProgressSetPtg(100);
            }
            // 转到
            else if (e.Control && e.KeyCode == Keys.G)
            {
                tsmGoto_Click(trvNote, e);
                tsmConvertToSchedule_Click(trvNote, e);
                tsmConvertToLog_Click(trvNote, e);
                tsmConvertToTransaction_Click(trvNote, e);
            }
            // 编辑节点
            else if (e.Control && e.KeyCode == Keys.E)
            {
                tsmEdit_Click(trvNote, e);
            }
            // 复制
            else if (e.Control && e.KeyCode == Keys.C)
            {
                tsmCopy_Click(trvNote, e);
                tsmCopyFile_Click(trvNote, e);
            }
            // 粘贴
            else if (e.Control && e.KeyCode == Keys.V)
            {
                tsmPaste_Click(trvNote, e);
            }
            // 删除
            else if (e.Control && e.KeyCode == Keys.D)
            {
                tsmRemove_Click(trvNote, e);
            }
            // 删除子节点
            else if (e.Control && e.KeyCode == Keys.O)
            {
                tsmRemoveChildren_Click(trvNote, e);
            }
            // 删除当前层
            else if (e.Control && e.KeyCode == Keys.P)
            {
                tsmRemoveLayer_Click(trvNote, e);
            }
            // 上移
            else if (e.Control && e.KeyCode == Keys.I)
            {
                tsmUp_Click(trvNote, e);
            }
            // 下移
            else if (e.Control && e.KeyCode == Keys.K)
            {
                tsmDown_Click(trvNote, e);
            }
            // 左移
            else if (e.Control && e.KeyCode == Keys.L)
            {
                tsmBelongTo_Click(trvNote, e);
            }
            // 右移
            else if (e.Control && e.KeyCode == Keys.J)
            {
                tsmIndependent_Click(trvNote, e);
            }
            // 保存
            else if (e.Control && e.KeyCode == Keys.S)
            {
                if (noteType == ENoteType.Note || noteType == ENoteType.DailyReport || noteType == ENoteType.System)
                {
                    SaveNote();
                }
                if (noteType == ENoteType.Literature)
                {
                    SaveLiterature();
                }
            }
            // 返回
            else if (e.Control && e.KeyCode == Keys.Q)
            {
                trvNote.SelectedNode = previousSelected;
            }
        }

        private void trvNote_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null && e.Label.Trim().Length > 0)
            {
                string newLog = e.Label.Trim();
                trvNote.SelectedNode.Text = newLog;
                trvNote.LabelEdit = false;
                updateJumpNode(trvNote.Nodes[0], oldEditNoteText, newLog);
                oldEditNoteText = "";
                updateNodeColor(trvNote.SelectedNode);
                btnSave.Enabled = true;
            }
            else
            {
                e.CancelEdit = true;
            }
        }

        private void trvNote_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        string highlightText = "";
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtHighlight.Text.Length > 0)
            {
                List<CNote> notes = G.glb.lstNote.FindAll(o => o.Topic.ToUpper().Contains(txtHighlight.Text.ToUpper()));
                if (notes.Count == 0)
                {
                    MessageBox.Show("No record!");
                }
                else if (notes.Count == 1)
                {
                    plot D = new plot();
                    D.CallInfoNote(notes[0]);
                }
                else
                {
                    frmSearchNote frmSearchNote = new frmSearchNote(txtHighlight.Text);
                    frmSearchNote.Show();
                }
            }
        }

        private void txtHighlight_TextChanged(object sender, EventArgs e)
        {
            if (txtHighlight.Text.Length == 0)
            {
                highlightText = "";
                SaveNoteLog();
                LoadNoteLog();
            }
        }

        private void CheckPassword(string password)
        {
            if (password == "1992Linear?Peng0821")
            {
                btnRead.Enabled = true;
                btnWrite.Enabled = true;
                btnSave.Enabled = true;
                btnLock.Text = "Lock";
                trvNote.Show();
                lockMode = false;
            }
            else
            {
                MessageBox.Show("Incorrect Password, access denied");
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (!lockMode)
            {
                btnRead.Enabled = false;
                btnWrite.Enabled = false;
                btnSave.Enabled = false;
                btnLock.Text = "Unlock";
                trvNote.Hide();
                lockMode = true;
            }
            else
            {
                frmNotePassword frmNotePassword = new frmNotePassword();
                frmNotePassword.SendPassword += new frmNotePassword.GetPassword(CheckPassword);
                frmNotePassword.Show();
            }
        }

        private void tsmConvertToSchedule_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Text.Contains("$SCHL$>"))
            {
                try
                {
                    string sch = trvNote.SelectedNode.Text.Replace("$SCHL$>", "");
                    string[] sp = sch.Split('@');
                    if (sp.Length < 3)
                    {
                        MessageBox.Show("Incorrect input format. Correct format is as follows: $SCHL$>ScheduleName@HH:MM-HH:MM(+1)@Color[@TaskName@Where@With]");
                    }
                    else
                    {
                        // Log Name
                        string LogName = sp[0];
                        // Time
                        bool addOneDayFlag = sp[1].Contains("(+1)");
                        if (addOneDayFlag)
                        {
                            sp[1] = sp[1].Replace("(+1)", "");
                        }
                        string[] schTimeStr = sp[1].Split('-');
                        string[] schStartStr = schTimeStr[0].Split(':');
                        string[] schEndStr = schTimeStr[1].Split(':');
                        DateTime StartTime = new DateTime(
                            Convert.ToInt32(noteDateTime.Year), Convert.ToInt32(noteDateTime.Month), Convert.ToInt32(noteDateTime.Day),
                            Convert.ToInt32(schStartStr[0]), Convert.ToInt32(schStartStr[1]), 0);
                        DateTime EndTime = new DateTime(
                            Convert.ToInt32(noteDateTime.Year), Convert.ToInt32(noteDateTime.Month), Convert.ToInt32(noteDateTime.Day),
                            Convert.ToInt32(schEndStr[0]), Convert.ToInt32(schEndStr[1]), 0);
                        if (addOneDayFlag)
                        {
                            EndTime += new TimeSpan(1, 0, 0, 0);
                        }
                        // Color
                        string Color = sp[2];
                        // Location
                        string Location = "";
                        if (sp.Length >= 4)
                        {
                            Location = sp[3];
                        }
                        // With
                        string WithWho = "";
                        if (sp.Length >= 5)
                        {
                            WithWho = sp[4];
                        }

                        // 判断是否能添加日程
                        bool CanAddScheduleFlag = true;
                        bool ReplaceExistFlag = false;
                        if (CanAddScheduleFlag && G.glb.lstSchedule.Exists(o => (o.StartTime <= StartTime && o.EndTime >= StartTime) || (o.StartTime >= StartTime && o.StartTime <= EndTime)))
                        {
                            DialogResult result = MessageBox.Show("Already have logs at that time, Do you replace?", "Log", MessageBoxButtons.YesNo);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    ReplaceExistFlag = true;
                                    break;
                                case DialogResult.No:
                                    CanAddScheduleFlag = false;
                                    break;
                                default:
                                    break;
                            }
                        }

                        if (ReplaceExistFlag)
                        {
                            G.glb.lstSchedule.RemoveAll(o => (o.StartTime <= StartTime && o.EndTime >= StartTime) || (o.StartTime >= StartTime && o.StartTime <= EndTime));
                        }

                        if (CanAddScheduleFlag)
                        {
                            CLog newSchedule = new CLog();
                            newSchedule.LogName = LogName;
                            newSchedule.StartTime = StartTime;
                            newSchedule.EndTime = EndTime;
                            newSchedule.Location = Location;
                            newSchedule.WithWho = WithWho;
                            newSchedule.Color = Color;
                            newSchedule.Alarm = true;
                            newSchedule.AlarmTime = StartTime - new TimeSpan(0, Convert.ToInt16(5), 0);
                            G.glb.lstSchedule.Add(newSchedule);
                            MessageBox.Show("Schedule added to record.");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Incorrect input format. Correct format is as follows: $SCHL$>YYYY.MM.DD@HH:MM:SS-HH:MM:SS(+1)@ScheduleName@Color[@TaskName@Where@With]");
                }
            }
        }

        private void tsmConvertToLog_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Text.Contains("$RECO$>"))
            {
                try
                {
                    string sch = trvNote.SelectedNode.Text.Replace("$RECO$>", "");
                    string[] sp = sch.Split('@');
                    if (sp.Length < 3)
                    {
                        MessageBox.Show("Incorrect input format. Correct format is as follows: $RECO$>ScheduleName@HH:MM-HH:MM(+1)@Color[@TaskName@Where@With]");
                    }
                    else
                    {
                        // Log Name
                        string LogName = sp[0];
                        // Time
                        bool addOneDayFlag = sp[1].Contains("(+1)");
                        if (addOneDayFlag)
                        {
                            sp[1] = sp[1].Replace("(+1)", "");
                        }
                        string[] schTimeStr = sp[1].Split('-');
                        string[] schStartStr = schTimeStr[0].Split(':');
                        string[] schEndStr = schTimeStr[1].Split(':');
                        DateTime StartTime = new DateTime(
                            Convert.ToInt32(noteDateTime.Year), Convert.ToInt32(noteDateTime.Month), Convert.ToInt32(noteDateTime.Day),
                            Convert.ToInt32(schStartStr[0]), Convert.ToInt32(schStartStr[1]), 0);
                        DateTime EndTime = new DateTime(
                            Convert.ToInt32(noteDateTime.Year), Convert.ToInt32(noteDateTime.Month), Convert.ToInt32(noteDateTime.Day),
                            Convert.ToInt32(schEndStr[0]), Convert.ToInt32(schEndStr[1]), 0);
                        if (addOneDayFlag)
                        {
                            EndTime += new TimeSpan(1, 0, 0, 0);
                        }
                        // Color
                        string Color = sp[2];
                        // Location
                        string Location = "";
                        if (sp.Length >= 4)
                        {
                            Location = sp[3];
                        }
                        // With
                        string WithWho = "";
                        if (sp.Length >= 5)
                        {
                            WithWho = sp[4];
                        }

                        // 判断是否能添加日程
                        bool CanAddScheduleFlag = true;
                        bool ReplaceExistFlag = false;
                        if (CanAddScheduleFlag && G.glb.lstLog.Exists(o => (o.StartTime <= StartTime && o.EndTime >= StartTime) || (o.StartTime >= StartTime && o.StartTime <= EndTime)))
                        {
                            DialogResult result = MessageBox.Show("Already have logs at that time, Do you replace?", "Log", MessageBoxButtons.YesNo);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    ReplaceExistFlag = true;
                                    break;
                                case DialogResult.No:
                                    CanAddScheduleFlag = false;
                                    break;
                                default:
                                    break;
                            }
                        }

                        if (ReplaceExistFlag)
                        {
                            G.glb.lstLog.RemoveAll(o => (o.StartTime <= StartTime && o.EndTime >= StartTime) || (o.StartTime >= StartTime && o.StartTime <= EndTime));
                        }

                        if (CanAddScheduleFlag)
                        {
                            CLog newSchedule = new CLog();
                            newSchedule.LogName = LogName;
                            newSchedule.StartTime = StartTime;
                            newSchedule.EndTime = EndTime;
                            newSchedule.Location = Location;
                            newSchedule.WithWho = WithWho;
                            newSchedule.Color = Color;
                            newSchedule.Alarm = true;
                            newSchedule.AlarmTime = StartTime - new TimeSpan(0, Convert.ToInt16(5), 0);
                            G.glb.lstLog.Add(newSchedule);
                            MessageBox.Show("Log added to record.");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Incorrect input format. Correct format is as follows: $RECO$>YYYY.MM.DD@HH:MM:SS-HH:MM:SS(+1)@ScheduleName@Color[@TaskName@Where@With]");
                }
            }
        }

        private void tsmConvertToTransaction_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null && trvNote.SelectedNode.Text.Contains("$TRSA$>"))
            {
                try
                {
                    string transactionSeg = trvNote.SelectedNode.Text.Replace("$TRSA$>", "");
                    transactionSeg = transactionSeg.Replace("=>", "@");
                    string[] transactionNote = transactionSeg.Split('@');
                    string accountFrom = transactionNote[2];
                    string accountTo = transactionNote[3];

                    bool CanSaveFlag = true;
                    if (G.glb.lstTransaction.Exists(o => o.TagTime == noteDateTime && o.Summary == transactionNote[0]))
                    {
                        CanSaveFlag = false;
                    }

                    if (CanSaveFlag)
                    {
                        CTransaction newTransaction = new CTransaction();
                        newTransaction.TagTime = noteDateTime;
                        newTransaction.Summary = transactionNote[0];
                        newTransaction.CreditAccount = transactionNote[2];
                        newTransaction.CreditAmount = Convert.ToDouble(transactionNote[1]);
                        newTransaction.CreditCurrency = G.glb.lstAccount.Find(o => o.AccountName == transactionNote[2]).Currency;
                        newTransaction.DebitAccount = transactionNote[3];
                        newTransaction.DebitAmount = Convert.ToDouble(transactionNote[1]);
                        newTransaction.DebitCurrency = G.glb.lstAccount.Find(o => o.AccountName == transactionNote[3]).Currency;
                        calculate C = new calculate();
                        newTransaction.IconType = C.MoneyInOrOut(
                            G.glb.lstAccount.Find(o => o.AccountName == transactionNote[3]).AccountType,
                            G.glb.lstAccount.Find(o => o.AccountName == transactionNote[2]).AccountType);
                        G.glb.lstTransaction.Add(newTransaction);
                        MessageBox.Show("Transaction added to record.");
                    }
                    else
                    {
                        MessageBox.Show("Transaction already exist.");
                    }
                }
                catch
                {
                    MessageBox.Show("Incorrect input format. Correct format is as follows: $TRSA$>Transaction Summary@Price@Credit Account=>Debit Account");
                }
            }
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkShow.Checked)
            {
                tblNote.RowStyles[1].Height = 0;
                tblNote.RowStyles[2].Height = 0;
                tblNote.RowStyles[3].Height = 0;
                tblNote.RowStyles[4].Height = 0;
                tblNote.RowStyles[5].Height = 0;
                tblNote.RowStyles[6].Height = 0;
                tblNote.RowStyles[7].Height = 0;
                if (noteType == ENoteType.DailyReport)
                {
                    splitContainer1.Panel1Collapsed = false;
                    splitContainer2.Panel1Collapsed = false;
                }
                else
                {
                    splitContainer1.Panel1Collapsed = true;
                    splitContainer2.Panel1Collapsed = true;
                }
            }
            else
            {
                if (noteType == ENoteType.Note || noteType == ENoteType.System)
                {
                    tblNote.RowStyles[1].Height = 26;
                    tblNote.RowStyles[2].Height = 0;
                    tblNote.RowStyles[3].Height = 0;
                    tblNote.RowStyles[4].Height = 0;
                    tblNote.RowStyles[5].Height = 0;
                    tblNote.RowStyles[6].Height = 100;
                    tblNote.RowStyles[7].Height = 0;
                    splitContainer1.Panel1Collapsed = true;
                    splitContainer2.Panel1Collapsed = true;
                }
                else if (noteType == ENoteType.DailyReport)
                {
                    tblNote.RowStyles[1].Height = 26;
                    tblNote.RowStyles[2].Height = 0;
                    tblNote.RowStyles[3].Height = 0;
                    tblNote.RowStyles[4].Height = 0;
                    tblNote.RowStyles[5].Height = 0;
                    tblNote.RowStyles[6].Height = 100;
                    tblNote.RowStyles[7].Height = 0;
                    splitContainer1.Panel1Collapsed = false;
                    splitContainer2.Panel1Collapsed = false;
                }
                else if (noteType == ENoteType.LitReview)
                {
                    tblNote.RowStyles[1].Height = 26;
                    tblNote.RowStyles[2].Height = 0;
                    tblNote.RowStyles[3].Height = 0;
                    tblNote.RowStyles[4].Height = 0;
                    tblNote.RowStyles[5].Height = 0;
                    tblNote.RowStyles[6].Height = 100;
                    tblNote.RowStyles[7].Height = 26;
                    splitContainer1.Panel1Collapsed = true;
                    splitContainer2.Panel1Collapsed = true;
                }
                else if (noteType == ENoteType.Literature)
                {
                    tblNote.RowStyles[1].Height = 0;
                    tblNote.RowStyles[2].Height = 26;
                    tblNote.RowStyles[3].Height = 26;
                    tblNote.RowStyles[4].Height = 26;
                    tblNote.RowStyles[5].Height = 120;
                    tblNote.RowStyles[6].Height = 100;
                    tblNote.RowStyles[7].Height = 0;
                    splitContainer1.Panel1Collapsed = true;
                    splitContainer2.Panel1Collapsed = true;
                }
            }
        }

        private void tsmRenameNote_Click(object sender, EventArgs e)
        {
            if (noteType == ENoteType.Note || noteType == ENoteType.LitReview)
            {
                string newLog = Interaction.InputBox("Input new note name", "New Note Name", note.Topic, 300, 300);
                if (newLog != "" && newLog != note.Topic)
                {
                    // First check if such name is exist
                    if (G.glb.lstNote.Exists(o => o.Topic == newLog && o.TagTime == note.TagTime))
                    {
                        MessageBox.Show("Note exists!");
                    }
                    else
                    {
                        // 先把当前窗口的东西变了
                        this.Text = "LifeGame - Note - " + newLog;
                        string oldTopic = txtTopic.Text;
                        txtTopic.Text = newLog;
                        trvNote.Nodes[0].Text = newLog;

                        // 把G.glb里的信息更新了
                        foreach (RNoteColor item in G.glb.lstNoteColor.FindAll(o => o.Topic == oldTopic && o.TagTime == note.TagTime))
                        {
                            item.Topic = newLog;
                        }

                        foreach (RNoteLog item in G.glb.lstNoteLog.FindAll(o => o.Topic == oldTopic && o.TagTime == note.TagTime))
                        {
                            item.Topic = newLog;
                        }

                        foreach (CNote item in G.glb.lstNote.FindAll(o => o.Topic == oldTopic && o.TagTime == note.TagTime))
                        {
                            item.Topic = newLog;
                        }

                        // 把G.glb里带有该note的引用信息更新了
                        foreach (RNoteLog item in G.glb.lstNoteLog.FindAll(o => o.Log.Contains("$NOTE$>") && o.Log.Contains(oldTopic)))
                        {
                            item.Log = item.Log.Replace(oldTopic, newLog);
                        }
                        foreach (RNoteLog item in G.glb.lstNoteLog.FindAll(o => o.SubLog.Contains("$NOTE$>") && o.SubLog.Contains(oldTopic)))
                        {
                            item.SubLog = item.SubLog.Replace(oldTopic, newLog);
                        }


                        // 把打开的Note的条目更新了
                        // 暂时不好改，先搁置着...

                        // 把note里的信息更新了
                        foreach (RNoteColor item in noteColors)
                        {
                            item.Topic = newLog;
                        }

                        foreach (RNoteLog item in noteLogs)
                        {
                            item.Topic = newLog;
                            if (item.Log == oldTopic)
                            {
                                item.Log = newLog;
                            }
                            if (item.SubLog == oldTopic)
                            {
                                item.SubLog = newLog;
                            }
                        }

                        note.Topic = newLog;

                        LoadNoteLog();
                    }
                }
            }
            else
            {
                MessageBox.Show("Error: Cannot rename this note!");
            }
        }

        public delegate void RefreshTabHandler();
        public event RefreshTabHandler RefreshTab;

        ParseBibTeX ParseBib = new ParseBibTeX();
        private void ParseBibTeXText(CBibTeX bib)
        {
            switch (bib.BibEntry)
            {
                case EBibEntry.Article:
                    txtBibRef.Text = ParseBib.ParseBibTeXArticle(bib, literature.DateAdded, literature.DateModified);
                    break;
                case EBibEntry.Book:
                    break;
                case EBibEntry.Booklet:
                    break;
                case EBibEntry.Conference:
                    txtBibRef.Text = ParseBib.ParseBibTeXConference(bib, literature.DateAdded, literature.DateModified);
                    break;
                case EBibEntry.Inbook:
                    break;
                case EBibEntry.Incollection:
                    break;
                case EBibEntry.Manual:
                    break;
                case EBibEntry.Mastersthesis:
                    txtBibRef.Text = ParseBib.ParseBibTeXMastersthesis(bib, literature.DateAdded, literature.DateModified);
                    break;
                case EBibEntry.Misc:
                    break;
                case EBibEntry.Phdthesis:
                    txtBibRef.Text = ParseBib.ParseBibTeXPhdthesis(bib, literature.DateAdded, literature.DateModified);
                    break;
                case EBibEntry.Proceedings:
                    break;
                case EBibEntry.Techreport:
                    break;
                case EBibEntry.Unpublished:
                    txtBibRef.Text = ParseBib.ParseBibTeXUnpublished(bib, literature.DateAdded, literature.DateModified);
                    break;
                default:
                    break;
            }
            literatureBib = bib;
            literature.DateModified = DateTime.Today;
        }

        private void LoadLiterature()
        {
            txtTitle.Enabled = false;
            txtTitle.Text = literature.Title;
            txtTopic.Text = literature.Title;
            txtYear.Text = literature.PublishYear.ToString();
            cbxJournalConference.Text = literature.JournalOrConferenceName;
            txtBibKey.Text = literature.BibKey;
            chkStar.Checked = literature.Star;
            chkPredatroyAlert.Checked = literature.PredatoryAlert;
            if (literature.BibTeX != null)
            {
                cbxBibEntryType.Text = literature.BibTeX.BibEntry.ToString();
                ParseBibTeXText(literature.BibTeX);
            }
            lsbAuthor.Items.Clear();
            foreach (RLiteratureAuthor author in lstLiteratureAuthor)
            {
                lsbAuthor.Items.Add(author.Author);
            }
            lsbTag.Items.Clear();
            foreach (RLiteratureTag tag in lstLiteratureTag)
            {
                lsbTag.Items.Add(tag.Tag);
            }
        }

        private string SelectedAttri = "";
        private void cmsAttri_Opening(object sender, CancelEventArgs e)
        {
            SelectedAttri = (sender as ContextMenuStrip).SourceControl.Name;
        }

        private void GetTag(string strTag)
        {
            if (!lsbTag.Items.Contains(strTag))
            {
                RLiteratureTag newTag = new RLiteratureTag();
                newTag.Tag = strTag;
                lstLiteratureTag.Add(newTag);
                lsbTag.Items.Add(strTag);
            }
        }

        private void tsmAttriAdd_Click(object sender, EventArgs e)
        {
            modifiedFlag = true;
            switch (SelectedAttri)
            {
                case "lsbTag":
                    frmAddTag frmAddTag = new frmAddTag();
                    frmAddTag.SendTag += new frmAddTag.GetTag(GetTag);
                    frmAddTag.Show();
                    break;
                case "lsbInCiting":
                    //string strInCiting = Interaction.InputBox("Literature InCiting", "Literature InCiting", "Literature InCiting", 300, 300);
                    //RLiteratureInCiting newInCiting = new RLiteratureInCiting();
                    //newInCiting.TitleOfMyArticle = strInCiting;
                    //lstLiteratureInCiting.Add(newInCiting);
                    //lsbInCiting.Items.Add(strInCiting);
                    break;
                default:
                    break;
            }
        }

        private void tsmAttriRemove_Click(object sender, EventArgs e)
        {
            modifiedFlag = true;
            switch (SelectedAttri)
            {
                case "lsbTag":
                    if (lsbTag.SelectedItem != null)
                    {
                        lstLiteratureTag.RemoveAll(o => o.Tag == lsbTag.SelectedItem.ToString());
                    }
                    lsbTag.Items.Clear();
                    foreach (RLiteratureTag Tag in lstLiteratureTag)
                    {
                        lsbTag.Items.Add(Tag.Tag);
                    }
                    break;
                case "lsbInCiting":
                    //if (lsbInCiting.SelectedItem != null)
                    //{
                    //    lstLiteratureInCiting.RemoveAll(o => o.TitleOfMyArticle == lsbInCiting.SelectedItem.ToString());
                    //}
                    //lsbInCiting.Items.Clear();
                    //foreach (RLiteratureInCiting InCiting in lstLiteratureInCiting)
                    //{
                    //    lsbInCiting.Items.Add(InCiting.TitleOfMyArticle);
                    //}
                    break;
                default:
                    break;
            }
        }

        private void GetBibKey()
        {
            string bibKey = "";
            if (lsbAuthor.Items.Count > 0)
            {
                string firstAuthor = lsbAuthor.Items[0].ToString();
                string[] firstAuthorNameSplit = firstAuthor.Split(" ".ToCharArray());
                bibKey = firstAuthorNameSplit[firstAuthorNameSplit.Length - 1] + txtYear.Text;
            }
            txtBibKey.Text = bibKey;
        }

        private void GetAuthor(string strAuthor)
        {
            RLiteratureAuthor newAuthor = new RLiteratureAuthor();
            newAuthor.Author = strAuthor;
            newAuthor.Rank = lsbAuthor.Items.Count;
            lstLiteratureAuthor.Add(newAuthor);
            lsbAuthor.Items.Add(strAuthor);
            GetBibKey();
        }

        private void tsmAuthorAdd_Click(object sender, EventArgs e)
        {
            modifiedFlag = true;
            frmAddAuthor frmAddAuthor = new frmAddAuthor();
            frmAddAuthor.SendAuthor += new frmAddAuthor.GetAuthor(GetAuthor);
            frmAddAuthor.Show();
        }

        private void tsmAuthorRemove_Click(object sender, EventArgs e)
        {
            modifiedFlag = true;
            if (lsbAuthor.SelectedItem != null)
            {
                lstLiteratureAuthor.RemoveAll(o => o.Author == lsbAuthor.SelectedItem.ToString());
            }
            lsbAuthor.Items.Clear();
            lstLiteratureAuthor = lstLiteratureAuthor.OrderBy(o => o.Rank).ToList();
            for (int i = 0; i < lstLiteratureAuthor.Count; i++)
            {
                lsbAuthor.Items.Add(lstLiteratureAuthor[i].Author);
                lstLiteratureAuthor[i].Rank = i;
            }
            GetBibKey();
        }

        private void tsmAuthorUp_Click(object sender, EventArgs e)
        {
            modifiedFlag = true;
            if (lsbAuthor.SelectedItem != null)
            {
                if (lsbAuthor.SelectedIndex > 0)
                {
                    int selectedIndex = lsbAuthor.SelectedIndex;
                    string itemSelected = lsbAuthor.SelectedItem.ToString();
                    lsbAuthor.Items.RemoveAt(selectedIndex);
                    lsbAuthor.Items.Insert(selectedIndex - 1, itemSelected);
                    lstLiteratureAuthor[selectedIndex].Rank = selectedIndex - 1;
                    lstLiteratureAuthor[selectedIndex - 1].Rank = selectedIndex;
                    lstLiteratureAuthor = lstLiteratureAuthor.OrderBy(o => o.Rank).ToList();
                }
            }
            GetBibKey();
        }

        private void tsmAuthorDown_Click(object sender, EventArgs e)
        {
            modifiedFlag = true;
            if (lsbAuthor.SelectedItem != null)
            {
                if (lsbAuthor.SelectedIndex < lsbAuthor.Items.Count - 1)
                {
                    int selectedIndex = lsbAuthor.SelectedIndex;
                    string itemSelected = lsbAuthor.SelectedItem.ToString();
                    lsbAuthor.Items.RemoveAt(selectedIndex);
                    lsbAuthor.Items.Insert(selectedIndex + 1, itemSelected);
                    lstLiteratureAuthor[selectedIndex].Rank = selectedIndex + 1;
                    lstLiteratureAuthor[selectedIndex + 1].Rank = selectedIndex;
                    lstLiteratureAuthor = lstLiteratureAuthor.OrderBy(o => o.Rank).ToList();
                }
            }
            GetBibKey();
        }

        private void btnBibTeX_Click(object sender, EventArgs e)
        {
            // First, create a temp literature log, use it to generate BibTeX
            // So that we don't need to care if the BibTeX is generated for new literature log or existing literature log
            // Anyway, BibTeX is just a set of attribution and eventually become a string
            CLiterature tmpLiterature = new CLiterature();
            tmpLiterature.Title = txtTitle.Text;
            tmpLiterature.BibKey = txtBibKey.Text;
            tmpLiterature.JournalOrConferenceName = cbxJournalConference.Text;
            tmpLiterature.BibTeX = literatureBib;
            modifiedFlag = true;

            if (txtTitle.Enabled == false)
            {
                tmpLiterature.DateAdded = G.glb.lstLiterature.Find(o => o.Title == txtTitle.Text).DateAdded;
            }
            else
            {
                tmpLiterature.DateAdded = DateTime.Today;
            }
            tmpLiterature.DateModified = DateTime.Today;
            if (txtYear.Text == "")
            {
                tmpLiterature.PublishYear = 9999;
            }
            else
            {
                tmpLiterature.PublishYear = Convert.ToInt32(txtYear.Text);
            }
            List<RLiteratureAuthor> tmpAuthorList = new List<RLiteratureAuthor>();
            for (int i = 0; i < lsbAuthor.Items.Count; i++)
            {
                RLiteratureAuthor tmpAuthor = new RLiteratureAuthor();
                tmpAuthor.Author = lsbAuthor.Items[i].ToString();
                tmpAuthor.Rank = i;
                tmpAuthorList.Add(tmpAuthor);
            }

            switch (cbxBibEntryType.Text)
            {
                case "Article":
                    frmBibArticle frmBibArticle = new frmBibArticle(tmpLiterature, tmpAuthorList);
                    frmBibArticle.BuildBibTeX += new frmBibArticle.BuildBibTeXHandler(ParseBibTeXText);
                    frmBibArticle.Show();
                    break;
                case "Mastersthesis":
                    RLiteratureAuthor tmpMasterAuthor = new RLiteratureAuthor();
                    if (tmpAuthorList.Count > 0)
                    {
                        tmpMasterAuthor = tmpAuthorList[0];
                    }
                    else
                    {
                        tmpMasterAuthor.Author = "";
                    }
                    frmBibMasterThesis frmBibMasterThesis = new frmBibMasterThesis(tmpLiterature, tmpMasterAuthor);
                    frmBibMasterThesis.BuildBibTeX += new frmBibMasterThesis.BuildBibTeXHandler(ParseBibTeXText);
                    frmBibMasterThesis.Show();
                    break;
                case "Phdthesis":
                    RLiteratureAuthor tmpPhDAuthor = new RLiteratureAuthor();
                    if (tmpAuthorList.Count > 0)
                    {
                        tmpPhDAuthor = tmpAuthorList[0];
                    }
                    else
                    {
                        tmpPhDAuthor.Author = "";
                    }
                    frmBibPhDThesis frmBibPhDThesis = new frmBibPhDThesis(tmpLiterature, tmpPhDAuthor);
                    frmBibPhDThesis.BuildBibTeX += new frmBibPhDThesis.BuildBibTeXHandler(ParseBibTeXText);
                    frmBibPhDThesis.Show();
                    break;
                case "Conference":
                    frmBibConference frmBibConference = new frmBibConference(tmpLiterature, tmpAuthorList);
                    frmBibConference.BuildBibTeX += new frmBibConference.BuildBibTeXHandler(ParseBibTeXText);
                    frmBibConference.Show();
                    break;
                case "Unpublished":
                    frmBibUnpublished frmBibUnpublished = new frmBibUnpublished(tmpLiterature, tmpAuthorList);
                    frmBibUnpublished.BuildBibTeX += new frmBibUnpublished.BuildBibTeXHandler(ParseBibTeXText);
                    frmBibUnpublished.Show();
                    break;
                default:
                    break;
            }
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            modifiedFlag = true;
            GetBibKey();
        }

        private void btnGoogleScholar_Click(object sender, EventArgs e)
        {
            string url = "https://scholar.google.com/scholar?hl=en&as_sdt=0%2C33&q=" + txtTitle.Text.Replace(" ", "+") + "&btnG=";
            System.Diagnostics.Process.Start("chrome.exe", url);
        }

        private void cbxJournalConference_TextChanged(object sender, EventArgs e)
        {
            modifiedFlag = true;
        }

        private void cbxBibEntryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            modifiedFlag = true;
        }

        private void chkStar_CheckedChanged(object sender, EventArgs e)
        {
            modifiedFlag = true;
        }

        private void chkPredatroyAlert_CheckedChanged(object sender, EventArgs e)
        {
            modifiedFlag = true;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            if (txtTitle.Enabled)
            {
                if (G.glb.lstLiterature.Exists(o => o.Title == txtTitle.Text))
                {
                    MessageBox.Show("Literature exists!");
                }
                txtTopic.Text = txtTitle.Text;
                modifiedFlag = true;

                if (trvNote.Nodes[0].Nodes.Count == 0)
                {
                    trvNote.Nodes[0].Nodes.Add("modified: " + DateTime.Now.ToString("F"));
                    trvNote.Nodes[0].Nodes[0].BackColor = Color.Pink;
                    trvNote.Nodes[0].Nodes[0].NodeFont = new Font(Font, FontStyle.Bold);
                    trvNote.Nodes[0].Nodes.Add("Q&A");
                    trvNote.Nodes[0].Nodes.Add("key take-away");
                }
            }
        }

        private void btnFullText_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "Literature\\" + txtTitle.Text + ".pdf";
                path = path.Replace(":", "-");
                path = "D:\\" + path;
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot find full text in 'D:\\Literature\\'.");
            }
        }

        private void relabelNodeNext(TreeNode node)
        {
            List<string> labels = new List<string>();
            foreach (RNoteColor item in noteColors)
            {
                labels.Add(item.Keyword);
            }
            for (int i = 0; i < labels.Count; i++)
            {
                if (node.Text.Contains(labels[i]))
                {
                    int newI = i + 1;
                    if (newI >= labels.Count)
                    {
                        newI = 0;
                    }
                    node.Text = node.Text.Replace(labels[i], labels[newI]);
                    (node.BackColor, node.ForeColor, node.NodeFont) = getColor(node.Text);
                    node.StateImageIndex = getLogo(node.Text);
                    break;
                }
            }
        }

        private void relabelNodePrev(TreeNode node)
        {
            List<string> labels = new List<string>();
            foreach (RNoteColor item in noteColors)
            {
                labels.Add(item.Keyword);
            }
            for (int i = 0; i < labels.Count; i++)
            {
                if (node.Text.Contains(labels[i]))
                {
                    int newI = i - 1;
                    if (newI < 0)
                    {
                        newI = labels.Count - 1;
                    }
                    node.Text = node.Text.Replace(labels[i], labels[newI]);
                    (node.BackColor, node.ForeColor, node.NodeFont) = getColor(node.Text);
                    node.StateImageIndex = getLogo(node.Text);
                    break;
                }
            }
        }

        private void tsmRotateLabelNext_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                relabelNodeNext(trvNote.SelectedNode);

                UpdateModifiedNodeTime(trvNote.SelectedNode);
            }
        }

        private void tsmRotateLabelPrev_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                relabelNodePrev(trvNote.SelectedNode);

                UpdateModifiedNodeTime(trvNote.SelectedNode);
            }
        }

        private void lsvColor_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lsvColor.SelectedItems.Count == 1)
            {
                string selectedLabel = lsvColor.SelectedItems[0].Text;
                int[] count = countLabel(trvNote.Nodes[0], selectedLabel);
                int labelCount = count[0];
                int labelWordCount = count[1];
                lblLabelCount.Text = labelCount.ToString();
                lblLabelWordCount.Text = labelWordCount.ToString();
            }
            else
            {
                lblLabelCount.Text = "-";
                lblLabelWordCount.Text = "-";
            }
        }

        private void tsmProgressAdd_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                if (trvNote.SelectedNode.Text.Contains("%") && trvNote.SelectedNode.Text.ToCharArray().Count(c => c == '%') == 1)
                {
                    string percentStr = Regex.Match(trvNote.SelectedNode.Text, @"(?<num>\d+)(?:\%)").Groups["num"].Value;
                    if (percentStr != "")
                    {
                        int percent = Convert.ToInt32(percentStr);
                        percent += 5;
                        if (percent >= 100)
                        {
                            percent = 100;
                        }
                        trvNote.SelectedNode.Text = trvNote.SelectedNode.Text.Replace(percentStr, percent.ToString());
                        (trvNote.SelectedNode.BackColor, trvNote.SelectedNode.ForeColor, trvNote.SelectedNode.NodeFont) = getColor(trvNote.SelectedNode.Text);
                        trvNote.SelectedNode.StateImageIndex = getLogo(trvNote.SelectedNode.Text);
                        UpdateModifiedNodeTime(trvNote.SelectedNode);
                    }
                }
            }
        }

        private void tsmProgressMinus_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                if (trvNote.SelectedNode.Text.Contains("%") && trvNote.SelectedNode.Text.ToCharArray().Count(c => c == '%') == 1)
                {
                    string percentStr = Regex.Match(trvNote.SelectedNode.Text, @"(?<num>\d+)(?:\%)").Groups["num"].Value;
                    if (percentStr != "")
                    {
                        int percent = Convert.ToInt32(percentStr);
                        percent -= 5;
                        if (percent <= 0)
                        {
                            percent = 0;
                        }
                        trvNote.SelectedNode.Text = trvNote.SelectedNode.Text.Replace(percentStr, percent.ToString());
                        (trvNote.SelectedNode.BackColor, trvNote.SelectedNode.ForeColor, trvNote.SelectedNode.NodeFont) = getColor(trvNote.SelectedNode.Text);
                        trvNote.SelectedNode.StateImageIndex = getLogo(trvNote.SelectedNode.Text);
                        UpdateModifiedNodeTime(trvNote.SelectedNode);
                    }
                }
            }
        }

        private void tsmProgressSetPtg(int percentage)
        {
            if (trvNote.SelectedNode != null)
            {
                if (trvNote.SelectedNode.Text.Contains("%") && trvNote.SelectedNode.Text.ToCharArray().Count(c => c == '%') == 1)
                {
                    string percentStr = Regex.Match(trvNote.SelectedNode.Text, @"(?<num>\d+)(?:\%)").Groups["num"].Value;
                    if (percentStr != "")
                    {
                        int percent = Convert.ToInt32(percentage);
                        if (percent <= 0)
                        {
                            percent = 0;
                        }
                        if (percent >= 100)
                        {
                            percent = 100;
                        }
                        trvNote.SelectedNode.Text = trvNote.SelectedNode.Text.Replace(percentStr, percent.ToString());
                        (trvNote.SelectedNode.BackColor, trvNote.SelectedNode.ForeColor, trvNote.SelectedNode.NodeFont) = getColor(trvNote.SelectedNode.Text);
                        trvNote.SelectedNode.StateImageIndex = getLogo(trvNote.SelectedNode.Text);
                        UpdateModifiedNodeTime(trvNote.SelectedNode);
                    }
                }
            }
        }

        private void lsvColor_DoubleClick(object sender, EventArgs e)
        {
            if (lsvColor.SelectedItems.Count == 1)
            {
                string selectedLabel = lsvColor.SelectedItems[0].Text;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (M.shownLits.Count > 0)
            {
                CLiterature prevLit = new CLiterature();
                int litIndex = M.shownLits.FindIndex(o => o == txtTitle.Text);
                if (litIndex == -1)
                {
                    prevLit = G.glb.lstLiterature.Find(o => o.Title == M.shownLits[0]);
                }
                else if (litIndex == 0)
                {
                    prevLit = G.glb.lstLiterature.Find(o => o.Title == M.shownLits[M.shownLits.Count - 1]);
                }
                else
                {
                    prevLit = G.glb.lstLiterature.Find(o => o.Title == M.shownLits[litIndex - 1]);
                }

                frmInfoNote frmInfoNote = new frmInfoNote(prevLit);
                M.notesOpened.Add(frmInfoNote);
                frmInfoNote.Show();

                M.notesOpened.RemoveAll(o => o.note.Topic == note.Topic && o.note.TagTime == note.TagTime);
                SaveLiterature();
                Dispose();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (M.shownLits.Count > 0)
            {
                CLiterature nextLit = new CLiterature();
                int litIndex = M.shownLits.FindIndex(o => o == txtTitle.Text);
                if (litIndex == -1)
                {
                    nextLit = G.glb.lstLiterature.Find(o => o.Title == M.shownLits[0]);
                }
                else if (litIndex == M.shownLits.Count - 1)
                {
                    nextLit = G.glb.lstLiterature.Find(o => o.Title == M.shownLits[0]);
                }
                else
                {
                    nextLit = G.glb.lstLiterature.Find(o => o.Title == M.shownLits[litIndex + 1]);
                }

                frmInfoNote frmInfoNote = new frmInfoNote(nextLit);
                M.notesOpened.Add(frmInfoNote);
                frmInfoNote.Show();

                M.notesOpened.RemoveAll(o => o.note.Topic == note.Topic && o.note.TagTime == note.TagTime);
                SaveLiterature();
                Dispose();
            }
        }

        private TreeNode createLitNoteLogNode()
        {
            TreeNode rootNode = new TreeNode(note.Topic, 0, 0);
            rootNode.Name = note.GUID;
            rootNode.Text = note.Topic;

            TreeNode metaNode = new TreeNode("meta", 0, 0);
            metaNode.Name = Guid.NewGuid().ToString();

            TreeNode yearNode = new TreeNode("year", 0, 0);
            yearNode.Name = Guid.NewGuid().ToString();
            yearNode.Text = "year: " + G.glb.lstLiterature.Find(o => o.Title == note.LiteratureTitle).PublishYear.ToString();
            metaNode.Nodes.Add(yearNode);

            TreeNode jourNode = new TreeNode("", 0, 0);
            jourNode.Name = Guid.NewGuid().ToString();
            jourNode.Text = "jourConf: " + G.glb.lstLiterature.Find(o => o.Title == note.LiteratureTitle).JournalOrConferenceName;
            metaNode.Nodes.Add(jourNode);

            List<RLiteratureAuthor> authors = new List<RLiteratureAuthor>();
            authors = G.glb.lstLiteratureAuthor.FindAll(o => o.Title == note.LiteratureTitle).ToList();
            foreach (RLiteratureAuthor author in authors)
            {
                TreeNode authorNode = new TreeNode(author.Author, 0, 0);
                authorNode.Name = Guid.NewGuid().ToString();
                authorNode.Text = "author: " + author.Author;
                metaNode.Nodes.Add(authorNode);
            }

            TreeNode tagRootNode = new TreeNode("tag", 0, 0);
            tagRootNode.Name = Guid.NewGuid().ToString();

            List<RLiteratureTag> tags = new List<RLiteratureTag>();
            tags = G.glb.lstLiteratureTag.FindAll(o => o.Title == note.LiteratureTitle).ToList();
            foreach (RLiteratureTag tag in tags)
            {
                TreeNode tagNode = new TreeNode(tag.Tag, 0, 0);
                tagNode.Name = Guid.NewGuid().ToString();
                tagNode.Text = "tag: " + tag.Tag;
                tagRootNode.Nodes.Add(tagNode);
            }

            rootNode.Nodes.Add(metaNode);
            rootNode.Nodes.Add(tagRootNode);
            rootNode.Expand();

            foreach (TreeNode tr in trvNote.Nodes[0].Nodes)
            {
                if (tr.Nodes.Count > 0)
                {
                    TreeNode sub = new TreeNode(tr.Text, 0, 0);
                    sub.Name = tr.Name;
                    sub.Text = tr.Text;
                    LoadChildNoteLog(sub, note.Topic);
                    sub.Name = Guid.NewGuid().ToString();
                    rootNode.Nodes.Add(sub);
                }
            }

            rootNode.Text = "$LITR$>" + note.LiteratureTitle;
            rootNode.Name = Guid.NewGuid().ToString();
            rootNode.ForeColor = Color.Brown;
            rootNode.NodeFont = new Font(Font, FontStyle.Underline);
            return rootNode;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            TreeNode litNode = createLitNoteLogNode();
            M.mem.copiedNodes.Clear();
            copyNode(litNode);
        }

        private void tsmCopyFile_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                try
                {
                    string lit = trvNote.SelectedNode.Text.ToString();
                    lit = lit.Replace("$LITR$>", "");
                    lit = lit.Replace(":", "-");
                    string files = "D:\\Literature\\" + lit + ".pdf";
                    System.Collections.Specialized.StringCollection toCopy = new System.Collections.Specialized.StringCollection();
                    toCopy.Add(files);
                    Clipboard.SetFileDropList(toCopy);
                }
                catch { }
            }
        }

        private void tsmCopyBibTeX_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                try
                {
                    string litTopic = trvNote.SelectedNode.Text.ToString();
                    litTopic = litTopic.Replace("$LITR$>", "");
                    litTopic = litTopic.Replace(":", "-");
                    CLiterature lit = G.glb.lstLiterature.Find(o => o.Title == litTopic);
                    string bib = "";
                    if (lit != null)
                    {
                        ParseBibTeX bibParser = new ParseBibTeX();
                        switch (lit.BibTeX.BibEntry)
                        {
                            case EBibEntry.Article:
                                bib = bibParser.ParseBibTeXArticle(lit.BibTeX);
                                break;
                            case EBibEntry.Conference:
                                bib = bibParser.ParseBibTeXConference(lit.BibTeX);
                                break;
                            case EBibEntry.Mastersthesis:
                                bib = bibParser.ParseBibTeXMastersthesis(lit.BibTeX);
                                break;
                            case EBibEntry.Phdthesis:
                                bib = bibParser.ParseBibTeXPhdthesis(lit.BibTeX);
                                break;
                            case EBibEntry.Unpublished:
                                bib = bibParser.ParseBibTeXUnpublished(lit.BibTeX);
                                break;
                            default:
                                break;
                        }
                    }
                    Clipboard.SetText(bib);
                }
                catch { }
            }
        }

        private void tsmAddProgress_Click(object sender, EventArgs e)
        {
            if (trvNote.SelectedNode != null)
            {
                noteAddProgress(trvNote.SelectedNode, "Mid");
            }
            UpdateModifiedNodeTime(trvNote.SelectedNode);
        }

        private void noteAddProgress(TreeNode node, string place)
        {
            // 先确认有没有progress
            if (!(node.Text.Contains("%") && node.Text.ToCharArray().Count(c => c == '%') == 1)
                && !node.Text.Contains("$LITR$>")
                && !node.Text.Contains("$NOTE$>")
                && !node.Text.Contains("$LINK$>")
                && !node.Text.Contains("$JUMP$>")
                && !node.Text.Contains("$SCHL$>")
                && !node.Text.Contains("$RECO$>")
                && !node.Text.Contains("$TSRA$>"))
            {
                if (place == "Front")
                {
                    node.Text = "[0%] - " + node.Text;
                }
                else if (place == "End")
                {
                    node.Text = node.Text + " - [0%]";
                }
                else if (place == "Mid")
                {
                    string[] split = node.Text.Split(':');
                    string newNote = split[0];
                    if (split.Length > 1)
                    {
                        newNote += ": [0%] - ";
                        for (int i = 1; i < split.Length; i++)
                        {
                            newNote += split[i];
                        }
                    }
                    else
                    {
                        newNote += " - [0%]";
                    }
                    node.Text = newNote;
                }
                (node.BackColor, node.ForeColor, node.NodeFont) = getColor(node.Text);
                node.StateImageIndex = getLogo(node.Text);
            }
            foreach (TreeNode child in node.Nodes)
            {
                noteAddProgress(child, place);
            }
        }

        private void picToday_Resize(object sender, EventArgs e)
        {
            if (noteType == ENoteType.DailyReport)
            {
                DrawDailySchedule();
            }
        }

        private void picToday_Click(object sender, EventArgs e)
        {
            if (noteType == ENoteType.DailyReport)
            {
                DrawDailySchedule();
            }
        }

        private void tsmGoToShare_Click(object sender, EventArgs e)
        {
            if (trvShare.SelectedNode != null)
            {
                if (trvShare.SelectedNode.Text.Contains("$LINK$>"))
                {
                    string selectedPath = trvShare.SelectedNode.Text.Split('@')[0];
                    selectedPath = selectedPath.Replace("$LINK$>", "");
                    string[] checkUrl = selectedPath.Split(':');
                    if (checkUrl[0] == "http" || checkUrl[0] == "https")
                    {
                        System.Diagnostics.Process.Start("chrome.exe", selectedPath);
                    }
                    else
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(selectedPath);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("File/link is not found.");
                        }
                    }
                }
                else if (trvShare.SelectedNode.Text.Contains("$LITR$>"))
                {
                    string selectedPath = trvShare.SelectedNode.Text.Split('@')[0];
                    selectedPath = selectedPath.Replace("$LITR$>", "");
                    if (G.glb.lstLiterature.Exists(o => o.Title == selectedPath))
                    {
                        if (M.notesOpened.Exists(o => o.note.LiteratureTitle == selectedPath))
                        {
                            M.notesOpened.Find(o => o.note.LiteratureTitle == selectedPath).Show();
                            M.notesOpened.Find(o => o.note.LiteratureTitle == selectedPath).BringToFront();
                        }
                        else
                        {
                            frmInfoNote frmInfoNote = new frmInfoNote(G.glb.lstLiterature.Find(o => o.Title == selectedPath));
                            M.notesOpened.Add(frmInfoNote);
                            frmInfoNote.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Literature does not exist in database");
                    }
                }
                else if (trvShare.SelectedNode.Text.Contains("$NOTE$>"))
                {
                    string selectedPath = trvShare.SelectedNode.Text.Replace("$NOTE$>", "");
                    string[] checkNote = selectedPath.Split('@');
                    DateTime noteDate = new DateTime();
                    string noteTitle = "";
                    bool tryOpenFlag = true;
                    if (checkNote.Length != 2)
                    {
                        MessageBox.Show("Incorrect Note Format, correct format should be 'YYYY.MM.DD@Note'");
                        tryOpenFlag = false;
                    }
                    else
                    {
                        string[] dateNote = checkNote[0].Split('.');
                        if (dateNote.Length != 3)
                        {
                            MessageBox.Show("Incorrect Note Format, correct format should be 'YYYY.MM.DD@Note'");
                            tryOpenFlag = false;
                        }
                        else
                        {
                            noteDate = new DateTime(Convert.ToInt32(dateNote[0]), Convert.ToInt32(dateNote[1]), Convert.ToInt32(dateNote[2]));
                        }
                    }

                    for (int i = 1; i < checkNote.Length; i++)
                    {
                        noteTitle = noteTitle + checkNote[i];
                        if (i < checkNote.Length - 1)
                        {
                            noteTitle = noteTitle + " ";
                        }
                    }
                    if (tryOpenFlag && G.glb.lstNote.Exists(o => o.TagTime == noteDate && o.Topic == noteTitle))
                    {
                        if (M.notesOpened.Exists(o => o.note.Topic == noteTitle && o.note.TagTime == noteDate))
                        {
                            M.notesOpened.Find(o => o.note.Topic == noteTitle && o.note.TagTime == noteDate).Show();
                            M.notesOpened.Find(o => o.note.Topic == noteTitle && o.note.TagTime == noteDate).BringToFront();
                        }
                        else
                        {
                            frmInfoNote frmInfoNote = new frmInfoNote(G.glb.lstNote.Find(o => o.TagTime == noteDate && o.Topic == noteTitle));
                            M.notesOpened.Add(frmInfoNote);
                            frmInfoNote.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot find record.");
                    }
                }
                else if (trvShare.SelectedNode.Text.Contains("$JUMP$>"))
                {
                    string selectedText = trvShare.SelectedNode.Text.Replace("$JUMP$>", "");
                    trvShare.SelectedNode = findByName(trvShare.Nodes[0], selectedText);
                }
                else if (trvShare.SelectedNode.Text.Split('#').Length == 3)
                {
                    string selectedText = trvShare.SelectedNode.Text.Split('#')[1];
                    trvShare.SelectedNode = findByName(trvShare.Nodes[0], selectedText);
                }
            }
        }

        private void tsmShowNote_Click(object sender, EventArgs e)
        {
            if (M.notesOpened.Exists(o => o.note.Topic == TDLNoteName))
            {
                M.notesOpened.Find(o => o.note.Topic == TDLNoteName).Show();
                M.notesOpened.Find(o => o.note.Topic == TDLNoteName).BringToFront();
            }
            else
            {
                frmInfoNote frmInfoNote = new frmInfoNote(G.glb.lstNote.Find(o => o.Topic == TDLNoteName));
                M.notesOpened.Add(frmInfoNote);
                frmInfoNote.Show();
            }
        }

        private void tsmUpdateShareNote_Click(object sender, EventArgs e)
        {
            trvShare.Nodes.Clear();
            LoadShareNoteLog();
        }

        private void btnPrevDate_Click(object sender, EventArgs e)
        {
            DateTime prevDate = note.TagTime.Date.AddDays(-1);
            if (G.glb.lstNote.Exists(o => o.Topic == "Daily Report" && o.TagTime == prevDate))
            {
                CNote prevDateNote = G.glb.lstNote.Find(o => o.Topic == "Daily Report" && o.TagTime.Date == prevDate.Date);
                frmInfoNote frmInfoNote = new frmInfoNote(prevDateNote);
                M.notesOpened.Add(frmInfoNote);
                frmInfoNote.Show();
            }
            else
            {
                frmInfoNote frmInfoNote = new frmInfoNote(prevDate, true);
                M.notesOpened.Add(frmInfoNote);
                frmInfoNote.Show();
            }

            M.notesOpened.RemoveAll(o => o.note.Topic == note.Topic && o.note.TagTime == note.TagTime);
            SaveNote();
            Dispose();
        }

        private void btnNextDate_Click(object sender, EventArgs e)
        {
            DateTime nextDate = note.TagTime.Date.AddDays(1);
            if (G.glb.lstNote.Exists(o => o.Topic == "Daily Report" && o.TagTime == nextDate))
            {
                CNote prevDateNote = G.glb.lstNote.Find(o => o.Topic == "Daily Report" && o.TagTime.Date == nextDate.Date);
                frmInfoNote frmInfoNote = new frmInfoNote(prevDateNote);
                M.notesOpened.Add(frmInfoNote);
                frmInfoNote.Show();
            }
            else
            {
                frmInfoNote frmInfoNote = new frmInfoNote(nextDate, true);
                M.notesOpened.Add(frmInfoNote);
                frmInfoNote.Show();
            }

            M.notesOpened.RemoveAll(o => o.note.Topic == note.Topic && o.note.TagTime == note.TagTime);
            SaveNote();
            Dispose();
        }

        private void trvShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void trvShare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
                tsmGoToShare_Click(trvShare, e);
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                tsmShowNote_Click(trvShare, e);
            }
        }

        private void btnJournal_Click(object sender, EventArgs e)
        {
            string journalNoteName = "SysNote: Journal Information";
            if (M.notesOpened.Exists(o => o.note.Topic == journalNoteName))
            {
                M.notesOpened.Find(o => o.note.Topic == journalNoteName).Show();
                M.notesOpened.Find(o => o.note.Topic == journalNoteName).BringToFront();
            }
            else
            {
                frmInfoNote frmInfoNote = new frmInfoNote(G.glb.lstNote.Find(o => o.Topic == journalNoteName));
                M.notesOpened.Add(frmInfoNote);
                frmInfoNote.Show();
            }
        }

        private void btnRegroup_Click(object sender, EventArgs e)
        {
            dicLitReviewTag.Clear();
            CollectLitTagTree();
            trvNote.Nodes[0].Nodes.Clear();
            List<string> hirearacy = new List<string>();
            string[] tagSplit = txtTagHierarchy.Text.Split(';');
            for (int i = 0; i < tagSplit.Length; i++)
            {
                if (dictTagValues.ContainsKey(tagSplit[i].Trim()))
                {
                    hirearacy.Add(tagSplit[i].Trim());
                }
            }
            BuildLitByLevel(trvNote.Nodes[0], hirearacy, new List<Tuple<string, string>>());
        }

        private void BuildLitByLevel(TreeNode treeNode, List<string> remainTags, List<Tuple<string, string>> searchedTags)
        {
            if (remainTags.Count == 0)
            {
                BuildLitBottomLevel(treeNode, searchedTags);
            }
            // remainTags里的第一个取出来，找到所有的取值，每个取值都生成一个子节点
            else
            {
                foreach (string tagValue in dictTagValues[remainTags[0]])
                {
                    // 先看看有没有符合搜索条件的
                    bool haschild = false;
                    if (searchedTags.Count > 0)
                    {
                        // 只要找到一个lit满足所有的条件就可以
                        foreach (var lit in dicLitReviewTag)
                        {
                            // 每个都得满足条件才算满足，所以先假设是满足的，一个个看能不能找到
                            bool fitFlag = true;
                            foreach (var search in searchedTags)
                            {
                                if (!dicLitReviewTag[lit.Key].Contains(search))
                                {
                                    fitFlag = false;
                                    break;
                                }
                            }
                            if (fitFlag)
                            {
                                if (!dicLitReviewTag[lit.Key].Contains(new Tuple<string, string>(remainTags[0], tagValue)))
                                {
                                    fitFlag = false;
                                }
                            }

                            if (fitFlag)
                            {
                                haschild = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        haschild = true;
                    }

                    if (haschild)
                    {
                        TreeNode tagNode = new TreeNode(remainTags[0] + ": " + tagValue);
                        (tagNode.BackColor, tagNode.ForeColor, tagNode.NodeFont) = getColor(remainTags[0] + ": " + tagValue);

                        List<string> newRemainTags = new List<string>();
                        if (remainTags.Count >= 1)
                        {
                            for (int i = 1; i < remainTags.Count; i++)
                            {
                                newRemainTags.Add(remainTags[i]);
                            }
                        }
                        List<Tuple<string, string>> newSearchTags = new List<Tuple<string, string>>();
                        for (int i = 0; i < searchedTags.Count; i++)
                        {
                            newSearchTags.Add(searchedTags[i]);
                        }
                        newSearchTags.Add(new Tuple<string, string>(remainTags[0], tagValue));
                        BuildLitByLevel(tagNode, newRemainTags, newSearchTags);
                        treeNode.Nodes.Add(tagNode);
                    }
                    else
                    {

                    }
                }
            }
        }

        private void BuildLitBottomLevel(TreeNode treeNode, List<Tuple<string, string>> searchedTags)
        {
            // 过滤出符合条件的Lit，添加为子节点
            foreach (var lit in dicLitReviewTag)
            {
                // 过滤剩下用来显示的
                List<string> takenTags = new List<string>();

                bool fitFlag = true;
                foreach (var search in searchedTags)
                {
                    takenTags.Add(search.Item1);
                    if (!dicLitReviewTag[lit.Key].Contains(search))
                    {
                        fitFlag = false;
                        break;
                    }
                }

                // 如果符合条件，添加一批子节点
                if (fitFlag)
                {
                    TreeNode litNode = new TreeNode(lit.Key);
                    (litNode.BackColor, litNode.ForeColor, litNode.NodeFont) = getColor(lit.Key);
                    litNode.StateImageIndex = getLogo(lit.Key);
                    foreach (var tag in lit.Value)
                    {
                        if (tag.Item2 != "" && !takenTags.Contains(tag.Item1))
                        {
                            TreeNode tagNode = new TreeNode(tag.Item1 + ": " + tag.Item2);
                            (tagNode.BackColor, tagNode.ForeColor, tagNode.NodeFont) = getColor(tag.Item1 + ": " + tag.Item2);
                            litNode.Nodes.Add(tagNode);
                        }
                    }
                    treeNode.Nodes.Add(litNode);
                }
                else 
                { 
                
                }
            }
        }

        private void CollectLitTagTree()
        {
            dictTagValues.Clear();
            // 先搜集所有已有的tag
            foreach (TreeNode child in trvNote.Nodes[0].Nodes)
            {
                CollectLitByLevel(child, new List<string>());
            }
            // 对于没有出现过的tag，补全，键值记为null
            List<string> allTags = new List<string>();
            foreach (var item in dicLitReviewTag)
            {
                foreach (var v in item.Value)
                {
                    if (!allTags.Contains(v.Item1))
                    {
                        allTags.Add(v.Item1);
                    }
                }
            }
            foreach (var item in dicLitReviewTag)
            {
                // 看看有哪些tag
                List<string> existTags = new List<string>();
                foreach (var v in item.Value)
                {
                    if (!existTags.Contains(v.Item1))
                    {
                        existTags.Add(v.Item1);
                    }
                }
                // 看看是不是每个tag都有
                foreach (string tag in allTags)
                {
                    if (!existTags.Contains(tag))
                    {
                        dicLitReviewTag[item.Key].Add(new Tuple<string, string>(tag, ""));
                    }
                }
            }
            foreach (var item in dicLitReviewTag)
            {
                foreach (var v in item.Value)
                {
                    if (!dictTagValues.ContainsKey(v.Item1))
                    {
                        dictTagValues[v.Item1] = new List<string>();
                    }
                    if (!dictTagValues[v.Item1].Contains(v.Item2))
                    {
                        dictTagValues[v.Item1].Add(v.Item2);
                    }
                }
            }
        }

        private void CollectLitByLevel(TreeNode treeNode, List<string> aboveTags)
        {
            // 如果treeNode已经是LITR，搜索结束，把途径到这里的上层tags和所有下层tag都存起来
            if (treeNode.Text.Contains("$LITR$>"))
            {
                string litName = treeNode.Text;
                if (!dicLitReviewTag.ContainsKey(litName))
                {
                    dicLitReviewTag[litName] = new List<Tuple<string, string>>();
                }
                foreach (string above in aboveTags)
                {
                    string[] splits = above.Split(':');
                    string tagName = "";
                    string tagValue = "";
                    if (splits.Length > 1)
                    {
                        tagName = splits[0].Trim();
                        for (int i = 1; i < splits.Length; i++)
                        {
                            tagValue += splits[i].Trim();
                        }
                        if (!dicLitReviewTag[litName].Contains(new Tuple<string, string>(tagName, tagValue)))
                        {
                            dicLitReviewTag[litName].Add(new Tuple<string, string>(tagName, tagValue));
                        }
                    }
                    else if (splits.Length == 1)
                    {
                        tagName = "desc";
                        tagValue = splits[0];
                        if (!dicLitReviewTag[litName].Contains(new Tuple<string, string>(tagName, tagValue)))
                        {
                            dicLitReviewTag[litName].Add(new Tuple<string, string>(tagName, tagValue));
                        }
                    }
                }
                foreach (TreeNode child in treeNode.Nodes)
                {
                    string[] splits = child.Text.Split(':');
                    string tagName = "";
                    string tagValue = "";
                    if (splits.Length > 1)
                    {
                        tagName = splits[0].Trim();
                        for (int i = 1; i < splits.Length; i++)
                        {
                            tagValue += splits[i].Trim();
                        }
                        if (!dicLitReviewTag[litName].Contains(new Tuple<string, string>(tagName, tagValue)))
                        {
                            dicLitReviewTag[litName].Add(new Tuple<string, string>(tagName, tagValue));
                        }
                    }
                    else if (splits.Length == 1)
                    {
                        tagName = "desc";
                        tagValue = splits[0];
                        if (!dicLitReviewTag[litName].Contains(new Tuple<string, string>(tagName, tagValue)))
                        {
                            dicLitReviewTag[litName].Add(new Tuple<string, string>(tagName, tagValue));
                        }
                    }
                }
            }
            else
            {
                foreach (TreeNode child in treeNode.Nodes)
                {
                    List<string> updatedTags = new List<string>();
                    foreach (string item in aboveTags)
                    {
                        updatedTags.Add(item);
                    }
                    updatedTags.Add(treeNode.Text);
                    CollectLitByLevel(child, updatedTags);
                }
            }
        }
    }
}
