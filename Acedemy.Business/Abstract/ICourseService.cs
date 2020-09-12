using Academy.EntityFramework.Concrete;
using Academy.EntityFramework.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.Business.Abstract
{
    public interface ICourseService : IService<Course>
    {
        List<Course> GetAllCourseWithChild();
        Course GetCourseWithChild(int Id);
        BusinessLayerResult<AssignDto> AssignStudentToCourse(AssignDto assignDto);
        BusinessLayerResult<AssignDto> AssignInstructorToCourse(AssignDto assignDto);


    }
}
