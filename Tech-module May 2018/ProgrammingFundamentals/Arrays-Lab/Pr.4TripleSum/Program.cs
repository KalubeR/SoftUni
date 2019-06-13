using System;
using System.Linq;
namespace Pr._4TripleSum
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            int counter = 0;
            for (int a = 0; a < numbers.Length; a++)
            {
                for (int b = a + 1; b < numbers.Length; b++)
                {
                    for (int c = 0; c < numbers.Length; c++)
                    {
                        if (numbers[a] + numbers[b] == numbers[c])
                        {
                            Console.WriteLine($"{numbers[a]} + {numbers[b]} == {numbers[c]}");
                            counter++;
                            break;
                        }
                    }
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
