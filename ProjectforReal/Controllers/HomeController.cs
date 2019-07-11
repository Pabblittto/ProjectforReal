using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectforReal.Models;

namespace ProjectforReal.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<BlogUserIdentity> signInManager;
        private readonly UserManager<BlogUserIdentity> userManager;
        public HomeController(SignInManager<BlogUserIdentity> signinmanager,UserManager<BlogUserIdentity> usermanager)
        {
            signInManager = signinmanager;
            userManager = usermanager;
        }
            
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login()
        {
            var ErrorList = new List<String>();
            var list = Request.Form;
            if (!(list.ContainsKey("Url") && list.ContainsKey("Password") && list.ContainsKey("Login")))// if one of this value is missing
            {
                
                ErrorList.Add("Problem with Logging occured");
                TempData["errors"] = ErrorList;
                return RedirectToAction("Index", "Home");
            }

            var result = await signInManager.PasswordSignInAsync(list["Login"], list["Password"], true,false);


            if (result.Succeeded)
            {
                return RedirectToAction(list["Url"]);
            }

            ErrorList.Add("Invalid Login Attemp");
            TempData["errors"] = ErrorList;
            return Redirect(list["Url"]);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
