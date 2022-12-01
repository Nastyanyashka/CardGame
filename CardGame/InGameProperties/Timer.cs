using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.InGameProperties
{
    internal class Timer:IProperties
    {
        string description;
        int amountOfMoves;
        public Timer( int amountOfMoves, string description)
        {
            this.description = description;
            this.amountOfMoves = amountOfMoves;
        }

        public string Description { get { return description; } }
        public int AmountOfMoves { get { return amountOfMoves; }  set { amountOfMoves = value; } }
    }
}
