namespace AM_Assignment2.Models
{
    public class MessageRead
    {
        public int MessageReadID { get; set; } // Auto incrementing primary key
        public int MessageID { get; set; } // MessageID foreign key (primary key of Message table)
        public string ReaderID { get; set; } // E-mail of reader
        public bool MarkedAsRead { get; set; } // Whether message has been read by the recipient
    }
}