using Academy.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acedemy.API.Models.Dto
{
    public class AttendanceDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}