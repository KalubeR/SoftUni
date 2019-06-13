using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueues_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}
