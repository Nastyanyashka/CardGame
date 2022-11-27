using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Interfaces;

namespace CardGame
{
    internal abstract class Card:ICard
    {
        protected string name;
        protected int manaCost;

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

    }
}
