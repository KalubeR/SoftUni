using System;
using System.Linq;

namespace Pr._11EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int totalSum = 0;

            foreach (int num in numbers)
            {
                totalSum += num;
            }

            int leftSum = 0;
            int rightSum = totalSum;
            bool hasFound = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNum = numbers[i];
                rightSum -= currentNum;
                if (leftSum == rightSum)
                {
                    hasFound = true;
                    Console.WriteLine(i);
                    break;
                }
                leftSum += currentNum;
            }

            if (hasFound == false)
            {
                Console.WriteLine("no");
            }
        }
    }
}
