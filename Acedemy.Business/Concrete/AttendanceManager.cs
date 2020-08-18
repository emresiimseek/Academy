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
        private IAttendanceDetailDal _AttendanceDetailDal { get; set; }
        public AttendanceManager(IAttendanceDal attendanceDal, IAttendanceDetailDal AttendanceDetailDal)
        {
            _attendanceDal = attendanceDal;
            _AttendanceDetailDal = AttendanceDetailDal;
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
            return null;
        }



        public List<Attendance> GetAll()
        {
            return _attendanceDal.GetAll();
        }

        public void Update(Attendance attendance)
        {
            throw new NotImplementedException();
        }
        public Attendance CreateAttendance(Attendance attendances)
        {
            attendances.AttendanceDetails = null;
            _attendanceDal.Add(attendances);
            attendances= _attendanceDal.Get(x => x.CourseId == attendances.CourseId && attendances.CreatedOn == attendances.CreatedOn);
            return attendances;
        }

        public BusinessLayerResult<Attendance> SaveAttendance(Attendance attendances)
        {
            BusinessLayerResult<Attendance> res = new BusinessLayerResult<Attendance>();
            res.Result = attendances;
            if (_attendanceDal.Get(x=>x.CourseId==attendances.CourseId&&x.CreatedOn==attendances.CreatedOn)!=null)
            {
                res.AddError(MessagesCodes.AlreadyExist, $"{attendances.CreatedOn} tarihli yoklama zaten yapılmış.");
                return res;
            }
            _attendanceDal.Add(attendances);
            AttendanceDetail attendanceDetail = new AttendanceDetail { Attendance=attendances};
            return res;

        }


        public List<AttendanceReport> GetAttendanceReport(ReportDto reportDto)
        {
            //List<Attendance> attendances= _attendanceDal.GetAll(a => a.CourseId == id && a.CreatedOn == reportDate);
            List<AttendanceReport> attendanceReports = _attendanceDal.GetAttendancesReport(reportDto);
            return attendanceReports;
        }

        public void DeleteStudentFromAttendance(AttendanceDetail attendanceDetail)
        {
            var res = _AttendanceDetailDal.Delete(attendanceDetail);
        }

        public AttendanceDetail GetAttendanceDetail(int Id)
        {
            return _AttendanceDetailDal.Get(ad => ad.AttendanceDetailId == Id);
        }
    }
}
