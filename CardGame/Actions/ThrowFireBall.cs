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
    public class ThrowFireBall: IAction,IHaveAttackDamage
    {
        AttackDamage damage;

        CardGame.InGameProperties.Timer timer;
        List<TypeOfActions> typeOfActions = new List<TypeOfActions>() { TypeOfActions.AttackAction };
        public ThrowFireBall(int damage,int amountOfMoves)
        {
            if (damage < 0) throw new ArgumentException("damage can't be negative");
            this.damage = new AttackDamage( damage, "");
            timer = new CardGame.InGameProperties.Timer(amountOfMoves, "");
        }

        public List<TypeOfActions> Type { get { return typeOfActions; } }

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
            return new ThrowFireBall(damage.Amount, this.timer.AmountOfMoves);
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
                ((IHaveEffects)recipient).Effects.Add(new Effects.Burning(timer.AmountOfMoves, damage.Amount));
            if (((IHaveBasicProperties)recipient).HealthPoints < 1 && (recipient is IPlayer) == false)
                GameManager.game.ExitCardFromGame((ICard)recipient);
        }
    }
}
