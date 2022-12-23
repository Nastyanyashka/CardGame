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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
namespace GraphicsForGame
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        ICard card;
        StateOfCard state;
        InHand inHandState;
        static UserControl1 temp;
        //Image image;
        public UserControl1(ICard card, StateOfCard state, InHand inHandState)
        {
            InitializeComponent();
            this.card = card;
            this.state = state;
            this.inHandState = inHandState;
            if(card is IPlayer)
            {
                HP.Background = new SolidColorBrush(Colors.Black);
                Attack.Background = new SolidColorBrush(Colors.Black);
                Name.Background = new SolidColorBrush(Colors.Black);  
            }
            if (card != null)
            {
                Name.Content = card.Name;
                Update();
            }
        }

        public void MouseDown123(object sender, MouseButtonEventArgs e)
        {
            if (state == StateOfCard.Filled && card.Owner == GameManager.Game.CurrentPlayer)
            {
                //e.Handled = true;
                if (GameManager.Game.CurrentPlayer == card.Owner && card.State == States.Activated && card.CanMakeMove == true)
                    GameManager.Game.SelectedCard = card;
                //else if (GameManager.Game.SelectedCard != null)
                //{
                //    GameManager.Game.MakeMove(GameManager.Game.SelectedCard, card);
                //}
                Trace.WriteLine("User Control Clicked");
                temp = this;
            }
            else if(state == StateOfCard.Filled && card.Owner != GameManager.Game.CurrentPlayer && GameManager.Game.SelectedCard!=null && temp.inHandState== InHand.No && this.inHandState == InHand.No)
            {
                GameManager.Game.MakeMove(GameManager.Game.SelectedCard, this.card);
                if(GameManager.Game.CheckToWin())
                {
                    return;
                }
                this.Update();
                temp.Update();
                temp = null!;
                GameManager.Game.SelectedCard = null!;
            }
            else if(state == StateOfCard.Filled && card.Owner != GameManager.Game.CurrentPlayer && GameManager.Game.SelectedCard != null && temp.inHandState == InHand.Yes && this.inHandState == InHand.No
                && temp.card is not CreatureCard)
            {
                GameManager.Game.MakeMove(GameManager.Game.SelectedCard, this.card);
                if (GameManager.Game.CheckToWin())
                {
                    return;
                }
                this.Update();
                temp.Update();
                temp.Visibility = Visibility.Collapsed;
                temp = null!;
                GameManager.Game.SelectedCard = null!;
            }
            else if(state == StateOfCard.Nofilled) 
            {
                if (temp == null) { return; }
                
                if(temp.state== StateOfCard.Filled && (temp.InHandState == InHand.Yes))
                {
                    this.card = temp.card;
                    this.state = temp.state;
                    this.inHandState = InHand.No;
                    this.Name.Content = this.card.Name;
                    this.Update();
                    this.Visibility = Visibility.Visible;
                    this.Background = new SolidColorBrush(Colors.Black);
                    temp.state = StateOfCard.Nofilled;
                    temp.inHandState = InHand.No;
                    temp.card = null!;
                    temp.Visibility = Visibility.Collapsed;
                    GameManager.Game.ThrowCardInGame(GameManager.Game.SelectedCard);
                }
                temp = null!;
            }
        }
        public void Update()
        {
            if (card != null)
            {
                if (card is IHaveHealthPoints)
                    HP.Content = ((IHaveHealthPoints)card).HealthPoints;
                Attack.Content = card.Damage;
            }
        }
        public ICard Card { get { return card; } }
        public InHand InHandState { get {return inHandState; } set { inHandState = value; } }
        public StateOfCard State { get { return state; } set { state = value; } }
    }
}
