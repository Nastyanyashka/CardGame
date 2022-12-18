﻿using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Effects
{
    public class Inspiration: IEffects
    {
        List<MomentsOfEvents> _moments;
        CardGame.InGameProperties.Timer timer;
        bool checker = false;
       
        public Inspiration(int amountOfMoves)
        {
            timer = new InGameProperties.Timer(amountOfMoves, "");
            _moments = new List<MomentsOfEvents>();
            _moments.Add(MomentsOfEvents.EnterTheGame);
            _moments.Add(MomentsOfEvents.BeforeMove);
        }
        public List<MomentsOfEvents> moments { get => _moments; }
        public int AmountOfMoves
        { get { return timer.AmountOfMoves; } set { timer.AmountOfMoves = value; } }
        public IEffects.Effect GetEffectMethod(MomentsOfEvents moment, Interfaces.ITakeMessage owner)
        {
            IEffects.Effect effect;
            if (moment == MomentsOfEvents.EnterTheGame && checker == false)
            {
                effect = ToInspirate;
                checker= true;
            }
            else if (moment == MomentsOfEvents.BeforeMove)
                effect = ToInspirateBeforeMove;
            else
                effect = null!;
            return effect;
        }
        public object Clone()
        {
            return new Inspiration(timer.AmountOfMoves);
        }
        private void ToInspirate(Interfaces.ISendMessage sender, Interfaces.IAction action, Interfaces.ITakeMessage owner)
        {
            if (owner is IHaveHealthPoints&& owner is IHaveAttackDamage && timer.AmountOfMoves > 0)
            {
                ((IHaveHealthPoints)owner).HealthPoints++;
                ((IHaveAttackDamage)owner).Damage++;
            }
        }
        private void ToInspirateBeforeMove(Interfaces.ISendMessage sender, Interfaces.IAction action, Interfaces.ITakeMessage owner)
        {
            timer.AmountOfMoves--;
            if(timer.AmountOfMoves == 0)
            {
                ((IHaveHealthPoints)owner).HealthPoints--;
                ((IHaveAttackDamage)owner).Damage--;
            }
        }
        
    }
}
