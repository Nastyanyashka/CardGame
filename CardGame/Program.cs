// See https://aka.ms/new-console-template for more information
using CardGame.Cards;
using CardGame.Interfaces;
using CardGame;
using CardGame.InGameProperties;


Ogr ogr = new Ogr();
ogr.Damage+=1;
ogr.Effects.Add(new CardGame.Effects.Inspiration(3));

Console.WriteLine();




















































//List<ICard> cards = new List<ICard>();
//cards.Add(new Ogr());
//cards.Add(new Ogr());
//cards.Add(new Knight());
//List<ICard> cards2 = new List<ICard>();
//cards2.Add(new Ogr());
//cards2.Add(new Ogr());
//GameManager game = GameManager.game;

//Deck deck = new Deck(cards);

//Deck deck2 = new Deck(cards2);
//IPlayer p1 = new Player(deck);


////p1.Hand.Add(new Ogr(p1));
//IPlayer p2 = new Player(deck2);
////p2.Hand.Add(new Wizard());

//game.Players.Add(p1);
//game.Players.Add(p2);


//game.NextPlayer();
//while (game.CheckToWin() == null)
//{
//    printData();
//    game.MakeMove();
//    Console.WriteLine("\n");
//}
//Console.WriteLine("Победил: " + ((Player)game.CheckToWin()).Name);
        
//static void printData()
//{
//    GameManager game = GameManager.game;
//    List<IHaveBasicProperties> objs = new List<IHaveBasicProperties>(game.Players);
//    objs.AddRange(new List<IHaveBasicProperties>(game.CardsInGame));
//    foreach (IHaveBasicProperties obj in objs)
//        Console.WriteLine(obj.Name +" Attack"+ " - " + ((IHaveBasicProperties)obj).Damage + " Health" + " - " + ((IHaveBasicProperties)obj).HealthPoints); 
//}