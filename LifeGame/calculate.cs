using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    public class calculate
    {
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
            calculate C = new calculate();
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

        public SBalance CalFutureBalance(
            string AccountName,
            List<CAccount> accounts,
            List<RSubAccount> rSubAccounts,
            List<CTransaction> transactions,
            List<CTransaction> budgets,
            List<RCurrencyRate> currencyRates,
            DateTime StartTime,
            DateTime EndTime)
        {
            // Calculate The Balance without budget
            SBalance balance = CalBalance(AccountName, accounts, rSubAccounts, transactions, currencyRates, StartTime, EndTime);
            double retOpeningBalanceDebit = balance.OpeningBalanceDebit;
            double retOpeningBalanceCredit = balance.OpeningBalanceCredit;
            double retAmountDebit = balance.AmountDebit;
            double retAmountCredit = balance.AmountCredit;
            double retEndingBalanceDebit = balance.EndingBalanceDebit;
            double retEndingBalanceCredit = balance.EndingBalanceCredit;

            // 找到所有的Heir科目
            calculate C = new calculate();
            List<string> heirAccount = C.FindAllHeirAccount(AccountName, rSubAccounts);
            List<CTransaction> BudgetsInRange = budgets.FindAll(
                o => o.TagTime >= StartTime
                && o.TagTime <= EndTime
                && heirAccount.Exists(
                    p => p == o.DebitAccount
                    || p == o.CreditAccount)).ToList();
            foreach (CTransaction budget in BudgetsInRange)
            {
                if (heirAccount.Exists(o => o == budget.DebitAccount))
                {
                    if (budget.DebitCurrency == accounts.Find(o => o.AccountName == AccountName).Currency)
                    {
                        retAmountDebit += budget.DebitAmount;
                    }
                    else
                    {
                        if (currencyRates.Exists(o => o.CurrencyA == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyB == budget.DebitCurrency))
                        {
                            retAmountDebit += budget.DebitAmount / currencyRates.Find(o => o.CurrencyA == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyB == budget.DebitCurrency).Rate;
                        }
                        else if (currencyRates.Exists(o => o.CurrencyB == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyA == budget.DebitCurrency))
                        {
                            retAmountDebit += budget.DebitAmount * currencyRates.Find(o => o.CurrencyB == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyA == budget.DebitCurrency).Rate;
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Lack of exchange rate of " + budget.DebitCurrency + " → " + accounts.Find(o => o.AccountName == AccountName).Currency);
                        }
                    }
                }
                if (heirAccount.Exists(o => o == budget.CreditAccount))
                {
                    if (budget.CreditCurrency == accounts.Find(o => o.AccountName == AccountName).Currency)
                    {
                        retAmountCredit += budget.CreditAmount;
                    }
                    else
                    {
                        if (currencyRates.Exists(o => o.CurrencyA == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyB == budget.CreditCurrency))
                        {
                            retAmountCredit += budget.CreditAmount / currencyRates.Find(o => o.CurrencyA == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyB == budget.CreditCurrency).Rate;
                        }
                        else if (currencyRates.Exists(o => o.CurrencyB == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyA == budget.CreditCurrency))
                        {
                            retAmountCredit += budget.CreditAmount * currencyRates.Find(o => o.CurrencyB == accounts.Find(p => p.AccountName == AccountName).Currency && o.CurrencyA == budget.CreditCurrency).Rate;
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Lack of exchange rate of " + budget.CreditCurrency + " → " + accounts.Find(o => o.AccountName == AccountName).Currency);
                        }
                    }
                }
            }
            // 目前账目等均以2019.1.1开始，之前默认为无数据
            if (EndTime >= new DateTime(2019, 1, 1))
            {
                SBalance toStart = CalFutureBalance(AccountName, accounts, rSubAccounts, transactions, budgets, currencyRates, new DateTime(2019, 1, 1), StartTime.AddDays(-1));
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
