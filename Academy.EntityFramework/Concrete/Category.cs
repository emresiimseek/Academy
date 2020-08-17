using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.EntityFramework.Concrete
{
    public class Category : Entity
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
