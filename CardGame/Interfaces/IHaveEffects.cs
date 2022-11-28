using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Interfaces
{
    internal interface IHaveEffects
    {
        List<IEffects> Effects { get; }
    }
}
