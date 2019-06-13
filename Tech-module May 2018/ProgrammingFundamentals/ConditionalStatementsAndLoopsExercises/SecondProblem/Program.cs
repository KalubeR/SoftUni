using System;

namespace SecondProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());
            double priceForStudio = 0;
            double priceForDouble = 0;
            double priceForSuite = 0;


            if (month == "May" || month == "October")
            {
                priceForStudio = 50;
                priceForDouble = 65;
                priceForSuite = 75;
                if (nightsCount > 7)
                {
                    priceForStudio *= 0.95;
                }
            }
            else if (month == "June" || month == "September")
            {
                priceForStudio = 60;
                priceForDouble = 72;
                priceForSuite = 82;
                if (nightsCount > 14)
                {
                    priceForDouble *= 0.9;
                }
            }
            else if (month == "July" || month == "August" || month == "December")
            {
                priceForStudio = 68;
                priceForDouble = 77;
                priceForSuite = 89;
                if (nightsCount > 14)
                {
                    priceForSuite *= 0.85;
                }
            }
            if (nightsCount > 7 && month == "September")
            {
                priceForStudio *= nightsCount - 1;
            }
            else if (nightsCount > 7 && month == "October")
            {
                priceForStudio *= nightsCount - 1;
            }
            else
            {
                priceForStudio *= nightsCount;
            }
            priceForDouble *= nightsCount;
            priceForSuite *= nightsCount;
            Console.WriteLine($"Studio: {priceForStudio:f2} lv.");
            Console.WriteLine($"Double: {priceForDouble:f2} lv.");
            Console.WriteLine($"Suite: {priceForSuite:f2} lv.");
        }
    }
}
