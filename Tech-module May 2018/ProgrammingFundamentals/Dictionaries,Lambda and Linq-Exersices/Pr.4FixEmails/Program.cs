using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._4FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "stop")
                {
                    break;
                }

                string email = Console.ReadLine();

                if (!emails.ContainsKey(name))
                {
                    emails.Add(name, email);
                }
            }

            foreach (var kvp in emails)
            {
                if (!kvp.Value.EndsWith("us") || kvp.Value.EndsWith("uk"))
                {
                    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}
