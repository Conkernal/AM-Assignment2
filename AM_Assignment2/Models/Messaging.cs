using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace AM_Assignment2.Models
{
    public class Message
    {
        [Required]
        public int MessageID { get; set; }
        [Required]
        public string SenderID { get; set; }
        [Required]
        public string RecipientID { get; set; }
        [Required]
        public string MessageTitle{ get; set; }
        [Required]
        public string MessageBody { get; set; }
        [Required]
        public DateTime MsgTimeStamp { get; set; }

    }



}