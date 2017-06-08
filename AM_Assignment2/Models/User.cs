using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AM_Assignment2.Models
{
    // Class definition for User table (application database)
    public class User
    {
        public string UserID { get; set; }
        public string UserInterface { get; set; } // User interface preference
    }
}