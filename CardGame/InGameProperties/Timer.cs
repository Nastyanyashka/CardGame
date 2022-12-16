using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.InGameProperties
{
    public class Timer:IProperties
    {
        string description;
        int amountOfMoves;
        public Timer( int amountOfMoves, string description)
        {
            this.description = description;
            if (amountOfMoves < 1) throw new ArgumentException("AmountOfMoves of Effects/Actions can't be < 1");
            this.amountOfMoves = amountOfMoves;
        }

        public string Description { get { return description; } }
        public int AmountOfMoves { get { return amountOfMoves; }  set { amountOfMoves = value; } }
    }
}
