using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmsMvc.Models.Entity;
using System.Web.Security;

namespace SmsMvc.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        SmsMVCEntities db = new SmsMVCEntities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Tbl_Teacher teacher)
        {
            var teacher_ = db.Tbl_Teacher.FirstOrDefault(x => x.TeacherNumber == teacher.TeacherNumber && x.TeacherPassword == teacher.TeacherPassword);
            if (teacher_ != null)
            {
                FormsAuthentication.SetAuthCookie(teacher_.TeacherFirstName, false);
                return RedirectToAction("Index", "Teacher");
            }

            else
            {
                ViewBag.message = "The Teacher Number or Teacher Password is incorrect.";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}