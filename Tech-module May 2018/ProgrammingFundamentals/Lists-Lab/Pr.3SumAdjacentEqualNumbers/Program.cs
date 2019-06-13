using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr._3SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> input = Console.ReadLine().Split().Select(decimal.Parse).ToList();

            for (int i = 0; i < input.Count- 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    input[i] += input[i + 1];
                    input.Remove(input[i + 1]);
                    i = -1;
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
