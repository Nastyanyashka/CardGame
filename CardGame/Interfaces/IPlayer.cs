using CardGame.InGameProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Interfaces
{
    internal interface IPlayer:ISendMessage,ITakeMessage,IHaveEffects,ICloneable,IHaveBasicProperties
    {
        public IDeck Deck { get; }
        public List<ICard> Hand { get; set; }

        public ManaPoints ManaPoints { get; set; }
    }
}
