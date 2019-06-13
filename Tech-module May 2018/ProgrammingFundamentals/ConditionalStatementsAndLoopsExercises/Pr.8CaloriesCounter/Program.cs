using System;

namespace Pr._8CaloriesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int callories = 0;

            for (int i = 0; i < n; i++)
            {
                string ingredient = Console.ReadLine().ToLower();
                if (ingredient == "cheese")
                {
                    callories += 500;
                }
                else if (ingredient == "tomato sauce")
                {
                    callories += 150;
                }
                else if (ingredient == "salami")
                {
                    callories += 600;
                }
                else if (ingredient == "pepper")
                {
                    callories += 50;
                }
            }
            Console.WriteLine($"Total calories: {callories}");
        }
    }
}
