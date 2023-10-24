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
        // Settings
        public List<string> lstGoodJournal = new List<string>();
        public List<string> lstBadJournal = new List<string>();

        // Tasks, Logs and Events
        // public List<CTask> lstTask = new List<CTask>();
        // public List<RSubTask> lstSubTask = new List<RSubTask>();
        public List<CLog> lstSchedule = new List<CLog>();
        public List<CLog> lstLog = new List<CLog>();
        public List<CEvent> lstEvent = new List<CEvent>();
        public List<CSleep> lstSleepSchedule = new List<CSleep>();
        public List<CSleep> lstSleepLog = new List<CSleep>();
        // public List<CWorkOut> lstWorkOut = new List<CWorkOut>();
        // public List<CMedicine> lstMedicine = new List<CMedicine>();

        // Finiance
        public List<CTransaction> lstTransaction = new List<CTransaction>();
        public List<CTransaction> lstBudget = new List<CTransaction>();
        public List<CAccount> lstAccount = new List<CAccount>();
        public List<RSubAccount> lstSubAccount = new List<RSubAccount>();
        public List<RCurrencyRate> lstCurrencyRate = new List<RCurrencyRate>();

        // Note
        public List<CNote> lstNote = new List<CNote>();
        public List<RNoteColor> lstNoteColor = new List<RNoteColor>();
        public List<RNoteLog> lstNoteLog = new List<RNoteLog>();
        // public List<RNoteTag> lstNoteTag = new List<RNoteTag>();

        // Literature
        public List<CLiterature> lstLiterature = new List<CLiterature>();
        public List<RLiteratureAuthor> lstLiteratureAuthor = new List<RLiteratureAuthor>();
        public List<RLiteratureTag> lstLiteratureTag = new List<RLiteratureTag>();
        public List<RLiteratureInCiting> lstLiteratureCiting = new List<RLiteratureInCiting>();
        public List<RLiteratureInstitution> lstLiteratureInstitution = new List<RLiteratureInstitution>();
        public List<RLiteratureOutSource> lstLiteratureOutSource = new List<RLiteratureOutSource>();
        public List<CAuthor> lstAuthor = new List<CAuthor>();
        public List<RAuthorAffiliation> lstAuthorAffiliation = new List<RAuthorAffiliation>();

        // Survey
        public List<CSurvey> lstSurvey = new List<CSurvey>();
        public List<RSurveyLiterature> lstSurveyLiterature = new List<RSurveyLiterature>();
        public List<RSurveyTag> lstSurveyTag = new List<RSurveyTag>();
        public List<RSurveyTagValueOption> lstSurveyTagValueOption = new List<RSurveyTagValueOption>();
        public List<RSurveySubTag> lstSurveySubTag = new List<RSurveySubTag>();
        public List<RSurveyLiteratureTagValue> lstSurveyLiteratureTagValue = new List<RSurveyLiteratureTagValue>();
    }
}
