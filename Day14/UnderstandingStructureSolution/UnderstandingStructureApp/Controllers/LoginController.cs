using Microsoft.AspNetCore.Mvc;
using System.Net;
using UnderstandingStructureApp.Interfaces;
using UnderstandingStructureApp.Models;
using UnderstandingStructureApp.Services;

namespace UnderstandingStructureApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserLogin(User user)
        {
            try
            {
                if (_loginService.Login(user.Username, user.Password))
                {
                   HttpContext.Session.SetString("username", user.Username);
                    return RedirectToAction("Index", "Pizza");
                }
                ViewBag.Message = "Unable to login";
                return View();
            }
            catch (Exception e)
            {

                ViewBag.Message = e.Message;
                return View();
            }
            
        }
    }
}
