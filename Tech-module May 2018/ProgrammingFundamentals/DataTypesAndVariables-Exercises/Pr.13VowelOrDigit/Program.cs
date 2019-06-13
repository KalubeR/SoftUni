using System;

namespace Pr._13VowelOrDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());

            if (symbol == 'a' || symbol == 'u' || symbol == 'e' || symbol == 'o' || symbol == 'y' || symbol == 'i')
            {
                Console.WriteLine("vowel");
            }
            else if (char.IsDigit(symbol))
            {
                Console.WriteLine("digit");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
