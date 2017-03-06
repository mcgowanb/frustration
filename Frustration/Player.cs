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

        public Piece SelectPiece(int i)
        {
            return pieces.ElementAt(i);
        }

        public List<Piece> GetAvailablePieces(int moveLength)
        {
            List<Piece> availablePieces = new List<Piece>();
            foreach (var item in pieces)
            {
                if (item.IsAvailable(moveLength))
                {
                    availablePieces.Add(item);
                }
            }
            return availablePieces;
        }
    }
}
