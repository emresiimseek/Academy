using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Academy.EntityFramework.Concrete.DTOs
{
    public class ReportDto
    {
        [Required]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Lütfen yoklama almak istediğiniz tarihi seçiniz.")]
        public string ReportDateAsString { get; set; }
        public DateTime ReportDate { get; set; }

    }
}