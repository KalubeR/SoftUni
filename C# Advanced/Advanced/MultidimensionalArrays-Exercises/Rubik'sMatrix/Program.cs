using System;
using System.Linq;

namespace Rubik_sMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[][] rubikMatrix = new int[rows][];

            int counter = 1;

            for (int row = 0; row < rubikMatrix.Length; row++)
            {
                rubikMatrix[row] = new int[cols];
                for (int col = 0; col < rubikMatrix[row].Length; col++)
                {
                    rubikMatrix[row][col] = counter++;
                }
            }

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] commands = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int targetRowCol = int.Parse(commands[0]);
                string command = commands[1];
                int moves = int.Parse(commands[2]);

                if (command == "down")
                {
                    MoveDown(rubikMatrix, targetRowCol, moves % rubikMatrix.Length);
                }

                else if (command == "left")
                {
                    MoveLeft(rubikMatrix, targetRowCol, moves % rubikMatrix[0].Length);
                }

                else if (command == "up")
                {
                    MoveUp(rubikMatrix, targetRowCol, moves % rubikMatrix.Length);
                }

                else if (command == "right")
                {
                    MoveRight(rubikMatrix, targetRowCol, moves % rubikMatrix[0].Length);
                }
            }

            int counter1 = 1;

            for (int row = 0; row < rubikMatrix.Length; row++)
            {
                for (int col = 0; col < rubikMatrix[row].Length; col++)
                {
                    if (rubikMatrix[row][col] == counter1)
                    {
                        Console.WriteLine("No swap required");
                        counter1++;
                    }

                    else
                    {
                        Rearrange(rubikMatrix, counter1, row, col);
                        counter1++;
                    }
                }
            }
        }

        private static void Rearrange(int[][] rubikMatrix, int counter, int row, int col)
        {
            for (int targetRow = 0; targetRow < rubikMatrix.Length; targetRow++)
            {
                for (int targetCol = 0; targetCol < rubikMatrix[targetRow].Length; targetCol++)
                {
                    if (rubikMatrix[targetRow][targetCol] == counter)
                    {
                        rubikMatrix[targetRow][targetCol] = rubikMatrix[row][col];
                        rubikMatrix[row][col] = counter;

                        Console.WriteLine($"Swap ({row}, {col}) with ({targetRow}, {targetCol})");
                        return;
                    }
                }
            }
        }

        private static void MoveRight(int[][] rubikMatrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = rubikMatrix[row][rubikMatrix[row].Length - 1];

                for (int col = rubikMatrix[row].Length - 1; col > 0; col--)
                {
                    rubikMatrix[row][col] = rubikMatrix[row][col - 1];
                }

                rubikMatrix[row][0] = lastElement;
            }
        }

        private static void MoveUp(int[][] rubikMatrix, int col, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int firstElement = rubikMatrix[0][col];

                for (int row = 0; row < rubikMatrix.Length - 1; row++)
                {
                    rubikMatrix[row][col] = rubikMatrix[row + 1][col];
                }

                rubikMatrix[rubikMatrix.Length - 1][col] = firstElement;
            }
        }

        private static void MoveLeft(int[][] rubikMatrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int firstElement = rubikMatrix[row][0];

                for (int col = 0; col < rubikMatrix[row].Length - 1; col++)
                {
                    rubikMatrix[row][col] = rubikMatrix[row][col + 1];
                }

                rubikMatrix[row][rubikMatrix[row].Length - 1] = firstElement;
            }
        }

        private static void MoveDown(int[][] rubikMatrix, int col, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = rubikMatrix[rubikMatrix.Length - 1][col];

                for (int row = rubikMatrix.Length - 1; row > 0; row--)
                {
                    rubikMatrix[row][col] = rubikMatrix[row - 1][col];
                }

                rubikMatrix[0][col] = lastElement;
            }
        }
    }
}
