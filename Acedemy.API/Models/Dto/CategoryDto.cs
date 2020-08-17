using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acedemy.API.Models.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<CategoryDto> Categories { get; set; }
    }
}