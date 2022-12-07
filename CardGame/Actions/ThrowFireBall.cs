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
    internal class ThrowFireBall: IAction
    {
        AttackDamage damage;
        public ThrowFireBall(int damage)
        {
            if (damage < 0) throw new ArgumentException("damage can't be negative");
            this.damage = new AttackDamage(damage, "");         
        }
        public object Clone()
        {
            return new ThrowFireBall(damage.Amount);
        }
        public Interfaces.IAction.Action GetActionMethod(Interfaces.ITakeMessage recipient)
        {
            if (recipient != null)
                return new Interfaces.IAction.Action(ToThrowFireBall);
            else
                return null!;
        }
        private void ToThrowFireBall(Interfaces.ISendMessage sender, Interfaces.ITakeMessage recipient, List<Interfaces.ITakeMessage> anotherRecipient)
        {
           
            if (recipient is IHaveBasicProperties)
                ((IHaveBasicProperties)recipient).HealthPoints -= damage.Amount;

            foreach (IEffects effect in ((ICard)recipient).Effects)
            {
                if (effect is Burning)
                {
                    ((Burning)effect).AmountOfMoves = 3;
                }
                    return;
            }
            if (recipient is IHaveEffects)
                ((IHaveEffects)recipient).Effects.Add(new Effects.Burning(3));
            if (((IHaveBasicProperties)recipient).HealthPoints < 1 && (recipient is IPlayer) == false)
                GameManager.game.ExitCardFromGame((ICard)recipient);
        }
    }
}
