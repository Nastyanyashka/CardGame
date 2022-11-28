using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.InGameProperties
{
    internal class AttackDamage: IProperties
    {
        string description;
        int amount;
        AttackDamage(int amount, string description)
        {
            this.description = description;
            this.amount = amount;
        }

        public string Description { get { return description; } }
        public int Amount { get { return amount; } }
    }
}
