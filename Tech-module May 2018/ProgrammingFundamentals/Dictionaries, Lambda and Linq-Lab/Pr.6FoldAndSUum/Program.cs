using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr._6FoldAndSUum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = numbers.Length / 4;

            int[] left = numbers.Take(k).Reverse().ToArray();
            int[] right = numbers.Reverse().Take(k).ToArray();

            int[] top = left.Concat(right).ToArray();

            int[] middle = numbers.Skip(k).Take(2 * k).ToArray();

            var sum = top.Select((x, index) => x + middle[index]);
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}

