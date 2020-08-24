using Academy.EntityFramework.Concrete;
using Acedemy.API.Models.Dto;
using Acedemy.Business.Abstract;
using Acedemy.Mvc.UI.ApiServices;
using Acedemy.Mvc.UI.Models;
using FrameworkCore.Utilities.Mappings;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Acedemy.Mvc.UI.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        LoginUserModel LoginUserModel = new LoginUserModel();
        private static LoginApiService _loginApiService;
        private static UserApiService _userApiService;

        private IAutoMapperBase _autoMapperBase { get; set; }
        public LoginController(LoginApiService loginApiService, IAutoMapperBase autoMapperBase, UserApiService userApiService)
        {
            _loginApiService = loginApiService;
            _autoMapperBase = autoMapperBase;
            _userApiService = userApiService;
        }

        // GET: Login
        [AllowAnonymous]
        public ActionResult LoginPage()
        {
            return View(LoginUserModel);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> LoginPage(LoginUserModel loginUserModel)
        {
            if (ModelState.IsValid)
            {

                TokenContent rest = await _loginApiService.Authenticate("http://academy.emresimsek.info/token", loginUserModel);
                if (rest.access_token != null)
                {
                    FormsAuthentication.SetAuthCookie(loginUserModel.Username, false);
                    Session["access_token"] = rest.access_token;
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.LoginError = "Kullanıcı Adı ve paralo uyuşmamaktadır!";

            }

            return View(loginUserModel);
        }

        public ActionResult SignOut()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginPage", "Login");
        }
        [AllowAnonymous]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost, AllowAnonymous]
        public async Task<ActionResult> Register(RegisterUserModel registerUserModel)
        {

            await _userApiService.Add(_autoMapperBase.MapToSameType<RegisterUserModel, InstructorDto>(registerUserModel), "http://academy.emresimsek.info/api/User");
            return View();
        }


    }
}
