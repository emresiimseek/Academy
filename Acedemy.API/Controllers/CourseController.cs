﻿using Academy.EntityFramework.Concrete;
using Acedemy.API.Filters;
using Acedemy.API.Models.Dto;
using Acedemy.Business.Abstract;
using Acedemy.DataAccess.Concrete;
using FrameworkCore.Utilities.Mappings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acedemy.API.Controllers
{
    [ValidationFilter]
    public class CourseController : ApiController
    {
        private ICourseService _courseService { get; set; }
        private IAutoMapperBase _autoMapperBase { get; set; }
        public CourseController(ICourseService courseService, IAutoMapperBase autoMapperBase)
        {
            _courseService = courseService;
            _autoMapperBase = autoMapperBase;
        }
        // GET: api/Test
        public List<CourseDto> GetAll()
        {
            InstructorCoursesDal ınstructorCourses = new InstructorCoursesDal();
            ınstructorCourses.Test();
            List<Course> courses = _courseService.GetAll();
            List<CourseDto> courseModels = _autoMapperBase.MapToSameList<Course, CourseDto>(courses);
            return courseModels;
        }
        [Route("api/Course/People")]
        public List<CourseDto> GetAllCourseWithInstructors()
        {
            List<Course> courses = _courseService.GetAllCourseWithChild();
            List<CourseDto> courseModels = _autoMapperBase.MapToSameList<Course, CourseDto>(courses);
            return courseModels;
        }

        // GET: api/Test/5
       
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

        // POST: api/Test
        public void Post([FromBody] CourseDto courseModel)
        {

            _courseService.Add(_autoMapperBase.MapToSameType<CourseDto, Course>(courseModel));
        }

        // PUT: api/Test/5
        public CourseDto Put(int id, [FromBody] CourseDto courseModel)
        {
            Course course = _courseService.Get(id);
            if (course == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"{0} id'li kurs bulunamadı.", id)),
                    ReasonPhrase = "Course Not Found",
                    StatusCode=HttpStatusCode.NotFound
                };
                throw new HttpResponseException(response);
            }
            courseModel.ModifiedOn = DateTime.Now;
            courseModel.CreatedOn = course.CreatedOn;
            _courseService.Update(_autoMapperBase.MapToSameType<CourseDto, Course>(courseModel));
            return courseModel;
        }

        // DELETE: api/Test/5
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
    }
}
