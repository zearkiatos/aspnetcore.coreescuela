using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using aspnetcore.coreescuela.Models.Enum;

namespace aspnetcore.coreescuela.Models
{
    public class Course : BaseSchoolObject
    {
        [Required(ErrorMessage = "The field name is required")]
        [StringLength(5)]
        public override string Name { get; set; }
        public ClassDayType ClassDay { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set; }

        public string SchoolId { get; set; }

        public School School { get; set; }
        [Display(Prompt ="Address", Name="Address")]
        [Required(ErrorMessage = "The field address is required")]
        [MinLength(10, ErrorMessage="The min length is 10 characters")]
        public string Address { get; set; }

    }
}