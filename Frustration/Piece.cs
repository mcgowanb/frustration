using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frustration
{
    enum PieceState { Playing, Home, Safe, Finish }
    enum Colour { Red, Yellow, Green, Blue }
    class Piece
    {
        private const int BOARD_MOVES = 28;
        private const int HOME_SPACES = 4;
        public PieceState State { get; private set; }
        public int Position { get; private set; }
        public Colour Colour { get; private set; }

        public Piece(Colour pc)
        {
            ReturnHome();
            Colour = pc;
        }

        public Boolean Move(int diceValue)
        {
            Boolean complete = false;
            //if 6 and home
            if (diceValue == 6 && this.State.Equals(PieceState.Home))
            {
                complete = MoveOntoBoard();
            }
            else if (Position + diceValue <= BOARD_MOVES)
            {
                Position += diceValue;
                complete = true;
            }
            else if (Position + diceValue <= BOARD_MOVES + HOME_SPACES)
            {
                State = PieceState.Safe;
                Position += diceValue;
                complete = true;
            }

            return complete;
        }

        public Boolean IsAvailable(int diceRoll)
        {
            bool available = false;

            if (State.Equals(PieceState.Home) && diceRoll == 6)
            {
                available = true;
            }

            else if ((State.Equals(PieceState.Playing) || State.Equals(PieceState.Safe)) && Position + diceRoll <= BOARD_MOVES + HOME_SPACES)
            {
                available = true;
            }
            return available;
        }

        public void ReturnHome()
        {
            State = PieceState.Home;
            Position = 0;
        }

        public bool MoveOntoBoard()
        {
            State = PieceState.Playing;
            Position = 0;
            return true;
        }

    }
}
