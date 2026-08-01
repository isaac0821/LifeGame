using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    #region Literature System


    public class RLiteratureTag
    {
        public string Title;
        public string Tag;
    }


    public class RLiteratureAuthor
    {
        public string Title;
        public string Author;
        public int Ordering;
    }
    #endregion

    #region Note System


    public class RNoteColor
    {
        public string GUID;
        public string Keyword;
        public string Color;
    }
    #endregion

    /// <summary>应用配置项（Shortcuts/Theme）</summary>
    public class CConfigEntry
    {
        public string Category; // "Shortcuts" / "Theme"
        public string Key;
        public string Value;
    }
}
