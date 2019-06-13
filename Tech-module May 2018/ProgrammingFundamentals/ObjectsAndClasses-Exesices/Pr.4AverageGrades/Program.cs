using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr._4AverageGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                List<string> tokens = Console.ReadLine().Split().ToList();

                string name = tokens[0];
                tokens.Remove(tokens[0]);
                List<double> grades = tokens.Select(double.Parse).ToList();

                Student student = new Student(name, grades);
                student.AverageGrade = grades.Average();
                students.Add(student);
            }

            var filteredStudents = students.Where(st => st.AverageGrade >= 5.00).OrderBy(st => st.Name).ThenByDescending(st => st.AverageGrade);

            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrade:f2}");
            }
        }
    }

    class Student
    {
        public Student(string name, List<double> grades)
        {
            Name = name;
            Grades = grades;
        }

        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double AverageGrade { get; set; }
    }
}
