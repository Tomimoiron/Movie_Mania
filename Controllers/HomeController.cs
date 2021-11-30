using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movie_Mania_2.Data;
using Movie_Mania_2.Models;

namespace Movie_Mania_2.Controllers
{
    public class HomeController : Controller
    {
        private Movie_Mania_2Context db = new Movie_Mania_2Context();
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}