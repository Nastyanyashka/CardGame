using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Interfaces
{
    internal interface ICard
    {
        string Name { get; }
        List<IAction> Actions { get; }
        int ManaCost { get; } 
    }
}
