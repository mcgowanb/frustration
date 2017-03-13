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
        Dice dice;
        Player player;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            int n = Convert.ToInt32(txtNoPlayers.Text);
            game = new Game(n);

            lbxPlayer1.ItemsSource = game.players.ElementAt(0).GetAvailablePieces();



          //  game.PlayGame();
        }

        public void btnPlayerRoll1_Click(object sender, RoutedEventArgs e)
        {
            
        //  Start Turn
        //  Roll Dice

       


            //  Populate List Box

  // lbxPlayer1.ItemsSource = availablePieces;


        }

        private void btnMovePlayer1_Click(object sender, RoutedEventArgs e)
        {
            //  Get selected item
            Piece piece = lbxPlayer1.SelectedItem as Piece;

            //  Move selected piece

            game.MovePiece(piece);
        }
    }
}
