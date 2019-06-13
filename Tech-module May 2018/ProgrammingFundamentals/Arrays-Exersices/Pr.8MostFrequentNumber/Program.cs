using System;
using System.Linq;

namespace Pr._8MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int maxNumber = 0;
            int maxCounter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int counter = 0;

                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[j] == numbers[i])
                    {
                        counter++;
                    }
                }

                if (counter > maxCounter)
                {
                    maxCounter = counter;
                    maxNumber = numbers[i];
                }
            }

            Console.WriteLine(maxNumber);
        }
    }
}
