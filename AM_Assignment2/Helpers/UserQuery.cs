﻿using System.Collections.Generic;
using AM_Assignment2.Models;
using System.Data.SqlClient;
using System.Configuration;
using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AM_Assignment2.Helpers
{
    public class UserQuery
    {

        // Checks if user exists in Identity database with a given e-mail. Returns true if record is found.
        // * userEmail: the e-mail address assigned the user
        public bool CheckIfUserExists(string userEmail)
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "SELECT COUNT(Email) FROM [AspNetUsers] WHERE Email = @UserEmail";
            dbcommand.Parameters.AddWithValue("@UserEmail", userEmail);

            dbcon.Open();
            int userExists = (int)dbcommand.ExecuteScalar();
            dbcon.Close();
            if (userExists == 1) // User only exists if 1 record is found
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Returns the UserIDs of users that are in a certain group
         * groupID: GroupID of Group in database
         */
        public List<User> GetUserByGroup(int groupID)
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["App_Database"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "SELECT UserID FROM [User] WHERE GroupID = @GroupID";
            dbcommand.Parameters.AddWithValue("@GroupID", groupID);

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

        // Get details of all users
        public List<User> GetAllUsers()
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["App_Database"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "SELECT UserID, UserCreationDate, LastLoginTime, GroupID FROM [User]";

            dbcon.Open();
            var reader = dbcommand.ExecuteReader();
            var userList = new List<User>();

            while (reader.Read())
            {
                var userItem = new User();
                userItem.UserID = reader["UserID"].ToString();
                userItem.UserCreationDate = (DateTime)reader["UserCreationDate"];
                if (!DBNull.Value.Equals(reader["LastLoginTime"])) // Check if null first since LastLoginTime is an optional attribute
                {
                    userItem.LastLoginTime = System.Convert.ToDateTime(reader["LastLoginTime"]);
                }
                if (!DBNull.Value.Equals(reader["GroupID"])) // Check if null first since GroupID is an optional attribute
                {
                    userItem.GroupID = int.Parse(reader["GroupID"].ToString());
                }
                userList.Add(userItem);
            }

            dbcon.Close();

            return userList;
        }

        // Delete user record from application database
        public void DeleteUser(string userID)
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["App_Database"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "DELETE FROM [User] WHERE UserID = @UserID";
            dbcommand.Parameters.AddWithValue("@UserID", userID);

            dbcon.Open();
            dbcommand.ExecuteNonQuery();
            dbcon.Close();
        }

        // Get UserEmail by UserID
        public string GetUserEmailByUserID(string userID)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser foundUser = userManager.FindById(userID);
            return foundUser.Email;
        }

        public string GetUserIDByUserEmail(string userEmail)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser foundUser = userManager.FindByEmail(userEmail);
            return foundUser.Id;
        }

        // Get Role by UserID
        public IList<string> GetRoleByUserID(string userID)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser foundUser = userManager.FindById(userID);
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext())
            );
            var RolesForUser = userManager.GetRoles(userID);
            return RolesForUser;
        }

        // Update group by UserID
        public void UpdateGroupByUserID(string userID, int groupID)
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["App_Database"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "UPDATE [User] SET GroupID = @GroupID WHERE UserID = @UserID";
            dbcommand.Parameters.AddWithValue("@GroupID", groupID);
            dbcommand.Parameters.AddWithValue("@UserID", userID);

            dbcon.Open();
            dbcommand.ExecuteNonQuery();
            dbcon.Close();
        }

        // Get user group from user
        public int GetGroupByUserID(string userID)
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["App_Database"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "SELECT GroupID FROM [User] WHERE UserID = @UserID";
            dbcommand.Parameters.AddWithValue("@UserID", userID);

            dbcon.Open();
            var reader = dbcommand.ExecuteReader();

            var GroupData = new Group();
            while (reader.Read())
            {
                if (!DBNull.Value.Equals(reader["GroupID"])) // Check if null first since GroupID is an optional attribute
                {
                    GroupData.GroupID = int.Parse(reader["GroupID"].ToString());
                }
            }

            dbcon.Close();

            return GroupData.GroupID;
        }
    }
}