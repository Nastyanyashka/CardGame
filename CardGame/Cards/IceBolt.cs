using CardGame.Actions;
using CardGame.InGameProperties;
using CardGame.Interfaces;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Cards
{
    public class IceBolt : Card
    {
        public IceBolt() {
            owner = null!;
            damage.Amount = 3;
            actions.Add(new FreezeWithDamage(damage.Amount,3));
            manaCost.Cost = 3;
            name.Name = "Ice Bolt";
        }
        public override object Clone()
        {
            return new IceBolt();
        }

        public override List<IMessage> createMessage()
        {
            return new List<IMessage>() { new Message(this, actions[0]) };
        }
    }
}
