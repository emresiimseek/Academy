using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.EntityFramework.Concrete.DTOs
{
    public class AssignDto
    {
        public int CourseId { get; set; }
        public int[] People { get; set; }
    }
}
