using System;
using System.Linq;

namespace Zadacha3
{
    class Program
    {
        static int playerRow = 0;
        static int playerCol = 0;
        static char[,] jaggedArray;
        static int totalCoals = 0;
        static int collectedCoals = 0;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            jaggedArray = new char[rows, rows];

            string[] directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < jaggedArray.GetLength(1); col++)
                {
                    jaggedArray[row, col] = input[col];
                    if (jaggedArray[row,col] == 's')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedArray.GetLength(0); col++)
                {
                    if (jaggedArray[row,col] == 'c')
                    {
                        totalCoals++;
                    }
                }
            }


            while (true)
            {
                MoveMiner(directions);

            }



        }

        private static void MoveMiner(string[] directions)
        {
            int counter = 0;
            for (int i = 0; i < directions.Length; i++)
            {
                counter++;
                if (directions[i] == "up")
                {
                    if (playerRow == 0 && !IsInside(playerRow - 1, playerCol))
                    {
                        continue;
                    }
                    playerRow--;
                }
                else if (directions[i] == "right")
                {
                    if (!IsInside(playerRow, playerCol + 1))  //playerCol == jaggedArray[playerRow].Length - 1 && 
                    {
                        continue;

                    }
                    playerCol++;
                }
                else if (directions[i] == "down")
                {
                    if (playerRow == jaggedArray.Length && !IsInside(playerRow + 1, playerCol))
                    {
                        continue;

                    }
                    playerRow++;
                }
                else if (directions[i] == "left")
                {
                    if (playerCol == 0 && !IsInside(playerRow, playerCol - 1))
                    {
                        continue;

                    }
                    playerCol--; ;
                }

                if (jaggedArray[playerRow,playerCol] == 'c')
                {
                    collectedCoals++;

                    jaggedArray[playerRow,playerCol] = '*';
                    if (collectedCoals == totalCoals)
                    {
                        Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                        Environment.Exit(0);

                    }

                }


                if (jaggedArray[playerRow,playerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                    Environment.Exit(0);
                }
                else if (counter == directions.Length)
                {
                    Console.WriteLine($"{totalCoals - collectedCoals} coals left. ({playerRow}, {playerCol})");
                    Environment.Exit(0);

                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray.GetLength(1);
        }


    }
}
