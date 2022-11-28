using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Interfaces
{
    internal interface IMessage
    {
        ISendMessage Sender { get; }
        List<ITakeMessage> Receivers { get; }
        List<IAction> Actions { get; }
    }
}
