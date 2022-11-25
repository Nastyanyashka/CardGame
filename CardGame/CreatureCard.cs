using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class CreatureCard: Card
    {
        
        List<IEffects> effects = new List<IEffects>();
        List<IProperties> properties = new List<IProperties>();    
        List<IAction> actions = new List<IAction>();   

        public CreatureCard(Card card,List<IEffects> effects, List<IProperties> properties, List<IAction> actions):base(card.Name,card.HealthPoints,card.AttackDamage,card.ManaCost)
        {
            if(effects!=null)
            this.effects = effects;
            if(properties!=null)
            this.properties = properties;
            if(actions!=null)
            this.actions = actions;
        }

        public void AddEffect(IEffects effect)
        {
            effects.Add(effect);
        }

        public List<IEffects> Effects { get { return effects; } }
        public List<IProperties> Properties { get { return properties; } }
        public override List<IAction> Actions { get { return actions; } }
    }
}
