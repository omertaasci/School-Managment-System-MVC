using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmsMvc.Models.Entity;
using System.Data.Entity;

namespace SmsMvc.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        SmsMVCEntities db = new SmsMVCEntities();

        public ActionResult Index()
        {
            var list = db.Tbl_Student.Include(c => c.Tbl_Club).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult NewStudent()
        {
            List<SelectListItem> studentClubDropDown = (from i in db.Tbl_Club.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = i.ClubName,
                                                            Value = i.ClubId.ToString()
                                                        }).ToList();
            ViewBag.studentClubDropDown_ViewBag = studentClubDropDown;
            return View();
        }

        [HttpPost]
        public ActionResult NewStudent(Tbl_Student student)
        {
            var club = db.Tbl_Club.Where(m => m.ClubId == student.Tbl_Club.ClubId).FirstOrDefault();
            student.Tbl_Club = club;
            db.Tbl_Student.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetStudent(int id)
        {
            var val = db.Tbl_Student.Find(id);

            List<SelectListItem> studentClubDropDown = (from i in db.Tbl_Club.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = i.ClubName,
                                                            Value = i.ClubId.ToString()
                                                        }).ToList();
            ViewBag.studentClubDropDown_ViewBag = studentClubDropDown;

            return View("GetStudent", val);
        }

        public ActionResult UpdateStudent(Tbl_Student student)
        {
            var val = db.Tbl_Student.Find(student.StudentId);
            val.StudentFirstName = student.StudentFirstName;
            val.StudentLastName = student.StudentLastName;
            var club = db.Tbl_Club.Where(m => m.ClubId == student.Tbl_Club.ClubId).FirstOrDefault();
            val.StudentClub = club.ClubId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStudent(int id)
        {
            var val = db.Tbl_Student.Find(id);
            db.Tbl_Student.Remove(val);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}