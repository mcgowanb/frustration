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
        int[] locations;

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
            locations = new int[BOARD_SPACES];
            for (int i = 0; i < BOARD_SPACES; i++)
            {
                locations[i] = i;
            }
        }

        public Piece Move(Piece p, int diceValue)
        {
            //check the board for an existing piece at that location
            //if found, return the piece at that location
            //else return null
            throw new NotImplementedException();
        }


    }
}
