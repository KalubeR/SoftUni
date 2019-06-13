using System;

public class Startup
{
    public static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            Box<int> element = new Box<int>(int.Parse(Console.ReadLine()));
            Console.WriteLine(element);
        }
    }
}