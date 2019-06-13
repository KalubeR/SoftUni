using System;
using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class EmployeeInfoCommand : ICommand
    {
        private readonly Mapper mapper;
        private readonly MyAppContext context;

        public EmployeeInfoCommand(Mapper mapper, MyAppContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public string Execute(string[] inputArgs)
        {
            int employeeId = int.Parse(inputArgs[0]);

            var employee = this.context.Employees
                .Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException("User not found!");
            }

            var employeeInfoDto = this.mapper.CreateMappedObject<EmployeeInfoDto>(employee);

            return
                $"ID: {employeeInfoDto.Id} - {employeeInfoDto.FirstName} {employeeInfoDto.LastName} - ${employeeInfoDto.Salary:f2}";
        }
    }
}