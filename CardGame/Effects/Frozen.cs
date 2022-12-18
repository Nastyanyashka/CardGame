using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Effects
{
    public class Frozen : IEffects
    {
        List<MomentsOfEvents> _moments;
        CardGame.InGameProperties.Timer timer;
        public Frozen(int amountOfMoves) 
        {
            timer = new InGameProperties.Timer(amountOfMoves, "");
            _moments = new List<MomentsOfEvents>();
            _moments.Add(MomentsOfEvents.BeforeMove);
            _moments.Add(MomentsOfEvents.EnterTheGame);
        }
        public List<MomentsOfEvents> moments { get => _moments; }
        public int AmountOfMoves
        { get { return timer.AmountOfMoves; } set { timer.AmountOfMoves = value; } }
        public IEffects.Effect GetEffectMethod(MomentsOfEvents moment, Interfaces.ITakeMessage owner)
        {
            IEffects.Effect effect;
            if (moment == MomentsOfEvents.EnterTheGame)
                effect = ToFreeze;
            else if (moment == MomentsOfEvents.BeforeMove)
                effect = ToFreezeBeforeMove;
            else
                effect = null!;
            return effect;
        }
        public object Clone()
        {
            return new Frozen(timer.AmountOfMoves);
        }
        private void ToFreeze(Interfaces.ISendMessage sender, Interfaces.IAction action, Interfaces.ITakeMessage owner)
        {
            if (owner is ICard)
            {
                ((ICard)owner).State = States.Deactivated;
            }
            if (((IHaveHealthPoints)owner).HealthPoints < 1 && (owner is IPlayer) == false)
                GameManager.Game.ExitCardFromGame((ICard)owner);
        }
        private void ToFreezeBeforeMove(Interfaces.ISendMessage sender, Interfaces.IAction action, Interfaces.ITakeMessage owner)
        {
            timer.AmountOfMoves--;
            if (timer.AmountOfMoves == 0)
            {
                ((ICard)owner).State = States.Activated;
                ((ICard)owner).Effects.Remove(this);
            }
        }

    }
}
