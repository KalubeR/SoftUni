using System;
using System.Linq;

namespace Pr._6ReverseAnArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] text = input.Split(' ').ToArray();

            //1  for (int i = 0; i < input.Length / 2; i++)
                {
                    string temp = text[i];
                    text[i] = text[text.Length - 1 - i];
                    text[text.Length - 1 - i] = temp;
                }
            //2  Array.Reverse(text)

            Console.WriteLine(string.Join(" ", text));
        }
    }
}
