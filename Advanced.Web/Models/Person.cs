using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Components;

namespace Advanced.Web.Models
{
    public class Person
    {
        public long PersonId { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public long DepartmentId { get; set; }

        public long LocationId { get; set; }

        public Department Department { get; set; }

        public Location Location { get; set; }
    }
}