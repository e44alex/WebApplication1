using System;
using System.ComponentModel;

namespace WebApplication1.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        [DisplayName("Student Name")]
        public string Name { get; set; }

        public string Address { get; set; }

        [DisplayName("Group Number")]
        public string GroupNumber { get; set; }

        [DisplayName("Course")]
        public int CourseNumber { get; set; }
    }
}