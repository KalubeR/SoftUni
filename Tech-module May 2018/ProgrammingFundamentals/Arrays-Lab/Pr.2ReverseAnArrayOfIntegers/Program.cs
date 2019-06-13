using System;
using System.Linq;
namespace Pr._2ReverseAnArrayOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write(string.Join("!", numbers));
            }
            numbers = numbers.Reverse().ToArray();
        }
    }
}
