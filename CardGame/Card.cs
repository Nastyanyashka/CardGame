using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal abstract class Card:ICard
    {
        protected string name;
        protected int healthPoints;
        protected int attackDamage;
        protected int manaCost;

        internal Card(string name, int helthPoint, int attackDamage, int manaCost)
        {
            if (helthPoint < 0) throw new Exception("Health can't be negative");
            if (attackDamage < 0) throw new Exception("Attack can't be negative");
            if (manaCost < 0) throw new Exception("Manacost can't be negative");
            this.name = name;
            this.healthPoints = helthPoint;
            this.attackDamage = attackDamage;
            this.manaCost = manaCost;
        }

        internal Card(string name,int manaCost)
        {
            if (manaCost < 0) throw new Exception("Manacost can't be negative");
            this.name = name;
            this.manaCost = manaCost;
        }
        abstract public List<IAction> Actions { get; }

        public string Name { get { return name; } }

        public int ManaCost { get { return manaCost; }
            set {
                if (value < 0) throw new Exception("Manacost can't be negative");
                manaCost= value;
            }
        }
        public int HealthPoints { get { return healthPoints; } set
            {
                if (value < 0) throw new Exception("HealthPoints can't be negative");
                healthPoints = value;
            }
        }
        public int AttackDamage { get { return attackDamage; } set
            {
                if (value < 0) throw new Exception("Attack can't be negative");
                attackDamage = value;
            }
        }

    }
}
