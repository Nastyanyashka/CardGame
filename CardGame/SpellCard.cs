using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Interfaces;

namespace CardGame
{
    internal class SpellCard : Card
    {
        List<IAction> actions = new List<IAction>();

        public SpellCard(Card card, List<IAction> actions) : base(card.Name, card.ManaCost)
        {
            if (actions != null)
                this.actions = actions;
        }
        public override List<IAction> Actions { get { return actions; } }
    }
    
}
