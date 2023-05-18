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
    public partial class frmDelNoteMine : Form
    {
        DateTime curDate;
        public frmDelNoteMine(DateTime date)
        {
            InitializeComponent();
            curDate = date;
            dtpDate.Value = curDate;
        }

        public delegate void DrawLogHandler();
        public event DrawLogHandler DrawLog;

        string SelectedCat = "";
        private void cmsDelete_Opening(object sender, CancelEventArgs e)
        {
            SelectedCat = (sender as ContextMenuStrip).SourceControl.Name;
        }

        private void LoadNotes()
        {
            lsbNote.Items.Clear();
            List<CNote> notes = G.glb.lstNote.FindAll(o => o.TagTime == curDate).ToList();
            foreach (CNote note in notes)
            {
                lsbNote.Items.Add(note.Topic);
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            switch (SelectedCat)
            {
                //case "lsbLiteratureLog":
                //    if (lsbLiteratureLog.SelectedItems != null)
                //    {
                //        G.glb.lstLiteratureLog.RemoveAll(o => o.TagTime == curDate && o.LiteratureTitle == lsbLiteratureLog.SelectedItem.ToString());
                //        LoadLiteratureLogs();
                //    }
                //    break;
                case "lsbNote":
                    if (lsbNote.SelectedItems != null)
                    {
                        DialogResult result = MessageBox.Show("If it is deleted it can not be restored?", "Delete", MessageBoxButtons.YesNo);
                        switch (result)
                        {
                            case DialogResult.Yes:
                                G.glb.lstNote.RemoveAll(o => o.TagTime == curDate && o.Topic == lsbNote.SelectedItem.ToString());
                                G.glb.lstNoteLog.RemoveAll(o => o.TagTime == curDate && o.Topic == lsbNote.SelectedItem.ToString());
                                break;
                            case DialogResult.No:
                                break;
                            default:
                                break;
                        }
                        LoadNotes();
                    }
                    break;
                default:
                    break;
            }
        }

        private void frmDelNoteMine_Load(object sender, EventArgs e)
        {
            LoadNotes();
        }

        private void frmDelNoteMine_FormClosing(object sender, FormClosingEventArgs e)
        {
            DrawLog();
        }
    }
}
