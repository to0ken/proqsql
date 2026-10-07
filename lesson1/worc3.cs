
using System;
using System.Data.SqlClient;

namespace ConnectDB
{
    class lesson3
    {
        static void Main(string[] args)
        {
            bool running = true;
            string conn_str = "Data Source=COMP7A2\\SQLEXPRESS;" +
                              "Initial Catalog=TestIndex2;" +
                              "Integrated Security=True;" +
                              "TrustServerCertificate=True;";
            SqlConnection connection = new SqlConnection(conn_str);
            string[] sql_command = { "SELECT TOP 10 * FROM Table_1",
                "INSERT INTO Table_1(id,name,balance,credit) VALUES(@id,@name,@balance,@credit)"};

            while (running)
            {
                connection.Open();
                Console.WriteLine("Please select number");
                Console.WriteLine("1.Show table");
                Console.WriteLine("2.Add user");

                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        GetData(sql_command[0], connection);
                        break;
                    case "2":
                        SetData(sql_command[1], connection);
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("choose number for example");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("Please press any key for new example");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            
            SetData(sql_command[1], connection);
            GetData(sql_command[0], connection);
            Console.ReadKey();
        }

        static void SetData(string cmd, SqlConnection conn)
        {
            using (SqlCommand command = new SqlCommand(cmd, conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                int id = reader.GetInt32(0);
                id =+ 1;

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", "mishka");
                command.Parameters.AddWithValue("@balance", 1000.00);
                command.Parameters.AddWithValue("@credit", 300.00);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }
        static void GetData(string cmd, SqlConnection conn)
        {
            using(SqlCommand command = new SqlCommand(cmd, conn))
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    decimal balance = reader.GetDecimal(3);
                    decimal credit = reader.GetDecimal(4);
                    decimal diff_balance = reader.GetDecimal(5);

                    Console.WriteLine($"----------------\n" +
                        $"ID: {id}\n" +
                        $"Имя: {name}\n" +
                        $"Баланс: {balance}\n" +
                        $"Снятие: {credit}\n" +
                        $"Остаток: {diff_balance}\n" +
                        $"----------------");
                }
            }
            conn.Close();
        }
    }
}
