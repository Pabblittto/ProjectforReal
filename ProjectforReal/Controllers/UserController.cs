using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectforReal.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //site presenting all info about user
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Edit()
        {

            return View();
        }

    }
}