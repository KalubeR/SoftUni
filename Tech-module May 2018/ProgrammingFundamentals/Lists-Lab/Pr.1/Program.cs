using System;
using System.Linq;
using System.Collections.Generic;
namespace Pr._1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> res = new List<int>();

            foreach (int num in numbers)
            {
                if (num >= 0)
                {
                    res.Add(num);
                }
            }
            numbers.Clear();
            for (int i = res.Count - 1; i >= 0; i--)
            {
                numbers.Add(res[i]);
            }

            if (numbers.Count > 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
