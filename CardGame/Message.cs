using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CardGame.Interfaces;

namespace CardGame
{
    internal class Message:IMessage
    {
        ISendMessage sender;
        List<ITakeMessage> receivers;
        List<IAction> actions;

        public Message(Interfaces.ICard sender, List<Interfaces.IAction> actions)
        {
            this.sender = sender;
            this.actions = actions;
            receivers = new List<Interfaces.ITakeMessage>();
        }
        public Message(Interfaces.ICard sender, List<Interfaces.IAction> actions, List<Interfaces.ITakeMessage> receivers) : this(sender, actions)
        {
            this.receivers = receivers;
        }

        public ISendMessage Sender { get { return sender; } set
            { if (value == null)
                {
                    throw new ArgumentNullException("There is no sender");
                }
               sender = value; 
            } 
        }
        public List<ITakeMessage> Receivers { get { return receivers; } set { receivers = value; } }
        public List<IAction> Actions { get { return actions; } set { actions= value; } }

    }
}
