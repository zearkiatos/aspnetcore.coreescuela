using System;
using System.ComponentModel.DataAnnotations;

namespace aspnetcore.coreescuela.Models
{
    public abstract class BaseSchoolObject
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "The name field is required")]
        public virtual string Name { get; set; }

        public BaseSchoolObject() => (Id) = (Guid.NewGuid().ToString());

        public override string ToString()
        {
            return $"{Name}, {Id}";
        }
    }
}