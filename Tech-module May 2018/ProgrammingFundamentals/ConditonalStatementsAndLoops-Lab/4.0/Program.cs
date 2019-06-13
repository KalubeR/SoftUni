using System;

namespace _4._0
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double.Parse(Console.ReadLine());
                Console.WriteLine("It is a number.");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
