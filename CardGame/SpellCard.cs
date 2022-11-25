using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class SpellCard:Card
    {
        List<IAction> actions = new List<IAction>();

        public SpellCard(Card card, List<IAction> actions) : base(card.Name, card.HealthPoints, card.AttackDamage, card.ManaCost)
        {
            if (actions != null)
                this.actions = actions;
        }
        public override List<IAction> Actions { get { return actions; } }
    }
}
