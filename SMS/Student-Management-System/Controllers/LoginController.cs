﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Student_Management_System.Models;
namespace Student_Management_System.Controllers
{
    public class LoginController : Controller
    {
        StudentEntities db = new StudentEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user objchk)
        {
            var obj = db.users.Where(a => a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();
            if (obj != null)
            {
                Session["userID"] = obj.id.ToString();
                Session["UserName"] = obj.username.ToString();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}