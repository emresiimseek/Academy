using Academy.EntityFramework.Concrete;
using Acedemy.Business.Abstract;
using Acedemy.DataAccess;
using Acedemy.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal { get; set; }
        private IValidateService _validateService { get; set; }

        public UserManager(IUserDal userDal, IValidateService validateService)
        {
            _userDal = userDal;
            _validateService = validateService;
        }

        public int Add(Instructor entity)
        {
            var _validateManager = new ValidateManager();
            entity.Password = _validateManager.Encrypt(entity.Password);
            entity.Birthdate = DateTime.Now;
            entity.HireDate = DateTime.Now;
            entity.Gender = 'f';
            return _userDal.Add(entity);
        }

        public List<Instructor> GetAll(Expression<Func<Instructor, bool>> filter = null)
        {
            return _userDal.GetAll(null);
        }

        public Instructor Get(Expression<Func<Instructor, bool>> filter)
        {
            return _userDal.Get(filter);
        }

        public void Update(Instructor entity)
        {
            _userDal.Update(entity);
        }

        public int Delete(Instructor entity)
        {
            return _userDal.Delete(entity);
        }

        public void AddUser(Instructor ınstructor)
        {
            _userDal.Add(ınstructor);
        }

        public List<Instructor> GetAllWithChilds()
        {
            return _userDal.GetAllWithChilds();
        }

        public Instructor GetByUsernamePassword(Instructor ınstructor)
        {
            ınstructor.Password = _validateService.Encrypt(ınstructor.Password);
            return _userDal.Get(u => u.UserName == ınstructor.UserName && u.Password == ınstructor.Password);
        }
    }
}
