using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Statistics")
                {
                    break;
                }

                string[] inputArgs = input.Split();

                string vlogger = inputArgs[0];
                string command = inputArgs[1];
                string targetUser = inputArgs[2];

                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(vlogger))
                    {
                        vloggers.Add(vlogger, new Dictionary<string, SortedSet<string>>());
                        vloggers[vlogger].Add("followers", new SortedSet<string>());
                        vloggers[vlogger].Add("following", new SortedSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    if (vloggers.ContainsKey(vlogger) && vloggers.ContainsKey(targetUser) && vlogger != targetUser)
                    {
                        vloggers[vlogger]["following"].Add(targetUser);
                        vloggers[targetUser]["followers"].Add(vlogger);
                    }
                }

            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int counter = 1;

            foreach (var vloger in vloggers.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
            {
                Console.WriteLine($"{counter}. {vloger.Key} : {vloger.Value["followers"].Count} followers, {vloger.Value["following"].Count} following");

                if (counter == 1)
                {
                    foreach (var item in vloger.Value["followers"])
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }

                counter++;
            }
        }
    }
}
