using AcademyApp.model;
using AcademyApp.model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

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
            using (var connection = new SqlConnection(conn_srt))
            {
                return connection.Query<group>("SELECT GroupName, GroupId FROM Groups;").ToList();
            }

        }

        
        
    }
}
