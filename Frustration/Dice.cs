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
        const int DICE_LIMIT = 7;
        public Dice()
        {
            RandomFactory = new Random();
        }
        public int Roll()
        {
            return RandomFactory.Next(1, DICE_LIMIT + 1);
        }
    }
}
