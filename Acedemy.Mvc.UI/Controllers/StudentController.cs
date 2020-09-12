using Acedemy.API.Models.Dto;
using Acedemy.Mvc.UI.ApiService;
using FrameworkCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Acedemy.Mvc.UI.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        public static string ApiUrl { get; set; }
        private StudentApiService _apiService;
        public StudentController(StudentApiService apiService)
        {
            ApiUrl = ConfigHelper.GetConfigPar<string>("ApiUrl");
            _apiService = apiService;
        }


        // GET: Student
        public async Task<ActionResult> Index()
        {
            List<StudentDto> studentDto = await _apiService.GetAllAsync(ApiUrl+"api/Student", Session["access_token"] as String);
            return View(studentDto);
        }
        [HttpPost]
        public async Task<PartialViewResult> FindByName(string key)
        {
            List<StudentDto> studentDtos = await _apiService.FindByName(ApiUrl + "api/Student/Find", Session["access_token"] as String, key);
            return PartialView("_SearchStudenPartial", studentDtos);
        }

        [HttpPost]
        public async Task<PartialViewResult> FindByNameForAssign(string key)
        {
            List<StudentDto> studentDtos = await _apiService.FindByName(ApiUrl + "api/Student/Find", Session["access_token"] as String, key);
            return PartialView("_SearchPartialForAssign", studentDtos);
        }

        // GET: Student/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }
        // POST: Student/Create
        [HttpPost]
        public async Task<ActionResult> Create(StudentDto studentDto)
        {
            if (ModelState.IsValid)
            {
                Boolean result = await _apiService.AddStudent(studentDto, ApiUrl + "api/Student", Session["access_token"] as String);
                ViewBag.result = result;
            }
           
            return View(studentDto);
        }
        [HttpPost]
        public async Task DeleteStudent(int id)
        {
            await _apiService.DeleteStudent(ApiUrl + "api/Student/" + id, Session["access_token"] as String);
        }

        public async Task<ActionResult> EditStudent(int id)
        {
            StudentDto ınstructor = await _apiService.Get(ApiUrl + "api/Student/" + id, Session["access_token"] as String);
            return View(ınstructor);
        }
        [HttpPost]
        public async Task<ActionResult> EditStudent(StudentDto stu)
        {
            if (ModelState.IsValid)
            {
                StudentDto student = await _apiService.Get(ApiUrl + "api/Student/" + stu.Id, Session["access_token"] as String);
                student.FirstName = stu.FirstName;
                student.LastName = stu.LastName;
                student.EnrollmentDate = stu.EnrollmentDate;
                student.Birthdate = stu.Birthdate;
                Boolean res = await _apiService.UpdateStudent(student, ApiUrl + "api/Student/" + stu.Id, Session["access_token"] as String);
                return RedirectToAction("Index", "Student");
            }
            return View(stu);
           


        }


    }
}
