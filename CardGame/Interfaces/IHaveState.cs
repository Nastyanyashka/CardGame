using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Interfaces
{
    public interface IHaveState
    {
        States State { get; set; }
    }
}
