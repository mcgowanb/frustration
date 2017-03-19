using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frustration
{
    class Game
    {
        public List<Player> Players { get; private set; }
        public List<Player> Winners { get; private set; }
        public Boolean RollAgain { get; private set; }

        public Player CurrentPlayer { get; private set; }
        private int playerIdx;
        public int DiceValue { get; private set; }
        public Board board { get; private set; }

        const int MAX_PLAYERS = 4;
        internal const int BOARD_MOVES = 28;
        internal const int HOME_SPACES = 4;
        Dice dice;

        public Game(int nPlayers)
        {
            Players = new List<Player>();
            Winners = new List<Player>();
            dice = new Dice();
            board = new Board();
            CreatePlayers(nPlayers);
            RollAgain = false;
            playerIdx = 0;
        }

        public void SetNextPlayer()
        {
            if (playerIdx == (Players.Count))
            {
                playerIdx = 0;
            }
            CurrentPlayer = Players[playerIdx];
            playerIdx++;
        }
        

        public void MovePiece(Piece p)
        {
            p.Move(DiceValue);
            Piece returned = board.Move(p, DiceValue, CurrentPlayer.Offset);
            if(returned != null)
            {
                returned.ReturnHome();
            }
        }

        public void RollDice()
        {
            RollAgain = false;
            DiceValue = dice.Roll();
            if (DiceValue == 6)
                RollAgain = true;
        }


        public List<Piece> DisplayAvailablePieces()
        {
            try
            {
                List<Piece> availablePieces = CurrentPlayer.GetAvailablePieces(DiceValue);
                return availablePieces;
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
        }

        private int GetPlayerOffset()
        {
            int offset = 0;
            switch (Players.Count)
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
                Players.Add(new Player(colours[i], GetPlayerOffset(), "Player " + (i + 1)));
            }
        }

    }
}
