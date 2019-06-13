using System;
using System.Numerics;
namespace Pr._14FactorialtrailingZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            CountOfZeroes(n);
        }

        static BigInteger PrintFactorial(int n)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        static void CountOfZeroes(int n)
        {
            BigInteger number = PrintFactorial(n);
            int counter = 0;

            while (number % 10 == 0)
            {
                number /= 10;
                counter++;
            }
            Console.WriteLine(counter);
        }
    }
}
