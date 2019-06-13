using System;

namespace Pr._7PrimesInGivenRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int stop = int.Parse(Console.ReadLine());

            IsPrime(start, stop);
        }

        static void IsPrime(int start, int stop)
        {
            bool isPrime = true;
            for (int i = start; i <= stop; i++)
            {
                if (i < 2)
                {
                    isPrime = false;
                }
                for (int j = i; j <= stop; j++)
                {
                    if (i % j != 0)
                    {
                        Console.Write($"{i}, ");
                        break;
                    }
                    
                }
            }
        }
    }
}
