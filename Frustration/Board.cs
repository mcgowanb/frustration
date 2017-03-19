using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frustration
{
    class Board
    {
        public Piece[] locations { get; private set; }

        public Board()
        {
            InitialiseLocations();
        }

        private void InitialiseLocations()
        {
            locations = new Piece[Game.BOARD_MOVES];
        }

        public Piece Move(Piece playerPiece, int diceValue, int playerOffset)
        {
            int absoluteMove = playerPiece.Position + playerOffset;
            //moving around the board from 28 round to 0 again
            if (absoluteMove > locations.Length)
            {
                absoluteMove -= locations.Length;
            }
            //handle out of bounds exception if offset is 0
            if(absoluteMove - diceValue > 0)
                locations[absoluteMove - diceValue] = null;
            Piece boardPiece = locations[absoluteMove];

            locations[absoluteMove] = playerPiece;
            //if a piece has moved to home, remove from the board
            return boardPiece;

        }

        public List<String> DisplayBoard()
        {
            List<String> l = new List<String>();
            for (int i = 0; i < locations.Length; i++)
            {
                Piece p = locations[i];
                String colour = "Empty";
                String pieceLocation = "Empty";
                if (p != null)
                {
                    colour = p.Colour.ToString() ?? "Empty";
                    pieceLocation = p.Position.ToString() ?? "Empty";
                    l.Add(String.Format("{0} Relative Location: {1} Board Loaction: {2}", colour, pieceLocation, i));

                }
                else
                    l.Add(String.Format("{0} Empty", i));
            }
            return l;
        }

      


    }
}
