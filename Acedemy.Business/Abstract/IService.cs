using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.Business.Abstract
{
    public interface IService<T>
        where T:new()
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
