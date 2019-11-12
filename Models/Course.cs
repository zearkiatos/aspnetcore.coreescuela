using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using aspnetcore.coreescuela.Models.Enum;

namespace aspnetcore.coreescuela.Models
{
    public class Course : BaseSchoolObject
    {
        [Required(ErrorMessage = "El nombre del Curso es requerido")]
        [StringLength(5)]
        public override string Name { get; set; }
        public ClassDayType ClassDay { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set; }

        public string SchoolId { get; set; }

        public School School { get; set; }
        [Display(Prompt ="Dirección correspondencia", Name="Address")]
        [Required(ErrorMessage = "Se requiere incluir una dirección")]
        [MinLength(10, ErrorMessage="La longitud mínima de la dirección es 10")]
        public string Address { get; set; }

    }
}