using System;

namespace aspnetcore.coreescuela.Models
{
    public abstract class BaseSchoolObject
    {
        public string UniqueId { get; set; }
        public string Name { get; set; }

        public BaseSchoolObject() => (UniqueId) = (Guid.NewGuid().ToString());

        public override string ToString()
        {
            return $"{Name}, {UniqueId}";
        }
    }
}