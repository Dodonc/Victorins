using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victorins
{
    public class CQuestAsk:CQuest
    {
        public string Quest { get; private set; }
        public string Name { get; private set; }

        public string answer { get; private set; }

        public CQuestAsk(string Quest, string Name, string answer):base(Quest,Name) 
        {
            this.Quest = Quest;
            this.Name = Name;
            this.answer = answer;
        }

        public bool IsRight( string ans)
        {
            if (this.answer == ans) return true;
            else return false;
        }
    }
}
