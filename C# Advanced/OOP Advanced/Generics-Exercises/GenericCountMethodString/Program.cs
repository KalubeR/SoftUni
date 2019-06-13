using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        int counter = int.Parse(Console.ReadLine());

        List<string> messages = new List<string>();

        for (int i = 0; i < counter; i++)
        {
            string message = Console.ReadLine();
            messages.Add(message);

        }
        Box<string> myData = new Box<string>(messages);

        Console.WriteLine(myData.Compare(Console.ReadLine()));
    }
}