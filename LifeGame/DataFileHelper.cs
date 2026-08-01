using System;
using System.IO;
using System.Text;

namespace LifeGame
{
    /// <summary>文件读写工具（原子写入 + .bak 备份，无 SHA256）</summary>
    public static class DataFileHelper
    {
        public const string DataDir = "data";
        public const string ConfigDir = "data\\config";
        public const string NotesDir = "data\\notes";
        public const string SysNotesDir = "data\\sysnotes";
        public const string LitsDir = "data\\lits";
        public const string DiariesDir = "data\\diaries";
        public const string LogsDir = "data\\logs";
        public const string LiteratureReviewDir = "data\\literature_review";

        /// <summary>确保所有 data 子目录存在</summary>
        public static void EnsureDirectories()
        {
            Directory.CreateDirectory(DataDir);
            Directory.CreateDirectory(ConfigDir);
            Directory.CreateDirectory(NotesDir);
            Directory.CreateDirectory(SysNotesDir);
            Directory.CreateDirectory(LitsDir);
            Directory.CreateDirectory(DiariesDir);
            Directory.CreateDirectory(LogsDir);
            Directory.CreateDirectory(LiteratureReviewDir);
        }

        /// <summary>原子写入文本文件（先写 .tmp → 旧文件 .bak → 替换）</summary>
        public static void AtomicWriteText(string path, string content)
        {
            string dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);

            string tmpPath = path + ".tmp";
            string bakPath = path + ".bak";

            File.WriteAllText(tmpPath, content, Encoding.UTF8);

            string verify = File.ReadAllText(tmpPath, Encoding.UTF8);
            if (verify != content)
                throw new IOException("Write verification failed: " + path);

            if (File.Exists(path))
                File.Copy(path, bakPath, overwrite: true);

            if (File.Exists(path))
                File.Delete(path);
            File.Move(tmpPath, path);
        }

        /// <summary>读取文本文件</summary>
        public static string ReadText(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found: " + path);
            return File.ReadAllText(path, Encoding.UTF8);
        }

        /// <summary>读取文本文件，不存在返回 null</summary>
        public static string TryReadText(string path)
        {
            if (!File.Exists(path)) return null;
            return File.ReadAllText(path, Encoding.UTF8);
        }

        /// <summary>安全删除文件及其 .tmp/.bak</summary>
        public static void SafeDelete(string path)
        {
            foreach (var f in new[] { path, path + ".tmp", path + ".bak" })
            {
                if (File.Exists(f))
                {
                    try { File.Delete(f); } catch { }
                }
            }
        }

        /// <summary>文件名安全化：替换无效字符为 _</summary>
        public static string SanitizeFileName(string name)
        {
            if (string.IsNullOrEmpty(name)) return "_";
            char[] invalid = Path.GetInvalidFileNameChars();
            var sb = new StringBuilder(name.Length);
            foreach (char c in name)
                sb.Append(Array.IndexOf(invalid, c) >= 0 ? '_' : c);
            string result = sb.ToString().Trim();
            // 限制长度，留够扩展名空间
            if (result.Length > 200) result = result.Substring(0, 200);
            return string.IsNullOrEmpty(result) ? "_" : result;
        }
    }
}
