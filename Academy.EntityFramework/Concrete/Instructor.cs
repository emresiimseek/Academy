using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.EntityFramework.Concrete
{
    public class Instructor : Person
    {
        [Required]
        public DateTime HireDate { get; set; }
        [Required, StringLength(500)]
        public string Biography { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
