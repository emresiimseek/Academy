using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.EntityFramework.Concrete.DTOs
{
    public class AttendanceModelDto
    {
        public int CourseId { get; set; }
        public int[] students { get; set; }
        public string CreatedOn { get; set; }
    }
}
