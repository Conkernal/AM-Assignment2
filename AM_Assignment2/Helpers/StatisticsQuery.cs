using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AM_Assignment2.Helpers
{
    public class StatisticsQuery
    {
        public void AddResults(bool Answer1, bool Answer2, bool Answer3, bool Answer4, bool Answer5, bool Answer6, string userID)
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["App_Database"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "INSERT INTO [Statistics] (SenderID, Answer1, Answer2, Answer3, Answer4, Answer5, Answer6) VALUES (@SenderID, @Answer1, @Answer2, @Answer3, @Answer4, @Answer5, @Answer6)";
            dbcommand.Parameters.AddWithValue("@SenderID", userID);
            dbcommand.Parameters.AddWithValue("@Answer1", Answer1);
            dbcommand.Parameters.AddWithValue("@Answer2", Answer2);
            dbcommand.Parameters.AddWithValue("@Answer3", Answer3);
            dbcommand.Parameters.AddWithValue("@Answer4", Answer4);
            dbcommand.Parameters.AddWithValue("@Answer5", Answer5);
            dbcommand.Parameters.AddWithValue("@Answer6", Answer6);

            dbcon.Open();
            dbcommand.ExecuteNonQuery();
            dbcon.Close();
        }
    }
}