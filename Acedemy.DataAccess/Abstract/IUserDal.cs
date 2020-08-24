using Academy.EntityFramework.Concrete;
using FrameworkCore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.DataAccess.Abstract
{
    public interface IUserDal:IRepository<Person>
    {
    }
}
