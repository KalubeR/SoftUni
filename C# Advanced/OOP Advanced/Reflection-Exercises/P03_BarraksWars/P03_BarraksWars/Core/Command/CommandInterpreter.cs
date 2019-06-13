using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P03_BarraksWars.Core.Command
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        public IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        public IUnitFactory UnitFactory
        {
            get { return unitFactory; }
            set { unitFactory = value; }
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

            var instance = (IExecutable)Activator.CreateInstance(type, new object[] { data, this.repository, unitFactory});

            return instance;
        }
    }
}
