using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frustration
{
    class Board
    {
        Piece[] locations;

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
            locations[absoluteMove - diceValue] = null;
            Piece boardPiece = locations[absoluteMove];

            locations[absoluteMove] = playerPiece;
            //if a piece has moved to home, remove from the board
            return boardPiece;

        }


    }
}
