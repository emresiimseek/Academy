using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.EntityFramework.Concrete
{
    public class Attendance : Entity
    {
        public Attendance()
        {
            AttendanceDetails = new List<AttendanceDetail>();
        }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity),Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual List<AttendanceDetail> AttendanceDetails { get; set; }
    }
}
