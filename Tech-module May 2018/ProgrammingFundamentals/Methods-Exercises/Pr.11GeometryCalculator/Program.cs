using System;

namespace Pr._11GeometryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine();

            if (figureType == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                GetTriangleArea(side, height);
            }
            else if (figureType == "square")
            {
                double side = double.Parse(Console.ReadLine());
                GetSquareArea(side);
            }
            else if (figureType == "rectangle")
            {
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                GetRectangleArea(width, height);
            }
            else if (figureType == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                GetCircleArea(radius);
            }
        }

        static void GetTriangleArea(double side, double height)
        {
            double area = (side * height) / 2;
            Console.WriteLine($"{area:f2}");
        }

        static void GetSquareArea(double side)
        {
            double area = side * side;
            Console.WriteLine($"{area:f2}");
        }

        static void GetRectangleArea(double width, double heigth)
        {
            double area = width * heigth;
            Console.WriteLine($"{area:f2}");
        }

        static void GetCircleArea(double radius)
        {
            double area = Math.PI * radius * radius;
            Console.WriteLine($"{area:f2}");
        }
    }
}
