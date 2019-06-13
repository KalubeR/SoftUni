using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadacha6
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int[]> petrolPumps = new Queue<int[]>();

            int n = int.Parse(Console.ReadLine());
            int index = 0;

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                petrolPumps.Enqueue(input);
            }


            while (true)
            {
                int totalFuel = 0;

                foreach (var currentPetrolPump in petrolPumps)
                {
                    int petrol = currentPetrolPump[0];
                    int distance = currentPetrolPump[1];
                    totalFuel += petrol - distance;

                    if (totalFuel < 0)
                    {
                        int[] pumpToRemove = petrolPumps.Dequeue();
                        petrolPumps.Enqueue(pumpToRemove);
                        index++;
                        break;
                    }
                }

                if (totalFuel >= 0)
                {
                    break;
                }
            }
            Console.WriteLine(index);
        }
    }
}
