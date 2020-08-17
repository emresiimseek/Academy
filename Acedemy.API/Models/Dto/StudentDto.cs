using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Acedemy.API.Models.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string FirstName { get; set; }
        [Required, StringLength(200)]
        public string LastName { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        public virtual IList<CourseDto> Courses { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}