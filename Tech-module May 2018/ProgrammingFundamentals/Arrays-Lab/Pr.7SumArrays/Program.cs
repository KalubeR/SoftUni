using System;
using System.Linq;

namespace Pr._7SumArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arr2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int maxLength = Math.Max(arr1.Length, arr2.Length);
            int[] arrResult = new int[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                arrResult[i] = arr1[i % arr1.Length] + arr2[i % arr2.Length];
            }

            Console.WriteLine(string.Join(" ", arrResult));
        }
    }
}
