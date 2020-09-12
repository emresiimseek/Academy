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
    public class StudentDal : RepositoryBase<Student, AcedemyContext>, IStudentDal
    {
        AcedemyContext acedemyContext = new AcedemyContext();
        public List<Student> FindByName(string key)
        {
            return acedemyContext.Set<Person>().Include("Courses").OfType<Student>().Where(s => s.FirstName.Contains(key) || s.LastName.Contains(key)).ToList();
        }

        public List<Student> GetAllWithCourse()
        {

            return acedemyContext.Set<Person>().Include("Courses").OfType<Student>().ToList();
        }


    }
}
