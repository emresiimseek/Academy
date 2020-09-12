using Academy.EntityFramework.Concrete;
using Academy.EntityFramework.Concrete.DTOs;
using Acedemy.API.Filters;
using Acedemy.API.Models.Dto;
using Acedemy.Business;
using Acedemy.Business.Abstract;
using Acedemy.DataAccess;
using Acedemy.DataAccess.Concrete;
using FrameworkCore.Utilities.Mappings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Acedemy.API.Controllers
{
    [ValidationFilter]
    [Authorize]
    public class CourseController : ApiController
    {
        private ICourseService _courseService { get; set; }
        private IAutoMapperBase _autoMapperBase { get; set; }
        public CourseController(ICourseService courseService, IAutoMapperBase autoMapperBase)
        {
            _courseService = courseService;
            _autoMapperBase = autoMapperBase;
        }
        // GET: api/Course
        [HttpGet]
        public List<CourseDto> GetAll()
        {

            List<Course> courses = _courseService.GetAllCourseWithChild();
            List<CourseDto> courseModels = _autoMapperBase.MapToSameList<Course, CourseDto>(courses);
            return courseModels;
        }
        [Route("api/Course/People")]
        [HttpGet]
        public List<CourseDto> GetAllCourseWithInstructors()
        {
            List<Course> courses = _courseService.GetAllCourseWithChild();
            List<CourseDto> courseModels = _autoMapperBase.MapToSameList<Course, CourseDto>(courses);
            return courseModels;
        }

        // GET: api/Course/5
        [HttpGet]
        [Route("api/Course/{id}")]
        public CourseDto Get(int id)
        {
            Course course = _courseService.Get(id);
            if (course == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"{0} id'li kurs bulunamadı.", id)),
                    ReasonPhrase = "Course Not Found",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(response);
            }
            course = _courseService.GetCourseWithChild(id);
            return _autoMapperBase.MapToSameType<Course, CourseDto>(course);
        }

        // POST: api/Course
        [HttpPost]
        public void Post([FromBody] CourseDto courseModel)
        {


            _courseService.Add(_autoMapperBase.MapToSameType<CourseDto, Course>(courseModel));
        }

        // PUT: api/Course/5
        [HttpPut]
        [Route("api/Course/{id}")]
        public CourseDto Put(int id, [FromBody] CourseDto courseModel)
        {
            Course course = _courseService.Get(id);
            if (course == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"{0} id'li kurs bulunamadı.", id)),
                    ReasonPhrase = "Course Not Found",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(response);
            }
            courseModel.ModifiedOn = DateTime.Now;
            courseModel.CreatedOn = course.CreatedOn;
            _courseService.Update(_autoMapperBase.MapToSameType<CourseDto, Course>(courseModel));
            return courseModel;
        }

        // DELETE: api/Course/5
        [HttpDelete]
        [Route("api/Course/{id}")]
        public void Delete(int id)
        {
            Course course = _courseService.Get(id);
            if (course == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"{0} id'li kurs bulunamadı.", id)),
                    ReasonPhrase = "Course Not Found",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(response);
            }
            _courseService.Delete(course);
        }
        [HttpPost]
        [Route("api/Course/AssignStudent")]
        public BusinessLayerResult<AssignDto> AssignStudentToCourse([FromBody] AssignDto assignDto)
        {
            return _courseService.AssignStudentToCourse(assignDto);
        }
        [HttpPost]
        [Route("api/Course/AssignInstructor")]
        public BusinessLayerResult<AssignDto> AssignInstructorToCourse([FromBody] AssignDto assignDto)
        {
            return _courseService.AssignInstructorToCourse(assignDto);
        }

        [Route("api/Course/values")]
        public IHttpActionResult GetValues()
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;

            var claims = claimsIdentity.Claims.Select(x => new { type = x.Type, value = x.Value });

            return Ok(claims);
        }

    }
}
