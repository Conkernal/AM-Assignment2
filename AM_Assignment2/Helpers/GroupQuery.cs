using System.Collections.Generic;
using AM_Assignment2.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace AM_Assignment2.Helpers
{
    public class GroupQuery
    {
        public List<Group> GetAllGroups()
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["App_Database"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "SELECT GroupID, GroupName FROM [Group]";

            dbcon.Open();
            var reader = dbcommand.ExecuteReader();
            var groupList = new List<Group>();

            while(reader.Read())
            {
                var groupItem = new Group();
                groupItem.GroupID = int.Parse(reader["GroupID"].ToString());
                groupItem.GroupName = reader["GroupName"].ToString();
                groupList.Add(groupItem);
            }

            dbcon.Close();
            return groupList;
        }
    }
}