using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Interfaces
{
    public interface IAction:ICloneable
    {
        List<TypeOfActions> Type { get; }
        public Action GetActionMethod(ITakeMessage recipient);
        public delegate void Action(ISendMessage sender, ITakeMessage recipient, List<ITakeMessage> anotherRecipient);
    }
}
