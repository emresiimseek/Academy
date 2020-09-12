using Academy.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Acedemy.API.Models.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        [Required, StringLength(200)]
        [DisplayName("Ad")]
        public string FirstName { get; set; }
        [Required, StringLength(200)]
        [DisplayName("Soyad")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Cinsiyet")]
        public char Gender { get; set; }
        [Required]
        [DisplayName("Doğum Tarihi")]
        public DateTime Birthdate { get; set; }
        [Required]
        [DisplayName("Kayıt Tarihi")]
        public DateTime EnrollmentDate { get; set; }
        public virtual List<Course> Courses { get; set; }
        [DisplayName("Oluşturma Tarihi")]
        public DateTime CreatedOn { get; set; }
        [DisplayName("Güncelleme Tarihi")]
        public DateTime ModifiedOn { get; set; }
    }
}