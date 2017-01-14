using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeLemonade
{
    public class Inventory
    {

        public int lemonCount;
        public int cupCount;
        public int sugarCount;
        public int iceCount;

        public int lemonsPurchased;
        public int cupsPurchased;
        public int sugarPurchased;
        public int icePurchased;

        public int lemonsUsed;
        public int cupsUsed;
        public int sugarUsed;
        public int iceUsed;

        public double money;
        public int cupsSold;
        public Weather weather;
        public double flavorFactor;

        public List<int> WorkingInventory;

        public Inventory(double bank, List<int> Inventory)
        {
            weather = new Weather();
            weather.SetWeatherDetails();
            this.WorkingInventory = Inventory;
            this.money = bank;
        }

        public void GetWeatherPrediction(Weather weather)
        {
            Console.WriteLine(weather.predictedWeather);
            Console.WriteLine();
        }


        public Tuple<List<int>,double> MakePurchases(List<int> Inventory, double money)
        {
            GetWeatherPrediction(weather);
            List<int> NewInventory;
            double totalCost = 0;
            while (totalCost < money)
            {
                try
                {
                    Console.WriteLine("Would you like to purchase lemons at $0.75 each?  You have {0}.", Inventory[0]);
                    lemonsPurchased = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    while (!int.TryParse(Console.ReadLine(), out lemonsPurchased))
                    {
                        Console.WriteLine("INVALID ENTRY.  Number of lemons purchased is set to 0.");
                        lemonsPurchased = 0;
                        break;
                    }
                }

                try
                {
                    Console.WriteLine("Would you like to purchase cups at $0.10 each?  You have {0}.", Inventory[1]);
                    cupsPurchased = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    while (!int.TryParse(Console.ReadLine(), out cupsPurchased))
                    {
                        Console.WriteLine("INVALID ENTRY.  Number of cups purchased is set to 0.");
                        cupsPurchased = 0;
                        break;
                    }
                }

                try
                {
                    Console.WriteLine("Would you like to purchase sugar at $0.50 per cup?  You have {0} cups.", Inventory[2]);
                    sugarPurchased = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    while (!int.TryParse(Console.ReadLine(), out sugarPurchased))
                    {
                        Console.WriteLine("INVALID ENTRY.  Number of cups of sugar purchased is set to 0.");
                        sugarPurchased = 0;
                        break;
                    }
                }

                try
                {
                    Console.WriteLine("Would you like to purchase ice at $0.10 per cup?  You have no ice.");
                    icePurchased = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    while (!int.TryParse(Console.ReadLine(), out icePurchased))
                    {
                        Console.WriteLine("INVALID ENTRY.  Number of cups of ice purchased is set to 0.");
                        icePurchased = 0;
                        break;
                    }
                }

                totalCost = lemonsPurchased * 0.75 + cupsPurchased * 0.10 + sugarPurchased * 0.50 + icePurchased * 0.10;
                Console.WriteLine("Total cost = ${0}.", totalCost);
                
                if (totalCost > money)
                {
                    Console.WriteLine("You do not have enough money for these purchases; you have ${0}.  Please try again.", money);
                }
                else
                {
                    break;
                }
            }
            NewInventory = new List<int>() { lemonsPurchased, cupsPurchased, sugarPurchased, icePurchased};
            Tuple<List<int>, double> PurchaseResult = new Tuple<List<int>, double>(NewInventory, (0-totalCost));
            return PurchaseResult;
        }

        public List<int> MakeRecipe(List<int> Inventory)
        {
            List<int> NewRecipe;
            {
                while (lemonsUsed == 0)
                {
                    Console.WriteLine("How many lemons do you want to use to make your lemonade?  You have {0}.", Inventory[0]);
                    lemonsUsed = 0 - Convert.ToInt32(Console.ReadLine());
                }

                while (cupsUsed == 0)
                {
                    Console.WriteLine("How many cups?  You have {0}.", Inventory[1]);
                    cupsUsed = 0 - Convert.ToInt32(Console.ReadLine());
                }

                while (sugarUsed == 0)
                {
                    Console.WriteLine("How much sugar?  You have {0} cups of sugar.", Inventory[2]);
                    sugarUsed = 0 - Convert.ToInt32(Console.ReadLine());
                }

                while (iceUsed == 0)
                {
                    Console.WriteLine("How much ice?  You have {0} cups of ice.", Inventory[3]);
                    iceUsed = 0 - Convert.ToInt32(Console.ReadLine());
                }
            }
            NewRecipe = new List<int>() { lemonsUsed, cupsUsed, sugarUsed, iceUsed };
            SetFlavorFactor(NewRecipe);
            return NewRecipe;
        }
        
        public double GetFlavorFactor(List<int> NewRecipe)
        {
            //the perfect lemonade has a ratio of 3 lemons to 1 cup of sugar.  That makes 5 cups of lemonade.  Best is to put 1 cup of ice in each cup.
            //if ratio is > 3.5, lemonade is too sour.  If ratio is <2.5, lemonade is too sweet.  
            string quality = "";
            double ratio = lemonsUsed / sugarUsed;
            return ratio;
        }

        public void SetFlavorFactor(List<int> NewRecipe)
        {
            flavorFactor = GetFlavorFactor(NewRecipe);
        }
        
            
        public List<int> GetCurrentInventory(List<int> FirstInventory, List<int> SecondInventory)
        {
            List<int> Inventory = new List<int>() { };
            for (int i=0; i<FirstInventory.Count; i++)
            {
                Inventory.Add(FirstInventory[i] + SecondInventory[i]);
            }
            return Inventory;
        }
            
        public void GetActualWeather(Weather weather)
        {
            Console.WriteLine("{0}  The number of people who visited your stand was {1}.", weather.actualWeather, weather.visitors);
        }

        public int SellLemonade(Weather weather)
        {
            GetActualWeather(weather);
            int cupsSold = Math.Min(weather.visitors, Math.Abs(cupsUsed));
            return cupsSold;
        }

        public int GetCupsSold()
        {
            if (flavorFactor > 3.5 | flavorFactor < 2.5)
            {
                cupsSold = Convert.ToInt16(Math.Ceiling(cupsSold*0.5));
                Console.WriteLine("Your lemonade doesn't taste good.  Your sales may suffer!!!  Press any key to continue.");
                Console.ReadLine();
                Console.WriteLine();
                cupsSold = Convert.ToInt32(Math.Ceiling(SellLemonade(weather) * 0.75));
            }
            else
            {
                Console.WriteLine("Your lemonade tastes just right!  Press any key to continue.");
                Console.ReadLine();
                Console.WriteLine();
                cupsSold = SellLemonade(weather);
            }
            return cupsSold;
        }

    }
}
