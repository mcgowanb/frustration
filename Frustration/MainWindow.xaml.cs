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

namespace Frustration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            //int n = Convert.ToInt32(txtNoPlayers.Text);
            game = new Game(4);
            btnRollDice.IsEnabled = true;

            lbxP1.ItemsSource = game.Players.ElementAt(0).pieces;
            lbxP2.ItemsSource = game.Players.ElementAt(1).pieces;
            lbxP3.ItemsSource = game.Players.ElementAt(2).pieces;
            lbxP4.ItemsSource = game.Players.ElementAt(3).pieces;
            lbxBoard.ItemsSource = game.board.DisplayBoard();

            game.SetNextPlayer();
            lblCurrent.Content = "Current Player: " + game.CurrentPlayer.Name;

        }

        private void btnRollDice_Click(object sender, RoutedEventArgs e)
        {
            game.RollDice();
            txtDiceValue.Text = game.DiceValue.ToString();
            if (game.DisplayAvailablePieces().Count == 0)
            {
                MessageBox.Show("No available pieces, moving to next player");
                game.SetNextPlayer();
                lblCurrent.Content = "Current Player: " + game.CurrentPlayer.Name;
            }
            else
            {
                lbxCurrentPlayer.ItemsSource = game.DisplayAvailablePieces();
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnRollDice.IsEnabled = false;
            btnPlayPiece.IsEnabled = false;
        }

        private void btnPlayPiece_Click(object sender, RoutedEventArgs e)
        {
            Piece p = lbxCurrentPlayer.SelectedItem as Piece;
            if (p != null)
            {
                game.MovePiece(p);
                UpdatePage();
                if (game.RollAgain)
                {
                    MessageBox.Show("Rolled a six, play again");
                    lbxCurrentPlayer.ItemsSource = null;
                }
                else
                {
                    game.SetNextPlayer();
                    lblCurrent.Content = "Current Player: " + game.CurrentPlayer.Name;
                    txtDiceValue.Text = null;
                    lbxCurrentPlayer.ItemsSource = null;
                }
            }
        }


        private void UpdatePage()
        {
            lbxP1.Items.Refresh();
            lbxP2.Items.Refresh();
            lbxP3.Items.Refresh();
            lbxP3.Items.Refresh();
            lbxBoard.ItemsSource = game.board.DisplayBoard();

        }

        private void lbxPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxCurrentPlayer.SelectedItem != null)
                btnPlayPiece.IsEnabled = true;

            else
                btnPlayPiece.IsEnabled = false;
        }
    }
}
