using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.InGameProperties
{
    public class NameOfCard: IProperties
    {
        string description;
        string name;
        public NameOfCard(string name, string description)
        {
            this.description = description;
            this.name = name;
        }

        public string Description { get { return description; } }
        public string Name { get { return name; } set { name = value; } }
    }
}
