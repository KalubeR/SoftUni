using System;

namespace Pr._15FastPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int i = 2; i <= input; i++)
            {
                bool isItPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isItPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{i} -> {isItPrime}");
            }

        }
    }
}
