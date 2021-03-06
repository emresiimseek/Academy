﻿using Academy.EntityFramework.Concrete;
using Acedemy.API.Models.Dto;
using Acedemy.Business.Abstract;
using Acedemy.Mvc.UI.ApiServices;
using Acedemy.Mvc.UI.Models;
using FrameworkCore.CrossCuttingConcerns.Securtiy;
using FrameworkCore.CrossCuttingConcerns.Securtiy.Web;
using FrameworkCore.Helpers;
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
        public static string ApiUrl { get; set; }
        LoginUserModel LoginUserModel = new LoginUserModel();
        private static LoginApiService _loginApiService;
        private static UserApiService _userApiService;

        private IAutoMapperBase _autoMapperBase { get; set; }
        public LoginController(LoginApiService loginApiService, IAutoMapperBase autoMapperBase, UserApiService userApiService)
        {
            ApiUrl = ConfigHelper.GetConfigPar<string>("ApiUrl");
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

                TokenContent rest = await _loginApiService.Authenticate(ApiUrl + "token", loginUserModel);
                if (rest.access_token != null)
                {

                    InstructorDto ınstructorDto = await _userApiService.Get(rest.access_token, ApiUrl+"api/User", loginUserModel);
                    string[] roles = new string[ınstructorDto.Roles.Count];
                    for (int i = 0; i < ınstructorDto.Roles.Count; i++)
                    {
                        ınstructorDto.Roles.ForEach(x => roles[i] = x.Name.ToString());
                    }


                    AuthenticationHelper.CreateAuthCookie(ınstructorDto.Id, ınstructorDto.UserName, DateTime.Now.AddDays(1), roles, false, ınstructorDto.FirstName, ınstructorDto.LastName);
                    //FormsAuthentication.SetAuthCookie(loginUserModel.Username, false);



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

            await _userApiService.Add(_autoMapperBase.MapToSameType<RegisterUserModel, InstructorDto>(registerUserModel), ApiUrl+"api/User");
            return View();
        }


    }
}
