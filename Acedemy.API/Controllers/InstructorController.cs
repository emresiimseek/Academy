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
        public InstructorDto Get(int id)
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
            InstructorDto dto = _autoMapperBase.MapToSameType<Instructor, InstructorDto>(ınstructor);
            return dto;

        }

        // POST: api/Instructor
        [HttpPost]
        [Route("api/Instructor/")]
        public void Post([FromBody] InstructorDto ınstructorDto)
        {
            Instructor ınstructor = _autoMapperBase.MapToSameType<InstructorDto, Instructor>(ınstructorDto);
            _ınstructorService.Add(ınstructor);
        }

        [HttpPut]
        [Route("api/Instructor/{id}")]
        public void Put(int id, [FromBody] InstructorDto ınstructorDto)
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
        }



        [HttpPost]
        [Route("api/Instructor/Find")]
        public List<InstructorDto> FindByName([FromBody] string key)
        {
            return _autoMapperBase.MapToSameList<Instructor, InstructorDto>(_ınstructorService.FindByName(key));
        }
        [HttpGet]
        [Route("api/Instructor")]
        // GET: api/User
        public List<InstructorDto> GetAll()
        {
            List<Instructor> ınstructors = _ınstructorService.GetInstructorWithCourses();
            List<InstructorDto> ınstructorDtos = _autoMapperBase.MapToSameList<Instructor, InstructorDto>(ınstructors);
            return ınstructorDtos;
        }
        [HttpDelete]
        [Route("api/Instructor/{id}")]
        public void Delete(int id)
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
        }


    }
}
