using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CardGame.Interfaces;
namespace CardGame
{
    internal abstract class CreatureCard: Card
    {

        public CreatureCard(List<IEffects> effects, List<IProperties> properties, List<IAction> actions)
        {
            if (effects==null)
                throw new ArgumentNullException(nameof(effects));
            this.effects = effects;
            if(properties==null)
                throw new ArgumentNullException(nameof(properties));
            this.properties = properties;
            if(actions==null)
                throw new ArgumentNullException(nameof(actions));
            this.actions = actions;
        }

    }
}
