using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];

            char[][] jaggedArray = new char[rows][];

            string input = Console.ReadLine();

            int[] shot = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int impactRow = shot[0];
            int impactCol = shot[1];
            int radius = shot[2];

            FillMatrix(jaggedArray, input, dimensions);

            Shoot(jaggedArray, impactRow, impactCol, radius);

            Rearrange(jaggedArray);

            PrintMatrix(jaggedArray);
        }

        private static void Rearrange(char[][] jaggedArray)
        {
            Queue<char> queue = new Queue<char>();

            int counter = 0;

            for (int col = 0; col < jaggedArray[0].Length; col++)
            {
                counter = 0;

                for (int row = 0; row < jaggedArray.Length; row++)
                {
                    if (jaggedArray[row][col] != ' ')
                    {
                        queue.Enqueue(jaggedArray[row][col]);
                    }

                    else
                    {
                        counter++;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    jaggedArray[row][col] = ' ';
                }

                for (int row = counter; row < jaggedArray.Length; row++)
                {
                    jaggedArray[row][col] = queue.Dequeue();
                }
            }
        }

        private static void Shoot(char[][] jaggedArray, int impactRow, int impactCol, int radius)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (Math.Pow(radius, 2) >= Math.Pow((row - impactRow), 2) + Math.Pow((col - impactCol), 2))
                    {
                        jaggedArray[row][col] = ' ';
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]}");
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix(char[][] jaggedArray, string input, int[] dimensions)
        {
            int rows = dimensions[0];
            int cols = dimensions[1];

            int counter = 0;
            bool isLeft = true;

            for (int row = jaggedArray.Length - 1; row >= 0; row--)
            {
                jaggedArray[row] = new char[cols];
                if (isLeft)
                {
                    for (int col = jaggedArray[row].Length - 1; col >= 0; col--)
                    {
                        if (counter > input.Length - 1)
                        {
                            counter = 0;
                        }

                        jaggedArray[row][col] = input[counter++];
                        isLeft = false;
                    }
                }

                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        if (counter > input.Length - 1)
                        {
                            counter = 0;
                        }

                        jaggedArray[row][col] = input[counter++];
                        isLeft = true;
                    }
                }
            }
        }
    }
}
