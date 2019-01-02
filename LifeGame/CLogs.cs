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
    public class RPreReqAchievement
    {
        public string Achievement;
        public string PreReqAchievement;
        public EPreReq PreReqLogic;
    }

    public enum ECheckState : int
    {
        Waiting,
        Succeed,
        Failed
    }

    /// <summary>
    /// 外部不可控项
    /// </summary>
    public class CCheck
    {
        public string CheckName;
        public ECheckState CheckState;
        public string ContributionToAchievement;
        public int ContributionPoint;
    }

    /// <summary>
    /// 任务
    /// </summary>
    public class CTask
    {
        public string TaskName;
        public DateTime DeadLine;
        public bool IsAbort;
        public bool IsBottom;
        public bool IsInfinite;
        public bool IsFinished;
        public string ContributionToAchievement;
        public int ContributionPoint;
    }

    /// <summary>
    /// 任务与子任务关系
    /// </summary>
    public class RSubTask
    {
        public string Task;
        public string SubTask;
    }

    /// <summary>
    /// 日志
    /// </summary>
    public class CLog
    {
        public string LogName;
        public DateTime StartTime;
        public DateTime EndTime;
        public string ContributionToTask;
        public int ProgressPercentageToTask;
        public string Location;
        public string WithWho;
        public string Color;
    }

    /// <summary>
    /// 开支，目前只支持一借一贷的形式
    /// </summary>
    public class CMoneyDetail
    {
        public string Summary;
        public DateTime Date;
        public string DebitAccount;
        public string CreditAccount;
        public double Amount;
        public string DebitCurrency;
        public string CreditCurrency;
        public string RelateToTask;
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
    public class RSubAccount
    {
        public string Account;
        public string SubAccount;
    }

    /// <summary>
    /// 起居记录
    /// </summary>
    public class CHealth
    {
        public DateTime Date;
        public DateTime GetUpTime;
        public DateTime GoToBedTime;
        public bool IsGoToBedBeforeMidNight;
        public double Weight;
    }

    /// <summary>
    /// 锻炼记录
    /// </summary>
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
    public class CMedicine
    {
        public DateTime Date;
        public string MedicineName;
        public DateTime TakenTime;
        public double MedicineQty;
        public string MedicineUnit;
    }
}
