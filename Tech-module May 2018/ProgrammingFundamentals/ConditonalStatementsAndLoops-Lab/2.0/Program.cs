using System;

namespace _2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{n} X {m} = {n * m}");
                m++;
                if (m > 10 )
                {
                    break;
                }
            }
        }
    }
}
