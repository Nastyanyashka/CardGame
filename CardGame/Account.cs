using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Interfaces;
namespace CardGame
{
    class Account:IHaveDeck,IHaveProperties
    {
        List<ICard> cards;
        List<IDeck> decks = new List<IDeck>();
        Account(List<ICard> cards, List<IDeck> decks)
        {
            this.cards = cards;
            this.decks = decks;
        }



        public List<IDeck> Decks => throw new NotImplementedException();

        public List<IProperties> Properties => throw new NotImplementedException();



        void EnterGame(IPlayer player)
        {

        }
    }
}
