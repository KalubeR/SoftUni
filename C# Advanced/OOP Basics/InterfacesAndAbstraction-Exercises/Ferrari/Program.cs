using System;

namespace Ferrari
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Ferrari ferrari = new Ferrari(name);

            Console.WriteLine($"{ferrari.Model}/{ferrari.Brake()}/{ferrari.Gas()}/{ferrari.Driver}");
        }
    }
}
