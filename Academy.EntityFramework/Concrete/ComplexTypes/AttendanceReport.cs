using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.EntityFramework.Concrete.ComplexTypes
{
    public class AttendanceReport
    {
        public int AttendanceId { get; set; }
        public int  CourseId { get; set; }
        public string  CourseName { get; set; }
        public string  StudentFullName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
