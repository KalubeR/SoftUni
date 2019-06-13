using System;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split().Skip(1).ToArray();

            ListyIterator<string> list = new ListyIterator<string>(data);
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                try
                {
                    string[] inputArgs = input.Split();
                    string command = inputArgs[0];

                    switch (command)
                    {
                        case "Move":
                            Console.WriteLine(list.Move());
                            break;
                        case "Print":
                            Console.WriteLine(list.Print());
                            break;
                        case "HasNext":
                            Console.WriteLine(list.HasNext());
                            break;
                        case "PrintAll":
                            list.PrintAll();
                            break;
                    }
                }
                catch (InvalidOperationException io)
                {
                    Console.WriteLine(io.Message);
                }
                

            }

        }
    }
}
