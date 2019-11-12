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

            //Loading Courses of the school
            var courses = LoadingCourse(school);

            //By each course loading subjects
            var subjects = LoadingSubject(school);
            //By each course loading Students

            var students = LoadingStudents(courses);


            var tests = LoadingTest(courses, students, subjects);


            modelBuilder.Entity<School>().HasData(school);

            modelBuilder.Entity<Course>().HasData(courses.ToArray());

            modelBuilder.Entity<Subject>().HasData(subjects.ToArray());

            modelBuilder.Entity<Student>().HasData(students.ToArray());

            modelBuilder.Entity<Test>().HasData(tests.ToArray());

        }

        private static List<Subject> LoadingSubject(School school)
        {
            var subjectList = new List<Subject>();
            var tmpList = new List<Subject> {
                            new Subject{
                                Name="Matemáticas"} ,
                            new Subject{ SchoolId = school.Id, Name="Educación Física"},
                            new Subject{ SchoolId = school.Id, Name="Castellano"},
                            new Subject{ SchoolId = school.Id, Name="Ciencias Naturales"},
                            new Subject{ SchoolId = school.Id, Name="Programación"}

                };
            return tmpList;
        }

        private static List<Course> LoadingCourse(School school)
        {
            var schoolCourses = new List<Course>()
            {
                new Course(){ SchoolId = school.Id, Name="101", ClassDay = ClassDayType.Morning},
                new Course(){ SchoolId = school.Id, Name="201", ClassDay = ClassDayType.Morning},
                new Course(){ SchoolId = school.Id, Name="301", ClassDay = ClassDayType.Morning},
                new Course(){ SchoolId = school.Id, Name="401", ClassDay = ClassDayType.Afternoon},
                new Course(){ SchoolId = school.Id, Name="501", ClassDay = ClassDayType.Afternoon}
            };
            return schoolCourses;
        }

        private static List<Student> LoadingStudents(List<Course> courses)
        {
            var studentList = new List<Student>();
            Random rnd = new Random();
            foreach (var course in courses)
            {
                int randomQty = rnd.Next(5, 20);
                var tmpList = GenerateRandomStudent(randomQty, course);
                studentList.AddRange(tmpList);
            }
            return studentList;
        }

        private static List<Test> LoadingTest(List<Course> courses, List<Student> students, List<Subject> subjects, int testByCourses = 5)
        {
            var test = new List<Test>();
            Random rnd = new Random();
            foreach (var course in courses)
            {
                for (var i = 0; i < testByCourses; i++)
                {
                    var listTest = (from st in students.Where(s => s.CourseId == course.Id)
                                    from su in subjects.Where(s => s.SchoolId== course.SchoolId)
                                    select new Test
                                    {
                                        Name = $"Examen {i + 1} de {su.Name}",
                                        StudentId = st.Id,
                                        SubjectId = su.Id,
                                        Result = MathF.Round((float)rnd.NextDouble() * 20, 2)
                                    }).ToList();

                    test.AddRange(listTest);
                }

            }
            return test;
        }

        private static List<Student> GenerateRandomStudent(int qty, Course course)
        {
            string[] name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás", "Zoy" };
            string[] lastName1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera", "Cerra" };
            string[] name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro", "Labe" };

            var studentList = from n1 in name1
                              from n2 in name2
                              from a1 in lastName1
                              select new Student
                              {
                                  CourseId = course.Id,
                                  Name = $"{n1} {n2} {a1}",
                              };

            return studentList.OrderBy((a) => a.Id).Take(qty).ToList();
        }

    }
}