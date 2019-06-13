using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._2Snowmen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> snowmen = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (snowmen.Count > 1)
            {
                for (int i = 0; i < snowmen.Count; i++)
                {
                    if (snowmen.Count(x => x != -1) == 1)
                    {
                        break;
                    }

                    if (snowmen[i] == -1)
                    {
                        continue;
                    }

                    int attacker = i;
                    int target = snowmen[i] % snowmen.Count;

                    int diff = Math.Abs(attacker - target);

                    if (attacker == target)
                    {
                        snowmen[attacker] = -1;
                        Console.WriteLine($"{attacker} performed harakiri");
                    }

                    else if (diff % 2 == 0)
                    {
                        snowmen[target] = -1;
                        Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                    }

                    else
                    {
                        snowmen[attacker] = -1;
                        Console.WriteLine($"{attacker} x {target} -> {target} wins");
                    }
                }

                snowmen = snowmen
                    .Where(x => x != -1)
                    .ToList();
            }
        }
    }
}
