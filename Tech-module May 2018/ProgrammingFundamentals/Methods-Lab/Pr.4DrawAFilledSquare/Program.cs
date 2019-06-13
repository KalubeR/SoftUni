using System;

namespace Pr._4DrawAFilledSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintDashes(n);
            PrintMiddleRows(n);
            PrintDashes(n);
        }

        static void PrintDashes(int n)
        {
            Console.WriteLine(new string('-', n * 2));
        }

        static void PrintMiddleRows(int n)
        {
            for (int row = 1; row <= n - 2; row++)
            {
                Console.Write("-");
                for (int i = 1; i <= n - 1; i++)
                {
                    Console.Write("\\/");
                }
                Console.WriteLine("-");
            }
        }
    }
}
