using System;

namespace Pr._4Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            double capacity = double.Parse(Console.ReadLine());

            double courses = (Math.Ceiling(persons / capacity));
            Console.WriteLine(courses);
        }
    }
}
