﻿using System;

namespace Pr._8CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintTheClosestToCenter(x1, y1, x2, y2);
        }

        static void PrintTheClosestToCenter(double x1, double y1, double x2, double y2)
        {
            double line1 = Math.Sqrt(x1 * x1 + y1 * y1);
            double line2 = Math.Sqrt(x2 * x2 + y2 * y2);


            if (line1 <= line2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}
