using System;

namespace aspnetcore.coreescuela.Models
{
    public class Test : BaseSchoolObject
    {

        public string StudentId { get; set; }
        public Student Student { get; set; }

        public string SubjectId { get; set; }         
        public Subject Subject { get; set; }

        public float Result { get; set; }

        public override string ToString()
        {
            return $"{Result}, {Student.Name}, {Subject.Name}";
        }
    }
}