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
    internal class CreatureCard: Card, ICreature
    {
        
        List<IEffects> effects = new List<IEffects>();
        List<IProperties> properties = new List<IProperties>();    
        List<IAction> actions = new List<IAction>();
        private int healthPoints;
        private int attackDamage;
        public CreatureCard(Card card,int healthPoints,int attackDamage,List<IEffects> effects, List<IProperties> properties, List<IAction> actions):base(card.Name,card.ManaCost)
        {
            if (healthPoints < 0) throw new Exception("Health can't be negative");
            if (attackDamage < 0) throw new Exception("Attack can't be negative");
            this.healthPoints = healthPoints;
            this.attackDamage = attackDamage;
            if (effects!=null)
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

        public int AttackDamage
        {
            get { return attackDamage; }
            set
            {
                if (value < 0) throw new Exception("Attack can't be negative");
                attackDamage = value;
            }
        }

        public int HealthPoints
        {
            get { return healthPoints; }
            set
            {
                if (value < 0) throw new Exception("HealthPoints can't be negative");
                healthPoints = value;
            }
        }

        public List<IEffects> Effects { get { return effects; } }
        public List<IProperties> Properties { get { return properties; } }
        public override List<IAction> Actions { get { return actions; } }
    }
}
