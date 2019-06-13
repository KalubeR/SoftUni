using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] jaggedArray = new int[dimensions[0]][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            }

            int maxSum = int.MinValue;
            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < jaggedArray.Length - 2; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length - 2; col++)
                {
                    int sum = jaggedArray[row][col] + jaggedArray[row][col + 1] + jaggedArray[row][col + 2] +
                        jaggedArray[row + 1][col] + jaggedArray[row + 1][col + 1] + jaggedArray[row + 1][col + 2] +
                        jaggedArray[row + 2][col] + jaggedArray[row + 2][col + 1] + jaggedArray[row + 2][col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = rowIndex; row < rowIndex + 3; row++)
            {
                for (int col = colIndex; col < colIndex + 3; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
