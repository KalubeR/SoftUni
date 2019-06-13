using System;
using System.Collections.Generic;
using System.Linq;

namespace OpinionPoll
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person(name, age);
                persons.Add(person);
            }
            persons = persons.OrderBy(p => p.Name).ToList();

            foreach (var person in persons)
            {
                if (person.Age > 30)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }
        }
    }
}
