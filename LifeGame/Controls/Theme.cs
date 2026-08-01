using System.Drawing;

namespace LifeGame
{
    public enum ThemeMode
    {
        Light,
        Dark
    }

    /// <summary>全局主题配色系统</summary>
    public class Theme
    {
        // 注意：静态字段按文本顺序初始化，LightTheme/DarkTheme 必须在 Current 之前
        public static Theme Current { get; private set; }

        // ---- Light Mode (米黄色暖色调) ----
        public static readonly Theme LightTheme = new Theme
        {
            Mode = ThemeMode.Light,
            // 主背景
            FormBackground = Color.FromArgb(245, 242, 235),
            PanelBackground = Color.FromArgb(252, 250, 245),
            // 卡片 / 工具栏
            Surface = Color.FromArgb(255, 252, 247),
            ToolbarBackground = Color.FromArgb(248, 244, 235),
            // 文字
            TextPrimary = Color.FromArgb(60, 50, 40),
            TextSecondary = Color.FromArgb(140, 130, 115),
            TextMuted = Color.FromArgb(180, 170, 155),
            // 主色调（暖蓝）
            Accent = Color.FromArgb(90, 130, 180),
            AccentLight = Color.FromArgb(215, 225, 240),
            // 边框
            Border = Color.FromArgb(225, 218, 205),
            BorderLight = Color.FromArgb(235, 230, 220),
            // 选中
            Selection = Color.FromArgb(225, 218, 205),
            SelectionText = Color.FromArgb(60, 50, 40),
            // 行
            RowBackground = Color.Transparent,
            RowHover = Color.FromArgb(248, 244, 235),
            RowSeparator = Color.FromArgb(235, 230, 220),
            // 展开箭头
            ExpandArrow = Color.FromArgb(160, 150, 135),
            // 缩进引导线
            Guideline = Color.FromArgb(215, 208, 195),
            // 进度条
            ProgressBarBackground = Color.FromArgb(225, 218, 205),
            ProgressBarFill = Color.FromArgb(90, 130, 180),
            // 按钮
            ButtonPrimaryBg = Color.FromArgb(90, 130, 180),
            ButtonPrimaryFg = Color.White,
            ButtonSecondaryBg = Color.FromArgb(245, 242, 235),
            ButtonSecondaryFg = Color.FromArgb(90, 130, 180),
            // 搜索框
            SearchBoxBorder = Color.FromArgb(200, 192, 178),
            // 菜单
            MenuBarBg = Color.FromArgb(240, 236, 225),
            MenuBarFg = Color.FromArgb(60, 50, 40),
            // 图标显示背景
            IconBg = Color.Transparent,
            // 日程表
            ScheduleBg = Color.FromArgb(255, 252, 247),
            ScheduleTodayHighlight = Color.FromArgb(255, 245, 230),
            // Tag 标签（浅色背景上）
            TagPalette = new[]
            {
                Color.FromArgb(225, 218, 205),
                Color.FromArgb(215, 225, 215),
                Color.FromArgb(235, 220, 210),
                Color.FromArgb(220, 220, 235),
                Color.FromArgb(240, 225, 220),
                Color.FromArgb(215, 235, 220),
                Color.FromArgb(230, 225, 210),
                Color.FromArgb(218, 228, 228),
            },
            TagForeColor = Color.FromArgb(80, 70, 60),
            // Top bar
            TopBarBg = Color.FromArgb(248, 244, 235),
        };

        // ---- Dark Mode (深色主题) ----
        public static readonly Theme DarkTheme = new Theme
        {
            Mode = ThemeMode.Dark,
            FormBackground = Color.FromArgb(24, 24, 27),
            PanelBackground = Color.FromArgb(28, 28, 32),
            Surface = Color.FromArgb(35, 35, 40),
            ToolbarBackground = Color.FromArgb(32, 32, 36),
            TextPrimary = Color.FromArgb(240, 240, 235),
            TextSecondary = Color.FromArgb(170, 168, 160),
            TextMuted = Color.FromArgb(110, 108, 100),
            Accent = Color.FromArgb(120, 175, 240),
            AccentLight = Color.FromArgb(45, 55, 72),
            Border = Color.FromArgb(55, 55, 60),
            BorderLight = Color.FromArgb(42, 42, 46),
            Selection = Color.FromArgb(50, 60, 78),
            SelectionText = Color.FromArgb(245, 245, 240),
            RowBackground = Color.FromArgb(28, 28, 32),
            RowHover = Color.FromArgb(38, 38, 44),
            RowSeparator = Color.FromArgb(42, 42, 46),
            ExpandArrow = Color.FromArgb(140, 138, 130),
            Guideline = Color.FromArgb(48, 48, 52),
            ProgressBarBackground = Color.FromArgb(50, 50, 54),
            ProgressBarFill = Color.FromArgb(120, 175, 240),
            ButtonPrimaryBg = Color.FromArgb(120, 175, 240),
            ButtonPrimaryFg = Color.FromArgb(24, 24, 27),
            ButtonSecondaryBg = Color.FromArgb(42, 42, 46),
            ButtonSecondaryFg = Color.FromArgb(200, 198, 190),
            SearchBoxBorder = Color.FromArgb(60, 60, 65),
            MenuBarBg = Color.FromArgb(32, 32, 36),
            MenuBarFg = Color.FromArgb(220, 218, 210),
            IconBg = Color.Transparent,
            ScheduleBg = Color.FromArgb(32, 32, 36),
            ScheduleTodayHighlight = Color.FromArgb(55, 50, 38),
            TagPalette = new[]
            {
                Color.FromArgb(55, 50, 42),
                Color.FromArgb(42, 55, 42),
                Color.FromArgb(55, 42, 50),
                Color.FromArgb(42, 42, 60),
                Color.FromArgb(60, 50, 42),
                Color.FromArgb(38, 55, 48),
                Color.FromArgb(50, 48, 42),
                Color.FromArgb(45, 52, 52),
            },
            TagForeColor = Color.FromArgb(220, 215, 205),
            TopBarBg = Color.FromArgb(32, 32, 36),
        };

        public ThemeMode Mode { get; private set; }

        static Theme()
        {
            Current = LightTheme;
        }

        public Color FormBackground;
        public Color PanelBackground;
        public Color Surface;
        public Color ToolbarBackground;
        public Color TextPrimary;
        public Color TextSecondary;
        public Color TextMuted;
        public Color Accent;
        public Color AccentLight;
        public Color Border;
        public Color BorderLight;
        public Color Selection;
        public Color SelectionText;
        public Color RowBackground;
        public Color RowHover;
        public Color RowSeparator;
        public Color ExpandArrow;
        public Color Guideline;
        public Color ProgressBarBackground;
        public Color ProgressBarFill;
        public Color ButtonPrimaryBg;
        public Color ButtonPrimaryFg;
        public Color ButtonSecondaryBg;
        public Color ButtonSecondaryFg;
        public Color SearchBoxBorder;
        public Color MenuBarBg;
        public Color MenuBarFg;
        public Color IconBg;
        public Color ScheduleBg;
        public Color ScheduleTodayHighlight;
        public Color[] TagPalette;
        public Color TagForeColor;
        public Color TopBarBg;

        public static void SetTheme(ThemeMode mode)
        {
            Current = mode == ThemeMode.Light ? LightTheme : DarkTheme;
        }

        public static void Toggle()
        {
            Current = Current.Mode == ThemeMode.Light ? DarkTheme : LightTheme;
        }
    }
}
