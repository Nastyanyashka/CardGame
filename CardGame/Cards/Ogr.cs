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
    public class Ogr:CreatureCard
    {
        public Ogr()
        {
            owner = null!;
            damage.Amount = 2;
            actions.Add(new Actions.Hit(damage.Amount));
            manaCost.Cost = 1;
            healthPoints.Amount = 5;
            name.Name = "Ogr";
        }
        public override object Clone()
        {
            return new Ogr();
        }

        public override List<IMessage> createMessage()
        {
            return new List<IMessage>() { new Message(this, actions[0]) };
        }
    }
}
