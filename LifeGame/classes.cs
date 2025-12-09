using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    #region 文献系统
    /// <summary>
    /// 文献类
    /// </summary>
    [Serializable]
    public class CLiterature
    {
        public string Title;
        public string GUID;
        public DateTime DateAdded;
        public DateTime DateModified;
        public int PublishYear;
        public string JournalOrConferenceName;
        public bool Star;

        public string BibKey;

        // BibTeX
        public EBibEntry BibEntry;
        public string Address;
        public string Annote;
        public string Author;
        public string Booktitle;
        public string Chapter;
        public string Crossref;
        public string Doi;
        public string Edition;
        public string Editor;
        public string Howpublished;
        public string Institution;
        public string Journal;
        public string Key;
        public string Month;
        public string Note;
        public string Number;
        public string Organization;
        public string Pages;
        public string Publisher;
        public string School;
        public string Series;
        public string Type;
        public string Volume;
        public string Year;
    }

    [Serializable]
    public class CLiteratureTag
    {
        public string Tag;
        public string GUID;
    }

    [Serializable]
    public class RSubLiteratureTag
    {
        public string Tag;
        public string GUID;
        public string SubTag;
        public string SubGUID;
        public int Ordering;
    }

    [Serializable]
    public class RLiteratureTag
    {
        public string Title;
        public string Tag;
    }

    [Serializable]
    public class RLiteratureAuthor
    {
        public string Title;
        public string Author;
        public int Ordering;
    }
    #endregion

    #region 每日系统

    [Serializable]
    public class CDiary
    {
        public DateTime Date;
        public string GUID;
    }

    [Serializable]
    public class CLog
    {
        public string LogName;
        public DateTime StartTime;
        public DateTime EndTime;
        public string Location;
        public string WithWho;
        public string Color;
        public bool Alarm;
        public DateTime AlarmTime;
    }

    [Serializable]
    public class CEvent
    {
        public DateTime TagTime;
        public string EventName;
        public EEventState EventState;
    }
    #endregion

    #region 财务系统
    [Serializable]
    public class CTransaction
    {
        public string Summary;
        public DateTime TagTime;
        public string DebitAccount;
        public string CreditAccount;
        public double DebitAmount;
        public double CreditAmount;
        public string DebitCurrency;
        public string CreditCurrency;
        public EMoneyFlowState IconType;
    }

    [Serializable]
    public class RCurrencyRate 
    {
        public string CurrencyA;
        public string CurrencyB;
        public double Rate;
    }

    [Serializable]
    public class CAccount
    {
        public string AccountName;
        public EAccountType AccountType;
        public string Currency;
        public bool ProtectedAccount;
    }

    [Serializable]
    public class RSubAccount
    {
        public string Account;
        public string SubAccount;
        public int Ordering;
    }
    #endregion

    #region 笔记系统
    [Serializable]
    public class CNote
    {
        public string Topic;
        public DateTime TagTime;
        public string GUID;
    }

    [Serializable]
    public class RNoteLog
    {
        public string GUID;        
        public string FatherLog;
        public string FatherGUID;
        public string SubLog;
        public string SubGUID;
        public bool IsExpand;
        public int Ordering;
    }

    [Serializable]
    public class RNoteColor
    {
        public string GUID;
        public string Keyword;
        public string Color;
    }
    #endregion
}
