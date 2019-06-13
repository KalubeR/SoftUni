using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._8LogsAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, SortedDictionary<string, int>> users = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();

                string[] tokens = input.Split(" ");
                string ip = tokens[0];
                string name = tokens[1];
                int duration = int.Parse(tokens[2]);

                if (!users.ContainsKey(name))
                {
                    users.Add(name, new SortedDictionary<string, int>());
                }

                if (!users[name].ContainsKey(ip))
                {
                    users[name].Add(ip, duration);
                }

                else
                {
                    users[name][ip] += duration;
                }
            }

            foreach (var user in users)
            {
                int totalDuration = users[user.Key].Values.Sum();
                List<string> listOfIps = user.Value.Keys.ToList();
                Console.WriteLine($"{user.Key}: {totalDuration} [{string.Join(", ", listOfIps)}]");
            }
        }
    }
}
