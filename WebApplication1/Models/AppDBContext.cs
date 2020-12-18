using System.Data.Entity;

namespace WebApplication1.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubjectAttendance> Attendances { get; set; }

        public AppDBContext() : base("DbConnection")
        {
        }
    }
}