using System;
using System.IO;
using System.Windows.Forms;

namespace LifeGame
{
    /// <summary>根据 noteText 决策 iglIcon 中的图标索引，OutineRow 用 ImageList.Draw 绘制</summary>
    public static class NoteIconProvider
    {
        public static ImageList IconList { get; set; }

        private const string KeyDDL         = "Note_DDL.png";
        private const string KeyJumpAvail   = "Note_Jump_Avail.png";
        private const string KeyJumpUnavail = "Note_Jump_Unavail.png";
        private const string KeyLinkAvail   = "Note_Link_Avail.png";
        private const string KeyLinkUnavail = "Note_Link_Unavail.png";
        private const string KeyLitAvail    = "Note_Litr_Avail.png";
        private const string KeyLitUnavail  = "Note_Litr_Unavail.png";
        private const string KeyNoteAvail   = "Note_Note_Avail.png";
        private const string KeyNoteUnavail = "Note_Note_Unavail.png";
        private const string KeySchAvail    = "Note_Schl_Avail.png";
        private const string KeySchUnavail  = "Note_Schl_Unavail.png";
        private const string KeyTaskAvail   = "Note_Task_Avail.png";
        private const string KeyTaskUnavail = "Note_Task_Unavail.png";
        private const string KeyFuncAvail   = "Note_Func_Avail.png";
        private const string KeyFuncUnavail = "Note_Func_Unavail.png";
        private const string KeyLrevAvail   = "Note_Lrev_Avail.png";
        private const string KeyLrevUnavail = "Note_Lrev_Unavail.png";

        private static int GetIndex(string key)
        {
            if (IconList == null || string.IsNullOrEmpty(key)) return -1;
            return IconList.Images.IndexOfKey(key);
        }

        /// <summary>检查 $TASK$> 的结束日期是否已过期（早于今天）</summary>
        private static bool IsTaskExpired(string text)
        {
            try
            {
                // $TASK$>Name@YYYY.MM.DD 或 $TASK$>Name@YYYY.MM.DD-YYYY.MM.DD
                string t = text.StartsWith("$TASK$>") ? text.Substring(7) : text;
                // 去掉末尾的 @{Mon, Wed}
                t = System.Text.RegularExpressions.Regex.Replace(t, @"@\{[^}]+\}\s*$", "").TrimEnd();
                int at = t.LastIndexOf('@');
                if (at < 0) return false;
                string range = t.Substring(at + 1);
                string endStr = range;
                int sep = range.IndexOf('-');
                if (sep >= 0) endStr = range.Substring(sep + 1);

                // . 在自定义日期格式中是区域性的日期分隔符，在 zh-CN 会被解释为 / 导致匹配失败
                endStr = endStr.Trim().Replace('.', '/');
                string[] fmts = { "yyyy/MM/dd", "yyyy-MM-dd" };
                if (DateTime.TryParseExact(endStr, fmts, System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime end))
                    return end < DateTime.Today;
                return false;
            }
            catch { return false; }
        }

        /// <summary>返回 iglIcon 中对应的图片索引，-1 表示无图标</summary>
        public static int GetIconIndex(string noteText)
        {
            if (string.IsNullOrEmpty(noteText)) return -1;

            if (noteText.IndexOf("$DDLI$>", StringComparison.OrdinalIgnoreCase) >= 0
                || noteText.IndexOf("Date:", StringComparison.OrdinalIgnoreCase) >= 0
                || noteText.IndexOf("date:", StringComparison.OrdinalIgnoreCase) >= 0)
                return GetIndex(KeyDDL);

            if (noteText.Contains("$LINK$>")) return GetIndex(GetLinkKey(noteText));
            if (noteText.Contains("$NOTE$>")) return GetIndex(GetNoteKey(noteText));
            if (noteText.Contains("$JUMP$>")) return GetIndex(KeyJumpAvail);
            if (noteText.Contains("$LITR$>")) return GetIndex(GetLitKey(noteText));
            if (noteText.Contains("$SCHL$>")) return GetIndex(GetSchKey(noteText));
            if (noteText.Contains("$TASK$>")) return GetIndex(IsTaskExpired(noteText) ? KeyTaskUnavail : KeyTaskAvail);
            if (noteText.Contains("$FUNC$>")) return GetIndex(GetFuncKey(noteText));
            if (noteText.Contains("$LREV$>")) return GetIndex(GetLrevKey(noteText));

            return -1;
        }

        private static string GetLinkKey(string text)
        {
            try
            {
                string path = text.Split('@')[0].Replace("$LINK$>", "");
                string[] parts = path.Split(':');
                if (parts[0] == "http" || parts[0] == "https") return KeyLinkAvail;
                return (File.Exists(path) || Directory.Exists(path)) ? KeyLinkAvail : KeyLinkUnavail;
            }
            catch { return KeyLinkUnavail; }
        }

        private static string GetNoteKey(string text)
        {
            try
            {
                string[] parts = text.Replace("$NOTE$>", "").Split('@');
                // Note Archive: $NOTE$>YYYY.MM.DD@Topic 或 icon模式: $NOTE$>Topic
                if (parts.Length >= 2)
                {
                    string[] dateParts = parts[0].Split('.');
                    if (dateParts.Length == 3
                        && int.TryParse(dateParts[0], out int y)
                        && int.TryParse(dateParts[1], out int m)
                        && int.TryParse(dateParts[2], out int d))
                    {
                        DateTime date = new DateTime(y, m, d);
                        return G.glb.lstNote.Exists(o => o.Created.Date == date && o.Topic == parts[1])
                            ? KeyNoteAvail : KeyNoteUnavail;
                    }
                }
                // 仅 Topic 形式：检查 Note 是否存在
                string topic = parts.Length >= 2 ? parts[1] : parts[0];
                return G.glb.lstNote.Exists(o => o.Topic == topic)
                    ? KeyNoteAvail : KeyNoteUnavail;
            }
            catch { return KeyNoteUnavail; }
        }

        private static string GetLitKey(string text)
        {
            string title = text.Split('@')[0].Replace("$LITR$>", "");
            bool exists = G.glb.lstLiterature.Exists(o => o.Title == title);
            return exists ? KeyLitAvail : KeyLitUnavail;
        }

        private static string GetSchKey(string text)
        {
            // $SCHL$> entries are always valid in Diary context
            return KeySchAvail;
        }

        private static string GetFuncKey(string text)
        {
            // $FUNC$> 是系统功能入口，永远可用
            return KeyFuncAvail;
        }

        private static string GetLrevKey(string text)
        {
            try
            {
                string[] parts = text.Replace("$LREV$>", "").Split('@');
                if (parts.Length >= 2)
                {
                    string[] dateParts = parts[0].Split('.');
                    if (dateParts.Length == 3
                        && int.TryParse(dateParts[0], out int y)
                        && int.TryParse(dateParts[1], out int m)
                        && int.TryParse(dateParts[2], out int d))
                    {
                        DateTime date = new DateTime(y, m, d);
                        return G.glb.lstLiteratureReview.Exists(o => o.Created.Date == date && o.Topic == parts[1])
                            ? KeyLrevAvail : KeyLrevUnavail;
                    }
                }
                return KeyLrevUnavail;
            }
            catch { return KeyLrevUnavail; }
        }
    }
}
