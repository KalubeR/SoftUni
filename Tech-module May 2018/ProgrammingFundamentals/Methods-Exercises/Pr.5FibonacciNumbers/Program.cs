using System;

namespace Pr._5FibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = Fib(n);
            Console.WriteLine(result);

        }

        static int Fib(int n)
        {
            int sum = 0;
            if (n == 0)
            {
                return sum = 1;
            }
            int a = 0;
            int b = 1;
            for (int i = 0; i < n; i++)
            {
                sum = 0; 
                sum += a + b;
                a = b;
                b = sum;
            }
            return sum;
        }
    }
}
