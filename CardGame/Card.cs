using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CardGame.InGameProperties;
using CardGame.Interfaces;
using static CardGame.Interfaces.IEffects;

namespace CardGame
{
    public abstract class Card:ICard
    {
        protected IPlayer owner;
        protected AttackDamage damage;
        protected ManaCost manaCost;
        protected NameOfCard name;
        protected List<IAction> actions = new List<IAction>();
        protected List<IEffects> effects = new List<IEffects>();
        protected States state;
        protected bool canMakeMove;
        protected Card()
        {
            
            this.owner = null!;
            manaCost = new ManaCost(0, "");
            damage = new AttackDamage(0, "");
            name = new NameOfCard("", "");
            this.state = States.Activated;
            canMakeMove = true;
        }

        public bool CanMakeMove { get { return canMakeMove; }  set { canMakeMove = value; } }

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

        public States State
        { get { return state; } set { state = value; } }

        public int ManaCost { get { return manaCost.Cost; } set { manaCost.Cost= value; } }

        public int Damage { get { return damage.Amount; } 
            set { 
                foreach(IAction action in actions)
                {
                    if(action is IHaveAttackDamage)
                    {
                        ((IHaveAttackDamage)action).Damage= value;
                    }
                }
                damage.Amount = value; } }

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
            IAction action = message.Actions;
            Interfaces.IAction tmp = (Interfaces.IAction)action.Clone();
            List<Interfaces.ITakeMessage> anotherRecipient = new List<Interfaces.ITakeMessage>(message.Receivers);
            anotherRecipient.Remove(this);
            tmp.GetActionMethod(this)(message.Sender, this, anotherRecipient);
        }

        public abstract object Clone();
        public abstract List<IMessage> createMessage();

    }
}
