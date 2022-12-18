// See https://aka.ms/new-console-template for more information
using CardGame.Cards;
using CardGame.Interfaces;
using CardGame;
using CardGame.InGameProperties;


List<ICard> cards = new List<ICard>();
cards.Add(new Ogr());
cards.Add(new Ogr());
cards.Add(new Ogr());
cards.Add(new Ogr());
cards.Add(new Ogr());
cards.Add(new Knight());
List<ICard> cards2 = new List<ICard>();
cards2.Add(new Ogr());
cards2.Add(new Ogr());
cards2.Add(new IceBolt());
GameManager game = GameManager.Game;

Deck deck = new Deck(cards);

Deck deck2 = new Deck(cards2);
IPlayer p1 = new Player(deck,"Player1");


//p1.Hand.Add(new Ogr(p1));
IPlayer p2 = new Player(deck2,"Player2");
//p2.Hand.Add(new Wizard());

game.Players.Add(p1);
game.Players.Add(p2);


game.NextPlayer();
while (game.CheckToWin() == null)
{
    printData();
    game.MakeMove();
    Console.WriteLine("\n");
}
Console.WriteLine("Победил: " + ((Player)game.CheckToWin()).Name);

static void printData()
{
    GameManager game = GameManager.Game;
    List<IHaveBasicProperties> objs = new List<IHaveBasicProperties>(game.Players);
    objs.AddRange(new List<IHaveBasicProperties>(game.CardsInGame));
    foreach (IHaveBasicProperties obj in objs)
        Console.WriteLine(obj.Name + " Attack" + " - " + ((IHaveAttackDamage)obj).Damage + " Health" + " - " + ((IHaveHealthPoints)obj).HealthPoints);
}