using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acedemy.API.Models.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime Birthdate { get; set; }
    }
}