using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frustration
{
    class Board
    {
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

        public Piece Move(Piece playerPiece, int diceValue)
        {
            Piece boardPiece = locations[playerPiece.Position];
            if (boardPiece != null)
            {
                return locations[playerPiece.Position];
            }
            else locations[playerPiece.Position] = playerPiece;

            return boardPiece;

        }


    }
}
