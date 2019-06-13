using System;
using System.Collections.Generic;

namespace OldestFamilyMember
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family members = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person(name, age);
                members.AddMember(person);
            }

            Person oldestPerson = members.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
