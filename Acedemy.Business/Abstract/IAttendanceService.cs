using Academy.EntityFramework.Concrete;
using Academy.EntityFramework.Concrete.ComplexTypes;
using Academy.EntityFramework.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.Business.Abstract
{
    public interface IAttendanceService:IService<Attendance>
    {
        BusinessLayerResult<Attendance> SaveAttendance(Attendance attendances);
        Attendance CreateAttendance(Attendance attendances);
        List<AttendanceReport> GetAttendanceReport(ReportDto reportDto);
        void DeleteStudentFromAttendance(AttendanceDetail attendanceDetail);
        AttendanceDetail GetAttendanceDetail(int Id);
    }
}
