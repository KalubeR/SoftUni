using GenericSwapMethodString;
using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {

        int count = int.Parse(Console.ReadLine());
        List<int> input = new List<int>();
        for (int i = 0; i < count; i++)
        {
            string inputmessage = Console.ReadLine();
            input.Add(int.Parse(inputmessage));
        }

        Box<int> myList = new Box<int>(input);

        int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        myList.Swap(indexes[0], indexes[1]);

        Console.WriteLine(myList);
    }
}
