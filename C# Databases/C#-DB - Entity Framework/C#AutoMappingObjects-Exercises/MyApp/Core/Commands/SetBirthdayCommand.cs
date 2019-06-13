using System;
using System.Globalization;
using MyApp.Core.Commands.Contracts;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class SetBirthdayCommand : ICommand
    {
        private readonly MyAppContext context;

        public SetBirthdayCommand(MyAppContext context)
        {
            this.context = context;
        }

        public string Execute(string[] inputArgs)
        {
            int employeeId = int.Parse(inputArgs[0]);
            DateTime birthday = DateTime.ParseExact(inputArgs[1], "dd-mm-yyyy", CultureInfo.InvariantCulture);

            var employee = this.context.Employees
                .Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException("Employee not found!");
            }

            employee.Birthday = birthday;
            this.context.SaveChanges();

            return $"Birthday successfully set!";
        }
    }
}