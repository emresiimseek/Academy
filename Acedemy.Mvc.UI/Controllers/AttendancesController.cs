using Academy.EntityFramework.Concrete;
using Academy.EntityFramework.Concrete.ComplexTypes;
using Academy.EntityFramework.Concrete.DTOs;
using Academy.EntityFramework.Messages;
using Acedemy.API.Models.Dto;
using Acedemy.Business;
using Acedemy.Mvc.UI.ApiService;
using Acedemy.Mvc.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Acedemy.Mvc.UI.Controllers
{
    public class AttendancesController : Controller
    {
        private CourseApiService _courseApiService;
        private AttendanceApiService _attendanceApiService;
        public AttendancesController(CourseApiService courseApiService, AttendanceApiService attendanceApiService)
        {
            _courseApiService = courseApiService;
            _attendanceApiService = attendanceApiService;
        }
        public async Task<ActionResult> TakeAttendance()
        {
            List<CourseDto> courseModels = await _courseApiService.GetAllAsync("https://localhost:44397/api/Course/People");
            List<CourseDto> courses = courseModels;
            return View(courses);
        }
        [HttpPost]
        public async Task<PartialViewResult> TakeAttendance(int Id)
        {
            CourseDto courseModel = await _courseApiService.GetById("https://localhost:44397/api/Course/" + Id);
            return PartialView("_CourseStudentsPartial", courseModel);
        }

        [HttpPost]
        public async Task<JsonResult> SaveAttendance(AttendanceModelDto veri)
        {
            BusinessLayerResult<AttendanceModelDto> result = new BusinessLayerResult<AttendanceModelDto>();
            result = await _attendanceApiService.Add(veri, "https://localhost:44397/api/Attendance");
            List<string> res = new List<string>();
            MessagesObj messages = new MessagesObj();
            if (result.Error.Count > 0)
            {
                messages = result.Error.FirstOrDefault();
                return Json(messages, JsonRequestBehavior.AllowGet);
            }
            messages.Message = "Başarılı!";
            return Json(messages, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> AttendanceReport()
        {
            List<CourseDto> courseDtos = await _courseApiService.GetAllAsync("https://localhost:44397/api/Course/People");
           

            return View(courseDtos);
        }
        [HttpPost]
        public async Task<PartialViewResult> AttendanceReport(ReportDto reportDto)
        {
            List<AttendanceReport> attendanceReports = await _attendanceApiService.GetAttendanceReport(reportDto, "https://localhost:44397/api/Attendance/Report");

            return PartialView("_ShowReportPartial", attendanceReports);
        }

        [HttpPost]
        public async Task<HttpStatusCode> DeleteFromAttendance(int Id)
        {
            HttpStatusCode httpStatusCode = await _attendanceApiService.Delete("https://localhost:44397/api/Attendance/" + Id);
            return httpStatusCode;
        }
        [HttpPost]
        public async Task<PartialViewResult> CreateChart(ReportDto reportDto)
        {
            CourseDto courseDto = await _courseApiService.GetById("https://localhost:44397/api/Course/" + reportDto.CourseId);
            ChartModel chartModel = new ChartModel();
            chartModel.totalSudent = courseDto.Students.Count();
            List<AttendanceReport> attendanceReports = await _attendanceApiService.GetAttendanceReport(reportDto, "https://localhost:44397/api/Attendance/Report");
            chartModel.totalParticipant= attendanceReports.Count();
            TempData[$"chart{reportDto.CourseId}"] = chartModel;
            chartModel.CourseId = reportDto.CourseId;
            ViewBag.chartmodel = chartModel;
            return PartialView("_ModelPartial", chartModel);
        }

        public async Task<ActionResult> ShowChart(int id)
        {
            ChartModel chartModel = new ChartModel();
            if (TempData[$"chart{id}"]!= null)
            {
                chartModel= TempData[$"chart{id}"] as ChartModel;
            }
            return View(chartModel);
        }

    }
}