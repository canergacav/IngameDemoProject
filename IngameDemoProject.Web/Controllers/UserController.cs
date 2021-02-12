using IngameDemo.Core.DTOs;
using IngameDemo.Core.Models;
using IngameDemoProject.Web.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IngameDemoProject.Web.Controllers
{
    public class UserController : Controller
    {

        public UserController()
        {
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginProc(LoginInput loginInput)
        {
            var result = RequestHelper.PostRequest<string>($"http://localhost:5000/User/Login", loginInput);
            if(result != null)
            {
                HttpContext.Session.SetString("Token", result);
                HttpContext.Session.SetString("Email", loginInput.Email);
            }
            return Json(result);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult RegisterProc(UserInput userInput)
        {
            var result = RequestHelper.PostRequest<User>($"http://localhost:5000/User/Register", userInput);
            return Json(result);
        }

        public IActionResult Logout()
        {

            HttpContext.Session.Remove("Token");
            HttpContext.Session.Remove("Email");
            return RedirectToAction("Login");

        }
    }
}
