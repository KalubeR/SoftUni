using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Contracts;

namespace MyApp.Core
{
    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input[0] == "Exit")
                {
                    return;
                }

                var commandInterpreter = serviceProvider.GetService<ICommandInterpreter>();

                string result = commandInterpreter.Read(input);

                Console.WriteLine(result);
            }
        }
    }
}