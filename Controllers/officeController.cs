using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class officeController : Controller
    {
        private officeEntities db = new officeEntities();

        // GET: /office/
        public ActionResult Index()
        {
            return View(db.type_.ToList());
        }

        // GET: /office/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type_ type_ = db.type_.Find(id);
            if (type_ == null)
            {
                return HttpNotFound();
            }
            return View(type_);
        }

        // GET: /office/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /office/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="type")] type_ type_)
        {
            if (ModelState.IsValid)
            {
                db.type_.Add(type_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type_);
        }

        // GET: /office/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type_ type_ = db.type_.Find(id);
            if (type_ == null)
            {
                return HttpNotFound();
            }
            return View(type_);
        }

        // POST: /office/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="type")] type_ type_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(type_);
        }

        // GET: /office/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type_ type_ = db.type_.Find(id);
            if (type_ == null)
            {
                return HttpNotFound();
            }
            return View(type_);
        }

        // POST: /office/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            type_ type_ = db.type_.Find(id);
            db.type_.Remove(type_);
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
