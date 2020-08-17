using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.EntityFramework.Concrete
{
    public class InstructorCourses
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key, Column(Order = 1)]
        public int InstructorId { get; set; }
        [Key, Column(Order = 2)]
        public int CourseId { get; set; }
        public List<Course> Courses { get; set; }
        public List<Instructor> Instructors { get; set; }
    }
}
