using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
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

    public enum EEventState : int
    {
        LogEvent,
        Succeed,
        Failed
    }
    public enum EMoneyFlowState : int
    {
        WithinSystem,
        FlowIn,
        FlowOut
    }

    public enum EAccountType : int
    {
        Assets,
        Expense,
        Liability,
        Equity,
        Income
    }

    public enum ENoteType : int
    {
        Note = 0,
        DailyReport = 1,
        Literature = 2,
        LitReview = 3,
        System = 4,
    }
}
