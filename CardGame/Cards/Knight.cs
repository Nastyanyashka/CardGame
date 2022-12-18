using CardGame.InGameProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using CardGame.Interfaces;
using CardGame;
    namespace CardGame.Cards
{
    public class Knight:CreatureCard
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

        public override List<IMessage> createMessage()
        {
            //List<ICard> allyCards = GameManager.Game.CardsInGame.Where(p => p.Owner == GameManager.Game.CurrentPlayer).ToList();
            List<ITakeMessage> allyCards = new List<ITakeMessage>();
            for (int i = 0;i<GameManager.Game.CardsInGame.Count;i++)
            {
                if (GameManager.Game.CardsInGame[i].Owner == GameManager.Game.CurrentPlayer)
                {
                    allyCards.Add(GameManager.Game.CardsInGame[i]);
                }
            } 
            return new List<IMessage>() { new Message(this, actions[0], allyCards),
            new Message (this,actions[1])};
        }
    }
}
