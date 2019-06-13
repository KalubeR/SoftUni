using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        int counter = int.Parse(Console.ReadLine());

        List<double> messages = new List<double>();

        for (int i = 0; i < counter; i++)
        {
            double message = double.Parse(Console.ReadLine());
            messages.Add(message);

        }
        Box<double> myData = new Box<double>(messages);

        Console.WriteLine(myData.Compare(double.Parse(Console.ReadLine())));
    }
}