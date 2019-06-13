using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._5ShortWordsSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .ToLower()
                .Split(new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length < 5)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine(string.Join(", ", input));
        }
    }
}
