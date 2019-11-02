using System;
using System.Collections.Generic;
using aspnetcore.coreescuela.Models.Enum;

namespace aspnetcore.coreescuela.Models
{
    public class Course : BaseSchoolObject
    {

        public ClassDayType ClassDay { get; set; }

        public List<Subject> Subject { get; set; }

        public List<Student> Students { get; set; }

        public string Address { get; set; }

    }
}