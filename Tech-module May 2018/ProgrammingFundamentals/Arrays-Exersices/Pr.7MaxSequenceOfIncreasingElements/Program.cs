using System;
using System.Linq;
using System.Collections.Generic;
namespace Pr._7MaxSequenceOfIncreasingElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int currentStart = 0;
            int currentLength = 1;
            int longestStart = 0;
            int longestLength = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    currentLength++;

                    if (currentLength > longestLength)
                    {
                        longestStart = currentStart;
                        longestLength = currentLength;
                    }
                }
                else
                {
                    currentStart = i;
                    currentLength = 1;
                }
            }

            for (int i = longestStart; i < longestLength + longestStart; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
