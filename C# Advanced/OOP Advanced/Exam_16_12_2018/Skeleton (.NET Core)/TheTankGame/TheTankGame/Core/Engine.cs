namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = true;
        }

        public void Run()
        {
            while (isRunning)
            {
                string input = this.reader.ReadLine();
                List<string> inputArgs = input.Split().ToList();
                if (inputArgs[0] == "Terminate")
                {
                    isRunning = false;
                }
                string result = this.commandInterpreter.ProcessInput(inputArgs);
                this.writer.WriteLine(result);
            }
        }
    }
}