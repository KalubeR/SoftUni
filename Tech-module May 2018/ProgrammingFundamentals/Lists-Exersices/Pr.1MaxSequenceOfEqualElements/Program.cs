using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr._1MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int maxCounter = 1;
            int maxNum = numbers[0];
            int counter = 1;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    counter++;

                    if (counter > maxCounter)
                    {
                        maxCounter = counter;
                        maxNum = numbers[i];
                    }
                }
                else
                {
                    counter = 1;
                }
            }

            for (int i = 0; i < maxCounter; i++)
            {
                Console.Write($"{maxNum} ");
            }
        }
    }
}
