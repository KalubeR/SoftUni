using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._2AppendLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split('|').ToList();
            List<string> result = new List<string>();
            numbers.Reverse();

            for (int i = 0; i < numbers.Count; i++)
            {
                string text = numbers[i];
                List<string> splitted = new List<string>(text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                string merged = string.Join(" ", splitted); 
                result.Add(merged);

            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
