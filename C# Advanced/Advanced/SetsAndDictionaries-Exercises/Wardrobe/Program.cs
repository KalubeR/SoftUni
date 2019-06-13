using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] cloth = input.Split(" -> ");

                string color = cloth[0];

                List<string> cloths = cloth[1].Split(",").ToList();

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in cloths)
                {
                    if (!clothes[color].ContainsKey(item))
                    {
                        clothes[color].Add(item, 0);
                    }

                    clothes[color][item]++;
                }
            }

            string[] clothToFind = Console.ReadLine().Split();

            string colorToFind = clothToFind[0];
            string clothFind = clothToFind[1];

            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (colorToFind == color.Key && clothFind == cloth.Key)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");

                    }
                }
            }
        }
    }
}
