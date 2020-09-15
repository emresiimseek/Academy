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
    [ValidationFilter]
    [Authorize]
    public class InstructorController : ApiController
    {

        private IAutoMapperBase _autoMapperBase { get; set; }
        private IInstructorService _ınstructorService { get; set; }
        public InstructorController(IInstructorService ınstructorService, IAutoMapperBase autoMapperBase)
        {
            _ınstructorService = ınstructorService;
            _autoMapperBase = autoMapperBase;
        }


        // GET: api/Instructor/5
        [HttpGet()]
        [Route("api/Instructor/{id}")]
        public IHttpActionResult Get(int id)
        {


            Instructor ınstructor = _ınstructorService.Get(id);
            if (ınstructor == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"{0} id'li eğitmen bulunamadı.", id)),
                    ReasonPhrase = "Course Not Found",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(response);
            }
            InstructorDto ınstructorDto = _autoMapperBase.MapToSameType<Instructor, InstructorDto>(ınstructor);
            return Ok(ınstructorDto);

        }

        // POST: api/Instructor
        [HttpPost]
        [Route("api/Instructor/")]
        public IHttpActionResult Post([FromBody] InstructorDto ınstructorDto)
        {
            Instructor ınstructor = _autoMapperBase.MapToSameType<InstructorDto, Instructor>(ınstructorDto);
            _ınstructorService.Add(ınstructor);
            return Ok();
        }

        [HttpPut]
        [Route("api/Instructor/{id}")]
        public IHttpActionResult Put(int id, [FromBody] InstructorDto ınstructorDto)
        {
            Instructor ınstructor = _ınstructorService.Get(id);
            if (ınstructor == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"{0} id'li eğitmen bulunamadı.", id)),
                    ReasonPhrase = "Instructor Not Found",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(response);
            }

            _ınstructorService.Update(_autoMapperBase.MapToSameType<InstructorDto, Instructor>(ınstructorDto));
            return Ok();
        }



        [HttpPost]
        [Route("api/Instructor/Find")]
        public IHttpActionResult FindByName([FromBody] string key)
        {
            return Ok(_autoMapperBase.MapToSameList<Instructor, InstructorDto>(_ınstructorService.FindByName(key)));
        }
        [HttpGet]
        [Route("api/Instructor")]
        // GET: api/User
        public IHttpActionResult GetAll()
        {
            List<Instructor> ınstructors = _ınstructorService.GetInstructorWithCourses();
            List<InstructorDto> ınstructorDtos = _autoMapperBase.MapToSameList<Instructor, InstructorDto>(ınstructors);
            return Ok(ınstructorDtos);
        }
        [HttpDelete]
        [Route("api/Instructor/{id}")]
        public IHttpActionResult Delete(int id)
        {
            Instructor course = _ınstructorService.Get(id);
            if (course == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"{0} id'li eğitmen bulunamadı.", id)),
                    ReasonPhrase = "Course Not Found",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(response);
            }
            _ınstructorService.Delete(course);
            return Ok();
        }


    }
}
