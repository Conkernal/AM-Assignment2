using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AM_Assignment2.DAL;
using AM_Assignment2.Models;
using AM_Assignment2.Helpers;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace AM_Assignment2.Controllers
{
    // Create, Read, Update and Delete functionality for Groups
    [Authorize(Roles = "Administrator")] // Secure to administrators only
    public class GroupController : Controller
    {
        private ApplicationUserManager _userManager;
        private App_Database db = new App_Database();

        // GET: Group
        public ActionResult Index()
        {
            return View(db.Group.ToList());
        }

        // GET: Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Group.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupName")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Group.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(group);
        }

        // GET: Group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Group.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,GroupName")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Group.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserQuery userQuery = new UserQuery();
            List<User> listOfUsersInGroup = userQuery.GetUserByGroup(id);
            List<string> userEmailList = new List<string>();
            if (listOfUsersInGroup.Count > 0) // If there are users still assigned to the group that's being deleted
            {
                foreach (var user in listOfUsersInGroup)
                {
                    userEmailList.Add(userQuery.GetUserEmailByUserID(user.UserID));
                }
                ViewData["UserEmailList"] = userEmailList;
                ViewData["UserIDList"] = listOfUsersInGroup;
                return RedirectToAction("UnsafeDeletion", new { groupID = id });
            }
            else // Delete group
            {
                Group group = db.Group.Find(id);
                db.Group.Remove(group);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Group/UnsafeDeletion/groupID
        // Description: If admin tries to delete group that has users still assigned to it (referential integrity), then display the users affected
        [HttpGet]
        public ActionResult UnsafeDeletion(int groupID)
        {
            UserQuery userQuery = new UserQuery();
            List<User> qryResult = userQuery.GetUserByGroup(groupID); // Select all users in corresponding group
            List<ApplicationUser> userGroupList = new List<ApplicationUser>();

            // For each user with corresponding group ID
            foreach (var item in qryResult)
            {
                ApplicationUser identity_user = UserManager.FindById(item.UserID); // Get user from identity database
                userGroupList.Add(identity_user);
            }

            ViewData["UsersInGroup"] = userGroupList; // For View
            return View();
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
