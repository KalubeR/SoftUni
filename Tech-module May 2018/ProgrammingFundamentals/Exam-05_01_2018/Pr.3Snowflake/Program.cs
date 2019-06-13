using System;
using System.Text.RegularExpressions;

namespace Pr._3Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {
            string surface = Console.ReadLine();
            string mantle = Console.ReadLine();
            string middle = Console.ReadLine();
            string secondMantle = Console.ReadLine();
            string secondSurface = Console.ReadLine();

            string surfacePattern = @"[^A-Za-z0-9]+";

            Regex surfaceRegex = new Regex($"^{surfacePattern}$");

            if (!surfaceRegex.IsMatch(surface))
            {
                Console.WriteLine("Invalid");
                return;
            }

            string mantlePattern = @"[0-9_]+";

            Regex mantleRegex = new Regex($"^{mantlePattern}$");

            if (!mantleRegex.IsMatch(mantle))
            {
                Console.WriteLine("Invalid");
                return;
            }

            string core = @"[A-Za-z]+";

            Regex middleRegex = new Regex($"{surfacePattern}{mantlePattern}({core}){mantlePattern}{surfacePattern}");

            if (!middleRegex.IsMatch(middle))
            {
                Console.WriteLine("Invalid");
                return;
            }

            if (!mantleRegex.IsMatch(secondMantle))
            {
                Console.WriteLine("Invalid");
                return;
            }

            if (!surfaceRegex.IsMatch(secondSurface))
            {
                Console.WriteLine("Invalid");
                return;
            }

            Console.WriteLine("Valid");

            Match match = middleRegex.Match(middle);
            Console.WriteLine(match.Groups[1].Value.Length);
        }
    }
}
