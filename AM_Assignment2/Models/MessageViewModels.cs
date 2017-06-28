using System;
using System.ComponentModel.DataAnnotations;

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

    public class SendAnnouncementViewModel
    {
        [Required]
        public int To { get; set; }

        public string MessageSubject { get; set; }

        public string MessageBody { get; set; }
    }

    public class MessageViewModel
    {
        [Required]
        public string FromID { get; set; }

        public string MessageSubject { get; set; }

        public DateTime MessageDate { get; set; }

        public string MessageBody { get; set; }
    }
}