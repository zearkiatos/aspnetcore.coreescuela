using System;
using System.Collections.Generic;
using System.Linq;
using aspnetcore.coreescuela.Context;
using aspnetcore.coreescuela.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.coreescuela.Controllers
{
    public class StudentController : Controller
    {

     private SchoolContext context;

        public StudentController(SchoolContext context)
        {
            this.context = context;
        }
        public IActionResult MultiStudent()
        {

            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Date = DateTime.Now;
            return View(this.context.Students);
        }
        [Route("Student/Index")]
        [Route("Student/Index/{studentId}")]
        public IActionResult Index(string studentId)
        {
            if (!String.IsNullOrEmpty(studentId))
            {
                var student = from st in this.context.Students
                              where st.Id == studentId
                              select st;
                return View(student.SingleOrDefault());
            }
            else
            {
                return View("MultiStudent",this.context.Students);
            }
        }
        [Route("Student")]
        public IActionResult Index()
        {
            return View(this.context.Students.FirstOrDefault());
        }
    }


}