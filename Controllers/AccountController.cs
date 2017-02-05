using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieProject.Models;

namespace MovieProject.Controllers
{
    public class AccountController : Controller
    {
        private MovieDBModel db = new MovieDBModel();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password) {

            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string username, string email, string password)
        {
           

            return null;
        }
    }
}