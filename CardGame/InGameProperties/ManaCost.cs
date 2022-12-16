using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Interfaces;
namespace CardGame.InGameProperties
{
    public class ManaCost : IProperties
    {
        string description;
        int cost;
        public ManaCost(int cost, string description)
        {
            this.description = description;
            this.cost = cost;
        }

        public string Description { get { return description; } }
        public int Cost { get { return cost; } set { cost = value; } }
    }
}
