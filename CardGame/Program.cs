// See https://aka.ms/new-console-template for more information
using CardGame.Cards;
using CardGame.Interfaces;
using CardGame;

GameManager game = GameManager.game;
IPlayer p1 = new Player(10, 10, 20, null);
p1.Properties.Add("Name", "p1");
p1.Hand.Add(new Ogr(p1, 5));
IPlayer p2 = new Player(10, 10, 20, null);
p2.Properties.Add("Name", "p2");
p2.Hand.Add(new Wizard(p2, 1));
game.players.Add(p2);
game.players.Add(p1);

game.NextPlayer();
while (game.CheckToWin() == null)
{
    printData();
    game.MakeMove();
    Console.WriteLine("\n");
}
Console.WriteLine("Победил: " + game.CheckToWin().Properties["Name"]);
        
static void printData()
{
    GameManager game = GameManager.game;
    List<IHaveProperties> objs = new List<IHaveProperties>(game.players);
    objs.AddRange(new List<IHaveProperties>(game.cardInGame));
    foreach (IHaveProperties obj in objs)
        Console.WriteLine(obj.Properties["Name"] + " - " + ((IHaveProperties)obj).healthPoint);
}