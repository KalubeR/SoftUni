using System;
using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class SetManagerCommand : ICommand
    {
        private readonly MyAppContext context;

        public SetManagerCommand(MyAppContext context)
        {
            this.context = context;
        }

        public string Execute(string[] inputArgs)
        {
            int employeeId = int.Parse(inputArgs[0]);
            int managerId = int.Parse(inputArgs[1]);

            var employee = this.context.Employees
                .Find(employeeId);
            var manager = this.context.Employees
                .Find(managerId);

            if (employee == null || manager == null)
            {
                throw new ArgumentNullException("Employee not found!");
            }

            employee.ManagerId = managerId;

            this.context.SaveChanges();

            return $"Manager successfully set!";
        }
    }
}