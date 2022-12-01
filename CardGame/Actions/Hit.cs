using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Actions
{
    internal class Hit : IAction
    {
        AttackDamage damage;
        public Hit(AttackDamage damage)
        {
            this.damage = damage;
        }
        public object Clone()
        {
            return new Hit(damage);
        }
        public Interfaces.IAction.Action GetActionMethod(Interfaces.ITakeMessage recipient = null)
        {
            if (recipient != null)
                return new IAction.Action(ToHit);
            else
                return null;
        }
        private void ToHit(Interfaces.ISendMessage sender = null, Interfaces.ITakeMessage recipient = null, List<Interfaces.ITakeMessage> anotherRecipient = null)
        {
            if (recipient is IHaveBasicProperties)
                ((IHaveBasicProperties)recipient).HealthPoints.Amount -= damage.Amount;
                    
           
        }
    }
}
