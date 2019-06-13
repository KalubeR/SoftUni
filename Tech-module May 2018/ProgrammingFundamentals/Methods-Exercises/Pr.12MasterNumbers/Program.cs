using System;

namespace Pr._12MasterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                bool isPalindrome = IsPalindrome(i);
                bool isDivisibleBySeven = IsDivisible(i);
                bool hasEvenDigit = HasEvenDigit(i);

                bool isMaster = isPalindrome && isDivisibleBySeven && hasEvenDigit;
                if (isMaster)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool HasEvenDigit(int number)
        {
            bool hasEvenDigit = false;

            while (number > 0)
            {
                int lastDigit = number % 10;
                if (lastDigit % 2 == 0)
                {
                    hasEvenDigit = true;
                    break;
                }
                number /= 10;
            }
            return hasEvenDigit;
        }

        static bool IsDivisible(int number)
        {
            bool isDivisible = false;
            int sum = 0;
            while (number > 0)
            {
                int digit = number % 10;
                sum += digit;
                number /= 10;
            }
            if (sum % 7 == 0)
            {
                isDivisible = true;
            }
            return isDivisible;
        }

        static bool IsPalindrome(int number)
        {
            string reversed = "";
            string numAsString = number.ToString();

            for (int i = numAsString.Length - 1; i >= 0; i--)
            {
                reversed += numAsString[i];
            }

            bool isPalindrome = numAsString == reversed;

            return isPalindrome;
        }
    }
}
