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
        public frmSearchNote(string noteName)
        {
            notes = G.glb.lstNote.FindAll(o => o.Topic.ToUpper().Contains(noteName.ToUpper()));
            InitializeComponent();
        }

        private void frmSearchNote_Load(object sender, EventArgs e)
        {
            notes = notes.OrderBy(o => o.TagTime).ToList();
            lsbNote.Items.Clear();
            foreach (CNote note in notes)
            {
                lsbNote.Items.Add(note.TagTime.Year.ToString() + "." + note.TagTime.Month.ToString() + "." + note.TagTime.Day.ToString() + " - " + note.Topic);
            }
        }

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            if (lsbNote.SelectedItem != null)
            {
                try
                {
                    string selectedItemText = lsbNote.SelectedItem.ToString();
                    string[] split = selectedItemText.Split('-');
                    string[] datelist = split[0].Split('.');
                    int Year = Convert.ToInt16(datelist[0]);
                    int Month = Convert.ToInt16(datelist[1]);
                    int Day = Convert.ToInt16(datelist[2].Substring(0, datelist[2].Length - 1));
                    DateTime date = new DateTime(Year, Month, Day, 0, 0, 0);
                    split[1] = split[1].Substring(1, split[1].Length - 1);
                    string NoteTopic = "";
                    for (int i = 1; i < split.Length; i++)
                    {
                        NoteTopic += split[i];
                        NoteTopic += "-";
                    }
                    NoteTopic = NoteTopic.Substring(0, NoteTopic.Length - 1);
                    CNote note = G.glb.lstNote.Find(o => o.TagTime == date && o.Topic == NoteTopic);
                    plot D = new plot();
                    D.CallInfoNote(note);
                }
                catch
                {
                    MessageBox.Show("Cannot find note.");
                }
            }
        }
    }
}
