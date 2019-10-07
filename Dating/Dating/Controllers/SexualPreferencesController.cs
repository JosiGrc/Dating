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
    public class SexualPreferencesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SexualPreferences
        public ActionResult Index()
        {
            var sexualPreferences = db.SexualPreferences.Include(s => s.ApplicationId);
            return View(sexualPreferences.ToList());
        }

        // GET: SexualPreferences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SexualPreference sexualPreference = db.SexualPreferences.Find(id);
            if (sexualPreference == null)
            {
                return HttpNotFound();
            }
            return View(sexualPreference);
        }

        // GET: SexualPreferences/Create
        public ActionResult Create()
        {
            PeopleViewModels identifyInfo = new PeopleViewModels()
            {
                SexualPreference = new SexualPreference()
            };
            return View(identifyInfo);
        }

        // POST: SexualPreferences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PeopleViewModels peopleViewModels)
        {
            SexualPreference sexualPreference = peopleViewModels.SexualPreference;
            sexualPreference.ApplicationId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.SexualPreferences.Add(sexualPreference);
                db.SaveChanges();
                return RedirectToAction("Details", "People");
            }
            return RedirectToAction("Index");

        }

        // GET: SexualPreferences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SexualPreference sexualPreference = db.SexualPreferences.Find(id);
            if (sexualPreference == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.People, "Id", "FirstName", sexualPreference.ApplicationId);
            return View(sexualPreference);
        }

        // POST: SexualPreferences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Male,Female,GayMale,GayFemale,PersonId")] SexualPreference sexualPreference)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sexualPreference).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.People, "Id", "FirstName", sexualPreference.ApplicationId);
            return View(sexualPreference);
        }

        // GET: SexualPreferences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SexualPreference sexualPreference = db.SexualPreferences.Find(id);
            if (sexualPreference == null)
            {
                return HttpNotFound();
            }
            return View(sexualPreference);
        }

        // POST: SexualPreferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SexualPreference sexualPreference = db.SexualPreferences.Find(id);
            db.SexualPreferences.Remove(sexualPreference);
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
