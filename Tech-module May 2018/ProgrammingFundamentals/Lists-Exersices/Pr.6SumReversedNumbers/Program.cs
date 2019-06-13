using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._6SumReversedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char[] number = input[i].ToCharArray();
                Array.Reverse(number);
                sum += int.Parse(string.Join("", number));
            }

            Console.WriteLine(sum);
        }
    }
}
