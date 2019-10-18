using Dating.Models;
using Dating.ViewModels;
using GoogleMapsApi.Entities.Common;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using static Dating.Models.Geocode;
using static System.Net.WebRequestMethods;

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

    
        public ActionResult Matches(Person person, SexualPreference sexualPreference)
        {
            string personId = User.Identity.GetUserId();
            person = db.People.Where(p => p.ApplicationId.Equals(personId)).FirstOrDefault();
            sexualPreference = db.SexualPreferences.Where(s => s.ApplicationId.Equals(personId)).FirstOrDefault();
            person.Matches = new List<Person>();


            foreach (Identify identify in db.Identifies)
            {
                Person newPerson = new Person();
                //person.Matches.Prepend(newPerson);

                if (identify.Age.Equals(sexualPreference.Age) && identify.Gender.Equals(sexualPreference.Gender) && identify.Personality.Equals(sexualPreference.Personality) && identify.Race.Equals(sexualPreference.Race))
                {
                    //var ageMatchId = db.Identifies.Where(i => i.Age.Equals(sexualPreference.Age) && i.Gender.Equals(sexualPreference.Gender) && i.Personality.Equals(sexualPreference.Personality) && i.Race.Equals(sexualPreference.Race)).Select(i => i.ApplicationId).FirstOrDefault();
                    newPerson = db.People.Where(p => p.ApplicationId.Equals(identify.ApplicationId)).FirstOrDefault();
                    person.Matches.Add(newPerson);
                }
                else if (sexualPreference.Age.Equals(identify.Age) && sexualPreference.Gender.Equals(identify.Gender) && sexualPreference.Personality.Equals(identify.Personality))
                {
                    //var ageMatchId = db.Identifies.Where(i => i.Age.Equals(sexualPreference.Age) && i.Gender.Equals(sexualPreference.Gender) && i.Personality.Equals(sexualPreference.Personality)).Select(i => i.ApplicationId).FirstOrDefault();
                    newPerson = db.People.Where(p => p.ApplicationId.Equals(identify.ApplicationId)).FirstOrDefault();
                    person.Matches.Add(newPerson);
                }
                else if (sexualPreference.Age.Equals(identify.Age) && sexualPreference.Gender.Equals(identify.Gender))
                {
                    //var ageMatchId = db.Identifies.Where(i => i.Age.Equals(sexualPreference.Age) && i.Gender.Equals(sexualPreference.Gender)).Select(i => i.ApplicationId).FirstOrDefault();
                    newPerson = db.People.Where(p => p.ApplicationId.Equals(identify.ApplicationId)).FirstOrDefault();
                    person.Matches.Add(newPerson);
                }
                else if (sexualPreference.Age.Equals(identify.Age))
                {
                    //var ageMatchId = db.Identifies.Where(i => i.Age.Equals(sexualPreference.Age)).Select(i => i.ApplicationId).FirstOrDefault();
                    newPerson = db.People.Where(p => p.ApplicationId.Equals(identify.ApplicationId)).FirstOrDefault();
                    person.Matches.Add(newPerson);
                }
                
            }

            //if (identify.Age.Equals(sexualPreference.Age) && identify.Gender.Equals(sexualPreference.Gender) && identify.Personality.Equals(sexualPreference.Personality) && identify.Race.Equals(sexualPreference.Race))
            //{

            //}
                return View(person.Matches);
        }

        public void FindingPercentageOfMatch()
        {
            Identify identify = new Identify();
            SexualPreference sexualPreference = new SexualPreference();
            var mainMatch = identify.Age.Equals(sexualPreference.Age) && identify.Gender.Equals(sexualPreference.Gender) && identify.Personality.Equals(sexualPreference.Personality) && identify.Race.Equals(sexualPreference.Race);

            if (mainMatch == true) 
            {

            }
        }


        public ActionResult SearchedPeople(string searchString)
        {            
            var peopelQuery = from p in db.People where ((string.IsNullOrEmpty(searchString) ? true : p.FirstName.Contains(searchString))) select p;


            //List<Person> filteredPeople = new List<Person>();

            //foreach(Person person in db.People)
            //{
            //    if (person.FirstName.ToLower() == searchString.ToLower())
            //    {
            //        filteredPeople.Add(person);
            //    }
            //    else if (person.LastName.ToLower().Equals(searchString.ToLower()))
            //    {
            //        filteredPeople.Add(person);
            //    }
            //}

            return View(peopelQuery);

        }

        public ActionResult Chat()
        {
            return View();
        }

        public void PersonsLocation()
        {
            //var locationData = GetLocation("da10b68dea6a42d58ea8fea66a57b886").Result;
        }


        //[HttpGet]
        //public void GetLocation(string key)
        //{
        //    key = "AIzaSyAjvSmZAIx5ytoXJmdVGlzqj8M76zlWKWs";

        //    var result = new WebClient().DownloadString(requestUri);
        //    GeoCode geocode = JsonConvert.DeserializeObject<GeoCode>(result);
        //    return geocode;

        //}

        public string ConvertAddressToGoogleFormat(Person person)
        {
            string googleFormatAddress = person.Zipcode.ToString();
            return googleFormatAddress;
        }

        public Geocode Geolocate(int zipcode)
        {
            string key = "AIzaSyAjvSmZAIx5ytoXJmdVGlzqj8M76zlWKWs";
            var requestUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={zipcode}&key={key}";
            var result = new WebClient().DownloadString(requestUrl);
            Geocode geocode = JsonConvert.DeserializeObject<Geocode>(result);
            return geocode;
        }




    }
}
