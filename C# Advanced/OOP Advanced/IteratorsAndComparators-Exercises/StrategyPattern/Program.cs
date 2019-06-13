using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SortedSet<Person> sortedByName = new SortedSet<Person>(new ComparerForName());
            SortedSet<Person> sortedByAge = new SortedSet<Person>(new ComparerForAge());

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                Person person = new Person(input[0], int.Parse(input[1]));

                sortedByAge.Add(person);
                sortedByName.Add(person);
            }

            foreach (var item in sortedByName)
            {
                Console.WriteLine(item);
            }
            foreach (var item in sortedByAge)
            {
                Console.WriteLine(item);
            }
        }
    }
}
