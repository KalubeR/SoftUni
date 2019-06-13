using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> hashset1 = new HashSet<int>();
            HashSet<int> hashset2 = new HashSet<int>();

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            int n = input[0];
            int m = input[1];

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                hashset1.Add(number);
            }

            for (int i = 0; i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                hashset2.Add(number);
            }

            int maxLength = Math.Max(n, m);

            foreach (var item in hashset1)
            {
                if (hashset2.Contains(item))
                {
                    Console.Write($"{item} ");
                }
            }
        }
    }
}
