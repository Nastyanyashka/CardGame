using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Interfaces
{
    internal interface IAction:ICloneable
    {
        public Action GetActionMethod(ITakeMessage recipient = null);
        public delegate void Action(ISendMessage sender = null, ITakeMessage recipient = null, List<ITakeMessage> anotherRecipient = null);
    }
}
