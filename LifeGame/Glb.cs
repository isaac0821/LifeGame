using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    public static class G
    {
        public static Mem glb = new Mem();
    }

    [Serializable]
    public class Mem
    {
        public List<CEvent> lstEvent = new List<CEvent>();
        public List<CTask> lstTask = new List<CTask>();
        public List<RSubTask> lstSubTask = new List<RSubTask>();
        public List<CLog> lstSchedule = new List<CLog>();
        public List<CLog> lstLog = new List<CLog>();
        public List<CMoneyDetail> lstMoneyDetail = new List<CMoneyDetail>();
        public List<CAccount> lstAccount = new List<CAccount>();
        public List<RSubAccount> lstSubAccount = new List<RSubAccount>();
        public List<CSleep> lstSleepSchedule = new List<CSleep>();
        public List<CSleep> lstSleepLog = new List<CSleep>();
        public List<CWorkOut> lstWorkOutSchedule = new List<CWorkOut>();
        public List<CWorkOut> lstWorkOutLog = new List<CWorkOut>();
        public List<CMedicine> lstMedicine = new List<CMedicine>();
    }
}
