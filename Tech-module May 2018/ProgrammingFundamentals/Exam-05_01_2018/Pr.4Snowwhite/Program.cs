using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr._4Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarfs = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Once upon a time")
                {
                    break;
                }

                string[] tokens = input.Split(new char[] { ' ', '<', ':', '>' }, StringSplitOptions.RemoveEmptyEntries);

                string dwarfName = tokens[0];
                string dwarfHatColor = tokens[1];
                int dwarfPhysics = int.Parse(tokens[2]);

                string ID = dwarfName + ":" + dwarfHatColor;

                if (!dwarfs.ContainsKey(ID))
                {
                    dwarfs.Add(ID, dwarfPhysics);
                }

                else
                {
                    if (dwarfs[ID] < dwarfPhysics)
                    {
                        dwarfs[ID] = dwarfPhysics;
                    }
                }
            }

            foreach (var dwarf in dwarfs.OrderByDescending(x => x.Value)
                .ThenByDescending(x => dwarfs.Where(y => y.Key.Split(':')[1] == x.Key.Split(':')[1]).Count()))
            {
                Console.WriteLine($"({dwarf.Key.Split(':')[1]}) {dwarf.Key.Split(':')[0]} <-> {dwarf.Value}");
            }
        }
    }
}
