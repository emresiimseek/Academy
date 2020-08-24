using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Acedemy.Mvc.UI.Models
{
    public class RegisterUserModel
    {
        [Required, StringLength(200)]
        public string FirstName { get; set; }
        [Required, StringLength(200)]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}