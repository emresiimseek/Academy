using Academy.EntityFramework.Concrete;
using FrameworkCore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.DataAccess.Abstract
{
    public interface ICourseDal : IRepository<Course>
    {

        List<Course> GetAllCourseWithChild();
        Course GetCourseWithChild(int Id);


    }
}
