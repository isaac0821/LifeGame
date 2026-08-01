using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LifeGame
{
    public class plot
    {
        private class PlotSchedule
        {
            public string Name;
            public DateTime StartTime;
            public DateTime EndTime;
            public string Color;
            public string Location;
            public string WithWho;
        }

        /// <summary>从日记 body 解析 $SCHL$> 行生成日程列表</summary>
        private List<PlotSchedule> LoadSchedulesForDate(DateTime date)
        {
            var result = new List<PlotSchedule>();
            string diaryPath = MarkdownNoteConverter.MakeDiaryPath(date);
            if (!File.Exists(diaryPath)) return result;
            try
            {
                string raw = File.ReadAllText(diaryPath, Encoding.UTF8);
                var (yaml, body) = GameDocument.SplitFrontMatter(raw);
                foreach (var line in body.Split('\n'))
                {
                    string t = line.TrimStart();
                    if ((t.StartsWith("[-] ") || t.StartsWith("[+] ")) && t.Length > 4)
                        t = t.Substring(4);
                    if (!t.StartsWith("$SCHL$>")) continue;
                    t = t.Substring(7);
                    var parts = t.Split('@');
                    if (parts.Length < 3) continue;
                    string[] times = parts[1].Split('-');
                    if (times.Length < 2) continue;
                    string startStr = times[0].Trim();
                    string endStr = times[1].Trim();
                    int crossDays = 0;
                    if (endStr.Contains("(+"))
                    {
                        int pIdx = endStr.IndexOf("(+");
                        int cPIdx = endStr.IndexOf(")", pIdx);
                        if (cPIdx > pIdx && int.TryParse(endStr.Substring(pIdx + 2, cPIdx - pIdx - 2), out int cd))
                            crossDays = cd;
                        endStr = endStr.Substring(0, pIdx).Trim();
                    }
                    if (DateTime.TryParse(date.ToString("yyyy-MM-dd") + " " + startStr, out DateTime st) &&
                        DateTime.TryParse(date.AddDays(crossDays).ToString("yyyy-MM-dd") + " " + endStr, out DateTime et))
                    {
                        result.Add(new PlotSchedule
                        {
                            Name = parts[0].Trim(),
                            StartTime = st,
                            EndTime = et,
                            Color = parts[2].Trim(),
                            Location = parts.Length >= 4 ? parts[3].Trim() : "",
                            WithWho = parts.Length >= 5 ? parts[4].Trim() : "",
                        });
                    }
                }
            }
            catch { }
            return result;
        }

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
                    ret = Color.DarkGray;
                    break;
                case "(None)":
                    ret = Color.Transparent;
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
        /// <param name="LocationMode">位置模式："all" - 全部; "left" - 左侧; "right" - 右侧</param>
        public void DrawLogController(PictureBox picMap, DateTime date)
        {
            int left = 0;
            int width = picMap.Width - 30;

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

            List<PlotSchedule> todayLogs = LoadSchedulesForDate(date);
            List<PlotSchedule> yesterdayLogs = new List<PlotSchedule>();
            if (date > DateTime.MinValue)
            {
                var prevSchedules = LoadSchedulesForDate(date.AddDays(-1));
                yesterdayLogs = prevSchedules.Where(o => o.EndTime.Date == date).ToList();
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
                string LogName = yesterdayLogs[i].Name;
                string Location = yesterdayLogs[i].Location;
                string WithWho = yesterdayLogs[i].WithWho;
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
                string LogName = todayLogs[i].Name;
                string Location = todayLogs[i].Location;
                string WithWho = todayLogs[i].WithWho;
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

        /// <summary>绘制 Diary 竖式日程时间轴（日程色块 + 时间刻度 + 当前指针）</summary>
        public void DrawDiaryTimeline(PictureBox picMap, DateTime date, int hourHeight = 80)
        {
            picMap.Controls.Clear();

            int width = picMap.Width;
            if (width < 150) width = 280;
            int height = 24 * hourHeight;
            int timeColWidth = 48;
            picMap.Height = height;
            picMap.Width = width;

            // 米黄底色
            picMap.BackColor = Color.FromArgb(255, 252, 245);

            // --- 时间刻度标签 ---
            var hourFont = new Font("Segoe UI", 7.5F, FontStyle.Regular);
            var minuteFont = new Font("Segoe UI", 6.5F, FontStyle.Regular);

            for (int h = 0; h < 24; h++)
            {
                int y = h * hourHeight;

                // 整点标签
                var lblHour = new Label
                {
                    Text = h.ToString("00") + ":00",
                    Left = 2,
                    Top = y - 1,
                    Width = timeColWidth - 6,
                    Height = 13,
                    Font = hourFont,
                    ForeColor = Color.FromArgb(160, 140, 110),
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.TopRight,
                };
                picMap.Controls.Add(lblHour);

                // 半小时小刻度（仅在高度够时显示）
                if (hourHeight >= 40)
                {
                    var lblHalf = new Label
                    {
                        Text = h.ToString("00") + ":30",
                        Left = 2,
                        Top = y + hourHeight / 2 - 5,
                        Width = timeColWidth - 6,
                        Height = 11,
                        Font = minuteFont,
                        ForeColor = Color.FromArgb(200, 190, 170),
                        BackColor = Color.Transparent,
                        TextAlign = ContentAlignment.TopRight,
                    };
                    picMap.Controls.Add(lblHalf);
                }

                // 网格线
                var gridLine = new PictureBox
                {
                    Left = timeColWidth,
                    Top = y,
                    Width = width - timeColWidth,
                    Height = 1,
                    BackColor = Color.FromArgb(230, 220, 200),
                };
                picMap.Controls.Add(gridLine);
            }

            // 左侧竖线
            var sepLine = new PictureBox
            {
                Left = timeColWidth - 1,
                Top = 0,
                Width = 1,
                Height = height,
                BackColor = Color.FromArgb(210, 200, 180),
            };
            picMap.Controls.Add(sepLine);

            // --- 日程色块 ---
            var todayLogs = LoadSchedulesForDate(date);
            var yesterdayLogs = new List<PlotSchedule>();
            if (date > DateTime.MinValue)
            {
                var prevSchedules = LoadSchedulesForDate(date.AddDays(-1));
                yesterdayLogs = prevSchedules.Where(o => o.EndTime.Date == date).ToList();
            }

            int blockLeft = timeColWidth + 4;
            int blockWidth = width - timeColWidth - 8;

            // 跨天的日志
            for (int i = 0; i < yesterdayLogs.Count; i++)
            {
                var log = yesterdayLogs[i];
                double end = (log.EndTime.Hour + log.EndTime.Minute / 60.0) / 24.0 * height;
                Color backColor = GetColor(log.Color);
                AddTimelineBlock(picMap, log, backColor, 0, (int)end, blockLeft, blockWidth, date, true);
            }

            // 当天日志
            for (int i = 0; i < todayLogs.Count; i++)
            {
                var log = todayLogs[i];
                double start = (log.StartTime.Hour + log.StartTime.Minute / 60.0) / 24.0 * height;
                double end = log.EndTime.Date > date ? height
                    : (log.EndTime.Hour + log.EndTime.Minute / 60.0) / 24.0 * height;
                Color backColor = GetColor(log.Color);
                AddTimelineBlock(picMap, log, backColor, (int)start, (int)end, blockLeft, blockWidth, date, log.EndTime.Date > date);
            }

            // --- 当前时间指针（仅当天） ---
            if (date == DateTime.Today.Date)
            {
                int nowY = (int)(height * DateTime.Now.TimeOfDay.TotalMinutes / (24 * 60));
                var nowLine = new PictureBox
                {
                    Left = timeColWidth,
                    Top = nowY - 1,
                    Width = width - timeColWidth,
                    Height = 2,
                    BackColor = Color.FromArgb(220, 50, 50),
                };
                picMap.Controls.Add(nowLine);
                picMap.Controls.SetChildIndex(nowLine, 0);

                var nowDot = new PictureBox
                {
                    Left = timeColWidth,
                    Top = nowY - 4,
                    Width = 8,
                    Height = 8,
                    BackColor = Color.FromArgb(220, 50, 50),
                };
                nowDot.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using (var b = new SolidBrush(Color.FromArgb(220, 50, 50)))
                        e.Graphics.FillEllipse(b, 0, 0, 7, 7);
                };
                picMap.Controls.Add(nowDot);

                var nowLabel = new Label
                {
                    Text = DateTime.Now.ToShortTimeString(),
                    Left = timeColWidth + 12,
                    Top = nowY - 13,
                    Width = 45,
                    Height = 13,
                    Font = new Font("Segoe UI", 7F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(220, 50, 50),
                    BackColor = Color.Transparent,
                };
                picMap.Controls.Add(nowLabel);
            }
        }

        private void AddTimelineBlock(PictureBox picMap, PlotSchedule log, Color backColor,
            int top, int bottom, int left, int width, DateTime date, bool isContinuation)
        {
            if (bottom - top < 16) bottom = top + 16; // 最小高度

            double totalHour = (log.EndTime - log.StartTime).TotalHours;
            string timeStr;
            if (isContinuation && log.StartTime.Date < date)
                timeStr = log.StartTime.ToShortTimeString() + "(-1d) - " + log.EndTime.ToShortTimeString();
            else if (log.EndTime.Date > date)
                timeStr = log.StartTime.ToShortTimeString() + " - " + log.EndTime.ToShortTimeString() + "(+1d)";
            else
                timeStr = log.StartTime.ToShortTimeString() + " - " + log.EndTime.ToShortTimeString();
            timeStr += " [" + Math.Round(totalHour, 1).ToString("0.#") + "h]";

            var block = new PictureBox
            {
                Left = left + 1,
                Top = top + 1,
                Width = width - 2,
                Height = bottom - top - 2,
                BackColor = backColor,
                Cursor = Cursors.Hand,
            };

            // 边框
            block.Paint += (s, e) =>
            {
                var pen = new Pen(Color.FromArgb(80, 0, 0, 0));
                e.Graphics.DrawRectangle(pen, 0, 0, block.Width - 1, block.Height - 1);
                pen.Dispose();
            };

            // 信息文本
            string info = timeStr;
            if (!string.IsNullOrEmpty(log.Name))
                info += "\n" + log.Name;
            if (!string.IsNullOrEmpty(log.Location))
                info += "  @" + log.Location;
            if (!string.IsNullOrEmpty(log.WithWho))
                info += "\n " + log.WithWho;

            var label = new Label
            {
                Text = info,
                Left = 6,
                Top = 4,
                Width = block.Width - 12,
                Height = block.Height - 8,
                ForeColor = Color.FromArgb(255 - backColor.R, 255 - backColor.G, 255 - backColor.B),
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 7.5F),
            };
            block.Controls.Add(label);

            picMap.Controls.Add(block);
        }

        public void DrawEventController(
            PictureBox picMap,
            DateTime date)
        {
            int left = picMap.Width - 27 > 0 ? picMap.Width - 27 : 0;
            List<PictureBox> lstPicEvent = new List<PictureBox>();
            List<NoteDocument> lstNote = G.glb.lstNote.FindAll(o => o.Created.Date == date).ToList();
            List<LiteratureDocument> lstLiterature = G.glb.lstLiterature.FindAll(o => o.Created == date).ToList();

            int acc = 0;

            // Notes
            for (int i = 0; i < lstNote.Count; i++)
            {
                lstPicEvent.Add(new PictureBox());
                NoteDocument note = lstNote[i];
                lstPicEvent[i + acc].Top = (i + acc) * 30 + 3;
                lstPicEvent[i + acc].Left = left;
                lstPicEvent[i + acc].Width = 24;
                lstPicEvent[i + acc].Height = 24;
                lstPicEvent[i + acc].Click += (e, a) => CallInfoNote(note);
                picMap.Controls.Add(lstPicEvent[i + acc]);
            }
            acc = acc + lstNote.Count;

            // Literature
            for (int i = 0; i < lstLiterature.Count; i++)
            {
                lstPicEvent.Add(new PictureBox());
                LiteratureDocument lit = lstLiterature[i];
                lstPicEvent[i + acc].Top = (i + acc) * 30 + 3;
                lstPicEvent[i + acc].Left = left;
                lstPicEvent[i + acc].Width = 24;
                lstPicEvent[i + acc].Height = 24;
                lstPicEvent[i + acc].Click += (e, a) => CallInfoLiterature(lit);
                picMap.Controls.Add(lstPicEvent[i + acc]);
            }
            acc = acc + lstLiterature.Count;
        }


        public void CallInfoNote(NoteDocument info)
        {
            if (M.NoteExists(info.GUID))
            {
                M.FindNoteForm(info.GUID).Show();
                M.FindNoteForm(info.GUID).BringToFront();
            }
            else
            {
                var f = new frmInfoNoteV2(info);
                M.notesOpened.Add(f);
                f.Show();
            }
        }

        public void CallInfoLiterature(LiteratureDocument lit)
        {
            if (M.NoteExists(lit.GUID))
            {
                M.FindNoteForm(lit.GUID).Show();
                M.FindNoteForm(lit.GUID).BringToFront();
            }
            else
            {
                var f = new frmInfoNoteV2(lit);
                M.notesOpened.Add(f);
                f.Show();
            }
        }



    }
}
