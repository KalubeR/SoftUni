using System;

namespace Pr._9CountTheIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            while (true)
            {
                string input = Console.ReadLine();
                int value = 0;
                if (int.TryParse(input, out value))
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(counter);
        }

    }
}
