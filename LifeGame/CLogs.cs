using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    /// <summary>
    /// 前置逻辑关系
    /// </summary>
    public enum EPreReq : int
    {
        OR,
        AND,
        NOT
    }

    /// <summary>
    /// 成就
    /// </summary>
    [Serializable]
    public class CAchievement
    {
        public string AchievementName;
        public int TotalProgressPoint;
        public bool IsAchieved;
        public bool IsTerminated;
        public string IconName;
    }

    /// <summary>
    /// 成就与前置成就关系
    /// </summary>
    [Serializable]
    public class RPreReqAchievement
    {
        public string Achievement;
        public string PreReqAchievement;
        public EPreReq PreReqLogic;
    }

    public enum EEventState : int
    {
        Waiting,
        Succeed,
        Failed
    }

    /// <summary>
    /// 外部事件
    /// </summary>
    [Serializable]
    public class CEvent
    {
        public string EventName;
        public EEventState EventState;
        public string ContributionToAchievement;
        public int ContributionPoint;
    }

    /// <summary>
    /// 任务
    /// </summary>
    [Serializable]
    public class CTask
    {
        public string TaskName;
        public DateTime DeadLine;
        public bool IsAbort;
        public bool IsBottom;
        public bool IsInfinite;
        public bool IsFinished;
    }

    /// <summary>
    /// 任务对成就的贡献度
    /// </summary>
    [Serializable]
    public class RTaskContributionToAchievement
    {
        public string TaskName;
        public string ContributionToAchievement;
        public int ContributionPoint;
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
    public class CMoneyDetail
    {
        public string Summary;
        public DateTime Date;
        public string DebitAccount;
        public string CreditAccount;
        public double DebitAmount;
        public double CreditAmount;
        public string DebitCurrency;
        public string CreditCurrency;
    }

    public enum EAccountType: int
    {
        Assets,
        Liability,
        Others
    }

    /// <summary>
    /// 记账科目
    /// </summary>
    [Serializable]
    public class CAccount
    {
        public string AccountName;
        public EAccountType AccountType;
        public string Note;
        public string Currency;
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

    /// <summary>
    /// 锻炼记录
    /// </summary>
    [Serializable]
    public class CWorkOut
    {
        public DateTime Date;
        public string WorkOutType;
        public double WorkOutQty;
        public string WorkOutUnit;
    }

    /// <summary>
    /// 药物记录
    /// </summary>
    [Serializable]
    public class CMedicine
    {
        public DateTime Date;
        public string MedicineName;
        public DateTime TakenTime;
        public double MedicineQty;
        public string MedicineUnit;
    }
}
