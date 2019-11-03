using aspnetcore.coreescuela.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore.coreescuela.Context
{
    public class SchoolContext : DbContext
    {
        public DbSet<School> Schools { get; set; }


        public DbSet<Subject> Subjects { get; set; }


        public DbSet<Course> Courses { get; set; }


        public DbSet<Student> Students { get; set; }

        public DbSet<Test> Tests { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options): base(options)
        {

        }
    }
}