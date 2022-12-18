using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using CardGame.InGameProperties;
using CardGame.Interfaces;
namespace CardGame
{
    public class GameManager
    {

        private static GameManager? _game;
        public static GameManager Game
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

            cardsInGame = new List<Interfaces.ICard>();
            cemetery = new List<Interfaces.ICard>();
            currentPlayer = null!;
        }
        Random rand = new Random();
        private List<Interfaces.IPlayer> players;
        private List<Interfaces.ICard> cardsInGame;
        private List<Interfaces.ICard> cemetery;
        private Interfaces.IPlayer currentPlayer;
        private bool checker = false;
        public List<IPlayer> Players { get { return players; }
            set
            { if (value == null)
                    throw new ArgumentNullException("");
                players = value;
            }
        }

        public List<ICard> CardsInGame
        {
            get { return cardsInGame; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("");
                cardsInGame = value;
            }
        }

        public List<ICard> Cemetery
        {
            get { return cemetery; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("");
                cemetery = value;
            }
        }
        public IPlayer CurrentPlayer
        {
            get { return currentPlayer; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("");
                currentPlayer = value;
            }
        }


        public void NextPlayer()
        {
            if (checker == false)
            {
                checker = true;
                for (int j = 0; j < players.Count; j++)
                {
                    for (int i = 0; i < players[j].Deck.Cards.Count; i++)
                    {
                        players[j].Deck.Cards[i].Owner = players[j];
                    }
                }
            }
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
            TakeCard();
            //ApplyEffectsByMoment(null!, null!, MomentsOfEvents.BeforeMove);
        }

        public void TakeCard()
        {
            if (currentPlayer.Deck.Cards.Count > 0)
            {
                ICard tmp = currentPlayer.Deck.Cards[rand.Next(0, currentPlayer.Deck.Cards.Count)];
                currentPlayer.Hand.Add(tmp);
                currentPlayer.Deck.Cards.Remove(tmp);
            }
        }
        public void EnterCardInGame(Interfaces.ICard card)
        {
            //сделать так чтобы сообщения хранились в List и имели в себе получателей, потом с помощью SendMessage отправлять каждое сообщение
            List<Interfaces.IMessage> messages = card.createMessage();
            foreach (Interfaces.IMessage message in messages)
            {
                SendMessage(message);
            }
            cardsInGame.Add(card);
            ApplyEffectsByMoment(card, null!, MomentsOfEvents.EnterTheGame);
        }
        public void ExitCardFromGame(Interfaces.ICard card)
        {
            cardsInGame.Remove(card);
            ApplyEffectsByMoment(card, null!, MomentsOfEvents.ExitTheGame);
            cemetery.Add(card);
        }
        public void SendMessage(Interfaces.IMessage message)
        {
            ApplyEffectsByMoment(message.Sender, null!, MomentsOfEvents.SendingMessage);
            foreach (Interfaces.ITakeMessage resipient in message.Receivers)
                resipient.takeMessage(message);
            ApplyEffectsByMoment(message.Sender, null!, MomentsOfEvents.ReceivingMessage);
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
            effectsOwner.AddRange(cardsInGame);
            foreach (Interfaces.IHaveEffects owner in effectsOwner)
            for(int i = 0; i< owner.Effects.Count;i++)
            {
                IEffects effect;
                if (owner.Effects[i].moments.Contains(moment))
                {
                    effect = owner.Effects[i];
                    try
                    {
                       effect.GetEffectMethod(moment, (ITakeMessage)owner)(initiator, action, (Interfaces.ITakeMessage)owner);
                    }
                    catch (NullReferenceException e)
                    { }
                }
            }
        }
        public ICard ChooseCardFromHand()
        {
            int i = 1;
            if (currentPlayer.Hand.Count != 0)
            {
                Console.WriteLine("Выберите карту которую хотите использовать");
                Console.WriteLine("\n0 - Скип хода");
                    foreach (Card card in currentPlayer.Hand)
                        Console.WriteLine((i++).ToString() + " " + card.Name);
                    i = Convert.ToInt32(Console.ReadLine());
                if (i == 0)
                { return null!; }

                    return currentPlayer.Hand[i-1];
            }
            return null!;
        }
        public ICard ChooseAttackingCard() {
            Console.WriteLine("Выбери кем атаковать");
            int i = 0;
            List<Interfaces.ICard> playerCards = new List<Interfaces.ICard>(cardsInGame.Where(c => (c.Owner == currentPlayer)&&c.State == States.Activated));
            foreach (Card card in playerCards)
                Console.WriteLine((i++).ToString() + " " + card.Name);
            i = Convert.ToInt32(Console.ReadLine());
            return playerCards[i];
        }
        public ITakeMessage ChooseAttackedCard(List<ITakeMessage> enemyCards) {
            Console.WriteLine("Выбери кого атаковать");
            int i = 0;
            
            foreach (Card card in enemyCards)
                Console.WriteLine((i++).ToString() + " " + card.Name);
            i = Convert.ToInt32(Console.ReadLine());
            return enemyCards[i];
        }
        public void MakeMove()
        {

            Console.WriteLine($"\n Сейчас ходит {currentPlayer.Name}");
            ApplyEffectsByMoment(null!, null!,MomentsOfEvents.BeforeMove);
            ICard cardFromHand = ChooseCardFromHand();
            ICard selectedCard;
            ITakeMessage enemyCard;
            List<Interfaces.IMessage> messages;
            if (cardFromHand != null)
            {
                if (cardFromHand is ICreatureCard)
                {
                    ((ICreatureCard)cardFromHand).intoTheGame();

                }
                else { currentPlayer.Hand.Remove(cardFromHand); }
                if (cardsInGame.Count(c => (c.Owner == currentPlayer) && (c.State == States.Activated)) != 0 || (cardFromHand is not ICreatureCard))
                {
                    if (cardFromHand is not ICreatureCard)
                    { selectedCard = cardFromHand; }

                    else { selectedCard = ChooseAttackingCard(); }
                    List<Interfaces.ITakeMessage> enemyCards = new List<Interfaces.ITakeMessage>();
                    enemyCards = new List<Interfaces.ITakeMessage>(players.Where(p => p != currentPlayer));
                    enemyCards.AddRange(new List<Interfaces.ITakeMessage>(cardsInGame.Where(c => c.Owner != currentPlayer)));
                    if (enemyCards.Count != 0)
                    {
                        enemyCard = ChooseAttackedCard(enemyCards);
                        messages = selectedCard.createMessage();
                        foreach (Interfaces.IMessage message in messages)
                        {
                            message.Receivers.Add(enemyCard);
                            if (selectedCard is not ICreatureCard)
                            {
                                ApplyEffectsByMoment(message.Sender, message.Actions, MomentsOfEvents.EnterTheGame);
                            }
                            else
                            {
                                ApplyEffectsByMoment(message.Sender, message.Actions, MomentsOfEvents.InMove);
                            }
                            SendMessage(message);
                        }
                    }
                }
            }
            ApplyEffectsByMoment(null!, null!, MomentsOfEvents.AfterMove);
            NextPlayer();
        }
    }  
}
