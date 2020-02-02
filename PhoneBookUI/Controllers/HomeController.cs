using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TraningPhonebook.Contracts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBookUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactRepository contact;

        public HomeController(IContactRepository _contact)
        {
            contact = _contact;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //contact.Add(new TraningPhonebook.Core.Contact
            //{
            //    FirstName = "Amin",
            //    LastName = "Hassani",
            //    Note = "This is frist Contact",
               
            //}
            //    );
        
            return View();
        }
    }
}
