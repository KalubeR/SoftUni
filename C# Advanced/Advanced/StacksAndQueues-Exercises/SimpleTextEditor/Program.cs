using System;
using System.Collections.Generic;

namespace Zadacha9
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            int n = int.Parse(Console.ReadLine());
            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = (input[0]);

                if (command == "1")
                {
                    stack.Push(text);
                    string inputString = input[1];

                    text += inputString;
                }

                else if (command == "2")
                {
                    int elementsToRemove = int.Parse(input[1]);

                    if (elementsToRemove > text.Length)
                    {
                        elementsToRemove = text.Length;
                    }
                    stack.Push(text);
                    text = text.Substring(0, text.Length - elementsToRemove);
                }

                else if (command == "3")
                {
                    int index = int.Parse(input[1]);

                    Console.WriteLine(text[index - 1]);
                }

                else if (command == "4")
                {
                    text = stack.Pop();
                }
            }
        }
    }
}
