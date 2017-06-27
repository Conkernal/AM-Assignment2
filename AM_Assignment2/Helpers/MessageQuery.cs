using AM_Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AM_Assignment2.Helpers
{
    public class MessageQuery
    {
        // Send message (store in database so it can be viewed by recipient)
        public void SendMessage(string toID, string fromID, string messageSubject, string messageBody)
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["App_Database"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "INSERT INTO [Message] (ToID, FromID, MessageSubject, MessageBody, MessageDate) VALUES (@ToID, @FromID, @MessageSubject, @MessageBody, @MessageDate)";
            dbcommand.Parameters.AddWithValue("@ToID", toID);
            dbcommand.Parameters.AddWithValue("@FromID", fromID);
            dbcommand.Parameters.AddWithValue("@MessageSubject", messageSubject);
            dbcommand.Parameters.AddWithValue("@MessageBody", messageBody);
            dbcommand.Parameters.AddWithValue("@MessageDate", DateTime.Now);

            dbcon.Open();
            dbcommand.ExecuteNonQuery();
            dbcon.Close();
        }

        public List<Message> GetInbox(string userEmail)
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["App_Database"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "SELECT MessageID, ToID, FromID, MessageSubject, MessageBody, MessageDate FROM [Message] WHERE ToID = @ToID ORDER BY MessageDate";
            dbcommand.Parameters.AddWithValue("@ToID", userEmail);

            dbcon.Open();
            var reader = dbcommand.ExecuteReader();
            var messageList = new List<Message>();

            while (reader.Read())
            {
                var message = new Message();
                message.MessageID = int.Parse(reader["MessageID"].ToString());
                message.ToID = reader["ToID"].ToString();
                message.FromID = reader["FromID"].ToString();
                message.MessageSubject = reader["MessageSubject"].ToString();
                message.MessageBody = reader["MessageBody"].ToString();
                message.MessageDate = (DateTime)reader["MessageDate"];
                messageList.Add(message);
            }

            dbcon.Close();
            return messageList;
        }
    }
}