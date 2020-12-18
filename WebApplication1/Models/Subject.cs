using System;
using System.ComponentModel;

namespace WebApplication1.Models
{
    public class Subject
    {
        public Guid Id { get; set; }

        [DisplayName("Subject Name")]
        public string Name { get; set; }
    }
}