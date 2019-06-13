using System;
using System.Collections.Generic;
using System.Linq;

namespace HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, string>> people = new Dictionary<string, SortedDictionary<string, string>>();

            int targetInfoIndex = int.Parse(Console.ReadLine());
            int infoIndex = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end transmissions")
                {
                    break;
                }

                string[] inputArgs = input.Split("=");

                string name = inputArgs[0];

                string[] kvps = inputArgs[1].Split(";");
                

                for (int i = 0; i < kvps.Length; i++)
                {
                    string[] kvp = kvps[i].Split(':');
                    string key = kvp[0];
                    string value = kvp[1];

                    if (!people.ContainsKey(name))
                    {
                        people.Add(name, new SortedDictionary<string, string>());
                    }

                    if (!people[name].ContainsKey(key))
                    {
                        people[name].Add(key, value);
                    }

                    if (people[name].ContainsKey(key))
                    {
                        people[name][key] = value;
                    }
                }

            }
            string[] killName = Console.ReadLine().Split();
            string targetName = killName[1];

            Console.WriteLine($"Info on {targetName}:");
            foreach (var kvp in people[targetName])
            {
                infoIndex += kvp.Key.Length;
                infoIndex += kvp.Value.Length;
                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            }

            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
            }
        }
    }
}
