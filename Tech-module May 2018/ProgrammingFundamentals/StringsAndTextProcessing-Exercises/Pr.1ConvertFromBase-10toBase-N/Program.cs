using System;
using System.Numerics;
using System.Text;
using System.Linq;

namespace Pr._1ConvertFromBase_10toBase_N
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int @base = int.Parse(input[0]);
            BigInteger number = BigInteger.Parse(input[1]);
            StringBuilder sb = new StringBuilder();

            while (number != 0)
            {
                BigInteger curSum = number % @base;
                sb.Append(curSum);
                number /= @base;
            }

            string result = string.Join("", sb.ToString().Reverse());
            Console.WriteLine(result);
        }
    }
}