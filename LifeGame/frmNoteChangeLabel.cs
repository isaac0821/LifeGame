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
    public partial class frmNoteChangeLabel : Form
    {
        private string OldLabel = "";
        private List<string> LabelOptions = new List<string>();
        public frmNoteChangeLabel(string tmpOldLabel, List<string> tmpLabelOptions)
        {
            OldLabel = tmpOldLabel;
            LabelOptions = tmpLabelOptions;
            InitializeComponent();
        }

        public delegate void SetNewLabel(string NewLabel);
        public event SetNewLabel SendNewLabel;

        private void frmNoteChangeLabel_Load(object sender, EventArgs e)
        {
            lblOldLabel.Text = OldLabel;
            cbxNewLabel.Items.Clear();
            foreach (string label in LabelOptions)
            {
                cbxNewLabel.Items.Add(label);
            }
            cbxNewLabel.Text = OldLabel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SendNewLabel != null)
            {
                SendNewLabel(cbxNewLabel.Text);
                Dispose();
            }
        }
    }
}
