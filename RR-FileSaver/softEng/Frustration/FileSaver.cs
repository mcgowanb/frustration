using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Frustration
{
    public class FileSaver
    {
        public void SaveGame(Game g)
        {
            Console.WriteLine("Game has been saved");

        }
        public Game LoadGame()
        {
            //  return new Game(int nPlayers);
            MessageBox.Show("Game is loading!!");
            return new Game();

        }
        public void ClearGame()
        {
            //delete the game 
        }
    }
}
