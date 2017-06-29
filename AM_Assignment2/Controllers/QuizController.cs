using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AM_Assignment2.Helpers;

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
        public ActionResult Results(string Answer1, string Answer2, string Answer3, string Answer4, string Answer5, string Answer6, string userEmail)
        {
            bool answer1Result;
            bool answer2Result;
            bool answer3Result;
            bool answer4Result;
            bool answer5Result;
            bool answer6Result;
            ViewData["Answer1"] = Answer1;
            if (Answer1 == "A")
            {
                ViewData["Answer1Result"] = "/Content/Images/checkmark.png";
                answer1Result = true;
            }
            else
            {
                ViewData["Answer1Result"] = "/Content/Images/x mark.png";
                answer1Result = false;

            }

            ViewData["Answer2"] = Answer2;
            if (Answer2 == "B")
            {
                ViewData["Answer2Result"] = "/Content/Images/checkmark.png";
                answer2Result = true;
            }
            else
            {
                ViewData["Answer2Result"] = "/Content/Images/x mark.png";
                answer2Result = false;

            }
            ViewData["Answer3"] = Answer3;
            if (Answer3 == "A")
            {
                ViewData["Answer3Result"] = "/Content/Images/checkmark.png";
                answer3Result = true;
            }
            else
            {
                ViewData["Answer3Result"] = "/Content/Images/x mark.png";
                answer3Result = false;

            }
            ViewData["Answer4"] = Answer4;
            if (Answer4 == "C")
            {
                ViewData["Answer4Result"] = "/Content/Images/checkmark.png";
                answer4Result = true;
            }
            else
            {
                ViewData["Answer4Result"] = "/Content/Images/x mark.png";
                answer4Result = false;

            }
            ViewData["Answer5"] = Answer5;
            if (Answer5 == "A")
            {
                ViewData["Answer5Result"] = "/Content/Images/checkmark.png";
                answer5Result = true;
            }
            else
            {
                ViewData["Answer5Result"] = "/Content/Images/x mark.png";
                answer5Result = false;

            }
            ViewData["Answer6"] = Answer6;
            if (Answer6 == "C")
            {
                ViewData["Answer6Result"] = "/Content/Images/checkmark.png";
                answer6Result = true;
            }
            else
            {
                ViewData["Answer6Result"] = "/Content/Images/x mark.png";
                answer6Result = false;

            }
            UserQuery userQuery = new UserQuery();
            string userID = userQuery.GetUserIDByUserEmail(@User.Identity.Name);

            StatisticsQuery statsQuery = new StatisticsQuery();
            statsQuery.AddResults(answer1Result, answer2Result, answer3Result, answer4Result, answer5Result, answer6Result, userID); // Record results

            return View();
        }

    }
}