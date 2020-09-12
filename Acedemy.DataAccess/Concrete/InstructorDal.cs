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
    public class InstructorDal : RepositoryBase<Instructor, AcedemyContext>, IInstructorDal
    {
        AcedemyContext acedemyContext = new AcedemyContext();
        public List<Instructor> FindByName(string key)
        {
            return acedemyContext.Set<Person>().Include("Courses").OfType<Instructor>().Where(s => s.FirstName.Contains(key) || s.LastName.Contains(key)).ToList();
        }

        public List<Instructor> GetAllWithCourse()
        {

            return acedemyContext.Set<Person>().Include("Courses").OfType<Instructor>().ToList();
        }


    }
}
