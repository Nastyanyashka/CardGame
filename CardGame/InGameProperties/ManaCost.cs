using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Interfaces;
namespace CardGame.InGameProperties
{
    internal class ManaCost : IProperties
    {
        string description;
        int cost;
        ManaCost(int cost, string description)
        {
            this.description = description;
            this.cost = cost;
        }

        public string Description { get { return description; } }
        public int Cost { get { return cost; } }
    }
}
