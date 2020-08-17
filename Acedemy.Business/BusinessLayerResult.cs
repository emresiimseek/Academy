using Academy.EntityFramework.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.Business
{
    public class BusinessLayerResult<T>where T:class
    {
        public T Result { get; set; }
        public List<MessagesObj> Error { get; set; }
        public BusinessLayerResult()
        {
            Error = new List<MessagesObj>();
        }
        public void AddError(MessagesCodes code, string Messsage)
        {
            Error.Add(new MessagesObj() { Code = code, Message = Messsage });
        }
    }

}
