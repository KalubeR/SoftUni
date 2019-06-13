using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._1Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                string[] line = input.Split();
                string command = line[0];

                switch (command)
                {
                    case "A":
                        string name = line[1];
                        string phone = line[2];
                        if (!phonebook.ContainsKey(name))
                        {
                            phonebook.Add(name, phone);
                        }
                        else
                        {
                            phonebook[name] = phone;
                        }
                        break;
                    case "S":
                        string searchName = line[1];
                        if (phonebook.ContainsKey(searchName))
                        {
                            string foundNumber = phonebook[searchName];
                            Console.WriteLine($"{searchName} -> {foundNumber}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {searchName} does not exist.");
                        }
                        break;
                }
            }
        }
    }
}
