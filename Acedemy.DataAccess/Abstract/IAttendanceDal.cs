using Academy.EntityFramework.Concrete;
using Academy.EntityFramework.Concrete.ComplexTypes;
using Academy.EntityFramework.Concrete.DTOs;
using FrameworkCore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.DataAccess.Abstract
{
    public interface IAttendanceDal:IRepository<Attendance>
    {
        List<AttendanceReport> GetAttendancesReport(ReportDto reportDto);
    }
}
