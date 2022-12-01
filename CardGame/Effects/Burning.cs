using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Effects
{
    internal class Burning:IEffects
    {
        List<MomentsOfEvents> _moments;
        AttackDamage damage;
        CardGame.InGameProperties.Timer timer;
        public List<MomentsOfEvents> moments { get => _moments; }
        public Burning(int amountOfMoves)
        {
            damage = new AttackDamage(1, "");
            timer = new InGameProperties.Timer(amountOfMoves, "");   
            _moments = new List<MomentsOfEvents>();
            _moments.Add(MomentsOfEvents.AfterMove);
        }
        public IEffects.Effect GetEffectMethod(MomentsOfEvents moment, Interfaces.ITakeMessage owner = null)
        {
            IEffects.Effect effect;
            if (moment == MomentsOfEvents.AfterMove)
                effect = ToBurning;
            else
                effect = null;
            return effect;
        }
        public object Clone()
        {
            return new Burning(timer.AmountOfMoves);
        }
        private void ToBurning(Interfaces.ISendMessage sender = null, Interfaces.IAction action = null, Interfaces.ITakeMessage owner = null)
        {
            if (owner is IHaveBasicProperties && timer.AmountOfMoves > 0)
                ((IHaveBasicProperties)owner).HealthPoints.Amount -= damage.Amount;
            timer.AmountOfMoves -= 1;
        }
    }
}
