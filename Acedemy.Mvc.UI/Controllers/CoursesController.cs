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
            List<CourseDto> courseModels = await _courseApiService.GetAllAsync("https://localhost:44397/api/Course/People");
            return View(courseModels);
        }

        // GET: Courses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseDto courseModel = await _courseApiService.GetById("https://localhost:44397/api/Course/" + id);
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
                await _courseApiService.Add(courseModel, "https://localhost:44397/api/Course/");
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
            CourseDto courseModel = await _courseApiService.GetById("https://localhost:44397/api/Course/" + id);
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
                CourseDto coursemodel = await _courseApiService.UpdateCourseAsync(courseModel, "https://localhost:44397/api/Course/" + id);
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
            CourseDto courseDto = await _courseApiService.GetById("https://localhost:44397/api/Course/" + id);
            if (courseDto == null)
            {
                return HttpNotFound();
            }
            await _courseApiService.DeleteCourseAsync("https://localhost:44397/api/Course/" + id);
            return RedirectToAction("Index");
        }
    }
}
