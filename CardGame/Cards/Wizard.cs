using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Cards
{
    internal class Wizard:Card
    {
        public Wizard()
        {
            owner = null;
            actions.Add(new Actions.ThrowFireBall(2));
            manaCost.Cost = 0;
            healthPoints.Amount = 8;
            damage.Amount = 3;
            name.Name = "Wizzard";
        }
        public override object Clone()
        {
            return new Wizard();
        }
    }
}
