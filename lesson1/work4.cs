using System;
using System.Data.SqlClient;
using System.Dynamic;
using System.Runtime.Remoting.Messaging;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool is_running = true;
            string conn_str = "Data source= COMP7A2\\SQLEXPRESS;" +
                "Initial Catalog = DataBase_1;" +
                "Integrated Security = True;" +
                "TrustServerCertificate = True";

            SqlConnection connection = new SqlConnection(conn_str);

            string[] sql_command = { "SELECT TOP 10 * FROM user2", "INSERT INTO users2(name,balance) VALUES(@name, @balance)" };


            while (is_running)
            {
                connection.Open();
                Console.WriteLine("1 - show colection");
                Console.WriteLine("2 - add users");
                Console.WriteLine("Select number");

                string choise = Console.ReadLine();
                switch (choise) {
                    case "1":
                        GetData(sql_command[0], connection); break;
                    case "2":
                        GetData(sql_command[1], connection); break;
                    case "3":
                        is_running = false; break;
                    default:
                        Console.WriteLine("pls choic number");break;
                }

                if (is_running)
                {
                    Console.WriteLine("pls choic a punkt");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            SetData(sql_command[1], connection);
            GetData(sql_command[0], connection);


        }

        static void SetData(string cmd, SqlConnection conn)
        {
            using (SqlCommand command = new SqlCommand(cmd, conn))
            {
                command.Parameters.AddWithValue("@name", "VAnia");
                command.Parameters.AddWithValue("@balance", 1000.00);
                command.ExecuteNonQuery();

            }
            conn.Close();
        }

        static void GetData(string cmd, SqlConnection conn)
        {
            using (SqlCommand command = new SqlCommand(cmd, conn))
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    double balance = reader.GetDouble(2);
                    double credit = reader.GetDouble(3);
                    double diff_balance = reader.GetDouble(4);

                }

                Console.WriteLine("ggg");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
