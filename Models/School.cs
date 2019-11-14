using System.Collections.Generic;
using aspnetcore.coreescuela.Models.Enum;

namespace aspnetcore.coreescuela.Models
{
    public class School : BaseSchoolObject
    {
        public School(int foundationYear, string country, string city, string address, SchoolType typeSchool)
        {
            this.FoundationYear = foundationYear;
            this.Country = country;
            this.City = city;
            this.Address = address;
            this.SchoolType = typeSchool;

        }
        public School(){

        }
        public int FoundationYear { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }


        public SchoolType SchoolType { get; set; }

        public School(string name, int foundationYear) => (Name, FoundationYear) = (name, foundationYear);

        public School(string name, int foundationYear, SchoolType type, string country = "", string city = "")
        {
            (Name, FoundationYear) = (name, FoundationYear);
            Country = country;
            City = city;

        }

        public List<Course> Course { get; set; }

        public override string ToString()
        {
            return $"Name: \"{Name}\" , Tipo: {SchoolType} \n Country: {System.Environment.NewLine} {Country}, City: {City}";
        }



    }
}