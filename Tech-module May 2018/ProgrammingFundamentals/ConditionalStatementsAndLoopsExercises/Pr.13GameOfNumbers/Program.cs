using System;

namespace Pt._13GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int sum = 0;
            int counter = 0;
            int magicalCounter = 0;
            for (int i = secondNum; i >= firstNum; i--)
            {
                for (int j = secondNum; j >= firstNum; j--)
                {
                    sum = i + j;
                    counter++;
                    if (sum == magicNum)
                    {
                        Console.WriteLine($"Number found! {i} + {j} = {magicNum}");
                        magicalCounter++;
                        return;
                    }
                }
            }
            if (magicalCounter == 0)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
            }
        }
    }
}
