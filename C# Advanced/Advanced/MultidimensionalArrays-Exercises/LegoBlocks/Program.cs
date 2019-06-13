using System;
using System.Linq;

namespace LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int totalCells = 0;

            int[][] jaggedArray1 = new int[n][];
            int[][] jaggedArray2 = new int[n][];

            int[][] finalJaggedArray = new int[n][];

            for (int row = 0; row < n; row++)
            {
                jaggedArray1[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                totalCells += jaggedArray1[row].Length;
            }

            for (int row = 0; row < n; row++)
            {
                jaggedArray2[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Reverse()
                    .ToArray();

                totalCells += jaggedArray2[row].Length;

            }

            int cols = jaggedArray1[0].Length + jaggedArray2[0].Length;
            bool isFit = true;

            for (int row = 0; row < jaggedArray1.Length; row++)
            {
                if (jaggedArray1[row].Length + jaggedArray2[row].Length != cols)
                {
                    isFit = false;
                }
            }

            if (isFit)
            {
                for (int row = 0; row < jaggedArray2.Length; row++)
                {
                    Console.WriteLine($"[{string.Join(", ", jaggedArray1[row])}, {string.Join(", ", jaggedArray2[row])}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {totalCells}");
            }
        }
    }
}
