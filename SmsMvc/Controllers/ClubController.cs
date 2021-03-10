using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmsMvc.Models.Entity;

namespace SmsMvc.Controllers
{
    public class ClubController : Controller
    {
        SmsMVCEntities db = new SmsMVCEntities();
        public ActionResult Index()
        {
            var club = db.Tbl_Club.ToList();
            return View(club);
        }

        [HttpGet]
        public ActionResult NewClub()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewClub(Tbl_Club club)
        {
            db.Tbl_Club.Add(club);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetClub(int id)
        {
            var getClub = db.Tbl_Club.Find(id);
            return View("GetClub", getClub);
        }

        public ActionResult UpdateClub(Tbl_Club club)
        {
            var val = db.Tbl_Club.Find(club.ClubId);
            val.ClubName = club.ClubName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClub(int id)
        {
            var val = db.Tbl_Club.Find(id);
            db.Tbl_Club.Remove(val);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}