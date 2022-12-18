using CardGame.InGameProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Interfaces
{
    public interface IPlayer:ISendMessage,ITakeMessage,IHaveEffects,ICloneable,IHaveBasicProperties,IHaveHealthPoints
    {
        public IDeck Deck { get; }
        public List<ICard> Hand { get; set; }

        public int ManaPoints { get; set; }
    }
}
