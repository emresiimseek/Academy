﻿using Academy.EntityFramework.Concrete;
using FrameworkCore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.DataAccess.Abstract
{
    public  interface IStudentDal:IRepository<Student>
    {
        List<Student> GetAllWithCourse();
        List<Student> FindByName(string key);
    }
}
