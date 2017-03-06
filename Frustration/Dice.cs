using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frustration
{
    class Dice
    {
        static Random RandomFactory;
        const int DICE_LIMIT = 6;
        public Dice()
        {
            RandomFactory = new Random();
        }
        public int RollDice()
        {
            return RandomFactory.Next(DICE_LIMIT + 1);
        }
    }
}
