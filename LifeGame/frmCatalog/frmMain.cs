﻿using System;
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

                //foreach (CLiterature item in G.glb.lstLiterature)
                //{
                //    if (!G.glb.lstNote.Exists(o => o.LiteratureTitle == item.Title))
                //    {
                //        string topicGUID = Guid.NewGuid().ToString();
                //        CNote note = new CNote();
                //        note.LiteratureTitle = item.Title;
                //        note.TagTime = item.DateAdded.Date;
                //        note.GUID = topicGUID;
                //        note.Topic = item.Title;
                //        G.glb.lstNote.Add(note);

                //        RNoteLog QA = new RNoteLog();
                //        QA.Topic = item.Title;
                //        QA.TopicGUID = topicGUID;
                //        QA.Log = item.Title;
                //        QA.GUID = topicGUID;
                //        QA.SubLog = "Q&A";
                //        QA.SubGUID = Guid.NewGuid().ToString();
                //        QA.TagTime = item.DateAdded.Date;
                //        QA.Index = 0;
                //        G.glb.lstNoteLog.Add(QA);

                //        RNoteLog keyTakeaway = new RNoteLog();
                //        keyTakeaway.Topic = item.Title;
                //        keyTakeaway.TopicGUID = topicGUID;
                //        keyTakeaway.Log = item.Title;
                //        keyTakeaway.GUID = topicGUID;
                //        keyTakeaway.SubLog = "key take-away";
                //        keyTakeaway.SubGUID = Guid.NewGuid().ToString();
                //        keyTakeaway.TagTime = item.DateAdded.Date;
                //        keyTakeaway.Index = 1;
                //        G.glb.lstNoteLog.Add(keyTakeaway);
                //    }
                //}
            }
            catch (Exception)
            {
                MessageBox.Show("Can not find an existing data file, a new empty data file is auto-created");
                // Event
                G.glb.lstEvent = new List<CEvent>();
                G.glb.lstSleepSchedule = new List<CSleep>();
                G.glb.lstSleepLog = new List<CSleep>();

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
                G.glb.lstAccount[0].Currency = "USD";
                G.glb.lstAccount[0].ProtectedAccount = true;
                G.glb.lstAccount[1].AccountName = "(Gain/Loss on Exchange)";
                G.glb.lstAccount[1].AccountType = EAccountType.Assets;
                G.glb.lstAccount[1].Currency = "USD";
                G.glb.lstAccount[1].ProtectedAccount = true;
                G.glb.lstAccount[2].AccountName = "(Expense)";
                G.glb.lstAccount[2].AccountType = EAccountType.Expense;
                G.glb.lstAccount[2].Currency = "USD";
                G.glb.lstAccount[2].ProtectedAccount = true;
                G.glb.lstAccount[3].AccountName = "(Equity)";
                G.glb.lstAccount[3].AccountType = EAccountType.Equity;
                G.glb.lstAccount[3].Currency = "USD";
                G.glb.lstAccount[3].ProtectedAccount = true;
                G.glb.lstAccount[4].AccountName = "(Openning Balance)";
                G.glb.lstAccount[4].AccountType = EAccountType.Equity;
                G.glb.lstAccount[4].Currency = "USD";
                G.glb.lstAccount[4].ProtectedAccount = true;
                G.glb.lstAccount[5].AccountName = "(Liability)";
                G.glb.lstAccount[5].AccountType = EAccountType.Liability;
                G.glb.lstAccount[5].Currency = "USD";
                G.glb.lstAccount[5].ProtectedAccount = true;
                G.glb.lstAccount[6].AccountName = "(Income)";
                G.glb.lstAccount[6].AccountType = EAccountType.Income;
                G.glb.lstAccount[6].Currency = "USD";
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
                G.glb.lstSubAccount[0].index = 0;
                G.glb.lstSubAccount[1].Account = "(Root)";
                G.glb.lstSubAccount[1].SubAccount = "(Expense)";
                G.glb.lstSubAccount[1].index = 1;
                G.glb.lstSubAccount[2].Account = "(Root)";
                G.glb.lstSubAccount[2].SubAccount = "(Equity)";
                G.glb.lstSubAccount[2].index = 2;
                G.glb.lstSubAccount[3].Account = "(Root)";
                G.glb.lstSubAccount[3].SubAccount = "(Liability)";
                G.glb.lstSubAccount[3].index = 3;
                G.glb.lstSubAccount[4].Account = "(Root)";
                G.glb.lstSubAccount[4].SubAccount = "(Income)";
                G.glb.lstSubAccount[4].index = 4;
                G.glb.lstSubAccount[5].Account = "(Assets)";
                G.glb.lstSubAccount[5].SubAccount = "(Gain/Loss on Exchange)";
                G.glb.lstSubAccount[5].index = 0;
                G.glb.lstSubAccount[6].Account = "(Equity)";
                G.glb.lstSubAccount[6].SubAccount = "(Openning Balance)";
                G.glb.lstSubAccount[6].index = 0;
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
                if (chkShowSchedule.Checked && chkShowLog.Checked & chkMine.Checked)
                {
                    Draw.DrawEventController(selectedPic, TodayDayOfWeek, G.glb.lstEvent, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
                    Draw.DrawScheduleAndLogController(selectedPic, TodayDayOfWeek, G.glb.lstSchedule, G.glb.lstSleepSchedule, "leftWithSupp");
                    Draw.DrawScheduleAndLogController(selectedPic, TodayDayOfWeek, G.glb.lstLog, G.glb.lstSleepLog, "rightWithSupp");
                }
                else if (chkShowSchedule.Checked && chkShowLog.Checked & !chkMine.Checked)
                {
                    Draw.DrawScheduleAndLogController(selectedPic, TodayDayOfWeek, G.glb.lstSchedule, G.glb.lstSleepSchedule, "left");
                    Draw.DrawScheduleAndLogController(selectedPic, TodayDayOfWeek, G.glb.lstLog, G.glb.lstSleepLog, "right");
                }
                else if (chkShowSchedule.Checked && !chkShowLog.Checked & chkMine.Checked)
                {
                    Draw.DrawEventController(selectedPic, TodayDayOfWeek, G.glb.lstEvent, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
                    Draw.DrawScheduleAndLogController(selectedPic, TodayDayOfWeek, G.glb.lstSchedule, G.glb.lstSleepSchedule, "allWithSupp");
                }
                else if (chkShowSchedule.Checked && !chkShowLog.Checked & !chkMine.Checked)
                {
                    Draw.DrawScheduleAndLogController(selectedPic, TodayDayOfWeek, G.glb.lstSchedule, G.glb.lstSleepSchedule, "all");
                }
                else if (!chkShowSchedule.Checked && chkShowLog.Checked & chkMine.Checked)
                {
                    Draw.DrawEventController(selectedPic, TodayDayOfWeek, G.glb.lstEvent, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
                    Draw.DrawScheduleAndLogController(selectedPic, TodayDayOfWeek, G.glb.lstLog, G.glb.lstSleepLog, "allWithSupp");
                }
                else if (!chkShowSchedule.Checked && chkShowLog.Checked & !chkMine.Checked)
                {
                    Draw.DrawScheduleAndLogController(selectedPic, TodayDayOfWeek, G.glb.lstLog, G.glb.lstSleepLog, "all");
                }
                else if (!chkShowSchedule.Checked && !chkShowLog.Checked & chkMine.Checked)
                {
                    Draw.DrawEventController(selectedPic, TodayDayOfWeek, G.glb.lstEvent, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
                }
                else if (!chkShowSchedule.Checked && !chkShowLog.Checked & !chkMine.Checked)
                {

                }
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

            if (chkShowSchedule.Checked && chkShowLog.Checked & chkMine.Checked)
            {
                DrawEvent();
                DrawScheduleWithMode("leftWithSupp");
                DrawLogWithMode("rightWithSupp");
            }
            else if (chkShowSchedule.Checked && chkShowLog.Checked & !chkMine.Checked)
            {
                DrawScheduleWithMode("left");
                DrawLogWithMode("right");
            }
            else if (chkShowSchedule.Checked && !chkShowLog.Checked & chkMine.Checked)
            {
                DrawEvent();
                DrawScheduleWithMode("allWithSupp");
            }
            else if (chkShowSchedule.Checked && !chkShowLog.Checked & !chkMine.Checked)
            {
                DrawScheduleWithMode("all");
            }
            else if (!chkShowSchedule.Checked && chkShowLog.Checked & chkMine.Checked)
            {
                DrawEvent();
                DrawLogWithMode("allWithSupp");
            }
            else if (!chkShowSchedule.Checked && chkShowLog.Checked & !chkMine.Checked)
            {
                DrawLogWithMode("all");
            }
            else if (!chkShowSchedule.Checked && !chkShowLog.Checked & chkMine.Checked)
            {
                DrawEvent();
            }
            else if (!chkShowSchedule.Checked && !chkShowLog.Checked & !chkMine.Checked)
            {

            }
        }
        private void DrawLogWithMode(string Mode)
        {
            plot Draw = new plot();
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
            plot Draw = new plot();
            Draw.DrawScheduleAndLogController(picMon, SelectedMonday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picTue, SelectedTuesday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picWed, SelectedWednesday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picThu, SelectedThursday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picFri, SelectedFriday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picSat, SelectedSaturday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picSun, SelectedSunday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
        }
        private void DrawEvent()
        {
            plot Draw = new plot();
            Draw.DrawEventController(picMon, SelectedMonday, G.glb.lstEvent, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
            Draw.DrawEventController(picTue, SelectedTuesday, G.glb.lstEvent, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
            Draw.DrawEventController(picWed, SelectedWednesday, G.glb.lstEvent, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
            Draw.DrawEventController(picThu, SelectedThursday, G.glb.lstEvent, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
            Draw.DrawEventController(picFri, SelectedFriday, G.glb.lstEvent, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
            Draw.DrawEventController(picSat, SelectedSaturday, G.glb.lstEvent, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
            Draw.DrawEventController(picSun, SelectedSunday, G.glb.lstEvent, G.glb.lstTransaction, G.glb.lstBudget, G.glb.lstNote);
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

        private void surveyVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSurvey frmSurvey = new frmSurvey();
            frmSurvey.Show();
        }

        private void addDailyToolStripMenuItem_Click(object sender, EventArgs e)
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
            frmInfoNote frmInfoNote = new frmInfoNote(sendToFrm, true);
            frmInfoNote.DrawLog += new frmInfoNote.DrawLogHandler(DrawLog);
            frmInfoNote.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchNote.Text.Length > 0)
            {
                List<CNote> notes = G.glb.lstNote.FindAll(o => o.Topic.ToUpper().Contains(txtSearchNote.Text.ToUpper()));
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
                    frmSearchNote frmSearchNote = new frmSearchNote(txtSearchNote.Text);
                    frmSearchNote.Show();
                }                
            }
        }

        private void tsmAddBatchLiterature_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Please select a .txt file.";
            openFileDialog.Filter = "Text files (*.txt)|*.txt";

            string openFilePath;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openFilePath = openFileDialog.FileName;
                string[] logList = System.IO.File.ReadAllLines(openFilePath);
                int succeedNum = 0;
                for (int i = 0; i < logList.Length; i++)
                {
                    try
                    {
                        string[] sp = logList[i].Split(';');
                        string authors = sp[0].Trim();
                        string literature = sp[1].Trim();
                        string journal = sp[2].Trim();
                        int year = Convert.ToInt32(sp[3].Trim());
                        string bibType = sp[4].Trim().Trim('[').Trim(']');

                        if (!G.glb.lstLiterature.Exists(o => o.Title == literature))
                        {

                            CLiterature newLiterature = new CLiterature();
                            newLiterature.Title = literature;
                            newLiterature.PublishYear = year;
                            newLiterature.JournalOrConferenceName = journal;
                            newLiterature.InOneSentence = "";
                            newLiterature.DateAdded = DateTime.Today;
                            newLiterature.DateModified = DateTime.Today;
                            newLiterature.Star = false;

                            if (G.glb.lstBadJournal.Contains(journal))
                            {
                                newLiterature.PredatoryAlert = true;
                            }
                            else
                            {
                                newLiterature.PredatoryAlert = false;
                            }

                            string[] authorList = authors.Split(',');
                            List<RLiteratureAuthor> newLiteratureAuthors = new List<RLiteratureAuthor>();
                            for (int au = 0; au < authorList.Length; au++)
                            {
                                RLiteratureAuthor newAuthor = new RLiteratureAuthor();
                                newAuthor.Title = literature;
                                newAuthor.Author = authorList[au].Trim();
                                newAuthor.Rank = au;
                                newLiteratureAuthors.Add(newAuthor);
                            }
                            string[] firstAuthor = authorList[0].Split(' ');
                            string firstAuthorLastName = firstAuthor[firstAuthor.Length - 1].Trim();
                            newLiterature.BibKey = firstAuthorLastName + year.ToString();

                            CBibTeX literatureBib = new CBibTeX();
                            if (bibType == "C")
                            {
                                literatureBib.BibEntry = EBibEntry.Conference;
                                literatureBib.Booktitle = journal;
                            }
                            else if (bibType == "J")
                            {
                                literatureBib.BibEntry = EBibEntry.Article;
                                literatureBib.Journal = journal;
                            }
                            else if (bibType == "D")
                            {
                                literatureBib.BibEntry = EBibEntry.Phdthesis;
                                literatureBib.Booktitle = journal;
                            }
                            else
                            {
                                literatureBib.BibEntry = EBibEntry.Unpublished;
                                literatureBib.Note = journal;
                            }
                            literatureBib.BibKey = firstAuthorLastName + year.ToString();
                            literatureBib.Title = literature;
                            
                            literatureBib.Year = year.ToString();
                            ParseBibTeX ParseBib = new ParseBibTeX();
                            literatureBib.Author = ParseBib.GetAuthor(newLiteratureAuthors);
                            newLiterature.BibTeX = literatureBib;

                            RLiteratureTag newLiteratureTag = new RLiteratureTag();
                            newLiteratureTag.Title = literature;
                            newLiteratureTag.Tag = "(Root)";

                            G.glb.lstLiterature.Add(newLiterature);
                            G.glb.lstLiteratureAuthor.AddRange(newLiteratureAuthors);
                            G.glb.lstLiteratureTag.Add(newLiteratureTag);
                            succeedNum += 1;
                        }
                        else
                        {
                            MessageBox.Show("Failed: " + logList[i] + " exists!");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Failed: " + logList[i] + " is illegal!");
                    }
                }
                if (succeedNum > 0)
                {
                    MessageBox.Show("In total " + succeedNum.ToString() + " literature added.");
                }
            }
        }

        private void tsmAddBatchTransactions_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Please select a .txt file.";
            openFileDialog.Filter = "Text files (*.txt)|*.txt";

            string openFilePath;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openFilePath = openFileDialog.FileName;
                string[] logList = System.IO.File.ReadAllLines(openFilePath);
                int succeedNum = 0;
                for (int i = 0; i < logList.Length; i++)
                {
                    try
                    {
                        string[] sp = logList[i].Split(';');
                        string dateStr = sp[0].Trim();
                        string recordStr = sp[1].Trim();
                        double number = Convert.ToDouble(sp[2].Trim());
                        string creditAcc = sp[3].Trim();
                        string debitAcc = sp[4].Trim();

                        CTransaction tmpTransaction = new CTransaction();
                        tmpTransaction.CreditAccount = creditAcc;
                        tmpTransaction.CreditCurrency = "RMB";
                        tmpTransaction.CreditAmount = number;
                        tmpTransaction.DebitAccount = debitAcc;
                        tmpTransaction.DebitCurrency = "RMB";
                        tmpTransaction.DebitAmount = number;
                        tmpTransaction.Summary = recordStr;
                        tmpTransaction.TagTime = DateTime.Parse(dateStr).Date;
                        calculate C = new calculate();
                        tmpTransaction.IconType = C.MoneyInOrOut(
                            G.glb.lstAccount.Find(o => o.AccountName == debitAcc).AccountType,
                            G.glb.lstAccount.Find(o => o.AccountName == creditAcc).AccountType);

                        if (!G.glb.lstTransaction.Exists(o => o.TagTime == tmpTransaction.TagTime
                            && o.CreditAccount == tmpTransaction.CreditAccount
                            && o.CreditCurrency == tmpTransaction.CreditCurrency
                            && o.CreditAmount == tmpTransaction.CreditAmount
                            && o.DebitAccount == tmpTransaction.DebitAccount
                            && o.DebitCurrency == tmpTransaction.DebitCurrency
                            && o.DebitAmount == tmpTransaction.DebitAmount
                            && o.Summary == tmpTransaction.Summary
                            && o.IconType == tmpTransaction.IconType))
                        {
                            // 添加对应的Transaction记录
                            G.glb.lstTransaction.Add(tmpTransaction);

                            // 在Daily Report里添加记录


                        }
                        else
                        {
                            MessageBox.Show("Failed: " + logList[i] + " exists!");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Failed: " + logList[i] + " is illegal!");
                    }
                }
                if (succeedNum > 0)
                {
                    MessageBox.Show("Intotal " + succeedNum.ToString() + " transaction record added."); 
                }
            }
        }
    }
}
