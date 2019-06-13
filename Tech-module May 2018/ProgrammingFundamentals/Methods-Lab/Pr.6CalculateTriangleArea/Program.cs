using System;

namespace Pr._6CalculateTriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double heith = double.Parse(Console.ReadLine());
            double result = GetTriangleArea(width, heith);
            Console.WriteLine(result);
        }

        static double GetTriangleArea(double width, double height)
        {
            return width * height / 2;
        }
    }
}
