﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acedemy.API.Models.Dto
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}