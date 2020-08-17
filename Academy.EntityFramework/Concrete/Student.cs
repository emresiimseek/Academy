using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.EntityFramework.Concrete
{
    public class Student : Person
    {
        
        [Required]
        public DateTime EnrollmentDate { get; set; }
        public int Absence { get; set; }
        public virtual IList<Course> Courses { get; set; }


    }
}
