using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr._1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine().Split().Select(double.Parse).ToList();
            var dictionary = new SortedDictionary<double, int>();

            foreach (double number in input)
            {
                if (!dictionary.ContainsKey(number))
                {
                    dictionary.Add(number, 1);
                }
                else
                {
                    dictionary[number]++;

                }

            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
