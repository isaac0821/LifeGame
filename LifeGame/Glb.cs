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
        // Achievement
        public List<CAchievement> lstAchievement = new List<CAchievement>();
        public List<RPreReqAchievement> lstPreReqAchievement = new List<RPreReqAchievement>();

        // Event
        public List<CEvent> lstEvent = new List<CEvent>();
        public List<CSleep> lstSleepSchedule = new List<CSleep>();
        public List<CSleep> lstSleepLog = new List<CSleep>();
        public List<CWorkOut> lstWorkOut = new List<CWorkOut>();
        public List<CMedicine> lstMedicine = new List<CMedicine>();
        public List<CMeeting> lstMeeting = new List<CMeeting>();
        public List<RMeetingLog> lstMeetingLog = new List<RMeetingLog>();
 
        // Literature
        public List<CLiterature> lstLiterature = new List<CLiterature>();
        public List<CLiteratureReadingLog> lstLiteratureLog = new List<CLiteratureReadingLog>();
        public List<RLiteratureAuthor> lstLiteratureAuthors = new List<RLiteratureAuthor>();
        public List<RLiteratureTag> lstLiteratureTag = new List<RLiteratureTag>();
        public List<RLiteratureCited> lstLiteratureCited = new List<RLiteratureCited>();
        public List<RLiteratureInstitution> lstLiteratureInstitution = new List<RLiteratureInstitution>();

        // Task and Log
        public List<CTask> lstTask = new List<CTask>();
        public List<RSubTask> lstSubTask = new List<RSubTask>();
        public List<CLog> lstSchedule = new List<CLog>();
        public List<CLog> lstLog = new List<CLog>();

        // Money
        public List<CTransaction> lstTransaction = new List<CTransaction>();
        public List<CTransactionDue> lstTransactionDue = new List<CTransactionDue>();
        public List<CAccount> lstAccount = new List<CAccount>();
        public List<RSubAccount> lstSubAccount = new List<RSubAccount>();
   }
}
