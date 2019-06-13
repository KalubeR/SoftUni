using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadacha10
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> plants = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> indexex = new List<int>();

            int days = 0;

            while (true)
            {
                for (int i = 0; i < plants.Count - 1; i++)
                {
                    if (plants[i] < plants[i + 1])
                    {
                        indexex.Add(i + 1);
                    }
                }

                if (indexex.Count == 0)
                {
                    break;
                }


                for (int i = indexex.Count - 1; i >= 0; i--)
                {
                    plants.RemoveAt(indexex[i]);
                }

                days++;
                indexex.Clear();
            }

            Console.WriteLine(days);
        }
    }
}
