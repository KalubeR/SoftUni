using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.HomeworkSubmissions = new List<Homework>();
            this.CourseEnrollments = new List<StudentCourse>();
        }

        public int StudentId { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "CHAR(10)")]
        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }

        public ICollection<StudentCourse> CourseEnrollments { get; set; }
    }
}