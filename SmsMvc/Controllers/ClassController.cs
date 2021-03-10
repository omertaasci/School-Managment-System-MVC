using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmsMvc.Models.Entity;

namespace SmsMvc.Controllers
{
    public class ClassController : Controller
    {
        SmsMVCEntities db = new SmsMVCEntities();
        public ActionResult Index()
        {
            var classList = db.Tbl_Class.ToList();
            return View(classList);
        }

        [HttpGet]
        public ActionResult NewClass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewClass(Tbl_Class class_)
        {
            db.Tbl_Class.Add(class_);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetClass(int id)
        {
            var getClass = db.Tbl_Class.Find(id);
            return View("GetClass", getClass);
        }

        public ActionResult UpdateClass(Tbl_Class class_)
        {
            var val = db.Tbl_Class.Find(class_.ClassId);
            val.ClassName = class_.ClassName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClass(int id)
        {
            var class_ = db.Tbl_Class.Find(id);
            db.Tbl_Class.Remove(class_);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}