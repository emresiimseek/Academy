
using Academy.EntityFramework.Concrete;
using Acedemy.DataAccess.Abstract;
using FrameworkCore.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.DataAccess.Concrete
{
    public class UserDal : RepositoryBase<Instructor, AcedemyContext>, IUserDal
    {
        public List<Instructor> GetAllWithChilds()
        {
            using (AcedemyContext context = new AcedemyContext())
            {
                return context.Set<Person>().Include("Courses").OfType<Instructor>().ToList();
            }
        }
    }
}
