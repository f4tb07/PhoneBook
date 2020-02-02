using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBookUI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

       // [HttpPost]
        //public IActionResult Register()
        //{
        //    return View();
        //}

    }
}