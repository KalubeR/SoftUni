using System;

namespace Pr._14IntegerToHexAndBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            string hexadecimal = Convert.ToString(input, 16).ToUpper();
            string binary = Convert.ToString(input, 2);
            Console.WriteLine(hexadecimal);
            Console.WriteLine(binary);

        }
    }
}
