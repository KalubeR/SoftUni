﻿using System;

namespace MyApp.Core.ViewModels
{
    public class EmployeePersonalInfoDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public decimal Salary { get; set; }

        public string Address { get; set; }
    }
}