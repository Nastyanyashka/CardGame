using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CardGame
{
    public class Player : Card,IPlayer
    {
        IDeck deck;
        List<ICard> hand = new List<ICard>();
        ManaPoints currentManaPoints;
        ManaPoints manaPoints;
        HealthPoints healthPoints;
        public Player(IDeck deck,string name)
        { 
           
            if(deck == null) throw new ArgumentNullException(nameof(deck));
            actions = new List<IAction>();
            this.deck = deck;
            healthPoints = new HealthPoints(30,"");
            currentManaPoints = new ManaPoints(0, "");
            manaPoints = new ManaPoints(0,"");
            this.name.Name = name;
        }

        public int HealthPoints { get { return healthPoints.Amount; } set { healthPoints.Amount = value; } }
        public int ManaPoints { get { return manaPoints.Count; }set
            { manaPoints.Count= value;}
        }
        public int CurrentManaPoints
        {
            get { return currentManaPoints.Count; }
            set
            { currentManaPoints.Count = value; }
        }
        public List<ICard> Hand { get { return hand; } set
            {
                if(value == null) throw new ArgumentNullException("Hand can't be null");
                hand = value;
            } }

        public IDeck Deck
        { get { return deck; } }

        public override object Clone()
        {
            return new Player(this.deck,this.name.Name);
        }

        public override List<IMessage> createMessage()
        {
            List<IMessage> msgs = new List<IMessage>();
            for(int i =0; i<actions.Count;i++)
            {
                msgs.Add(new Message(this, actions[i]));
            }
            return msgs;
        }
    }
}
