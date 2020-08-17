using Academy.EntityFramework.Concrete;
using Acedemy.DataAccess.Abstract;
using FrameworkCore.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.DataAccess.Concrete
{
    public class CourseDal : RepositoryBase<Course, AcedemyContext>, ICourseDal
    {
        public List<Course> GetAllCourseWithChild()
        {
            using (AcedemyContext acedemyContext = new AcedemyContext())
            {
                return acedemyContext.Set<Course>().Include("Students").Include("Instructors").ToList();
            }
        }

        public Course GetCourseWithChild(int Id)
        {
            using (AcedemyContext acedemyContext = new AcedemyContext())
            {
                return acedemyContext.Set<Course>().Include("Students").Include("Instructors").FirstOrDefault(c=>c.CourseId==Id);
            }
        }
    }
}
