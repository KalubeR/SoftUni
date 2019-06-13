using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] inputArgs = input.Split();

                Person person = new Person(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);

                people.Add(person);
            }

            int n = int.Parse(Console.ReadLine());

            Person comparePerson = people[n - 1];

            int equalPeople = 0;

            foreach (var item in people)
            {
                if (item.CompareTo(comparePerson) == 0)
                {
                    equalPeople++;
                }
            }

            if (equalPeople > 1)
            {
                Console.WriteLine($"{equalPeople} {people.Count - equalPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
           
        }
    }
}
