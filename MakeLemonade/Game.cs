using System;
using MakeLemonade;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeLemonade
{
    public class Game
    {
        public double bank;
        public List<int> CurrentInventory;


        public Game()
        {
            bank = 50;
            CurrentInventory = new List<int>() { 0, 0, 0, 0 };
        }

        public void RunGame()
        {
            Player player = new Player();
            player.Welcome();
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            player.PlayOnePeriod(player);
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();

        }
    }
}