using Academy.EntityFramework.Concrete;
using FrameworkCore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.Business.Abstract
{
    public interface IUserService:IRepository<Instructor>
    {
        void AddUser(Instructor ınstructor);
    }
}
