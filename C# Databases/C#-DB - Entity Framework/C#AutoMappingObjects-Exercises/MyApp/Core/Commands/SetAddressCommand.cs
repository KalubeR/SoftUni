using System;
using MyApp.Core.Commands.Contracts;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class SetAddressCommand : ICommand
    {
        private readonly MyAppContext context;

        public SetAddressCommand(MyAppContext context)
        {
            this.context = context;
        }

        public string Execute(string[] inputArgs)
        {
            int employeeId = int.Parse(inputArgs[0]);
            string address = inputArgs[1];

            var employee = this.context.Employees
                .Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException("User not found!");
            }

            employee.Address = address;
            this.context.SaveChanges();

            return $"Address successfully changed!";
        }
    }
}