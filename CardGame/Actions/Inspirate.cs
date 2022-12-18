using CardGame.Effects;
using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;
namespace CardGame.Actions
{
    public class Inspirate : IAction
    {
        int amountOfMoves;

        public Inspirate(int amountOfMoves)
        {
            if (amountOfMoves < 0) throw new ArgumentException(nameof(Inspirate));
            this.amountOfMoves = amountOfMoves;
        }


        public object Clone()
        {
            return new Inspirate(amountOfMoves);
        }
        public Interfaces.IAction.Action GetActionMethod(Interfaces.ITakeMessage recipient)
        {
            if (recipient != null)
                return new Interfaces.IAction.Action(ToInspirate);
            else
                return null!;
        }
        private void ToInspirate(Interfaces.ISendMessage sender, Interfaces.ITakeMessage recipient, List<Interfaces.ITakeMessage> anotherRecipient)
        {
            if (recipient is IHaveEffects)
                ((IHaveEffects)recipient).Effects.Add(new Inspiration(amountOfMoves));
            foreach (IHaveEffects recipients in anotherRecipient)
            {
                recipients.Effects.Add(new Inspiration(amountOfMoves));
            }
        }
    }
}
