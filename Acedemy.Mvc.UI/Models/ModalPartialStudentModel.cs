using Acedemy.API.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acedemy.Mvc.UI.Models
{
    public class ModalPartialStudentModel<T>
    {
        public List<T> EntityModal;
        public CourseDto CourseDto;

    }
}