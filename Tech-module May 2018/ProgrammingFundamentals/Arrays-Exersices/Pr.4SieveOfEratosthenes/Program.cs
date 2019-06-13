using System;
using System.Linq;
namespace Pr._4SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            bool[] numbers = new bool[n + 1];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = true;
                numbers[0] = numbers[1] = false;
            }

            for (int i = 2; i < numbers.Length; i++)
            {
                if (numbers[i])
                {
                    Console.Write($"{i} ");

                    for (int j = i * 2; j < numbers.Length; j+= i)
                    {
                        numbers[j] = false;
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
