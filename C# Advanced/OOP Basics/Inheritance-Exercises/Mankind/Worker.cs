using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private double salary;

        private double workingHours;

        public Worker(string firstName, string lastName, double salary, double workingHours)
            : base(firstName, lastName)
        {
            this.Salary = salary;
            this.WorkingHours = workingHours;
        }

        public double Salary
        {
            get { return salary; }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                salary = value;
            }
        }

        public double WorkingHours
        {
            get { return workingHours; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                workingHours = value;
            }
        }

        public double SalaryPerHour { get => this.GetSalaryPerHour(); }

        public double GetSalaryPerHour()
        {
            return this.Salary / (5 * this.WorkingHours);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.LastName}");
            sb.AppendLine($"Week Salary: {this.Salary:f2}");
            sb.AppendLine($"Hours per day: {this.WorkingHours:f2}");
            sb.AppendLine($"Salary per hour: {this.SalaryPerHour:f2}");

            string result = sb.ToString();
            return result;
        }
    }
}
