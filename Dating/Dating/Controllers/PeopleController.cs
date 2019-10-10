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
            //var searchString = "";
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

        public ActionResult Matches(Identify identify)
        {
            Person person = new Person();
            SexualPreference sexualPreference = new SexualPreference();  

            IEnumerable<Person> matchedPeople = db.People;

            if (identify.Age == sexualPreference.Age)
            {
                person.FirstName = db.People.Where(p => p.ApplicationId == sexualPreference.ApplicationId).ToString();
            }
            else if(identify.Gender.Equals(sexualPreference.Gender))
            {
                person.FirstName = db.People.Where(p => p.ApplicationId == sexualPreference.ApplicationId).ToString();
            }
            else if (identify.Personality.Equals(sexualPreference.Personality))
            {
                person.FirstName = db.People.Where(p => p.ApplicationId == sexualPreference.ApplicationId).ToString();
            }
            else if (identify.Race.Equals(sexualPreference.Race))
            {
                person.FirstName = db.People.Where(p => p.ApplicationId == sexualPreference.ApplicationId).ToString();
            }

            return View(matchedPeople);
        }


        public ActionResult SearchedPeople(string searchString) 
        {
            Person person = new Person();

            IEnumerable<Person> searchedPeople = db.People;

            foreach(Person item in searchedPeople)
            {
                if(!String.IsNullOrEmpty(searchString))
                {
                    searchedPeople = db.People.Where(p => p.FirstName.Contains(searchString));
                    return View(searchedPeople);
                }
            }
            return View(searchedPeople);

        }

        public ActionResult SignalRChatAPI()
        {
            return View();
        }

        public ActionResult GoogleGeoCodeAPI()
        {
            return View();
        }
    }
}
