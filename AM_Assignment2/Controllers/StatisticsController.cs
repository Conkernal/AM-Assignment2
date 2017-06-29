using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AM_Assignment2.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

        // GET: Statistics/ViewStats
        public ActionResult ViewStats()
        {
            return View();
        }
    }
}