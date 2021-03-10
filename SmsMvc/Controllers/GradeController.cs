using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmsMvc.Models.Entity;

namespace SmsMvc.Controllers
{
    public class GradeController : Controller
    {
        // GET: Grade
        SmsMVCEntities db = new SmsMVCEntities();
        public ActionResult Index()
        {
            var list = db.Tbl_Grade.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult NewGrade()
        {
            // Class DropDown
            List<SelectListItem> gradeClassViewBag = (from i in db.Tbl_Class.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = i.ClassName,
                                                          Value = i.ClassId.ToString()
                                                      }).ToList();
            ViewBag.gradeClass_ViewBag = gradeClassViewBag;

            // Student DropDown
            List<SelectListItem> gradeStudentViewBag = (from i in db.Tbl_Student.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = i.StudentFirstName + " " + i.StudentLastName,
                                                            Value = i.StudentId.ToString()
                                                        }).ToList();
            ViewBag.gradeStudent_ViewBag = gradeStudentViewBag;

            return View();
        }

        [HttpPost]
        public ActionResult NewGrade(Tbl_Grade grade)
        {
            var getClass = db.Tbl_Class.Where(m => m.ClassId == grade.Tbl_Class.ClassId).FirstOrDefault();
            grade.Tbl_Class = getClass;

            var getStudent = db.Tbl_Student.Where(m => m.StudentId == grade.Tbl_Student.StudentId).FirstOrDefault();
            grade.Tbl_Student = getStudent;

            // calculate grade average 
            decimal average = (Convert.ToDecimal(grade.Exam1) + Convert.ToDecimal(grade.Exam2) + Convert.ToDecimal(grade.Exam3) + Convert.ToDecimal(grade.Project)) / 4;
            grade.Average = average;

            //calculate status
            if (average >= 45)
            {
                grade.Status = true;
            }
            else
            {
                grade.Status = false;
            }

            db.Tbl_Grade.Add(grade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetGrade(int id)
        {
            var getGrade = db.Tbl_Grade.Find(id);

            // Class DropDown
            List<SelectListItem> gradeClassViewBag = (from i in db.Tbl_Class.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = i.ClassName,
                                                          Value = i.ClassId.ToString()
                                                      }).ToList();
            ViewBag.gradeClass_ViewBag = gradeClassViewBag;

            // Student DropDown
            List<SelectListItem> gradeStudentViewBag = (from i in db.Tbl_Student.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = i.StudentFirstName + " " + i.StudentLastName,
                                                            Value = i.StudentId.ToString()
                                                        }).ToList();
            ViewBag.gradeStudent_ViewBag = gradeStudentViewBag;


            return View("GetGrade", getGrade);
        }

        public ActionResult UpdateGrade(Tbl_Grade grade)
        {
            var val = db.Tbl_Grade.Find(grade.GradeId);
            //class
            var gradeClass = db.Tbl_Class.Where(m => m.ClassId == grade.Tbl_Class.ClassId).FirstOrDefault();
            val.ClassId = gradeClass.ClassId;
            //student
            var gradeStudent = db.Tbl_Student.Where(m => m.StudentId == grade.Tbl_Student.StudentId).FirstOrDefault();
            val.StudentId = gradeStudent.StudentId;

            val.Exam1 = grade.Exam1;
            val.Exam2 = grade.Exam2;
            val.Exam3 = grade.Exam3;
            val.Project = grade.Project;

            decimal average = (Convert.ToDecimal(grade.Exam1) + Convert.ToDecimal(grade.Exam2) + Convert.ToDecimal(grade.Exam3) + Convert.ToDecimal(grade.Project)) / 4;
            val.Average = average;

            if (average >= 45)
            {
                val.Status = true;
            }
            else
            {
                val.Status = false;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteGrade(int id)
        {
            var grade = db.Tbl_Grade.Find(id);
            db.Tbl_Grade.Remove(grade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}