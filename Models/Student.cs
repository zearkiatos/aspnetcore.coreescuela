using System;
using System.Collections.Generic;

namespace aspnetcore.coreescuela.Models
{
    public class Student : BaseSchoolObject
    {

        public List<Test> Tests { get; set; }

        public string CourseId { get; set; }

        public Course Course { get; set; }

    }
}