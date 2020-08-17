﻿using Academy.EntityFramework.Concrete;
using Academy.EntityFramework.Concrete.ComplexTypes;
using Academy.EntityFramework.Concrete.DTOs;
using Acedemy.API.Filters;
using Acedemy.API.Models.Dto;
using Acedemy.Business;
using Acedemy.Business.Abstract;
using FrameworkCore.Utilities.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acedemy.API.Controllers
{
    [ValidationFilter]
    public class AttendanceController : ApiController
    {
        private IAttendanceService _attendanceService { get; set; }
        private IAutoMapperBase _autoMapperBase { get; set; }
        public AttendanceController(IAttendanceService attendanceService, IAutoMapperBase autoMapperBase)
        {
            _autoMapperBase = autoMapperBase;
            _attendanceService = attendanceService;
        }
        // POST: api/Attendance/Report
        [Route("api/Attendance/Report")]
        [HttpPost]
        public List<AttendanceReport> GetAttendanceReport([FromBody] ReportDto reportDto)
        {
            List<AttendanceReport> attendanceReports = _attendanceService.GetAttendanceReport(reportDto);
            return attendanceReports;

        }
        // DELETE: api/Attendance/5
        public void Delete(int id)
        {
            Attendance attendance = new Attendance();
            attendance= _attendanceService.Get(id);
            if (attendance == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"{0} id'li öğrenci bulunamadı.", id)),
                    ReasonPhrase = "Course Not Found",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(response);
            }
            _attendanceService.DeleteStudentFromAttendance(attendance);
        }


        // POST: api/Attendance
        public BusinessLayerResult<AttendanceModelDto> Post(AttendanceModelDto attendanceModelDto)
        {
            BusinessLayerResult<AttendanceModelDto> result = _attendanceService.SaveAttendance(attendanceModelDto);
            return result;
        }


        // PUT: api/Attendance/5
        public void Put(int id, [FromBody] string value)
        {

        }
        // GET: api/Attendance/5
        public string Get(int id)
        {
            return "value";
        }


    }
}