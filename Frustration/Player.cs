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
        public String Name { get; private set; }

        public Player(Colour c, int offset, string name)
        {
            //record colour in player
            pieces = new List<Piece>();
            Name = name;
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

        public List<Piece> GetAvailablePieces(int diceValue)
        {
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
