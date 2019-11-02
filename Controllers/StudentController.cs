using System;
using System.Collections.Generic;
using System.Linq;
using aspnetcore.coreescuela.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.coreescuela.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult MultiStudent()
        {
            var students = this.GenerateRandomStudent();

            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Date = DateTime.Now;
            return View(students);
        }

        public IActionResult Index()
        {
            var student = new Student
            {
                Name = "Pepe Perez"
            };
            return View(student);
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

            return studentList.OrderBy((a) => a.UniqueId).ToList();



        }
    }


}