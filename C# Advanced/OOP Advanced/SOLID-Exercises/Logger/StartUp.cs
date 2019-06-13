using Logger.Appenders;
using Logger.Appenders.Contracts;
using Logger.Layouts;
using Logger.Layouts.Contracts;
using Logger.Loggers.Contracts;
using Logger.Loggers;
using System;
using Logger.Loggers.Enums;
using Logger.Core.Contracts;
using Logger.Core;

namespace Logger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
