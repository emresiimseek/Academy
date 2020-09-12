using Academy.EntityFramework.Concrete;
using Academy.EntityFramework.Concrete.DTOs;
using Academy.EntityFramework.Messages;
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
        private IStudentDal _studentDal { get; set; }
        private IUserDal _userDal { get; set; }
        public CourseManager(ICourseDal courseDal, IStudentDal studentDal, IUserDal userDal)
        {
            _courseDal = courseDal;
            _studentDal = studentDal;
            _userDal = userDal;
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

        public BusinessLayerResult<AssignDto> AssignStudentToCourse(AssignDto assignDto)
        {
            BusinessLayerResult<AssignDto> businessLayerResult = new BusinessLayerResult<AssignDto>();
            businessLayerResult.Result = assignDto;
            Course currentcourse = _courseDal.Get(x => x.CourseId == assignDto.CourseId);
            List<Student> students = new List<Student>();
            foreach (int Id in assignDto.People)
            {
                Student student = _studentDal.Get(s => s.Id == Id);
                Course course = _courseDal.GetCourseWithChild(assignDto.CourseId);
                var isExist = course.Students.FirstOrDefault(x => x.Id == student.Id);
                if (isExist == null)
                {
                    students.Add(student);
                }
                else
                {
                    businessLayerResult.AddError(MessagesCodes.AlreadyExist, $"{student.Id} numaralı öğrenci zaten kursa kayıtlıdır.");
                }
            }
            if (businessLayerResult.Error.Select(x => x.Code == MessagesCodes.AlreadyExist).ToList().Count < assignDto.People.Length || businessLayerResult.Error.Count == 0)
            {
                _courseDal.AssignStudentToCourse(currentcourse, students);
            }
            else
            {
                businessLayerResult.AddError(MessagesCodes.AlreadyExist, "Kayıtlı öğrenciler için işlem yapılmamıştır.");
            }
            return businessLayerResult;

        }

        public BusinessLayerResult<AssignDto> AssignInstructorToCourse(AssignDto assignDto)
        {
            BusinessLayerResult<AssignDto> businessLayerResult = new BusinessLayerResult<AssignDto>();
            businessLayerResult.Result = assignDto;
            Course currentcourse = _courseDal.Get(x => x.CourseId == assignDto.CourseId);
            List<Instructor> ınstructors = new List<Instructor>();
            foreach (int Id in assignDto.People)
            {
                Instructor ınstructor = _userDal.Get(s => s.Id == Id);
                Course course = _courseDal.GetCourseWithChild(assignDto.CourseId);
                var isExist = course.Instructors.FirstOrDefault(x => x.Id == ınstructor.Id);
                if (isExist == null)
                {
                    ınstructors.Add(ınstructor);
                }
                else
                {
                    businessLayerResult.AddError(MessagesCodes.AlreadyExist, $"{ınstructor.Id} numaralı Eğitmen zaten kursa atanmış.");
                }
            }
            if (businessLayerResult.Error.Select(x => x.Code == MessagesCodes.AlreadyExist).ToList().Count < assignDto.People.Length|| businessLayerResult.Error.Count==0)
            {
                _courseDal.AssignInstructorToCourse(currentcourse, ınstructors);

            }
            else
            {
                businessLayerResult.AddError(MessagesCodes.AlreadyExist, "Atanmış eğitmenler için işlem yapılmamıştır.");
            }
            return businessLayerResult;
        }
    }
}
