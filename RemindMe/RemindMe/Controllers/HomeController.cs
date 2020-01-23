using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;
using RemindMe.Models;
using System.Web.Services;
using MongoDB.Driver;
using MongoDB.Bson;

namespace RemindMe.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            Models.Data.ConnectToMongo();
            var db = Models.Data.database;
            var Event_collection = db.GetCollection<Event>("Events");
            Event e = new Event{
                email = collection["email"],
                name = collection["name"],
                date = collection["date"],
                time = collection["time"]
            };
            Event_collection.InsertOne(e);

          
            return View("Index");
        }


        [HttpGet]
        public ActionResult SendData(String email)
        {
            Email.Send(email);
            return Json("Successfully get method executed.", JsonRequestBehavior.AllowGet);
        }
       
        
        [HttpGet]
        public ActionResult RetrieveData()
        {
            Models.Data.ConnectToMongo();
            var db = Models.Data.database;
            var collection = db.GetCollection<Event>("Events");
            var filter = Builders<Event>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }

}