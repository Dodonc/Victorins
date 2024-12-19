using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victorins
{
    public class CPlayerScope
    {
        public string PlayerName { get; private set; }
        public int PlayerScope {  get; private set; }
        public CPlayerScope(string name, int scope ) 
        {
            PlayerName = name;
            PlayerScope = scope;
        }
        public void setPlayerScope(int s)
        {
            PlayerScope = s;
        }

        public int getPlayerScope() 
        {
            return PlayerScope;
        }
    }
}
