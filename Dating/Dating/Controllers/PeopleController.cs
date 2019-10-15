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
            Person person = db.People.Find(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
            person = db.People.Find(person.ApplicationId);

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

        public ActionResult Matching(Person person, SexualPreference sexualPreference)
        {
            var loggedInUser = User.Identity.GetUserId();
            person = db.People.Where(p => p.ApplicationId.Equals(loggedInUser)).FirstOrDefault();
            sexualPreference = db.SexualPreferences.Where(s => s.ApplicationId.Equals(loggedInUser)).FirstOrDefault();
            var personsAgePreference = sexualPreference.Age;


            foreach(Identify identify in db.Identifies)
            {
                if (personsAgePreference.Equals(identify.Age))
                {
                    var peopleId = db.Identifies.Where(i => i.Age.Equals(personsAgePreference)).Select(i => i.ApplicationId);
                    var peopleName = db.People.Where(p => p.ApplicationId.Equals(peopleId)).Select(p => p.FirstName).ToString();
                    person.Matches.Add(peopleName);
                    return PartialView(person.Matches);
                }

            }
            return PartialView();

        }


        public ActionResult SearchedPeople(string searchString) 
        {

            var searchedPeople = db.People.Where(s => s.FirstName.Equals(searchString.ToLower()));
           
            return View(searchedPeople);

        }

        public ActionResult SignalRChatAPI()
        {
            return View();
        }


        [HttpGet]
        public void GoogleGeoCodeAPI(Person person)
        {
            //var key = AIzaSyAjvSmZAIx5ytoXJmdVGlzqj8M76zlWKWs;
            //var zip = person.Location;
            //var requestUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={zip}&key={IzaSyAjvSmZAIx5ytoXJmdVGlzqj8M76zlWKWs}";

        }

        public void SetDistance()
        {

        }

        public void FindPeopleInArea()
        {
            Person person = new Person();
            var zip = person.Location;            
        }
    }
}
