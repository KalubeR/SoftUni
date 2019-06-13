using System;
using System.Linq;
namespace Pr._9IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] alphabet = new char[26];

            int index = 0;
            for (char i = 'a'; i <= 'z'; i++)
            {
                alphabet[index++] = i;
            }

            foreach (char letter in input)
            {
                int foundIndex = Array.IndexOf(alphabet, letter);

                Console.WriteLine($"{letter} -> {foundIndex}");
            }
        }
    }
}
