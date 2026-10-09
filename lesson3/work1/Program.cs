using System;
using System.Data.SqlClient;
using AcademyApp.data;

namespace AcademyApp
{
    internal class Program
    {
        static string connection_string = "Data Source=COMP7A2\\SQLEXPRESS;" +
                "Initial Catalog=academyCollegh;" +
                "Integrated Security=True;" +
                "TrustServerCertificate=True";

        static Studentrepos student_repo = new Studentrepos(connection_string);
        static void Main(string[] args)
        {

            bool is_running = true;
            


            while (is_running)
            {
                Console.WriteLine("1. Просмотр всех студентов");
                Console.WriteLine("0. Выход");
                Console.Write("Введите номер действия: ");
                string choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        ShowAllStudent();
                        break;
                    case "0":

                        break;

                    case "3":
                        ShowAllStudents();
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

        static void ShowAllStudent()
        {
            var student = student_repo.FindAllStudents();
        }
         
        static void ShowAllStudents() { }
    }
}
