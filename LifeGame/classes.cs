﻿using System;
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
        public CBibTeX BibTeX;
        public string BibKey;
        public DateTime DateAdded;
        public DateTime DateModified;
        public bool PredatoryAlert;
        public string Title;
        public int PublishYear;
        public string JournalOrConferenceName;
        public string InOneSentence;
        public bool Star;
    }

    [Serializable]
    public enum EBibEntry : int
    {
        Article,
        Book,
        Booklet,
        Conference,
        Inbook,
        Incollection,
        Manual,
        Mastersthesis,
        Misc,
        Phdthesis,
        Proceedings,
        Techreport,
        Unpublished
    }

    [Serializable]
    public class CBibTeX
    {
        public EBibEntry BibEntry;
        public string BibKey;
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
        public string Title;
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
        public int Index;
    }

    public class CJournalConf
    {
        public string Name;
        public string Abbr;
        public string Description;
        public bool isReliable;
        public bool isGarbage;
        public string Publisher;
    }

    /// <summary>
    /// 文献标签
    /// </summary>
    [Serializable]
    public class RLiteratureTag
    {
        public string Title;
        public string Tag;
    }

    /// <summary>
    /// 文献作者
    /// </summary>
    [Serializable]
    public class RLiteratureAuthor
    {
        public string Title;
        public string Author;
        public int Rank;
    }

    /// <summary>
    /// 综述
    /// </summary>
    [Serializable]
    public class CSurvey
    {
        public string SurveyTitle;
    }

    /// <summary>
    /// 综述内对文献分类用的标签，树形结构，每个标签的值可能是：布尔型，单选，字符串，数字
    /// </summary>
    [Serializable]
    public class RSurveyTag
    {
        public string SurveyTitle;
        public string Tag;
        public ESurveyTagType TagType;
    }

    [Serializable]
    public enum ESurveyTagType : int
    {
        NonBottom = 0,
        Boolean,
        SingleOption,
        String,
        Number
    }

    [Serializable]
    public class RSurveyTagValueOption
    {
        public string SurveyTitle;
        public string Tag;
        public string TagOption;
    }

    [Serializable]
    public class RSurveySubTag
    {
        public string SurveyTitle;
        public string Tag;
        public string SubTag;
        public int SubTagIndex;
    }

    [Serializable]
    public class RSurveyLiterature
    {
        public string SurveyTitle;
        public string LiteratureTitle;
    }

    [Serializable]
    public class RSurveyLiteratureTagValue
    {
        public string SurveyTitle;
        public string LiteratureTitle;
        public string Tag;
        public string TagValueString;
        public int TagValueNumber;
        public bool TagValueBoolean;
    }
    #endregion

    #region 任务系统
    /// <summary>
    /// 日志
    /// </summary>
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

    /// <summary>
    /// 外部事件
    /// </summary>
    [Serializable]
    public class CEvent
    {
        public DateTime TagTime;
        public string EventName;
        public EEventState EventState;
    }

    [Serializable]
    public enum EEventState : int
    {
        LogEvent,
        Succeed,
        Failed
    }

    #endregion

    #region 财务系统
    /// <summary>
    /// 开支，目前只支持一借一贷的形式
    /// </summary>
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
    public enum EMoneyFlowState : int
    {
        WithinSystem,
        FlowIn,
        FlowOut
    }

    [Serializable]
    public enum EAccountType : int
    {
        /// <summary>
        /// 资产
        /// </summary>
        Assets,
        /// <summary>
        /// 费用
        /// </summary>
        Expense,
        /// <summary>
        /// 负债
        /// </summary>
        Liability,
        /// <summary>
        /// 所有者权益
        /// </summary>
        Equity,
        /// <summary>
        /// 收入
        /// </summary>
        Income
    }

    /// <summary>
    /// 记账科目
    /// </summary>
    [Serializable]
    public class CAccount
    {
        public string AccountName;
        public EAccountType AccountType;
        public string Currency;
        public bool ProtectedAccount;
    }

    /// <summary>
    /// 科目上下级关系
    /// </summary>
    [Serializable]
    public class RSubAccount
    {
        public string Account;
        public string SubAccount;
        public int index;
    }
    #endregion

    #region 笔记系统
    /// <summary>
    /// 笔记
    /// </summary>
    [Serializable]
    public class CNote
    {
        public DateTime TagTime;
        public string GUID;
        public string Topic;
        public string LiteratureTitle;
        public bool FinishedNote;
        public bool Locked;
        public ENoteType NoteType;
    }
    public enum ENoteType : int
    {
        Note = 0,
        DailyReport = 1,
        Literature = 2,
        LitReview = 3,
        System = 4,
    }
    /// <summary>
    /// 笔记记录
    /// </summary>
    [Serializable]
    public class RNoteLog
    {
        public string Topic;
        public string TopicGUID;
        public DateTime TagTime;
        public string Log;  // 父节点的
        public string GUID;
        public string SubLog;  // 自己的
        public string SubGUID;
        public bool IsExpand;
        public int Index;
    }

    [Serializable]
    public class RNoteColor
    {
        public string Topic;
        public DateTime TagTime;
        public string Keyword;
        public string Color;
    }

    [Serializable]
    public class RNoteHierarchy
    {
        public string Topic;
        public string TopicGUID;
        public DateTime TagTime;
        public string Tag;
        public string SubTag;
        public int Index;
    }

    #endregion
}
