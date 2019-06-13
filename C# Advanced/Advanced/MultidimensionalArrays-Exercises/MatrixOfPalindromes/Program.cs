using System;
using System.Linq;

namespace Zadacha1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            int[] count = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[count[0], count[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = $"{alphabet[row]}{alphabet[col + row]}{alphabet[row]}";
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
