using System;

namespace Pr._10CubeProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();

            CalculateTheParameter(side, parameter);
        }

        static void CalculateTheParameter(double side, string parameter)
        {
            if (parameter == "face")
            {
                GetFaceDiagonals(side);
            }
            else if (parameter == "space")
            {
                GetSpaceDiagonals(side);
            }
            else if (parameter == "volume")
            {
                GetVolume(side);
            }
            else if (parameter == "area")
            {
                GetArea(side);
            }

        }

        static void GetArea(double side)
        {
            double area = 6 * Math.Pow(side, 2);
            Console.WriteLine($"{area:f2}");
        }

        static void GetVolume(double side)
        {
            double volume = Math.Pow(side, 3);
            Console.WriteLine($"{volume:f2}");
        }

        static void GetSpaceDiagonals(double side)
        {
            double spaceDiagonals = Math.Sqrt(3 * Math.Pow(side, 2));
            Console.WriteLine($"{spaceDiagonals:f2}");
        }

        static void GetFaceDiagonals(double side)
        {
            double faceDiagonals = Math.Sqrt(2 * Math.Pow(side, 2));
            Console.WriteLine($"{faceDiagonals:f2}");
        }
    }
}
