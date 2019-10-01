using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dating.Models;
using Microsoft.AspNet.Identity;

namespace Dating.Controllers
{
    public class IdentifiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Identifies
        public ActionResult Index()
        {
            var indetifies = db.Indetifies.Include(i => i.PersonId);
            return View(indetifies.ToList());
        }

        // GET: Identifies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identify identify = db.Indetifies.Find(id);
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
        public ActionResult Create([Bind(Include = "Id,Male,Female,GayMan,GayFemale,PeopleId,Person.Id,FirstName,LastName,Age,Location,ApplicationId")] Identify identify, Person person)
        {
            //ViewBag.PeopleId = db.People.Where(p => p.ApplicationId.ToString() == identify.PersonId.ToString()).FirstOrDefault();
            //find person in DB who is logged into app 
            _ = User.Identity.GetUserId();
            identify.PersonId = person.Id;
            //identify.personID = ID on person model
            if (ModelState.IsValid)  
            {
                db.Indetifies.Add(identify);
                db.SaveChanges();//There are FK conflicts here
                return RedirectToAction("Create");
            }
            return RedirectToAction("Create", "SexualPreferences");
        }

        // GET: Identifies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identify identify = db.Indetifies.Find(id);
            if (identify == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.People, "Id", "FirstName", identify.PersonId);
            return View(identify);
        }

        // POST: Identifies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Male,Female,GayMan,GayFemale,PersonId")] Identify identify)
        {
            if (ModelState.IsValid)
            {
                db.Entry(identify).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.People, "Id", "FirstName", identify.PersonId);
            return View(identify);
        }

        // GET: Identifies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identify identify = db.Indetifies.Find(id);
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
            Identify identify = db.Indetifies.Find(id);
            db.Indetifies.Remove(identify);
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
