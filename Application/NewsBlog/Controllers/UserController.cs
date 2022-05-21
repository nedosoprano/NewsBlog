using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using NewsBlogBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NewsBlog.Controllers
{
    public class UserController : Controller
    {
        private static IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            if(!User.Identity.IsAuthenticated)
                return View();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<ActionResult> Login(string name, string password)
        {
            var userIdentity = await _userService.LoginAsync(name, password);

            if (userIdentity == null) 
                return View((object)"LogIn failed!");

            var authentificationManager = HttpContext.GetOwinContext().Authentication;
            authentificationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(string name, string password)
        {
            var result = await _userService.CreateAsync(name, password);

            if (!result)
                return View((object)"SignUp failed!");

            await _userService.LoginAsync(name, password);
            return RedirectToAction("Index", "Home");
           
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                var authentificationManager = HttpContext.GetOwinContext().Authentication;
                authentificationManager.SignOut();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}