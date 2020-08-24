using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Acedemy.Mvc.UI.Models
{
    public class LoginUserModel
    {
        [Required, MaxLength(25)]
        public string Username { get; set; }
        [Required, MaxLength(25)]
        public string Password { get; set; }
    }
}