using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Interfaces;
using static CardGame.Interfaces.IEffects;

namespace CardGame
{
    internal abstract class Card:ICard
    {
        protected IPlayer owner;
        protected List<IAction> actions = new List<IAction>();
        protected List<IProperties> properties = new List<IProperties>();
        protected List<IEffects> effects = new List<IEffects>();
        protected Card()
        {
        }
        public  List<IAction> Actions { get { return actions; } }
        public IPlayer Owner { get { return owner; } set
            {
                if(value == null) throw new ArgumentNullException("");
                owner = value;
            } }
        public  List<IProperties> Properties
        {
            get { return properties; }
        }

        public  List<IEffects> Effects
        {
            get { return effects; }
        }


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
                foreach (IEffects effect in Effects.Where(e => e.moments.Contains(MomentsOfEvents.ReceivingMessage)))
                    effect.GetEffectMethod(action)(message.Sender, tmp, this);
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
        public  void intoTheGame() { }
        public  void exitTheGame() { }

    }
}
