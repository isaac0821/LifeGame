using Microsoft.VisualBasic;
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

        //记录数量
        List<CItem> Tags = new List<CItem>();
        List<CItem> Authors = new List<CItem>();
        List<CItem> JournalConferences = new List<CItem>();

        public frmLiterature()
        {
            InitializeComponent();
        }

        private void frmLiterature_Load(object sender, EventArgs e)
        {
            lstTags = G.glb.lstLiteratureTagType.ToList();
            lstSubTags = G.glb.lstSubLiteratureTag.ToList();
            LoadTab();
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
            LoadLiteratureList();
        }

        private void tsmAddLiterature_Click(object sender, EventArgs e)
        {
            frmInfoLiterature frmInfoLiterature = new frmInfoLiterature();
            frmInfoLiterature.RefreshTab += new frmInfoLiterature.RefreshTabHandler(LoadTab);
            frmInfoLiterature.Show();
        }

        private void tsmViewLiterature_Click(object sender, EventArgs e)
        {
            if (dgvLiterature.SelectedCells.Count == 1)
            {
                frmInfoLiterature frmInfoLiterature = new frmInfoLiterature(dgvLiterature.CurrentRow.Cells[1].Value.ToString());
                frmInfoLiterature.RefreshTab += new frmInfoLiterature.RefreshTabHandler(LoadTab);
                frmInfoLiterature.Show();
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
                        G.glb.lstLiterature.RemoveAll(o => o.Title == removedLit);
                        G.glb.lstLiteratureTag.RemoveAll(o => o.Title == removedLit);
                        G.glb.lstLiteratureAuthor.RemoveAll(o => o.Title == removedLit);
                        G.glb.lstSurveyLiterature.RemoveAll(o => o.LiteratureTitle == removedLit);
                        G.glb.lstSurveyLiteratureTagValue.RemoveAll(o => o.LiteratureTitle == removedLit);
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
            LoadTab();
        }

        private void LoadLiteratureList(List<string> loadedLits)
        {
            dgvLiterature.Rows.Clear();
            dgvLiterature.ShowCellToolTips = true;
            foreach (string title in loadedLits)
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
                int year = G.glb.lstLiterature.Find(o => o.Title == title).PublishYear;
                if (G.glb.lstLiterature.Find(o => o.Title == title).Star)
                {
                    starStr = "√";
                }
                // If the journal is predatory
                if (G.glb.lstBadJournal.Exists(o => o == G.glb.lstLiterature.Find(p => p.Title == title).JournalOrConferenceName))
                {
                    predatoryStr = "√";
                    predatoryShowFlag = false;
                }
                if (G.glb.lstLiterature.Find(o => o.Title == title).PredatoryAlert)
                {
                    predatoryStr = "√";
                    predatoryShowFlag = false;
                }
                // If the journal is reliable
                if (G.glb.lstGoodJournal.Exists(o => o == G.glb.lstLiterature.Find(p => p.Title == title).JournalOrConferenceName))
                {
                    goodJourStr = "√";
                    goodJourShowFlag = true;
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
                if (showFlag)
                {
                    dgvLiterature.Rows.Add(starStr, title, Convert.ToString(year), litType, goodJourStr, predatoryStr, addedDate.ToString("yyyy/MM/dd"), lastModifyDate.ToString("yyyy/MM/dd"));
                    dgvLiterature.Rows[dgvLiterature.Rows.Count - 1].Cells[1].ToolTipText = G.glb.lstLiterature.Find(o => o.Title == title).InOneSentence;
                }
                lblNumFound.Text = Convert.ToString(dgvLiterature.Rows.Count) + " result(s) found";
            }
        }

        private void LoadLiteratureList(string SearchText)
        {
            List<string> ShownTitle = new List<string>();
            foreach (CLiterature literature in G.glb.lstLiterature)
            {
                // Find literature with the search text in its title
                if (literature.Title.ToUpper().Contains(SearchText.ToUpper()))
                {
                    ShownTitle.Add(literature.Title);
                }
                // Find literature with the search text as part of the bibtex
                if (literature.BibKey.ToUpper().Contains(SearchText.ToUpper()))
                {
                    ShownTitle.Add(literature.Title);
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
                        ShownTitle.Add(literatureAuthor.Title);
                    }
                }
            }

            ShownTitle = ShownTitle.Distinct().ToList();
            LoadLiteratureList(ShownTitle);
        }

        private void LoadLiteratureList()
        {
            List<string> ShownTitle = new List<string>();

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
                    ShownTitle.Add(literature.Title);
                }
            }
            ShownTitle = ShownTitle.Distinct().ToList();
            LoadLiteratureList(ShownTitle);
        }

        private void LoadTag()
        {
            trvTag.Nodes.Clear();
            TreeNode rootNode = new TreeNode("(Root)");
            rootNode.Checked = false;
            rootNode.Name = G.glb.lstLiteratureTagType.Find(o => o.Tag == "(Root)").GUID;
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
            Authors = Authors.OrderByDescending(o => o.ItemCount).ToList();
            Authors = Authors.OrderBy(o => o.ItemName).ToList();
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

        private void goodJournalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReliableJournal frmReliableJournal = new frmReliableJournal();
            frmReliableJournal.RefreshLits += new frmReliableJournal.RefreshLitsHandler(LoadLiteratureList);
            frmReliableJournal.Show();
        }

        private void chkOnlyGood_CheckedChanged(object sender, EventArgs e)
        {
            LoadLiteratureList();
        }

        private void chkNoBad_CheckedChanged(object sender, EventArgs e)
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

        private void unreliableSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnreliableJournal frmUnreliableJournal = new frmUnreliableJournal();
            frmUnreliableJournal.RefreshLits += new frmUnreliableJournal.RefreshLitsHandler(LoadLiteratureList);
            frmUnreliableJournal.Show();
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

        private void addTag2Multi_Click(object sender, EventArgs e)
        {
            if (dgvLiterature.SelectedRows.Count >= 1)
            {
                frmAddTag frmAddTag = new frmAddTag();
                frmAddTag.SendTag += new frmAddTag.GetTag(AddTag2MultipleLiterature);
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

                        CLiteratureTag newTagType = new CLiteratureTag ();
                        newTagType.Tag = newTag;
                        newTagType.GUID = newNode.Name;
                        lstTags.Add(newTagType);

                        RSubLiteratureTag newSubTag = new RSubLiteratureTag ();
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
                trvTag.SelectedNode.Nodes.Count == 0 &&
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
                trvTag.Nodes.Remove(trvTag.SelectedNode);
                lstTags.RemoveAll(o => o.Tag == selectedTag);
                lstSubTags.RemoveAll(o => o.SubTag == selectedTag);
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
                string NewName = Interaction.InputBox("Input New Tag Name", "Rename", "Rename Tag", 300, 300);
                if (G.glb.lstLiteratureTagType.Exists(o => o.Tag == NewName))
                {
                    DialogResult result = MessageBox.Show("Tag '" + NewName + "' exists, do you want to merge into this tag?", "Merge confirm", MessageBoxButtons.YesNo);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            foreach (RLiteratureTag litTag in G.glb.lstLiteratureTag)
                            {
                                if (selectedTag == litTag.Tag && !G.glb.lstLiteratureTag.Exists(p => p.Tag == NewName && p.Title == litTag.Title))
                                {
                                    litTag.Tag = NewName;
                                }
                            }
                            LoadTab();
                            break;
                        case DialogResult.No:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    foreach (RLiteratureTag litTag in G.glb.lstLiteratureTag)
                    {
                        if (selectedTag == litTag.Tag && !G.glb.lstLiteratureTag.Exists(p => p.Tag == NewName && p.Title == litTag.Title))
                        {
                            litTag.Tag = NewName;
                        }
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
                frmInfoNote frmInfoNote = new frmInfoNote(trvTag.SelectedNode.Text.Split('[')[0], lstTitle);
                frmInfoNote.Show();
            }
        }

        private void frmLiterature_FormClosing(object sender, FormClosingEventArgs e)
        {
            M.literatureOpened.Clear();
            SaveTag();
            Dispose();
        }

        private void trvTag_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ChooseTag();
            UpdateAuthorJours();
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
                clbAuthor.Items.Add(author.ItemName + "[" + author.ItemCount.ToString() + "]", false);
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
                clbJournalConference.Items.Add(jourConf.ItemName + "[" + jourConf.ItemCount.ToString() + "]", false);
            }
        }

        private void trvTag_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvTag.SelectedNode.Parent == null)
            {
                tsmEditTag.Enabled = false;
                tsmRemoveTag.Enabled = false;
                tsmCreateNote.Enabled = false;
                tsmUp.Enabled = false;
                tsmDown.Enabled = false;
                tsmIndependent.Enabled = false;
                tsmBelongTo.Enabled = false;
            }
            else
            {
                tsmEditTag.Enabled = true;
                if (trvTag.SelectedNode.Nodes.Count > 0)
                {
                    tsmRemoveTag.Enabled = false;
                }
                else
                {
                    tsmRemoveTag.Enabled = true;
                }
                tsmCreateNote.Enabled = true;
                tsmUp.Enabled = true;
                tsmDown.Enabled = true;
                tsmIndependent.Enabled = true;
                tsmBelongTo.Enabled = true;
            }
        }
    }
}
