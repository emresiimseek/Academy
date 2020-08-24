using Acedemy.Mvc.UI.ApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Acedemy.Mvc.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController(AttendanceApiService attendanceApiService)
        {
        }
        // GET: Attendance
        public ActionResult Index()
        {
            return View();
        }

    } 
}
