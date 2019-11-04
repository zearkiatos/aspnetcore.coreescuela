using System;
using System.Collections.Generic;
using System.Linq;
using aspnetcore.coreescuela.Models;
using aspnetcore.coreescuela.Models.Enum;
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

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var school = new School();
            school.FoundationYear = 2005;
            school.Id = Guid.NewGuid().ToString();
            school.Name = "Platzi School";
            school.City = "Bogota";
            school.Country = "Colombia";
            school.Address = "Avenida Siempre Viva";
            school.SchoolType = SchoolType.Secondary;

            modelBuilder.Entity<School>().HasData(school);

            var subjects = new List<Subject>(){
                new Subject{
                    Name = "Programación"
                },
                new Subject{
                    Name = "Matemática"
                },
                new Subject{
                    Name = "Educación Física"
                },
                 new Subject{
                    Name = "Castellano"
                },
                new Subject{
                    Name = "Ciencias Naturales"
                }
            };

            modelBuilder.Entity<Subject>().HasData(subjects);

             modelBuilder.Entity<Student>().HasData(this.GenerateRandomStudent().ToArray());
        }

        private List<Student> GenerateRandomStudent()
        {
            string[] name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás", "Zoy" };
            string[] lastName1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera", "Cerra" };
            string[] name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro", "Labe" };

            var studentList = from n1 in name1
                              from n2 in name2
                              from a1 in lastName1
                              select new Student
                              {
                                  Name = $"{n1} {n2} {a1}"
                              };

            return studentList.OrderBy((a) => a.Id).ToList();



        }
    }
}