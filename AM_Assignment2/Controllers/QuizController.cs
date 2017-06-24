using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AM_Assignment2
{
    public class QuizController : Controller
    {
        // GET: Quiz
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        // Controller

        [HttpPost]
        public ActionResult Results(string Answer1, string Answer2, string Answer3, string Answer4, string Answer5, string Answer6)
        {
            ViewData["Answer1"] = Answer1;
            ViewData["Answer2"] = Answer2;
            ViewData["Answer3"] = Answer3;
            ViewData["Answer4"] = Answer4;
            ViewData["Answer5"] = Answer5;
            ViewData["Answer6"] = Answer6;
            return View();
        }

    }
}