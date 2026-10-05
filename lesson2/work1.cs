using System;
using System.Data.SqlClient;

namespace AcademyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool is_running = true;
            string connstr = ConnectDb();


            while (is_running)
            {
                Console.WriteLine("1. Просмотр всех студентов");
                Console.WriteLine("0. Выход");
                Console.Write("Введите номер действия: ");
                string choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        ShowAllStudents(connstr);
                        break;
                    case "0":
                        is_running = false;
                        break;

                    case "3":
                        ShowAllStudents(connstr);
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Введите 1 или 0.");
                        break;
                }

                if (is_running)
                {
                    Console.WriteLine("\nНажмите любую кнопку для продолжения...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static string ConnectDb()
        {
            string connectionString = "Data Source=COMP7A2\\SQLEXPRESS;" +
                "Initial Catalog=academyCollegh;" +
                "Integrated Security=True;" +
                "TrustServerCertificate=True";
            return connectionString;
        }

        static void AddGroup(string conn_srt, string group_name)
        {
            using (SqlConnection connection = new SqlConnection(conn_srt))
            {
                connection.Open();
                string sql_srt = "INSERT INTO dbo.Groups(GroupName) VALUES(@name)";
                using (SqlCommand command = new SqlCommand(sql_srt, connection))
                {
                    command.Parameters.AddWithValue("@name", group_name);

                    command.ExecuteNonQuery();
                    Console.WriteLine("Группа добавлена.");
                }
            }
        }

        static void FindStudentsByName(string conn_srt, string name)
        {
            using (SqlConnection connection = new SqlConnection(conn_srt))
            {
                connection.Open();
                string sql_srt = "SELECT s.FirstName, s.LastName, s.Age, g.GroupName " +
                 "FROM Students AS s, Groups AS g " +
                 "WHERE s.FirstName = @name " +
                 "AND s.GroupId = g.GroupId";
                using (SqlCommand command = new SqlCommand(sql_srt, connection))
                {
                    command.Parameters.AddWithValue("@name", name);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string first_name = reader.GetString(0);
                        string last_name = reader.GetString(1);
                        int age = reader.GetInt32(2);

                        string group_name = reader.GetString(3);

                        Console.WriteLine($"{first_name} | {last_name} | {age} | {group_name}");
                    }
                }
            }
        }

        static void AddStudent(string conn_srt, string first_name, string last_name, int age, string group_name)
        {
            using (SqlConnection connection = new SqlConnection(conn_srt))
            {
                connection.Open();
                string sql_srt = "INSERT INTO dbo.Students(FirstName, LastName, Age, GroupName) VALUES(@first_name, @last_name, @age, @group_name)";
                using (SqlCommand command = new SqlCommand(sql_srt, connection))
                {
                    command.Parameters.AddWithValue("@first_name", first_name);
                    command.Parameters.AddWithValue("@last_name", last_name);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@group_name", group_name);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Студент добавлен.");
                }
            }
        }

        static void ShowAllStudents(string connsrt)
        {
            using (SqlConnection connection = new SqlConnection(connsrt))
            {
                connection.Open();

                string sql_srt = "SELECT s.FirstName, s.LastName, s.Age, g.GroupName " +
                 "FROM Students AS s " +
                 "INNER JOIN Groups AS g ON s.GroupId = g.GroupId";

                using (SqlCommand command = new SqlCommand(sql_srt, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    Console.WriteLine("Имя | Фамилия | Возраст | Группа");
                    Console.WriteLine("-----------------------------------");

                    while (reader.Read())
                    {
                        string first_name = reader.GetString(0);
                        string last_name = reader.GetString(1);
                        int age = reader.GetInt32(2);

                        string group_name = reader.GetString(3);

                        Console.WriteLine($"{first_name} | {last_name} | {age} | {group_name}");
                    }
                }
            }
        }
    }
}
