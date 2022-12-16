using CardGame.InGameProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using CardGame.Interfaces;

namespace CardGame.Cards
{
    public class Knight:Card
    {
        public Knight()
        {
            owner = null!;
            damage.Amount = 1;
            actions.Add(new Actions.Inspirate(3));
            actions.Add(new Actions.Hit(damage.Amount));
            manaCost.Cost = 2;
            healthPoints.Amount = 4;
            name.Name = "Knight";
        }
        public override object Clone()
        {
            return new Knight();
        }
    }
}
