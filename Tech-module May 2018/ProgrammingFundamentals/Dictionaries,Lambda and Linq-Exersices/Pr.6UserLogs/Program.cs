using System;
using System.Collections.Generic;

namespace Pr._6UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            //dict
            //while
            //read the input
            //add in dict
            //sort
            //print

            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split(new char[] { ' ', '=', '\'' }, StringSplitOptions.RemoveEmptyEntries);
                string user = tokens[tokens.Length - 1];
                string ip = tokens[1];

                if (!users.ContainsKey(user))
                {
                    users.Add(user, new Dictionary<string, int>());
                }

                if (!users[user].ContainsKey(ip))
                {
                    users[user].Add(ip, 1);
                }

                else
                {
                    users[user][ip] += 1;
                }
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}: ");

                List<string> helper = new List<string>();
                foreach (var ip in user.Value)
                {
                    helper.Add($"{ip.Key} => {ip.Value}");
                }

                Console.Write(string.Join(", ", helper));
                Console.WriteLine(".");
            }
        }
    }
}