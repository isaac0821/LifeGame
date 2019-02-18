using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace LifeGame
{
    public partial class frmMain : Form
    {
        Timer timer = new Timer();

        private DateTime SelectedDate;
        private DateTime SelectedMonday;
        private DateTime SelectedTuesday;
        private DateTime SelectedWednesday;
        private DateTime SelectedThursday;
        private DateTime SelectedFriday;
        private DateTime SelectedSaturday;
        private DateTime SelectedSunday;

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

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                Deserialize();
                MessageBox.Show("Load existing file successfully.");
            }
            catch (Exception)
            {
                MessageBox.Show("Can not find an existing data file, a new empty data file is auto-created");
                // Event
                G.glb.lstEvent = new List<CEvent>();
                G.glb.lstSleepSchedule = new List<CSleep>();
                G.glb.lstSleepLog = new List<CSleep>();
                G.glb.lstWorkOut = new List<CWorkOut>();
                G.glb.lstMedicine = new List<CMedicine>();

                // Note
                G.glb.lstNote = new List<CNote>();
                G.glb.lstNoteOutsource = new List<RNoteOutsource>();
                G.glb.lstNoteLog = new List<RNoteLog>();

                // Literature
                G.glb.lstLiterature = new List<CLiterature>();
                G.glb.lstLiteratureAuthor = new List<RLiteratureAuthor>();
                G.glb.lstLiteratureTag = new List<RLiteratureTag>();
                G.glb.lstLiteratureCiting = new List<RLiteratureInCiting>();
                G.glb.lstLiteratureInstitution = new List<RLiteratureInstitution>();
                G.glb.lstLiteratureOutSource = new List<RLiteratureOutSource>();

                // Task and Log
                G.glb.lstTask = new List<CTask>();
                G.glb.lstSubTask = new List<RSubTask>();
                G.glb.lstSchedule = new List<CLog>();
                G.glb.lstLog = new List<CLog>();

                // Money
                G.glb.lstTransaction = new List<CTransaction>();
                G.glb.lstBudget = new List<CTransaction>();
                G.glb.lstAccount = new List<CAccount>();
                G.glb.lstSubAccount = new List<RSubAccount>();
                G.glb.lstCurrencyRate = new List<RCurrencyRate>();
            }

            SelectedDate = DateTime.Today.Date;
            dtpDate.Value = SelectedDate;
            DrawLog();
            timer.Interval = 1000 * 60 * 10;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SerializeNow();
            timer.Start();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            DrawLog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Wanna save?", "Saving", MessageBoxButtons.YesNoCancel);
            switch (result)
            {
                case DialogResult.Yes:
                    SerializeNow();
                    e.Cancel = false;
                    break;
                case DialogResult.No:
                    e.Cancel = false;
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                default:
                    e.Cancel = true;
                    break;
            }
        }

        private void taskTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTask frmTask = new frmTask();
            frmTask.Show();
        }

        private void moneyMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccount frmAccount = new frmAccount();
            frmAccount.Show();
        }

        private void literatureLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLiterature frmLiterature = new frmLiterature();
            frmLiterature.Show();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            SelectedDate = dtpDate.Value.Date;
            switch (SelectedDate.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    SelectedMonday = SelectedDate.Date.AddDays(-6);
                    SelectedTuesday = SelectedDate.Date.AddDays(-5);
                    SelectedWednesday = SelectedDate.Date.AddDays(-4);
                    SelectedThursday = SelectedDate.Date.AddDays(-3);
                    SelectedFriday = SelectedDate.Date.AddDays(-2);
                    SelectedSaturday = SelectedDate.Date.AddDays(-1);
                    SelectedSunday = SelectedDate.Date.AddDays(0);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Monday:
                    SelectedMonday = SelectedDate.Date.AddDays(0);
                    SelectedTuesday = SelectedDate.Date.AddDays(1);
                    SelectedWednesday = SelectedDate.Date.AddDays(2);
                    SelectedThursday = SelectedDate.Date.AddDays(3);
                    SelectedFriday = SelectedDate.Date.AddDays(4);
                    SelectedSaturday = SelectedDate.Date.AddDays(5);
                    SelectedSunday = SelectedDate.Date.AddDays(6);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Tuesday:
                    SelectedMonday = SelectedDate.Date.AddDays(-1);
                    SelectedTuesday = SelectedDate.Date.AddDays(0);
                    SelectedWednesday = SelectedDate.Date.AddDays(1);
                    SelectedThursday = SelectedDate.Date.AddDays(2);
                    SelectedFriday = SelectedDate.Date.AddDays(3);
                    SelectedSaturday = SelectedDate.Date.AddDays(4);
                    SelectedSunday = SelectedDate.Date.AddDays(5);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Wednesday:
                    SelectedMonday = SelectedDate.Date.AddDays(-2);
                    SelectedTuesday = SelectedDate.Date.AddDays(-1);
                    SelectedWednesday = SelectedDate.Date.AddDays(0);
                    SelectedThursday = SelectedDate.Date.AddDays(1);
                    SelectedFriday = SelectedDate.Date.AddDays(2);
                    SelectedSaturday = SelectedDate.Date.AddDays(3);
                    SelectedSunday = SelectedDate.Date.AddDays(4);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Thursday:
                    SelectedMonday = SelectedDate.Date.AddDays(-3);
                    SelectedTuesday = SelectedDate.Date.AddDays(-2);
                    SelectedWednesday = SelectedDate.Date.AddDays(-1);
                    SelectedThursday = SelectedDate.Date.AddDays(0);
                    SelectedFriday = SelectedDate.Date.AddDays(1);
                    SelectedSaturday = SelectedDate.Date.AddDays(2);
                    SelectedSunday = SelectedDate.Date.AddDays(3);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Friday:
                    SelectedMonday = SelectedDate.Date.AddDays(-4);
                    SelectedTuesday = SelectedDate.Date.AddDays(-3);
                    SelectedWednesday = SelectedDate.Date.AddDays(-2);
                    SelectedThursday = SelectedDate.Date.AddDays(-1);
                    SelectedFriday = SelectedDate.Date.AddDays(0);
                    SelectedSaturday = SelectedDate.Date.AddDays(1);
                    SelectedSunday = SelectedDate.Date.AddDays(2);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Saturday:
                    SelectedMonday = SelectedDate.Date.AddDays(-5);
                    SelectedTuesday = SelectedDate.Date.AddDays(-4);
                    SelectedWednesday = SelectedDate.Date.AddDays(-3);
                    SelectedThursday = SelectedDate.Date.AddDays(-2);
                    SelectedFriday = SelectedDate.Date.AddDays(-1);
                    SelectedSaturday = SelectedDate.Date.AddDays(0);
                    SelectedSunday = SelectedDate.Date.AddDays(1);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                default:
                    break;
            }
            DrawLog();
        }
        private void btnPreDate_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(-7);
        }
        private void btnNextDate_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(7);
        }

        private string SelectedPicName = "";
        private void cmsMain_Opening(object sender, CancelEventArgs e)
        {
            SelectedPicName = (sender as ContextMenuStrip).SourceControl.Name;
        }
        private void tsmAddSleepSchedule_Click(object sender, EventArgs e)
        {
            frmAddSleepSchedule frmAddScheduleSleep = new frmAddSleepSchedule();
            frmAddScheduleSleep.DrawLog += new frmAddSleepSchedule.DrawLogHandler(DrawLog);
            frmAddScheduleSleep.Show();
        }
        private void tsmAddSleepLog_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThu":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmAddSleepLog frmAddLogSleep = new frmAddSleepLog(sendToFrm);
            frmAddLogSleep.DrawLog += new frmAddSleepLog.DrawLogHandler(DrawLog);
            frmAddLogSleep.Show();
        }
        private void tsmAddSchedule_Click(object sender, EventArgs e)
        {
            frmAddSchedule frmAddSchedule = new frmAddSchedule();
            frmAddSchedule.DrawLog += new frmAddSchedule.DrawLogHandler(DrawLog);
            frmAddSchedule.Show();
        }
        private void tsmAddLog_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThu":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmAddLog frmAddLog = new frmAddLog(sendToFrm);
            frmAddLog.DrawLog += new frmAddLog.DrawLogHandler(DrawLog);
            frmAddLog.Show();
        }

        private void tsmDeleteSingleSchedule_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThu":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmDelLog frmDelLog = new frmDelLog(sendToFrm, false);
            frmDelLog.DrawLog += new frmDelLog.DrawLogHandler(DrawLog);
            frmDelLog.Show();
        }

        private void tsmClearSchedule_Click(object sender, EventArgs e)
        {
            frmClearSchedule frmClearSchedule = new frmClearSchedule();
            frmClearSchedule.DrawLog += new frmClearSchedule.DrawLogHandler(DrawLog);
            frmClearSchedule.Show();
        }

        private void tsmDeleteLog_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThu":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmDelLog frmDelLog = new frmDelLog(sendToFrm, true);
            frmDelLog.DrawLog += new frmDelLog.DrawLogHandler(DrawLog);
            frmDelLog.Show();
        }

        private void tsmDeleteInfoMine_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThu":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmDelInfoMine frmDelInfoMine = new frmDelInfoMine(sendToFrm);
            frmDelInfoMine.DrawLog += new frmDelInfoMine.DrawLogHandler(DrawLog);
            frmDelInfoMine.Show();
        }

        private void tsmDeleteNoteMine_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThu":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmDelNoteMine frmDelNoteMine = new frmDelNoteMine(sendToFrm);
            frmDelNoteMine.DrawLog += new frmDelNoteMine.DrawLogHandler(DrawLog);
            frmDelNoteMine.Show();
        }

        private void tsmAddEvent_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThu":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmAddEvent frmAddEvent = new frmAddEvent(sendToFrm);
            frmAddEvent.DrawLog += new frmAddEvent.DrawLogHandler(DrawLog);
            frmAddEvent.Show();
        }

        private void tsmAddNewTransaction_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThu":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmAddTransaction frmAddTransaction = new frmAddTransaction(sendToFrm);
            frmAddTransaction.DrawLog += new frmAddTransaction.DrawLogHandler(DrawLog);
            frmAddTransaction.Show();
        }

        private void tsmConvertBudget_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThu":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmConvertBudget frmConvertBudget = new frmConvertBudget(sendToFrm);
            frmConvertBudget.DrawLog += new frmConvertBudget.DrawLogHandler(DrawLog);
            frmConvertBudget.Show();
        }

        private void tsmAddBudget_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThu":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmAddBudget frmAddBudget = new frmAddBudget(sendToFrm);
            frmAddBudget.DrawLog += new frmAddBudget.DrawLogHandler(DrawLog);
            frmAddBudget.Show();
        }

        private void tsmAddWorkOut_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThu":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmAddWorkOut frmAddWorkOut = new frmAddWorkOut(sendToFrm);
            frmAddWorkOut.DrawLog += new frmAddWorkOut.DrawLogHandler(DrawLog);
            frmAddWorkOut.Show();
        }

        private void tsmAddMedicine_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThu":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmAddMedicine frmAddMedicine = new frmAddMedicine(sendToFrm);
            frmAddMedicine.DrawLog += new frmAddMedicine.DrawLogHandler(DrawLog);
            frmAddMedicine.Show();
        }

        private void tsmAddNote_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThu":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmInfoNote frmInfoNote = new frmInfoNote(sendToFrm);
            frmInfoNote.DrawLog += new frmInfoNote.DrawLogHandler(DrawLog);
            frmInfoNote.Show();
        }

        private void picMon_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedMonday;
            dtpDate.Value = SelectedDate;
        }
        private void picTue_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedTuesday;
            dtpDate.Value = SelectedDate;
        }
        private void picWed_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedWednesday;
            dtpDate.Value = SelectedDate;
        }
        private void picThu_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedThursday;
            dtpDate.Value = SelectedDate;
        }
        private void picFri_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedFriday;
            dtpDate.Value = SelectedDate;
        }
        private void picSat_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedSaturday;
            dtpDate.Value = SelectedDate;
        }
        private void picSun_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedSunday;
            dtpDate.Value = SelectedDate;
        }

        private void LoadLblDaily(Label lbl, DateTime date)
        {
            lbl.Text = "";
            string whole = "";
            List<CTask> taskDeadline = G.glb.lstTask.FindAll(o => o.DeadLine.Date == date.Date).ToList();
            foreach (CTask task in taskDeadline)
            {
                whole += "Deadline: " + task.TaskName + "\n";
            }
            if (taskDeadline.Count > 0)
            {
                whole = whole.Substring(0, whole.Length - 1);
            }
            lbl.Text = whole;
        }

        public void DrawLog()
        {
            Draw Draw = new Draw();
            LoadLblDaily(lblDDLMon, SelectedMonday);
            LoadLblDaily(lblDDLTue, SelectedTuesday);
            LoadLblDaily(lblDDLWed, SelectedWednesday);
            LoadLblDaily(lblDDLThu, SelectedThursday);
            LoadLblDaily(lblDDLFri, SelectedFriday);
            LoadLblDaily(lblDDLSat, SelectedSaturday);
            LoadLblDaily(lblDDLSun, SelectedSunday);

            picMon.Controls.Clear();
            picTue.Controls.Clear();
            picWed.Controls.Clear();
            picThu.Controls.Clear();
            picFri.Controls.Clear();
            picSat.Controls.Clear();
            picSun.Controls.Clear();

            if (chkShowSchedule.Checked && chkShowLog.Checked & chkMoney.Checked)
            {
                DrawScheduleWithMode("leftWithSupp");
                DrawLogWithMode("rightWithSupp");
                DrawEvent();
            }
            else if (chkShowSchedule.Checked && chkShowLog.Checked & !chkMoney.Checked)
            {
                DrawScheduleWithMode("left");
                DrawLogWithMode("right");
            }
            else if (chkShowSchedule.Checked && !chkShowLog.Checked & chkMoney.Checked)
            {
                DrawScheduleWithMode("allWithSupp");
                DrawEvent();
            }
            else if (chkShowSchedule.Checked && !chkShowLog.Checked & !chkMoney.Checked)
            {
                DrawScheduleWithMode("all");
            }
            else if (!chkShowSchedule.Checked && chkShowLog.Checked & chkMoney.Checked)
            {
                DrawLogWithMode("allWithSupp");
                DrawEvent();
            }
            else if (!chkShowSchedule.Checked && chkShowLog.Checked & !chkMoney.Checked)
            {
                DrawLogWithMode("all");
            }
            else if (!chkShowSchedule.Checked && !chkShowLog.Checked & chkMoney.Checked)
            {
                DrawEvent();
            }
            else if (!chkShowSchedule.Checked && !chkShowLog.Checked & !chkMoney.Checked)
            {

            }
        }
        private void DrawLogWithMode(string Mode)
        {
            Draw Draw = new Draw();
            Draw.DrawScheduleAndLogController(picMon, SelectedMonday, G.glb.lstLog, G.glb.lstSleepLog, Mode);
            Draw.DrawScheduleAndLogController(picTue, SelectedTuesday, G.glb.lstLog, G.glb.lstSleepLog, Mode);
            Draw.DrawScheduleAndLogController(picWed, SelectedWednesday, G.glb.lstLog, G.glb.lstSleepLog, Mode);
            Draw.DrawScheduleAndLogController(picThu, SelectedThursday, G.glb.lstLog, G.glb.lstSleepLog, Mode);
            Draw.DrawScheduleAndLogController(picFri, SelectedFriday, G.glb.lstLog, G.glb.lstSleepLog, Mode);
            Draw.DrawScheduleAndLogController(picSat, SelectedSaturday, G.glb.lstLog, G.glb.lstSleepLog, Mode);
            Draw.DrawScheduleAndLogController(picSun, SelectedSunday, G.glb.lstLog, G.glb.lstSleepLog, Mode);
        }
        private void DrawScheduleWithMode(string Mode)
        {
            Draw Draw = new Draw();
            Draw.DrawScheduleAndLogController(picMon, SelectedMonday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picTue, SelectedTuesday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picWed, SelectedWednesday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picThu, SelectedThursday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picFri, SelectedFriday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picSat, SelectedSaturday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picSun, SelectedSunday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
        }
        private void DrawEvent()        {
            Draw Draw = new Draw();
            Draw.DrawEventController(picMon, SelectedMonday, G.glb.lstEvent, G.glb.lstWorkOut, G.glb.lstMedicine, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
            Draw.DrawEventController(picTue, SelectedTuesday, G.glb.lstEvent, G.glb.lstWorkOut, G.glb.lstMedicine, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
            Draw.DrawEventController(picWed, SelectedWednesday, G.glb.lstEvent, G.glb.lstWorkOut, G.glb.lstMedicine, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
            Draw.DrawEventController(picThu, SelectedThursday, G.glb.lstEvent, G.glb.lstWorkOut, G.glb.lstMedicine, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
            Draw.DrawEventController(picFri, SelectedFriday, G.glb.lstEvent, G.glb.lstWorkOut, G.glb.lstMedicine, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
            Draw.DrawEventController(picSat, SelectedSaturday, G.glb.lstEvent, G.glb.lstWorkOut, G.glb.lstMedicine, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
            Draw.DrawEventController(picSun, SelectedSunday, G.glb.lstEvent, G.glb.lstWorkOut, G.glb.lstMedicine, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
        }

        private void lblDDLMon_Click(object sender, EventArgs e)
        {
            Draw D = new Draw();
            D.CallInfoDDL(lblDDLMon.Text);
        }
        private void lblDDLTue_Click(object sender, EventArgs e)
        {
            Draw D = new Draw();
            D.CallInfoDDL(lblDDLTue.Text);
        }
        private void lblDDLWed_Click(object sender, EventArgs e)
        {
            Draw D = new Draw();
            D.CallInfoDDL(lblDDLWed.Text);
        }
        private void lblDDLThu_Click(object sender, EventArgs e)
        {
            Draw D = new Draw();
            D.CallInfoDDL(lblDDLThu.Text);
        }
        private void lblDDLFri_Click(object sender, EventArgs e)
        {
            Draw D = new Draw();
            D.CallInfoDDL(lblDDLFri.Text);
        }
        private void lblDDLSat_Click(object sender, EventArgs e)
        {
            Draw D = new Draw();
            D.CallInfoDDL(lblDDLSat.Text);
        }
        private void lblDDLSun_Click(object sender, EventArgs e)
        {
            Draw D = new Draw();
            D.CallInfoDDL(lblDDLSun.Text);
        }

        private void chkShowSchedule_CheckedChanged(object sender, EventArgs e)
        {
            DrawLog();
        }
        private void chkShowLog_CheckedChanged(object sender, EventArgs e)
        {
            DrawLog();
        }
        private void chkMoney_CheckedChanged(object sender, EventArgs e)
        {
            DrawLog();
        }
    }
}
