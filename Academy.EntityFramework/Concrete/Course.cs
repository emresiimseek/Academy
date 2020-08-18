using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.EntityFramework.Concrete
{
    public class Course : Entity
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        [Required, StringLength(200)]
        public string Title { get; set; }
        [Required, StringLength(500)]
        public string Description { get; set; }
        public int TotalTime { get; set; }
        [JsonIgnore]
        public virtual List<Instructor> Instructors { get; set; }
        [JsonIgnore]
        public virtual List<Student> Students { get; set; }

    }
}
