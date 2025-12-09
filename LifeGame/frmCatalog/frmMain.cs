using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Windows.Forms.VisualStyles;

namespace LifeGame
{
    public partial class frmMain : Form
    {
        Timer autoSaveTimer = new Timer();
        Timer curPointerTimer = new Timer();

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



            //foreach (CNote item in G.glb.lstNote)
            //{
            //    if (item.FatherGUID == null) { item.FatherGUID = ""; }
            //}

            //foreach (RNoteLog item in G.glb.lstNoteLog)
            //{
            //    if (item.Topic == null) { item.Topic = ""; }
            //    if (item.FatherGUID == null) { item.FatherGUID = ""; }
            //    if (item.SubGUID == null) { item.SubGUID = ""; }
            //    if (item.GUID == null) { item.GUID = ""; }
            //}

            //foreach (CLiterature item in G.glb.lstLiterature)
            //{
            //    if (item.Title == null) { item.Title = ""; }
            //    if (item.JournalOrConferenceName == null) { item.JournalOrConferenceName = ""; }
            //    if (item.Address == null) { item.Address = ""; }
            //    if (item.Annote == null) { item.Annote = ""; }
            //    if (item.Author == null) { item.Author = ""; }
            //    if (item.Booktitle == null) { item.Booktitle = ""; }
            //    if (item.Chapter == null) { item.Chapter = ""; }
            //    if (item.Crossref == null) { item.Crossref = ""; }
            //    if (item.Doi == null) { item.Doi = ""; }
            //    if (item.Edition == null) { item.Edition = ""; }
            //    if (item.Editor == null) { item.Editor = ""; }
            //    if (item.Howpublished == null) { item.Howpublished = ""; }
            //    if (item.Institution == null) { item.Institution = ""; }
            //    if (item.Journal == null) { item.Journal = ""; }
            //    if (item.Key == null) { item.Key = ""; }
            //    if (item.Month == null) { item.Month = ""; }
            //    if (item.Note == null) { item.Note = ""; }
            //    if (item.Number == null) { item.Number = ""; }
            //    if (item.Organization == null) { item.Organization = ""; }
            //    if (item.Pages == null) { item.Pages = ""; }
            //    if (item.Publisher == null) { item.Publisher = ""; }
            //    if (item.School == null) { item.School = ""; }
            //    if (item.Series == null) { item.Series = ""; }
            //    if (item.Type == null) { item.Type = ""; }
            //    if (item.Volume == null) { item.Volume = ""; }
            //    if (item.Year == null) { item.Year = ""; }
            //}

            //IO.SaveData();
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
            }
            catch (Exception)
            {
                MessageBox.Show("Can not find an existing data file, a new empty data file is auto-created");
                G.glb.lstEvent = new List<CEvent>();
                G.glb.lstNote = new List<CNote>();
                G.glb.lstNoteLog = new List<RNoteLog>();
                G.glb.lstLiterature = new List<CLiterature>();
                G.glb.lstLiteratureAuthor = new List<RLiteratureAuthor>();
                G.glb.lstLiteratureTag = new List<RLiteratureTag>();
                G.glb.lstSchedule = new List<CLog>();

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

            // 转至当天
            SelectedDate = DateTime.Today.Date;
            dtpDate.Value = SelectedDate;
            DrawLog();

            // 定时保存， 每10分钟
            autoSaveTimer.Interval = 1000 * 60 * 30;
            autoSaveTimer.Start();
            autoSaveTimer.Tick += AutoSave;

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
            curPointerTimer.Tick += RefreshBackground;
        }

        private void AutoSave(object sender, EventArgs e)
        {
            SerializeNow();
        }

        private void RefreshBackground(object sender, EventArgs e)
        {
            curPointerTimer.Interval = 1000 * 60;
            FindNextToAlarm();
            DrawToday();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            tblMain.ColumnStyles[0].Width = 30;
            tblMain.ColumnStyles[8].Width = 30;
            DrawLog();

            if (this.WindowState == FormWindowState.Minimized)
            {
                nfiMain.Visible = true;
                this.ShowInTaskbar = false;
            }
            else
            {
                nfiMain.Visible = false;
            }
        }

