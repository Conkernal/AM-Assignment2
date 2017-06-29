using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM_Assignment2.Models
{
    public class Statistics
    {
        public int StatisticsID { get; set; } //Number of rows
        [Required]
        public string SenderID { get; set; }    //UserID

        public bool Answer1 { get; set; } //Individual questions
        public bool Answer2 { get; set; } //
        public bool Answer3 { get; set; } //
        public bool Answer4 { get; set; } //
        public bool Answer5 { get; set; } //
        public bool Answer6 { get; set; } //

    }
}