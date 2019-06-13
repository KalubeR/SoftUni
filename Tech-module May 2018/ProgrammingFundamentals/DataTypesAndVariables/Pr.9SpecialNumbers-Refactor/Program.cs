using System;

namespace Pr._9SpecialNumbers_Refactor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int number = i;
                int total = 0;
                while (number > 0)
                {
                    total += number % 10;
                    number = number / 10;
                }
                bool itIs = false;
                itIs = (total == 5) || (total == 7) || (total == 11);
                {
                    Console.WriteLine($"{i} -> {itIs}");
                }
            }

        }
    }
}
