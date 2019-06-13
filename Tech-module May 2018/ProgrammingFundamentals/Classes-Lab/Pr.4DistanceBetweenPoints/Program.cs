using System;
using System.Linq;

namespace Pr._4DistanceBetweenPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pointInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] pointInfo2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Point point1 = new Point();
            Point point2 = new Point();

            point1.X = pointInfo[0];
            point1.Y = pointInfo[1];
            point2.X = pointInfo2[0];
            point2.Y = pointInfo2[1];

            double sideA = Math.Abs(point1.X - point2.X);
            double sideB = Math.Abs(point1.Y - point2.Y);

            double sideC = Math.Sqrt(sideA * sideA + sideB * sideB);

            Console.WriteLine(sideC);
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
