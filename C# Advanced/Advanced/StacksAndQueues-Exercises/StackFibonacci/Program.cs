using System;
using System.Collections.Generic;

namespace Zadacha8
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<long> stack = new Stack<long>();

            long n = long.Parse(Console.ReadLine());

            stack.Push(0);
            stack.Push(1);

            for (int i = 0; i < n - 1; i++)
            {
                long firstNum = stack.Pop();
                long secondNum = stack.Peek();

                stack.Push(firstNum);
                stack.Push(firstNum + secondNum);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
