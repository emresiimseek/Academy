using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.EntityFramework.Concrete.DTOs
{
    public class AttendanceModelDto
    {
        [Required]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Lütfen listeden öğrenci seçiniz.")]
        public int[] students { get; set; }
        [Required(ErrorMessage = "Lütfen yoklama tarihini seçiniz.")]
        public string CreatedOn { get; set; }
    }
}
