using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using Google.Cloud.Storage.V1;

namespace Dating.Controllers
{
    public class GoogleGeoCodeAPIsController : Controller
    {
        class StorageQuickstart
        {
            static void Main(string[] args)
            {
                // Your Google Cloud Platform project ID.
                string projectId = "YOUR-PROJECT-ID";


                // Instantiates a client.
                StorageClient storageClient = StorageClient.Create();

                // The name for the new bucket.
                string bucketName = projectId + "-test-bucket";
                try
                {
                    // Creates the new bucket.
                    storageClient.CreateBucket(projectId, bucketName);
                    Console.WriteLine($"Bucket {bucketName} created.");
                }
                catch (Google.GoogleApiException e)
                when (e.Error.Code == 409)
                {
                    // The bucket already exists.  That's fine.
                    Console.WriteLine(e.Error.Message);
                }
            }
        }
    }





























    //// GET: GoogleGeoCodeAPIs
    //public ActionResult Index()
    //{
    //    return View();
    //}

    //// GET: GoogleGeoCodeAPIs/Details/5
    //public ActionResult Details(int id)
    //{
    //    return View();
    //}

    //// GET: GoogleGeoCodeAPIs/Create
    //public ActionResult Create()
    //{
    //    return View();
    //}

    //// POST: GoogleGeoCodeAPIs/Create
    //[HttpPost]
    //public ActionResult Create(FormCollection collection)
    //{
    //    try
    //    {
    //        // TODO: Add insert logic here

    //        return RedirectToAction("Index");
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    //// GET: GoogleGeoCodeAPIs/Edit/5
    //public ActionResult Edit(int id)
    //{
    //    return View();
    //}

    //// POST: GoogleGeoCodeAPIs/Edit/5
    //[HttpPost]
    //public ActionResult Edit(int id, FormCollection collection)
    //{
    //    try
    //    {
    //        // TODO: Add update logic here

    //        return RedirectToAction("Index");
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    //// GET: GoogleGeoCodeAPIs/Delete/5
    //public ActionResult Delete(int id)
    //{
    //    return View();
    //}

    //// POST: GoogleGeoCodeAPIs/Delete/5
    //[HttpPost]
    //public ActionResult Delete(int id, FormCollection collection)
    //{
    //    try
    //    {
    //        // TODO: Add delete logic here

    //        return RedirectToAction("Index");
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}
//}
}
