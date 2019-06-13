using System;
using System.Linq;
using System.Collections.Generic;

namespace Zadacha7
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            char[] openBrackets = new char[] { '[', '(', '{' };
            bool isValid = true;

            foreach (char ch in input)
            {
                if (openBrackets.Contains(ch))
                {
                    stack.Push(ch);
                }

                if (stack.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (ch == ']' && stack.Peek() == '[')
                {
                    stack.Pop();
                }

                else if (ch == '}' && stack.Peek() == '{')
                {
                    stack.Pop();
                }

                else if (ch == ')' && stack.Peek() == '(')
                {
                    stack.Pop();
                }
            }

            if (isValid && stack.Count == 0)
            {
                Console.WriteLine("YES");
            }

            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}