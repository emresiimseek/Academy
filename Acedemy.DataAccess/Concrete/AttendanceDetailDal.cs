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
    public class AttendanceDetailDal:RepositoryBase<AttendanceDetail,AcedemyContext>,IAttendanceDetailDal
    {

    }
}
