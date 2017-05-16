using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AM_Assignment2.Models
{
    // Class definition for user type table
    public class UserType
    {
        public string UserTypeID { get; set; } // 1) Char datatype is not supported. 2) Primary key has to be named <EntityName>ID otherwise errors will be encountered
        public string UserTypeName { get; set; }
    }
}