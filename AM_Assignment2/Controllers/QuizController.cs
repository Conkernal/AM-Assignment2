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
            if (Answer1 == "A")
            {
                ViewData["Answer1Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer1Result"] = "/Content/Images/x mark.png";

            }

            ViewData["Answer2"] = Answer2;
            if (Answer2 == "B")
            {
                ViewData["Answer2Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer2Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer3"] = Answer3;
            if (Answer3 == "A")
            {
                ViewData["Answer3Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer3Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer4"] = Answer4;
            if (Answer4 == "C")
            {
                ViewData["Answer4Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer4Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer5"] = Answer5;
            if (Answer5 == "A")
            {
                ViewData["Answer5Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer5Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer6"] = Answer6;
            if (Answer6 == "C")
            {
                ViewData["Answer6Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer6Result"] = "/Content/Images/x mark.png";

            }
            return View();
        }

    }
}