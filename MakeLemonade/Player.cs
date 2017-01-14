using MakeLemonade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeLemonade
{
    public class Player
    {
        public string name;
        public int numberOfDays;
        public double bank;
        public List<int> CurrentInventory;
        public List<double> ScoreSet = new List<double>() { };
        public double dailyScore;
        public double totalScore;
        Game game;
        Player player;



        public Player()
        {

        }

        public void Welcome()
        {
            name = GetName();
            Console.WriteLine("Welcome, {0}, to the Lemonade Stand!", name);
            numberOfDays = GetNumberOfDays();
            Console.WriteLine("You will be playing for {0} days.", numberOfDays);
            bank = 50;
            Console.WriteLine("You will start with ${0}.", bank);
            CurrentInventory = new List<int>(){ 0,0,0,0};
            Console.WriteLine("You have {0} lemons, {1} cups, {2} cups of sugar, and {3} cups of ice.  You will have to buy more ice every day.", CurrentInventory[0], CurrentInventory[1], CurrentInventory[2], CurrentInventory[3]);
            Console.WriteLine("Your goal is to sell as much lemonade as you can and make as much money as you can.  Pay attention to the weather forecast!");
            
        }
        public string GetName()
        {
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            return name;
        }

        public int GetNumberOfDays()
        {
            Console.WriteLine("For how many days would you like to play?");
            try
            {
                numberOfDays = Convert.ToInt16(Console.ReadLine());
            }
            catch (System.FormatException)
            { 
                Console.WriteLine("That is an invalid entry.  PLAY PERIOD WILL BE SET TO 2.");
                Console.WriteLine();
                numberOfDays = 2;
            }
            return numberOfDays;

        }


        public void PlayOnePeriod(Player player)
        {
            for (int i =0; i<numberOfDays; i++)
            {
                ScoreSet = PlayOneDay(i, player);
                dailyScore = Math.Ceiling(Math.Abs(ScoreSet[0] * ScoreSet[1]));
                totalScore += dailyScore;
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();

            }
            Console.WriteLine("Congratulations, {0}!  Your total score for {1} days is {2}.", name, numberOfDays, totalScore);
        }

        public List<double> PlayOneDay(int dayNumber, Player player)
        {
            Day day = new Day(dayNumber);
            day.dayNumber = dayNumber;
            CurrentInventory = day.PrepareLemonade(player);
            double profit = day.GetProfit(bank);
            //int cupsSold = day.cupsSold;
            Console.WriteLine("You sold {0} cups of lemonade today.", day.cupsSold);
            if (profit > 0)
            {
                Console.WriteLine("You made a profit of ${0}.", profit);
            }
            else if (profit<0)
            {
                Console.WriteLine("You had a loss of ${0}.", 0 - profit);
            }
            else
            {
                Console.WriteLine("You broke even today.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();

            bank += profit;
            Console.WriteLine("You now have ${0} in the bank.", bank);

            ScoreSet.Add(profit);
            ScoreSet.Add(day.cupsSold);
            return ScoreSet;
        }
    }
}

