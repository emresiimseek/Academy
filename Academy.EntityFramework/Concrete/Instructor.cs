using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.EntityFramework.Concrete
{
    [Table("Instructors")]
    public class Instructor : Person
    {
        public Instructor()
        {
            Courses = new List<Course>();
        }

        [Required]
        public DateTime HireDate { get; set; }
        [StringLength(500)]
        public string Biography { get; set; }
        [Required, MaxLength(25)]
        public string UserName { get; set; }
        [Required, MaxLength(25)]
        public string Password { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual List<Role> Roles { get; set; }



    }
}
