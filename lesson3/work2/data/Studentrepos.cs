using AcademyApp.model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace AcademyApp.data
{
    internal class Studentrepos
    {
        private readonly string conn_srt;
        public Studentrepos(string connection_string)
        {

            conn_srt = connection_string;
        }

        public List<student> FindAllStudents2()
        {
            var students = new List<student>();
            SqlConnection connection = new SqlConnection(conn_srt);
            connection.Open();
            string sql = "SELECT FirstName, Lastname, Age, GroupId FROM Students;";
            SqlCommand command = new SqlCommand(sql, connection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                students.Add(new student()
                {

                    FirstName = reader.GetString(0),
                    LastName = reader.GetString(1),
                    Age = reader.GetInt32(2),
                    GroupId = reader.GetInt32(3),
                });

            }
            return students;
        }

        public List<student> FindAllStudents()
        {
            var students = new List<student>();
            using (var connection = new SqlConnection(conn_srt))
            {
                return connection.Query<student>("SELECT FirstName, LastName, Age, GroupId FROM Students;").ToList();
            }

        }


        public student FindStudentBeId(string id)
        {
            var student = new student();
            using (var connection = new SqlConnection(conn_srt))
            {
                return connection.QueryFirstOrDefault<student>("SELECT FirstName, LastName, Age, GroupId " +
                    "FROM Students WHERE StudentId = @Id", new { @Id = id });
            }

        }

        public void AddStudent(string first_name, string last_name, string age, string group_id)
        {
            var student = new student
            {
                FirstName = first_name,
                LastName = last_name,
                Age = int.Parse(age),
                GroupId = int.Parse(group_id)
            };
            using (var connection = new SqlConnection(conn_srt))

            {
                string sql = "INSERT INTO students(FirstName, LastName, Age, GroupId)" +
                    "VALUES(@FirstName, @LastName, @Age, @GroupId)";
                connection.Execute(sql, new { @FirstName = first_name, LastName =last_name, Age = age, GroupId = group_id });
            }
        }
    }
}
