using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    public class CalAndFind
    {
        /// <summary>
        /// 寻找一项task的所有子节点 Done: 01/06/2019
        /// </summary>
        /// <param name="TaskName"></param>
        /// <param name="rSubTasks"></param>
        /// <returns></returns>
        public List<string> FindAllBottomTask(string TaskName, List<RSubTask> rSubTasks)
        {
            List<string> ret = new List<string>();
            ret.Add(TaskName);
            bool IsExpandFinish = true;
            do
            {
                // 全部展开Flag置为完成
                IsExpandFinish = true;
                // 临时存放展开中间状态
                List<string> tmp = new List<string>();
                // 每次循环遍历ret现有元素是否都已经被展开完毕
                for (int i = 0; i < ret.Count; i++)
                {
                    // 如果某个元素未被展开
                    if (rSubTasks.Exists(o => o.Task == ret[i]))
                    {
                        // 索引出所有该task的subTask，代替该元素存入tmp
                        List<RSubTask> subs = rSubTasks.FindAll(o => o.Task == ret[i]).ToList();
                        subs = subs.OrderBy(o => o.index).ToList();
                        foreach (RSubTask subTask in subs)
                        {
                            tmp.Add(subTask.SubTask);
                        }
                        // 全部展开完毕的flag置为false
                        IsExpandFinish = false;
                    }
                    // 如果某个元素已经被展开，保留进入tmp中间状态
                    else
                    {
                        tmp.Add(ret[i]);
                    }
                }
                // 如果不是全部都展开完了，用tmp替代ret
                if (!IsExpandFinish)
                {
                    ret = tmp.ToList();
                }
            } while (!IsExpandFinish);
            return ret;
        }

        /// <summary>
        /// 寻找一项task的所有子孙Task，各层级都要 Done: 01/06/2019
        /// </summary>
        /// <param name="TaskName"></param>
        /// <param name="rSubTasks"></param>
        /// <returns></returns>
        public List<string> FindAllHeirTask(string TaskName, List<RSubTask> rSubTasks)
        {
            List<string> ret = new List<string>();
            ret.Add(TaskName);
            List<string> collect = new List<string>();
            collect.Add(TaskName);
            bool IsExpandFinish = true;
            do
            {
                // 全部展开Flag置为完成
                IsExpandFinish = true;
                // 临时存放展开中间状态
                List<string> tmp = new List<string>();
                // 每次循环遍历ret现有元素是否都已经被展开完毕
                for (int i = 0; i < collect.Count; i++)
                {
                    // 如果某个元素未被展开
                    if (rSubTasks.Exists(o => o.Task == collect[i]))
                    {
                        // 索引出所有该task的subTask，代替该元素存入tmp
                        List<RSubTask> subs = rSubTasks.FindAll(o => o.Task == collect[i]).ToList();
                        subs = subs.OrderBy(o => o.index).ToList();
                        foreach (RSubTask subTask in subs)
                        {
                            tmp.Add(subTask.SubTask);
                            ret.Add(subTask.SubTask);
                        }
                        // 全部展开完毕的flag置为false
                        IsExpandFinish = false;
                    }
                }
                // 如果不是全部都展开完了，用tmp替代ret
                if (!IsExpandFinish)
                {
                    collect = tmp.ToList();
                }
            } while (!IsExpandFinish);
            return ret;
        }

        /// <summary>
        /// 寻找一项account的所有子孙Account，各层级都要 Done: 01/06/2019
        /// </summary>
        /// <param name="AccountName"></param>
        /// <param name="rSubAccounts"></param>
        /// <returns></returns>
        public List<string> FindAllHeirAccount(string AccountName, List<RSubAccount> rSubAccounts)
        {
            List<string> ret = new List<string>();
            ret.Add(AccountName);
            List<string> collect = new List<string>();
            collect.Add(AccountName);
            bool IsExpandFinish = true;
            do
            {
                // 全部展开Flag置为完成
                IsExpandFinish = true;
                // 临时存放展开中间状态
                List<string> tmp = new List<string>();
                // 每次循环遍历ret现有元素是否都已经被展开完毕
                for (int i = 0; i < collect.Count; i++)
                {
                    // 如果某个元素未被展开
                    if (rSubAccounts.Exists(o => o.Account == collect[i]))
                    {
                        // 索引出所有该task的subAccount，代替该元素存入tmp
                        List<RSubAccount> subs = rSubAccounts.FindAll(o => o.Account == collect[i]).ToList();
                        subs = subs.OrderBy(o => o.index).ToList();
                        foreach (RSubAccount subAccount in subs)
                        {
                            tmp.Add(subAccount.SubAccount);
                            ret.Add(subAccount.SubAccount);
                        }
                        // 全部展开完毕的flag置为false
                        IsExpandFinish = false;
                    }
                }
                // 如果不是全部都展开完了，用tmp替代ret
                if (!IsExpandFinish)
                {
                    collect = tmp.ToList();
                }
            } while (!IsExpandFinish);
            return ret;
        }

        /// <summary>
        /// 返回task累计花费时间
        /// </summary>
        /// <param name="TaskName">任务名</param>
        /// <param name="rSubTasks">任务关系列表</param>
        /// <param name="logs">日志列表</param>
        /// <returns></returns>
        public double CalTimeSpentInTask(string TaskName, List<RSubTask> rSubTasks, List<CLog> logs)
        {
            List<string> subTasks = FindAllBottomTask(TaskName, rSubTasks);
            double ret = 0;
            foreach (string subTask in subTasks)
            {
                List<CLog> logForSubTask = logs.FindAll(o => o.ContributionToTask == subTask).ToList();
                foreach (CLog log in logForSubTask)
                {
                    TimeSpan timeSpan = log.EndTime - log.StartTime;
                    ret += timeSpan.TotalHours;
                }
            }
            return ret;
        }


        /// <summary>
        /// 找到所有heir中未完成且未被放弃的任务中deadline最小的
        /// </summary>
        /// <param name="TaskName"></param>
        /// <param name="rSubTasks"></param>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public DateTime FindNextTimeMarker(string TaskName, List<RSubTask> rSubTasks, List<CTask> tasks)
        {
            DateTime ret = new DateTime(9998, 12, 31);
            List<string> heirTasks = FindAllHeirTask(TaskName, rSubTasks);
            foreach (string heir in heirTasks)
            {
                if (G.glb.lstTask.Find(o => o.TaskName == heir).DeadLine < ret
                    && G.glb.lstTask.Find(o => o.TaskName == heir).IsAbort == false
                    && G.glb.lstTask.Find(o => o.TaskName == heir).IsFinished == false)
                {
                    ret = G.glb.lstTask.Find(o => o.TaskName == heir).DeadLine;
                }
            }
            return ret;
        }

        /// <summary>
        /// 删除task，只有task及subtask都没有log记录的task能够被删除
        /// </summary>
        /// <param name="TaskName"></param>
        /// <param name="rSubTasks"></param>
        /// <param name="tasks"></param>
        public bool DeleteTask(string TaskName, List<RSubTask> rSubTasks, List<CTask> tasks, List<CLog> logs, List<CLog> schedules)
        {
            bool CanDeleteFlag = true;
            List<string> bottomTask = FindAllBottomTask(TaskName, rSubTasks);
            foreach (string bottom in bottomTask)
            {
                if (logs.Exists(o => o.ContributionToTask == bottom))
                {
                    CanDeleteFlag = false;
                    break;
                }
                if (schedules.Exists(o => o.ContributionToTask == bottom))
                {
                    CanDeleteFlag = false;
                    break;
                }
            }

            if (CanDeleteFlag)
            {
                List<string> heirTask = FindAllHeirTask(TaskName, rSubTasks);
                foreach (string heir in heirTask)
                {
                    G.glb.lstSubTask.RemoveAll(o => o.SubTask == heir);
                    G.glb.lstTask.RemoveAll(o => o.TaskName == heir);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Can not delete a task with data related to it.");
            }

            return CanDeleteFlag;
        }

        /// <summary>
        /// 删除Account，只有Account及subAccount都没有transaction记录和transactionDue记录的account能够被删除
        /// </summary>
        /// <param name="AccountName"></param>
        /// <param name="rSubAccounts"></param>
        /// <param name="tasks"></param>
        public bool DeleteAccount(string AccountName, List<RSubAccount> rSubAccounts, List<CAccount> tasks, List<CTransaction> transactions, List<CTransaction> transactionDues)
        {
            bool CanDeleteFlag = true;
            List<string> HeirAccount = FindAllHeirAccount(AccountName, rSubAccounts);
            foreach (string heir in HeirAccount)
            {
                if (transactions.Exists(o => o.CreditAccount == heir || o.DebitAccount == heir))
                {
                    CanDeleteFlag = false;
                    break;
                }
                if (transactionDues.Exists(o => o.CreditAccount == heir || o.DebitAccount == heir))
                {
                    CanDeleteFlag = false;
                    break;
                }
            }

            if (CanDeleteFlag)
            {
                List<string> heirAccount = FindAllHeirAccount(AccountName, rSubAccounts);
                foreach (string heir in heirAccount)
                {
                    G.glb.lstSubAccount.RemoveAll(o => o.SubAccount == heir);
                    G.glb.lstAccount.RemoveAll(o => o.AccountName == heir);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Can not delete an account with data related to it.");
            }

            return CanDeleteFlag;
        }

        /// <summary>
        /// 更新一个task的finish状态，通常由于上下级节点关系变化而调用
        /// </summary>
        /// <param name="TaskName"></param>
        /// <param name="rSubTasks"></param>
        /// <param name="tasks"></param>
        public void RefreshFinishTask(string TaskName, List<RSubTask> rSubTasks, List<CTask> tasks)
        {
            if (TaskName != "(Root)")
            {
                string upperTask = rSubTasks.Find(o => o.SubTask == TaskName).Task;
                bool IsTaskFinished = true;
                List<RSubTask> children = rSubTasks.FindAll(o => o.Task == TaskName);
                if (children.Count == 0 && tasks.Find(o => o.TaskName == TaskName).IsBottom != true)
                {
                    IsTaskFinished = false;
                }
                foreach (RSubTask task in children)
                {
                    if (tasks.Find(o => o.TaskName == task.SubTask).IsFinished == false)
                    {
                        IsTaskFinished = false;
                        break;
                    }
                }
                tasks.Find(o => o.TaskName == TaskName).IsFinished = IsTaskFinished;
                RefreshFinishTask(upperTask, rSubTasks, tasks);
            }
        }

        /// <summary>
        /// 完成一个task
        /// </summary>
        /// <param name="TaskName"></param>
        /// <param name="rSubTasks"></param>
        /// <param name="tasks"></param>
        public void FinishTask(string TaskName, List<RSubTask> rSubTasks, List<CTask> tasks)
        {
            string upperTask = rSubTasks.Find(o => o.SubTask == TaskName).Task;
            tasks.Find(o => o.TaskName == TaskName).IsFinished = true;
            if (upperTask != "(Root)")
            {
                bool IsUpperTaskFinished = true;
                List<RSubTask> sameLevel = rSubTasks.FindAll(o => o.Task == upperTask);
                foreach (RSubTask task in sameLevel)
                {
                    if (tasks.Find(o => o.TaskName == task.SubTask).IsFinished == false)
                    {
                        IsUpperTaskFinished = false;
                        break;
                    }
                }
                if (IsUpperTaskFinished)
                {
                    FinishTask(upperTask, rSubTasks, tasks);
                }
            }
        }

        /// <summary>
        /// 将原本标记为finished的任务改为unfinished
        /// </summary>
        /// <param name="TaskName"></param>
        /// <param name="rSubTasks"></param>
        /// <param name="tasks"></param>
        public void UnfinishTask(string TaskName, List<RSubTask> rSubTasks, List<CTask> tasks)
        {
            string upperTask = rSubTasks.Find(o => o.SubTask == TaskName).Task;
            tasks.Find(o => o.TaskName == TaskName).IsFinished = false;
            if (upperTask != "(Root)")
            {
                UnfinishTask(upperTask, rSubTasks, tasks);
            }
        }

        /// <summary>
        /// 放弃执行一个task
        /// </summary>
        /// <param name="TaskName"></param>
        /// <param name="rSubTasks"></param>
        /// <param name="tasks"></param>
        public void AbortTask(string TaskName, List<RSubTask> rSubTasks, List<CTask> tasks)
        {
            if (tasks.Exists(o => o.TaskName == TaskName))
            {
                tasks.Find(o => o.TaskName == TaskName).IsAbort = true;
            }
            if (rSubTasks.Exists(o => o.Task == TaskName))
            {
                List<RSubTask> subOfThisTask = rSubTasks.FindAll(o => o.Task == TaskName).ToList();
                foreach (RSubTask sub in subOfThisTask)
                {
                    if (tasks.Exists(o => o.TaskName == sub.SubTask))
                    {
                        AbortTask(sub.SubTask, rSubTasks, tasks);
                    }
                }
            }
        }

        /// <summary>
        /// 重新执行某个task
        /// </summary>
        /// <param name="TaskName"></param>
        /// <param name="rSubTasks"></param>
        /// <param name="tasks"></param>
        public void ReAssignTask(string TaskName, List<RSubTask> rSubTasks, List<CTask> tasks)
        {
            if (tasks.Exists(o => o.TaskName == TaskName))
            {
                tasks.Find(o => o.TaskName == TaskName).IsAbort = false;
            }
            if (rSubTasks.Exists(o => o.Task == TaskName))
            {
                List<RSubTask> subOfThisTask = rSubTasks.FindAll(o => o.Task == TaskName).ToList();
                foreach (RSubTask sub in subOfThisTask)
                {
                    if (tasks.Exists(o => o.TaskName == sub.SubTask))
                    {
                        ReAssignTask(sub.SubTask, rSubTasks, tasks);
                    }
                }
            }
        }

        /// <summary>
        /// 判断“钱是花掉了还是赚了” （资金是用贷方流向借方）
        /// 
        /// </summary>
        /// <param name="DebitAccountType">借方科目</param>
        /// <param name="CreditAccountType">贷方科目</param>
        /// <returns></returns>
        public EMoneyFlowState MoneyInOrOut(EAccountType DebitAccountType, EAccountType CreditAccountType)
        {
            EMoneyFlowState ret = EMoneyFlowState.WithinSystem;
            // 若资金从Income类科目流入至Asset类转化为资产，资金为流入
            if (CreditAccountType == EAccountType.Income && DebitAccountType != EAccountType.Expense)
            {
                ret = EMoneyFlowState.FlowIn;
            }
            else if (CreditAccountType != EAccountType.Income && DebitAccountType == EAccountType.Expense)
            {
                ret = EMoneyFlowState.FlowOut;
            }
            return ret;
        }

        public struct SBalance
        {
            public double OpeningBalanceDebit;
            public double OpeningBalanceCredit;
            public double AmountDebit;
            public double AmountCredit;
            public double EndingBalanceDebit;
            public double EndingBalanceCredit;
        }

        public SBalance CalBalance(
            string AccountName,
            List<CAccount> accounts,
            List<RSubAccount> rSubAccounts,
            List<CTransaction> transactions,
            List<RCurrencyRate> currencyRates,
            DateTime StartTime,
            DateTime EndTime)
        {
            double retOpeningBalanceDebit = 0;
            double retOpeningBalanceCredit = 0;
            double retAmountDebit = 0;
            double retAmountCredit = 0;
            double retEndingBalanceDebit = 0;
            double retEndingBalanceCredit = 0;
            // 找到所有的Heir科目
            CalAndFind C = new CalAndFind();
            List<string> heirAccount = C.FindAllHeirAccount(AccountName, rSubAccounts);
            List<CTransaction> TransactionsInRange = transactions.FindAll(
                o => o.TagTime >= StartTime
                && o.TagTime <= EndTime
                && heirAccount.Exists(
                    p => p == o.DebitAccount
                    || p == o.CreditAccount)).ToList();
            foreach (CTransaction transaction in TransactionsInRange)
            {
                if (heirAccount.Exists(o => o == transaction.DebitAccount))
                {
                    if (transaction.DebitCurrency == accounts.Find(o => o.AccountName == AccountName).Currency)
                    {
                        retAmountDebit += transaction.DebitAmount;
                    }
                    else
                    {
                        if (currencyRates.Exists(o => o.CurrencyA == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyB == transaction.DebitCurrency))
                        {
                            retAmountDebit += transaction.DebitAmount / currencyRates.Find(o => o.CurrencyA == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyB == transaction.DebitCurrency).Rate;
                        }
                        else if ((currencyRates.Exists(o => o.CurrencyB == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyA == transaction.DebitCurrency)))
                        {
                            retAmountDebit += transaction.DebitAmount * currencyRates.Find(o => o.CurrencyB == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyA == transaction.DebitCurrency).Rate;
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Lack of exchange rate of " + transaction.DebitCurrency + " → " + accounts.Find(o => o.AccountName == AccountName).Currency);
                        }
                    }
                }
                if (heirAccount.Exists(o => o == transaction.CreditAccount))
                {
                    if (transaction.CreditCurrency == accounts.Find(o => o.AccountName == AccountName).Currency)
                    {
                        retAmountCredit += transaction.CreditAmount;
                    }
                    else
                    {
                        if (currencyRates.Exists(o => o.CurrencyA == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyB == transaction.CreditCurrency))
                        {
                            retAmountCredit += transaction.CreditAmount / currencyRates.Find(o => o.CurrencyA == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyB == transaction.CreditCurrency).Rate;
                        }
                        else if (currencyRates.Exists(o => o.CurrencyB == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyA == transaction.CreditCurrency))
                        {
                            retAmountCredit += transaction.CreditAmount * currencyRates.Find(o => o.CurrencyB == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyA == transaction.CreditCurrency).Rate;
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Lack of exchange rate of " + transaction.CreditCurrency + " → " + accounts.Find(o => o.AccountName == AccountName).Currency);
                        }
                    }
                }
            }
            // 目前账目等均以2019.1.1开始，之前默认为无数据
            if (EndTime >= new DateTime(2019, 1, 1))
            {
                SBalance toStart = CalBalance(AccountName, accounts, rSubAccounts, transactions, currencyRates, new DateTime(2019, 1, 1), StartTime.AddDays(-1));
                if (toStart.EndingBalanceDebit - toStart.EndingBalanceCredit > 0)
                {
                    retOpeningBalanceDebit = toStart.EndingBalanceDebit - toStart.EndingBalanceCredit;
                    retOpeningBalanceCredit = 0;
                }
                else
                {
                    retOpeningBalanceDebit = 0;
                    retOpeningBalanceCredit = -(toStart.EndingBalanceDebit - toStart.EndingBalanceCredit);
                }
            }
            else
            {
                retOpeningBalanceDebit = 0;
                retOpeningBalanceCredit = 0;
            }
            double abs = (retOpeningBalanceDebit + retAmountDebit) - (retOpeningBalanceCredit + retAmountCredit);
            if (abs > 0)
            {
                retEndingBalanceDebit = abs;
                retEndingBalanceCredit = 0;
            }
            else
            {
                retEndingBalanceDebit = 0;
                retEndingBalanceCredit = -abs;
            }

            SBalance ret = new SBalance();
            ret.OpeningBalanceDebit = retOpeningBalanceDebit;
            ret.OpeningBalanceCredit = retOpeningBalanceCredit;
            ret.AmountDebit = retAmountDebit;
            ret.AmountCredit = retAmountCredit;
            ret.EndingBalanceDebit = retEndingBalanceDebit;
            ret.EndingBalanceCredit = retEndingBalanceCredit;
            return ret;
        }
    }
}
