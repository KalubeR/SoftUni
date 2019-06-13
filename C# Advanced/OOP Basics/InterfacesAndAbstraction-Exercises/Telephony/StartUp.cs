using System;

namespace Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbersToCall = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();
            Smartphone smartphone = new Smartphone();

            foreach (var item in numbersToCall)
            {
                bool isValid = true;
                foreach (var digit in item)
                {
                    if (!char.IsDigit(digit))
                    {
                        isValid = false;
                    }
                }
                if (isValid)
                {
                    Console.WriteLine($"{smartphone.Call()}{item}");
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var item in sites)
            {
                bool isValid = true;
                foreach (var letter in item)
                {
                    if (char.IsDigit(letter))
                    {
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    Console.WriteLine($"{smartphone.Browse()}{item}!");
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}
