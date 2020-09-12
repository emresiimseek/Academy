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
        public void AssignInstructorToCourse(Course course, List<Instructor> ınstructors)
        {
            using (AcedemyContext context = new AcedemyContext())
            {
                foreach (Instructor ınstructor in ınstructors)
                {
                    context.People.Attach(ınstructor);
                    context.Courses.Attach(course);
                    ınstructor.Courses.Add(course);
                }

                context.SaveChanges();
            }
        }

        public void AssignStudentToCourse(Course course, List<Student> students)
        {
            using (AcedemyContext context = new AcedemyContext())
            {
                foreach (Student student in students)
                {
                    context.People.Attach(student);
                    context.Courses.Attach(course);
                    student.Courses.Add(course);
                }

                context.SaveChanges();
            }
        }

        public List<Course> GetAllCourseWithChild()
        {
            using (AcedemyContext acedemyContext = new AcedemyContext())
            {
                List<Course> courses = acedemyContext.Set<Course>().Include("Instructors").Include("Students").ToList();
                return courses;
            }
        }

        public Course GetCourseWithChild(int Id)
        {
            using (AcedemyContext acedemyContext = new AcedemyContext())
            {
                return acedemyContext.Set<Course>().Include("Instructors").Include("Students").FirstOrDefault(c => c.CourseId == Id);
            }
        }
    }
}
