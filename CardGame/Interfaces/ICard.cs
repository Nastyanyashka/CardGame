using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Interfaces
{
    internal interface ICard:IHaveEffects,ISendMessage,ICloneable,ITakeMessage,IHaveBasicProperties
    {
        public IPlayer Owner { get; set; }
        List<IAction> Actions { get; }
        public IMessage createMessage();
        public void intoTheGame();
        public void exitTheGame();
    }
}
