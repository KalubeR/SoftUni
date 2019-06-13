using System;

namespace _3._0
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int number = Math.Abs(int.Parse(Console.ReadLine()));
                if (number % 2 == 0)
                {
                    Console.WriteLine("Please write an odd number.");
                }
                else
                {
                    Console.WriteLine($"The number is: {number}");
                    break;
                }
            }
        }
    }
}
