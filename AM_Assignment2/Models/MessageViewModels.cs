using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM_Assignment2.Models
{
    public class SendMessageViewModel
    {
        [EmailAddress]
        [Required]
        public string To { get; set; }

        public string MessageSubject { get; set; }

        public string MessageBody { get; set; }
    }
}