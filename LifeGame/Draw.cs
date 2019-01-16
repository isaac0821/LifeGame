using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LifeGame
{
    public class Draw
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
                default:
                    ret = Color.Black;
                    break;
            }
            return ret;
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
            picMap.BackColor = Color.White;

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
                string SleepTime = (todaySleep.IsGoToBedBeforeMidNight ? "(-1d)" : "") + todaySleep.GoToBedTime.ToShortTimeString() + " - " + todaySleep.GetUpTime.ToShortTimeString();
                picSleep.Width = width;
                picSleep.Height = (int)(end - start);
                picSleep.Left = left;
                picSleep.Top = (int)start;
                picSleep.BackColor = Color.LightBlue;
                picMap.Controls.Add(picSleep);
                lblSleep.Text = SleepTime + "\n" + "Sleep";
                lblSleep.Dock = DockStyle.Fill;
                lblSleep.Click += (e, a) => CallLogInfo(SleepTime, "Sleep", "", "", "", picSleep.BackColor);
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
                    string SleepTime = tomorrowSleep.GoToBedTime.ToShortTimeString() + " - " + tomorrowSleep.GetUpTime.ToShortTimeString() + "(+1d)";
                    picSleepYesterday.Width = width;
                    picSleepYesterday.Height = (int)(end - start);
                    picSleepYesterday.Left = left;
                    picSleepYesterday.Top = (int)start;
                    picSleepYesterday.BackColor = Color.LightBlue;
                    picMap.Controls.Add(picSleepYesterday);
                    lblSleepYesterday.Text = SleepTime + "\n" + "Sleep";
                    lblSleepYesterday.Dock = DockStyle.Fill;
                    lblSleepYesterday.Click += (e, a) => CallLogInfo("", "Sleep", "", "", "", picSleepYesterday.BackColor);
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
                string TimePeriod = yesterdayLogs[i].StartTime.ToShortTimeString() + "(-1d)" + " - " + yesterdayLogs[i].EndTime.ToShortTimeString();
                string LogName = yesterdayLogs[i].LogName;
                string Location = yesterdayLogs[i].Location;
                string WithWho = yesterdayLogs[i].WithWho;
                string TaskName = yesterdayLogs[i].ContributionToTask;
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
                lstLblLog[i].Click += (e, a) => CallLogInfo(TimePeriod, LogName, Location, WithWho, TaskName, backColor);
                lstPicLog[i].Controls.Add(lstLblLog[i]);
            }

            for (int i = 0; i < todayLogs.Count; i++)
            {
                lstPicLog.Add(new PictureBox());
                lstLblLog.Add(new Label());
                double start = (todayLogs[i].StartTime.Hour + todayLogs[i].StartTime.Minute / 60d) / 24d * height;
                double end;
                string TimePeriod;
                if (todayLogs[i].EndTime.Date == date)
                {
                    end = (todayLogs[i].EndTime.Hour + todayLogs[i].EndTime.Minute / 60d) / 24d * height;
                    TimePeriod = todayLogs[i].StartTime.ToShortTimeString() + " - " + todayLogs[i].EndTime.ToShortTimeString();
                }
                else
                {
                    end = height;
                    TimePeriod = todayLogs[i].StartTime.ToShortTimeString() + " - " + todayLogs[i].EndTime.ToShortTimeString() + "(+1d)";
                }
                string LogName = todayLogs[i].LogName;
                string Location = todayLogs[i].Location;
                string WithWho = todayLogs[i].WithWho;
                string TaskName = todayLogs[i].ContributionToTask;
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
                lstLblLog[i + yesterdayLogs.Count].Click += (e, a) => CallLogInfo(TimePeriod, LogName, Location, WithWho, TaskName, backColor);
                lstPicLog[i + yesterdayLogs.Count].Controls.Add(lstLblLog[i + yesterdayLogs.Count]);
            }
        }

        public void DrawEventController(
            PictureBox picMap, 
            DateTime date,
            List<CEvent> events,
            List<CWorkOut> workOuts,
            List<CLiteratureReadingLog> literatureReadingLogs,
            List<CMedicine> medicines,
            List<CTransaction> transactions,
            List<CTransactionDue> transactionDues,
            List<CMeeting> meetings)
        {
            int left = picMap.Width - 27 > 0 ? picMap.Width - 27 : 0;
            List<PictureBox> lstPicEvent = new List<PictureBox>();
            List<CEvent> lstEvent = events.FindAll(o => o.TagTime.Date == date).ToList();
            List<CWorkOut> lstWorkOut = workOuts.FindAll(o => o.TagTime.Date == date).ToList();
            List<CLiteratureReadingLog> lstLiteratureReadingLog = literatureReadingLogs.FindAll(o => o.TagTime.Date == date).ToList();
            List<CMedicine> lstMedicine = medicines.FindAll(o => o.TagTime.Date == date).ToList();
            List<CTransaction> lstTransaction = transactions.FindAll(o => o.TagTime.Date == date).ToList();
            List<CTransactionDue> lstTransactionDue = transactionDues.FindAll(o => o.TagTime.Date == date).ToList();
            List<CMeeting> lstMeeting = meetings.FindAll(o => o.TagTime.Date == date).ToList();
            int acc = 0;
            for (int i = 0; i < lstEvent.Count; i++)
            {
                lstPicEvent.Add(new PictureBox());
                double middle = lstEvent[i].TagTime.TimeOfDay.TotalDays * picMap.Height;
                if (lstEvent[i].EventState == EEventState.Succeed)
                {
                    lstPicEvent[i].Image = icon.iconEvent;
                }
                else
                {
                    lstPicEvent[i].Image = icon.iconFailedEvent;
                }
                lstPicEvent[i].Top = (int)middle > 15 ? (int)middle - 12 : 3;
                lstPicEvent[i].Left = left;
                lstPicEvent[i].Width = 24;
                lstPicEvent[i].Height = 24;
                picMap.Controls.Add(lstPicEvent[i]);
            }
            acc = acc + lstEvent.Count;
            for (int i = 0; i < lstWorkOut.Count; i++)
            {
                lstPicEvent.Add(new PictureBox());
                double middle = lstWorkOut[i].TagTime.TimeOfDay.TotalDays * picMap.Height;
                lstPicEvent[i + acc].Image = icon.iconFitness;
                lstPicEvent[i + acc].Top = (int)middle > 15 ? (int)middle - 12 : 3;
                lstPicEvent[i + acc].Left = left;
                lstPicEvent[i + acc].Width = 24;
                lstPicEvent[i + acc].Height = 24;
                picMap.Controls.Add(lstPicEvent[i + acc]);
            }
            acc = acc + lstWorkOut.Count;
            for (int i = 0; i < lstLiteratureReadingLog.Count; i++)
            {
                lstPicEvent.Add(new PictureBox());
                double middle = lstLiteratureReadingLog[i].TagTime.TimeOfDay.TotalDays * picMap.Height;
                lstPicEvent[i + acc].Image = icon.iconLiterature;
                lstPicEvent[i + acc].Top = (int)middle > 15 ? (int)middle - 12 : 3;
                lstPicEvent[i + acc].Left = left;
                lstPicEvent[i + acc].Width = 24;
                lstPicEvent[i + acc].Height = 24;
                picMap.Controls.Add(lstPicEvent[i + acc]);
            }
            acc = acc + lstLiteratureReadingLog.Count;
            for (int i = 0; i < lstMedicine.Count; i++)
            {
                lstPicEvent.Add(new PictureBox());
                double middle = lstMedicine[i].TagTime.TimeOfDay.TotalDays * picMap.Height;
                lstPicEvent[i + acc].Image = icon.iconHealth;
                lstPicEvent[i + acc].Top = (int)middle > 15 ? (int)middle - 12 : 3;
                lstPicEvent[i + acc].Left = left;
                lstPicEvent[i + acc].Width = 24;
                lstPicEvent[i + acc].Height = 24;
                picMap.Controls.Add(lstPicEvent[i + acc]);
            }
            acc = acc + lstMedicine.Count;
            for (int i = 0; i < lstTransaction.Count; i++)
            {
                lstPicEvent.Add(new PictureBox());
                double middle = lstTransaction[i].TagTime.TimeOfDay.TotalDays * picMap.Height;
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
                lstPicEvent[i + acc].Top = (int)middle > 15 ? (int)middle - 12 : 3;
                lstPicEvent[i + acc].Left = left;
                lstPicEvent[i + acc].Width = 24;
                lstPicEvent[i + acc].Height = 24;
                picMap.Controls.Add(lstPicEvent[i + acc]);
            }
            acc = acc + lstTransaction.Count;
            for (int i = 0; i < lstTransactionDue.Count; i++)
            {
                lstPicEvent.Add(new PictureBox());
                double middle = lstTransactionDue[i].TagTime.TimeOfDay.TotalDays * picMap.Height;
                lstPicEvent[i + acc].Image = icon.iconTransactionDue;
                lstPicEvent[i + acc].Top = (int)middle > 15 ? (int)middle - 12 : 3;
                lstPicEvent[i + acc].Left = left;
                lstPicEvent[i + acc].Width = 24;
                lstPicEvent[i + acc].Height = 24;
                picMap.Controls.Add(lstPicEvent[i + acc]);
            }
            acc = acc + lstTransactionDue.Count;
            for (int i = 0; i < lstMeeting.Count; i++)
            {
                lstPicEvent.Add(new PictureBox());
                double middle = lstMeeting[i].TagTime.TimeOfDay.TotalDays * picMap.Height;
                lstPicEvent[i + acc].Image = icon.iconMeeting;
                lstPicEvent[i + acc].Top = (int)middle > 15 ? (int)middle - 12 : 3;
                lstPicEvent[i + acc].Left = left;
                lstPicEvent[i + acc].Width = 24;
                lstPicEvent[i + acc].Height = 24;
                picMap.Controls.Add(lstPicEvent[i + acc]);
            }
        }

        public void CallLogInfo(string Timeperiod, string LogName, string Location, string WithWho, string TaskName, Color color)
        {
            frmLogInfo frmLogInfo = new frmLogInfo(Timeperiod, LogName, Location, WithWho, TaskName, color);
            frmLogInfo.Show();
        }

        public void CallDDLInfo(string DDLInfo)
        {
            frmDDLInfo frmDDLInfo = new frmDDLInfo(DDLInfo);
            frmDDLInfo.Show();
        }

        public void CancelLog(List<CLog> logList, DateTime date, string LogName)
        {
            DialogResult result = MessageBox.Show("Delete This Log?", "Deleting", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    logList.RemoveAll(o => o.StartTime.Date == date && o.LogName == LogName);
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }
    }
}
