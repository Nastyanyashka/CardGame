using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Interfaces
{
    public interface ICard:IHaveEffects,ISendMessage,ICloneable,ITakeMessage,IHaveBasicProperties, IHaveAttackDamage, IHaveManaCost,IHaveState
    {
        public IPlayer Owner { get; set; }
        List<IAction> Actions { get; }
        public List<IMessage> createMessage();
        public bool CanMakeMove { get; set; }
    }
}
