using System;
using System.Linq;

namespace RadioactiveMutantVampiresBunnies
{
    class Program
    {
        static int playerRow;
        static int playerColl;
        static char[][] jaggedArray;
        static bool isDead;
        static bool isOutside;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int rows = dimensions[0];
            int colls = dimensions[1];

            jaggedArray = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = Console.ReadLine().ToCharArray();
                if (jaggedArray[i].Contains('P'))
                {
                    playerRow = i;
                    playerColl = Array.IndexOf(jaggedArray[i], 'P');
                }
            }
            string commands = Console.ReadLine();

            MovePlayer(commands);


        }

        private static void MoveBunnies()
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] == 'B')
                    {
                        int bunnyRow = row;
                        int bunnyCol = col;

                        if (IsInside(bunnyRow - 1, bunnyCol))
                        {
                            if (IsPlayer(bunnyRow - 1, bunnyCol))
                            {
                                isDead = true;
                            }

                            jaggedArray[bunnyRow - 1][bunnyCol] = 'B';
                        }
                        if (IsInside(bunnyRow, bunnyCol + 1))
                        {
                            if (IsPlayer(bunnyRow, bunnyCol + 1))
                            {
                                isDead = true;
                            }

                            jaggedArray[bunnyRow][bunnyCol + 1] = 'B';
                        }
                        if (IsInside(bunnyRow + 1, bunnyCol))
                        {
                            if (IsPlayer(bunnyRow + 1, bunnyCol))
                            {
                                isDead = true;
                            }

                            jaggedArray[bunnyRow + 1][bunnyCol] = 'B';
                        }
                        if (IsInside(bunnyRow, bunnyCol - 1))
                        {
                            if (IsPlayer(bunnyRow, bunnyCol - 1))
                            {
                                isDead = true;
                            }

                            jaggedArray[bunnyRow][bunnyCol - 1] = 'B';
                        }
                    }
                }
            }
        }

        private static bool IsPlayer(int row, int col)
        {
            return jaggedArray[row][col] == 'P';
        }

        private static void MovePlayer(string commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                jaggedArray[playerRow][playerColl] = '.';
                if (commands[i] == 'U')
                {
                    playerRow--;
                }
                else if (commands[i] == 'L')
                {
                    playerColl--;
                }
                else if (commands[i] == 'R')
                {
                    playerColl++;
                }
                else if (commands[i] == 'D')
                {
                    playerRow++;
                }

                if (jaggedArray[playerRow][playerColl] == 'B')
                {
                    isDead = true;
                }
                if (!IsInside(playerRow, playerColl))
                {
                    isOutside = true;
                }
                else
                {
                    jaggedArray[playerRow][playerColl] = 'P';
                }

                MoveBunnies();

                if (isDead)
                {
                    PrintJaggedArray();
                    Console.WriteLine($"dead: {playerRow} {playerColl}");
                    break;
                }

                if (isOutside)
                {
                    PrintJaggedArray();
                    Console.WriteLine($"won: {playerRow} {playerColl}");
                    break;
                }
            }

        }

        private static void PrintJaggedArray()
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && col >= 0 && row < jaggedArray.Length && col < jaggedArray[row].Length;
        }
    }
}
