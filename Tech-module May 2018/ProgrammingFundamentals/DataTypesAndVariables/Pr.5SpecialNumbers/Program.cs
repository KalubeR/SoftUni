using System;

namespace Pr._5SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                int sumDigits = 0;
                int number = i;
                while (number > 0)
                {
                    sumDigits += number % 10;
                    number = number / 10;
                }
                if (sumDigits == 5 || sumDigits == 7 || sumDigits == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
