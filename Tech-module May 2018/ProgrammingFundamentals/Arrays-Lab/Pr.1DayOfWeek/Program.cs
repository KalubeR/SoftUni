using System;

namespace Pr._1DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            int days = int.Parse(Console.ReadLine());

            if (days > 0 && days < 8)
            {
                Console.WriteLine(daysOfWeek[days - 1]);
            }
            else
            {
                Console.WriteLine("Invalid Day!");
            }
        }
    }
}
