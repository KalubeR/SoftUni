using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._7PopulationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> totalPopulation = new Dictionary<string, long>();
            Dictionary<string, Dictionary<string, long>> countriesAndCities = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "report")
                {
                    break;
                }

                string[] tokens = input.Split('|');

                string city = tokens[0];
                string country = tokens[1];
                long population = long.Parse(tokens[2]);

                if (!totalPopulation.ContainsKey(country))
                {
                    totalPopulation.Add(country, 0);
                    countriesAndCities.Add(country, new Dictionary<string, long>());
                }

                totalPopulation[country] += population;

                countriesAndCities[country].Add(city, population);
            }

            foreach (var country in totalPopulation.OrderByDescending(c => c.Value))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value})");

                Dictionary<string, long> cities = countriesAndCities[country.Key]
                    .OrderByDescending(c => c.Value)
                    .ToDictionary(x => x.Key, x=> x.Value);

                foreach (var city in cities)
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
