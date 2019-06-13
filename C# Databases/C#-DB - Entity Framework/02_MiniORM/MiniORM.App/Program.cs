using System;
using System.Linq;
using MiniORM.App.Data.Entities;

namespace MiniORM.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = @"Server=DESKTOP-M55K9NF\SQLEXPRESS;Database=MiniORM;Integrated Security=True";

            var context = new SoftUniDbContextClass(connectionString);

            context.Employees.Add(
                new Employee()
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
