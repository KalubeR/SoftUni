using System;

namespace Pr._3PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            PrintTriangle(num);
        }

        static void PrintTriangle(int num)
        {
            PrintTriangleTopPart(num);
            PrintTriangleBottomPart(num);
        }

        static void PrintTriangleTopPart(int num)
        {
            for (int row = 1; row <= num; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write(col + " ");
                }
                Console.WriteLine();
            }
        }

        static void PrintTriangleBottomPart(int num)
        {
            for (int row = num - 1; row >= 1; row--)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write(col + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
