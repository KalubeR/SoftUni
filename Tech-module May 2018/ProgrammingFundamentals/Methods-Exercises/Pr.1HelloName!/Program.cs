using System;

namespace Pr._1HelloName_
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintName(input);
        }

        static void PrintName(string input)
        {
            Console.WriteLine($"Hello, {input}!");
        }
    }
}
