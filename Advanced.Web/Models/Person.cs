using System.ComponentModel.DataAnnotations;

namespace Advanced.Web.Models
{
    public class Person
    {
        public long PersonId { get; set; }

        [Required(ErrorMessage = "A firstname is required")]
        [MinLength(3, ErrorMessage = "Firstname mus be 3 or more characters")]
        public string Firstname { get; set; }


        [Required(ErrorMessage = "A surname is required")]
        [MinLength(3, ErrorMessage = "Surname mus be 3 or more characters")]
        public string Surname { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "A department most be selected")]
        public long DepartmentId { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "A location most be selected")]
        public long LocationId { get; set; }

        public Department Department { get; set; }

        public Location Location { get; set; }
    }
}