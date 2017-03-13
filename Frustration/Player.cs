using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frustration
{
    class Player
    {
        const int NUMBER_OF_PIECES = 4;

        public List<Piece> pieces { get; private set; }
        public int Offset { get; private set; }
        public int MyProperty { get; set; }

        public Player(Colour c, int offset)
        {
            pieces = new List<Piece>();
            Offset = offset;
            CreatePieces(c);
        }


        private void CreatePieces(Colour c)
        {
            for (int i = 0; i < NUMBER_OF_PIECES; i++)
            {
                pieces.Add(new Piece(c));
            }
        }

        public List<Piece> GetAvailablePieces(int diceValue = 0)
        {
            if (diceValue == 0)
            {
                return pieces;
            }
            List<Piece> availablePieces = new List<Piece>();
            foreach (var item in pieces)
            {
                if (item.IsAvailable(diceValue))
                {
                    availablePieces.Add(item);
                }
            }
            return availablePieces;
        }

        public Boolean CheckForWinner()
        {
            Boolean hasWon = false;
            hasWon = pieces.Any(p => p.State.Equals(PieceState.Finish));
            return hasWon;
        }
    }
}
