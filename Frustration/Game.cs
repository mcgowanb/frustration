using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frustration
{
    class Game
    {
        List<Player> players;
        List<Player> winners;

        const int MAX_PLAYERS = 4;
        Dice dice;

        public Game(int nPlayers)
        {
            players = new List<Player>();
            winners = new List<Player>();
            dice = new Dice();
            //create players
            //take turn
            //roll dice
            //select piece
            //move piece
        }

        public void PlayGame()
        {
            while (true)
            {
                foreach (var player in players)
                {
                    if (TakeTurn(player))
                    {
                        players.Remove(player);
                        winners.Add(player);
                    }
                }
            }

        }

        public Boolean TakeTurn(Player player)
        {
            Boolean hasWon = false;
            int diceValue = dice.Roll();
            List<Piece> availablePieces = player.GetAvailablePieces(diceValue);
            //player select piece here
            Piece piece = availablePieces.ElementAt(0);

            piece.Move(diceValue);
            //if piece state has changed from playing to home, remove from the board else do nothing on the board
            //move on the board
            hasWon = player.CheckForWinner();

            return hasWon;
        }

        public void AddPlayer(Colour c)
        {
            if (players.Count < MAX_PLAYERS)
            {
                Player p = new Player(c, GetPlayerOffset());
                players.Add(p);
            }
        }

        private int GetPlayerOffset()
        {
            int offset = 0;
            switch (players.Count)
            {
                case 1:
                    offset = 7;
                    break;
                case 2:
                    offset = 14;
                    break;
                case 3:
                    offset = 21;
                    break;
                default:
                    break;
            }
            return offset;
        }

        //public List<Piece> CheckAvailablePieces(Player p, int diceRoll)
        //{
        //    List<Piece> l = new List<Piece>();
        //    foreach (var item in p.pieces)
        //    {
        //        //check all player pieces
        //        //get piece
        //        //check remaining spaces left
        //        //return ones available for play
        //    }

        //    //add pieces that match criteria here
        //    return l;
        //    //throw new NotImplementedException();
        //}
    }
}
