using Academy.EntityFramework.Concrete;
using Academy.EntityFramework.Concrete.ComplexTypes;
using Academy.EntityFramework.Concrete.DTOs;
using Acedemy.DataAccess.Abstract;
using FrameworkCore.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.DataAccess.Concrete
{
    public class AttendanceDal : RepositoryBase<Attendance, AcedemyContext>, IAttendanceDal
    {
        public List<AttendanceReport> GetAttendancesReport(ReportDto reportDto)
        {
            AcedemyContext context = new AcedemyContext();
            var result = from a in context.Attendances
                         join c in context.Courses on a.CourseId equals c.CourseId
                         join s in context.Students on a.StudentId equals s.Id
                         where a.CourseId==reportDto.CourseId && a.CreatedOn==reportDto.ReportDate
                         
                         select new AttendanceReport
                         {
                             AttendanceId=a.Id,
                             CourseId = c.CourseId,
                             CourseName = c.Title,
                             StudentFullName = s.FirstName + s.LastName,
                             CreatedOn=a.CreatedOn
                         };
            
            return result.ToList();

        }

    }
}
