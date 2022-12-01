using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Actions
{
    internal class ThrowFireBall: IAction
    {
        AttackDamage damage;
        public ThrowFireBall(AttackDamage damage)
        {
            this.damage = damage;           
        }
        public object Clone()
        {
            return new ThrowFireBall(damage);
        }
        public Interfaces.IAction.Action GetActionMethod(Interfaces.ITakeMessage recipient = null)
        {
            if (recipient != null)
                return new Interfaces.IAction.Action(ToThrowFireBall);
            else
                return null;
        }
        private void ToThrowFireBall(Interfaces.ISendMessage sender = null, Interfaces.ITakeMessage recipient = null, List<Interfaces.ITakeMessage> anotherRecipient = null)
        {
            if (recipient is IHaveBasicProperties)
                ((IHaveBasicProperties)recipient).HealthPoints.Amount -= damage.Amount;
            if (recipient is IHaveEffects)
                ((IHaveEffects)recipient).Effects.Add(new Effects.Burning(3));
        }
    }
}
