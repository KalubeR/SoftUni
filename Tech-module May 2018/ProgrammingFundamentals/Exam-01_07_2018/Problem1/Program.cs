using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int studentsAnsweredPerHour = firstEmployee + secondEmployee + thirdEmployee;
            int time = 0;

            while (true)
            {
                if (studentsCount <= 0)
                {
                    break;
                }
                studentsCount -= studentsAnsweredPerHour;
                time++;

                if (time % 4 == 0)
                {
                    time++;
                }
            }

            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}
