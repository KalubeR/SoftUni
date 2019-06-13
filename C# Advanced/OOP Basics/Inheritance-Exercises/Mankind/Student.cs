using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return facultyNumber; }
            set
            {
                bool isValid = true;
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                foreach (var item in value)
                {
                    if (!char.IsLetterOrDigit(item))
                    {
                        isValid = false;
                    }
                }
                if (isValid == false)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.LastName}");
            sb.AppendLine($"Faculty number: {this.FacultyNumber}");

            string result = sb.ToString();
            return result;
        }
    }
}
