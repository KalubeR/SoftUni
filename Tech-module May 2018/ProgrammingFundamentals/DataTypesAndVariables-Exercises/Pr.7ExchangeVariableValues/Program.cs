using System;

namespace Pr._7ExchangeVariableValues
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            Console.WriteLine($"Before:\r\na = {a}\r\nb = {b}");
            int temporary = a;
            a = b;
            b = temporary;
            Console.WriteLine($"After:\r\na = {a}\r\nb = {b}");
        }
    }
}
