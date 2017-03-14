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
            int n = Convert.ToInt32(txtNoPlayers.Text);
            game = new Game(n);

            lbxPlayer1.ItemsSource = game.players.ElementAt(0).GetAvailablePieces();
            lbxPlayer2.ItemsSource = game.players.ElementAt(1).GetAvailablePieces();
            lbxPlayer3.ItemsSource = game.players.ElementAt(2).GetAvailablePieces();
            lbxPlayer4.ItemsSource = game.players.ElementAt(3).GetAvailablePieces();


            //  game.PlayGame();
        }

        public void btnRollDice_Click(object sender, RoutedEventArgs e)
        {

            //  Start Turn - method
            // update dice roll box with game.CurrentDiceValue
            game.StartTurn(game.currentPlayer);

            txbCurrentDice.Text = Convert.ToString(game.CurrentDiceValue);
            txbCurrentRollAgain.Text = Convert.ToString(game.rollAgain);
            lbxMain.ItemsSource = game.currentPlayer.GetAvailablePieces();

            lbxBoard.ItemsSource = game.board.locations;
            //  Populate List Box

            // lbxPlayer1.ItemsSource = availablePieces;


        }

        private void btnMove_Click(object sender, RoutedEventArgs e)
        {
            //  Get selected item
            Piece piece = lbxMain.SelectedItem as Piece;

            //  Move selected piece

            game.MovePiece(piece);

            lbxMain.ItemsSource = game.currentPlayer.GetAvailablePieces();
        }
    }
}
