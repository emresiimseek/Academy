using Academy.EntityFramework.Concrete;
using Academy.EntityFramework.Concrete.ComplexTypes;
using Academy.EntityFramework.Concrete.DTOs;
using Academy.EntityFramework.Messages;
using Acedemy.Business.Abstract;
using Acedemy.DataAccess.Abstract;
using Acedemy.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.Business.Concrete
{
    public class AttendanceManager : IAttendanceService
    {
        private IAttendanceDal _attendanceDal { get; set; }
        public AttendanceManager(IAttendanceDal attendanceDal)
        {
            _attendanceDal = attendanceDal;
        }
        public void Add(Attendance attendance)
        {

            _attendanceDal.Add(attendance);
        }

        public void Delete(Attendance attendance)
        {
            throw new NotImplementedException();
        }

        public Attendance Get(int id)
        {
            return _attendanceDal.Get(a => a.Id == id);
        }



        public List<Attendance> GetAll()
        {
            return _attendanceDal.GetAll();
        }

        public void Update(Attendance attendance)
        {
            throw new NotImplementedException();
        }

        public BusinessLayerResult<AttendanceModelDto> SaveAttendance(AttendanceModelDto attendanceModelDto)
        {
            BusinessLayerResult<AttendanceModelDto> result = new BusinessLayerResult<AttendanceModelDto>();
            Attendance attendance = new Attendance();
            attendance.CourseId = attendanceModelDto.CourseId;
            attendance.ModifiedOn = DateTime.Now;
            attendance.CreatedOn = attendanceModelDto.CreatedOn;
            foreach (int studentId in attendanceModelDto.Students)
            {
                attendance.StudentId = studentId;
                if (_attendanceDal.Get(a => a.CourseId == attendance.CourseId && a.StudentId == attendance.StudentId) != null)
                {
                    result.AddError(MessagesCodes.AlreadyExist, $"Kayıt daha önce zaten gerçekleştirilmiş.");
                    return result;
                }

                _attendanceDal.Add(attendance);

            }
            result.Result = attendanceModelDto;
            return result;

        }

        public List<AttendanceReport> GetAttendanceReport(ReportDto reportDto)
        {
            //List<Attendance> attendances= _attendanceDal.GetAll(a => a.CourseId == id && a.CreatedOn == reportDate);
            List<AttendanceReport> attendanceReports = _attendanceDal.GetAttendancesReport(reportDto);
            return attendanceReports;
        }

        public void DeleteStudentFromAttendance(Attendance attendance)
        {
            var res = _attendanceDal.Delete(attendance);
        }
    }
}
