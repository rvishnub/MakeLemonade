using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeLemonade
{
    public class Day
    {
        public int dayNumber;
        public int cupsSold;
        public double priceLemonade;
        public double profit;
        public double totalCost;
        Weather weather;
        Inventory inventory;
        Player player;

        public Day(int dayNumber)
        {
            this.dayNumber = dayNumber;
        }


        public double GetPrice()
        {
            double price = 0;
            Console.WriteLine("For how much would you like to sell your lemonade?");
            try
            {
                price = Convert.ToDouble(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("That is an invalid entry.  PRICE WILL BE SET TO $1.00 PER CUP.");
                Console.WriteLine();
                price = 1;
            }

            Console.WriteLine();
            return price;
        }

        public void SetPrice()
        {
            priceLemonade = GetPrice();
        }

        public double GetProfit(double bank)
        {
            double profit = totalCost + (cupsSold * priceLemonade);
            return profit;
        }


        public List<int> PrepareLemonade(Player player)
        {
            Inventory inventory = new Inventory(player.bank, player.CurrentInventory);
            Tuple<List<int>,double> PurchaseResult = inventory.MakePurchases(player.CurrentInventory, player.bank);
            List<int> PurchasedInventory = PurchaseResult.Item1;
            totalCost = PurchaseResult.Item2;
            player.CurrentInventory = inventory.GetCurrentInventory(player.CurrentInventory, PurchasedInventory);
            List<int> NewRecipe = inventory.MakeRecipe(player.CurrentInventory);
            SetPrice();
            List<int> NewInventory = inventory.GetCurrentInventory(player.CurrentInventory, NewRecipe);
            cupsSold = GetCupsSold(inventory);
            return NewInventory;
            
        }

        public int GetCupsSold(Inventory inventory)
        {
            return inventory.GetCupsSold();
        }
    }
}