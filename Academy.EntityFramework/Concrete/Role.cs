using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.EntityFramework.Concrete
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Instructor> Instructors { get; set; }
    }
}
