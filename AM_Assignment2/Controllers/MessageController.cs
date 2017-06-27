using AM_Assignment2.DAL;
using AM_Assignment2.Helpers;
using AM_Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AM_Assignment2.Controllers
{
    public class MessageController : Controller
    {
        private App_Database db = new App_Database();
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Message/Inbox
        public ActionResult Inbox()
        {
            return View();
        }
        
        // GET: /Message/New
        public ActionResult New(SendMessageViewModel model)
        {
            return View();
        }

        // POST: /Message/ProcessNewMessage
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessNewMessage(SendMessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                ViewData["To"] = model.To;
                ViewData["MessageSubject"] = model.MessageSubject;
                ViewData["MessageBody"] = model.MessageBody;
                MessageQuery messageQuery = new MessageQuery();
                messageQuery.SendMessage(model.To, User.Identity.Name, model.MessageSubject, model.MessageBody);
                return RedirectToAction("Inbox", "Message");
            }
            else
            {
                return RedirectToAction("New", "Message");
            }
        }
    }
}