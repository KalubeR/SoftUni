﻿using System;

namespace Pr._15Substring_Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int jump = int.Parse(Console.ReadLine());

            const char search = 'р';
            bool hasMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == search)
                {
                    hasMatch = true;

                    int length = jump + 1;

                    if (endIndex > text.Length)
                    {
                        endIndex = text.Length;
                    }

                    string matchedString = text.Substring(i, endIndex);
                    Console.WriteLine(matchedString);
                    i += jump;
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}
