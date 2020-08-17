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
        public int[] Students { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedOn { get; set; }
    }
}
