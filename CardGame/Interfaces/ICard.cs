using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Interfaces
{
    internal interface ICard:IHaveProperties,IHaveEffects,ISendMessage,ICloneable,ITakeMessage
    {
        public IPlayer Owner { get; set; }
        List<IAction> Actions { get; }
        public IMessage createMessage();
        public void intoTheGame();
        public void exitTheGame();
    }
}
