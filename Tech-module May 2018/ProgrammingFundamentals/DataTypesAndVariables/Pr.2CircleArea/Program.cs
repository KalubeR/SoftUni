using System;

namespace Pr._2CircleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());

            double area = Math.PI * r * r;
            Console.WriteLine($"{area:f12}");
        }
    }
}
