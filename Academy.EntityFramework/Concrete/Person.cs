using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.EntityFramework.Concrete
{
    public class Person : Entity
    {

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity),Key]
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string FirstName { get; set; }
        [Required, StringLength(200)]
        public string LastName { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }



    }
}
