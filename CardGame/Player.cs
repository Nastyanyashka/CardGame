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
        

        Player(IDeck deck, NameOfCard name,HealthPoints healthPoints, ManaPoints manaPoints)
        { 
           
            if(deck == null) throw new ArgumentNullException(nameof(deck));
            if (healthPoints == null)   throw new ArgumentNullException(nameof(healthPoints));
            if (manaPoints==null) throw new ArgumentNullException(nameof(manaPoints));
            actions = null;
            this.deck = deck;
            
            properties.Add(name);
            properties.Add(healthPoints);
            properties.Add(manaPoints);
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
            return new Player(this.deck, (NameOfCard)properties[0], (HealthPoints)properties[1],(ManaPoints) properties[2]);
        }

    }
}
