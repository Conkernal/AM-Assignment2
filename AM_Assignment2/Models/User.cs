using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM_Assignment2.Models
{
    // Class definition for User table (application database)
    public class User
    {
        public User()
        {
            UserCreationDate = DateTime.Today; // Default value for user creation date (today)
        }
        public string UserID { get; set; }

        [Required]
        public string UserInterface { get; set; } // User interface preference

        [Required]
        [DataType(DataType.Date)]
        public DateTime UserCreationDate { get; set; }

        public DateTime? LastLoginTime { get; set; } // The ? allows this field to be nullable

        public int? GroupID { get; set; } // Group assigned to user

    }
}