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
namespace jxgl.Controllers
{
    [Authorize]
    [AdminFilters]
    public class TCsController : Controller
    {
        private JXGLDBContext db = new JXGLDBContext();

        // GET: TCs
        public ActionResult Index()
        {
            return View(db.TCs.ToList());
        }

        // GET: TCs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TC tC = db.TCs.Find(id);
            if (tC == null)
            {
                return HttpNotFound();
            }
            return View(tC);
        }

        // GET: TCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TCs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tno,Cno,Time,Day,Location,RoomNum,StarTime,EndTime")] TC tC)
        {
            if (ModelState.IsValid)
            {
                db.TCs.Add(tC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tC);
        }

        // GET: TCs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TC tC = db.TCs.Find(id);
            if (tC == null)
            {
                return HttpNotFound();
            }
            return View(tC);
        }

        // POST: TCs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tno,Cno,Time,Day,Location,RoomNum,StarTime,EndTime")] TC tC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tC);
        }

        // GET: TCs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TC tC = db.TCs.Find(id);
            if (tC == null)
            {
                return HttpNotFound();
            }
            return View(tC);
        }

        // POST: TCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TC tC = db.TCs.Find(id);
            db.TCs.Remove(tC);
            db.SaveChanges();
            return RedirectToAction("Index");
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
