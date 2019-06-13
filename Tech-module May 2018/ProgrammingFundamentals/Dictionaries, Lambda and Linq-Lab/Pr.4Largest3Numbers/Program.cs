using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._4Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(n => int.Parse(n)).OrderByDescending(n => n).Take(3).ToList();

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
