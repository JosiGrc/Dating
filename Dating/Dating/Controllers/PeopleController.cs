using Dating.Models;
using Dating.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Dating.Controllers
{
    public class PeopleController : Controller
    {

        //Member Variables            

        private ApplicationDbContext db = new ApplicationDbContext();

        //Methods


        // GET: People
        public ActionResult Index()
        {
            var personId = User.Identity.GetUserId();
            var personInfo = db.People.Where(c => c.ApplicationId.ToString() == personId);
            return View(personInfo);
        }

        // GET: People/Details/5
        public ActionResult Details()
        {
            var personId = User.Identity.GetUserId();
            var personInfo = db.People.Where(c => c.ApplicationId.ToString() == personId).FirstOrDefault();
            return View(personInfo);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PeopleViewModels peopleViewModels)
        {
            Person person = peopleViewModels.Person;
            //Identify identify = peopleViewModels.Identify;
            //SexualPreference sexualPreference = peopleViewModels.SexualPreference;
       
            peopleViewModels.Person.ApplicationId = User.Identity.GetUserId();
            //peopleViewModels.Identify.ApplicationId = User.Identity.GetUserId();


            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return RedirectToAction("Create", "Identifies");

        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Age,Location,ApplicationId")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person== null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        public void GettingMatches(Identify identify)
        {
            Person person = new Person();
            var possibleMatches = db.SexualPreferences.Where(s => s.Age == identify.Age && s.Gender.ToString() == identify.Gender.ToString() && s.Race.ToString() == identify.Race.ToString() && s.Personality.ToString() == identify.Personality.ToString());
            //var namesOfMatches = db.SexualPreferences.Find(User.Identity.GetUserId);


        }


    }
}
