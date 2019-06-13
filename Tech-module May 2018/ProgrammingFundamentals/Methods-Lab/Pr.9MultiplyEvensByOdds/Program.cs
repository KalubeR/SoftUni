using System;

namespace Pr._9MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Math.Abs(int.Parse(Console.ReadLine()));
            int result = GetMultipleOfEvensAndOdds(n);
            Console.WriteLine(result);
        }

        static int GetMultipleOfEvensAndOdds(int n)
        {
            int sumEvens = GetSumOfEvenDigits(n);
            int sumOdds = GetSumOfOddDigits(n);
            return sumEvens * sumOdds;
        }

        static int GetSumOfEvenDigits(int n)
        {
            int evenSum = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                if (lastDigit % 2 == 0)
                {
                    evenSum += lastDigit;
                }

                n /= 10;
            }
            return evenSum;
        }

        static int GetSumOfOddDigits(int n)
        {
            int oddSum = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                if (lastDigit % 2 != 0)
                {
                    oddSum += lastDigit;
                }
                 n /= 10;
            }
            return oddSum;
        }
    }
}
