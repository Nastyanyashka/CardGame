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
            return new Burning(timer.AmountOfMoves);
        }
        private void ToBurning(Interfaces.ISendMessage sender, Interfaces.IAction action, Interfaces.ITakeMessage owner)
        {
            if (owner is IHaveBasicProperties && timer.AmountOfMoves > 0)
                ((IHaveBasicProperties)owner).HealthPoints -= damage.Amount;
            if (((IHaveBasicProperties)owner).HealthPoints < 1 && (owner is IPlayer) == false)
                GameManager.game.ExitCardFromGame((ICard)owner);
            timer.AmountOfMoves -= 1;
        }
        public int AmountOfMoves
        { get { return timer.AmountOfMoves;} set { timer.AmountOfMoves = value; } }
    }
}
