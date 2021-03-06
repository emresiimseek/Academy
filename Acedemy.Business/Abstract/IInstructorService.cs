﻿using Academy.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.Business.Abstract
{
    public interface IInstructorService : IService<Instructor>
    {
        List<Instructor> GetInstructorWithCourses();
        List<Instructor> FindByName(string key);

    }
}
