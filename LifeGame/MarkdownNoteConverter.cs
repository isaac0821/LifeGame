using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LifeGame
{
    /// <summary>
    /// Markdown (.md) + YAML front matter 工具方法。
    /// 数据模型的加载/保存逻辑已在 GameDocument 子类中实现。
    /// 文件名规则：
    ///   Note:       NOTE_{yyyyMMdd}_{santizedTopic}.md → data/notes/
    ///   Literature: LITR_{sanitizedTitle}.md           → data/lits/
    ///   Diary:      DIAY_{yyyyMMdd}.md                 → data/diaries/
    /// </summary>
    public static class MarkdownNoteConverter
    {
        #region === 文件名生成 ===

        public static string MakeNoteFileName(DateTime date, string topic)
        {
            string safe = DataFileHelper.SanitizeFileName(topic ?? "Note");
            return $"NOTE_{date:yyyyMMdd}_{safe}.md";
        }

        public static string MakeNotePath(DateTime date, string topic)
            => Path.Combine(DataFileHelper.NotesDir, MakeNoteFileName(date, topic));

        public static string MakeSysNoteFileName(string topic)
        {
            string name = topic ?? "SysNote";
            // 去掉 "SysNote:" / "SysNote：" 前缀，只保留有意义的后半部分
            if (name.StartsWith("SysNote:")) name = name.Substring("SysNote:".Length).Trim();
            else if (name.StartsWith("SysNote：")) name = name.Substring("SysNote：".Length).Trim();
            if (string.IsNullOrEmpty(name)) name = "SysNote";
            string safe = DataFileHelper.SanitizeFileName(name);
            return $"SYSN_{safe}.md";
        }

        public static string MakeSysNotePath(string topic)
            => Path.Combine(DataFileHelper.SysNotesDir, MakeSysNoteFileName(topic));

        public static string MakeLiteratureFileName(string title)
        {
            string safe = DataFileHelper.SanitizeFileName(title ?? "Literature");
            return $"LITR_{safe}.md";
        }

        public static string MakeLiteraturePath(string title)
            => Path.Combine(DataFileHelper.LitsDir, MakeLiteratureFileName(title));

        public static string MakeDiaryFileName(DateTime date)
            => $"DIAY_{date:yyyyMMdd}.md";

        public static string MakeDiaryPath(DateTime date)
            => Path.Combine(DataFileHelper.DiariesDir, MakeDiaryFileName(date));

        public static string MakeLiteratureReviewFileName(DateTime date, string topic)
        {
            string safe = DataFileHelper.SanitizeFileName(topic ?? "Review");
            return $"LREV_{date:yyyyMMdd}_{safe}.md";
        }

        public static string MakeLiteratureReviewPath(DateTime date, string topic)
            => Path.Combine(DataFileHelper.LiteratureReviewDir, MakeLiteratureReviewFileName(date, topic));

        #endregion

        #region === 缩进大纲正文 ===

        public static List<OutlineLine> ParseOutlineBody(string body)
        {
            var lines = new List<OutlineLine>();
            if (string.IsNullOrWhiteSpace(body)) return lines;

            var rawLines = body.Split('\n');
            var stack = new Stack<OutlineLine>();

            foreach (var raw in rawLines)
            {
                string text = raw.Replace("\t", "    ");
                if (string.IsNullOrEmpty(text)) continue;

                int indent = 0;
                while (indent < text.Length && text[indent] == ' ') indent++;
                int level = indent / 4;
                string content = text.Substring(indent).Trim();
                if (string.IsNullOrEmpty(content)) continue;

                // 检测收起标记 [-]
                bool isExpanded = true;
                if (content.StartsWith("[-] "))
                {
                    content = content.Substring(4).Trim();
                    isExpanded = false;
                }

                var line = new OutlineLine { Text = content, Level = level, Expanded = isExpanded };
                while (stack.Count > 0 && stack.Peek().Level >= level) stack.Pop();
                line.ParentGUID = stack.Count > 0 ? stack.Peek().GUID : "";
                stack.Push(line);
                lines.Add(line);
            }
            return lines;
        }

        public static string BuildOutlineBody(List<OutlineLine> lines)
        {
            if (lines == null || lines.Count == 0) return "";
            var sb = new StringBuilder();
            foreach (var line in lines)
            {
                string indent = new string(' ', line.Level * 4);
                string prefix = line.Expanded ? "" : "[-] ";
                sb.AppendLine(indent + prefix + (line.Text ?? ""));
            }
            return sb.ToString();
        }

        /// <summary>构建带标题行的 body（Level 0 标题 + 内容行 Level+1）</summary>
        public static string BuildOutlineBodyWithTitle(string title, List<OutlineLine> lines)
        {
            var sb = new StringBuilder();
            sb.AppendLine(title ?? "");
            if (lines != null && lines.Count > 0)
            {
                int minLevel = lines.Min(l => l.Level);
                int offset = 1 - minLevel;
                foreach (var l in lines)
                    sb.AppendLine(new string(' ', (l.Level + offset) * 4) + (l.Text ?? ""));
            }
            return sb.ToString();
        }

        #endregion
    }
}
