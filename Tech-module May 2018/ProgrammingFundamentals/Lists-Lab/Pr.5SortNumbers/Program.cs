using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._5SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine().Split().Select(double.Parse).ToList();

            input.Sort();

            Console.WriteLine(string.Join(" <= ", input));
        }
    }
}
