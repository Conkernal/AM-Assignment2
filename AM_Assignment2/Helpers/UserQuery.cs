using System.Collections.Generic;
using AM_Assignment2.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace AM_Assignment2.Helpers
{
    public class UserQuery
    {
        public List<User> GetUserByGroup(int GroupID)
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["App_Database"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "SELECT UserID FROM [User] WHERE GroupID = @GroupID";
            dbcommand.Parameters.AddWithValue("@GroupID", GroupID);

            dbcon.Open();
            var reader = dbcommand.ExecuteReader();
            var userList = new List<User>();

            while (reader.Read())
            {
                var userItem = new User();
                userItem.UserID = reader["UserID"].ToString();
                userList.Add(userItem);
            }

            dbcon.Close();
            return userList;
        }
    }
}