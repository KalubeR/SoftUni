using System;

namespace Pr._11ConverSpeedUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            float hours = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());

            float time = hours + minutes / 60f + seconds / 3600f;

            float metersPerSecond = meters / (time * 3600);
            float kmPerHour = (meters / 1000f) / time;
            float milesPerHour = (meters / 1609f) / time;

            Console.WriteLine(metersPerSecond);
            Console.WriteLine(kmPerHour);
            Console.WriteLine(milesPerHour);
        }
    }
}
