using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Interfaces;
namespace CardGame
{
    internal class Account
    {
        string name;
        List<ICard> cards;
        List<IDeck> decks = new List<IDeck>();
        Account(string name)
        {
            this.name = name;
            cards= new List<ICard>();
            decks = new List<IDeck>();
        }
        public List<IDeck> Decks { get { return decks; } set { decks = value; } }



        void EnterGame(IPlayer player)
        {

        }
    }
}
