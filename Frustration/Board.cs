using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frustration
{
    class Board
    {
        // to be changed
        public const int BOARD_SPACES = 32;
        const int HOME_SPACES = 4;
        Piece[] locations;

        public static int RegularPlaces
        {
            get
            {
                return BOARD_SPACES - HOME_SPACES;
            }
        }

        public Board()
        {
            InitialiseLocations();
        }

        private void InitialiseLocations()
        {
            locations = new Piece[BOARD_SPACES];
        }

        public Piece Move(Piece playerPiece, int diceValue, int playerOffset)
        {
            int absoluteMove = playerPiece.Position + diceValue + playerOffset;
            if(absoluteMove > locations.Length)
            {
                absoluteMove -= locations.Length;
            }
            Piece boardPiece = locations[absoluteMove];
            if (boardPiece != null)
            {
                return locations[playerPiece.Position];
            }
            else locations[playerPiece.Position] = playerPiece;
            //if a piece has moved to home, remove from the board
            return boardPiece;

        }


    }
}
