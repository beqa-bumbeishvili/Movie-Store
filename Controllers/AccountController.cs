﻿using System;
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
        public ActionResult Login([Bind(Include = "AccountEmail,AccountPassword")] User user)
        {
            if (helper.EmailExistsInDatabase(user.AccountEmail) && helper.PasswordExistsInDatabase(user.AccountPassword))
            {
                return View("~/Views/Movies/Index.cshtml");
            }
            ViewBag.Login = "unsuccessful";
            return View("~/Views/Movies/Index.cshtml");
        }

        [HttpPost]
        public ActionResult Register([Bind(Include = "ID,AccountEmail,AccountPassword")] User user)
        {
            if (helper.IsValidEmail(user.AccountEmail) && helper.IsValidPassword(user.AccountPassword))
            {
                db.Users.Add(user);
                db.SaveChanges();
                return View("~/Views/Movies/Index.cshtml");
            }
            ViewBag.Registration = "unsuccessful";
            return RedirectToAction("Index","Movies");
        }
    }
}