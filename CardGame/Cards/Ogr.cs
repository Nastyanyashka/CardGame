using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CardGame.Interfaces.IAction;
using static CardGame.Interfaces.IEffects;

namespace CardGame.Cards
{
    internal class Ogr:Card
    {
        public Ogr(IPlayer player) : base(player)
        {
            owner = player;
            actions.Add(new Actions.Hit(new AttackDamage(4, "")));
            manaCost.Cost = 0;
            healthPoints.Amount = 8;
            damage.Amount = 3;
            name.Name = "Ogr";
        }
        public override object Clone()
        {
            return new Ogr(owner);
        }
    }
}
