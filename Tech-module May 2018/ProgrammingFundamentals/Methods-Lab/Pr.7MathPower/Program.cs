using System;

namespace Pr._7MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            Console.WriteLine(RaiseToPower(number, power));
        }

        static double RaiseToPower(double number, double power)
        {
            double sum = 1;
            for (int i = 1; i <= power; i++)
            {
                sum *= number;
            }
            return sum;
        }
    }
}
