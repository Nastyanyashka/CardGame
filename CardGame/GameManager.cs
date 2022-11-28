using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.InGameProperties;
using CardGame.Interfaces;
namespace CardGame
{
    internal class GameManager
    {
        private static GameManager _game;
        public static GameManager game
        {
            get
            {
                if (_game == null)
                    _game = new GameManager();
                return _game;
            }
        }
        private GameManager()
        {
            players = new List<Interfaces.IPlayer>();
            cardInGame = new List<Interfaces.ICard>();
            cemetery = new List<Interfaces.ICard>();
            currentPlayer = null;
        }
        public List<Interfaces.IPlayer> players;
        public List<Interfaces.ICard> cardInGame;
        public List<Interfaces.ICard> cemetery;
        public Interfaces.IPlayer currentPlayer;
        public void NextPlayer()
        {
            if (currentPlayer == null && players.Count > 0)
                currentPlayer = players[0];
            else
            {
                int indexPlayer = players.FindIndex(p => p == currentPlayer);
                indexPlayer++;
                if (indexPlayer == players.Count)
                    currentPlayer = players[0];
                else
                    currentPlayer = players[indexPlayer];
            }
            ApplyEffectsByMoment(null, null, null, MomentsOfEvents.BetweenMove);
        }
        public void EnterCardInGame(Interfaces.ICard card)
        {
            cardInGame.Add(card);
            ApplyEffectsByMoment(card, null, card, MomentsOfEvents.EnterTheGame);
        }
        public void ExitCardFromGame(Interfaces.ICard card)
        {
            cardInGame.Remove(card);
            ApplyEffectsByMoment(card, null, card, MomentsOfEvents.ExitTheGame);
            cemetery.Add(card);
        }
        public void SendMessage(Interfaces.IMessage message)
        {
            ApplyEffectsByMoment(message.Sender, null, null, MomentsOfEvents.SendingMessage);
            foreach (Interfaces.ITakeMessage resipient in message.Receivers)
                resipient.takeMessage(message);
            ApplyEffectsByMoment(message.Sender, null, null, MomentsOfEvents.ReceivingMessage);
        }
        public Interfaces.IPlayer CheckToWin()
        {
            HealthPoints hp;
            int count = players.Count;
            foreach(Player player in players)
            {
                hp = (HealthPoints)player.Properties[2];
                if (hp.Amount < 1 )
                {
                    players.Remove(player);
                    count--;
                }
            }

            if (count > 1)
                return null;
            else
                return players[0];
        }
        private void ApplyEffectsByMoment(Interfaces.ISendMessage initiator, Interfaces.IAction action, Interfaces.ITakeMessage ownerMessage, MomentsOfEvents moment)
        {
            List<IHaveEffects> effectsOwner = new List<IHaveEffects>(players);
            effectsOwner.AddRange(cardInGame);
            foreach (IHaveEffects owner in effectsOwner)
                foreach (IEffects effect in owner.Effects.Where(e => e.moments.Contains(moment)))
                    effect.GetEffectMethod(moment)(initiator, action, (Interfaces.ITakeMessage)owner);
        }

        public void MakeMove()
        {
            ApplyEffectsByMoment(null, null, currentPlayer, MomentsOfEvents.BeforeMove);
            int i = 0;
            
            Interfaces.ICard selectedCard;
            List<Interfaces.ITakeMessage> enemyCards = new List<Interfaces.ITakeMessage>();
            if (currentPlayer.Hand.Count != 0)
            {
                Console.WriteLine("Выставить карту?");
                char answer = Console.ReadKey().KeyChar;
                if (answer == '1')
                {


                    foreach (Interfaces.ICard card in currentPlayer.Hand)
                    {
                        NameOfCard name = (NameOfCard)card.Properties[0];
                        Console.WriteLine((i++).ToString() + " " + name.Name);
                    }
                    i = Convert.ToInt32(Console.ReadLine());
                    currentPlayer.Hand[i].intoTheGame();
                }
            }


            List<Interfaces.ICard> playerCards = new List<Interfaces.ICard>(cardInGame.Where(c => c.Owner == currentPlayer));

            if (cardInGame.Count(c => c.Owner == currentPlayer) != 0)
            {
                Console.WriteLine("Выбери кем атаковать");
                i = 0;
                foreach (Interfaces.IHaveProperties card in playerCards)
                {
                    NameOfCard name = (NameOfCard)card.Properties[0];
                    Console.WriteLine((i++).ToString() + " " + name.Name);
                }
                i = Convert.ToInt32(Console.ReadLine());
                selectedCard = playerCards[i];


                enemyCards = new List<Interfaces.ITakeMessage>(players.Where(p => p != currentPlayer));
                enemyCards.AddRange(new List<Interfaces.ITakeMessage>(cardInGame.Where(c => c.Owner != currentPlayer)));
                if (enemyCards.Count != 0)
                {
                    Console.WriteLine("Выбери кого атаковать");
                    i = 0;
                    foreach (Interfaces.IHaveProperties card in enemyCards)
                    {
                        NameOfCard name = (NameOfCard)card.Properties[0];
                        Console.WriteLine((i++).ToString() + " " + name.Name);
                    }
                    i = Convert.ToInt32(Console.ReadLine());
                    List<Interfaces.ITakeMessage> enemyCard = new List<Interfaces.ITakeMessage>();
                    enemyCard.Add(enemyCards[i]);

                    Interfaces.IMessage message = selectedCard.createMessage();
                    message.Receivers.Add(enemyCard[0]);
                    foreach (Interfaces.IAction action in message.Actions)
                        ApplyEffectsByMoment(message.Sender, action, currentPlayer, MomentsOfEvents.InMove);
                    SendMessage(message);
                }
            }

        }
    }
}
