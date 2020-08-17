using Academy.EntityFramework.Concrete;
using Acedemy.Business.Abstract;
using Acedemy.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private IStudentDal _studentDal { get; set; }
        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }
        public List<Student> GetAll()
        {
            return _studentDal.GetAll();
        }

        public Student Get(int id)
        {
            return _studentDal.Get(c => c.Id == id);
        }

        public void Add(Student student)
        {
            _studentDal.Add(student);
        }

        public void Update(Student student)
        {
            _studentDal.Update(student);
        }

        public void Delete(Student student)
        {
            _studentDal.Delete(student);
        }
    }
}
