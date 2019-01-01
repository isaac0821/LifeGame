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
        /// 绘制一日计划或日志
        /// </summary>
        /// <param name="picMap">画布</param>
        /// <param name="date">日期</param>
        /// <param name="logs">所有记录</param>
        /// <param name="healths">睡眠记录</param>
        public void DrawScheduleAndLog(PictureBox picMap, DateTime date, List<CLog> logs, List<CHealth> healths)
        {
            int width = picMap.Width;
            int Height = picMap.Height;
            Graphics rct = picMap.CreateGraphics();

            List<CLog> todayLogs = logs.FindAll(o => o.StartTime.Date == date).ToList();
            List<CLog> yesterdayLogs = logs.FindAll(o => o.StartTime.Date == date.AddDays(-1) && o.EndTime.Date == date).ToList();

            foreach (CLog log in yesterdayLogs)
            {
                double start = 0;
                double end = ((double)log.EndTime.Hour + (double)log.EndTime.Minute / 60d) / 24d * Height;
                rct.FillRectangle(new SolidBrush(GetColor(log.Color)), 0, (int)start, width, (int)(end - start));
            }

            foreach (CLog log in todayLogs)
            {
                double start = ((double)log.StartTime.Hour + (double)log.StartTime.Minute / 60d) / 24d * Height;
                double end;
                if (log.EndTime.Date == date)
                {
                    end = ((double)log.EndTime.Hour + (double)log.EndTime.Minute / 60d) / 24d * Height;
                }
                else
                {
                    end = Height;
                }
                rct.FillRectangle(new SolidBrush(GetColor(log.Color)), 0, (int)start, width, (int)(end - start));
            }
        }
    }
}
