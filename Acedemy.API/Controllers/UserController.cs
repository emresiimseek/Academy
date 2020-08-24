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
    public class UserController : ApiController
    {
        private IUserService _userService { get; set; }
        private IAutoMapperBase _autoMapperBase { get; set; }
        public UserController(IUserService userService, IAutoMapperBase autoMapperBase)
        {
            _userService = userService;
            _autoMapperBase = autoMapperBase;
        }


        // POST: api/User
        [HttpPost]
        public void Post([FromBody] InstructorDto ınstructorDto)
        {
            _userService.Add(_autoMapperBase.MapToSameType<InstructorDto, Instructor>(ınstructorDto));
        }


    }
}
