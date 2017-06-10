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
        [HttpPost]
        public ActionResult Results(bool semantic, bool nonsemantic, string contactMethod, bool table, bool span, bool article)
        {
            ViewBag.ContactMethod = contactMethod;
            var list = new List<String>();
            var list2 = new List<String>();
            if (semantic) list.Add("semantic - correct");
            if (nonsemantic) list.Add("non-semantic - wrong");
            if (table) list2.Add("table - wrong");
            if (span) list2.Add("span - correct");
            if (article) list2.Add("article - wrong");
            ViewBag.InformMethods = list;
            ViewBag.SomethingMethods = list2;
            return View();
        }

    }
}