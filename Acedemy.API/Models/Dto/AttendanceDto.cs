using Academy.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Acedemy.API.Models.Dto
{
    public class AttendanceDto
    {
        public AttendanceDto()
        {
            AttendanceDetails = new List<AttendanceDetail>();
        }
        public int AttendaceId { get; set; }
        public int CourseId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedOn { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ModifiedOn { get; set; }
        public virtual Course Course { get; set; }
        public virtual List<AttendanceDetail> AttendanceDetails { get; set; }

    }
}