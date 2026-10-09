using AcademyApp.model;
using System;
using System.Collections.Generic;
using AcademyApp.model;
using System.Data.SqlClient;

namespace AcademyApp.data
{
    internal class Grouprepos
    {
        private readonly string conn_srt;
        public Grouprepos(string connection_string)
        {

            conn_srt = connection_string;
        }

        public List<group> FindAllGroup()
        {
            var groups = new List<group>();
            SqlConnection connection = new SqlConnection(conn_srt);
            connection.Open();
            string sql = "SELECT GroupName, GroupId FROM Groups;";
            SqlCommand command = new SqlCommand(sql, connection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                groups.Add(new group()
                {

                    GroupName = reader.GetString(0),
                   
         
                    GroupId = reader.GetInt32(1),
                });

            }
            connection.Close(); 
            return groups;
        }
        
    }
}
