using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._2RotateAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            int[] sumArray = new int[arr.Length];

            for (int i = 0; i < rotations; i++)
            {
                Shift(arr);
                Sum(sumArray, arr);
            }

            Console.WriteLine(string.Join(" ", sumArray));
        }

        static void Sum(int[] sumArray, int[] arr)
        {
            for (int i = 0; i < sumArray.Length; i++)
            {
                sumArray[i] += arr[i];
            }
        }

        static void Shift(int[] arr)
        {
            int last = arr[arr.Length - 1];
            for (int i = arr.Length - 1; i >= 1; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[0] = last;
        }
    }
}