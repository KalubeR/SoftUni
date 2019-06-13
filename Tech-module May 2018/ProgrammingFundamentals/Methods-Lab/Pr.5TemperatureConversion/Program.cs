using System;

namespace Pr._5TemperatureConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            double degrees = double.Parse(Console.ReadLine());
            double result = FahrenheitToCelsius(degrees);
            Console.WriteLine($"{result:f2}");
        }

        static double FahrenheitToCelsius(double degrees)
        {
            return (degrees - 32) * 5 / 9;
        }
    }
}
