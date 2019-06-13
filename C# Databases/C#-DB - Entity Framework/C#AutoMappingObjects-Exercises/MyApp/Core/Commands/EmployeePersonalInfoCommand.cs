using System;
using System.Globalization;
using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly Mapper mapper;
        private readonly MyAppContext context;

        public EmployeePersonalInfoCommand(Mapper mapper, MyAppContext context)
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

            var employeePersonalInfoDto = this.mapper.CreateMappedObject<EmployeePersonalInfoDto>(employee);

            return $"ID: 1 - {employeePersonalInfoDto.FirstName} {employeePersonalInfoDto.LastName} - ${employeePersonalInfoDto.Salary:f2}" +  Environment.NewLine +
               $"Birthday: {employeePersonalInfoDto.Birthday} " + Environment.NewLine +
                $"Address: {employeePersonalInfoDto.Address}";

        }
    }
}