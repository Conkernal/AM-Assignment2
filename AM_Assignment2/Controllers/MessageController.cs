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
                List<string> MessageFormErrorList = new List<string>();
                ViewData["To"] = model.To;
                ViewData["MessageSubject"] = model.MessageSubject;
                ViewData["MessageBody"] = model.MessageBody;
                MessageQuery messageQuery = new MessageQuery();

                bool safe = true; // Initialize to true and set to false if error is found

                if (string.IsNullOrEmpty(model.MessageBody) || string.IsNullOrWhiteSpace(model.MessageBody)) // Check if message body is empty
                {
                    MessageFormErrorList.Add("Message doesn't contain a message");
                    safe = false;
                }
                if (string.IsNullOrEmpty(model.To))
                {
                    MessageFormErrorList.Add("Recipient e-mail address not set");
                    safe = false;
                }
                UserQuery userQuery = new UserQuery();
                if (userQuery.CheckIfUserExists(model.To) == false) // Check if recipient is a valid user
                {
                    MessageFormErrorList.Add("User with e-mail address " + model.To + " doesn't exist");
                    safe = false;
                }

                if (safe == true) // If there are no errors, proceed with sending the message
                {
                    messageQuery.SendMessage(model.To, User.Identity.Name, model.MessageSubject, model.MessageBody);
                    return RedirectToAction("Inbox", "Message");
                }
                else
                {
                    TempData["MessageFormError"] = MessageFormErrorList;
                    return RedirectToAction("New", "Message");
                }
            }
            else
            {
                return RedirectToAction("New", "Message");
            }
        }


        // GET: /Message/Announcement
        public ActionResult Announcement()
        {
            return View();
        }

        // POST: /Message/ProcessNewMessage
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessAnnouncement(SendAnnouncementViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<string> MessageFormErrorList = new List<string>();
                ViewData["To"] = model.To;
                ViewData["MessageSubject"] = model.MessageSubject;
                ViewData["MessageBody"] = model.MessageBody;
                MessageQuery messageQuery = new MessageQuery();

                bool safe = true; // Initialize to true and set to false if error is found

                if (string.IsNullOrEmpty(model.MessageBody) || string.IsNullOrWhiteSpace(model.MessageBody)) // Check if message body is empty
                {
                    MessageFormErrorList.Add("Message doesn't contain a message");
                    safe = false;
                }

                if (safe == true) // If there are no errors, proceed with sending the message
                {
                    messageQuery.SendMessage(model.To, User.Identity.Name, model.MessageSubject, model.MessageBody);
                    return RedirectToAction("Inbox", "Message");
                }
                else
                {
                    TempData["MessageFormError"] = MessageFormErrorList;
                    return RedirectToAction("New", "Message");
                }
            }
            else
            {
                return RedirectToAction("New", "Message");
            }
        }
    }
}