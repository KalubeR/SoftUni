using System;

namespace FirstProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();
            double price = 0;
            string hallName = "";
            if (persons <= 50)
            {
                price += 2500;
                hallName = "Small Hall";
            }
            else if (persons > 50 && persons <= 100)
            {
                price += 5000;
                hallName = "Terrace";
            }
            else if (persons > 100 && persons <= 120)
            {
                price += 7500;
                hallName = "Great Hall";
            }
            if (package == "Normal")
            {
                price += 500;
                price *= 0.95;
            }
            else if (package == "Gold")
            {
                price += 750;
                price *= 0.9;
            }
            else if (package == "Platinum")
            {
                price += 1000;
                price *= 0.85;
            }
            double pricePerPerson = price / persons;
            if (persons > 120)
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }
            else
            {
                Console.WriteLine($"We can offer you the {hallName}");
                Console.WriteLine($"The price per person is {pricePerPerson:f2}$");

            }
        }
    }
}
