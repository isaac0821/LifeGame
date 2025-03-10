﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace LifeGame
{
    public partial class frmLiterature : Form
    {
        //记录tag结构，随时需要更新
        List<CLiteratureTag> lstTags = new List<CLiteratureTag>();
        List<RSubLiteratureTag> lstSubTags = new List<RSubLiteratureTag>();

        CheckedListBox clbTempLitsAreaA = new CheckedListBox();
        CheckedListBox clbTempLitsAreaB = new CheckedListBox();

        //记录数量
        List<CItem> Tags = new List<CItem>();
        List<CItem> Authors = new List<CItem>();
        List<CItem> JournalConferences = new List<CItem>();

        //记录Journal Information，关闭/打开窗口时更新
        List<CJournalConf> lstJournal = new List<CJournalConf>();

        public frmLiterature()
        {
            InitializeComponent();
        }

        private void frmLiterature_Load(object sender, EventArgs e)
        {
            LoadJournalInfo();
            lstTags = G.glb.lstLiteratureTagType.ToList();
            lstSubTags = G.glb.lstSubLiteratureTag.ToList();
            cbxMode.Text = "AND";
            LoadTab();

            clbTempLitsAreaA.Dock = DockStyle.Fill;
            clbTempLitsAreaA.ContextMenuStrip = cmsTempLitsArea;
            clbTempLitsAreaA.BorderStyle = BorderStyle.None;
            clbTempLitsAreaA.Name = "clbTempLitsAreaA";
            clbTempLitsAreaB.Dock = DockStyle.Fill;
            clbTempLitsAreaB.ContextMenuStrip = cmsTempLitsArea;
            clbTempLitsAreaB.BorderStyle = BorderStyle.None;
            clbTempLitsAreaB.Name = "clbTempLitsAreaB";

            tblTempArea.RowCount = 2;
            tblTempArea.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblTempArea.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblTempArea.ColumnCount = 1;
            tblTempArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblTempArea.Controls.Add(clbTempLitsAreaA, 0, 0);
            tblTempArea.Controls.Add(clbTempLitsAreaB, 0, 1);
        }

        private string journalNoteName = "SysNote: Journal Information";
        
        private void LoadJournalInfo()
        {
            List<RNoteLog> jours = G.glb.lstNoteLog.FindAll(o => o.Topic == journalNoteName).ToList();
            foreach (RNoteLog item in jours)
            {
                CJournalConf journal = new CJournalConf();
                journal.Name = item.SubLog;
                // 得到具体的内容
                List<RNoteLog> details = G.glb.lstNoteLog.FindAll(o => o.Topic == journalNoteName && o.Log == journal.Name).ToList();
                foreach (RNoteLog info in details)
                {
                    string text = info.SubLog;
                    string[] split = text.Split(':');
                    // 如果有Abbr
                    if (split[0] == "Abbr" && split.Length > 1)
                    {
                        journal.Abbr = split[1].Trim();
                    }
                    // 如果有Description
                    if (split[0] == "Desc" && split.Length > 1)
                    {
                        journal.Description = split[1].Trim();
                    }
                    // 如果有IsPredatory
                    if (split[0] == "IsPred" && split.Length > 1)
                    {
                        journal.isGarbage = true;
                    }
                    // 如果有IsReliable
                    if (split[0] == "IsGood" && split.Length > 1)
                    {
                        journal.isReliable = true;
                    }
                    // 如果有Publisher
                    if (split[0] == "Publisher" && split.Length > 1)
                    {
                        journal.Publisher = split[1].Trim();
                    }
                }
                lstJournal.Add(journal);
            }
        }
        private void SaveJournalInfo()
        {
            List<string> litTitle = new List<string>();
            foreach (CLiterature item in G.glb.lstLiterature)
            {
                if (!litTitle.Contains(item.JournalOrConferenceName))
                {
                    litTitle.Add(item.JournalOrConferenceName);
                }
            }
            // string jourGUID = G.glb.lstNote.Find(o => o.Topic == journalNoteName).GUID;
            DateTime tagTime = G.glb.lstNote.Find(o => o.Topic == journalNoteName).TagTime;
            foreach (string item in litTitle)
            {
                if (!G.glb.lstNoteLog.Exists(o => 
                        o.Topic == journalNoteName
                        && o.Log == item) &&
                    !G.glb.lstNoteLog.Exists(o =>
                        o.Topic == journalNoteName
                        && o.SubLog == item))
                {
                    RNoteLog newJour = new RNoteLog();
                    newJour.SubLog = item;
                    newJour.SubGUID = Guid.NewGuid().ToString();
                    newJour.Log = journalNoteName;
                    newJour.GUID = "";
                    newJour.Topic = journalNoteName;
                    // newJour.TopicGUID = jourGUID;
                    newJour.TagTime = tagTime;
                    G.glb.lstNoteLog.Add(newJour);
                }
            }
        }

        private class CItem
        {
            public CItem(string name, int count)
            {
                ItemName = name;
                ItemCount = count;
            }
            public string ItemName;
            public int ItemCount;
        }

        private void LoadTab()
        {
            Tags = new List<CItem>();
            foreach (CLiterature literature in G.glb.lstLiterature)
            {
                // By Tag
                List<RLiteratureTag> lstTag = G.glb.lstLiteratureTag.FindAll(o => o.Title == literature.Title).ToList();
                foreach (RLiteratureTag tag in lstTag)
                {
                    Tags.Add(new CItem(tag.Tag, 0));
                }

                foreach (RLiteratureTag tag in lstTag)
                {
                    if (Tags.Exists(o => o.ItemName == tag.Tag))
                    {
                        Tags[Tags.FindIndex(o => o.ItemName == tag.Tag)].ItemCount += 1;
                    }

                    if (!lstTags.Exists(o => o.Tag == tag.Tag))
                    {
                        CLiteratureTag newTag = new CLiteratureTag();
                        newTag.Tag = tag.Tag;
                        newTag.GUID = Guid.NewGuid().ToString();
                        lstTags.Add(newTag);

                        RSubLiteratureTag newSubTag = new RSubLiteratureTag();
                        newSubTag.Tag = "(Root)";
                        newSubTag.GUID = G.glb.lstLiteratureTagType.Find(o => o.Tag == "(Root)").GUID;
                        newSubTag.SubTag = tag.Tag;
                        newSubTag.SubGUID = newTag.GUID;
                        lstSubTags.Add(newSubTag);
                    }
                }
            }
            LoadTag();
            LoadLiteratureList(M.shownLits);
        }

        private void tsmAddLiterature_Click(object sender, EventArgs e)
        {
            //frmInfoLiterature frmInfoLiterature = new frmInfoLiterature();
            //frmInfoLiterature.RefreshTab += new frmInfoLiterature.RefreshTabHandler(LoadTab);
            //frmInfoLiterature.Show();

            frmInfoNote frmInfoNote = new frmInfoNote();
            frmInfoNote.RefreshTab += new frmInfoNote.RefreshTabHandler(LoadTab);
            frmInfoNote.Show();
        }

        private void tsmViewLiterature_Click(object sender, EventArgs e)
        {
            if (dgvLiterature.SelectedCells.Count == 1)
            {
                if (M.notesOpened.Exists(o => o.note.LiteratureTitle == dgvLiterature.CurrentRow.Cells[1].Value.ToString()))
                {
                    M.notesOpened.Find(o => o.note.LiteratureTitle == dgvLiterature.CurrentRow.Cells[1].Value.ToString()).Show();
                    M.notesOpened.Find(o => o.note.LiteratureTitle == dgvLiterature.CurrentRow.Cells[1].Value.ToString()).BringToFront();
                }
                else
                {
                    frmInfoNote frmInfoNote = new frmInfoNote(G.glb.lstLiterature.Find(o => o.Title == dgvLiterature.CurrentRow.Cells[1].Value.ToString()));
                    frmInfoNote.RefreshTab += new frmInfoNote.RefreshTabHandler(LoadTab);
                    M.notesOpened.Add(frmInfoNote);
                    frmInfoNote.Show();
                }
            }
        }

        private void tsmRemoveLiterature_Click(object sender, EventArgs e)
        {
            if (dgvLiterature.SelectedCells.Count == 1)
            {
                DialogResult result = MessageBox.Show("Delete this literature?", "Delete", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        string removedLit = dgvLiterature.CurrentRow.Cells[1].Value.ToString();
                        if (M.tempLitsA.Contains(removedLit))
                        {
                            M.tempLitsA.RemoveAll(o => o == removedLit);
                            clbTempLitsAreaA.Items.Clear();
                            foreach (string item in M.tempLitsA)
                            {
                                clbTempLitsAreaA.Items.Add(item, false);
                            }
                        }
                        if (M.tempLitsB.Contains(removedLit))
                        {
                            M.tempLitsB.RemoveAll(o => o == removedLit);
                            clbTempLitsAreaB.Items.Clear();
                            foreach (string item in M.tempLitsB)
                            {
                                clbTempLitsAreaB.Items.Add(item, false);
                            }
                        }
                        G.glb.lstLiterature.RemoveAll(o => o.Title == removedLit);
                        G.glb.lstLiteratureTag.RemoveAll(o => o.Title == removedLit);
                        G.glb.lstLiteratureAuthor.RemoveAll(o => o.Title == removedLit);
                        DialogResult noteResult = MessageBox.Show("Delete related note?", "Delete", MessageBoxButtons.YesNo);
                        switch (noteResult)
                        {
                            case DialogResult.Yes:
                                if (G.glb.lstNote.Exists(o => o.LiteratureTitle == removedLit))
                                {
                                    string topicGUID = G.glb.lstNote.Find(o => o.LiteratureTitle == removedLit).GUID;
                                    G.glb.lstNote.RemoveAll(o => o.LiteratureTitle == removedLit);
                                    G.glb.lstNoteLog.RemoveAll(o => o.TopicGUID == topicGUID);
                                }
                                break;
                            case DialogResult.No:
                                if (G.glb.lstNote.Exists(o => o.LiteratureTitle == removedLit))
                                {
                                    G.glb.lstNote.Find(o => o.LiteratureTitle == removedLit).LiteratureTitle = "";
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
            LoadTab();
        }

        private void btnSearchInResult_Click(object sender, EventArgs e)
        {
            if (cbxMode.Text == "AND")
            {
                if (M.shownLits.Count > 0 && txtSearchInRes.Text != "")
                {
                    List<string> newLitList = searchByText(txtSearchInRes.Text);
                    List<string> oriLitList = M.shownLits.ToList();

                    List<string> bothLitList = new List<string>();
                    foreach (string lit in oriLitList)
                    {
                        if (newLitList.Exists(o => o == lit))
                        {
                            bothLitList.Add(lit);
                        }
                    }
                    M.shownLits = bothLitList.ToList();
                    M.shownLits = M.shownLits.Distinct().ToList();
                    LoadLiteratureList(M.shownLits);
                }
            }
            else if (cbxMode.Text == "OR")
            {
                if (M.shownLits.Count > 0 && txtSearchInRes.Text != "")
                {
                    List<string> newLitList = searchByText(txtSearchInRes.Text);
                    M.shownLits.AddRange(newLitList);
                    M.shownLits = M.shownLits.Distinct().ToList();
                    LoadLiteratureList(M.shownLits);
                }
            }
            else if (cbxMode.Text == "NOT")
            {
                if (M.shownLits.Count > 0 && txtSearchInRes.Text != "")
                {
                    List<string> newLitList = searchByText(txtSearchInRes.Text);
                    foreach (string item in newLitList)
                    {
                        M.shownLits.RemoveAll(o => o == item);
                    }
                    M.shownLits = M.shownLits.Distinct().ToList();
                    LoadLiteratureList(M.shownLits);
                }
            }
        }

        private List<string> searchByText(string SearchText)
        {
            List<string> searched = new List<string>();
            foreach (CLiterature literature in G.glb.lstLiterature)
            {
                // Find literature with the search text in its title
                if (literature.Title.ToUpper().Contains(SearchText.ToUpper()))
                {
                    searched.Add(literature.Title);
                }
                // Find literature with the search text as part of the bibtex
                if (literature.BibKey.ToUpper().Contains(SearchText.ToUpper()))
                {
                    searched.Add(literature.Title);
                }
            }
            // Find literature with the search text as the author name
            List<string> AuthorNames = new List<string>();
            foreach (RLiteratureAuthor litAuthors in G.glb.lstLiteratureAuthor)
            {
                if (!AuthorNames.Contains(litAuthors.Author))
                {
                    AuthorNames.Add(litAuthors.Author);
                }
            }
            foreach (string author in AuthorNames)
            {
                if (author.ToUpper().Contains(SearchText.ToUpper()))
                {
                    foreach (RLiteratureAuthor literatureAuthor in G.glb.lstLiteratureAuthor.FindAll(o => o.Author == author))
                    {
                        searched.Add(literatureAuthor.Title);
                    }
                }
            }
            return searched;
        }

        private void LoadLiteratureList(List<string> loadedLits)
        {
            dgvLiterature.Rows.Clear();
            dgvLiterature.ShowCellToolTips = true;
            LoadJournalInfo();
            foreach (string title in loadedLits)
            {
                if (G.glb.lstLiterature.Exists(o => o.Title == title))
                {
                    DateTime addedDate = new DateTime();
                    DateTime lastModifyDate = new DateTime();
                    addedDate = G.glb.lstLiterature.Find(o => o.Title == title).DateAdded;
                    lastModifyDate = G.glb.lstLiterature.Find(o => o.Title == title).DateModified;
                    string starStr = "";
                    string predatoryStr = "";
                    bool predatoryShowFlag = true; // true if we want to show it
                    string goodJourStr = "";
                    bool goodJourShowFlag = false;  // true if we want to show it
                    bool showFlag = true;
                    string litType = "";
                    string abbr = "";
                    string publisher = "";
                    int year = G.glb.lstLiterature.Find(o => o.Title == title).PublishYear;
                    if (G.glb.lstLiterature.Find(o => o.Title == title).Star)
                    {
                        starStr = "√";
                    }
                    // If the journal is predatory
                    if (lstJournal.Exists(o => o.Name == G.glb.lstLiterature.Find(p => p.Title == title).JournalOrConferenceName))
                    {
                        if (lstJournal.Find(o => o.Name == G.glb.lstLiterature.Find(p => p.Title == title).JournalOrConferenceName).isGarbage)
                        {
                            predatoryStr = "√";
                            predatoryShowFlag = false;
                        }
                    }
                    if (G.glb.lstLiterature.Find(o => o.Title == title).PredatoryAlert)
                    {
                        predatoryStr = "√";
                        predatoryShowFlag = false;
                    }
                    // If the journal is reliable
                    if (lstJournal.Exists(o => o.Name == G.glb.lstLiterature.Find(p => p.Title == title).JournalOrConferenceName))
                    {
                        if (lstJournal.Find(o => o.Name == G.glb.lstLiterature.Find(p => p.Title == title).JournalOrConferenceName).isReliable)
                        {
                            goodJourStr = "√";
                            goodJourShowFlag = true;
                        }
                    }
                    // Only if chkOnlyGood is checked and goodJournalShowFlag is not true, don't show it.
                    if (chkOnlyGood.Checked && !goodJourShowFlag)
                    {
                        showFlag = false;
                    }
                    if (showFlag)
                    {
                        // For those showing lits, if chkNoBad is checked and the journal could be bad, don't show it.
                        if (chkNoBad.Checked && !predatoryShowFlag)
                        {
                            showFlag = false;
                        }
                    }
                    switch (G.glb.lstLiterature.Find(o => o.Title == title).BibTeX.BibEntry)
                    {
                        case EBibEntry.Article:
                            litType = "J";
                            break;
                        case EBibEntry.Book:
                            litType = "M";
                            break;
                        case EBibEntry.Booklet:
                            litType = "M";
                            break;
                        case EBibEntry.Conference:
                            litType = "C";
                            break;
                        case EBibEntry.Inbook:
                            litType = "M";
                            break;
                        case EBibEntry.Incollection:
                            litType = "A";
                            break;
                        case EBibEntry.Manual:
                            litType = "M";
                            break;
                        case EBibEntry.Mastersthesis:
                            litType = "D";
                            break;
                        case EBibEntry.Misc:
                            litType = "M";
                            break;
                        case EBibEntry.Phdthesis:
                            litType = "D";
                            break;
                        case EBibEntry.Proceedings:
                            litType = "C";
                            break;
                        case EBibEntry.Techreport:
                            litType = "R";
                            break;
                        case EBibEntry.Unpublished:
                            litType = "M";
                            break;
                        default:
                            break;
                    }
                    // Abbr
                    if (lstJournal.Exists(o => o.Name == G.glb.lstLiterature.Find(p => p.Title == title).JournalOrConferenceName))
                    {
                        abbr = lstJournal.Find(o => o.Name == G.glb.lstLiterature.Find(p => p.Title == title).JournalOrConferenceName).Abbr;
                    }
                    // Publisher
                    if (lstJournal.Exists(o => o.Name == G.glb.lstLiterature.Find(p => p.Title == title).JournalOrConferenceName))
                    {
                        publisher = lstJournal.Find(o => o.Name == G.glb.lstLiterature.Find(p => p.Title == title).JournalOrConferenceName).Publisher;
                    }

                    if (showFlag)
                    {
                        dgvLiterature.Rows.Add(
                            starStr, 
                            title, 
                            abbr,
                            publisher,
                            Convert.ToString(year), 
                            litType, 
                            goodJourStr, 
                            predatoryStr, 
                            addedDate.ToString("yyyy/MM/dd"), 
                            lastModifyDate.ToString("yyyy/MM/dd"));
                        if (chkHightlight.Checked && G.glb.lstNoteLog.FindAll(o => o.Topic == title).Count >= 4)
                        {
                            dgvLiterature.Rows[dgvLiterature.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                        }
                    }
                    lblNumFound.Text = Convert.ToString(dgvLiterature.Rows.Count) + " result(s) found";
                }
            }
        }

        private void LoadLiteratureList(string SearchText)
        {
            M.shownLits = searchByText(SearchText).Distinct().ToList();
            LoadLiteratureList(M.shownLits);
        }

        private void LoadLiteratureList()
        {
            M.shownLits.Clear();
            int startYear = Convert.ToInt32(txtStartYear.Text);
            int endYear = Convert.ToInt32(txtEndYear.Text);

            ChooseTag();

            List<string> chosenAuthors = new List<string>();
            for (int i = 0; i < clbAuthor.Items.Count; i++)
            {
                if (clbAuthor.CheckedItems.Contains(clbAuthor.Items[i]))
                {
                    chosenAuthors.Add(clbAuthor.Items[i].ToString().Split('[')[0]);
                }
            }
            List<string> chosenJourConf = new List<string>();
            for (int i = 0; i < clbJournalConference.Items.Count; i++)
            {
                if (clbJournalConference.CheckedItems.Contains(clbJournalConference.Items[i]))
                {
                    chosenJourConf.Add(clbJournalConference.Items[i].ToString().Split('[')[0]);
                }
            }

            foreach (CLiterature literature in G.glb.lstLiterature)
            {
                if (startYear <= literature.PublishYear
                    && literature.PublishYear <= endYear
                    && chosenAuthors.Exists(o => G.glb.lstLiteratureAuthor.Exists(p => p.Title == literature.Title && names.processName(p.Author) == o))
                    && chosenTags.Exists(o => G.glb.lstLiteratureTag.Exists(p => p.Title == literature.Title && p.Tag == o))
                    && chosenJourConf.Exists(o => o == literature.JournalOrConferenceName))
                {
                    M.shownLits.Add(literature.Title);
                }
            }
            M.shownLits = M.shownLits.Distinct().ToList();
            LoadLiteratureList(M.shownLits);
        }

        private void LoadTag()
        {
            trvTag.Nodes.Clear();
            TreeNode rootNode = new TreeNode("(Root)");
            rootNode.Checked = false;
            rootNode.Name = lstTags.Find(o => o.Tag == "(Root)").GUID;
            int tagNum = 0;
            if (Tags.Exists(o => o.ItemName == "(Root)"))
            {
                tagNum = Tags.Find(o => o.ItemName == "(Root)").ItemCount;
            }
            rootNode.Text = "(Root)" + "[" + tagNum.ToString() + "]";
            rootNode.Expand();
            LoadChildTag(rootNode, "(Root)");
            trvTag.Nodes.Add(rootNode);
        }

        private void LoadChildTag(TreeNode treeNode, string tag)
        {
            if (lstSubTags.Exists(o => o.Tag == tag && o.GUID == treeNode.Name))
            {
                List<RSubLiteratureTag> subTag = lstSubTags.FindAll(o => o.Tag == tag && o.GUID == treeNode.Name);
                subTag = subTag.OrderBy(o => o.Index).ToList();

                foreach (RSubLiteratureTag sub in subTag)
                {
                    TreeNode childNode = new TreeNode(sub.SubTag);
                    childNode.Checked = false;
                    childNode.Name = sub.SubGUID;
                    int tagNum = 0;
                    if (Tags.Exists(o => o.ItemName == sub.SubTag))
                    {
                        tagNum = Tags.Find(o => o.ItemName == sub.SubTag).ItemCount;
                    }
                    childNode.Text = sub.SubTag + "[" + tagNum.ToString() + "]";
                    childNode.Expand();
                    LoadChildTag(childNode, sub.SubTag);
                    treeNode.Nodes.Add(childNode);
                }
            }
        }

        List<string> chosenTags = new List<string>();
        private void ChooseTag()
        {
            chosenTags.Clear();
            if (trvTag.Nodes[0].Checked)
            {
                chosenTags.Add("(Root)");
            }
            foreach (TreeNode child in trvTag.Nodes[0].Nodes)
            {
                ChooseSubTag(child);
            }
        }

        private void ChooseSubTag(TreeNode treeNode)
        {
            if (treeNode.Checked)
            {
                chosenTags.Add(treeNode.Text.Split('[')[0]);
            }
            foreach (TreeNode child in treeNode.Nodes)
            {
                ChooseSubTag(child);
            }
        }

        private void UpdateAuthorJours()
        {
            List<string> taggedLiteratures = new List<string>();
            foreach (RLiteratureTag litTag in G.glb.lstLiteratureTag)
            {
                if (chosenTags.Exists(o => o == litTag.Tag)
                    && !taggedLiteratures.Exists(o => o == litTag.Title))
                {
                    taggedLiteratures.Add(litTag.Title);
                }
            }
            Authors = new List<CItem>();
            JournalConferences = new List<CItem>();
            foreach (string literature in taggedLiteratures)
            {
                // By Authors
                List<RLiteratureAuthor> lstAuthor = G.glb.lstLiteratureAuthor.FindAll(o => o.Title == literature).ToList();
                names names = new names();
                foreach (RLiteratureAuthor author in lstAuthor)
                {
                    if (Authors.Exists(o => o.ItemName == names.processName(author.Author)))
                    {
                        Authors[Authors.FindIndex(o => o.ItemName == names.processName(author.Author))].ItemCount += 1;
                    }
                    else
                    {
                        Authors.Add(new CItem(names.processName(author.Author), 1));
                    }
                }
                // By Journal/Conference
                if (JournalConferences.Exists(o => o.ItemName == G.glb.lstLiterature.Find(p => p.Title == literature).JournalOrConferenceName))
                {
                    JournalConferences[JournalConferences.FindIndex(o => o.ItemName == G.glb.lstLiterature.Find(p => p.Title == literature).JournalOrConferenceName)].ItemCount += 1;
                }
                else
                {
                    JournalConferences.Add(new CItem(G.glb.lstLiterature.Find(p => p.Title == literature).JournalOrConferenceName, 1));
                }
            }
            Authors = Authors.OrderBy(o => o.ItemName).ToList();
            Authors = Authors.OrderByDescending(o => o.ItemCount).ToList();
            JournalConferences = JournalConferences.OrderByDescending(o => o.ItemCount).ToList();
            JournalConferences = JournalConferences.OrderBy(o => o.ItemName).ToList();
            clbAuthor.Items.Clear();
            foreach (CItem author in Authors)
            {
                clbAuthor.Items.Add(author.ItemName + "[" + author.ItemCount.ToString() + "]", true);
            }
            clbJournalConference.Items.Clear();
            foreach (CItem jourConf in JournalConferences)
            {
                clbJournalConference.Items.Add(jourConf.ItemName + "[" + jourConf.ItemCount.ToString() + "]", true);
            }
        }

        // 在tag树结构变化时保存，保存到窗体内记录
        private void SaveTag()
        {
            lstTags = new List<CLiteratureTag>();
            lstSubTags = new List<RSubLiteratureTag>();
            CLiteratureTag rootTag = new CLiteratureTag();
            rootTag.Tag = "(Root)";
            rootTag.GUID = trvTag.Nodes[0].Name;
            lstTags.Add(rootTag);
            foreach (TreeNode child in trvTag.Nodes[0].Nodes)
            {
                SaveSubTag(child);
            }
            G.glb.lstLiteratureTagType.Clear();
            G.glb.lstSubLiteratureTag.Clear();
            foreach (CLiteratureTag item in lstTags)
            {
                G.glb.lstLiteratureTagType.Add(item);
            }
            foreach (RSubLiteratureTag item in lstSubTags)
            {
                G.glb.lstSubLiteratureTag.Add(item);
            }
        }

        private void SaveSubTag(TreeNode treeNode)
        {
            CLiteratureTag subTag = new CLiteratureTag();
            subTag.Tag = treeNode.Text.Split('[')[0];
            subTag.GUID = treeNode.Name;
            lstTags.Add(subTag);

            RSubLiteratureTag newSubTag = new RSubLiteratureTag();
            newSubTag.Tag = treeNode.Parent.Text.Split('[')[0];
            newSubTag.GUID = treeNode.Parent.Name;
            newSubTag.SubTag = treeNode.Text.Split('[')[0];
            newSubTag.SubGUID = treeNode.Name;
            newSubTag.Index = treeNode.Index;
            lstSubTags.Add(newSubTag);
            foreach (TreeNode child in treeNode.Nodes)
            {
                SaveSubTag(child);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                LoadLiteratureList(txtSearch.Text);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (clbAuthor.Items.Count == 0 || clbJournalConference.Items.Count == 0)
            {
                ChooseTag();
                UpdateAuthorJours();
            }
            LoadLiteratureList();
        }

        private void tsmExportBib_Click(object sender, EventArgs e)
        {
            string strTag = Interaction.InputBox("Tag", "Project", "Project", 300, 300);
            List<RLiteratureTag> lstLiterature = G.glb.lstLiteratureTag.FindAll(o => o.Tag == strTag);
            List<CLiterature> lstLitsToBeExported = new List<CLiterature>();

            string bib = "";

            foreach (RLiteratureTag lit in lstLiterature)
            {
                lstLitsToBeExported.Add(G.glb.lstLiterature.Find(o => o.Title == lit.Title));
            }
            foreach (CLiterature lit in lstLitsToBeExported)
            {
                ParseBibTeX ParseBibTeX = new ParseBibTeX();
                string bibLog = "";
                switch (lit.BibTeX.BibEntry)
                {
                    case EBibEntry.Article:
                        bibLog = ParseBibTeX.ParseBibTeXArticle(lit.BibTeX, lit.DateAdded, lit.DateModified);
                        break;
                    case EBibEntry.Book:
                        break;
                    case EBibEntry.Booklet:
                        break;
                    case EBibEntry.Conference:
                        bibLog = ParseBibTeX.ParseBibTeXConference(lit.BibTeX, lit.DateAdded, lit.DateModified);
                        break;
                    case EBibEntry.Inbook:
                        break;
                    case EBibEntry.Incollection:
                        break;
                    case EBibEntry.Manual:
                        break;
                    case EBibEntry.Mastersthesis:
                        bibLog = ParseBibTeX.ParseBibTeXMastersthesis(lit.BibTeX, lit.DateAdded, lit.DateModified);
                        break;
                    case EBibEntry.Misc:
                        break;
                    case EBibEntry.Phdthesis:
                        bibLog = ParseBibTeX.ParseBibTeXPhdthesis(lit.BibTeX, lit.DateAdded, lit.DateModified);
                        break;
                    case EBibEntry.Proceedings:
                        break;
                    case EBibEntry.Techreport:
                        break;
                    case EBibEntry.Unpublished:
                        bibLog = ParseBibTeX.ParseBibTeXUnpublished(lit.BibTeX, lit.DateAdded, lit.DateModified);
                        break;
                    default:
                        break;
                }

                bib += bibLog + "\n\n";
            }

            System.IO.File.WriteAllText(@"D:\" + strTag + "Bib.bib", bib);
        }

        private void chkOnlyGood_CheckedChanged(object sender, EventArgs e)
        {
            LoadLiteratureList();
        }

        private void chkNoBad_CheckedChanged(object sender, EventArgs e)
        {
            LoadLiteratureList();
        }
        private void chkHightlight_CheckedChanged(object sender, EventArgs e)
        {
            LoadLiteratureList();
        }

        private void dgvLiterature_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "colCited")
            {
                e.SortResult = (
                    Convert.ToString(e.CellValue1) == "" && Convert.ToString(e.CellValue2) == "" ? 0 :
                    Convert.ToString(e.CellValue1) != "" && Convert.ToString(e.CellValue2) == "" ? 1 :
                    Convert.ToString(e.CellValue1) == "" && Convert.ToString(e.CellValue2) != "" ? -1 :
                    Convert.ToInt32(e.CellValue1) > Convert.ToInt32(e.CellValue2) ? 1 :
                    Convert.ToInt32(e.CellValue1) < Convert.ToInt32(e.CellValue2) ? -1 :
                    0);
                e.Handled = true;
            }
        }

        private void AddTag2MultipleLiterature(string strTag)
        {
            if (dgvLiterature.SelectedRows.Count >= 1
                && MessageBox.Show("Do you confirm to add tag to all selected literature.", "Add Tag", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvLiterature.SelectedRows)
                {
                    // MessageBox.Show(row.Cells[1].Value.ToString());
                    if (!G.glb.lstLiteratureTag.Exists(o => o.Title == row.Cells[1].Value.ToString() && o.Tag == strTag))
                    {
                        RLiteratureTag newTag = new RLiteratureTag();
                        newTag.Title = row.Cells[1].Value.ToString();
                        newTag.Tag = strTag;
                        G.glb.lstLiteratureTag.Add(newTag);
                        G.glb.lstLiteratureTag.RemoveAll(o => o.Title == row.Cells[1].Value.ToString() && o.Tag == "(Root)");
                    }
                }
                LoadTab();
            }
        }

        private void RemoveTagFromMultipleLiterature(string strTag)
        {
            if (dgvLiterature.SelectedRows.Count >= 1
                && MessageBox.Show("Do you confirm to remove tag from all selected literature.", "Remove Tag", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvLiterature.SelectedRows)
                {
                    G.glb.lstLiteratureTag.RemoveAll(o => o.Title == row.Cells[1].Value.ToString() && o.Tag == strTag);
                    foreach (CLiterature lit in G.glb.lstLiterature)
                    {
                        if (!G.glb.lstLiteratureTag.Exists(o => o.Title == lit.Title))
                        {
                            RLiteratureTag defaultTag = new RLiteratureTag();
                            defaultTag.Title = lit.Title;
                            defaultTag.Tag = "(Root)";
                            G.glb.lstLiteratureTag.Add(defaultTag);
                        }
                    }
                }
                LoadTab();
            }
        }

        private void addTag2Multi_Click(object sender, EventArgs e)
        {
            if (dgvLiterature.SelectedRows.Count >= 1)
            {
                frmAddTag frmAddTag = new frmAddTag();
                frmAddTag.SendTag += new frmAddTag.GetTag(AddTag2MultipleLiterature);
                frmAddTag.Show();
            }
        }
        private void tsmRemoveTagFromMulti_Click(object sender, EventArgs e)
        {
            if (dgvLiterature.SelectedRows.Count >= 1)
            {
                frmAddTag frmAddTag = new frmAddTag();
                frmAddTag.SendTag += new frmAddTag.GetTag(RemoveTagFromMultipleLiterature);
                frmAddTag.Show();
            }
        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            if (trvTag.SelectedNode != null)
            {
                string newTag = Interaction.InputBox("Input a new tag", "New Tag", "New Tag", 300, 300);
                if (newTag != "")
                {
                    if (!lstTags.Exists(o => o.Tag == newTag))
                    {
                        TreeNode newNode = new TreeNode(newTag, 0, 0);
                        newNode.Text = newTag + ("[0]");
                        newNode.Name = Guid.NewGuid().ToString();
                        newNode.ExpandAll();
                        trvTag.SelectedNode.ExpandAll();
                        trvTag.SelectedNode.Nodes.Add(newNode);

                        CLiteratureTag newTagType = new CLiteratureTag();
                        newTagType.Tag = newTag;
                        newTagType.GUID = newNode.Name;
                        lstTags.Add(newTagType);

                        RSubLiteratureTag newSubTag = new RSubLiteratureTag();
                        newSubTag.Tag = trvTag.SelectedNode.Text.Split('[')[0];
                        newSubTag.GUID = trvTag.SelectedNode.Name;
                        newSubTag.SubTag = newTag;
                        newSubTag.SubGUID = newNode.Name;
                        lstSubTags.Add(newSubTag);
                    }
                    else
                    {
                        MessageBox.Show("Tag exists!");
                    }
                }
            }
        }

        private void tsmFold_Click(object sender, EventArgs e)
        {
            if (trvTag.SelectedNode != null)
            {
                foreach (TreeNode item in trvTag.SelectedNode.Nodes)
                {
                    item.Collapse(true);
                }
            }
        }

        private void tsmExpand_Click(object sender, EventArgs e)
        {
            if (trvTag.SelectedNode != null)
            {
                trvTag.SelectedNode.ExpandAll();
                foreach (TreeNode item in trvTag.SelectedNode.Nodes)
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
            if (trvTag.SelectedNode != null &&
                MessageBox.Show("Confirm to sort children nodes.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                Comparison<TreeNode> sorterX = new Comparison<TreeNode>(TreeNodeCompare);
                List<TreeNode> al = new List<TreeNode>();

                foreach (TreeNode tn in trvTag.SelectedNode.Nodes)
                {
                    al.Add(tn);
                }
                al.Sort(sorterX);

                trvTag.SelectedNode.Nodes.Clear();
                foreach (TreeNode tn in al)
                {
                    trvTag.SelectedNode.Nodes.Add(tn);
                }
                SaveTag();
            }
        }

        private void tsmRemoveTag_Click(object sender, EventArgs e)
        {
            if (trvTag.SelectedNode != null &&
                MessageBox.Show("Do you want to remove these tags? Literature without tag will add a new tag called '(default)'", "Remove confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveTag();
                string selectedTag = trvTag.SelectedNode.Text.Split('[')[0];
                G.glb.lstLiteratureTag.RemoveAll(o => o.Tag == selectedTag);
                foreach (CLiterature lit in G.glb.lstLiterature)
                {
                    if (!G.glb.lstLiteratureTag.Exists(o => o.Title == lit.Title))
                    {
                        RLiteratureTag defaultTag = new RLiteratureTag();
                        defaultTag.Title = lit.Title;
                        defaultTag.Tag = "(Root)";
                        G.glb.lstLiteratureTag.Add(defaultTag);
                    }
                }
                // 只能移除子节点的tag
                if (trvTag.SelectedNode.Nodes.Count == 0)
                {
                    trvTag.Nodes.Remove(trvTag.SelectedNode);
                    lstTags.RemoveAll(o => o.Tag == selectedTag);
                    lstSubTags.RemoveAll(o => o.SubTag == selectedTag);
                }
                LoadTab();
            }
        }

        private void tsmEditTag_Click(object sender, EventArgs e)
        {
            string selectedTag = "";
            if (trvTag.SelectedNode != null)
            {
                SaveTag();
                selectedTag = trvTag.SelectedNode.Text.Split('[')[0];
                string newTag = Interaction.InputBox("Input New Tag Name", "Rename", "Rename Tag", 300, 300);
                if ((lstTags.Exists(o => o.Tag == newTag)
                    && MessageBox.Show("Tag '" + newTag + "' exists, do you want to merge into this tag?", "Merge confirm", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    foreach (RLiteratureTag litTag in G.glb.lstLiteratureTag)
                    {
                        if (selectedTag == litTag.Tag && !G.glb.lstLiteratureTag.Exists(p => p.Tag == newTag && p.Title == litTag.Title))
                        {
                            litTag.Tag = newTag;
                        }
                    }
                    if (trvTag.SelectedNode.Nodes.Count == 0)
                    {
                        trvTag.Nodes.Remove(trvTag.SelectedNode);
                        lstTags.RemoveAll(o => o.Tag == selectedTag);
                        lstSubTags.RemoveAll(o => o.SubTag == selectedTag);
                    }
                    LoadTab();
                }
                else if (!lstTags.Exists(o => o.Tag == newTag))
                {
                    foreach (RLiteratureTag litTag in G.glb.lstLiteratureTag)
                    {
                        if (selectedTag == litTag.Tag && !G.glb.lstLiteratureTag.Exists(p => p.Tag == newTag && p.Title == litTag.Title))
                        {
                            litTag.Tag = newTag;
                        }
                    }
                    lstTags.Find(o => o.Tag == selectedTag).Tag = newTag;
                    foreach (RSubLiteratureTag item in lstSubTags.FindAll(o => o.Tag == selectedTag))
                    {
                        item.Tag = newTag;
                    }
                    foreach (RSubLiteratureTag item in lstSubTags.FindAll(o => o.SubTag == selectedTag))
                    {
                        item.SubTag = newTag;
                    }
                    LoadTab();
                }
            }
        }

        private void tsmUp_Click(object sender, EventArgs e)
        {
            if (trvTag.SelectedNode != null)
            {
                TreeNode node = trvTag.SelectedNode;
                TreeNode preNode = node.PrevNode;
                if (preNode != null)
                {
                    TreeNode newNode = (TreeNode)node.Clone();
                    if (node.Parent == null)
                    {
                        trvTag.Nodes.Insert(preNode.Index, newNode);
                    }
                    else
                    {
                        node.Parent.Nodes.Insert(preNode.Index, newNode);
                    }
                    node.Remove();
                    trvTag.SelectedNode = newNode;
                }
                SaveTag();
            }
        }

        private void tsmDown_Click(object sender, EventArgs e)
        {
            if (trvTag.SelectedNode != null)
            {
                TreeNode node = trvTag.SelectedNode;
                TreeNode nextNode = node.NextNode;
                if (nextNode != null)
                {
                    TreeNode newNode = (TreeNode)node.Clone();
                    if (node.Parent == null)
                    {
                        trvTag.Nodes.Insert(nextNode.Index + 1, newNode);
                    }
                    else
                    {
                        node.Parent.Nodes.Insert(nextNode.Index + 1, newNode);
                    }
                    node.Remove();
                    trvTag.SelectedNode = newNode;
                }
                SaveTag();
            }
        }

        private void tsmIndependent_Click(object sender, EventArgs e)
        {
            if (trvTag.SelectedNode != null)
            {
                TreeNode node = trvTag.SelectedNode;
                TreeNode parentNode = node.Parent;
                TreeNode grandparentNode = node.Parent.Parent;
                TreeNode newNode = (TreeNode)node.Clone();
                if (node.Parent != null && node.Parent.Parent != null)
                {
                    grandparentNode.Nodes.Insert(parentNode.Index + 1, newNode);
                    node.Remove();
                    trvTag.SelectedNode = newNode;
                }
                SaveTag();
            }
        }

        private void tsmBelongTo_Click(object sender, EventArgs e)
        {
            if (trvTag.SelectedNode != null && trvTag.SelectedNode.Parent != null)
            {
                TreeNode node = trvTag.SelectedNode;
                TreeNode preNode = node.PrevNode;
                TreeNode newNode = (TreeNode)node.Clone();
                if (node.Parent != null && node.PrevNode != null)
                {
                    preNode.Nodes.Insert(preNode.Nodes.Count, newNode);
                    node.Remove();
                    trvTag.SelectedNode = newNode;
                }
                SaveTag();
            }
        }

        private void tsmCreateNote_Click(object sender, EventArgs e)
        {
            if (trvTag.SelectedNode != null)
            {
                List<RLiteratureTag> lst = G.glb.lstLiteratureTag.FindAll(o => o.Tag == trvTag.SelectedNode.Text.Split('[')[0]).ToList();
                List<string> lstTitle = new List<string>();
                for (int i = 0; i < lst.Count; i++)
                {
                    lstTitle.Add(lst[i].Title.ToString());
                }
                frmInfoNote frmInfoNote = new frmInfoNote("Literature Review: " + trvTag.SelectedNode.Text.Split('[')[0], lstTitle);
                frmInfoNote.Show();
            }
        }

        private void frmLiterature_FormClosing(object sender, FormClosingEventArgs e)
        {
            M.literatureOpened.Clear();
            SaveJournalInfo();
            SaveTag();
            Dispose();
        }

        private void trvTag_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
            clbAuthor.Items.Clear();
            clbJournalConference.Items.Clear();
        }

        // Updates all child tree nodes recursively.
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clbAuthor.Items.Clear();
            foreach (CItem author in Authors)
            {
                clbAuthor.Items.Add(author.ItemName + "[" + author.ItemCount.ToString() + "]", false);
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clbAuthor.Items.Clear();
            foreach (CItem author in Authors)
            {
                clbAuthor.Items.Add(author.ItemName + "[" + author.ItemCount.ToString() + "]", true);
            }
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clbJournalConference.Items.Clear();
            foreach (CItem jourConf in JournalConferences)
            {
                clbJournalConference.Items.Add(jourConf.ItemName + "[" + jourConf.ItemCount.ToString() + "]", false);
            }
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clbJournalConference.Items.Clear();
            foreach (CItem jourConf in JournalConferences)
            {
                clbJournalConference.Items.Add(jourConf.ItemName + "[" + jourConf.ItemCount.ToString() + "]", true);
            }
        }

        private void btnAuthorAndJournal_Click(object sender, EventArgs e)
        {
            ChooseTag();
            UpdateAuthorJours();
        }

        private void trvTag_KeyDown(object sender, KeyEventArgs e)
        {
            // 新建节点
            if (e.Control && e.KeyCode == Keys.A)
            {
                tsmAdd_Click(trvTag, e);
            }
            // 折叠
            else if (e.Control && e.KeyCode == Keys.N)
            {
                tsmFold_Click(trvTag, e);
            }
            // 展开
            else if (e.Control && e.KeyCode == Keys.M)
            {
                tsmExpand_Click(trvTag, e);
            }
            // 编辑节点
            else if (e.Control && e.KeyCode == Keys.E)
            {
                tsmEditTag_Click(trvTag, e);
            }
            // 删除
            else if (e.Control && e.KeyCode == Keys.D)
            {
                tsmRemoveTag_Click(trvTag, e);
            }
            // 上移
            else if (e.Control && e.KeyCode == Keys.I)
            {
                tsmUp_Click(trvTag, e);
            }
            // 下移
            else if (e.Control && e.KeyCode == Keys.K)
            {
                tsmDown_Click(trvTag, e);
            }
            // 左移
            else if (e.Control && e.KeyCode == Keys.L)
            {
                tsmBelongTo_Click(trvTag, e);
            }
            // 右移
            else if (e.Control && e.KeyCode == Keys.J)
            {
                tsmIndependent_Click(trvTag, e);
            }
        }

        private void trvTag_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void trvTag_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        
        private void updateTempLitAreaA()
        {
            clbTempLitsAreaA.Items.Clear();
            foreach (string item in M.tempLitsA)
            {
                clbTempLitsAreaA.Items.Add(item);
            }
        }
       
        private void updateTempLitAreaB()
        {
            clbTempLitsAreaB.Items.Clear();
            foreach (string item in M.tempLitsB)
            {
                clbTempLitsAreaB.Items.Add(item);
            }
        }

        private void tsmTempSelectAll_Click(object sender, EventArgs e)
        {
            switch (SelectedAttri)
            {
                case "clbTempLitsAreaA":
                    clbTempLitsAreaA.Items.Clear();
                    foreach (string item in M.tempLitsA)
                    {
                        clbTempLitsAreaA.Items.Add(item, true);
                    }
                    break;
                case "clbTempLitsAreaB":
                    clbTempLitsAreaB.Items.Clear();
                    foreach (string item in M.tempLitsB)
                    {
                        clbTempLitsAreaB.Items.Add(item, true);
                    }
                    break;
                default:
                    break;
            }
        }

        private void tsmTempClearSelection_Click(object sender, EventArgs e)
        {
            switch (SelectedAttri)
            {
                case "clbTempLitsAreaA":
                    clbTempLitsAreaA.Items.Clear();
                    foreach (string item in M.tempLitsA)
                    {
                        clbTempLitsAreaA.Items.Add(item, false);
                    }
                    break;
                case "clbTempLitsAreaB":
                    clbTempLitsAreaB.Items.Clear();
                    foreach (string item in M.tempLitsB)
                    {
                        clbTempLitsAreaB.Items.Add(item, false);
                    }
                    break;
                default:
                    break;
            }
        }

        private void tsmTempSort_Click(object sender, EventArgs e)
        {
            switch (SelectedAttri)
            {
                case "clbTempLitsAreaA":
                    clbTempLitsAreaA.Items.Clear();
                    M.tempLitsA.Sort();
                    foreach (string item in M.tempLitsA)
                    {
                        clbTempLitsAreaA.Items.Add(item, false);
                    }
                    break;
                case "clbTempLitsAreaB":
                    clbTempLitsAreaB.Items.Clear();
                    M.tempLitsB.Sort();
                    foreach (string item in M.tempLitsB)
                    {
                        clbTempLitsAreaB.Items.Add(item, false);
                    }
                    break;
                default:
                    break;
            }
        }

        private void tsmTempClear_Click(object sender, EventArgs e)
        {
            switch (SelectedAttri)
            {
                case "clbTempLitsAreaA":
                    M.tempLitsA.Clear();
                    clbTempLitsAreaA.Items.Clear();
                    break;
                case "clbTempLitsAreaB":
                    M.tempLitsB.Clear();
                    clbTempLitsAreaB.Items.Clear();
                    break;
                default:
                    break;
            }
        }

        private void tsmRemoveSelected_Click(object sender, EventArgs e)
        {
            switch (SelectedAttri)
            {
                case "clbTempLitsAreaA":
                    for (int i = 0; i < clbTempLitsAreaA.CheckedItems.Count; i++)
                    {
                        M.tempLitsA.RemoveAll(o => o == clbTempLitsAreaA.CheckedItems[i].ToString());
                    }
                    clbTempLitsAreaA.Items.Clear();
                    foreach (string item in M.tempLitsA)
                    {
                        clbTempLitsAreaA.Items.Add(item, false);
                    }
                    break;
                case "clbTempLitsAreaB":
                    for (int i = 0; i < clbTempLitsAreaB.CheckedItems.Count; i++)
                    {
                        M.tempLitsB.RemoveAll(o => o == clbTempLitsAreaB.CheckedItems[i].ToString());
                    }
                    clbTempLitsAreaB.Items.Clear();
                    foreach (string item in M.tempLitsB)
                    {
                        clbTempLitsAreaB.Items.Add(item, false);
                    }
                    break;
                default:
                    break;
            }
        }

        private void tsmReplaceMainLitsArea_Click(object sender, EventArgs e)
        {
            switch (SelectedAttri)
            {
                case "clbTempLitsAreaA":
                    M.shownLits = M.tempLitsA.ToList();
                    LoadLiteratureList(M.shownLits);
                    break;
                case "clbTempLitsAreaB":
                    M.shownLits = M.tempLitsB.ToList();
                    LoadLiteratureList(M.shownLits);
                    break;
                default:
                    break;
            }
        }

        private void tsmAddToMainLitsArea_Click(object sender, EventArgs e)
        {
            switch (SelectedAttri)
            {
                case "clbTempLitsAreaA":
                    M.shownLits.AddRange(M.tempLitsA.ToList());
                    M.shownLits = M.shownLits.Distinct().ToList();
                    LoadLiteratureList(M.shownLits);
                    break;
                case "clbTempLitsAreaB":
                    M.shownLits.AddRange(M.tempLitsB.ToList());
                    M.shownLits = M.shownLits.Distinct().ToList();
                    LoadLiteratureList(M.shownLits);
                    break;
                default:
                    break;
            }
        }

        private void tsmAddSelectedToMainLitsArea_Click(object sender, EventArgs e)
        {
            switch (SelectedAttri)
            {
                case "clbTempLitsAreaA":
                    for (int i = 0; i < clbTempLitsAreaA.CheckedItems.Count; i++)
                    {
                        M.shownLits.Add(clbTempLitsAreaA.CheckedItems[i].ToString());
                    }
                    M.shownLits = M.shownLits.Distinct().ToList();
                    LoadLiteratureList(M.shownLits);
                    break;
                case "clbTempLitsAreaB":
                    for (int i = 0; i < clbTempLitsAreaB.CheckedItems.Count; i++)
                    {
                        M.shownLits.Add(clbTempLitsAreaB.CheckedItems[i].ToString());
                    }
                    M.shownLits = M.shownLits.Distinct().ToList();
                    LoadLiteratureList(M.shownLits);
                    break;
                default:
                    break;
            }
        }

        private string SelectedAttri = "";
        private void cmsTempLitsArea_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SelectedAttri = (sender as ContextMenuStrip).SourceControl.Name;

            if (SelectedAttri == "clbTempLitsAreaA")
            {
                tsmRemoveDupsA.Visible = true;
                tsmIntersectAwithB.Visible = true;
                tsmRemoveDupsB.Visible = false;
                tsmIntersectBwithA.Visible = false;
            }
            else
            {
                tsmRemoveDupsA.Visible = false;
                tsmIntersectAwithB.Visible = false;
                tsmRemoveDupsB.Visible = true;
                tsmIntersectBwithA.Visible = true;
            }
        }

        private void tsmAddToAreaA_Click(object sender, EventArgs e)
        {
            if (dgvLiterature.SelectedRows.Count >= 1)
            {
                for (int i = 0; i < dgvLiterature.SelectedRows.Count; i++)
                {
                    if (!M.tempLitsA.Contains(dgvLiterature.SelectedRows[i].Cells[1].Value.ToString()))
                    {
                        M.tempLitsA.Add(dgvLiterature.SelectedRows[i].Cells[1].Value.ToString());
                    }
                }
                updateTempLitAreaA();
            }
        }

        private void tsmAddToAreaB_Click(object sender, EventArgs e)
        {
            if (dgvLiterature.SelectedRows.Count >= 1)
            {
                for (int i = 0; i < dgvLiterature.SelectedRows.Count; i++)
                {
                    if (!M.tempLitsB.Contains(dgvLiterature.SelectedRows[i].Cells[1].Value.ToString()))
                    {
                        M.tempLitsB.Add(dgvLiterature.SelectedRows[i].Cells[1].Value.ToString());
                    }
                }
                updateTempLitAreaB();
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

        private void tsmCopyToNote(object sender, EventArgs e)
        {
            if (dgvLiterature.SelectedCells.Count == 1)
            {
                string litName = dgvLiterature.CurrentRow.Cells[1].Value.ToString();
                
                CNote note = G.glb.lstNote.Find(o => o.LiteratureTitle == litName);
                List<RNoteLog> litNoteLog = G.glb.lstNoteLog.FindAll(o => o.Topic == litName && o.TagTime.Date == G.glb.lstLiterature.Find(p => p.Title == litName).DateAdded.Date);
                
                TreeNode litNode = createLitNoteLogNode(note, litNoteLog);
                M.mem.copiedNodes.Clear();
                copyNode(litNode);
            }
        }

        private TreeNode createLitNoteLogNode(CNote note, List<RNoteLog> litNoteLog)
        {
            TreeNode rootNode = new TreeNode(note.Topic, 0, 0);
            rootNode.Name = note.GUID;
            rootNode.Text = note.Topic;

            TreeNode yearNode = new TreeNode("year", 0, 0);
            yearNode.Name = Guid.NewGuid().ToString();
            yearNode.Text = "year: " + G.glb.lstLiterature.Find(o => o.Title == note.LiteratureTitle).PublishYear.ToString();
            rootNode.Nodes.Add(yearNode);

            TreeNode jourNode = new TreeNode("", 0, 0);
            jourNode.Name = Guid.NewGuid().ToString();
            jourNode.Text = "jourConf: " + G.glb.lstLiterature.Find(o => o.Title == note.LiteratureTitle).JournalOrConferenceName;
            rootNode.Nodes.Add(jourNode);

            List<RLiteratureAuthor> authors = new List<RLiteratureAuthor>();
            authors = G.glb.lstLiteratureAuthor.FindAll(o => o.Title == note.LiteratureTitle).ToList();
            foreach (RLiteratureAuthor author in authors)
            {
                TreeNode authorNode = new TreeNode(author.Author, 0, 0);
                authorNode.Name = Guid.NewGuid().ToString();
                authorNode.Text = "author: " + author.Author;
                rootNode.Nodes.Add(authorNode);
            }

            List<RLiteratureTag> tags = new List<RLiteratureTag>();
            tags = G.glb.lstLiteratureTag.FindAll(o => o.Title == note.LiteratureTitle).ToList();
            foreach (RLiteratureTag tag in tags)
            {
                TreeNode tagNode = new TreeNode(tag.Tag, 0, 0);
                tagNode.Name = Guid.NewGuid().ToString();
                tagNode.Text = "tag: " + tag.Tag;
                rootNode.Nodes.Add(tagNode);
            }

            rootNode.Expand();

            litNoteLog.RemoveAll(o => o.SubLog.Contains("modified: "));
            litNoteLog.RemoveAll(o => o.SubLog.Contains("Modified: "));

            litNoteLog.RemoveAll(o =>
                    o.Topic == o.Log
                    && !litNoteLog.Exists(p => p.Log == o.SubLog));

            if (litNoteLog.Count > 0)
            {
                LoadChildNoteLog(rootNode, litNoteLog);
            }           

            rootNode.Text = "$LITR$>" + note.LiteratureTitle;
            rootNode.Name = Guid.NewGuid().ToString();
            rootNode.ForeColor = Color.Brown;
            rootNode.NodeFont = new Font(Font, FontStyle.Underline);
            return rootNode;
        }

        private int getLogo(string noteText)
        {
            if (noteText.Contains("ddl: ") || noteText.Contains("DDL: "))
            {
                return 14;
            }
            else if (noteText.Contains("$LINK$>"))
            {
                string selectedPath = noteText.Replace("$LINK$>", "");
                string[] checkUrl = selectedPath.Split(':');
                if (checkUrl[0] == "http" || checkUrl[0] == "https")
                {
                    return 0;
                }
                else
                {
                    try
                    {
                        if (System.IO.File.Exists(selectedPath))
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
                string selectedPath = noteText.Replace("$LITR$>", "");
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
            else
            {
                return -1;
            }
        }

        private (Color, Color, Font) getColor(string note)
        {
            Color BackColor = new Color();
            Color ForeColor = new Color();
            Font TextFont = new Font(Font, FontStyle.Regular);

            BackColor = Color.White;
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
            else if (note.Split('#').Length == 3)
            {
                ForeColor = Color.Indigo;
                TextFont = new Font(Font, FontStyle.Bold);
            }

            if (note.Contains("ddl: ") || note.Contains("DDL: "))
            {
                string dateSeg = "";
                dateSeg = note.Replace("ddl: ", "");
                dateSeg = dateSeg.Replace("DDL: ", "");
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

        private void LoadChildNoteLog(TreeNode treeNode, List<RNoteLog> litNoteLog)
        {
            // 如果本条NoteLog作为上级NoteLog存在，添加所有的SubLog
            if (litNoteLog.Exists(o => o.Log == treeNode.Text && o.GUID == treeNode.Name))
            {
                List<RNoteLog> subNoteLog = litNoteLog.FindAll(o => o.Log == treeNode.Text && o.GUID == treeNode.Name).ToList();
                subNoteLog = subNoteLog.OrderBy(o => o.Index).ToList();
                foreach (RNoteLog sub in subNoteLog)
                {
                    TreeNode childNode = new TreeNode(sub.SubLog);
                    childNode.Name = sub.SubGUID;
                    childNode.Text = sub.SubLog;
                    childNode.BackColor = SystemColors.Window;
                    childNode.ForeColor = Color.Black;
                    childNode.Expand();
                    childNode.StateImageIndex = getLogo(sub.SubLog);
                    (childNode.BackColor, childNode.ForeColor, childNode.NodeFont) = getColor(sub.SubLog);
                    LoadChildNoteLog(childNode, litNoteLog);
                    treeNode.Nodes.Add(childNode);
                }
            }
        }

        private void tsmH2V_Click(object sender, EventArgs e)
        {
            // 如果是垂直分割
            if (tblTempArea.RowCount == 1)
            {
                tblTempArea.RowCount = 2;
                tblTempArea.RowStyles.Clear();
                tblTempArea.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tblTempArea.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tblTempArea.ColumnCount--;
                tblTempArea.ColumnStyles.Clear();
                tblTempArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                tblTempArea.Controls.Add(clbTempLitsAreaA, 0, 0);
                tblTempArea.Controls.Add(clbTempLitsAreaB, 0, 1);
            }
            else
            {
                tblTempArea.ColumnCount = 2;
                tblTempArea.ColumnStyles.Clear();
                tblTempArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tblTempArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tblTempArea.RowCount--;
                tblTempArea.RowStyles.Clear();
                tblTempArea.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                tblTempArea.Controls.Add(clbTempLitsAreaA, 0, 0);
                tblTempArea.Controls.Add(clbTempLitsAreaB, 1, 0);
            }
        }

        private void removeDupsInAreaAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M.tempLitsA.RemoveAll(o => M.tempLitsB.Contains(o));
            updateTempLitAreaA();
        }

        private void removeDupsInAreaBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M.tempLitsB.RemoveAll(o => M.tempLitsA.Contains(o));
            updateTempLitAreaB();
        }

        private void tmsIntersectAwithB_Click(object sender, EventArgs e)
        {
            M.tempLitsA.RemoveAll(o => !M.tempLitsB.Contains(o));
            updateTempLitAreaA();
        }

        private void tsmIntersectBwithA_Click(object sender, EventArgs e)
        {
            M.tempLitsB.RemoveAll(o => !M.tempLitsA.Contains(o));
            updateTempLitAreaB();
        }

        private void dgvLiterature_Sorted(object sender, EventArgs e)
        {
            M.shownLits.Clear();
            for (int i = 0; i < dgvLiterature.Rows.Count; i++)
            {
                M.shownLits.Add(dgvLiterature.Rows[i].Cells[1].Value.ToString());
            }
        }
    }
}
