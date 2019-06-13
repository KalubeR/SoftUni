using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> messages = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();
                messages.Add(element);
            }

            Box<string> data = new Box<string>(messages);

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            data.Swap(indexes[0], indexes[1]);

            Console.WriteLine(data);
        }
    }
}
