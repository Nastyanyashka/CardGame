using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Actions
{
    public class Hit : IAction,IHaveAttackDamage
    {
        AttackDamage damage;
        public Hit(int damage)
        {
            if (damage < 0) throw new ArgumentException("damage can't be negative");
            this.damage = new AttackDamage(damage,"");
        }


        public object Clone()
        {
            return new Hit(damage.Amount);
        }
        public Interfaces.IAction.Action GetActionMethod(Interfaces.ITakeMessage recipient)
        {
            if (recipient != null)
                return new IAction.Action(ToHit);
            else
                return null!;
        }
        private void ToHit(Interfaces.ISendMessage sender, Interfaces.ITakeMessage recipient, List<Interfaces.ITakeMessage> anotherRecipient)
        {
            if (recipient is IHaveHealthPoints)
            {
                ((IHaveHealthPoints)recipient).HealthPoints -= damage.Amount;
                if(((IHaveHealthPoints)recipient).HealthPoints < 1 && (recipient is IPlayer)== false)
                    GameManager.Game.ExitCardFromGame((ICard)recipient);
            }
        }
        public int Damage { get { 
                return damage.Amount;
            }
            set
            {
                damage.Amount = value;
            }
        }
    }
}
