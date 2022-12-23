using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public abstract class CreatureCard:Card,ICreatureCard
    {
        protected HealthPoints healthPoints;
        protected CreatureCard():base()
        {
            healthPoints = new HealthPoints(0, "");
        
        }
        public int HealthPoints { get { return healthPoints.Amount; } set { healthPoints.Amount = value; } }
        public void intoTheGame()
        {
            owner.Hand.Remove(this);
            owner.CurrentManaPoints -= this.ManaCost;
            GameManager.Game.EnterCardInGame(this);
        }
        public void exitTheGame()
        {
            GameManager.Game.ExitCardFromGame(this);
        }
    }
}
