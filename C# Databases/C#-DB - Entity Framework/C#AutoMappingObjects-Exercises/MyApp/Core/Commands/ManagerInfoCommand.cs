using System;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class ManagerInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public ManagerInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            int employeeId = int.Parse(inputArgs[0]);

            var employee = this.context.Employees
                .Include(m => m.ManagedEmployees)
                .FirstOrDefault(x => x.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException("User not found!");
            }

            var managerDto = this.mapper.CreateMappedObject<ManagerDto>(employee);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(
                $"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.ManagedEmployees.Count}");

            foreach (var employe in managerDto.ManagedEmployees)
            {
                sb.AppendLine($"    - {employe.FirstName} {employe.LastName} - ${employe.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}