using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace LifeGame
{
    public partial class frmStarter : Form
    {
        public frmStarter()
        {
            InitializeComponent();
        }
        private void SerializeNow()
        {
            FileStream f = new FileStream("data.dat", FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(f, G.glb);
            f.Close();
        }
        private void Deserialize()
        {
            FileStream f = new FileStream("data.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter b = new BinaryFormatter();
            G.glb = b.Deserialize(f) as Mem;
            f.Close();
        }
        private void frmStarter_Load(object sender, EventArgs e)
        {

            try
            {
                Deserialize();
            }
            catch (Exception)
            {
                MessageBox.Show("Can not find an existing data file, a new empty data file is auto-created");
                // Event
                G.glb.lstEvent = new List<CEvent>();

                // Note
                G.glb.lstNote = new List<CNote>();
                G.glb.lstNoteLog = new List<RNoteLog>();

                // Literature
                G.glb.lstLiterature = new List<CLiterature>();
                G.glb.lstLiteratureAuthor = new List<RLiteratureAuthor>();
                G.glb.lstLiteratureTag = new List<RLiteratureTag>();

                // Task and Log
                G.glb.lstSchedule = new List<CLog>();
                G.glb.lstLog = new List<CLog>();

                // Money
                G.glb.lstTransaction = new List<CTransaction>();
                G.glb.lstBudget = new List<CTransaction>();
                G.glb.lstAccount = new List<CAccount>();
                G.glb.lstSubAccount = new List<RSubAccount>();
                G.glb.lstCurrencyRate = new List<RCurrencyRate>();
                G.glb.lstTransaction.Clear();
                G.glb.lstAccount.Clear();
                G.glb.lstAccount.Add(new CAccount());
                G.glb.lstAccount.Add(new CAccount());
                G.glb.lstAccount.Add(new CAccount());
                G.glb.lstAccount.Add(new CAccount());
                G.glb.lstAccount.Add(new CAccount());
                G.glb.lstAccount.Add(new CAccount());
                G.glb.lstAccount.Add(new CAccount());
                G.glb.lstAccount[0].AccountName = "(Assets)";
                G.glb.lstAccount[0].AccountType = EAccountType.Assets;
                G.glb.lstAccount[0].Currency = "RMB";
                G.glb.lstAccount[0].ProtectedAccount = true;
                G.glb.lstAccount[1].AccountName = "(Gain/Loss on Exchange)";
                G.glb.lstAccount[1].AccountType = EAccountType.Assets;
                G.glb.lstAccount[1].Currency = "RMB";
                G.glb.lstAccount[1].ProtectedAccount = true;
                G.glb.lstAccount[2].AccountName = "(Expense)";
                G.glb.lstAccount[2].AccountType = EAccountType.Expense;
                G.glb.lstAccount[2].Currency = "RMB";
                G.glb.lstAccount[2].ProtectedAccount = true;
                G.glb.lstAccount[3].AccountName = "(Equity)";
                G.glb.lstAccount[3].AccountType = EAccountType.Equity;
                G.glb.lstAccount[3].Currency = "RMB";
                G.glb.lstAccount[3].ProtectedAccount = true;
                G.glb.lstAccount[4].AccountName = "(Openning Balance)";
                G.glb.lstAccount[4].AccountType = EAccountType.Equity;
                G.glb.lstAccount[4].Currency = "RMB";
                G.glb.lstAccount[4].ProtectedAccount = true;
                G.glb.lstAccount[5].AccountName = "(Liability)";
                G.glb.lstAccount[5].AccountType = EAccountType.Liability;
                G.glb.lstAccount[5].Currency = "RMB";
                G.glb.lstAccount[5].ProtectedAccount = true;
                G.glb.lstAccount[6].AccountName = "(Income)";
                G.glb.lstAccount[6].AccountType = EAccountType.Income;
                G.glb.lstAccount[6].Currency = "RMB";
                G.glb.lstAccount[6].ProtectedAccount = true;
                G.glb.lstSubAccount.Clear();
                G.glb.lstSubAccount.Add(new RSubAccount());
                G.glb.lstSubAccount.Add(new RSubAccount());
                G.glb.lstSubAccount.Add(new RSubAccount());
                G.glb.lstSubAccount.Add(new RSubAccount());
                G.glb.lstSubAccount.Add(new RSubAccount());
                G.glb.lstSubAccount.Add(new RSubAccount());
                G.glb.lstSubAccount.Add(new RSubAccount());
                G.glb.lstSubAccount[0].Account = "(Root)";
                G.glb.lstSubAccount[0].SubAccount = "(Assets)";
                G.glb.lstSubAccount[0].Ordering = 0;
                G.glb.lstSubAccount[1].Account = "(Root)";
                G.glb.lstSubAccount[1].SubAccount = "(Expense)";
                G.glb.lstSubAccount[1].Ordering = 1;
                G.glb.lstSubAccount[2].Account = "(Root)";
                G.glb.lstSubAccount[2].SubAccount = "(Equity)";
                G.glb.lstSubAccount[2].Ordering = 2;
                G.glb.lstSubAccount[3].Account = "(Root)";
                G.glb.lstSubAccount[3].SubAccount = "(Liability)";
                G.glb.lstSubAccount[3].Ordering = 3;
                G.glb.lstSubAccount[4].Account = "(Root)";
                G.glb.lstSubAccount[4].SubAccount = "(Income)";
                G.glb.lstSubAccount[4].Ordering = 4;
                G.glb.lstSubAccount[5].Account = "(Assets)";
                G.glb.lstSubAccount[5].SubAccount = "(Gain/Loss on Exchange)";
                G.glb.lstSubAccount[5].Ordering = 0;
                G.glb.lstSubAccount[6].Account = "(Equity)";
                G.glb.lstSubAccount[6].SubAccount = "(Openning Balance)";
                G.glb.lstSubAccount[6].Ordering = 0;
                G.glb.lstCurrencyRate.Clear();
                G.glb.lstCurrencyRate.Add(new RCurrencyRate());
                G.glb.lstCurrencyRate[0].CurrencyA = "USD";
                G.glb.lstCurrencyRate[0].CurrencyB = "RMB";
                G.glb.lstCurrencyRate[0].Rate = 6.5;

                SerializeNow();
            }

            DateTime today = DateTime.Today.Date;
            if (G.glb.lstNote.Exists(o => o.Topic == "Daily Report" && o.TagTime == today))
            {
                CNote prevDateNote = G.glb.lstNote.Find(o => o.Topic == "Daily Report" && o.TagTime.Date == today.Date);
                frmInfoNote frmInfoNote = new frmInfoNote(prevDateNote);
                M.notesOpened.Add(frmInfoNote);
                frmInfoNote.Show();
            }
            else
            {
                frmInfoNote frmInfoNote = new frmInfoNote(today, true);
                M.notesOpened.Add(frmInfoNote);
                frmInfoNote.Show();
            }

            this.WindowState = FormWindowState.Minimized;
        }

        private void frmStarter_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        private void nfiMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DateTime today = DateTime.Today.Date;
            if (G.glb.lstNote.Exists(o => o.Topic == "Daily Report" && o.TagTime == today))
            {
                CNote prevDateNote = G.glb.lstNote.Find(o => o.Topic == "Daily Report" && o.TagTime.Date == today.Date);
                frmInfoNote frmInfoNote = new frmInfoNote(prevDateNote);
                M.notesOpened.Add(frmInfoNote);
                frmInfoNote.Show();
            }
            else
            {
                frmInfoNote frmInfoNote = new frmInfoNote(today, true);
                M.notesOpened.Add(frmInfoNote);
                frmInfoNote.Show();
            }
        }

        private void frmStarter_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                nfiMain.Visible = true;
                this.ShowInTaskbar = false;
            }
            else
            {
                DateTime today = DateTime.Today.Date;
                if (G.glb.lstNote.Exists(o => o.Topic == "Daily Report" && o.TagTime == today))
                {
                    CNote prevDateNote = G.glb.lstNote.Find(o => o.Topic == "Daily Report" && o.TagTime.Date == today.Date);
                    frmInfoNote frmInfoNote = new frmInfoNote(prevDateNote);
                    M.notesOpened.Add(frmInfoNote);
                    frmInfoNote.Show();
                }
                else
                {
                    frmInfoNote frmInfoNote = new frmInfoNote(today, true);
                    M.notesOpened.Add(frmInfoNote);
                    frmInfoNote.Show();
                }

                nfiMain.Visible = false;
            }
        }

        private void tsmToday_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today.Date;
            if (G.glb.lstNote.Exists(o => o.Topic == "Daily Report" && o.TagTime == today))
            {
                CNote prevDateNote = G.glb.lstNote.Find(o => o.Topic == "Daily Report" && o.TagTime.Date == today.Date);
                frmInfoNote frmInfoNote = new frmInfoNote(prevDateNote);
                M.notesOpened.Add(frmInfoNote);
                frmInfoNote.Show();
            }
            else
            {
                frmInfoNote frmInfoNote = new frmInfoNote(today, true);
                M.notesOpened.Add(frmInfoNote);
                frmInfoNote.Show();
            }
        }

        private void tsmToolNewNote_Click(object sender, EventArgs e)
        {
            frmInfoNote frmInfoNote = new frmInfoNote(DateTime.Today.Date);
            frmInfoNote.Show();
        }

        private void tsmFindNote_Click(object sender, EventArgs e)
        {
            string search = Interaction.InputBox("Search for existing notes.", "Search Note", "", 300, 300);
            if (search != "")
            {
                List<CNote> notes = G.glb.lstNote.FindAll(o => o.Topic.ToUpper().Contains(search.ToUpper()));
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
                    frmSearchNote frmSearchNote = new frmSearchNote(search);
                    frmSearchNote.Show();
                }
            }
        }

        private void tsmToolLiterature_Click(object sender, EventArgs e)
        {
            if (M.literatureOpened.Count != 0)
            {
                M.literatureOpened[0].Show();
                M.literatureOpened[0].BringToFront();
            }
            else
            {
                frmLiterature frmLiterature = new frmLiterature();
                M.literatureOpened.Add(frmLiterature);
                frmLiterature.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
