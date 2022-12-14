using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Interfaces;
namespace CardGame
{
    internal abstract class SpellCard : Card
    {

        protected SpellCard(List<IAction> actions)
        {
            if (actions == null)
                throw new ArgumentNullException(nameof(actions));
            this.actions = actions;
        }

    }
    
}
