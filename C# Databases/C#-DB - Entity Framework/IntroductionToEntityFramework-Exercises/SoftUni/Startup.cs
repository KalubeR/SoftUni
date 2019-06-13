using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var result = RemoveTown(context);
                Console.WriteLine(result);
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(x => new
                {
                    EmployeeId = x.EmployeeId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MiddleName = x.MiddleName,
                    JobTitle = x.JobTitle,
                    Salary = x.Salary
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    Salary = x.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    DepartmentName = x.Department.Name,
                    x.Salary
                })
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var address = new Address();
            address.AddressText = "Vitoshka 15";
            address.TownId = 4;

            var employee = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            employee.Address = address;
            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(a => a.AddressId)
                .Select(x => new
                {
                    x.Address.AddressText
                })
                .Take(10)
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(x => x.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 &&
                                                         p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeFullName = e.FirstName + " " + e.LastName,
                    ManagerFullName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(x => new
                    {
                        x.Project.Name,
                        x.Project.StartDate,
                        x.Project.EndDate
                    })

                })
                .Take(10)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFullName} - Manager: {employee.ManagerFullName}");

                foreach (var project in employee.Projects)
                {
                    var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    var endDate = project.EndDate.HasValue
                        ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                        : "not finished";

                    sb.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
                .Select(x => new
                {
                    x.AddressText,
                    x.Town.Name,
                    x.Employees.Count
                })
                .OrderByDescending(a => a.Count)
                .ThenBy(a => a.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Name} - {address.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(y => new
                {
                    y.FirstName,
                    y.LastName,
                    y.JobTitle,
                    Projects = y.EmployeesProjects.Select(a => new
                    {
                        a.Project.Name
                    })
                        .OrderBy(p => p.Name)
                        .ToList()
                })
                .FirstOrDefault();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var project in employee.Projects)
            {
                sb.AppendLine($"{project.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFullName = x.Manager.FirstName + " " + x.Manager.LastName,
                    Employees = x.Employees.Select(y => new
                    {
                        EmployeeFullName = y.FirstName + " " + y.LastName,
                        y.JobTitle
                    })
                        .OrderBy(y => y.EmployeeFullName)
                        .ToList()
                })
                .ToList();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} – {department.ManagerFullName}");
                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.EmployeeFullName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    x.StartDate
                })
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");

                var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt");
                sb.AppendLine($"{startDate}");

            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            string[] departmentsNames = new[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Where(e => departmentsNames.Contains(e.Department.Name))
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12M;
            }

            context.SaveChanges();

            var resultEmployees = context.Employees
                .Where(e => departmentsNames.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Salary
                })
                .ToList();

            foreach (var resultEmployee in resultEmployees)
            {
                sb.AppendLine($"{resultEmployee.FirstName} {resultEmployee.LastName} (${resultEmployee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => EF.Functions.Like(e.FirstName, "Sa%"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var project = context.Projects
                .FirstOrDefault(p => p.ProjectId == 2);

            var employeesProjects = context.EmployeesProjects.Where(x => x.ProjectId == 2)
                .ToList();
            context.EmployeesProjects.RemoveRange(employeesProjects);

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .Select(x => new
                {
                    x.Name
                })
                .ToList();

            foreach (var pr in projects)
            {
                sb.AppendLine($"{pr.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            string townName = "Seattle";

            var employees = context.Employees
                .Where(x => x.Address.Town.Name == townName)
                .ToList();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            var addressCount = context.Addresses
                .Count(x => x.Town.Name == townName);

            var addresses = context.Addresses
                .Where(a => a.Town.Name == townName)
                .ToList();

            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
            }

            var town = context.Towns
                .FirstOrDefault(t => t.Name == townName);

            context.Towns
                .Remove(town);

            context.SaveChanges();

            sb.AppendLine($"{addressCount} addresses in Seattle were deleted");

            return sb.ToString().TrimEnd();
        }
    }
}
