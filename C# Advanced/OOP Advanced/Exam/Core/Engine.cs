using System;
using System.Collections.Generic;
using System.Linq;
using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.isRunning = true;
        }

        public void Run()
        {
            while (isRunning)
            {
                List<string> input = this.reader.ReadLine().Split().ToList();
                if (input[0] == "Exit")
                {
                    isRunning = false;
                }

                this.writer.WriteLine(this.commandParser.Parse(input));

            }
        }
    }
}