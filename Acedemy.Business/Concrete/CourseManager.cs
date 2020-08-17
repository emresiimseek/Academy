using Academy.EntityFramework.Concrete;
using Acedemy.Business.Abstract;
using Acedemy.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.Business.Concrete
{
    public class CourseManager : ICourseService
    {
        private ICourseDal _courseDal { get; set; }
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }
        public List<Course> GetAll()
        {
            return _courseDal.GetAll();
        }

        public Course Get(int id)
        {
            return _courseDal.Get(c => c.CourseId == id);
        }

        public void Add(Course course)
        {
            _courseDal.Add(course);
        }

        public void Update(Course course)
        {
            _courseDal.Update(course);
        }

        public void Delete(Course course)
        {
            _courseDal.Delete(course);
        }

        public List<Course> GetAllCourseWithChild()
        {
            return _courseDal.GetAllCourseWithChild();
        }

        public Course GetCourseWithChild(int Id)
        {
            return _courseDal.GetCourseWithChild(Id);
        }
    }
}
