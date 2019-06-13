using System;

namespace ThirdProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string noun = Console.ReadLine();
            string wordInPlural = "";
            if (noun.EndsWith("y"))
            {
                noun = noun.Remove(noun.Length - 1);
                wordInPlural = noun.Insert(noun.Length, "ies");
            }
            else if (noun.EndsWith("o") || noun.EndsWith("ch") || noun.EndsWith("s") || noun.EndsWith("sh") || noun.EndsWith("x") || noun.EndsWith("z"))
            {
                wordInPlural = noun.Insert(noun.Length, "es");
            }
            else
            {
                wordInPlural = noun.Insert(noun.Length, "s"); 
            }
            Console.WriteLine(wordInPlural);
        }
    }
}
