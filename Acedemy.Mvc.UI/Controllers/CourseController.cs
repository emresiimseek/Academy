using Academy.EntityFramework.Concrete;
using Academy.EntityFramework.Messages;
using Acedemy.API.Models.Dto;
using Acedemy.Business;
using Acedemy.Mvc.UI.ApiService;
using Acedemy.Mvc.UI.ApiServices;
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

    public class CourseController : Controller
    {
        public static string ApiUrl { get; set; }
  
        private InstructorApiService _ınstructorApiService;
        private CourseApiService _courseApiService;
        private StudentApiService _studentApiService;
        private UserApiService _userApiService;
        public CourseController(CourseApiService courseApiService, StudentApiService studentApiService, UserApiService userApiService, InstructorApiService ınstructorApiService)
        {

            ApiUrl = ConfigHelper.GetConfigPar<string>("ApiUrl");
            _studentApiService = studentApiService;
            _courseApiService = courseApiService;
            _userApiService = userApiService;
            _ınstructorApiService = ınstructorApiService;
        }
        // GET: Courses
        public async Task<ActionResult> Index()

        {
            List<CourseDto> courseModels = await _courseApiService.GetAllAsync(ApiUrl + "api/Course/People", Session["access_token"] as String);
            return View(courseModels);
        }

        // GET: Courses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseDto courseModel = await _courseApiService.GetById(ApiUrl + "api/Course/" + id, Session["access_token"] as String);
            if (courseModel == null)
            {
                return HttpNotFound();
            }
            return View(courseModel);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CourseDto courseModel)
        {
            if (ModelState.IsValid)
            {
                await _courseApiService.Add(courseModel, ApiUrl + "api/Course/", Session["access_token"] as String);
                return RedirectToAction("Index");
            }

            return View(courseModel);
        }

        // GET: Courses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseDto courseModel = await _courseApiService.GetById(ApiUrl + "api/Course/" + id, Session["access_token"] as String);
            if (courseModel == null)
            {
                return HttpNotFound();
            }
            return View(courseModel);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Edit(CourseDto courseModel, int id)
        {
            if (ModelState.IsValid)
            {
                CourseDto coursemodel = await _courseApiService.UpdateCourseAsync(courseModel, ApiUrl + "api/Course/" + id, Session["access_token"] as String);
                return View(coursemodel);
            }
            return View(courseModel);
        }
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseDto courseDto = await _courseApiService.GetById(ApiUrl + "api/Course/" + id, Session["access_token"] as String);
            if (courseDto == null)
            {
                return HttpNotFound();
            }
            await _courseApiService.DeleteCourseAsync(ApiUrl + "api/Course/" + id, Session["access_token"] as String);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<PartialViewResult> GetAllStudent(int Id)
        {
            ModalPartialStudentModel<StudentDto> modal = new ModalPartialStudentModel<StudentDto>();
            modal.CourseDto = await _courseApiService.GetById(ApiUrl + "api/Course/" + Id, Session["access_token"] as String);
            modal.EntityModal = await _studentApiService.GetAllAsync(ApiUrl + "api/Student", Session["access_token"] as String);
            return PartialView("_ModalPartialAddStudent", modal);
        }
        [HttpPost]
        public async Task<PartialViewResult> GetAllInstructor(int Id)
        {
            ModalPartialStudentModel<InstructorDto> modal = new ModalPartialStudentModel<InstructorDto>();
            modal.CourseDto = await _courseApiService.GetById(ApiUrl + "api/Course/" + Id, Session["access_token"] as String);
            modal.EntityModal = await _ınstructorApiService.GetAllInstructor(ApiUrl + "api/Instructor", Session["access_token"] as String);
            return PartialView("_ModalPartialAddInstructor", modal);
        }



        [HttpPost]
        public async Task<PartialViewResult> FindByNameForAssignPartial()
        {
            List<StudentDto> studentDto = await _studentApiService.GetAllAsync(ApiUrl + "api/Student", Session["access_token"] as String);
            return PartialView("_SearchPartialForAssign", studentDto);
        }

        [HttpPost]
        public async Task<JsonResult> SaveStudentAssign(AssignModel assignModel)
        {
            BusinessLayerResult<AssignModel> result = await _courseApiService.AssignStudent(ApiUrl + "api/Course/AssignStudent", Session["access_token"] as String, assignModel);
            if (result.Error.Count == 0)
            {

                return Json(new { messages = new List<string> { "Başarılı!" } }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { messages = result.Error.Select(x => x.Message).ToList() }, JsonRequestBehavior.AllowGet);
            }

        }
        public async Task<JsonResult> SaveInstructorAssign(AssignModel assignModel)
        {
            BusinessLayerResult<AssignModel> result = await _courseApiService.AssignInstructor(ApiUrl + "api/Course/AssignInstructor", Session["access_token"] as String, assignModel);
            if (result.Error.Count == 0)
            {

                return Json(new { messages = new List<string> { "Başarılı!" } }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { messages = result.Error.Select(x => x.Message).ToList() }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
