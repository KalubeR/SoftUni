using System;

namespace Pr._2MaxMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int max = GetMax(a, b);
            max = GetMax(max, c);
            Console.WriteLine(max);
        }

        static int GetMax(int a, int b)
        {
            int max = 0;
            if (a > b)
            {
                max = a;
            }
            else
            {
                max = b;
            }
            return max;
        }
    }
}
