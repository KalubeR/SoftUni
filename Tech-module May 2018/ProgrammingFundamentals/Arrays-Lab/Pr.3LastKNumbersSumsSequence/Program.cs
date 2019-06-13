using System;
using System.Linq;

namespace Pr._3LastKNumbersSumsSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            long[] arr = new long[n];
            arr[0] = 1;

            for (int i = 1; i < arr.Length; i++)
            {
                long sum = 0;
                for (int j = i - k; j <= i - 1; j++)
                {
                    if (j >= 0)
                    {
                        sum += arr[j];
                    }
                }
                arr[i] = sum;
            }
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
