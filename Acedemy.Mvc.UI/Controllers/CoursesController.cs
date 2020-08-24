using Acedemy.API.Models.Dto;
using Acedemy.Mvc.UI.ApiService;
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

    public class CoursesController : Controller
    {
        private CourseApiService _courseApiService;
        public CoursesController(CourseApiService courseApiService)
        {
            _courseApiService = courseApiService;
        }
        // GET: Courses
        public async Task<ActionResult> Index()
        
        {
            List<CourseDto> courseModels = await _courseApiService.GetAllAsync("http://academy.emresimsek.info/api/Course/People", Session["access_token"] as String);
            return View(courseModels);
        }

        // GET: Courses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseDto courseModel = await _courseApiService.GetById("http://academy.emresimsek.info/api/Course/" + id, Session["access_token"] as String);
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
                await _courseApiService.Add(courseModel, "http://academy.emresimsek.info/api/Course/", Session["access_token"] as String);
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
            CourseDto courseModel = await _courseApiService.GetById("http://academy.emresimsek.info/api/Course/" + id, Session["access_token"] as String);
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
        public async Task<ActionResult> Edit(CourseDto courseModel,int id)
        {
            if (ModelState.IsValid)
            {
                CourseDto coursemodel = await _courseApiService.UpdateCourseAsync(courseModel, "http://academy.emresimsek.info/api/Course/" + id, Session["access_token"] as String);
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
            CourseDto courseDto = await _courseApiService.GetById("http://academy.emresimsek.info/api/Course/" + id, Session["access_token"] as String);
            if (courseDto == null)
            {
                return HttpNotFound();
            }
            await _courseApiService.DeleteCourseAsync("http://academy.emresimsek.info/api/Course/" + id, Session["access_token"] as String);
            return RedirectToAction("Index");
        }
    }
}
