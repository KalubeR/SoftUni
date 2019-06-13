using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr._5ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "print")
                {
                    Console.WriteLine("[{0}]", string.Join(", ", nums));
                    break;
                }

                string[] tokens = line.Split();

                string command = tokens[0];

                int index;
                int element;
                switch (command)
                {
                    case "add":
                        index = int.Parse(tokens[1]);
                        element = int.Parse(tokens[2]);
                        nums.Insert(index, element);
                        break;
                    case "addMany":
                        AddMany(nums, tokens);
                        break;
                    case "contains":
                        element = int.Parse(tokens[1]);
                        index = nums.IndexOf(element);
                        Console.WriteLine(index);
                        break;
                    case "remove":
                        index = int.Parse(tokens[1]);
                        nums.RemoveAt(index);
                        break;
                    case "shift":
                        int rotations = int.Parse(tokens[1]);
                        Shift(nums, rotations);
                        break;
                    case "sumPairs":
                        SumPairs(nums);
                        break;
                }
            }
        }

        static void SumPairs(List<int> nums)
        {
            for (int i = 0; i < nums.Count - 1; i++)
            {
                nums[i] += nums[i + 1];
                nums.RemoveAt(i + 1);
            }
        }

        static void AddMany(List<int> nums, string[] tokens)
        {
            int index = int.Parse(tokens[1]);
            List<int> numbersToAdd = new List<int>();
            for (int i = 2; i < tokens.Length; i++)
            {
                numbersToAdd.Add(int.Parse(tokens[i]));
            }
            nums.InsertRange(index, numbersToAdd);
        }

        static void Shift(List<int> nums, int rotations)
        {
            for (int i = 0; i < rotations % nums.Count; i++)
            {
                int first = nums[0];
                nums.RemoveAt(0);
                nums.Add(first);
            }
        }
    }
}