        private void FindNextToAlarm()
        {
            CLog nextAlarmingSchedule = G.glb.lstSchedule.FindAll(o => o.Alarm == true && o.StartTime >= DateTime.Now && (DateTime.Now - o.AlarmTime).TotalMinutes <= 1).OrderBy(o => o.AlarmTime).FirstOrDefault();
            if (nextAlarmingSchedule != null)
            {
                TimeSpan minToNextAlarm = new TimeSpan();
                minToNextAlarm = nextAlarmingSchedule.AlarmTime - DateTime.Now;
                if ((int)minToNextAlarm.TotalMinutes == 0)
                {
                    double totalHour = (nextAlarmingSchedule.EndTime - nextAlarmingSchedule.StartTime).TotalHours;
                    totalHour = Math.Round(totalHour, 2);
                    SystemSounds.Beep.Play();
                    string TimePeriod;
                    if (nextAlarmingSchedule.EndTime.Date == DateTime.Today.Date)
                    {
                        TimePeriod = nextAlarmingSchedule.StartTime.ToShortTimeString() + " - " + nextAlarmingSchedule.EndTime.ToShortTimeString() + " [" + totalHour.ToString() + "h]";
                    }
                    else
                    {
                        TimePeriod = nextAlarmingSchedule.StartTime.ToShortTimeString() + " - " + nextAlarmingSchedule.EndTime.ToShortTimeString() + "(+1d)" + " [" + totalHour.ToString() + "h]";
                    }
                    string LogName = nextAlarmingSchedule.LogName;
                    string Location = nextAlarmingSchedule.Location;
                    string WithWho = nextAlarmingSchedule.WithWho;
                    bool IsAlarm = nextAlarmingSchedule.Alarm;
                    plot p = new plot();
                    Color backColor = p.GetColor(nextAlarmingSchedule.Color);
                    frmInfoLog frmInfoLog = new frmInfoLog(TimePeriod, LogName, Location, WithWho, backColor, IsAlarm, false);
                    frmInfoLog.Show();
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                SerializeNow();
                e.Cancel = false;
            }
            else
            {
                DialogResult minimize = MessageBox.Show("Minimize windows (Yes) or exit (No)?", "Exiting", MessageBoxButtons.YesNoCancel);
                switch (minimize)
                {

                    case DialogResult.Yes:
                        this.WindowState = FormWindowState.Minimized;
                        e.Cancel = true;
                        break;
                    case DialogResult.No:
                        SerializeNow();
                        e.Cancel = false;
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void moneyMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccount frmAccount = new frmAccount();
            frmAccount.Show();
        }

        private void literatureLToolStripMenuItem_Click(object sender, EventArgs e)
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
                    lblMonday.Text = SelectedMonday.ToShortDateString();
                    lblTuesday.Text = SelectedTuesday.ToShortDateString();
                    lblWednesday.Text = SelectedWednesday.ToShortDateString();
                    lblThursday.Text = SelectedThursday.ToShortDateString();
                    lblFriday.Text = SelectedFriday.ToShortDateString();
                    lblSaturday.Text = SelectedSaturday.ToShortDateString();
                    lblSunday.Text = SelectedSunday.ToShortDateString();
                    break;
                case DayOfWeek.Monday:
                    SelectedMonday = SelectedDate.Date.AddDays(0);
                    SelectedTuesday = SelectedDate.Date.AddDays(1);
                    SelectedWednesday = SelectedDate.Date.AddDays(2);
                    SelectedThursday = SelectedDate.Date.AddDays(3);
                    SelectedFriday = SelectedDate.Date.AddDays(4);
                    SelectedSaturday = SelectedDate.Date.AddDays(5);
                    SelectedSunday = SelectedDate.Date.AddDays(6);
                    lblMonday.Text = SelectedMonday.ToShortDateString();
                    lblTuesday.Text = SelectedTuesday.ToShortDateString();
                    lblWednesday.Text = SelectedWednesday.ToShortDateString();
                    lblThursday.Text = SelectedThursday.ToShortDateString();
                    lblFriday.Text = SelectedFriday.ToShortDateString();
                    lblSaturday.Text = SelectedSaturday.ToShortDateString();
                    lblSunday.Text = SelectedSunday.ToShortDateString();
                    break;
                case DayOfWeek.Tuesday:
                    SelectedMonday = SelectedDate.Date.AddDays(-1);
                    SelectedTuesday = SelectedDate.Date.AddDays(0);
                    SelectedWednesday = SelectedDate.Date.AddDays(1);
                    SelectedThursday = SelectedDate.Date.AddDays(2);
                    SelectedFriday = SelectedDate.Date.AddDays(3);
                    SelectedSaturday = SelectedDate.Date.AddDays(4);
                    SelectedSunday = SelectedDate.Date.AddDays(5);
                    lblMonday.Text = SelectedMonday.ToShortDateString();
                    lblTuesday.Text = SelectedTuesday.ToShortDateString();
                    lblWednesday.Text = SelectedWednesday.ToShortDateString();
                    lblThursday.Text = SelectedThursday.ToShortDateString();
                    lblFriday.Text = SelectedFriday.ToShortDateString();
                    lblSaturday.Text = SelectedSaturday.ToShortDateString();
                    lblSunday.Text = SelectedSunday.ToShortDateString();
                    break;
                case DayOfWeek.Wednesday:
                    SelectedMonday = SelectedDate.Date.AddDays(-2);
                    SelectedTuesday = SelectedDate.Date.AddDays(-1);
                    SelectedWednesday = SelectedDate.Date.AddDays(0);
                    SelectedThursday = SelectedDate.Date.AddDays(1);
                    SelectedFriday = SelectedDate.Date.AddDays(2);
                    SelectedSaturday = SelectedDate.Date.AddDays(3);
                    SelectedSunday = SelectedDate.Date.AddDays(4);
                    lblMonday.Text = SelectedMonday.ToShortDateString();
                    lblTuesday.Text = SelectedTuesday.ToShortDateString();
                    lblWednesday.Text = SelectedWednesday.ToShortDateString();
                    lblThursday.Text = SelectedThursday.ToShortDateString();
                    lblFriday.Text = SelectedFriday.ToShortDateString();
                    lblSaturday.Text = SelectedSaturday.ToShortDateString();
                    lblSunday.Text = SelectedSunday.ToShortDateString();
                    break;
                case DayOfWeek.Thursday:
                    SelectedMonday = SelectedDate.Date.AddDays(-3);
                    SelectedTuesday = SelectedDate.Date.AddDays(-2);
                    SelectedWednesday = SelectedDate.Date.AddDays(-1);
                    SelectedThursday = SelectedDate.Date.AddDays(0);
                    SelectedFriday = SelectedDate.Date.AddDays(1);
                    SelectedSaturday = SelectedDate.Date.AddDays(2);
                    SelectedSunday = SelectedDate.Date.AddDays(3);
                    lblMonday.Text = SelectedMonday.ToShortDateString();
                    lblTuesday.Text = SelectedTuesday.ToShortDateString();
                    lblWednesday.Text = SelectedWednesday.ToShortDateString();
                    lblThursday.Text = SelectedThursday.ToShortDateString();
                    lblFriday.Text = SelectedFriday.ToShortDateString();
                    lblSaturday.Text = SelectedSaturday.ToShortDateString();
                    lblSunday.Text = SelectedSunday.ToShortDateString();
                    break;
                case DayOfWeek.Friday:
                    SelectedMonday = SelectedDate.Date.AddDays(-4);
                    SelectedTuesday = SelectedDate.Date.AddDays(-3);
                    SelectedWednesday = SelectedDate.Date.AddDays(-2);
                    SelectedThursday = SelectedDate.Date.AddDays(-1);
                    SelectedFriday = SelectedDate.Date.AddDays(0);
                    SelectedSaturday = SelectedDate.Date.AddDays(1);
                    SelectedSunday = SelectedDate.Date.AddDays(2);
                    lblMonday.Text = SelectedMonday.ToShortDateString();
                    lblTuesday.Text = SelectedTuesday.ToShortDateString();
                    lblWednesday.Text = SelectedWednesday.ToShortDateString();
                    lblThursday.Text = SelectedThursday.ToShortDateString();
                    lblFriday.Text = SelectedFriday.ToShortDateString();
                    lblSaturday.Text = SelectedSaturday.ToShortDateString();
                    lblSunday.Text = SelectedSunday.ToShortDateString();
                    break;
                case DayOfWeek.Saturday:
                    SelectedMonday = SelectedDate.Date.AddDays(-5);
                    SelectedTuesday = SelectedDate.Date.AddDays(-4);
                    SelectedWednesday = SelectedDate.Date.AddDays(-3);
                    SelectedThursday = SelectedDate.Date.AddDays(-2);
                    SelectedFriday = SelectedDate.Date.AddDays(-1);
                    SelectedSaturday = SelectedDate.Date.AddDays(0);
                    SelectedSunday = SelectedDate.Date.AddDays(1);
                    lblMonday.Text = SelectedMonday.ToShortDateString();
                    lblTuesday.Text = SelectedTuesday.ToShortDateString();
                    lblWednesday.Text = SelectedWednesday.ToShortDateString();
                    lblThursday.Text = SelectedThursday.ToShortDateString();
                    lblFriday.Text = SelectedFriday.ToShortDateString();
                    lblSaturday.Text = SelectedSaturday.ToShortDateString();
                    lblSunday.Text = SelectedSunday.ToShortDateString();
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
        private void tsmAddSchedule_Click(object sender, EventArgs e)
        {
            frmAddSchedule frmAddSchedule = new frmAddSchedule();
            frmAddSchedule.DrawLog += new frmAddSchedule.DrawLogHandler(DrawLog);
            frmAddSchedule.Show();
        }
        private void tsmAddNewLog_Click(object sender, EventArgs e)
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

        private void tsmConvertSchedule_Click(object sender, EventArgs e)
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
            frmConvertSchedule frmConvertSchedule = new frmConvertSchedule(sendToFrm);
            frmConvertSchedule.DrawLog += new frmConvertSchedule.DrawLogHandler(DrawLog);
            frmConvertSchedule.Show();
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

        private void tsmAddNote_Click(object sender, EventArgs e)
        {
            string strTitle = Interaction.InputBox("Input new note topic", "Add Note", "(New Note)", 300, 300);
            CNote newNote = new CNote();
            newNote.Topic = strTitle;
            newNote.TagTime = DateTime.Today;
            newNote.GUID = Guid.NewGuid().ToString();
            G.glb.lstNote.Add(newNote);
            frmInfoNote frmInfoNote = new frmInfoNote(newNote);
            frmInfoNote.DrawLog += new frmInfoNote.DrawLogHandler(DrawLog);
            frmInfoNote.Show();
        }

        private void picMon_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedMonday;
            dtpDate.Value = SelectedDate;
            OpenDiary(SelectedDate);
        }
        private void picTue_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedTuesday;
            dtpDate.Value = SelectedDate;
            OpenDiary(SelectedDate);
        }
        private void picWed_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedWednesday;
            dtpDate.Value = SelectedDate;
            OpenDiary(SelectedDate);
        }
        private void picThu_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedThursday;
            dtpDate.Value = SelectedDate;
            OpenDiary(SelectedDate);
        }
        private void picFri_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedFriday;
            dtpDate.Value = SelectedDate;
            OpenDiary(SelectedDate);
        }
        private void picSat_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedSaturday;
            dtpDate.Value = SelectedDate;
            OpenDiary(SelectedDate);
        }
        private void picSun_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedSunday;
            dtpDate.Value = SelectedDate;
            OpenDiary(SelectedDate);
        }

        public void DrawToday()
        {
            plot Draw = new plot();
            DateTime TodayDayOfWeek = new DateTime();
            PictureBox selectedPic = new PictureBox();
            bool NeedRefresh = true;
            if (DateTime.Today == SelectedSunday)
            {
                picSun.Controls.Clear();
                selectedPic = picSun;
                TodayDayOfWeek = SelectedSunday;
            }
            else if (DateTime.Today == SelectedMonday)
            {
                picMon.Controls.Clear();
                selectedPic = picMon;
                TodayDayOfWeek = SelectedMonday;
            }
            else if (DateTime.Today == SelectedTuesday)
            {
                picTue.Controls.Clear();
                selectedPic = picTue;
                TodayDayOfWeek = SelectedTuesday;
            }
            else if (DateTime.Today == SelectedWednesday)
            {
                picWed.Controls.Clear();
                selectedPic = picWed;
                TodayDayOfWeek = SelectedWednesday;
            }
            else if (DateTime.Today == SelectedThursday)
            {
                picThu.Controls.Clear();
                selectedPic = picThu;
                TodayDayOfWeek = SelectedThursday;
            }
            else if (DateTime.Today == SelectedFriday)
            {
                picFri.Controls.Clear();
                selectedPic = picFri;
                TodayDayOfWeek = SelectedFriday;
            }
            else if (DateTime.Today == SelectedSaturday)
            {
                picSat.Controls.Clear();
                selectedPic = picSat;
                TodayDayOfWeek = SelectedSaturday;
            }
            else
            {
                NeedRefresh = false;
            }
            if (NeedRefresh)
            {
                Draw.DrawEventController(selectedPic, TodayDayOfWeek);
                Draw.DrawLogController(selectedPic, TodayDayOfWeek);
            }
        }

        public void DrawLog()
        {
            plot Draw = new plot();
            picMon.Controls.Clear();
            picTue.Controls.Clear();
            picWed.Controls.Clear();
            picThu.Controls.Clear();
            picFri.Controls.Clear();
            picSat.Controls.Clear();
            picSun.Controls.Clear();
            Draw.DrawLogController(picMon, SelectedMonday);
            Draw.DrawLogController(picTue, SelectedTuesday);
            Draw.DrawLogController(picWed, SelectedWednesday);
            Draw.DrawLogController(picThu, SelectedThursday);
            Draw.DrawLogController(picFri, SelectedFriday);
            Draw.DrawLogController(picSat, SelectedSaturday);
            Draw.DrawLogController(picSun, SelectedSunday);
            Draw.DrawEventController(picMon, SelectedMonday);
            Draw.DrawEventController(picTue, SelectedTuesday);
            Draw.DrawEventController(picWed, SelectedWednesday);
            Draw.DrawEventController(picThu, SelectedThursday);
            Draw.DrawEventController(picFri, SelectedFriday);
            Draw.DrawEventController(picSat, SelectedSaturday);
            Draw.DrawEventController(picSun, SelectedSunday);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                List<CNote> notes = G.glb.lstNote.FindAll(o => o.Topic.ToUpper().Contains(txtSearch.Text.ToUpper()));
                List<CLiterature> lits = G.glb.lstLiterature.FindAll(o => o.Title.ToUpper().Contains(txtSearch.Text.ToUpper()));
                if (notes.Count == 0 && lits.Count == 0)
                {
                    MessageBox.Show("No record!");
                }
                else if (notes.Count + lits.Count == 1)
                {
                    if (notes.Count == 1)
                    {
                        if (M.notesOpened.Exists(o => o.GUID == notes[0].GUID))
                        {
                            M.notesOpened.Find(o => o.GUID == notes[0].GUID).Show();
                            M.notesOpened.Find(o => o.GUID == notes[0].GUID).BringToFront();
                        }
                        else
                        {
                            frmInfoNote frmInfoNote = new frmInfoNote(notes[0]);
                            M.notesOpened.Add(frmInfoNote);
                            frmInfoNote.Show();
                        }
                    }
                    else
                    {
                        if (M.notesOpened.Exists(o => o.GUID == lits[0].GUID))
                        {
                            M.notesOpened.Find(o => o.GUID == lits[0].GUID).Show();
                            M.notesOpened.Find(o => o.GUID == lits[0].GUID).BringToFront();
                        }
                        else
                        {
                            frmInfoNote frmInfoNote = new frmInfoNote(lits[0]);
                            M.notesOpened.Add(frmInfoNote);
                            frmInfoNote.Show();
                        }
                    }
                }
                else
                {
                    frmSearchNote frmSearchNote = new frmSearchNote(txtSearch.Text);
                    frmSearchNote.Show();
                }
            }
        }

        private void nfiMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void tsmToolNewNote_Click(object sender, EventArgs e)
        {
            string topic = Interaction.InputBox("Add new Note", "Add Note", "(New Note)", 300, 300);
            CNote newNote = new CNote();
            newNote.Topic = topic;
            newNote.TagTime = DateTime.Today;
            newNote.GUID = Guid.NewGuid().ToString();
            G.glb.lstNote.Add(newNote);

            frmInfoNote frmInfoNote = new frmInfoNote(newNote);
            frmInfoNote.Show();
        }

        private void tsmToolNewLiterature_Click(object sender, EventArgs e)
        {
            string strTitle = Interaction.InputBox("Input literature title", "Add Literature", "(New Literture)", 300, 300);
            if (G.glb.lstLiterature.Exists(o => o.Title == strTitle))
            {
                MessageBox.Show("Literature exists, please check!");
            }
            else
            {
                CLiterature newLit = new CLiterature();
                newLit.Title = strTitle;
                newLit.GUID = Guid.NewGuid().ToString();
                newLit.DateAdded = DateTime.Today;
                newLit.DateModified = DateTime.Today;
                newLit.Star = false;
                newLit.JournalOrConferenceName = "";
                newLit.PublishYear = 9999;
                G.glb.lstLiterature.Add(newLit);

                frmInfoNote frmInfoNote = new frmInfoNote(newLit);
                frmInfoNote.Show();
            }
        }

        private void findNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string search = Interaction.InputBox("Search for existing notes.", "Search Note", "", 300, 300);
            if (search != "")
            {
                List<CNote> notes = G.glb.lstNote.FindAll(o => o.Topic.ToUpper().Contains(search.ToUpper()));
                List<CLiterature> lits = G.glb.lstLiterature.FindAll(o => o.Title.ToUpper().Contains(search.ToUpper()));
                if (notes.Count == 0 && lits.Count == 0)
                {
                    MessageBox.Show("No record!");
                }
                else if (notes.Count + lits.Count == 1)
                {
                    if (notes.Count == 1)
                    {
                        if (M.notesOpened.Exists(o => o.GUID == notes[0].GUID))
                        {
                            M.notesOpened.Find(o => o.GUID == notes[0].GUID).Show();
                            M.notesOpened.Find(o => o.GUID == notes[0].GUID).BringToFront();
                        }
                        else
                        {
                            frmInfoNote frmInfoNote = new frmInfoNote(notes[0]);
                            M.notesOpened.Add(frmInfoNote);
                            frmInfoNote.Show();
                        }
                    }
                    else
                    {
                        if (M.notesOpened.Exists(o => o.GUID == lits[0].GUID))
                        {
                            M.notesOpened.Find(o => o.GUID == lits[0].GUID).Show();
                            M.notesOpened.Find(o => o.GUID == lits[0].GUID).BringToFront();
                        }
                        else
                        {
                            frmInfoNote frmInfoNote = new frmInfoNote(lits[0]);
                            M.notesOpened.Add(frmInfoNote);
                            frmInfoNote.Show();
                        }
                    }
                }
                else
                {
                    frmSearchNote frmSearchNote = new frmSearchNote(search);
                    frmSearchNote.Show();
                }
            }
        }

        private void OpenDiary(DateTime date)
        {
            if (!G.glb.lstDiary.Exists(o => o.Date == date))
            {
                CDiary diary = new CDiary();
                diary.Date = date;
                diary.GUID = Guid.NewGuid().ToString();
                G.glb.lstDiary.Add(diary);
            }

            CDiary d = G.glb.lstDiary.Find(o => o.Date == date);
            if (M.notesOpened.Exists(o => o.GUID == d.GUID))
            {
                M.notesOpened.Find(o => o.GUID == d.GUID).Show();
                M.notesOpened.Find(o => o.GUID == d.GUID).BringToFront();
            }
            else
            {
                frmInfoNote frmInfoNote = new frmInfoNote(d);
                M.notesOpened.Add(frmInfoNote);
                frmInfoNote.Show();
            }
        }

        private void tsmToday_Click(object sender, EventArgs e)
        {
            OpenDiary(DateTime.Today);
        }

        
    }
}
