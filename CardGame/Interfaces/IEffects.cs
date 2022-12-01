using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Interfaces
{
    internal interface IEffects:ICloneable
    {
        List<MomentsOfEvents> moments { get; }
        public Effect GetEffectMethod(MomentsOfEvents moment, ITakeMessage owner = null);
        public delegate void Effect(ISendMessage sender = null, IAction action = null, ITakeMessage owner = null);
    }
}
