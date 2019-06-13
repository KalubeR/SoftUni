using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._2ChangeList
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Odd")
                {
                    numbers.RemoveAll(n => n % 2 == 0);

                    foreach (int number in numbers)
                    {
                        Console.Write($"{number} ");
                    }
                    break;
                }

                else if (line == "Even")
                {
                    numbers.RemoveAll(n => n % 2 != 0);

                    foreach (int number in numbers)
                    {
                        Console.Write($"{number} ");
                    }
                    break;
                }
                string[] tokens = line.Split();

                string command = tokens[0];

                switch (command)
                {
                    case "Delete":
                        int numToRemove = int.Parse(tokens[1]);
                        numbers.RemoveAll(n => n == numToRemove);
                        break;
                    case "Insert":
                        int numToInsert = int.Parse(tokens[1]);
                        int position = int.Parse(tokens[2]);
                        numbers.Insert(position, numToInsert);
                        break;
                }
            }
        }
    }
}
