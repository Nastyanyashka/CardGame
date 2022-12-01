// See https://aka.ms/new-console-template for more information
using CardGame.Cards;
using CardGame.Interfaces;
using CardGame;







GameManager game = GameManager.game;
IPlayer p1 = new Player(null);
p1.Hand.Add(new Ogr(p1));
IPlayer p2 = new Player(null);
p2.Hand.Add(new Wizard(p2));
game.players.Add(p2);
game.players.Add(p1);

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
    GameManager game = GameManager.game;
    List<IHaveBasicProperties> objs = new List<IHaveBasicProperties>(game.players);
    objs.AddRange(new List<IHaveBasicProperties>(game.cardInGame));
    foreach (IHaveBasicProperties obj in objs)
        Console.WriteLine(obj.Name + " - " + ((IHaveBasicProperties)obj).HealthPoints.Amount);
}