using Academy.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Acedemy.API.Models.Dto
{
    public class InstructorDto
    {
        public int Id { get; set; }
        [Required, StringLength(200)]
        [DisplayName("Ad")]
        public string FirstName { get; set; }
        [Required, StringLength(200)]
        [DisplayName("Soyad")]
        public string LastName { get; set; }
  
        public DateTime Birthdate { get; set; }
        public DateTime HireDate { get; set; }
        [StringLength(500)]
        public string Biography { get; set; }
        [Required, MaxLength(25)]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required, MaxLength(25)]
        [DisplayName("Parola")]
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public List<Course> Courses { get; set; }
        public  List<Role> Roles { get; set; }


    }
}