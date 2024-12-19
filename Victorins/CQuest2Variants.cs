using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victorins
{
    public class CQuest2Variants : CQuest
    {
        public string Quest { get; private set; }
        public string Name { get; private set; }
        public bool isAns {  get; private set; }
     

        public CQuest2Variants(string Quest, string Name, bool isAns) : base(Quest, Name)
        {
            this.Quest = Quest;
            this.Name = Name;
            this.isAns = isAns;

        }

        public bool IsRight(bool ans)
        {
            if (this.isAns == ans) return true;
            else return false;
        }

    }
}
