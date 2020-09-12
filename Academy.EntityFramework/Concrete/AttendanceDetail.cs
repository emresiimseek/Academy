using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.EntityFramework.Concrete
{
    public class AttendanceDetail : Entity
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceDetailId { get; set; }
        [Key, Column(Order = 1)]
        public int AttendanceId { get; set; }
        [Key, Column(Order = 2)]
        public int StudentId { get; set; }
        public virtual Attendance Attendance { get; set; }
        public virtual Student Student { get; set; }
    }
}
