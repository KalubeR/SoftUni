using System;
using System.Linq;
using System.Collections.Generic;

namespace Pr._3SearchForANumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] arr = Console.ReadLine().Split();

            int takeElements = int.Parse(arr[0]);
            List<int> takenElements = numbers.Take(takeElements).ToList();

            int deleteElements = int.Parse(arr[1]);
            takenElements.RemoveRange(0, deleteElements);

            int searchedNumber = int.Parse(arr[2]);
            if (takenElements.Contains(searchedNumber))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
