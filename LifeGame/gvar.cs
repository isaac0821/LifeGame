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
        // Logs and Events
        public List<CLog> lstSchedule = new List<CLog>();
        public List<CLog> lstLog = new List<CLog>();
        public List<CEvent> lstEvent = new List<CEvent>();

        // Finance
        public List<CTransaction> lstTransaction = new List<CTransaction>();
        public List<CTransaction> lstBudget = new List<CTransaction>();
        public List<CAccount> lstAccount = new List<CAccount>();
        public List<RSubAccount> lstSubAccount = new List<RSubAccount>();
        public List<RCurrencyRate> lstCurrencyRate = new List<RCurrencyRate>();

        // Note
        public List<CNote> lstNote = new List<CNote>();
        public List<RNoteColor> lstNoteColor = new List<RNoteColor>();
        public List<RNoteLog> lstNoteLog = new List<RNoteLog>();
        public List<RNoteHierarchy> lstNoteHierarchy = new List<RNoteHierarchy>();

        // Literature
        public List<CLiteratureTag> lstLiteratureTagType = new List<CLiteratureTag>();
        public List<RSubLiteratureTag> lstSubLiteratureTag = new List<RSubLiteratureTag>();
        public List<CLiterature> lstLiterature = new List<CLiterature>();
        public List<RLiteratureAuthor> lstLiteratureAuthor = new List<RLiteratureAuthor>();
        public List<RLiteratureTag> lstLiteratureTag = new List<RLiteratureTag>();

        // Survey
        public List<CSurvey> lstSurvey = new List<CSurvey>();
        public List<RSurveyLiterature> lstSurveyLiterature = new List<RSurveyLiterature>();
        public List<RSurveyTag> lstSurveyTag = new List<RSurveyTag>();
        public List<RSurveyTagValueOption> lstSurveyTagValueOption = new List<RSurveyTagValueOption>();
        public List<RSurveySubTag> lstSurveySubTag = new List<RSurveySubTag>();
        public List<RSurveyLiteratureTagValue> lstSurveyLiteratureTagValue = new List<RSurveyLiteratureTagValue>();
    }
}
