using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.InGameProperties
{
    internal class NameOfCard: IProperties
    {
        string description;
        string name;
        NameOfCard(string name, string description)
        {
            this.description = description;
            this.name = name;
        }

        public string Description { get { return description; } }
        public string Name { get { return name; } }
    }
}
