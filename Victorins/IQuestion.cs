using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victorins
{
    internal interface IQuestion
    {
        string Quest { get; }
        string Name { get; }

        string TakeQuest();


    }
}
