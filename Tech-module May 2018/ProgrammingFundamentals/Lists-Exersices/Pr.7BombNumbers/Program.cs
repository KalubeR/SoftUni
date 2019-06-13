using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._7BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();
            int[] bombNumbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            int bombNumber = bombNumbers[0];
            int range = bombNumbers[1];

            int bombIndex = numbers.IndexOf(bombNumber);

            while (bombIndex != -1)
            {
                int leftIndex = bombIndex - range;
                int rightIndex = bombIndex + range;

                if (leftIndex < 0)
                {
                    leftIndex = 0;
                }

                if (rightIndex > numbers.Count - 1)
                {
                    rightIndex = numbers.Count - 1;
                }

                int count = rightIndex - leftIndex + 1;

                numbers.RemoveRange(leftIndex, count);

                bombIndex = numbers.IndexOf(bombNumber);
            }

            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
