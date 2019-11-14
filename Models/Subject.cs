using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspnetcore.coreescuela.Models
{
    public class Subject : BaseSchoolObject
    {

        [Required(ErrorMessage = "The name field is required")]
        public override string Name { get; set; }
        public string SchoolId { get; set; }

        public School School { get; set; }

        public List<Test> Tests { get; set; }
    }
}