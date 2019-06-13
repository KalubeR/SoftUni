using System;

namespace Pr._4VariableInHexadecimalFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int secondNum = Convert.ToInt32(number, 16);
            Console.WriteLine(secondNum);
            
        }
    }
}
