using CustomStack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            CustomStack<string> stack = new CustomStack<string>(input);
            

            while (true)
            {
                try
                {
                    string command = Console.ReadLine();
                    if (command == "Pop")
                    {
                        stack.Pop();
                    }
                    string[] inputargs = command.Split();

                    if (inputargs[0] == "Push")
                    {
                        stack.Push(inputargs[1]);
                    }
                    if (command == "END")
                    {
                        IEnumerable<string> final = stack.Reverse();
                        foreach (var item in final)
                        {
                            Console.WriteLine(item);
                        }
                        foreach (var item in final)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    }
                }
                catch (InvalidOperationException io)
                {
                    Console.WriteLine(io.Message);
                }   
            }
        }
    }
}
