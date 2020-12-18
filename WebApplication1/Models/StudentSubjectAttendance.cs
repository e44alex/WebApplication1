using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class StudentSubjectAttendance
    {
        public Guid Id { get; set; }

        public Guid SubjectId { get; set; }

        public Guid StudentId { get; set; }

        public int CountMissed { get; set; }

        [NotMapped]
        public string StudentName { get; set; }

        [NotMapped]
        public string SubjectName { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}