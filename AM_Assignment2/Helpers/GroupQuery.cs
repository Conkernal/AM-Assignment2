using System.Collections.Generic;
using AM_Assignment2.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace AM_Assignment2.Helpers
{
    public class GroupQuery
    {
        // Get list of all groups
        public List<Group> GetAllGroups()
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["App_Database"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "SELECT GroupID, GroupName FROM [Group]";

            dbcon.Open();
            var reader = dbcommand.ExecuteReader();
            var groupList = new List<Group>();

            while (reader.Read())
            {
                var groupItem = new Group();
                groupItem.GroupID = int.Parse(reader["GroupID"].ToString());
                groupItem.GroupName = reader["GroupName"].ToString();
                groupList.Add(groupItem);
            }

            dbcon.Close();
            return groupList;
        }

        /* Returns the name of the group. Returns blank string if user doesn't have an assigned group.
         * Parameters:
         * 1. groupID (GroupID in database for Group)
         */
        public string GetGroupNameByID(int? groupID)
        {
            if (groupID.HasValue) // If user has an assigned group
            {
                var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["App_Database"].ToString());
                var dbcommand = new SqlCommand();
                dbcommand.Connection = dbcon;
                dbcommand.CommandText = "SELECT GroupName FROM [Group] WHERE GroupID = @GroupID";
                dbcommand.Parameters.AddWithValue("@GroupID", groupID);

                dbcon.Open();
                var reader = dbcommand.ExecuteReader();
                string groupName = null;

                while (reader.Read())
                {
                    groupName = reader["GroupName"].ToString();
                }
                dbcon.Close();
                return groupName;
            }
            else // Else, return blank string
            {
                return "";
            }
        }
    }
}