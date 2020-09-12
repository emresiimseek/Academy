using Academy.EntityFramework.Concrete;
using FrameworkCore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.DataAccess.Abstract
{
    public interface IInstructorDal : IRepository<Instructor>
    {
        List<Instructor> GetAllWithCourse();
        List<Instructor> FindByName(string key);
    }
}
