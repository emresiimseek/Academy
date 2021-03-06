﻿using Academy.EntityFramework.Concrete;
using Academy.EntityFramework.Concrete.ComplexTypes;
using Academy.EntityFramework.Concrete.DTOs;
using Academy.EntityFramework.Messages;
using Acedemy.API.Models.Dto;
using Acedemy.Business;
using Acedemy.Mvc.UI.ApiService;
using Acedemy.Mvc.UI.Models;
using FrameworkCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Acedemy.Mvc.UI.Controllers
{
    [Authorize]
    public class AttendancesController : Controller
    {
        public static string ApiUrl { get; set; }
        public static DateTime date { get; set; }
        private CourseApiService _courseApiService;
        private AttendanceApiService _attendanceApiService;
        public AttendancesController(CourseApiService courseApiService, AttendanceApiService attendanceApiService)
        {
            ApiUrl = ConfigHelper.GetConfigPar<string>("ApiUrl");
            _courseApiService = courseApiService;
            _attendanceApiService = attendanceApiService;
        }
        public async Task<ActionResult> TakeAttendance()
        {
            List<CourseDto> courseModels = await _courseApiService.GetAllAsync(ApiUrl + "api/Course/People", Session["access_token"] as String);
            List<CourseDto> courses = courseModels;
            return View(courses);
        }
        [HttpPost]
        public async Task<PartialViewResult> TakeAttendance(int Id)
        {
            CourseDto courseModel = await _courseApiService.GetById(ApiUrl + "api/Course/" + Id, Session["access_token"] as String);

            return PartialView("_CourseStudentsPartial", courseModel);
        }

        [HttpPost]
        public async Task<JsonResult> SaveAttendance(AttendanceModelDto veri)
        {
            if (ModelState.IsValid)
            {
                List<MessagesObj> messagesObjs = new List<MessagesObj>();
                AttendanceDto attendanceDto = new AttendanceDto();
                attendanceDto.CourseId = veri.CourseId;
                attendanceDto.CreatedOn = DateTime.ParseExact(veri.CreatedOn, "dd/MM/yyyy", null);
                attendanceDto.ModifiedOn = DateTime.Now;

                for (int i = 0; i < veri.students.Length; i++)
                {
                    AttendanceDetail attendanceDetail = new AttendanceDetail();
                    attendanceDetail.StudentId = veri.students[i];
                    attendanceDetail.CreatedOn = DateTime.Now;
                    attendanceDetail.ModifiedOn = DateTime.Now;
                    attendanceDto.AttendanceDetails.Add(attendanceDetail);
                }
                messagesObjs = await _attendanceApiService.Add(attendanceDto, ApiUrl + "api/Attendance", Session["access_token"] as String);
                if (messagesObjs.Count == 0)
                {
                    return Json(new { messages = new List<string> { "Kaydınız başarılı bir şekilde gerçekleştirilmiştir." } }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { messages = messagesObjs.Select(y => y.Message).ToList() }, JsonRequestBehavior.AllowGet);
            }
            //return Json(new { success = false, errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList() }, JsonRequestBehavior.AllowGet);
            var test = ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage)).ToList();
            return Json(new { messages = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList() }, JsonRequestBehavior.AllowGet);

        }

        public async Task<ActionResult> AttendanceReport()
        {
            List<CourseDto> courseDtos = await _courseApiService.GetAllAsync(ApiUrl + "api/Course/People", Session["access_token"] as String);
            return View(courseDtos);
        }
        [HttpPost]
        public async Task<PartialViewResult> AttendanceReport(ReportDto reportDto)
        {
            reportDto.ReportDate = DateTime.ParseExact(reportDto.ReportDateAsString, "dd/MM/yyyy", null);
            List<AttendanceReport> attendanceReports = await _attendanceApiService.GetAttendanceReport(reportDto, ApiUrl + "api/Attendance/Report", Session["access_token"] as String);
            return PartialView("_ShowReportPartial", attendanceReports);
        }

        [HttpPost]
        public async Task<HttpStatusCode> DeleteFromAttendance(int Id)
        {
            HttpStatusCode httpStatusCode = await _attendanceApiService.Delete(ApiUrl + "api/Attendance/" + Id, Session["access_token"] as String);
            return httpStatusCode;
        }
        [HttpPost]
        public async Task<PartialViewResult> CreateChart(ReportDto reportDto)
        {
            reportDto.ReportDate = DateTime.ParseExact(reportDto.ReportDateAsString, "dd/MM/yyyy", null);
            CourseDto courseDto = await _courseApiService.GetById(ApiUrl + "api/Course/" + reportDto.CourseId, Session["access_token"] as String);
            ChartModel chartModel = new ChartModel();
            chartModel.totalSudent = courseDto.Students.Count();
            List<AttendanceReport> attendanceReports = await _attendanceApiService.GetAttendanceReport(reportDto, ApiUrl + "api/Attendance/Report", Session["access_token"] as String);
            chartModel.totalParticipant = attendanceReports.Count();
            TempData[$"chart{reportDto.CourseId}"] = chartModel;
            chartModel.CourseId = reportDto.CourseId;
            ViewBag.chartmodel = chartModel;
            return PartialView("_ModelPartial", chartModel);
        }

        public async Task<ActionResult> ShowChart(int id)
        {
            ChartModel chartModel = new ChartModel();
            if (TempData[$"chart{id}"] != null)
            {
                chartModel = TempData[$"chart{id}"] as ChartModel;
                TempData.Remove($"chart{id}");
            }
            return View(chartModel);
        }

    }
}