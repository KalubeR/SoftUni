using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadacha5
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<long> queue = new Queue<long>();

            long n = long.Parse(Console.ReadLine());
            List<long> numbers = new List<long>();

            queue.Enqueue(n);
            numbers.Add(n);

            for (int i = 0; i < 17; i++)
            {
                long currNum = queue.Dequeue();
                long a = currNum + 1;
                long b = 2 * currNum + 1;
                long c = currNum + 2;

                queue.Enqueue(a);
                queue.Enqueue(b);
                queue.Enqueue(c);

                numbers.Add(a);
                numbers.Add(b);
                numbers.Add(c);
            }

            Console.WriteLine(string.Join(" ", numbers.Take(50)));
        }
    }
}
