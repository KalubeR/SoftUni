using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            int sum1 = 0;
            int sum2 = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum1 += matrix[row, row];
                sum2 += matrix[row, matrix.GetLength(1) - 1 - row];
            }

            int result = Math.Abs(sum1 - sum2);
            Console.WriteLine(result);
        }
    }
}
