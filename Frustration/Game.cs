using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frustration
{
    class Game
    {
        public List<Player> players;
        List<Player> winners;
        Board board;
        int currentDiceValue;
        Player currentPlayer;
        bool rollAgain = false;

        const int MAX_PLAYERS = 4;
        internal const int BOARD_MOVES = 28;
        internal const int HOME_SPACES = 4;
        Dice dice;

        public Game(int nPlayers)
        {
            players = new List<Player>();
            winners = new List<Player>();
            dice = new Dice();
            board = new Board();
            CreatePlayers(nPlayers);
            //create players
            //take turn
            //roll dice
            //select piece
            //move piece
        }

        public void PlayGame()
        {
            while (players.Count > 1)
            {
                foreach (var player in players)
                {
                    StartTurn(player);

                    if (player.CheckForWinner())
                    {
                        players.Remove(player);
                        winners.Add(player);
                    }
                    EndTurn(player);
                }
            }
            //game over summary

        }


        //public void StartTurn(Player player)
        //{


        //    bool rollAgain = false;
        //    //should the user actually physically roll the dice
        //    int diceValue = dice.Roll();
        //    if (diceValue == 6)
        //        rollAgain = true;
        //    List<Piece> availablePieces = player.GetAvailablePieces(diceValue);

        //    if (availablePieces.Count == 0)
        //    {
        //        return;
        //    }



        //}


        public void StartTurn(Player player)
        {


            //bool rollAgain = false;
            //should the user actually physically roll the dice
            currentDiceValue = dice.Roll();
            if (currentDiceValue == 6)
                rollAgain = true;
            List<Piece> availablePieces = player.GetAvailablePieces(currentDiceValue);


            //  If nothing available
            if (availablePieces.Count == 0)
            {
                return;
            }




            if (rollAgain)
                StartTurn(player);
            //if piece state has changed from playing to home, remove from the board else do nothing on the board
            //move on the board
        }

        public void MovePiece(Piece piece)
        {
            ////player select piece here
            //Piece piece = availablePieces.ElementAt(0);

            piece.Move(currentDiceValue);
            //return the dice value here, as if its changing state from outside to inside then the move becomes 1 instead of 6

            Piece returnPiece = board.Move(piece, currentDiceValue, currentPlayer.Offset);
            if (returnPiece != null)
                returnPiece.ReturnHome();

        }




        public void EndTurn(Player player)
        {

            if (rollAgain)
                StartTurn(player);
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
                    offset = 0;
                    break;
            }
            return offset;
        }

        private void CreatePlayers(int n)
        {
            Colour[] colours = { Colour.Blue, Colour.Green, Colour.Red, Colour.Yellow };
            for (int i = 0; i < n; i++)
            {
                players.Add(new Player(colours[i], GetPlayerOffset()));
            }
        }

    }
}
