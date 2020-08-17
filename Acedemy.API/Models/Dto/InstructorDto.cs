using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Acedemy.API.Models.Dto
{
    public class InstructorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime Birthdate { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required, StringLength(500)]
        public string Biography { get; set; }
        public virtual List<CourseDto> Courses { get; set; }
     
    }
}