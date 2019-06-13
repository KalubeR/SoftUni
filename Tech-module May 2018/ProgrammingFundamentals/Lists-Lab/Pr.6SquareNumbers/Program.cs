using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._6SquareNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (Math.Sqrt(numbers[i]) == (int)Math.Sqrt(numbers[i]))
                {
                    result.Add(numbers[i]);
                }
            }

            result.Sort();
            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
