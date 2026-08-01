using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LifeGame
{
    public static class G
    {
        public static Mem glb = new Mem();
    }

    public class Mem
    {
        public List<NoteDocument> lstNote = new List<NoteDocument>();
        public List<LiteratureDocument> lstLiterature = new List<LiteratureDocument>();
        public List<LiteratureReviewDocument> lstLiteratureReview = new List<LiteratureReviewDocument>();
        public List<DiaryDocument> lstDiary = new List<DiaryDocument>();
        public List<CConfigEntry> lstConfig = new List<CConfigEntry>();
    }

    public static class DataStore
    {
        #region === Global Config ===

        public static void LoadGlobalData()
        {
            DataFileHelper.EnsureDirectories();
            LoadAppConfig();
            LoadNoteIndex();
            LoadLiteratureIndex();
            LoadLiteratureReviewIndex();
            LoadDiaryIndex();
            RebuildLiteratureList();
            RebuildLiteratureReviewList();
        }

        private static void LoadAppConfig()
        {
            string json = DataFileHelper.TryReadText("data\\config\\app_config.json");
            try
            {
                if (json != null)
                {
                    dynamic obj = JsonConvert.DeserializeObject(json);
                    var shortcuts = JsonConvert.DeserializeObject<List<CConfigEntry>>(obj.Shortcuts?.ToString() ?? "[]") ?? new List<CConfigEntry>();
                    var theme = JsonConvert.DeserializeObject<List<CConfigEntry>>(obj.Theme?.ToString() ?? "[]") ?? new List<CConfigEntry>();
                    G.glb.lstConfig = shortcuts.Concat(theme).ToList();
                }
            }
            catch { }

            // 如果没有任何配置项（首次运行或文件不存在），填充默认值
            if (G.glb.lstConfig.Count == 0)
                EnsureDefaultConfig();

            // 应用已保存的主题配置到 Theme.Current
            ApplyAllThemeConfig();
        }

        private static void EnsureDefaultConfig()
        {
            G.glb.lstConfig = _defaultConfigValues
                .Select(kv => new CConfigEntry { Category = kv.Key.Category, Key = kv.Key.Key, Value = kv.Value })
                .ToList();
        }

        private static readonly Dictionary<(string Category, string Key), string> _defaultConfigValues = new Dictionary<(string, string), string>
        {
            { ("Shortcuts", "Save"),          "Ctrl+S" },
            { ("Shortcuts", "Search"),        "Ctrl+F" },
            { ("Shortcuts", "Goto"),          "Ctrl+G" },
            { ("Shortcuts", "AddChild"),      "Ctrl+A" },
            { ("Shortcuts", "AddSibling"),    "Ctrl+B" },
            { ("Shortcuts", "Delete"),        "Ctrl+D" },
            { ("Shortcuts", "Copy"),          "Ctrl+C" },
            { ("Shortcuts", "Paste"),         "Ctrl+V" },
            { ("Shortcuts", "MoveUp"),        "Ctrl+I" },
            { ("Shortcuts", "MoveDown"),      "Ctrl+K" },
            { ("Shortcuts", "Indent"),        "Ctrl+L" },
            { ("Shortcuts", "Unindent"),      "Ctrl+J" },
            { ("Shortcuts", "Fold"),          "Ctrl+N" },
            { ("Shortcuts", "Expand"),        "Ctrl+M" },
            { ("Shortcuts", "Edit"),          "Ctrl+E" },
            { ("Shortcuts", "Undo"),          "Ctrl+Z" },
            { ("Shortcuts", "Redo"),          "Ctrl+Shift+Z" },
            { ("Shortcuts", "ToggleMode"),    "Ctrl+Y" },

            { ("Theme", "AccentColor"),       "#5A82B4" },
            { ("Theme", "FormBackground"),    "#F5F2EB" },
            { ("Theme", "PanelBackground"),   "#FCFAF5" },
            { ("Theme", "TextPrimary"),       "#3C3228" },
            { ("Theme", "TextSecondary"),     "#8C8273" },
            { ("Theme", "ButtonPrimaryBg"),   "#5A82B4" },
            { ("Theme", "ButtonPrimaryFg"),   "#FFFFFF" },
            { ("Theme", "ToolbarBackground"), "#F8F4EB" },
            { ("Theme", "Selection"),         "#E1DACD" },
            { ("Theme", "Border"),            "#E1DACD" },
            { ("Theme", "Surface"),           "#FFFCF7" },
            { ("Theme", "FontSize"),          "9" },
        };

        private static void ApplyAllThemeConfig()
        {
            if (Theme.Current == null) return;
            foreach (var entry in G.glb.lstConfig)
            {
                if (entry.Category != "Theme" || string.IsNullOrEmpty(entry.Value)) continue;
                try
                {
                    switch (entry.Key)
                    {
                        case "AccentColor":
                            var accent = ColorTranslator.FromHtml(entry.Value);
                            Theme.Current.Accent = accent;
                            Theme.Current.ButtonPrimaryBg = accent;
                            Theme.Current.ProgressBarFill = accent;
                            break;
                        case "FormBackground":
                            Theme.Current.FormBackground = ColorTranslator.FromHtml(entry.Value);
                            break;
                        case "PanelBackground":
                            Theme.Current.PanelBackground = ColorTranslator.FromHtml(entry.Value);
                            break;
                        case "TextPrimary":
                            Theme.Current.TextPrimary = ColorTranslator.FromHtml(entry.Value);
                            break;
                        case "TextSecondary":
                            Theme.Current.TextSecondary = ColorTranslator.FromHtml(entry.Value);
                            break;
                        case "ButtonPrimaryBg":
                            Theme.Current.ButtonPrimaryBg = ColorTranslator.FromHtml(entry.Value);
                            break;
                        case "ButtonPrimaryFg":
                            Theme.Current.ButtonPrimaryFg = ColorTranslator.FromHtml(entry.Value);
                            break;
                        case "ToolbarBackground":
                            Theme.Current.ToolbarBackground = ColorTranslator.FromHtml(entry.Value);
                            break;
                        case "Selection":
                            Theme.Current.Selection = ColorTranslator.FromHtml(entry.Value);
                            break;
                        case "Border":
                            Theme.Current.Border = ColorTranslator.FromHtml(entry.Value);
                            break;
                        case "Surface":
                            Theme.Current.Surface = ColorTranslator.FromHtml(entry.Value);
                            break;
                        // FontSize 仅在新表单创建时应用，不在启动时批量修改
                    }
                }
                catch { }
            }
        }

        public static void SaveAppConfig()
        {
            var shortcuts = G.glb.lstConfig.Where(c => c.Category == "Shortcuts").ToList();
            var theme = G.glb.lstConfig.Where(c => c.Category == "Theme").ToList();
            string json = JsonConvert.SerializeObject(new
            {
                Shortcuts = shortcuts,
                Theme = theme,
            }, Formatting.Indented);
            DataFileHelper.EnsureDirectories();
            DataFileHelper.AtomicWriteText("data\\config\\app_config.json", json);
        }

        #endregion

        #region === Note Index (data/notes/_index.json) ===

        public static void LoadNoteIndex()
        {
            DataFileHelper.EnsureDirectories();
            try
            {
                string json = DataFileHelper.TryReadText("data\\notes\\_index.json");
                var index = (json != null)
                    ? JsonConvert.DeserializeObject<List<NoteIndexEntry>>(json) ?? new List<NoteIndexEntry>()
                    : new List<NoteIndexEntry>();

                // Auto-remove entries whose .md file was deleted manually
                index = index.Where(e =>
                {
                    string fp = Path.Combine(DataFileHelper.NotesDir, e.FileName ?? "");
                    return File.Exists(fp);
                }).ToList();
                // 清理所有 SysNote 入口（已迁移到 data/sysnotes/）
                var toDelete = index.Where(e => (e.Topic ?? "").StartsWith("SysNote:") || (e.Topic ?? "").StartsWith("SysNote：")).ToList();
                foreach (var entry in toDelete)
                {
                    string fp = Path.Combine(DataFileHelper.NotesDir, entry.FileName ?? "");
                    if (File.Exists(fp)) DataFileHelper.SafeDelete(fp);
                    index.Remove(entry);
                }

                // 如果 _index.json 为空或只有 SysNote 条目，从磁盘 .md 文件重建索引
                if (index.Count == 0)
                {
                    RebuildNoteIndexFromDisk(out index);
                    // 保存重建的索引
                    string newJson = JsonConvert.SerializeObject(index, Formatting.Indented);
                    DataFileHelper.AtomicWriteText("data\\notes\\_index.json", newJson);
                }

                G.glb.lstNote = index.Select(e => new NoteDocument
                {
                    GUID = e.Guid,
                    Topic = e.Topic,
                    Created = e.TagTime,
                }).ToList();

                // 启动时加载所有 Note 的 YAML 元数据（Colors, Tasks, DDLs）
                foreach (var note in G.glb.lstNote)
                    LoadNoteYamlMetadata(note);
            }
            catch { G.glb.lstNote = new List<NoteDocument>(); }
        }

        /// <summary>从 .md 文件加载 YAML 元数据填充 NoteDocument（不解析 body）</summary>
        private static void LoadNoteYamlMetadata(NoteDocument note)
        {
            try
            {
                string fp = Path.Combine(DataFileHelper.NotesDir,
                    MarkdownNoteConverter.MakeNoteFileName(note.Created, note.Topic));
                if (!File.Exists(fp)) return;
                string raw = File.ReadAllText(fp, Encoding.UTF8);
                var (yamlStr, _) = GameDocument.SplitFrontMatter(raw);
                if (string.IsNullOrEmpty(yamlStr)) return;
                var dict = GameDocument.ParseSimpleYaml(yamlStr);
                note.ParseYaml(dict);
            }
            catch { }
        }

        /// <summary>从 data/notes/NOTE_*.md 文件扫描重建索引</summary>
        private static void RebuildNoteIndexFromDisk(out List<NoteIndexEntry> index)
        {
            index = new List<NoteIndexEntry>();
            var dir = DataFileHelper.NotesDir;
            if (!Directory.Exists(dir)) return;

            foreach (var fp in Directory.GetFiles(dir, "NOTE_*.md", SearchOption.TopDirectoryOnly))
            {
                try
                {
                    string raw = File.ReadAllText(fp, Encoding.UTF8);
                    var (yaml, _) = GameDocument.SplitFrontMatter(raw);
                    if (string.IsNullOrEmpty(yaml)) continue;
                    var dict = GameDocument.ParseSimpleYaml(yaml);
                    string type = dict.TryGetValue("type", out var t) ? t?.ToString() ?? "" : "";
                    // 只索引普通 Note，跳过 SysNote、Diary 等其他类型
                    if (!string.Equals(type, "Note", StringComparison.OrdinalIgnoreCase)) continue;
                    string topic = dict.TryGetValue("topic", out var top) ? top?.ToString() ?? "" : "";
                    // 跳过 SysNote
                    if (topic.StartsWith("SysNote:") || topic.StartsWith("SysNote：")) continue;
                    string guid = dict.TryGetValue("guid", out var g) ? g?.ToString() ?? "" : "";
                    if (string.IsNullOrEmpty(guid)) guid = Guid.NewGuid().ToString();
                    DateTime created = DateTime.Today;
                    if (dict.TryGetValue("created", out var c))
                        DateTime.TryParse(c?.ToString(), out created);

                    index.Add(new NoteIndexEntry
                    {
                        Guid = guid,
                        Topic = topic,
                        TagTime = created,
                        FileName = Path.GetFileName(fp),
                    });
                }
                catch { }
            }
        }

        public static void SaveNoteIndex()
        {
            var index = G.glb.lstNote.Select(n => new NoteIndexEntry
            {
                Guid = n.GUID,
                Topic = n.Topic ?? "",
                TagTime = n.Created,
                FileName = MarkdownNoteConverter.MakeNoteFileName(n.Created, n.Topic),
            }).ToList();
            string json = JsonConvert.SerializeObject(index, Formatting.Indented);
            DataFileHelper.AtomicWriteText("data\\notes\\_index.json", json);
        }

        public static string GetNoteFilePath(string guid)
        {
            string json = DataFileHelper.TryReadText("data\\notes\\_index.json");
            if (json == null) return null;
            try
            {
                var index = JsonConvert.DeserializeObject<List<NoteIndexEntry>>(json) ?? new List<NoteIndexEntry>();
                var entry = index.Find(e => e.Guid == guid);
                if (entry != null)
                    return Path.Combine(DataFileHelper.NotesDir, entry.FileName);
            }
            catch { }
            return null;
        }

        #endregion

        #region === Literature Index (data/lits/_index.json) ===

        public static void LoadLiteratureIndex()
        {
            string json = DataFileHelper.TryReadText("data\\lits\\_index.json");
            if (json == null) return;
            try
            {
                var index = JsonConvert.DeserializeObject<List<NoteIndexEntry>>(json) ?? new List<NoteIndexEntry>();
                // Auto-remove entries whose .md file was deleted manually
                index = index.Where(e =>
                {
                    string fp = Path.Combine(DataFileHelper.LitsDir, e.FileName ?? "");
                    return File.Exists(fp);
                }).ToList();
                // Literature index entries not stored in G.glb.lstNote (populated by RebuildLiteratureList)
            }
            catch { }
        }

        public static void SaveLiteratureIndex()
        {
            var index = new List<NoteIndexEntry>();
            foreach (var lit in G.glb.lstLiterature)
            {
                index.Add(new NoteIndexEntry
                {
                    Guid = lit.GUID,
                    Topic = lit.Title ?? "",
                    TagTime = lit.Created,
                    FileName = MarkdownNoteConverter.MakeLiteratureFileName(lit.Title),
                });
            }
            string json = JsonConvert.SerializeObject(index, Formatting.Indented);
            DataFileHelper.AtomicWriteText("data\\lits\\_index.json", json);
        }

        public static string GetLiteratureFilePath(string guid)
        {
            string json = DataFileHelper.TryReadText("data\\lits\\_index.json");
            if (json == null) return null;
            try
            {
                var index = JsonConvert.DeserializeObject<List<NoteIndexEntry>>(json) ?? new List<NoteIndexEntry>();
                var entry = index.Find(e => e.Guid == guid);
                if (entry != null)
                    return Path.Combine(DataFileHelper.LitsDir, entry.FileName);
            }
            catch { }
            return null;
        }

        #endregion

        #region === Diary Index (data/diaries/_index.json) ===

        public static void LoadDiaryIndex()
        {
            string json = DataFileHelper.TryReadText("data\\diaries\\_index.json");
            if (json == null) return;
            try
            {
                var index = JsonConvert.DeserializeObject<List<DiaryIndexEntry>>(json) ?? new List<DiaryIndexEntry>();
                // Auto-remove entries whose .md file was deleted manually
                index = index.Where(e =>
                {
                    string fp = Path.Combine(DataFileHelper.DiariesDir, e.FileName ?? "");
                    return File.Exists(fp);
                }).ToList();
                G.glb.lstDiary = index.Select(e => new DiaryDocument
                {
                    GUID = e.Guid,
                    Date = e.Date,
                }).ToList();
            }
            catch { }
        }

        public static void SaveDiaryIndex()
        {
            var index = G.glb.lstDiary.Select(d => new DiaryIndexEntry
            {
                Date = d.Date,
                Guid = d.GUID,
                FileName = MarkdownNoteConverter.MakeDiaryFileName(d.Date),
            }).ToList();
            string json = JsonConvert.SerializeObject(index, Formatting.Indented);
            DataFileHelper.AtomicWriteText("data\\diaries\\_index.json", json);
        }

        public static string GetDiaryFilePath(string guid)
        {
            string json = DataFileHelper.TryReadText("data\\diaries\\_index.json");
            if (json == null) return null;
            try
            {
                var index = JsonConvert.DeserializeObject<List<DiaryIndexEntry>>(json) ?? new List<DiaryIndexEntry>();
                var entry = index.Find(e => e.Guid == guid);
                if (entry != null)
                    return Path.Combine(DataFileHelper.DiariesDir, entry.FileName);
            }
            catch { }
            return null;
        }

        #endregion

        #region === Literature Review Index (data/literature_review/_index.json) ===

        public static void LoadLiteratureReviewIndex()
        {
            string json = DataFileHelper.TryReadText("data\\literature_review\\_index.json");
            if (json == null) return;
            try
            {
                var index = JsonConvert.DeserializeObject<List<NoteIndexEntry>>(json) ?? new List<NoteIndexEntry>();
                index = index.Where(e =>
                {
                    string fp = Path.Combine(DataFileHelper.LiteratureReviewDir, e.FileName ?? "");
                    return File.Exists(fp);
                }).ToList();
                G.glb.lstLiteratureReview = index.Select(e => new LiteratureReviewDocument
                {
                    GUID = e.Guid,
                    Topic = e.Topic,
                    Created = e.TagTime,
                }).ToList();
            }
            catch { }
        }

        public static void SaveLiteratureReviewIndex()
        {
            var index = G.glb.lstLiteratureReview.Select(r => new NoteIndexEntry
            {
                Guid = r.GUID,
                Topic = r.Topic ?? "",
                TagTime = r.Created,
                FileName = MarkdownNoteConverter.MakeLiteratureReviewFileName(r.Created, r.Topic),
            }).ToList();
            string json = JsonConvert.SerializeObject(index, Formatting.Indented);
            DataFileHelper.AtomicWriteText("data\\literature_review\\_index.json", json);
        }

        public static string GetLiteratureReviewFilePath(string guid)
        {
            string json = DataFileHelper.TryReadText("data\\literature_review\\_index.json");
            if (json == null) return null;
            try
            {
                var index = JsonConvert.DeserializeObject<List<NoteIndexEntry>>(json) ?? new List<NoteIndexEntry>();
                var entry = index.Find(e => e.Guid == guid);
                if (entry != null)
                    return Path.Combine(DataFileHelper.LiteratureReviewDir, entry.FileName);
            }
            catch { }
            return null;
        }

        public static void RebuildLiteratureReviewList()
        {
            G.glb.lstLiteratureReview.Clear();

            string dir = DataFileHelper.LiteratureReviewDir;
            if (!Directory.Exists(dir)) return;

            foreach (var file in Directory.GetFiles(dir, "LREV_*.md"))
            {
                try
                {
                    var revData = GameDocument.LoadMetadataOnly(file) as LiteratureReviewDocument;
                    if (revData == null) continue;

                    G.glb.lstLiteratureReview.Add(revData);
                }
                catch { }
            }

            // 从实际 .md 文件重建索引，确保 GUID 一致
            SaveLiteratureReviewIndex();
        }

        #endregion

        #region === Literature List Rebuild ===

        public static void RebuildLiteratureList()
        {
            G.glb.lstLiterature.Clear();

            string dir = DataFileHelper.LitsDir;
            if (!Directory.Exists(dir)) return;

            foreach (var file in Directory.GetFiles(dir, "LITR_*.md"))
            {
                try
                {
                    var litData = GameDocument.LoadMetadataOnly(file) as LiteratureDocument;
                    if (litData == null) continue;

                    G.glb.lstLiterature.Add(litData);
                }
                catch { }
            }

            // 从实际 .md 文件重建索引，确保 GUID 一致
            SaveLiteratureIndex();
        }

        #endregion
    }

    public class NoteIndexEntry
    {
        public string Guid;
        public string Topic;
        public DateTime TagTime;
        public string FileName;
    }

    public class DiaryIndexEntry
    {
        public DateTime Date;
        public string Guid;
        public string FileName;
    }
}
