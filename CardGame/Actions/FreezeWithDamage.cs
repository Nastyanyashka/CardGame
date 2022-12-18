using CardGame.Effects;
using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Actions
{
    public class FreezeWithDamage:IAction,IHaveAttackDamage
    {
        AttackDamage damage;
        CardGame.InGameProperties.Timer timer;
        public FreezeWithDamage(int damage, int amountOfMoves)
        {
            if (damage < 0) throw new ArgumentException("damage can't be negative");
            this.damage = new AttackDamage(damage, "");
            timer = new CardGame.InGameProperties.Timer(amountOfMoves, "");
        }

        public int Damage
        {
            get
            {
                return damage.Amount;
            }
            set
            {
                damage.Amount = value;
            }
        }

        public object Clone()
        {
            return new FreezeWithDamage(damage.Amount, this.timer.AmountOfMoves);
        }
        public Interfaces.IAction.Action GetActionMethod(Interfaces.ITakeMessage recipient)
        {
            if (recipient != null)
                return new Interfaces.IAction.Action(ToFreeze);
            else
                return null!;
        }
        private void ToFreeze(Interfaces.ISendMessage sender, Interfaces.ITakeMessage recipient, List<Interfaces.ITakeMessage> anotherRecipient)
        {

            if (recipient is IHaveHealthPoints)
            {
                ((IHaveHealthPoints)recipient).HealthPoints -= damage.Amount;
                if (((IHaveHealthPoints)recipient).HealthPoints < 1 && (recipient is IPlayer) == false)
                    GameManager.Game.ExitCardFromGame((ICard)recipient);
            }

            foreach (IEffects effect in ((ICard)recipient).Effects)
            {
                if (effect is Frozen)
                {
                    ((Frozen)effect).AmountOfMoves = 3;
                    return;
                }
                
            }
            if (recipient is IHaveEffects)
                ((IHaveEffects)recipient).Effects.Add(new Effects.Frozen(timer.AmountOfMoves));
            
        }
    }
}
