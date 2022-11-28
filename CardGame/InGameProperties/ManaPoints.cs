using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Interfaces;

namespace CardGame.InGameProperties
{
    internal class ManaPoints : IProperties
    {
        int count;
        string description;
        ManaPoints(int count, string description)
        {
            if (count < 0 || count > 10) throw new ArgumentOutOfRangeException("count");
            this.description = description;
            this.count = count;
        }

        public string Description { get { return description; } }

        public int Count { get { return count; }
            set { 
                count = value; }
        }
    }
}
