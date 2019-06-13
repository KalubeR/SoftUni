using System;

namespace Pr._3UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            foreach (var ch in input.ToCharArray())
            {
                Console.Write(GetEscapeSequence(ch));
            }
        }

        public static string GetEscapeSequence(char c)
        {
            return "\\u" + ((int)c).ToString("X4").ToLower();
        }
    }
}
