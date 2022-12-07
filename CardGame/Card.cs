using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using CardGame.InGameProperties;
using CardGame.Interfaces;
using static CardGame.Interfaces.IEffects;

namespace CardGame
{
    internal abstract class Card:ICard
    {
        protected IPlayer owner;
        protected HealthPoints healthPoints;
        protected AttackDamage damage;
        protected ManaCost manaCost;
        protected NameOfCard name;


        protected List<IAction> actions = new List<IAction>();
        protected List<IEffects> effects = new List<IEffects>();
        protected Card(IPlayer owner)
        {
            this.owner = owner;
            healthPoints = new HealthPoints(0, "");
            manaCost = new ManaCost(0, "");
            damage = new AttackDamage(0, "");
            name = new NameOfCard("", "");
        }
        public  List<IAction> Actions { get { return actions; } }
        public IPlayer Owner { get { return owner; } set
            {
                if(value == null) throw new ArgumentNullException("Owner Can't be null");
                owner = value;
            } }
        public  List<IEffects> Effects
        {
            get { return effects; }
        }

        public int HealthPoints { get { return healthPoints.Amount; } set { healthPoints.Amount= value; } }
        public int ManaCost { get { return manaCost.Cost; } set { manaCost.Cost= value; } }

        public int Damage { get { return damage.Amount; } set { damage.Amount = value; } }

        public string Name { get { return name.Name; } }







        public void sendMessage(IMessage message)
        {
            foreach (ITakeMessage receivier in message.Receivers)
            {
                receivier.takeMessage(message);
            }
        }
        public void takeMessage(IMessage message)
        {
            foreach (Interfaces.IAction action in message.Actions)
            {
                Interfaces.IAction tmp = (Interfaces.IAction)action.Clone();
                List<Interfaces.ITakeMessage> anotherRecipient = new List<Interfaces.ITakeMessage>(message.Receivers);
                anotherRecipient.Remove(this);
                tmp.GetActionMethod(this)(message.Sender, this, anotherRecipient);
            }
        }


        public abstract object Clone();
        public IMessage createMessage()
        {
            return new Message(this, actions);
        }
        public  void intoTheGame() {
            owner.Hand.Remove(this);
            GameManager.game.EnterCardInGame(this);
        }
        public  void exitTheGame() {
            GameManager.game.ExitCardFromGame(this);
        }

    }
}
