using System;
using System.Collections.Generic;

namespace Pr._2OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().ToLower().Split();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            List<string> result = new List<string>();

            foreach (var word in input)
            {
                if (!dict.ContainsKey(word))
                {
                    dict.Add(word, 0);
                }

                dict[word]++;
            }

            foreach (var kvp in dict)
            {
                if (kvp.Value % 2 != 0)
                {
                    result.Add(kvp.Key);
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
