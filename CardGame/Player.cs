using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CardGame
{
    internal class Player : Card,IPlayer
    {
        IDeck deck;
        List<ICard> hand = new List<ICard>();
        ManaPoints manaPoints;

        public Player(IDeck deck) : base(null)
        { 
           
            //if(deck == null) throw new ArgumentNullException(nameof(deck));
            actions = null;
            this.deck = deck;
            healthPoints.Amount = 30;
            manaPoints = new ManaPoints(0,"");
            name.Name = "Player";
        }

        
        public ManaPoints ManaPoints { get { return manaPoints; }set
            { manaPoints= value;}
        }

        public List<ICard> Hand { get { return hand; } set
            {
                if(value == null) throw new ArgumentNullException(nameof(value));
                hand = value;
            } }

        public IDeck Deck
        { get { return deck; } }

        public override object Clone()
        {
            return new Player(this.deck);
        }

    }
}
