using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dating.Models;
using Dating.ViewModels;
using Microsoft.AspNet.Identity;

namespace Dating.Controllers
{
    public class IdentifiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Identifies
        public ActionResult Index()
        {
            var indetifies = db.Identifies.Include(i => i.ApplicationId);
            return View(indetifies.ToList());
        }

        // GET: Identifies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identify identify = db.Identifies.Find(id);
            if (identify == null)
            {
                return HttpNotFound();
            }
            return View(identify);
        }

        // GET: Identifies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Identifies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PeopleViewModels peopleViewModels)
        {

            Identify identify = peopleViewModels.Identify;
            //identify.ApplicationId = peopleViewModels.Person.ApplicationId;
            

            if (ModelState.IsValid)  
            {
                db.Identifies.Add(identify);
                db.SaveChanges();//There are FK conflicts here
                return RedirectToAction("Create");
            }
            return RedirectToAction("Create");
        }

        // GET: Identifies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identify identify = db.Identifies.Find(id);
            if (identify == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.People, "Id", "FirstName", identify.ApplicationId);
            return View(identify);
        }

        // POST: Identifies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Gender,Race,Personality,PersonId")] Identify identify)
        {
            if (ModelState.IsValid)
            {
                db.Entry(identify).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.People, "Id", "FirstName", identify.ApplicationId);
            return View(identify);
        }

        // GET: Identifies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identify identify = db.Identifies.Find(id);
            if (identify == null)
            {
                return HttpNotFound();
            }
            return View(identify);
        }

        // POST: Identifies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Identify identify = db.Identifies.Find(id);
            db.Identifies.Remove(identify);
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
