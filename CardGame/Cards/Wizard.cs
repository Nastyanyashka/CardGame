using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Cards
{
    public class Wizard:Card
    {
        public Wizard()
        {
            owner = null!;
            damage.Amount = 2;
            actions.Add(new Actions.ThrowFireBall(damage.Amount,3));
            manaCost.Cost = 2;
            healthPoints.Amount = 4;
            name.Name = "Wizzard";
        }
        public override object Clone()
        {
            return new Wizard();
        }
    }
}
