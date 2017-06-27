using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM_Assignment2.Models
{
    public class Statistics
    {
        [Required]
        public string StatisticsID { get; set; } //Number of rows
        [Required]
        public string SenderID { get; set; }    //UserID

        public string Answer1 { get; set; } //Individual questions
        public string Answer2 { get; set; } //
        public string Answer3 { get; set; } //
        public string Answer4 { get; set; } //
        public string Answer5 { get; set; } //
        public string Answer6 { get; set; } //

    }
}