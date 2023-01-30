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
    public partial class frmNoteProperties : Form
    {
        public frmNoteProperties(CNoteProperties noteProperties)
        {
            InitializeComponent();
            lblNoteType.Text = noteProperties.NoteType;
            lblNumChildren.Text = noteProperties.numChildren.ToString();
            lblNumCLinks.Text = noteProperties.numCLinks.ToString();
            lblNumCNotes.Text = noteProperties.numCNotes.ToString();
            lblNumCLitrs.Text = noteProperties.numCLitrs.ToString();
            lblNumOffsprings.Text = noteProperties.numOffsprings.ToString();
            lblNumOLinks.Text = noteProperties.numOLinks.ToString();
            lblNumONotes.Text = noteProperties.numONotes.ToString();
            lblNumOLitrs.Text = noteProperties.numOLitrs.ToString();
        }
    }
}
