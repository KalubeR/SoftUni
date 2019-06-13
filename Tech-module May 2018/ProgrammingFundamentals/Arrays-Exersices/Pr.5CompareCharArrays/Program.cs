using System;
using System.Linq;
namespace Pr._5CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arr1 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] arr2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

            int shorter = Math.Min(arr1.Length, arr2.Length);
            for (int i = 0; i < shorter; i++)
            {
                if (arr1[i] < arr2[i])
                {
                    foreach (char ch in arr1)
                    {
                        Console.Write(ch);
                    }
                    Console.WriteLine();

                    foreach (char ch in arr2)
                    {
                        Console.Write(ch);
                    }
                    return;
                }

                else if (arr1[i] > arr2[i])
                {
                    foreach (char ch in arr2)
                    {
                        Console.Write(ch);
                    }
                    Console.WriteLine();

                    foreach (char ch in arr1)
                    {
                        Console.Write(ch);
                    }
                    return;
                }
            }

            if (arr1.Length < arr2.Length)
            {
                Console.WriteLine(arr1);
                Console.WriteLine(arr2);
            }
            else
            {
                Console.WriteLine(arr2);
                Console.WriteLine(arr1);
            }
        }
    }
}
