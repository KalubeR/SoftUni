using Logger.Appenders.Contracts;
using Logger.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                this.commandInterpreter.AddAppender(inputArgs);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] inputArgs = input.Split('|');

                this.commandInterpreter.AddMessage(inputArgs);
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
