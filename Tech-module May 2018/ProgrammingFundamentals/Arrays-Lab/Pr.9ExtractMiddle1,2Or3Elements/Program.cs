using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._9ExtractMiddle1_2Or3Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = numbers.Length;

            PrintMiddleElements(numbers, n);
        }

        static void PrintMiddleElements(int[] arr, int n)
        {
            if (n == 1)
            {
                Console.WriteLine($"{{ {arr[0]} }}");
            }
            else if (n % 2 != 0)
            {
                Console.WriteLine($"{{ {arr[(n / 2) - 1]}, {arr[n / 2]}, {arr[(n / 2) + 1]} }}");
            }
            else if (n % 2 == 0)
            {
                Console.WriteLine($"{{ {arr[(n / 2) - 1]}, {arr[n / 2]} }}");
            }

        }
    }
}
