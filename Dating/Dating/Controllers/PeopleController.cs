using Dating.Models;
using Dating.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

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
            person.ApplicationId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Create", "Identifies");
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

        public void GettingMatches(Identify identify, SexualPreference sexualPreference)
        {
            Person person = new Person();
            var possibleMatches = db.SexualPreferences.Where(s => s.Age == identify.Age && s.Gender.ToString() == identify.Gender.ToString() && s.Race.ToString() == identify.Race.ToString() && s.Personality.ToString() == identify.Personality.ToString());
            var userId = User.Identity.GetUserId();
            var percent = possibleMatches.Count();
            if (percent > 2)
            {
                if (person.ApplicationId == userId && person.ApplicationId == sexualPreference.ApplicationId)
            {
                person.Matches.Add(person.FirstName);
            }
            }

            
        }

  
        public ActionResult SearchForPeople(string searchString, string sortOrder)
        {
            Person person = new Person();
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var searchingPeople = from p in db.People select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                var searchedPeople = db.People.Where(p => p.FirstName.Contains(searchString) || p.FirstName.Contains(searchString));

                switch (sortOrder)
                {
                    case "person.FirstName":
                        searchedPeople = searchedPeople.OrderByDescending(s => s.FirstName);
                        break;
                    case "person.LastName":
                        searchedPeople = searchedPeople.Where(s => s.LastName == person.LastName);
                        break;
                    default:
                        searchedPeople = searchedPeople.OrderBy(s => s.LastName);
                        break;
                }
            }           
            return View(searchingPeople);
        }

    }
}
