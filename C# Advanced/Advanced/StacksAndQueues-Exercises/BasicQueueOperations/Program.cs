using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadacha2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            int numberToPush = input[0];
            int numberToPop = input[1];
            int magicNum = input[2];

            for (int i = 0; i < numberToPush; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < numberToPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {

                if (queue.Contains(magicNum))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }


        }
    }
}
