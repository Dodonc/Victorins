using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victorins
{
    public class CQuest : IQuestion
    {
        public string Quest { get; private set; }
        public string Name { get; private set; }
        public CQuest(string Quest,string Name) 
        {
            this.Quest = Quest;
            this.Name = Name;
        }


        public virtual string TakeQuest()
        {
            return Quest;
        }
        public string GetName() { return Name; }
        public CPlayerScope TakeScope(bool isRight, CPlayerScope scope)
        {
            if (isRight)
            {
                scope.setPlayerScope(scope.getPlayerScope()+1);
            }
            
            return scope;
        }
        
    }
}
