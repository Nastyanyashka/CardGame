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
        private static GameManager? _game;
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
            currentPlayer = null!;
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
            ApplyEffectsByMoment(null!, null!, MomentsOfEvents.BetweenMove);
        }
        public void EnterCardInGame(Interfaces.ICard card)
        {
            cardInGame.Add(card);
            ApplyEffectsByMoment(card, null!, MomentsOfEvents.EnterTheGame);
        }
        public void ExitCardFromGame(Interfaces.ICard card)
        {
            cardInGame.Remove(card);
            ApplyEffectsByMoment(card, null!, MomentsOfEvents.ExitTheGame);
            cemetery.Add(card);
        }
        public void SendMessage(Interfaces.IMessage message)
        {
            ApplyEffectsByMoment(message.Sender, null!, MomentsOfEvents.SendingMessage);
            foreach (Interfaces.ITakeMessage resipient in message.Receivers)
                resipient.takeMessage(message);
            ApplyEffectsByMoment(message.Sender, null!,  MomentsOfEvents.ReceivingMessage);
        }
        public Interfaces.IPlayer CheckToWin()
        {
            if (players.Count(p => p.HealthPoints > 0) > 1)
                return null!;
            else
                return players.Find(p => p.HealthPoints > 0)!;
        }
        private void ApplyEffectsByMoment(Interfaces.ISendMessage initiator, Interfaces.IAction action, MomentsOfEvents moment)
        {
            List<Interfaces.IHaveEffects> effectsOwner = new List<Interfaces.IHaveEffects>(players);
            effectsOwner.AddRange(cardInGame);
            foreach (Interfaces.IHaveEffects owner in effectsOwner)
                foreach (Interfaces.IEffects effect in owner.Effects.Where(e => e.moments.Contains(moment)))
                    effect.GetEffectMethod(moment, (ITakeMessage)owner)(initiator, action, (Interfaces.ITakeMessage)owner);
        }
        public void MakeMove()
        {
            ApplyEffectsByMoment(null!, null!,MomentsOfEvents.BeforeMove);
            int i = 0;
            Interfaces.ICard selectedCard;
            List<Interfaces.ITakeMessage> enemyCards = new List<Interfaces.ITakeMessage>();
            if (currentPlayer.Hand.Count != 0)
            {
                Console.WriteLine("Выставить карту?");
                char answer = Console.ReadKey().KeyChar;
                Console.WriteLine("");
                if (answer == '1')
                {
                    foreach (Card card in currentPlayer.Hand)
                        Console.WriteLine((i++).ToString() + " " + card.Name);
                    i = Convert.ToInt32(Console.ReadLine());
                    currentPlayer.Hand[i].intoTheGame();
                }
            }

            List<Interfaces.ICard> playerCards = new List<Interfaces.ICard>(cardInGame.Where(c => c.Owner == currentPlayer));

            if (cardInGame.Count(c => c.Owner == currentPlayer) != 0)
            {
                Console.WriteLine("Выбери кем атаковать");
                i = 0;
                foreach (Card card in playerCards)
                    Console.WriteLine((i++).ToString() + " " + card.Name);
                i = Convert.ToInt32(Console.ReadLine());
                selectedCard = playerCards[i];


                enemyCards = new List<Interfaces.ITakeMessage>(players.Where(p => p != currentPlayer));
                enemyCards.AddRange(new List<Interfaces.ITakeMessage>(cardInGame.Where(c => c.Owner != currentPlayer)));
                if (enemyCards.Count != 0)
                {
                    Console.WriteLine("Выбери кого атаковать");
                    i = 0;
                    foreach (Card card in enemyCards)
                        Console.WriteLine((i++).ToString() + " " + card.Name);
                    i = Convert.ToInt32(Console.ReadLine());
                    ITakeMessage enemyCard = enemyCards[i];

                    Interfaces.IMessage message = selectedCard.createMessage();
                    message.Receivers.Add(enemyCard);
                    foreach (Interfaces.IAction action in message.Actions)
                        ApplyEffectsByMoment(message.Sender, action, MomentsOfEvents.InMove);
                    SendMessage(message);
                }
            }

            ApplyEffectsByMoment(null!, null!, MomentsOfEvents.AfterMove);
            NextPlayer();
        }
    }  
}
