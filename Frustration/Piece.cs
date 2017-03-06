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
        public PieceState State { get; private set; }
        public int Position { get; private set; }
        public Colour Colour { get; private set; }

        public Piece(Colour pc)
        {
            ReturnHome();
            Colour = pc;
        }

        public Boolean Move(int steps)
        {
            Boolean complete = false;
            if (Position + steps <= Board.RegularPlaces)
            {
                Position += steps;
                complete = true;
            }
            else if (Position + steps <= Board.BOARD_SPACES)
            {
                State = PieceState.Safe;
                Position += steps;
                complete = true;
            }

            return complete;
        }

        public Boolean IsAvailable(int steps)
        {
            Boolean available = false;

            if (State.Equals(PieceState.Home) && steps == 6)
            {
                available = true;
            }

            else if ((State.Equals(PieceState.Playing) || State.Equals(PieceState.Safe)) && Position + steps <= Board.BOARD_SPACES)
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

    }
}
