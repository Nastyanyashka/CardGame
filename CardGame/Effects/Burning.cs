using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Effects
{
    public class Burning:IEffects
    {
        List<MomentsOfEvents> _moments;
        AttackDamage damage;
        CardGame.InGameProperties.Timer timer;
      
        public Burning(int amountOfMoves, int damage)
        {
            this.damage = new AttackDamage(damage, "");
            timer = new InGameProperties.Timer(amountOfMoves, "");   
            _moments = new List<MomentsOfEvents>();
            _moments.Add(MomentsOfEvents.AfterMove);
        }
        public int AmountOfMoves
        { get { return timer.AmountOfMoves; } set { timer.AmountOfMoves = value; } }
        public List<MomentsOfEvents> moments { get => _moments; }
        public IEffects.Effect GetEffectMethod(MomentsOfEvents moment, Interfaces.ITakeMessage owner)
        {
            IEffects.Effect effect;
            if (moment == MomentsOfEvents.AfterMove)
                effect = ToBurning;
            else
                effect = null!;
            return effect;
        }
        public object Clone()
        {
            return new Burning(timer.AmountOfMoves, damage.Amount);
        }
        private void ToBurning(Interfaces.ISendMessage sender, Interfaces.IAction action, Interfaces.ITakeMessage owner)
        {
            if (owner is IHaveHealthPoints && timer.AmountOfMoves > 0)
                ((IHaveHealthPoints)owner).HealthPoints -= damage.Amount;
            if (((IHaveHealthPoints)owner).HealthPoints < 1 && (owner is IPlayer) == false)
                GameManager.Game.ExitCardFromGame((ICard)owner);
            timer.AmountOfMoves -= 1;
            if(timer.AmountOfMoves == 0)
            {
                ((ICard)owner).Effects.Remove(this);
            }
        }
        
    }
}
