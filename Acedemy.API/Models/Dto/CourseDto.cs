using Academy.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Acedemy.API.Models.Dto
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        [Required, StringLength(200)]
        [DisplayName("Kurs Adı")]
        public string Title { get; set; }
        [Required, StringLength(500)]
        [DisplayName("Kurs Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Kurs Toplam Süre")]
        public int TotalTime { get; set; }
        [DisplayName("Oluşturma Tarihi")]
        public DateTime CreatedOn { get; set; }
        [DisplayName("Değiştirme Tarihi")]
        public DateTime ModifiedOn { get; set; }
        public List<Instructor> Instructors { get; set; }
        public virtual List<Attendance> Attendances { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<Person> People { get; set; }
    }
}