using System;
using System.Linq;

namespace Pr._5RoundingNumbersAwayFromZero
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                double number = Math.Round(numbers[i], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{numbers[i]} => {number}");
            }
        }
    }
}
