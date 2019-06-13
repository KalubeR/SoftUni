﻿using System.Collections.Generic;

namespace MyApp.Core.ViewModels
{
    public class ManagerDto
    {
        public ManagerDto()
        {
            this.ManagedEmployees = new List<EmployeeDto>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDto> ManagedEmployees { get; set; }
    }
}