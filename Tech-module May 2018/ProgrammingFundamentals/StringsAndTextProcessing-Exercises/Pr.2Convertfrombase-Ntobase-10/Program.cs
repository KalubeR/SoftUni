using System;
using System.Numerics;

namespace Pr._2Convertfrombase_Ntobase_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int @base = int.Parse(input[0]);
            string numberAsString = input[1];
            BigInteger sum = 0;
            int pow = 0;

            for (int i = numberAsString.Length - 1; i >= 0; i--)
            {
                char curChar = numberAsString[i];
                int curNum = int.Parse(curChar.ToString());

                BigInteger curSum = curNum * BigInteger.Pow(@base, pow);
                sum += curSum;
                pow++;
            }

            Console.WriteLine(sum);
        }
    }
}
