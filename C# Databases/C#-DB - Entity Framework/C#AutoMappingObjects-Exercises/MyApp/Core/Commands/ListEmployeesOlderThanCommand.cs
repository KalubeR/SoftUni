using System.Linq;
using MyApp.Core.Commands.Contracts;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly MyAppContext context;

        public ListEmployeesOlderThanCommand(MyAppContext context)
        {
            this.context = context;
        }

        public string Execute(string[] inputArgs)
        {
            //int age = int.Parse(inputArgs[0]);

            //var employees = this.context.Employees
            //    .Where(x => x.Birthday.Value.Year)
            return null;
        }
    }
}