using System;
using System.Linq;

namespace Pr._8CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (nums.Length == 1)
            {
                Console.WriteLine($"{nums[0]} is already condensed to number");
            }

            else
            {
                while (nums.Length > 1)
                {
                    int[] condensed = new int[nums.Length - 1];
                    for (int i = 0; i < condensed.Length; i++)
                    {
                        condensed[i] = nums[i] + nums[i + 1];
                    }
                    nums = condensed;
                }
                Console.WriteLine(string.Join(" ", nums));
            }
        }
    }
}
