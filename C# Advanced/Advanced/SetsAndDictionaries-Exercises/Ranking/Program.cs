using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of contests")
                {
                    break;
                }

                string[] inputArgs = input.Split(":");

                string contestName = inputArgs[0];
                string contestPass = inputArgs[1];

                if (!contests.ContainsKey(contestName))
                {
                    contests.Add(contestName, contestPass);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of submissions")
                {
                    break;
                }

                string[] inputArgs = input.Split("=>");

                string contestName = inputArgs[0];
                string contestPass = inputArgs[1];
                string user = inputArgs[2];
                int points = int.Parse(inputArgs[3]);

                if (contests.ContainsKey(contestName) && contests[contestName] == contestPass)
                {
                    if (!users.ContainsKey(user))
                    {
                        users.Add(user, new Dictionary<string, int>());
                    }

                    if (!users[user].ContainsKey(contestName))
                    {
                        users[user].Add(contestName, points);
                    }


                    if (users[user][contestName] < points)
                    {
                        users[user][contestName] = points;
                    }

                }
            }

            int maxSum = int.MinValue;

            foreach (var item in users)
            {
                foreach (var item1 in item.Value)
                {
                    if (item.Value.Values.Sum() > maxSum)
                    {

                    }
                }
            }
        
            var topStudent = users.OrderByDescending(x => x.Value.Sum(s => s.Value)).FirstOrDefault();

            Console.WriteLine($"Best candidate is {topStudent.Key} with total {topStudent.Value.Sum(x=> x.Value)} points.");
            Console.WriteLine("Ranking:");
            foreach (var item in users.OrderBy(x=> x.Key))
            {
                Console.WriteLine(item.Key);

                foreach (var user in item.Value.OrderByDescending(x=> x.Value))
                {
                    Console.WriteLine($"#  {user.Key} -> {user.Value}");
                }
            }
        }
    }
}
