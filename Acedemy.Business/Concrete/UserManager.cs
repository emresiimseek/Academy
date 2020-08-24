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
        public IUserDal _userDal { get; set; }

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
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
            throw new NotImplementedException();
        }

        public Instructor Get(Expression<Func<Instructor, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Instructor entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Instructor entity)
        {
            throw new NotImplementedException();
        }

        public void AddUser(Instructor ınstructor)
        {

        }
    }
}
