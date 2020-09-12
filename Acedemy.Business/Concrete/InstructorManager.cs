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
    public class InstructorManager : IInstructorService
    {
        public IInstructorDal _ınstructorDal { get; set; }
        private IValidateService _validateService { get; set; }
        public InstructorManager(IInstructorDal ınstructorDal, IValidateService validateService)
        {
            _ınstructorDal = ınstructorDal;
            _validateService = validateService;
        }
        public void Add(Instructor Entity)
        {
            Entity.Password = _validateService.Encrypt(Entity.Password);
            _ınstructorDal.Add(Entity);
        }

        public void Delete(Instructor Entity)
        {
            _ınstructorDal.Delete(Entity);
        }

        public List<Instructor> FindByName(string key)
        {
            return _ınstructorDal.FindByName(key);
        }

        public Instructor Get(int id)
        {
            return _ınstructorDal.Get(x => x.Id == id);
        }

        public List<Instructor> GetAll()
        {
            return _ınstructorDal.GetAll();
        }

        public List<Instructor> GetInstructorWithCourses()
        {
            return _ınstructorDal.GetAllWithCourse();
        }

        public void Update(Instructor Entity)
        {
            Instructor ınstructor = _ınstructorDal.Get(x => x.Id == Entity.Id);
            if (ınstructor.Password != Entity.Password)
            {
                Entity.Password = _validateService.Encrypt(Entity.Password);
            }
            _ınstructorDal.Update(Entity);
        }
    }
}
