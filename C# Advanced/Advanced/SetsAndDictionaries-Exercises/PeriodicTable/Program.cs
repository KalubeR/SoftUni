using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> hashset = new SortedSet<string>();
        
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                foreach (var item in input)
                {
                    hashset.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", hashset));
        }
    }
}
