using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Interfaces;
namespace CardGame
{
    internal class Deck : IDeck
    {
        List<ICard> cards;   
        public Deck(List<ICard> cards) {
            if(cards == null)
                throw new ArgumentNullException("");
            this.cards = cards;
        }
        public List<ICard> Cards { get { return cards; } set { 
                if(value == null) throw new ArgumentNullException("");
                cards = value; } }
    }
}
