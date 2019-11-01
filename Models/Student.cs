using System;
using System.Collections.Generic;

namespace aspnetcore.coreescuela.Models
{
    public class Student : BaseSchoolObject
    {

        public List<Test> Test { get; set; }

    }
}