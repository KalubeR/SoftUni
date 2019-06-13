using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                double salary = double.Parse(input[1]);
                string position = input[2];
                string department = input[3];

                Employee employee = new Employee(name, salary, position, department);

                if (input.Length == 6)
                {
                    string email = input[4];
                    int age = int.Parse(input[5]);
                    employee.Email = email;
                    employee.Age = age;
                }
                else if (input.Length == 5)
                {
                    if (input[4].Contains('@'))
                    {
                        string email = input[4];
                        employee.Email = email;
                    }
                    else
                    {
                        int age = int.Parse(input[4]);
                        employee.Age = age;
                    }
                }
                employees.Add(employee);
            }

            var topDepartment = employees.GroupBy(x => x.Department)
                                         .ToDictionary(x => x.Key, y => y.Select(s => s))
                                         .OrderByDescending(x => x.Value.Average(s => s.Salary))
                                         .FirstOrDefault();
            Console.WriteLine($"Highest Average Salary: {topDepartment.Key}");
            foreach (Employee employee in topDepartment.Value.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}
