using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeLemonade
{
    public class Weather
    {
        public string predictedWeather;
        public string actualWeather;
        public int weatherScore;
        public int visitors;
        List<int> Numbers;
        public List<string> Skies = new List<string>() { "heavy rain", "rain", "scattered showers", "cloudy skies", "partly sunny skies", "partly cloudy skies", "sunny skies" };

        public Weather()
        {

        }

        public void SetWeatherDetails()
        {
            SetWeatherScore();
            SetPredictedWeather();
            SetActualWeather();
            SetVisitors();
        }

        public int GetRandomNumbers(int i, int j)
        {
            Random random = new Random();
            int k = random.Next(i, j);
            return k;
        }

        public List<int> GenerateRandomNumberList()
        {
            int i = GetRandomNumbers(1, 7);
            int j = GetRandomNumbers(1, 7);
            List<int> myList = new List<int>() { i, j };
            return myList;
        }

        public void GetRandomNumbersList()
        {
            Numbers = GenerateRandomNumberList();
        }

        public int GetWeatherScore()
        {
            Numbers = GenerateRandomNumberList();
            int j = (Numbers[0] * 2) * (Numbers[1]);
            return j;
        }

        public void SetWeatherScore()
        {
            weatherScore = GetWeatherScore();
        }

        public string GetPredictedWeather()
        {
            GetRandomNumbersList();
            string skies = Skies[Numbers[0]];
            string temperature = Convert.ToString(((Numbers[1] + 12) * 5));
            string str = "Weather predictions for tomorrow are " + skies + " and " + temperature + " degrees.";
            return str;
        }

        public void SetPredictedWeather()
        {
            predictedWeather = GetPredictedWeather();

        }

        public string GetActualWeather()
        {
            int i = GetRandomNumbers(0, 2);
            string skies = Skies[Numbers[0] - i];
            string temperature = Convert.ToString(((Numbers[1] + 12 - i) * 5));
            string str = "Today's weather turned out to be " + skies + " and " + temperature + " degrees.";
            return str;
        }

        public void SetActualWeather()
        {
            actualWeather = GetActualWeather();
        }

        public int GetVisitors()
        {

            SetWeatherScore();
            int i = weatherScore;
            return i;//is in a range from 2 to 98, number of people who come out.
        }

        public void SetVisitors()
        {
            visitors = GetVisitors();

        }

    }
}
