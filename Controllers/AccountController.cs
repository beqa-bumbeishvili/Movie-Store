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
        private Helper helper = new Helper();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            if (helper.EmailExistsInDatabase(email) && helper.PasswordExistsInDatabase(password))
            {
                return RedirectToAction("Index", "Movies");
            }
            ViewBag.Login = "unsuccessful";
            return RedirectToAction("Index", "Movies");
        }

        [HttpPost]
        public ActionResult Register(string name, string email, string password)
        {
            if (helper.IsValidEmail(email) && helper.IsValidPassword(password))
            {
                var user = new User();
                user.AccountEmail = email;
                user.AccountPassword = password;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            ViewBag.Registration = "unsuccessful";
            return RedirectToAction("Index","Movies");
        }
    }
}
