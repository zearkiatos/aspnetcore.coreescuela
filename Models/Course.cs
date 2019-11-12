using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using aspnetcore.coreescuela.Models.Enum;

namespace aspnetcore.coreescuela.Models
{
    public class Course : BaseSchoolObject
    {
        [Required]
        public override string Name { get; set; }
        public ClassDayType ClassDay { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set; }

        public string SchoolId { get; set; }

        public School School { get; set; }

        public string Address { get; set; }

    }
}