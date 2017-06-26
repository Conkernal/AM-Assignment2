using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AM_Assignment2.Models;
using System.Data.SqlClient;
using System.Configuration;


namespace AM_Assignment2.Helpers
{
    public class MessageQuery
    {
        // Get list of all groups
        public List<Message> GetAllGroups()
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["App_Database"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "SELECT UserID FROM [User]";

            dbcon.Open();
            var reader = dbcommand.ExecuteReader();
            var messageList = new List<Message>();

            while (reader.Read())
            {
                var messageItem = new Message();
                messageItem.SenderID= reader["UserID"].ToString();
                messageList.Add(messageItem);
            }

            dbcon.Close();
            return messageList;
        }

        /* Returns the name of the group. Returns blank string if user doesn't have an assigned group.
         * Parameters:
         * 1. groupID (GroupID in database for Group)
         */
        public string GetEmailFromID(string userID)
        {

                var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Default_Connection"].ToString());
                var dbcommand = new SqlCommand();
                dbcommand.Connection = dbcon;
                dbcommand.CommandText = "SELECT Email FROM [ASPNetUsers] WHERE UserID = @UserID";
                dbcommand.Parameters.AddWithValue("@Email", userID);

                dbcon.Open();
                var reader = dbcommand.ExecuteReader();
                string email = null;

                while (reader.Read())
                {
                    email = reader["Email"].ToString();
                }
                dbcon.Close();
                return email;
            }
    }
}