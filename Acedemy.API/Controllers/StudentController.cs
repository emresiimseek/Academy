using Academy.EntityFramework.Concrete;
using Acedemy.API.Filters;
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
    [Authorize]
    [ValidationFilter]
    public class StudentController : ApiController
    {
        private IStudentService _studentService { get; set; }
        private IAutoMapperBase _autoMapperBase { get; set; }
        public StudentController(IStudentService studentService, IAutoMapperBase autoMapperBase)
        {
            _studentService = studentService;
            _autoMapperBase = autoMapperBase;
        }
        // GET: api/Student
        public IHttpActionResult GetAll()
        {
            List<Student> students = _studentService.GetStudentWithCourses();
            List<StudentDto> studentModels = _autoMapperBase.MapToSameList<Student, StudentDto>(students);
            return Ok(studentModels);
        }


        // POST: api/Student
        [HttpPost]
        public IHttpActionResult Post([FromBody] StudentDto studentModel)
        {
            _studentService.Add(_autoMapperBase.MapToSameType<StudentDto, Student>(studentModel));
            return Ok();
        }

        [HttpPut]
        [Route("api/Student/{id}")]
        public IHttpActionResult Put(int id, [FromBody] StudentDto studentDto)
        {
            Student student = _studentService.Get(id);
            if (student == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"{0} id'li öğrenci bulunamadı.", id)),
                    ReasonPhrase = "Instructor Not Found",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(response);
            }

            _studentService.Update(_autoMapperBase.MapToSameType<StudentDto, Student>(studentDto));
            return Ok();
        }


        [HttpPost]
        [Route("api/Student/Find")]
        public IHttpActionResult FindByName([FromBody] string key)
        {
            return Ok(_autoMapperBase.MapToSameList<Student, StudentDto>(_studentService.FindByName(key)));
        }

        [HttpDelete]
        [Route("api/Student/{id}")]
        public IHttpActionResult Delete(int id)
        {
            Student course = _studentService.Get(id);
            if (course == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"{0} id'li öğrenci bulunamadı.", id)),
                    ReasonPhrase = "Course Not Found",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(response);
            }
            _studentService.Delete(course);
            return Ok();
        }

        // GET: api/Student/5
        [HttpGet()]
        [Route("api/Student/{id}")]
        public IHttpActionResult Get(int id)
        {
            Student student = _studentService.Get(id);
            if (student == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"{0} id'li öğrenci bulunamadı.", id)),
                    ReasonPhrase = "Course Not Found",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(response);
            }

            StudentDto studentDto = _autoMapperBase.MapToSameType<Student, StudentDto>(student);
            return Ok(studentDto);

        }

    }
}
