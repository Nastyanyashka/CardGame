using CardGame;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GraphicsForGame
{
    /// <summary>
    /// Логика взаимодействия для EditDeck.xaml
    /// </summary>
    public partial class EditDeck : Window
    {
        Dictionary<int, Deck> decks = new Dictionary<int, Deck>();
        static int iterator = 0;
        public EditDeck()
        {
            InitializeComponent();
           
            Label deck = new Label();
            deck.FontSize = 20;
            deck.HorizontalAlignment = HorizontalAlignment.Center;
            deck.VerticalAlignment = VerticalAlignment.Center;
            deck.Width = 200;
            deck.Height = 37;
            deck.Visibility = Visibility.Visible;
            Grid1.Children.Add(deck);
            Grid.SetColumn(deck, 1);
            Grid.SetRow(deck, 0);
            Button DeckReady = new Button()
            {
                Margin = new Thickness(0, 323, 0, 0),
                Height = 42,
                Width = 210,
                Content = "Готово",
                FontSize = 20
            };
            DeckReady.Click += ReadyDeck_Button;
            Grid.SetColumn(DeckReady, 1);
            Grid.SetRow(DeckReady, 1);
            Grid1.Children.Add(DeckReady);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CreateDeck.Visibility = Visibility.Collapsed;
            LabelDecks.Visibility = Visibility.Collapsed;
            decks.Add(iterator, new Deck(new List<ICard>()));
            
        }
        private void ReadyDeck_Button(object sender, RoutedEventArgs e)
        {
            CreateDeck.Visibility = Visibility.Visible;
            LabelDecks.Visibility = Visibility.Visible;

        }
    }
}
