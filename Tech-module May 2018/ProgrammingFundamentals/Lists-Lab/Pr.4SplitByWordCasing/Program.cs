using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._4SplitByWordCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().Split(", ; : . ! ( ) \" ' \\ / [ ]".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> lower = new List<string>();
            List<string> mixed = new List<string>();
            List<string> upper = new List<string>();

            
            foreach (var word in text)
            {
                bool isAllLower = true;
                bool isAllUpper = true;

                for (int i = 0; i < word.Length; i++)
                {
                    if (char.IsLower(word[i]))
                    {
                        isAllUpper = false;
                    }

                    else if (char.IsUpper(word[i]))
                    {
                        isAllLower = false;
                    }

                    else
                    {
                        isAllLower = false;
                        isAllUpper = false;
                    }
                }

                if (isAllLower)
                {
                    lower.Add(word);
                }

                else if (isAllUpper)
                {
                    upper.Add(word);
                }

                else
                {
                    mixed.Add(word);
                }
            }

            Console.WriteLine("Lower-case: {0}", string.Join(", ", lower));
            Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixed));
            Console.WriteLine("Upper-case: {0}", string.Join(", ", upper));
        }
    }
}
