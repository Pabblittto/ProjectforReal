using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProjectforReal.Models;
using ProjectforReal.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace ProjectforReal.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<BlogUserIdentity> signInManager;
        private readonly UserManager<BlogUserIdentity> userManager;
        private readonly Models.AppContext appContext;

        public HomeController(SignInManager<BlogUserIdentity> signinmanager,UserManager<BlogUserIdentity> usermanager,Models.AppContext MyContext)
        {
            signInManager = signinmanager;
            userManager = usermanager;
            appContext = MyContext;
        }
            
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
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

            var result = await signInManager.PasswordSignInAsync(list["Login"].ToString(), list["Password"].ToString(), true,false);


            if (result.Succeeded)
            {
                var InfoList = new List<String>()
                {
                    "Login successed :)"
                };

                TempData["info"] = InfoList;
                return Redirect(list["Url"]);
            }

            ErrorList.Add("Invalid Login Attemp");
            TempData["errors"] = ErrorList;
            return Redirect(list["Url"]);
        }


        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)// if model is valid- register User
            {
                var InfoList = new List<string>();


                var MyUser = new BlogUserIdentity()
                {
                    UserName = model.Login,
                    Email=model.Email,
                };



                var identityResult = userManager.PasswordValidators.First().ValidateAsync(userManager,MyUser,model.Password);

                if (identityResult.Result.Succeeded)// password is ok- create user
                {

                    if (model.CreateBlog)// if user want ot create own blog
                    {
                        var BlogObj = new Blog()
                        {
                            BlogName = model.BlogName,
                            DateOfCreated = DateTime.Now.Date,
                            Description = model.Description
                        };

                        BlogObj.BlogUserIdentity = MyUser;
                        appContext.Add(BlogObj);
                        //appContext.SaveChanges();

                        //MyUser.Blog = BlogObj;
                        
                    }

                    InfoList.Add("Account created :)");

                    TempData["info"] = InfoList;

                    await userManager.CreateAsync(MyUser,model.Password);// registration successfull
                    await appContext.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in identityResult.Result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }
            }
            
            return View(model);
        }

        [HttpGet]
        public IActionResult Info(string message)// action for critical events- it redirect to index/home and display info
        {
            var Message = message.Replace('+', ' ');
            TempData["info"] = new List<string>
            {
                Message
            };
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return View();
            
        }

        [HttpGet]
        public IActionResult LogIn(string ReturnUrl)
        {
            var LoginForm = new LoginViewModel()
            {
                ReturnUrl = ReturnUrl
            };

            return Redirect(ReturnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)// if model is valid- log in user
            {
                var Loginresult = await signInManager.PasswordSignInAsync(model.Login, model.Password,true,false);

                if (Loginresult.Succeeded)// user log in succeded
                {

                }

            }

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
