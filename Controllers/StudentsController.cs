using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using jxgl.Data_Access_Layer;
using jxgl.Models;
using jxgl.Filters;
using jxgl.ViewModel;
namespace jxgl.Controllers
{
    [Authorize]
    
    public class StudentsController : Controller
    {
        private JXGLDBContext db = new JXGLDBContext();
        [AdminFilters]
        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }
        [AdminFilters]
        // GET: Students/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        [AdminFilters]
        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [AdminFilters]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sno,Sname,Ssex,Sacad,Spwd")] Student student)
        {
            student.Spwd = student.Sno.ToString().Substring(5);
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }
        [AdminFilters]
        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [AdminFilters]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sno,Sname,Ssex,Sacad,Spwd")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        [AdminFilters]
        // GET: Students/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        [AdminFilters]
        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        [TeacherFilters]
        public ActionResult Sinfo()
        {
            JXGLBusinessLayer students = new JXGLBusinessLayer() ;
            StudentListViewModel models = new StudentListViewModel();
            models.Students = students.GetStudents(HttpContext.Session["UserName"].ToString());
            return View("TSView",models);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
