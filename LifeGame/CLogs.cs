﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    [Serializable]
    public enum EEventState : int
    {
        LogEvent,
        Succeed,
        Failed
    }

    /// <summary>
    /// 文献类
    /// </summary>
    [Serializable]
    public class CLiterature
    {
        public string Title;
        public int PublishYear;
        public ELiteratureImportance Importance;
        public ELiteratureReadingStatus ReadingStatus;
        public string JournalOrConferenceName;
        public string InOneSentence;
    }

    [Serializable]
    public enum ELiteratureImportance: int
    {
        VeryImportant,
        Important,
        Medium,
        Unimportant
    }

    [Serializable]
    public enum ELiteratureReadingStatus : int
    {
        ModelRecur,
        FormulaDerivation,
        UnderstandModel,
        GetIdeaAndStructure,
        AbstractAndConclusion,
        NotYetStarted,
    }

    /// <summary>
    /// 自己引用的参考文献
    /// </summary>
    [Serializable]
    public class RLiteratureInCiting
    {
        public string Title;
        public string TitleOfMyArticle;
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
    /// 文献机构
    /// </summary>
    [Serializable]
    public class RLiteratureInstitution
    {
        public string Title;
        public string Institution;
    }

    /// <summary>
    /// 笔记
    /// </summary>
    [Serializable]
    public class CNote
    {
        public DateTime TagTime;
        public string Topic;
        public string LiteratureTitle;
        public bool FinishedNote;
    }

    /// <summary>
    /// 笔记的外部链接路径
    /// </summary>
    [Serializable]
    public class RNoteOutsource
    {
        public DateTime TagTime;
        public string Topic;
        public string Outsourcepath;
    }

    /// <summary>
    /// 笔记记录
    /// </summary>
    [Serializable]
    public class RNoteLog
    {
        public string Topic;
        public DateTime TagTime;
        public string Log;
        public string SubLog;
        public int Index;
        public int LogoIndex;
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

    /// <summary>
    /// 锻炼记录
    /// </summary>
    [Serializable]
    public class CWorkOut
    {
        public DateTime TagTime;
        public string WorkOutType;        
        public double WorkOutQty;
        public string WorkOutUnit;
        public string Location;
    }

    /// <summary>
    /// 药物记录
    /// </summary>
    [Serializable]
    public class CMedicine
    {
        public DateTime TagTime;
        public EMedicineTiming MedicineTime;
        public string MedicineName;        
        public double MedicineQty;
        public string MedicineUnit;
    }

    [Serializable]
    public enum EMedicineTiming: int
    {
        BeforeBreakfast,
        AfterBreakfast,
        BeforeLunch,
        AfterLunch,
        BeforeDinner,
        AfterDinner,
        BeforeSleep,
        WhenNeeded
    }

    /// <summary>
    /// 任务
    /// </summary>
    [Serializable]
    public class CTask
    {
        public string TaskName;
        public DateTime DeadLine;
        public bool IsFinished;
        public bool IsBottom;
        public bool IsAbort;
        public bool IsInfinite;
    }

    /// <summary>
    /// 任务与子任务关系
    /// </summary>
    [Serializable]
    public class RSubTask
    {
        public string Task;
        public string SubTask;
        public int index;
    }

    /// <summary>
    /// 日志
    /// </summary>
    [Serializable]
    public class CLog
    {
        public string LogName;
        public DateTime StartTime;
        public DateTime EndTime;
        public string ContributionToTask;
        public string Location;
        public string WithWho;
        public string Color;
    }

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

    /// <summary>
    /// 预计收入支出
    /// </summary>
    [Serializable]
    public class CTransactionDue
    {
        public string Summary;
        public DateTime TagTime;
        public string Account;
        public ETransactionDueType TransactionDueType;
        public double FixedAmount;
        public DateTime BalanceDate;
        public string Amount;
        public string Currency;
        public bool DebitOrCredit;
    }

    [Serializable]
    public enum ETransactionDueType: int
    {
        Fixed,
        RemainingBalanceAtSomeDate,
        RemainingBalance
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
    public enum EAccountType: int
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

    /// <summary>
    /// 睡眠记录
    /// </summary>
    [Serializable]
    public class CSleep
    {
        public DateTime Date;
        public DateTime GetUpTime;
        public DateTime GoToBedTime;
        public bool IsGoToBedBeforeMidNight;
    }


}
