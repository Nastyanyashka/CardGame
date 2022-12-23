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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CardGame;
using CardGame.Interfaces;
using CardGame.InGameProperties;
using CardGame.Cards;
using CardGame.Effects;
using CardGame.Actions;
namespace GraphicsForGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            Game gameWindow = new Game();     
            this.Close();
            gameWindow.Show();
            
        }

        private void Cards_Click(object sender, RoutedEventArgs e)
        {
            EditDeck editDeckWindow = new EditDeck();
            this.Close();
            editDeckWindow.Show();
        }
    }
}
