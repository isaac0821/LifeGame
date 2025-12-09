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
    public partial class frmSearchNote : Form
    {
        List<CNote> notes = new List<CNote>();
        List<CLiterature> lits = new List<CLiterature> ();
        string search = "";

        public frmSearchNote(string searchName)
        {
            notes = G.glb.lstNote.FindAll(o => o.Topic.ToUpper().Contains(searchName.ToUpper()));
            notes = notes.OrderBy(o => o.TagTime).ToList();
            lits = G.glb.lstLiterature.FindAll(o => o.Title.ToUpper().Contains(searchName.ToUpper()));
            lits = lits.OrderBy(o => o.Title).ToList();
            search = searchName;
            InitializeComponent();
        }

        private void RefreshNoteList()
        {
            lsbNote.Items.Clear();
            foreach (CNote note in notes)
            {
                lsbNote.Items.Add(note.TagTime.Year.ToString() + "." + note.TagTime.Month.ToString() + "." + note.TagTime.Day.ToString() + "@" + note.Topic);
            }
        }
        private void RefreshLitList()
        {
            lsbLit.Items.Clear();
            foreach (CLiterature lit in lits)
            {
                lsbLit.Items.Add(lit.Title);
            }
        }

        private void frmSearchNote_Load(object sender, EventArgs e)
        {
            RefreshNoteList();
            RefreshLitList();
        }

        private void tsmOpenNote_Click(object sender, EventArgs e)
        {
            if (lsbNote.SelectedItem != null)
            {
                try
                {
                    string selectedItemText = lsbNote.SelectedItem.ToString();
                    string[] split = selectedItemText.Split('@');
                    string[] datelist = split[0].Split('.');
                    int Year = Convert.ToInt16(datelist[0]);
                    int Month = Convert.ToInt16(datelist[1]);
                    int Day = Convert.ToInt16(datelist[2]);
                    DateTime date = new DateTime(Year, Month, Day, 0, 0, 0);
                    CNote note = G.glb.lstNote.Find(o => o.TagTime == date && o.Topic == split[1]);
                    if (M.notesOpened.Exists(o => o.GUID == note.GUID))
                    {
                        M.notesOpened.Find(o => o.GUID == note.GUID).Show();
                        M.notesOpened.Find(o => o.GUID == note.GUID).BringToFront();
                    }
                    else
                    {
                        frmInfoNote frmInfoNote = new frmInfoNote(note);
                        M.notesOpened.Add(frmInfoNote);
                        frmInfoNote.Show();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot find note.");
                }
            }
        }

        private void tsmRemoveNote_Click(object sender, EventArgs e)
        {
            if (lsbNote.SelectedItem != null)
            {
                try
                {
                    string selectedItemText = lsbNote.SelectedItem.ToString();
                    string[] split = selectedItemText.Split('@');
                    string[] datelist = split[0].Split('.');
                    int Year = Convert.ToInt16(datelist[0]);
                    int Month = Convert.ToInt16(datelist[1]);
                    int Day = Convert.ToInt16(datelist[2]);
                    DateTime date = new DateTime(Year, Month, Day, 0, 0, 0);
                    string NoteTopic = split[1];

                    DialogResult result = MessageBox.Show("Delete this Note?", "Delete", MessageBoxButtons.YesNo);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            string GUID = G.glb.lstNote.Find(o => o.TagTime == date && o.Topic == NoteTopic).GUID;
                            G.glb.lstNote.RemoveAll(o => o.GUID == GUID);
                            G.glb.lstNoteColor.RemoveAll(o => o.GUID == GUID);
                            G.glb.lstNoteLog.RemoveAll(o => o.GUID == GUID);
                            RefreshNoteList();
                            break;
                        case DialogResult.No:
                            break;
                        default:
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot find note.");
                }
            }
        }

        private void tsmOpenLit_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedItemText = lsbLit.SelectedItem.ToString();
                CLiterature lit = G.glb.lstLiterature.Find(o =>  o.Title == selectedItemText);
                if (M.notesOpened.Exists(o => o.GUID == lit.GUID))
                {
                    M.notesOpened.Find(o => o.GUID == lit.GUID).Show();
                    M.notesOpened.Find(o => o.GUID == lit.GUID).BringToFront();
                }
                else
                {
                    frmInfoNote frmInfoNote = new frmInfoNote(lit);
                    M.notesOpened.Add(frmInfoNote);
                    frmInfoNote.Show();
                }
            }
            catch
            {
                MessageBox.Show("Cannot find literature.");
            }
        }
    }
}
