using Academy.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.Business.Abstract
{
    public interface IValidateService : IService<Instructor>
    {
        Task<Instructor> Authenticate(string username, string password);
        string Encrypt(string text);
        string Decrypt(string cipher);
    }
}
