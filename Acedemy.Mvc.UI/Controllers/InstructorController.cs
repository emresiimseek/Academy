using Acedemy.API.Models.Dto;
using Acedemy.Mvc.UI.ApiServices;
using FrameworkCore.CrossCuttingConcerns.Securtiy;
using FrameworkCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Acedemy.Mvc.UI.Controllers
{
    public class InstructorController : Controller
    {
        public static string ApiUrl { get; set; }

        private InstructorApiService _ınstructorApiService;
        public InstructorController(InstructorApiService ınstructorApiService)
        {
            ApiUrl = ConfigHelper.GetConfigPar<string>("ApiUrl");
            _ınstructorApiService = ınstructorApiService;
        }


        // GET: Instructor
        public async Task<ActionResult> Index()
        {
            List<InstructorDto> ınstructorDtos = await _ınstructorApiService.GetAllInstructor(ApiUrl + "api/Instructor/", Session["access_token"] as String);
            return View(ınstructorDtos);
        }

        [HttpPost]
        public async Task<PartialViewResult> FindByName(string key)
        {
            List<InstructorDto> ınstructorDtos = await _ınstructorApiService.FindByName(ApiUrl + "api/Instructor/Find", Session["access_token"] as String, key);
            return PartialView("_SearchInstructorPartial", ınstructorDtos);
        }
        [HttpGet]
        public async Task<PartialViewResult> UserProfile()
        {
            Identity ıdentity = (Identity)HttpContext.User.Identity;
            InstructorDto ınstructor = await _ınstructorApiService.Get(ApiUrl + "api/Instructor/" + ıdentity.Id, Session["access_token"] as String);
            return PartialView("_ProfilePartial", ınstructor);
        }
        [HttpPost]
        public async Task<JsonResult> EditProfile(InstructorDto ıns)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList() }, JsonRequestBehavior.AllowGet);
            }
            InstructorDto ınstructor = await _ınstructorApiService.Get(ApiUrl + "api/Instructor/" + ıns.Id, Session["access_token"] as String);
            ınstructor.FirstName = ıns.FirstName;
            ınstructor.LastName = ıns.LastName;
            ınstructor.UserName = ıns.UserName;
            ınstructor.Password = ıns.Password;
            Boolean res = await _ınstructorApiService.UpdateInstructor(ınstructor, ApiUrl + "api/Instructor/" + ıns.Id, Session["access_token"] as String);
            return Json(res);


        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(InstructorDto ınstructor)
        {
            if (ModelState.IsValid)
            {
                ViewBag.result = await _ınstructorApiService.AddInstructor(ınstructor, ApiUrl + "api/Instructor/", Session["access_token"] as String);
            }

            return View(ınstructor);
        }
        [HttpPost]
        public async Task DeleteInstructor(int id)
        {
            await _ınstructorApiService.DeleteInstructor(ApiUrl + "api/Instructor/" + id, Session["access_token"] as String);
        }

        public async Task<ActionResult> EditInstructor(int id)
        {
            InstructorDto ınstructor = await _ınstructorApiService.Get(ApiUrl + "api/Instructor/" + id, Session["access_token"] as String);
            return View(ınstructor);
        }
        [HttpPost]
        public async Task<ActionResult> EditInstructor(InstructorDto ıns)
        {
            if (ModelState.IsValid)
            {
                InstructorDto ınstructor = await _ınstructorApiService.Get(ApiUrl + "api/Instructor/" + ıns.Id, Session["access_token"] as String);
                ınstructor.FirstName = ıns.FirstName;
                ınstructor.LastName = ıns.LastName;
                ınstructor.UserName = ıns.UserName;
                ınstructor.Password = ıns.Password;
                Boolean res = await _ınstructorApiService.UpdateInstructor(ınstructor, ApiUrl + "api/Instructor/" + ıns.Id, Session["access_token"] as String);
                return RedirectToAction("Index", "Instructor");

            }

            return View(ıns);
        }


    }




}

