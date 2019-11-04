using System;
using System.Collections.Generic;

namespace aspnetcore.coreescuela.Models
{
    public class Subject : BaseSchoolObject
    {
        public string CourseId { get; set; }

        public Course Course { get; set; }

        public List<Test> Tests { get; set; }
    }
}