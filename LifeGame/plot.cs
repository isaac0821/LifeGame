using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LifeGame
{
    public class plot
    {
        /// <summary>
        /// 返回Color格式的颜色 Done: 01/03/2019
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Color GetColor(string color)
        {
            Color ret = new Color();
            switch (color)
            {
                case "Red":
                    ret = Color.Red;
                    break;
                case "Orange":
                    ret = Color.Orange;
                    break;
                case "Yellow":
                    ret = Color.Yellow;
                    break;
                case "Green":
                    ret = Color.Green;
                    break;
                case "Blue":
                    ret = Color.Blue;
                    break;
                case "Cyan":
                    ret = Color.Cyan;
                    break;
                case "Purple":
                    ret = Color.Purple;
                    break;
                case "Brown":
                    ret = Color.Brown;
                    break;
                case "Gray":
                    ret = Color.LightGray;
                    break;
                default:
                    ret = Color.Black;
                    break;
            }
            return ret;
        }

        public Color RandomColor()
        {
            Random r = new Random();
            Color rndColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            return rndColor;
        }

        public void DrawPercentageBlocks(PictureBox picMap, string baseColor, List<double> lstAmount, List<string> lstDesc)
        {
            picMap.BackColor = Color.White;
            picMap.Controls.Clear();
            // Check percentage
            double totalAmount = 0;
            foreach (double amount in lstAmount)
            {
                totalAmount += amount;
            }
            List<double> lstPercentage = new List<double>();
            for (int i = 0; i < lstAmount.Count(); i++)
            {
                lstPercentage.Add(lstAmount[i] / totalAmount);
            }
            
            double accLeft = 0;
            List<Color> backgroundColorList = new List<Color>();
            if (baseColor == "r")
            {
                backgroundColorList.Add(Color.FromArgb(100, 0, 0));
                backgroundColorList.Add(Color.FromArgb(200, 0, 0));
            }
            else if (baseColor == "g")
            {
                backgroundColorList.Add(Color.FromArgb(0, 100, 0));
                backgroundColorList.Add(Color.FromArgb(0, 200, 0));
            }

            List<PictureBox> picPtgBlock = new List<PictureBox>();
            for (int i = 0; i < lstPercentage.Count(); i++)
            {
                picPtgBlock.Add(new PictureBox());
                picPtgBlock[i].Width = (int)(lstPercentage[i] * picMap.Width);
                picPtgBlock[i].Height = picMap.Height;
                picPtgBlock[i].Left = (int)accLeft;
                picPtgBlock[i].Top = 0;
                picPtgBlock[i].BackColor = backgroundColorList[i % 2];
                Label lblPtg = new Label();
                lblPtg.Text = Math.Round(lstPercentage[i] * 100, 2).ToString() + "%";
                lblPtg.ForeColor = Color.White;
                lblPtg.Height = 11;
                lblPtg.Top = 0;
                lblPtg.Left = 0;
                picPtgBlock[i].Controls.Add(lblPtg);
                Label lblDesc = new Label();
                lblDesc.Text = lstDesc[i];
                lblDesc.ForeColor = Color.White;
                lblDesc.Top = lblPtg.Height;
                lblDesc.Height = 11;
                lblDesc.Left = 0;
                lblDesc.Width = picPtgBlock[i].Width;
                Label lblAmount = new Label();
                lblAmount.Text = Math.Round(lstAmount[i], 2).ToString();
                lblAmount.ForeColor = Color.White;
                lblAmount.Top = lblDesc.Top + lblDesc.Height;
                lblAmount.Left = 0;
                lblAmount.Width = picPtgBlock[i].Width;
                picPtgBlock[i].Controls.Add(lblAmount);
                picPtgBlock[i].Controls.Add(lblDesc);
                picPtgBlock[i].Controls.Add(lblAmount);
                picMap.Controls.Add(picPtgBlock[i]);
                accLeft += (int)(lstPercentage[i] * picMap.Width);
            }
        }


        /// <summary>
        /// 绘制计划图或日志图 Done: 01/03/2019
        /// </summary>
        /// <param name="picMap">画布</param>
        /// <param name="date">日期</param>
        /// <param name="logs">日志</param>
        /// <param name="healths">健康日志</param>
        /// <param name="IsLabelShown">是否显示标签</param>
        /// <param name="LocationMode">位置模式："all" - 全部; "left" - 左侧; "right" - 右侧</param>
        public void DrawScheduleAndLogController(PictureBox picMap, DateTime date, List<CLog> logs, List<CSleep> healths, string LocationMode)
        {
            int left = 0;
            int width = picMap.Width;
            if (LocationMode == "all")
            {
                left = 0;
                width = picMap.Width;
            }
            else if (LocationMode == "left")
            {
                left = 0;
                width = picMap.Width / 2;
            }
            else if (LocationMode == "right")
            {
                left = picMap.Width / 2;
                width = picMap.Width / 2;
            }
            else if (LocationMode == "allWithSupp")
            {
                left = 0;
                width = (picMap.Width = 30) > 0 ? picMap.Width - 30 : 0;
            }
            else if (LocationMode == "leftWithSupp")
            {
                left = 0;
                width = (picMap.Width - 30) > 0 ? (picMap.Width - 30) / 2 : 0;
            }
            else if (LocationMode == "rightWithSupp")
            {
                left = (picMap.Width - 30) > 0 ? (picMap.Width - 30) / 2 : 0;
                width = (picMap.Width - 30) > 0 ? (picMap.Width - 30) / 2 : 0;
            }
            int height = picMap.Height;
            PictureBox picTimePointer = new PictureBox();
            PictureBox picToday = new PictureBox();
            Label lblNow = new Label();
            if (date < DateTime.Today.Date)
            {
                picMap.BackColor = Color.FromArgb(19, 92, 08, 21);
            }
            else if (date == DateTime.Today.Date)
            {
                picMap.BackColor = Color.FromArgb(19, 92, 08, 21);
            }
            else
            {
                picMap.BackColor = Color.White;
            }
            if (date == DateTime.Today.Date)
            {
                picTimePointer.Width = picMap.Width;
                picTimePointer.Height = 2;
                picTimePointer.Left = 0;
                picTimePointer.Top = (int)(height * DateTime.Now.TimeOfDay.TotalMinutes / (24 * 60));
                picTimePointer.BackColor = Color.DarkRed;
                picMap.Controls.Add(picTimePointer);
                lblNow.Text = DateTime.Now.ToShortTimeString();
                lblNow.Top = (int)(height * DateTime.Now.TimeOfDay.TotalMinutes / (24 * 60)) - 14;
                lblNow.Left = picMap.Width - 50;
                lblNow.Height = 14;
                lblNow.BringToFront();
                lblNow.BackColor = Color.DarkRed;
                lblNow.ForeColor = Color.White;
                picMap.Controls.Add(lblNow);
            }

            List<CLog> todayLogs = logs.FindAll(o => o.StartTime.Date == date).ToList();
            List<CLog> yesterdayLogs = logs.FindAll(o => o.StartTime.Date == date.AddDays(-1) && o.EndTime.Date == date).ToList();
            CSleep todaySleep = healths.Find(o => o.Date == date);
            CSleep tomorrowSleep = healths.Find(o => o.Date == date.AddDays(1));

            PictureBox picSleep = new PictureBox();
            Label lblSleep = new Label();
            if (healths.Exists(o => o.Date == date))
            {
                double start;
                if (todaySleep.IsGoToBedBeforeMidNight)
                {
                    start = 0;
                }
                else
                {
                    start = (todaySleep.GoToBedTime.Hour + todaySleep.GoToBedTime.Minute / 60d) / 24d * height;
                }
                double end = (todaySleep.GetUpTime.Hour + todaySleep.GetUpTime.Minute / 60d) / 24d * height;
                double totalHour = (todaySleep.GetUpTime - todaySleep.GoToBedTime).TotalHours;
                totalHour = Math.Round(totalHour, 2);
                string SleepTime = (todaySleep.IsGoToBedBeforeMidNight ? "(-1d)" : "") + todaySleep.GoToBedTime.ToShortTimeString() + " - " + todaySleep.GetUpTime.ToShortTimeString() + " [" + totalHour.ToString() + "h]";
                picSleep.Width = width;
                picSleep.Height = (int)(end - start);
                picSleep.Left = left;
                picSleep.Top = (int)start;
                picSleep.BackColor = Color.LightBlue;
                picMap.Controls.Add(picSleep);
                lblSleep.Text = SleepTime + "\n" + "Sleep";
                lblSleep.Dock = DockStyle.Fill;
                lblSleep.Click += (e, a) => CallInfoLog(SleepTime, "Sleep", "", "", picSleep.BackColor, false);
                picSleep.Controls.Add(lblSleep);
            }

            PictureBox picSleepYesterday = new PictureBox();
            Label lblSleepYesterday = new Label();
            if (healths.Exists(o => o.Date == date.AddDays(1)))
            {
                if (tomorrowSleep.IsGoToBedBeforeMidNight)
                {
                    double start = (tomorrowSleep.GoToBedTime.Hour + tomorrowSleep.GoToBedTime.Minute / 60d) / 24d * height;
                    double end = height;
                    double totalHour = (tomorrowSleep.GetUpTime - tomorrowSleep.GoToBedTime).TotalHours;
                    totalHour = Math.Round(totalHour, 2);
                    string SleepTime = tomorrowSleep.GoToBedTime.ToShortTimeString() + " - " + tomorrowSleep.GetUpTime.ToShortTimeString() + "(+1d)" + " [" + totalHour.ToString() + "h]";
                    picSleepYesterday.Width = width;
                    picSleepYesterday.Height = (int)(end - start);
                    picSleepYesterday.Left = left;
                    picSleepYesterday.Top = (int)start;
                    picSleepYesterday.BackColor = Color.LightBlue;
                    picMap.Controls.Add(picSleepYesterday);
                    lblSleepYesterday.Text = SleepTime + "\n" + "Sleep";
                    lblSleepYesterday.Dock = DockStyle.Fill;
                    lblSleepYesterday.Click += (e, a) => CallInfoLog("", "Sleep", "", "", picSleepYesterday.BackColor, false);
                    picSleepYesterday.Controls.Add(lblSleepYesterday);
                }
            }

            List<PictureBox> lstPicLog = new List<PictureBox>();
            List<Label> lstLblLog = new List<Label>();
            for (int i = 0; i < yesterdayLogs.Count; i++)
            {
                lstPicLog.Add(new PictureBox());
                lstLblLog.Add(new Label());
                double start = 0;
                double end = (yesterdayLogs[i].EndTime.Hour + yesterdayLogs[i].EndTime.Minute / 60d) / 24d * height;
                double totalHour = (yesterdayLogs[i].EndTime - yesterdayLogs[i].StartTime).TotalHours;
                totalHour = Math.Round(totalHour, 2);
                string TimePeriod = yesterdayLogs[i].StartTime.ToShortTimeString() + "(-1d)" + " - " + yesterdayLogs[i].EndTime.ToShortTimeString() + " [" + totalHour.ToString() + "h]";
                string LogName = yesterdayLogs[i].LogName;
                string Location = yesterdayLogs[i].Location;
                string WithWho = yesterdayLogs[i].WithWho;
                // string TaskName = yesterdayLogs[i].ContributionToTask;
                bool IsAlarm = yesterdayLogs[i].Alarm;
                Color backColor = GetColor(yesterdayLogs[i].Color);
                lstPicLog[i].Width = width;
                lstPicLog[i].Height = (int)(end - start);
                lstPicLog[i].Left = left;
                lstPicLog[i].Top = (int)start;
                lstPicLog[i].BackColor = backColor;
                picMap.Controls.Add(lstPicLog[i]);
                lstLblLog[i].Text = TimePeriod + "\n" + LogName + "\n" + Location + "\n" + WithWho;
                lstLblLog[i].Dock = DockStyle.Fill;
                lstLblLog[i].ForeColor = Color.FromArgb(255 - backColor.R, 255 - backColor.G, 255 - backColor.B);
                lstLblLog[i].Click += (e, a) => CallInfoLog(TimePeriod, LogName, Location, WithWho, backColor, IsAlarm);
                lstPicLog[i].Controls.Add(lstLblLog[i]);
            }

            for (int i = 0; i < todayLogs.Count; i++)
            {
                lstPicLog.Add(new PictureBox());
                lstLblLog.Add(new Label());
                double start = (todayLogs[i].StartTime.Hour + todayLogs[i].StartTime.Minute / 60d) / 24d * height;
                double end;
                double totalHour = (todayLogs[i].EndTime - todayLogs[i].StartTime).TotalHours;
                totalHour = Math.Round(totalHour, 2);
                string TimePeriod;
                if (todayLogs[i].EndTime.Date == date)
                {
                    end = (todayLogs[i].EndTime.Hour + todayLogs[i].EndTime.Minute / 60d) / 24d * height;
                    TimePeriod = todayLogs[i].StartTime.ToShortTimeString() + " - " + todayLogs[i].EndTime.ToShortTimeString() + " [" + totalHour.ToString() + "h]";
                }
                else
                {
                    end = height;
                    TimePeriod = todayLogs[i].StartTime.ToShortTimeString() + " - " + todayLogs[i].EndTime.ToShortTimeString() + "(+1d)" + " [" + totalHour.ToString() + "h]";
                }
                string LogName = todayLogs[i].LogName;
                string Location = todayLogs[i].Location;
                string WithWho = todayLogs[i].WithWho;
                // string TaskName = todayLogs[i].ContributionToTask;
                bool IsAlarm = todayLogs[i].Alarm;
                Color backColor = GetColor(todayLogs[i].Color);
                lstPicLog[i + yesterdayLogs.Count].Width = width;
                lstPicLog[i + yesterdayLogs.Count].Height = (int)(end - start);
                lstPicLog[i + yesterdayLogs.Count].Left = left;
                lstPicLog[i + yesterdayLogs.Count].Top = (int)start;
                lstPicLog[i + yesterdayLogs.Count].BackColor = backColor;
                picMap.Controls.Add(lstPicLog[i + yesterdayLogs.Count]);
                lstLblLog[i + yesterdayLogs.Count].Text = TimePeriod + "\n" + LogName + "\n" + Location + "\n" + WithWho;
                lstLblLog[i + yesterdayLogs.Count].Dock = DockStyle.Fill;
                lstLblLog[i + yesterdayLogs.Count].ForeColor = Color.FromArgb(255 - backColor.R, 255 - backColor.G, 255 - backColor.B);
                lstLblLog[i + yesterdayLogs.Count].Click += (e, a) => CallInfoLog(TimePeriod, LogName, Location, WithWho, backColor, IsAlarm);
                lstPicLog[i + yesterdayLogs.Count].Controls.Add(lstLblLog[i + yesterdayLogs.Count]);
            }

            if (date == DateTime.Today.Date)
            {
                picToday.Width = picMap.Width;
                picToday.Height = (int)(height - height * DateTime.Now.TimeOfDay.TotalMinutes / (24 * 60));
                picToday.Left = 0;
                picToday.Top = (int)(height * DateTime.Now.TimeOfDay.TotalMinutes / (24 * 60));
                picToday.BackColor = Color.White;
                picMap.Controls.Add(picToday);
            }
        }

        public void DrawEventController(
            PictureBox picMap,
            DateTime date,
            List<CEvent> events,
            List<CTransaction> transactions,
            List<CTransaction> budgets,
            List<CNote> notes)
        {
            int left = picMap.Width - 27 > 0 ? picMap.Width - 27 : 0;
            List<PictureBox> lstPicEvent = new List<PictureBox>();
            List<CEvent> lstEvent = events.FindAll(o => o.TagTime.Date == date).ToList();
            List<CTransaction> lstTransaction = transactions.FindAll(o => o.TagTime.Date == date).ToList();
            List<CTransaction> lstBudget = budgets.FindAll(o => o.TagTime.Date == date).ToList();
            List<CNote> lstNote = notes.FindAll(o => o.TagTime.Date == date).ToList();
            int acc = 0;
            for (int i = 0; i < lstEvent.Count; i++)
            {
                lstPicEvent.Add(new PictureBox());
                CEvent eve = lstEvent[i];
                if (lstEvent[i].EventState == EEventState.LogEvent)
                {
                    lstPicEvent[i].Image = icon.iconEvent;
                }
                else if (lstEvent[i].EventState == EEventState.Succeed)
                {
                    lstPicEvent[i].Image = icon.iconSucceedEvent;
                }
                else
                {
                    lstPicEvent[i].Image = icon.iconFailedEvent;
                }
                lstPicEvent[i].Top = i * 30 + 3;
                lstPicEvent[i].Left = left;
                lstPicEvent[i].Width = 24;
                lstPicEvent[i].Height = 24;
                lstPicEvent[i].Click += (e, a) => CallInfoEvent(eve);
                picMap.Controls.Add(lstPicEvent[i]);
            }
            acc = acc + lstEvent.Count;
            for (int i = 0; i < lstTransaction.Count; i++)
            {
                lstPicEvent.Add(new PictureBox());
                CTransaction transaction = lstTransaction[i];
                EMoneyFlowState MoneyFlowState = lstTransaction[i].IconType;
                switch (MoneyFlowState)
                {
                    case EMoneyFlowState.WithinSystem:
                        lstPicEvent[i + acc].Image = icon.iconMoneyWithin;
                        break;
                    case EMoneyFlowState.FlowIn:
                        lstPicEvent[i + acc].Image = icon.iconMoneyIn;
                        break;
                    case EMoneyFlowState.FlowOut:
                        lstPicEvent[i + acc].Image = icon.iconMoneyOut;
                        break;
                    default:
                        break;
                }
                lstPicEvent[i + acc].Top = (i + acc) * 30 + 3;
                lstPicEvent[i + acc].Left = left;
                lstPicEvent[i + acc].Width = 24;
                lstPicEvent[i + acc].Height = 24;
                lstPicEvent[i + acc].Click += (e, a) => CallInfoTransaction(transaction);
                picMap.Controls.Add(lstPicEvent[i + acc]);
            }
            acc = acc + lstTransaction.Count;
            for (int i = 0; i < lstBudget.Count; i++)
            {
                lstPicEvent.Add(new PictureBox());
                CTransaction transactionDue = lstBudget[i];
                EMoneyFlowState MoneyFlowState = lstBudget[i].IconType;
                switch (MoneyFlowState)
                {
                    case EMoneyFlowState.WithinSystem:
                        lstPicEvent[i + acc].Image = icon.iconTransactionDueWithin;
                        break;
                    case EMoneyFlowState.FlowIn:
                        lstPicEvent[i + acc].Image = icon.iconTransactionDueIn;
                        break;
                    case EMoneyFlowState.FlowOut:
                        lstPicEvent[i + acc].Image = icon.iconTransactionDueOut;
                        break;
                    default:
                        break;
                }
                lstPicEvent[i + acc].Top = (i + acc) * 30 + 3;
                lstPicEvent[i + acc].Left = left;
                lstPicEvent[i + acc].Width = 24;
                lstPicEvent[i + acc].Height = 24;
                lstPicEvent[i + acc].Click += (e, a) => CallInfoBudget(transactionDue);
                picMap.Controls.Add(lstPicEvent[i + acc]);
            }
            acc = acc + lstBudget.Count;
            for (int i = 0; i < lstNote.Count; i++)
            {
                lstPicEvent.Add(new PictureBox());
                CNote note = lstNote[i];
                if (lstNote[i].Topic == "Daily Report")
                {
                    lstPicEvent[i + acc].Image = icon.iconDaily;
                }
                else if (lstNote[i].LiteratureTitle != "")
                {
                    lstPicEvent[i + acc].Image = icon.iconLiterature;
                }
                else
                {
                    if (lstNote[i].FinishedNote)
                    {
                        lstPicEvent[i + acc].Image = icon.iconNote;
                    }
                    else
                    {
                        lstPicEvent[i + acc].Image = icon.iconWorkingNote;
                    }
                }
                lstPicEvent[i + acc].Top = (i + acc) * 30 + 3;
                lstPicEvent[i + acc].Left = left;
                lstPicEvent[i + acc].Width = 24;
                lstPicEvent[i + acc].Height = 24;
                lstPicEvent[i + acc].Click += (e, a) => CallInfoNote(note);
                picMap.Controls.Add(lstPicEvent[i + acc]);
            }
            acc = acc + lstNote.Count;
        }

        public void CallInfoLog(string Timeperiod, string LogName, string Location, string WithWho, Color color, bool IsAlarm)
        {
            frmInfoLog frmInfoLog = new frmInfoLog(Timeperiod, LogName, Location, WithWho, color, IsAlarm);
            frmInfoLog.ShowDialog();
        }


        public void CallInfoEvent(CEvent info)
        {
            frmInfoEvent frmInfoEvent = new frmInfoEvent(info);
            frmInfoEvent.Show();
        }

        public void CallInfoNote(CNote info)
        {
            //frmInfoNote frmInfoNote = new frmInfoNote(info);
            //frmInfoNote.Show();


            if (M.notesOpened.Exists(o => o.note.Topic == info.Topic && o.note.TagTime == info.TagTime.Date))
            {
                M.notesOpened.Find(o => o.note.Topic == info.Topic && o.note.TagTime == info.TagTime.Date).Show();
                M.notesOpened.Find(o => o.note.Topic == info.Topic && o.note.TagTime == info.TagTime.Date).BringToFront();
            }
            else
            {
                if (info.LiteratureTitle == "" || info.LiteratureTitle == null)
                {
                    frmInfoNote frmInfoNote = new frmInfoNote(info);
                    M.notesOpened.Add(frmInfoNote);
                    frmInfoNote.Show();
                }
                else
                {
                    frmInfoNote frmInfoNote = new frmInfoNote(G.glb.lstLiterature.Find(o => o.Title == info.LiteratureTitle));
                    M.notesOpened.Add(frmInfoNote);
                    frmInfoNote.Show();
                }
            }
        }

        public void CallInfoTransaction(CTransaction info)
        {
            frmInfoTransaction frmInfoTransaction = new frmInfoTransaction(info);
            frmInfoTransaction.Show();
        }

        public void CallInfoBudget (CTransaction info)
        {
            frmInfoTransaction frmInfoBudget = new frmInfoTransaction(info);
            frmInfoBudget.Show();
        }

    }
}
