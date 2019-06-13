using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();

            foreach (char ch in input)
            {
                if (!chars.ContainsKey(ch))
                {
                    chars.Add(ch, 0);
                }

                chars[ch]++;
            }

            foreach (var kvp in chars)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
