using System;
using System.Linq;

namespace Sneaking
{
    class Program
    {
        static int playerRow = 0;
        static int playerCol = 0;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] room = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();

                if (room[row].Contains('S'))
                {
                    playerRow = row;
                    playerCol = Array.IndexOf(room[row], 'S');
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();

            for (int i = 0; i < directions.Length; i++)
            {
                MoveEnemy(room);

                if (room[playerRow].Contains('d') && Array.IndexOf(room[playerRow], 'd') > playerCol)
                {
                    room[playerRow][playerCol] = 'X';
                    Console.WriteLine($"Sam died at {playerRow}, {playerCol}");
                    break;
                }
                else if (room[playerRow].Contains('b') && Array.IndexOf(room[playerRow], 'b') < playerCol)
                {
                    room[playerRow][playerCol] = 'X';
                    Console.WriteLine($"Sam died at {playerRow}, {playerCol}");
                    break;
                }

                MoveSam(room, directions[i]);

                if (room[playerRow].Contains('N'))
                {
                    int indexOfN = Array.IndexOf(room[playerRow], 'N');
                    room[playerRow][indexOfN] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    break;
                }

            }
            foreach (var r in room)
            {
                Console.WriteLine(String.Join("", r));
            }
        }

        private static void PrintMatrix(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveSam(char[][] room, char direction)
        {
            room[playerRow][playerCol] = '.';

            if (direction == 'U')
            {
                playerRow--;
            }
            else if (direction == 'D')
            {
                playerRow++;
            }
            else if (direction == 'L')
            {
                playerCol--;
            }
            else if (direction == 'R')
            {
                playerCol++;
            }

            room[playerRow][playerCol] = 'S';
        }

        private static void MoveEnemy(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                int indexOfB = Array.IndexOf(room[row], 'b');
                int indexOfD = Array.IndexOf(room[row], 'd');

                if (indexOfB != -1)
                {
                    if (indexOfB == room[row].Length - 1)
                    {
                        room[row][indexOfB] = 'd';
                    }
                    else
                    {
                        room[row][indexOfB] = '.';
                        indexOfB++;
                        room[row][indexOfB] = 'b';
                    }
                }

                else if (indexOfD != -1)
                {
                    if (indexOfD == 0)
                    {
                        room[row][indexOfD] = 'b';
                    }
                    else
                    {
                        room[row][indexOfD] = '.';
                        indexOfD--;
                        room[row][indexOfD] = 'd';
                    }

                }
            }
        }
    }
}
