using System;
using System.ComponentModel.DataAnnotations;

namespace AM_Assignment2.Models
{
    public class Message
    {

        public int MessageID { get; set; }
        
        public string ToID { get; set; } // E-mail of recipient

        public string FromID { get; set; } // E-mail of sender

        public int? GroupID { get; set; }

        public string MessageSubject { get; set; }

        public string MessageBody { get; set; }

        public DateTime MessageDate { get; set; }
    }
}