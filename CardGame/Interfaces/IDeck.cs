using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Interfaces
{
    internal interface IDeck: IHaveProperties
    {
        List<ICard> Cards { get; set; }
    }
}
