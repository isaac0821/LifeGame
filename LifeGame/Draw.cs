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
        /// 返回Color格式的颜色
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
                    ret = Color.Gray;
                    break;
                default:
                    ret = Color.Black;
                    break;
            }
            return ret;
        }

        /// <summary>
        /// 绘制计划图或日志图
        /// </summary>
        /// <param name="picMap">画布</param>
        /// <param name="date">日期</param>
        /// <param name="logs">日志</param>
        /// <param name="healths">健康日志</param>
        /// <param name="IsLabelShown">是否显示标签</param>
        /// <param name="LocationMode">位置模式："all" - 全部; "left" - 左侧; "right" - 右侧</param>
        public void DrawScheduleAndLog(PictureBox picMap, DateTime date, List<CLog> logs, List<CHealth> healths, bool IsLabelShown, string LocationMode)
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
            int height = picMap.Height;
            Graphics rct = picMap.CreateGraphics();
            rct.FillRectangle(new SolidBrush(Color.White), left, 0, width, height);
            List<CLog> todayLogs = logs.FindAll(o => o.StartTime.Date == date).ToList();
            List<CLog> yesterdayLogs = logs.FindAll(o => o.StartTime.Date == date.AddDays(-1) && o.EndTime.Date == date).ToList();
            CHealth todaySleep = healths.Find(o => o.Date == date);
            CHealth tomorrowSleep = healths.Find(o => o.Date == date.AddDays(1));

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
                rct.FillRectangle(new SolidBrush(Color.LightBlue), left, (int)start, width, (int)(end - start));
                if (IsLabelShown)
                {
                    rct.DrawString("Sleep", new Font("Microsoft Sans Serif", 8), new SolidBrush(Color.Black), left, (int)start);
                }
            }

            if (healths.Exists(o => o.Date == date.AddDays(1)))
            {
                if (tomorrowSleep.IsGoToBedBeforeMidNight)
                {
                    double start = (tomorrowSleep.GoToBedTime.Hour + tomorrowSleep.GoToBedTime.Minute / 60d) / 24d * height;
                    double end = height;
                    rct.FillRectangle(new SolidBrush(Color.LightBlue), left, (int)start, width, (int)(end - start));
                    if (IsLabelShown)
                    {
                        rct.DrawString("Sleep", new Font("Microsoft Sans Serif", 8), new SolidBrush(Color.Black), left, (int)start);
                    }
                }
            }

            foreach (CLog log in yesterdayLogs)
            {
                double start = 0;
                double end = (log.EndTime.Hour + log.EndTime.Minute / 60d) / 24d * height;
                rct.FillRectangle(new SolidBrush(GetColor(log.Color)), left, (int)start, width, (int)(end - start));
                if (IsLabelShown)
                {
                    string LogName = log.LogName.Length > 10 ? log.LogName.Substring(10) : log.LogName;
                    rct.DrawString(LogName, new Font("Microsoft Sans Serif", 8), new SolidBrush(Color.Black), left, (int)start);
                }
            }

            foreach (CLog log in todayLogs)
            {
                double start = (log.StartTime.Hour + log.StartTime.Minute / 60d) / 24d * height;
                double end;
                if (log.EndTime.Date == date)
                {
                    end = (log.EndTime.Hour + log.EndTime.Minute / 60d) / 24d * height;
                }
                else
                {
                    end = height;
                }
                rct.FillRectangle(new SolidBrush(GetColor(log.Color)), left, (int)start, width, (int)(end - start));
                if (IsLabelShown)
                {
                    string LogName = log.LogName.Length > 10 ? log.LogName.Substring(10) : log.LogName;
                    rct.DrawString(LogName, new Font("Microsoft Sans Serif", 8), new SolidBrush(Color.Black), left, (int)start);
                }
            }
        }
    }
}
