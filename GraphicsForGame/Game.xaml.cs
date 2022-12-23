using CardGame;
using CardGame.Cards;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;


namespace GraphicsForGame
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public bool player1Turn = true;
        int iteratorP1 = 0;
        int iteratorP2 = 0;

        public Game()
        {
            InitializeComponent();


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
            cards2.Add(new Wizard());
            cards2.Add(new Wizard());
            Deck deck = new Deck(cards);
            Deck deck2 = new Deck(cards2);
            Player p1 = new Player(deck, "Player1");
            Player p2 = new Player(deck2, "Player2");
            GameManager.Game.Players.Add(p1);
            GameManager.Game.Players.Add(p2);

            BitmapImage bmp1 = new BitmapImage();
            bmp1.BeginInit();
            bmp1.UriSource = new Uri(@"D:/C#/CardGame/GraphicsForGame/Images/NecoArc.jpg", UriKind.RelativeOrAbsolute);
            bmp1.EndInit();

            ImageBrush myBrush = new ImageBrush();
            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
            img.Source = bmp1;
            img.Stretch= Stretch.Fill;
            myBrush.ImageSource = img.Source;
            UserControl1 player1 = new UserControl1(p1, StateOfCard.Filled, InHand.No)
            {
                Background = myBrush
            };

            Grid.SetColumn(player1, 2);
            Grid.SetRow(player1, 0);
            GridGame.Children.Add(player1);

            BitmapImage bmp2 = new BitmapImage();
            bmp2.BeginInit();
            bmp2.UriSource = new Uri(@"D:/C#/CardGame/GraphicsForGame/Images/Sus.jpg", UriKind.RelativeOrAbsolute);
            bmp2.EndInit();


            ImageBrush myBrush1 = new ImageBrush();
            System.Windows.Controls.Image img2 = new System.Windows.Controls.Image();
            img2.Source = bmp2;

            img2.Stretch = Stretch.Fill;

            myBrush1.ImageSource = img2.Source;
            UserControl1 player2 = new UserControl1(p2, StateOfCard.Filled, InHand.No)
            {
                Background = myBrush1
            };

            Grid.SetColumn(player2, 2);
            Grid.SetRow(player2, 4);
            GridGame.Children.Add(player2);

            UserControl1 emptiness = new UserControl1(null!, StateOfCard.Nofilled, InHand.No)
            {
                Background = new SolidColorBrush(Colors.White)
            };


            Grid.SetColumn(emptiness, 0);
            Grid.SetRow(emptiness, 1);
            GridGame.Children.Add(emptiness);
            UserControl1 emptiness1 = new UserControl1(null!, StateOfCard.Nofilled, InHand.No)
            {
                Background = new SolidColorBrush(Colors.White)
            };

            Grid.SetColumn(emptiness1, 1);
            Grid.SetRow(emptiness1, 1);
            GridGame.Children.Add(emptiness1);
            UserControl1 emptiness2 = new UserControl1(null!, StateOfCard.Nofilled, InHand.No)
            {
                Background = new SolidColorBrush(Colors.White)
            };

            Grid.SetColumn(emptiness2, 2);
            Grid.SetRow(emptiness2, 1);
            GridGame.Children.Add(emptiness2);
            UserControl1 emptiness3 = new UserControl1(null!, StateOfCard.Nofilled, InHand.No)
            {
                Background = new SolidColorBrush(Colors.White)
             };

            Grid.SetColumn(emptiness3, 3);
            Grid.SetRow(emptiness3, 1);
            GridGame.Children.Add(emptiness3);
            UserControl1 emptiness4 = new UserControl1(null!, StateOfCard.Nofilled, InHand.No)
            {
                Background = new SolidColorBrush(Colors.White)
            };

            Grid.SetColumn(emptiness4, 4);
            Grid.SetRow(emptiness4, 1);
            GridGame.Children.Add(emptiness4);

            UserControl1 emptiness5 = new UserControl1(null!, StateOfCard.Nofilled, InHand.No)
            {
                Background = new SolidColorBrush(Colors.White)
            };

            Grid.SetColumn(emptiness5, 0);
            Grid.SetRow(emptiness5, 3);
            GridGame.Children.Add(emptiness5);
            UserControl1 emptiness6 = new UserControl1(null!, StateOfCard.Nofilled, InHand.No)
            {
                Background = new SolidColorBrush(Colors.White)
            };

            Grid.SetColumn(emptiness6, 1);
            Grid.SetRow(emptiness6, 3);
            GridGame.Children.Add(emptiness6);
            UserControl1 emptiness7 = new UserControl1(null!, StateOfCard.Nofilled, InHand.No)
            {
                Background = new SolidColorBrush(Colors.White)
            };

            Grid.SetColumn(emptiness7, 2);
            Grid.SetRow(emptiness7, 3);
            GridGame.Children.Add(emptiness7);
            UserControl1 emptiness8 = new UserControl1(null!, StateOfCard.Nofilled, InHand.No)
            {
                Background = new SolidColorBrush(Colors.White)
            };

            Grid.SetColumn(emptiness8, 3);
            Grid.SetRow(emptiness8, 3);
            GridGame.Children.Add(emptiness8);
            UserControl1 emptiness9 = new UserControl1(null!, StateOfCard.Nofilled, InHand.No)
            {
                Background = new SolidColorBrush(Colors.White)
            };

            Grid.SetColumn(emptiness9, 4);
            Grid.SetRow(emptiness9, 3);
            GridGame.Children.Add(emptiness9);


            NextTurn();
        }
        private void NextTurn()
        {
            GameManager.Game.NextPlayer();
            ICard card = GameManager.Game.TakeCard();
            if(card != null){
                if (player1Turn == false)
                {
                    UserControl1 someCardInHand = new UserControl1(card, StateOfCard.Filled, InHand.Yes)
                    {
                        Background = new SolidColorBrush(Colors.Black),
                        Margin = new Thickness(2),
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    HandP2.Children.Add(someCardInHand);
                    
                }
                else if (player1Turn == true)
                {
                    UserControl1 someCardInHand = new UserControl1(card, StateOfCard.Filled,InHand.Yes)
                    {
                        Background = new SolidColorBrush(Colors.Black),
                        Margin = new Thickness(2),
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    HandP1.Children.Add(someCardInHand);
                }
            }
        }
        //public void GridClick_Click()
        //{
        //    //e.GetPosition
            
        //    Trace.WriteLine("Grid CLicked");
        //    bool checker = false;
        //    UIElement smth123;
        //    if (GameManager.Game.SelectedCard != null)
        //    {
        //        GameManager.Game.ThrowCardInGame(GameManager.Game.SelectedCard);
        //        if(player1Turn== true)
        //        {
        //            for(int i = 0;i<HandP1.Children.Count;i++)
        //            {
        //                smth123 = HandP1.Children[i];
        //                if (smth123 is UserControl1)
        //                {
        //                    ((UserControl1)smth123).Update();
        //                    if (((UserControl1)smth123).Card == GameManager.Game.SelectedCard && checker == false)
        //                    {
        //                        checker = true;
        //                        Grid.SetRow(smth123, 3);
        //                        Grid.SetColumn(smth123, iteratorP1);
        //                        HandP1.Children.Remove(smth123);
        //                        GridGame.Children.Add(smth123);
        //                        iteratorP1++;
        //                        //надо выбрал элемент , чтобы selected card = карте нажатия
        //                        //break;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            for (int i = 0; i < HandP2.Children.Count; i++)
        //            {
        //              smth123 = HandP2.Children[i];
        //              if (smth123 is UserControl1)
        //              {
        //                  ((UserControl1)smth123).Update();
        //                if (((UserControl1)smth123).Card == GameManager.Game.SelectedCard && checker == false)
        //                {
        //                        checker = true;
        //                        Grid.SetRow(smth123, 1);
        //                        Grid.SetColumn(smth123, iteratorP2);
        //                        HandP2.Children.Remove(smth123);
        //                        GridGame.Children.Add(smth123);
        //                        iteratorP2++;
        //                        //break;
        //                }
        //              }
        //            }                    
        //        }
        //    }


           
        //    for (int i = 0; i < GridGame.Children.Count; i++)
        //    {
        //        smth123 = GridGame.Children[i];
        //        if (smth123 is UserControl1)
        //        {
        //            ((UserControl1)smth123).Update();
        //        }

        //    }
        //    //if (GameManager.Game.SelectedCard is not ICreatureCard)
        //    //    GameManager.Game.MakeMove(GameManager.Game.SelectedCard,);
        //}

        private void EndTurn_Click(object sender, RoutedEventArgs e)
        {
            if(player1Turn == true)
            {
                player1Turn = false;
            }
            else
            {
                player1Turn = true;
            }
            UIElement smth123;
            for (int i = 0; i < GridGame.Children.Count; i++)
            {
                smth123 = GridGame.Children[i];
                if (smth123 is UserControl1)
                {
                    ((UserControl1)smth123).Update();
                }

            }
            NextTurn();
        }

    }
}
