using System;
using System.Linq;
using System.Collections.Generic;
namespace Pr._7CountNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int[] arr = new int[1001];

            foreach (int num in numbers)
            {
                arr[num]++;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    Console.WriteLine($"{i} -> {arr[i]}");
                }
            }
        }
    }
}
