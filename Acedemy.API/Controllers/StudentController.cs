using Academy.EntityFramework.Concrete;
using Acedemy.API.Models.Dto;
using Acedemy.Business.Abstract;
using FrameworkCore.Utilities.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acedemy.API.Controllers
{
    public class StudentController : ApiController
    {
        private IStudentService _studentService { get; set; }
        private IAutoMapperBase _autoMapperBase { get; set; }
        public StudentController(IStudentService studentService, IAutoMapperBase autoMapperBase)
        {
            _studentService = studentService;
            _autoMapperBase = autoMapperBase;
        }
        // GET: api/Test
        public List<StudentDto> GetAll()
        {
            List<Student> students = _studentService.GetAll();
            List<StudentDto> studentModels = _autoMapperBase.MapToSameList<Student, StudentDto>(students);
            return studentModels;
        }

        // GET: api/Test/5
        public StudentDto Get(int id)
        {
            Student student = _studentService.Get(id);
            return _autoMapperBase.MapToSameType<Student, StudentDto>(student);
        }
        

        // POST: api/Test
        public void Post([System.Web.Http.FromBody] StudentDto studentModel)
        {

            _studentService.Add(_autoMapperBase.MapToSameType<StudentDto, Student>(studentModel));
        }

        // PUT: api/Test/5
        public StudentDto Put(int id, [System.Web.Http.FromBody]StudentDto studentModel)
        {
            Student student = _studentService.Get(id);
            if (student == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"{0} id'li kurs bulunamadı.", id)),
                    ReasonPhrase = "Course Not Found"
                };
                throw new HttpResponseException(response);
            }
            studentModel.ModifiedOn = DateTime.Now;
            studentModel.CreatedOn = student.CreatedOn;
            _studentService.Update(_autoMapperBase.MapToSameType<StudentDto, Student>(studentModel));
            return studentModel;
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
            Student student = _studentService.Get(id);
            _studentService.Delete(student);
        }
    }
}
